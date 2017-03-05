using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;
using MLMGC.COMP;

namespace Web.Enterprise.Controls
{
    public partial class Upload : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            ///获取要上传到的文件路径
            string folder = Requests.GetQueryString("folder");
            if (string.IsNullOrEmpty(folder))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", ";alert('路径错误！');", true);
                return;
            }

            string filename = File1.PostedFile.FileName.ToString();
            string fileType = filename.Substring(filename.LastIndexOf(".") + 1).ToLower(); //得到文件类型
            if (filename.Length == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", ";alert('请选择要上传的文件！');", true);
                return;
            }
            string newFile = UserID+"_"+new Random().Next() + "." + fileType;  //新的文件名
            string savepath = folder+ "/";  
            string filefolder = Server.MapPath("/Resource/") + savepath;
            if (!System.IO.Directory.Exists(filefolder))
            {
                System.IO.Directory.CreateDirectory(filefolder);
            }
            string url = ConfigurationManager.AppSettings["VirtualName"].ToString() + "/" + folder + "/" + newFile;
            string newPath = filefolder+ newFile;          
            byte[] btE = new byte[File1.PostedFile.ContentLength];
            File1.PostedFile.InputStream.Read(btE, 0, File1.PostedFile.ContentLength);
            System.IO.FileStream fsE = new System.IO.FileStream(newPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            fsE.Write(btE, 0, btE.Length);
            fsE.Close();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "parent.funupload('" + url + "');", true);

        }
    }
}