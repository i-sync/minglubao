using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;

namespace WebAdmin
{
    public partial class UpdatePassword : MLMGC.Security.AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 确认按钮点击事件
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
            E_Admin data = new E_Admin();
            data.AdminID = UserID;            
            data.Password = MLMGC.COMP.EncryptString.EncryptPassword(oldPassword);
            data.NewPassword = MLMGC.COMP.EncryptString.EncryptPassword(newPassword);
            bool flag = new T_Admin().UpdatePassword(data);
            
            MLMGC.COMP.Jscript.ShowMsg(string.Format("修改{0}！",flag?"成功":"失败"), this);            
        }
    }
}