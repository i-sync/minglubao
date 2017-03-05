using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.User;
using System.Data;
using MLMGC.COMP;
using MLMGC.BLL.User;

namespace Web.pinsou
{
    public partial class AutoLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取品搜数据
            long id = Requests.GetQueryLong("id", 0);
            long userid = Requests.GetQueryLong("userid", 0);
            string username = Requests.GetQueryString("username");
            E_PinsouUser data = new E_PinsouUser();
            data.ID = id;
            data.Pinsou_UserID = userid;
            data.UserName = username;

            //查询登录信息
            DataTable dt = new T_User().Pinsou_AutoLogin(data);
            if (dt != null && dt.Rows.Count == 1)//验证通过
            {
                string name = dt.Rows[0]["Email"].ToString();
                string pwd = dt.Rows[0]["password"].ToString();
                Login(name, pwd);
            }
            else  //验证失败
            {
                Jscript.ShowMsg("信息错误无法登录！", this);
                return;
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        protected void Login(string name,string pwd)
        {
            E_User data = new E_User();
            data.UserType = (int)MLMGC.DataEntity.User.UserType.个人用户;
            data.UserName = name;
            data.Password = MLMGC.COMP.EncryptString.EncryptPassword(pwd);//加密
            data = new MLMGC.BLL.User.T_User().UserLogin(data);

            if (data != null)
            {
                E_PersonalUser dataPU = new E_PersonalUser();
                dataPU.UserID = data.UserID;
                dataPU.PersonalID = data.EnterpriseID;
                dataPU.UserName = data.UserName;
                dataPU.Password = data.Password;
                new MLMGC.Security.PersonalPage().Login(dataPU);

                //登录成功添加日志
                data.LoginIP = HttpContext.Current.Request.ServerVariables["Remote_Addr"];
                data.Browser = HttpContext.Current.Request.Browser.Type;
                data.Resolution = "";
                bool flag = new MLMGC.BLL.User.T_User().AddLoginInfo(data);
                Response.Redirect("../Personal/Default.aspx");
            }
            else
            {
                Jscript.ShowMsg("密码错误！", this);
                return;
            }
        }
    }
}