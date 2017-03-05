using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;

namespace Web.Enterprise
{
    public partial class UpdatePassword : MLMGC.Security.EnterprisePage
    {
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
            string oldPassword = txtEPOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirm = txtConfirm.Text;
            if (oldPassword == "" || newPassword == "" || confirm == "")
            {
                MLMGC.COMP.Jscript.ShowMsg("请认真填写以上内容", this);
                return;
            }
            if (newPassword != confirm)
            {
                MLMGC.COMP.Jscript.ShowMsg("两次密码输入不一致", this);
                return;
            }
            E_User data = new E_User();
            data.EnterpriseID = EnterpriceID;
            data.UserID = UserID;
            data.Password =MLMGC.COMP.EncryptString.EncryptPassword(oldPassword);
            data.NewPassword =MLMGC.COMP.EncryptString.EncryptPassword(newPassword);
            bool flag = new T_User().UpdatePassword(data);
            if (flag)
            {
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "修改密码", IP = MLMGC.COMP.Requests.GetRealIP() });
                MLMGC.COMP.Jscript.ShowMsg("修改成功", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("修改失败", this);
            }
        }
    }
}