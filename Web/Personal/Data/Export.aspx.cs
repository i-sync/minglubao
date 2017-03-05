using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.DataEntity.Personal;
using System.Data;
using MLMGC.BLL.Personal;

namespace Web.Personal.Data
{
    public partial class Export : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }
        /// <summary>
        /// 绑定类型
        /// </summary>
        protected void databind()
        {
            //--绑定状态--
           EnumUtil.BindList<EnumClientStatus>(rblStatus);
           rblStatus.SelectedIndex = 0;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            bool b = false;
            T_ClientInfo bll = new T_ClientInfo();
            E_ClientInfo data = new E_ClientInfo();
            data.PersonalID = PersonalID;
            data.SetStatus = int.Parse(rblStatus.SelectedValue.ToString());
            DataSet ds = bll.DataExport(data);
            Jscript.ShowMsg(b ? "导出成功" : "操作失败", this);
            ExportDataSet(ds, "导出——"+DateTime.Now.ToString("yyyyMMddHHss")+"("+data.Status.ToString()+")", new List<string>() {"名录信息","来源信息","行业信息","地区信息" });
            
        }

        /// <summary>
        /// DataSet导出Excel
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="filename">文件名</param>
        /// <param name="listname">Sheet表名</param>
        protected void ExportDataSet(DataSet ds, string filename, List<string> listname)
        {
            if (MLMGC.COMP.Data.DataSetIsNotNull(ds))
            {
                Response.Clear();
                Response.BufferOutput = false;
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                filename = HttpUtility.UrlEncode(filename);
                Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
                Response.ContentType = "application/ms-excel";

                StarTech.NPOI.NPOIHelper.ExportExcel(ds, Response.OutputStream, listname);
                Response.Close();
            }
            else
            {
                Jscript.ShowMsg("无法导出数据", this);
            }
        }
    }
}