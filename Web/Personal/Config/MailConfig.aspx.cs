using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Personal.Config;
using MLMGC.DataEntity.Personal.Config;

namespace Web.Personal.Config
{
    public partial class MailConfig :MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind()
        {
            E_MailConfig data = new T_MailConfig().GetConfig(new E_MailConfig()
            {
                PersonalID =PersonalID
            });
            if (data == null) { return; }
            if (data.Email.IndexOf("@") > -1)
            {
                txtEmail.Text = data.Email.Substring(0, data.Email.IndexOf("@"));
                txtEmailSuffix.Text = data.Email.Substring(data.Email.IndexOf("@") + 1);
            }
            txtSMTP.Text = data.SMTP;
            txtPort.Text = data.Port.ToString();
            txtUserName.Text = data.UserName;
            txtPassword.Text = data.Password;
            txtName.Text = data.Name;
        }

        /// <summary>
        /// 点击保存按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" ||txtEmailSuffix.Text==""|| txtPassword.Text == "" || txtPort.Text == "" || txtSMTP.Text == "" || txtUserName.Text == "")
            {
                MLMGC.COMP.Jscript.ShowMsg("请认真填写以上内容", this);
                return;
            }
            E_MailConfig data = new E_MailConfig();
            data.PersonalID = PersonalID;
            data.Email = txtEmail.Text.Trim()+"@"+txtEmailSuffix.Text;
            data.SMTP = txtSMTP.Text.Trim();
            data.Port = int.Parse(txtPort.Text);
            data.UserName = txtUserName.Text.Trim();
            data.Password = txtPassword.Text;
            data.Name = txtName.Text;
            bool b = new T_MailConfig().SetConfig(data);
            MLMGC.COMP.Jscript.ShowMsg("保存" + (b ? "成功" : "失败"), this);
        }
    }
}