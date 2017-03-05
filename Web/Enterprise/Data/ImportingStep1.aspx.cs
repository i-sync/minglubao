using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity;
using MLMGC.COMP;

namespace Web.Enterprise.Data
{
    public partial class ImportingStep1 : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUpload1.VirtualPath = MLMGC.COMP.Config.EnterpriseDataFoler + "/" + EnterpriceID.ToString() + "/";
            FileUpload1.FileExt = MLMGC.COMP.Config.ImportingExt;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            List<PFileInfo> list = FileUpload1.Upload(EPUserTMRID.ToString());
            if (list!=null && list.Count == 1)//==1 上传成功
            {
                string url = list[0].FilePath + list[0].FileAddress;
                bool b = new ImportingData(EnterpriceID, EPUserTMRID).CreateXML(url);
                if (b)
                {
                    System.IO.File.Delete(url);
                    Response.Redirect("ImportingStep2.aspx");
                }
                else
                {
                    Jscript.AlertAndRedirect(this, "操作失败", "ImportingStep1.aspx");
                }
            }
            else
            {
                Jscript.AlertAndRedirect(this, "上传文件失败", "ImportingStep1.aspx");
            }
        }
    }
}