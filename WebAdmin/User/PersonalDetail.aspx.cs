using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;

namespace WebAdmin.User
{
    public partial class PersonalDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int uid = Requests.GetQueryInt("uid", 0);
            int pid = Requests.GetQueryInt("pid", 0);
            databind(uid, pid);
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind(int uid,int pid)
        {
            E_Personal data = new E_Personal();
            data.UserID = uid;
            data.PersonalID = pid;
            data = new T_Personal().SelectModel(data);
            if (data != null)
            {
                txtRealName.Text = data.RealName;
                txtTel.Text = data.Tel;
                txtEmail.Text = data.Email;
                txtMobile.Text = data.Mobile;
                txtFax.Text = data.Fax;
                txtAddress.Text = data.Address;
                txtClientNum.Text = data.ClientNum.ToString();
                txtUserName.Text = data.UserName;
                //txtPassword.Text = data.Password;
            }
        }
    }
}