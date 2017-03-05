using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise.Allot
{
    public partial class AllotStatistics : MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            if (!IsPostBack)
            {
                databind();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        public void databind()
        {
            string start = Requests.GetQueryString("startdate");
            string end = Requests.GetQueryString("enddate");
            txtStartDate.Text = start;
            txtEndDate.Text = end;

            E_Allot data = new E_Allot();
            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;
            data.Page = new E_Page();
            if (!string.IsNullOrEmpty(start))
            {
                data.Page.StartDate = Convert.ToDateTime(start);
            }
            if (!string.IsNullOrEmpty(end))
            {
                data.Page.EndDate = Convert.ToDateTime(end);
            }
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            DataTable dt = new T_Allot().AllotStatistics(data);
            rpList.DataSource = dt;
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string url = string.Format(Request.Url.AbsolutePath + "?startdate={0}&enddate={1}",txtStartDate.Text,txtEndDate.Text);
            Response.Redirect(url);
        }
    }
}