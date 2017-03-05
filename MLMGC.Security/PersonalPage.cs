using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using MLMGC.DataEntity.User;

namespace MLMGC.Security
{
    public class PersonalPage : System.Web.UI.Page
    {
        private int _userid = 0,_personalid;
        private string _loginusername = "";
        private string _password = "";
        private readonly string cookiekey = "mlmgc";
        private bool _ischecklogin = true;

        private bool _isopen = false;//标识该个人用户加入的企业项目是否开通：默认为未开通

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
        public string Password { get { return _password; } }
        /// <summary>
        /// 用户选择的角色信息
        /// </summary>
        public int PersonalID { get { return _personalid; } }
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

        public PersonalPage(bool IsBind = false)
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
            if (Session["UserID"] != null && Session["LoginUserName"] != null && Session["Password"] != null && Session["PersonalID"] != null)
            {
                _userid = Convert.ToInt32(Session["UserID"].ToString());
                _loginusername = Session["LoginUserName"].ToString();
                _password = Session["Password"].ToString();
                _personalid = int.Parse(Session["PersonalID"].ToString());
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
                    _loginusername = cookie["LoginUserName"].ToString();
                    _password = cookie["Password"].ToString();
                    _personalid = Convert.ToInt32(cookie["PersonalID"].ToString());
                }
            }
            string msg = "";
            if (_userid == 0)
            {
                msg = "您还没有登录，请<a href='/Default.aspx' target='_top'>登录</a>后进行操作！";
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
            setSession(_userid, _loginusername, _password, _personalid);
        }
        /// <summary>
        /// 设置Session状态
        /// </summary>
        /// <param name="_UserID"></param>
        /// <param name="_LoginUserName"></param>
        /// <param name="_Password"></param>
        /// <param name="_EnterpriseID"></param>
        protected void setSession(int _UserID, string _LoginUserName, string _Password, int _PersonalID)
        {
            Session["UserID"] = _UserID.ToString();
            Session["LoginUserName"] = _LoginUserName;
            Session["Password"] = _Password;
            Session["PersonalID"] = _PersonalID;
            Session.Timeout = 30;
            HttpCookie cookie = new HttpCookie(cookiekey);
            cookie["UserID"] = _UserID.ToString();
            cookie["LoginUserName"] = _LoginUserName;
            cookie["Password"] = _Password;
            cookie["PersonalID"] = _PersonalID.ToString();
            cookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
            MLMGC.COMP.CookieEncrypt.SetCookie(cookie);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="data"></param>
        public void Login(E_PersonalUser data)
        {
            if (data != null)
            {
                setSession(data.UserID, data.UserName, data.Password, data.PersonalID);
            }
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

        /// <summary>
        /// 获取个人用户所在项目企业编号
        /// </summary>
        public int EnterpriseID
        {
            get
            {
                E_Personal data = new E_Personal() { PersonalID = _personalid,UserID =_userid };
                DataTable dt = new MLMGC.BLL.User.T_Personal().GetEnterpriseID(data);
                if (dt != null && dt.Rows.Count == 1)
                {
                    int eid = Convert.ToInt32(dt.Rows[0]["EnterpriseID"]);
                    _isopen = dt.Rows[0]["OpenFlag"].ToString() == "1";
                    return eid;
                }
                return 0;
            }
        }

        /// <summary>
        /// 查看他所加入的项目企业是否开通
        /// </summary>
        public bool IsOpen
        {
            get 
            {
                return _isopen;
            }
        }

        /// <summary>
        /// 判断用户是否加入项目或加入的企业是否开通了项目
        /// </summary>
        public void IsJoin()
        {
            //判断用户是否加入了项目，或者该企业项目是否开通
            if (EnterpriseID == 0 || !IsOpen)
            {
                Server.Transfer("itemerror.aspx", false);
            }
        }
    }
}
