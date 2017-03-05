using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;

namespace WebAdmin.User
{
    public partial class LoginList : System.Web.UI.Page
    {
        int pageSize = 20, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            E_User data = new E_User();

            data.Page = new MLMGC.DataEntity.E_Page();
            data.UserName = Requests.GetQueryString("username");
            txtUserName.Text = data.UserName;
            data.Type = Requests.GetQueryInt("type",1);
            rbList.SelectedValue = data.Type.ToString();

            if (data.Type == 2)
            {
                string start = Requests.GetQueryString("startdate");
                string end = Requests.GetQueryString("enddate");
                txtStartDate.Text = start;
                txtEndDate.Text = end;
                if (start != "")
                    data.Page.StartDate = Convert.ToDateTime(start);
                if (end != "")
                    data.Page.EndDate = Convert.ToDateTime(end);
            }

            //分页参数
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new T_User().GetLoginList(data);
            rpList.DataBind();
            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 点击检索按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format(Request.Url.AbsolutePath + "?username={0}&type={1}&startdate={2}&enddate={3}", txtUserName.Text, rbList.SelectedValue, txtStartDate.Text, txtEndDate.Text);
            Response.Redirect(url);
        }
    }
}