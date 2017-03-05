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
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int enterpriseid = Requests.GetQueryInt("eid", 0);
            if (!IsPostBack)
            {
                databind(enterpriseid);
            }
        }

        protected void databind(int enterpriseid)
        {
            E_Enterprise data = new E_Enterprise();
            data.EnterpriseID = enterpriseid;
            data = new T_Enterprise().GetModel(data);
            if (data == null)
                return;
            txtEnterpriseNames.Text = data.EnterpriseNames;
            txtLinkman.Text = data.Linkman;
            txtPosition.Text = data.Position;
            txtTel.Text = data.Tel;
            txtEmail.Text = data.Email;
            txtMobile.Text = data.Mobile;
            txtFax.Text = data.Fax;
            txtAddress.Text = data.Address;
            txtUserAmount.Text = data.UserAmount.ToString();
            txtStartDate.Text = data.StartDate.ToString();
            txtExpireDate.Text = data.ExpireDate.ToString();
            txtUserNum.Text = data.UserNum.ToString();
            txtClientNum.Text = data.ClientNum.ToString();
            txtUserName.Text = data.AdminUserName;
            txtPassword.Text = data.AdminPassword;
        }
    }
}