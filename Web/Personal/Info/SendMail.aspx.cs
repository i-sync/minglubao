using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Personal.Config;
using MLMGC.BLL.Personal.Config;
using MLMGC.COMP;

namespace Web.Personal.Info
{
    public partial class SendMail : MLMGC.Security.PersonalPage
    {
        protected bool IsShow = false;
        E_MailConfig data;
        protected void Page_Load(object sender, EventArgs e)
        {
            databind();
        }

        protected void databind()
        {
            data = new T_MailConfig().GetConfig(new E_MailConfig()
            {
                PersonalID = PersonalID
            });
            if (data == null)
            {
                plSend.Visible = false;
                return;
            }
            plConfig.Visible = false;
            ltSendEmail.Text = data.Name;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (data == null)
            {
                Jscript.ShowMsg("读取配置失败", this);
                return;
            }
            
            MLMGC.Controls.SendMail SM = new MLMGC.Controls.SendMail(data.Email, data.SMTP,data.Port, data.UserName, data.Password,data.UserName);
            string errorMessage;
            bool b = SM.Send(txtReceiveEmail.Text.Trim(), txtSubject.Text.Trim(), txtContent.Text.Trim(),out errorMessage);
            Jscript.ShowMsg("发送"+(b?"成功":"失败"+errorMessage), this);
        }
    }
}