using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.Leader
{
    public partial class Search : MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            if (!IsPostBack) { databind(); }
        }
        /// <summary>
        /// 页面初始化加载数据
        /// </summary>
        protected void databind()
        {
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;

            data.ClientName = Requests.GetQueryString("keyword");
            txtKeyword.Text = data.ClientName;

            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            DataSet ds = new T_ClientInfo().LeaderList(data);
            if (ds != null && ds.Tables.Count > 1)//判断是否有数据返回
            {
                //绑定列表
                rpList.DataSource = ds.Tables[0];
                rpList.DataBind();
                //绑定统计
                DataTable dt = MLMGC.COMP.EnumUtil.ToTable<EnumClientStatus>();
                //过虑 “所有状态”,"共享" 二项
                dt.Rows.Remove(dt.Select("name='"+EnumClientStatus.所有状态+"'")[0]);
                dt.Rows.Remove(dt.Select("name='" + EnumClientStatus.共享 + "'")[0]);
                dt.Columns.Add("Amount", typeof(int));
                dt.Columns.Add("Percentage", typeof(string));
                foreach (DataRow dr in dt.Rows)
                {
                    if (ds.Tables[1].Select("Status=" + dr["id"]).Count() > 0)
                    {
                        dr["Amount"] = ds.Tables[1].Select("[Status]=" + dr["id"])[0]["Amount"];
                        dr["Percentage"] = ds.Tables[1].Select("[Status]=" + dr["id"])[0]["Percentage"];
                    }
                    else
                    {
                        dr["Amount"] = "0";
                        dr["Percentage"] = "0.00";
                    }
                }
                //绑定列表
                rpStatistics.DataSource = dt;
                rpStatistics.DataBind();

            }

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }
    }
}