using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace WebAdmin.Enterprise
{
    public partial class List : System.Web.UI.Page
    {
        int pageSize = 20, pageIndex = 1;
        protected int day = 14;
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
        protected void databind()
        {
            day = Requests.GetQueryInt("day", MLMGC.COMP.Config.WarningDay);
            txtDay.Text = day.ToString();

            E_Enterprise data = new E_Enterprise();
            data.EnterpriseNames = Requests.GetQueryString("enterprisenames");
            txtEnterpriseNames.Text = data.EnterpriseNames;
            
            string start = Requests.GetQueryString("startdate");
            string end = Requests.GetQueryString("enddate");
            txtStartDate.Value = start;
            txtEndDate.Value = end;
            data.Page = new MLMGC.DataEntity.E_Page();
            if (start != "")
                data.Page.StartDate = Convert.ToDateTime(start);
            if (end != "")
                data.Page.EndDate = Convert.ToDateTime(end);

            //分页参数
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new T_Enterprise().GetList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        protected string Status(object obj)
        {
            return DateTime.Now > Convert.ToDateTime(obj) ? "已过期" : "使用中";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format(Request.Url.AbsolutePath + "?enterprisenames={0}&startdate={1}&enddate={2}&day={3}", txtEnterpriseNames.Text, txtStartDate.Value, txtEndDate.Value,txtDay.Text);
            Response.Redirect(url);
        }
    }
}