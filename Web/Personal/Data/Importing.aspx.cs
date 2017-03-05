using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity;
using MLMGC.COMP;

namespace Web.Personal.Data
{
    public partial class Importing : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUpload1.VirtualPath = MLMGC.COMP.Config.PersonalDataFoler + "/"+PersonalID.ToString()+"/";
            FileUpload1.FileExt = MLMGC.COMP.Config.ImportingExt;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            //string url = @"E:\名录宝\MLMGC\Web\Resource\PersonalData\1\1.xls";
            //ImportData import = new ImportData(PersonalID, url);
            //bool b = import.Import();
            //if (b)//导入成功删除文件
            //{
            //    //System.IO.File.Delete(url);
            //}
            //Jscript.ShowMsg(b ? "全部导入成功" : String.Join("\\r\\n", import.Result), this);
            //上传文件
            List<PFileInfo> list = FileUpload1.Upload(PersonalID.ToString());
            if (list.Count == 1)//==1 上传成功
            {
                ImportData import = new ImportData(PersonalID, list[0].FilePath + list[0].FileAddress);
                bool b = import.Import();
                Jscript.AlertAndRedirect(this,b ? "导入成功" : string.Join("\\r\\n", import.Result), "Importing.aspx");
            }
            else
            {
                Jscript.ShowMsg("上传文件失败", this);
            }
        }
    }
}