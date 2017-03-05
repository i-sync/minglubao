using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MLMGC.DataEntity.User;
using MLMGC.COMP;

namespace Web.Handler
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler,IRequiresSessionState
    {
        System.Collections.Specialized.NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            nv = context.Request.Form;
            switch (nv["type"])
            {
                case "1":
                    EPLogin();
                    break;
                case "2":
                    PILogin();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }

        /// <summary>
        /// 企业用户登录
        /// </summary>
        private void EPLogin()
        {
            string code = nv["code"];
            string name = nv["name"];
            string pwd =nv["pwd"];
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
            {
                HttpContext.Current.Response.Write("error");
                return;
            }

            E_User data = new E_User();
            data.UserType = (int)MLMGC.DataEntity.User.UserType.企业用户;
            data.EnterpriseCode = code;
            data.UserName = name;
            data.Password =EncryptString.EncryptPassword(pwd);//加密
            data = new MLMGC.BLL.User.T_User().UserLogin(data);

            if (data != null)
            {
                E_EnterpriseUser dataEU = new E_EnterpriseUser();
                dataEU.EnterpriseID = data.EnterpriseID;
                dataEU.UserID = data.UserID;
                dataEU.UserName = data.UserName;
                dataEU.Password = data.Password;
                dataEU.EPUserTMRID = 0;
                new MLMGC.Security.EnterprisePage().Login(dataEU);
                //MLMGC.Security.ActiveUser.Instance.Login(data.UserID.ToString(), MLMGC.COMP.Requests.GetRealIP());
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = data.EnterpriseID, UserID = data.UserID, LogTitle = "登录", IP = MLMGC.COMP.Requests.GetRealIP() });
                HttpContext.Current.Response.Write("1");
            }
            else
            {
                HttpContext.Current.Response.Write("2");
            }
        }

        /// <summary>
        /// 个人用户登录
        /// </summary>
        private void PILogin()
        {
            //获取数据
            string name = nv["name"].Trim();
            string pwd = nv["pwd"].Trim();
            string screen = nv["screen"];
            string auto = nv["auto"];
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(screen))
            {
                HttpContext.Current.Response.Write("error");
                return;
            }

            E_User data = new E_User();
            data.UserType = (int)MLMGC.DataEntity.User.UserType.个人用户;
            data.UserName = name;
            data.Password = MLMGC.COMP.EncryptString.EncryptPassword(pwd);//加密
            data = new MLMGC.BLL.User.T_User().UserLogin(data);

            if (data != null)
            {
                //登录成功，且选中自动登录
                if (auto == "1")
                {
                    if (HttpContext.Current.Response.Cookies["autologin"].Value == null)
                    {
                        HttpCookie AutoCookie = new HttpCookie("autologin");
                        AutoCookie.Expires = DateTime.Now.AddYears(20);
                        AutoCookie.Values.Add("name", name);
                        AutoCookie.Values.Add("pwd", pwd);
                        HttpContext.Current.Response.Cookies.Add(AutoCookie);
                    }
                }
                else //否则设置cookie过期
                {
                    HttpCookie AutoCookie = new HttpCookie("autologin");
                    AutoCookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Set(AutoCookie);
                }


                E_PersonalUser dataPU = new E_PersonalUser();
                dataPU.UserID = data.UserID;
                dataPU.PersonalID = data.EnterpriseID;
                dataPU.UserName = data.UserName;
                dataPU.Password = data.Password;
                new MLMGC.Security.PersonalPage().Login(dataPU);

                //登录成功添加日志
                data.LoginIP =HttpContext.Current.Request.ServerVariables["Remote_Addr"];
                data.Browser = HttpContext.Current.Request.Browser.Type;
                data.Resolution = screen;
                bool flag = new MLMGC.BLL.User.T_User().AddLoginInfo(data);
                HttpContext.Current.Response.Write("1");
            }
            else
            {
                HttpContext.Current.Response.Write("2");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}