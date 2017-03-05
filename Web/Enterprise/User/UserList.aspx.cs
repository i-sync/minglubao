using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Enterprise;
using MLMGC.BLL.User;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DataEntity.User;
using MLMGC.COMP;

namespace Web.Enterprise.User
{
    public partial class UserList : MLMGC.Security.EnterprisePage
    {
        protected int pageSize = 20, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            //---------获取企业购买用户数量及使用数量
            DataTable dt = new T_User().GetEPUserCount(new E_User { EnterpriseID = EnterpriceID });
            if (dt != null && dt.Rows.Count == 1)
            {
                liNum.Text = dt.Rows[0]["Num"].ToString();
                liCount.Text = dt.Rows[0]["Count"].ToString();
                btnAddUser.Visible = int.Parse(dt.Rows[0]["Count"].ToString()) > int.Parse(dt.Rows[0]["Num"].ToString());
            }
                        
            string username =MLMGC.COMP.Requests.GetQueryString("username");
            string truename =MLMGC.COMP.Requests.GetQueryString("truename");
            
            //绑定用户列表
            E_User data = new E_User();
            data.EnterpriseID = EnterpriceID;
            data.UserName = username;
            data.TrueName = truename;

            txtUserName.Text = username;
            txtTrueName.Text = truename;
            
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new T_User().GetEPList(data);
            rpList.DataBind();

            tableSearch.Visible=pageList1.Visible = data.Page.TotalCount > pageSize;
            if (pageList1.Visible)
            {
                pageList1.PageSize = pageSize;
                pageList1.CurrentPageIndex = pageIndex;
                pageList1.RecordCount = data.Page.TotalCount;
            }
        }

        /// <summary>
        /// 点击检索按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format(Request.Url.AbsolutePath+"?username={0}&truename={1}",txtUserName.Text,txtTrueName.Text);
            Response.Redirect(url);
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserEdit.aspx?type=add");
        }
    }
}