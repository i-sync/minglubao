using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;

namespace Web.Personal
{
    public partial class UpdatePassword : MLMGC.Security.PersonalPage
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
            string oldPassword = txtOldPassword.Text;
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
            data.PersonalID = PersonalID;
            data.UserID = UserID;
            data.Password =MLMGC.COMP.EncryptString.EncryptPassword(oldPassword);
            data.NewPassword = MLMGC.COMP.EncryptString.EncryptPassword(newPassword);
            bool flag = new T_Personal().UpdatePassword(data);
            if (flag)
            {
                MLMGC.COMP.Jscript.ShowMsg("修改成功", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("修改失败", this);
            }
        }
    }
}