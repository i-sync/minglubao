using System;
using System.Collections.Generic;
using System.Web;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;

namespace MLMGC.Security
{
    public class AdminPage : System.Web.UI.Page
    {
        private int _userid = 0;
        private string _loginusername = "";
        private string _password = "";
        private readonly string cookiekey = "mlmgc";
        private bool _ischecklogin = true;

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _loginusername; }
        }
        public string Password { get { return _password;  } }
        /// <summary>
        /// 是否检查登录
        /// </summary>
        public bool IsCheckLogin { set { _ischecklogin = value; } }

        protected override void OnInit(EventArgs e)
        {
            if (System.Web.HttpContext.Current != null)
            {

                _bind(true);
                base.OnInit(e);
            }
        }

        public AdminPage(bool IsBind = false)
        {
            try
            {
                if (IsBind) { _bind(false); }
            }
            catch { }
        }

        /// <summary>
        /// 绑定用户信息
        /// </summary>
        protected void _bind(bool bIsResponse)
        {
            if (_ischecklogin == false) { return; }
            //获取Session
            if (Session["UserID"] != null && Session["LoginUserName"] != null && Session["Password"] != null)
            {
                _userid = Convert.ToInt32(Session["UserID"].ToString());
                _loginusername = Session["LoginUserName"].ToString();
                _password = Session["Password"].ToString();
            }
            else
            {
                HttpCookieCollection coll = (HttpCookieCollection)HttpContext.Current.Request.Cookies;
                HttpCookie cookie = null;
                for (int i = 0; i < coll.Count; ++i)
                {
                    if (coll[i].Name.Equals(cookiekey))
                    {
                        if (cookie == null || cookie.Value.Length < coll[i].Value.Length)
                        {
                            cookie = coll[i];
                        }
                    }
                }
                if (cookie != null)
                {
                    _userid = Convert.ToInt32(cookie["UserID"].ToString());
                    _loginusername = HttpUtility.HtmlDecode(cookie["LoginUserName"].ToString());
                    _password = HttpUtility.HtmlDecode(cookie["Password"].ToString());
                    //E_Admin data = new E_Admin();
                    //data.AdminID = _userid;
                    //data.UserName = _loginusername;
                    //data.Password = _password;
                    //T_Admin bll = new T_Admin();
                    //if (!bll.CheckCookie(data))
                    //{
                    //    _userid = 0;
                    //    _loginusername = "";
                    //    _password = "";
                    //    _usertype = -1;
                    //}
                }
            }
            string msg = "";
            if (_userid == 0)
            {
                if (Server.MapPath(".").ToLower().Contains("admin"))
                {
                    msg = "您还没有登录，请<a href='/Default.aspx' target='_top'>登录</a>后进行操作！";
                }
                else
                {
                    msg = "您还没有登录，请<a href='/Default.aspx' target='_top'>登录</a>后进行操作！";
                }
            }
            else
            {
                setSession();
            }

            if (msg.Length > 0 && bIsResponse)
            {
                HttpContext.Current.Response.Write("<html><body style='background-color:#D5E5F1;font-size:14px;'><div style='text-align:center;margin:300px auto 0 auto;'>" + msg + "</div></body></html>");
                HttpContext.Current.Response.End();
            }
        }
        /// <summary>
        /// 设置Session状态
        /// </summary>
        internal void setSession()
        {
            setSession(_userid, _loginusername, _password);
        }
        /// <summary>
        /// 设置Session状态
        /// </summary>
        /// <param name="_UserID"></param>
        /// <param name="_LoginUserName"></param>
        /// <param name="_Password"></param>
        /// <param name="_UserType"></param>
        protected void setSession(int _UserID, string _LoginUserName, string _Password)
        {
            Session["UserID"] = _UserID.ToString();
            Session["LoginUserName"] = _LoginUserName;
            Session["Password"] = _Password;
            Session.Timeout = 30;
            HttpCookie cookie = new HttpCookie(cookiekey);
            cookie["UserID"] = _UserID.ToString();
            cookie["LoginUserName"] =HttpUtility.HtmlEncode(_LoginUserName);
            cookie["Password"] =HttpUtility.HtmlEncode(_Password);
            cookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        /// <summary>
        /// 退出
        /// </summary>
        public void LoginOut()
        {
            Session.Abandon();
            HttpContext.Current.Session.Clear();
            HttpCookie Cookie = new HttpCookie(cookiekey);
            Cookie.Expires = DateTime.Now.AddDays(-1d);
            System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
        }
    }
}
