using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;
using MLMGC.COMP;

namespace WebAdmin
{
    public partial class Default : MLMGC.Security.AdminPage
    {
        protected override void OnInit(EventArgs e)
        {
            IsCheckLogin = false;
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            E_Admin data = new E_Admin();
            data.UserName = StringUtil.safety(UserName.Text);
            data.Password = EncryptString.EncryptPassword(StringUtil.safety(Password.Text.Trim()));
            T_Admin bll = new T_Admin();
            E_Admin model = bll.UserLogin(data);
            if (model != null)
            {
                setSession(model.AdminID, model.UserName, model.Password);
                Response.Redirect("index.aspx");
            }
            Jscript.ShowMsg("帐号或密码错误，无法登录系统！", this);
        }
    }
}