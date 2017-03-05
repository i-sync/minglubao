using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;

namespace Web.User
{
    public partial class GetPassword : System.Web.UI.Page
    {
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 点击确定按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            if (userName == "")
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入用户名", this);
                return;
            }
            //验证通过
            E_User data = new E_User();
            data.UserName = userName;
            data.UserType = (int)UserType.个人用户;
            data.Status = (int)UserStatus.启用;
            int result = new T_Personal().GetPassword(data);
            switch(result)
            {
                case 1:
                    bool flag = SendEmail(data.Password, data.UserName);
                    if (flag)
                    { 
                        MLMGC.COMP.Jscript.ShowMsg("您的密码已发送到您的邮箱，请注意查收",this);
                    }
                    else
                    {
                        MLMGC.COMP.Jscript.ShowMsg("邮件发送失败", this);   
                    }
                    break;
                case 0:
                    MLMGC.COMP.Jscript.ShowMsg("用户名不存在", this);   
                    break;
                case -1:
                    MLMGC.COMP.Jscript.ShowMsg("用户已禁用", this);   
                    break;
                case -2:
                    MLMGC.COMP.Jscript.ShowMsg("用户账户已过期", this);   
                    break;
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        bool SendEmail(string password, string mailTo)
        {
            //string url = string.Format("{0}RegisterConfirm.aspx?uid={1}&v={2}", Pinsou.Config.SystemConfig.SysURL, uid, code);
            MLMGC.Controls.SendMail sm = new MLMGC.Controls.SendMail();

            string mailbody = string.Format("<p style=\"font-size:14px;font-weight:700;\">您的密码是:{0}</p>", password);
            string errorMessage;
            bool flag = sm.Send(mailTo, "名录宝找回密码", mailbody,out errorMessage);
            return flag;
        }
    }
}