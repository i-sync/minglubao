using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;

namespace WebAdmin.User
{
    public partial class PersonalList : System.Web.UI.Page
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
        protected void databind()
        {
            E_Personal data = new E_Personal();
            data.UserName = Requests.GetQueryString("username");
            txtUserName.Text = data.UserName;
            data.RealName = Requests.GetQueryString("realname");
            txtRealName.Text = data.RealName;
            
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
             
            rpList.DataSource = new T_Personal().GetList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }
        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format(Request.Url.AbsolutePath + "?username={0}&realname={1}&startdate={2}&enddate={3}", txtUserName.Text, txtRealName.Text, txtStartDate.Value, txtEndDate.Value);
            Response.Redirect(url);
        }
    }
}