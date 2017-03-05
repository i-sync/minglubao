using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;
using MLMGC.COMP;

namespace Web.User
{
    public partial class RegStep2 : System.Web.UI.Page
    {
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            string gid = Requests.GetQueryString("gid");
            string email = Requests.GetQueryString("email");
            string code = Requests.GetQueryString("code");
            if (email != "" && code != "")
            {
                hdUID.Value = gid;
                txtUserName.Text = email;
                txtEmailCode.Text = code;
                txtEmailCode.Enabled = true;
            }
            else
            {
                //生成新用户编码
                hdUID.Value = Guid.NewGuid().ToString();
            }
        }


        /// <summary>
        /// 点击注册按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //获取界面数据
            string username = txtUserName.Text.Trim();
            string emailcode = txtEmailCode.Text.Trim();
            string uid = hdUID.Value;
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirm.Text.Trim();
            string realname = txtRealName.Text.Trim();
            string mobile = txtMobile.Text.Trim();
            string tel = txtTel.Text.Trim();
            string fax = txtFax.Text.Trim();
            string address = txtAddress.Text.Trim();
            if (string.IsNullOrWhiteSpace(username) | string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirm) || string.IsNullOrWhiteSpace(emailcode) ||
                string.IsNullOrWhiteSpace(realname) || string.IsNullOrWhiteSpace(mobile) || string.IsNullOrWhiteSpace(address))
            {
                MLMGC.COMP.Jscript.ShowMsg("请认真填写以上内容", this);
                return;
            }
            if (password != confirm)
            {
                MLMGC.COMP.Jscript.ShowMsg("两次密码不一致", this);
                return;
            }

            E_Personal data = new E_Personal();
            data.UserName = username;
            data.EmailCode = emailcode;
            data.UID = Guid.Parse(uid);
            data.Password = EncryptString.EncryptPassword(password);
            data.RealName = realname;
            data.Sex = Convert.ToInt32(rbSex.SelectedValue);
            data.Mobile = mobile;
            data.Tel = tel;
            data.Fax = fax;
            data.Address = address;

            int result = new T_Personal().AddPersonal(data);
            switch (result)
            {
                case -2:
                    MLMGC.COMP.Jscript.ShowMsg("添加失败，用户名已存在", this);
                    break;
                case -1:
                    MLMGC.COMP.Jscript.ShowMsg("验证码失效", this);
                    break;
                case 0:
                    MLMGC.COMP.Jscript.ShowMsg("注册失败", this);
                    break;
                case 1:
                    Response.Redirect("regstep3.aspx");                  
                    break;
            }
        }
    }
}