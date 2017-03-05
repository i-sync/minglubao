using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MLMGC.DataEntity.User;

namespace MLMGC.Security
{
    public class EnterprisePage : System.Web.UI.Page
    {

        private int _userid = 0, _teamid = 0, _roleid = 0, _enterpriseid = 0;
        private string _loginusername = "";
        private string _password = "";
        private int _epusertmrid = 0;
        private readonly string cookiekey = "mlmgcEPU";
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
        /// 当前所在团队编号
        /// </summary>
        public int TeamID
        {
            get { return _teamid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _loginusername; }
        }
        public string Password { get { return _password; } }
        public int RoleID { get { return _roleid; } }
        /// <summary>
        /// 用户选择的角色信息
        /// </summary>
        public int EPUserTMRID { get { return _epusertmrid; } }
        public int EnterpriceID { get { return _enterpriseid; } }
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

        public EnterprisePage(bool IsBind = false)
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
            if (Session["UserID"] != null && Session["LoginUserName"] != null && Session["Password"] != null && Session["EnterpriseID"] != null && Session["EPUserTMRID"] != null && Session["TeamID"] != null && Session["RoleID"] != null)
            {
                _userid = Convert.ToInt32(Session["UserID"].ToString());
                _loginusername = Session["LoginUserName"].ToString();
                _password = Session["Password"].ToString();
                _enterpriseid = int.Parse(Session["EnterpriseID"].ToString());
                _epusertmrid = int.Parse(Session["EPUserTMRID"].ToString());
                _teamid = int.Parse(Session["TeamID"].ToString());
                _roleid = int.Parse(Session["RoleID"].ToString());
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
                    _enterpriseid = Convert.ToInt32(cookie["EnterpriseID"].ToString());
                    _epusertmrid = Convert.ToInt32(cookie["EPUserTMRID"]);
                    _teamid = Convert.ToInt32(cookie["TeamID"]);
                    _roleid = Convert.ToInt32(cookie["RoleID"]);
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
            setSession(_userid, _loginusername, _password, _enterpriseid, _epusertmrid, _teamid, _roleid);
        }
        /// <summary>
        /// 设置Session状态
        /// </summary>
        /// <param name="_UserID"></param>
        /// <param name="_LoginUserName"></param>
        /// <param name="_Password"></param>
        /// <param name="_EnterpriseID"></param>
        protected void setSession(int _UserID, string _LoginUserName, string _Password, int _EnterpriseID, int _EPUserTMRID, int _TeamID, int _RoleID)
        {
            Session["UserID"] = _UserID.ToString();
            Session["LoginUserName"] = _LoginUserName;
            Session["Password"] = _Password;
            Session["EnterpriseID"] = _EnterpriseID;
            Session["EPUserTMRID"] = _EPUserTMRID;
            Session["TeamID"] = _TeamID;
            Session["RoleID"] = _RoleID;
            Session.Timeout = 30;
            HttpCookie cookie = new HttpCookie(cookiekey);
            cookie["UserID"] = _UserID.ToString();
            cookie["LoginUserName"] = _LoginUserName;
            cookie["Password"] = _Password;
            cookie["EnterpriseID"] = _EnterpriseID.ToString();
            cookie["EPUserTMRID"] = _EPUserTMRID.ToString();
            cookie["TeamID"] = _TeamID.ToString();
            cookie["RoleID"] = _RoleID.ToString();
            cookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
            MLMGC.COMP.CookieEncrypt.SetCookie(cookie);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="data"></param>
        public void Login(E_EnterpriseUser data)
        {
            if (data != null)
            {
                setSession(data.UserID, data.UserName, data.Password, data.EnterpriseID, data.EPUserTMRID, data.TeamID, data.RoleID);
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
        /// 判断该企业是否已经开通企业项目
        /// </summary>
        public bool IsOpen
        {
            get
            {
                ///获取企业项目对象
                MLMGC.DataEntity.Enterprise.E_Item data = new DataEntity.Enterprise.E_Item();
                data.EnterpriseID = EnterpriceID;
                data = new MLMGC.BLL.Enterprise.T_Item().GetModel(data);

                bool flag = false;
                if (data != null)
                {
                    flag = data.OpenFlag == DataEntity.Enterprise.ItemOpenFlag.已开通;
                }
                return flag;
            }
        }
        /// <summary>
        /// 检查是否有项目操作权限
        /// </summary>
        public void isPermission()
        {
            ///如何当前便当角色不是总监或企业项目没有开通，则跳转到错误页面
            if (RoleID != ((int)MLMGC.DataEntity.User.EnumRole.总监) || !IsOpen)
            {
                Server.Transfer("ItemError.aspx", false);
            }
        }

        public void showMsg(string msg)
        {
            Server.Transfer("ItemError.aspx?", false);
        }
    }
}
