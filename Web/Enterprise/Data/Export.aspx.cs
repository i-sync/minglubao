using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.COMP;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;

namespace Web.Enterprise.Data
{
    public partial class Export : MLMGC.Security.EnterprisePage
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
            Dictionary<string, int> list = new Dictionary<string, int>();
            list.Add(EnumClientStatus.所有状态.ToString(), 0);
            list.Add(EnumClientStatus.潜在客户.ToString(), (int)EnumClientStatus.潜在客户);
            list.Add(EnumClientStatus.意向客户.ToString(), (int)EnumClientStatus.意向客户);
            list.Add(EnumClientStatus.成交客户.ToString(), (int)EnumClientStatus.成交客户);
            list.Add(EnumClientStatus.失败客户.ToString(), (int)EnumClientStatus.失败客户);
            list.Add(EnumClientStatus.报废客户.ToString(), (int)EnumClientStatus.报废客户);
            rblStatus.DataSource = list;
            rblStatus.DataTextField = "Key";
            rblStatus.DataValueField = "Value";
            rblStatus.DataBind();
            rblStatus.SelectedIndex = 0;
        }

        /// <summary>
        /// 点击导出按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = EnterpriceID;
            //data.EPUserTMRID = EPUserTMRID;
            data.SetStatus = int.Parse(rblStatus.SelectedValue.ToString());
            DataSet ds = new T_ClientInfoData().LeaderDataExport(data);
            if (ds != null)
            {
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "名录导出", IP = MLMGC.COMP.Requests.GetRealIP() });
                Jscript.ShowMsg("数据导出成功", this);
                ExportDataSet(ds, "导出——" + DateTime.Now.ToString("yyyyMMddHHss") + "(" + data.Status.ToString() + ")", new List<string>() { "名录信息", "来源信息", "行业信息", "地区信息" });
            }
            else
            {
                Jscript.ShowMsg("数据导出失败", this);
            }
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