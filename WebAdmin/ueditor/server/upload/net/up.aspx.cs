using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MLMGC.COMP;

namespace Web.ueditor.server.upload.net
{
    public partial class up : System.Web.UI.Page
    {
        string uploadPath = Config.GetAppSettings("VirtualName") +"/"+ Config.UploadFileFolder;            //"Uploads";   //保存路径
        string fileType = ".jpg,.jpeg,.gif,.png,.bmp";   //文件允许格式
        int fileSize = 2048;    //文件大小限制，单位KB
        string state = "SUCCESS";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpPostedFile oFile = Request.Files[0];
                string fileExtension = System.IO.Path.GetExtension(oFile.FileName).ToLower();
                if (fileType.ToLower().IndexOf(fileExtension) > -1)//检测是否为允许的上传文件类型
                {
                    if (this.fileSize * 1024 >= oFile.ContentLength)
                    {
                        try
                        {
                            string DirectoryPath;
                            // 取消下面注释按文件夹归档储存
                            //DirectoryPath = uploadPath + DateTime.Now.ToString("yyyy-MM");
                            DirectoryPath = uploadPath;
                            string sFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");  //文件名称
                            string FullPath = "/" + DirectoryPath + "/" + sFileName + fileExtension;//最终文件路径
                            if (!Directory.Exists(Server.MapPath("/" + DirectoryPath)))
                                Directory.CreateDirectory(Server.MapPath("/" + DirectoryPath));
                            oFile.SaveAs(Server.MapPath(FullPath));
                            //Response.Write("parent.reloadImg(‘" + Page.ResolveUrl(FullPath) + "‘);" + "location.href=‘upload.aspx?url=" + Page.ResolveUrl(FullPath) + "‘;");

                            string retPath = "/" + DirectoryPath + "/" + sFileName + fileExtension;

                            Response.Write("{'url':'" + retPath + "','title':'" + sFileName + "','state':'" + state + "'}");
                            return;

                        }
                        catch
                        {

                            //MessageBox.ShowAndRedirect(this, "上传文件失败。" + ex.Message, "upload.aspx");
                            state = "上传文件失败！";

                        }
                    }
                    else
                    {
                        //MessageBox.ShowAndRedirect(this, "上传文件大小超过限制。", "upload.aspx");
                        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "<script>alert('上传文件大小超过限制。');location.href='upload.aspx'</script>");
                        state = "上传文件大小超过限制！";
                    }
                }
                else
                {
                    //MessageBox.ShowAndRedirect(this, "上传文件扩展名是不允许的扩展名。", "upload.aspx");
                    //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "<script>alert('上传文件扩展名是不允许的扩展名。');location.href='upload.aspx'</script>");
                    state = "上传文件扩展名是不允许的扩展名！";
                }
                Response.Write("{'url':'','title':'','state':'" + state + "'}");
            }
        }
    }
}