using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Apply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool b = new MLMGC.BLL.Enterprise.T_Apply().Add(new MLMGC.DataEntity.Enterprise.E_Apply()
            {
                EnterpriseName = txtEnterpriseName.Text,
                Address = txtAddress.Text,
                Linkman = txtLinkman.Text,
                Position = txtPosition.Text,
                Tel = txtTel.Text,
                Email = txtEmail.Text,
                Mobile = txtMobile.Text,
                Fax = txtFax.Text,
                UserAmount = int.Parse(txtUserAmount.Text)
            });
            MLMGC.COMP.Jscript.ShowMsg("申请"+(b?"成功，稍后客服人员将与您联系。":"失败"), this);
        }
    }
}