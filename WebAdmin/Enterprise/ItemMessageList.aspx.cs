using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;

namespace WebAdmin.Enterprise
{
    public partial class ItemMessageList : System.Web.UI.Page
    {
        private int pageIndex = 1;
        private int pageSize = 20;
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
            string epname = Requests.GetQueryString("epname");
            string itemname = Requests.GetQueryString("itemname");
            string username = Requests.GetQueryString("username");
            string mobile = Requests.GetQueryString("mobile");
            string email = Requests.GetQueryString("email");
            int delflag = Requests.GetQueryInt("delflag", -1);
            txtEPName.Text = epname;
            txtItemName.Text = itemname;
            txtUserName.Text = username;
            txtMobile.Text = mobile;
            txtEmail.Text = email;

            cbDelFlag.Checked = delflag == 0;
            
            E_ItemMessage data = new E_ItemMessage();
            data.EnterpriseName = epname;
            data.ItemName = itemname;
            data.UserName = username;
            data.Mobile = mobile;
            data.Email = email;
            data.DelFlag = delflag;
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            rpList.DataSource = new T_ItemMessage().AdminGetList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 点击按名称进行检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format("{0}?epname={1}&itemname={2}&username={3}&mobile={4}&email={5}&delflag={6}", Request.Url.AbsolutePath, txtEPName.Text.Trim(), txtItemName.Text.Trim(), txtUserName.Text.Trim(), txtMobile.Text.Trim(), txtEmail.Text.Trim(),cbDelFlag.Checked?0:-1);
            Response.Redirect(url);
        }

        
    }
}