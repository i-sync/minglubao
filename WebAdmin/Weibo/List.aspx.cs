using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.COMP;
using MLMGC.DataEntity.Personal;
using MLMGC.BLL.Personal;
using MLMGC.BLL.User;

namespace WebAdmin.Weibo
{
    public partial class List : System.Web.UI.Page
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
            //绑定人员信息
            DataTable dt = new T_Personal().DataList();
            ddlPersonal.Items.Add(new ListItem("", "-1"));
            foreach (DataRow row in dt.Rows)
            {
                ddlPersonal.Items.Add(new ListItem(row["RealName"].ToString(), row["PersonalID"].ToString()));
            }

            int personalid ;
            E_Weibo data = new E_Weibo();
            data.Detail = Requests.GetQueryString("detail");//获取内容 
            txtDetail.Text = data.Detail;
            int.TryParse(Requests.GetQueryString("personalid"),out personalid);//个人编号 
            data.PersonalID = personalid;
            ddlPersonal.SelectedValue = personalid.ToString();

            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            DataTable dtList = new T_Weibo().AdminList(data);
            rpList.DataSource = dtList;
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
            string url = string.Format(Request.Url.AbsolutePath + "?detail={0}&personalid={1}", txtDetail.Text.Trim(), ddlPersonal.SelectedValue);
            Response.Redirect(url);
        }
    }
}