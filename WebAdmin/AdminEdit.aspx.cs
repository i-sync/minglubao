using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;
using MLMGC.COMP;

namespace WebAdmin
{
    public partial class AdminEdit : MLMGC.Security.AdminPage
    {
        protected string type = string.Empty;
        protected int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取操作类型：添加还是修改
            type = Requests.GetQueryString("type");
            id = Requests.GetQueryInt("id", 0);
            if(!IsPostBack & type=="update")
            {
                databind();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind()
        {
            E_Admin data = new E_Admin();
            data.AdminID = id;
            data = new T_Admin().GetModel(data);
            if (data != null)
            {
                txtName.Text = data.UserName;
            }
        }

        /// <summary>
        /// 点击确定按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                Jscript.ShowMsg("请输入用户名", this);
                return;
            }
            if (string.IsNullOrEmpty(password) & type == "add")
            {
                Jscript.ShowMsg("添加用户时必须输入密码", this);
                return;  
            }
            if (password != confirm)
            {
                Jscript.ShowMsg("两次密码输入不一致", this);
                return;
            }

            E_Admin data = new E_Admin();
            data.AdminID = id;
            data.UserName = name;
            data.Password = string.IsNullOrEmpty(password) ? "" : EncryptString.EncryptPassword(password);

            //先判断一下用户名是否存在
            bool b = new T_Admin().Exists(data);
            if (b)
            {
                Jscript.ShowMsg("用户名已存在", this);
                return;
            }

            bool flag =false;
            if (type == "add")
            {
                flag = new T_Admin().Add(data);
            }
            else if(type=="update")
            {
                flag = new T_Admin().Update(data);
            }
            if (flag)
            {
                Jscript.AlertAndRedirect(this, "操作成功", "adminlist.aspx");
            }
            else
            {
                Jscript.ShowMsg("操作失败",this);
            }
        }
    }
}