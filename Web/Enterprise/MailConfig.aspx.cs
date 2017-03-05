using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;

namespace Web.Enterprise
{
    public partial class MailConfig : MLMGC.Security.EnterprisePage
    {
        int userid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            userid=MLMGC.COMP.Requests.GetQueryInt("uid", UserID);
            if (!IsPostBack) { databind(); }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind()
        {
            E_MailConfig data = new T_MailConfig().GetConfig(new E_MailConfig()
            {
                EnterpriseID = base.EnterpriceID,
                UserID = userid
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int port = 0;
            E_MailConfig data = new E_MailConfig();
            data.EnterpriseID = EnterpriceID;
            data.UserID = userid;
            data.Email = txtEmail.Text.Trim() + "@" + txtEmailSuffix.Text;
            data.SMTP = txtSMTP.Text.Trim();
            int.TryParse(txtPort.Text, out port);
            data.Port = port;
            data.UserName = txtUserName.Text.Trim();
            data.Password = txtPassword.Text;
            data.Name = txtName.Text;
            bool flag = new T_MailConfig().ModifyConfig(data);
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "配置邮箱信息", IP = MLMGC.COMP.Requests.GetRealIP() });
            //MLMGC.COMP.Jscript.ShowMsg("保存"+(b?"成功":"失败"), this);
            if (flag)
            {
                MLMGC.COMP.Jscript.AlertAndRedirect(this, "保存成功", MLMGC.COMP.Requests.GetQueryString("backurl"));
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("保存失败", this);
            }
        }
    }
}