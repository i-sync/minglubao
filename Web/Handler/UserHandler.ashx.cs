using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;
using MLMGC.COMP;
namespace Web.Handler
{
    /// <summary>
    /// UserHandler 的摘要说明
    /// </summary>
    public class UserHandler : IHttpHandler, IRequiresSessionState
    {
        System.Collections.Specialized.NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            nv = context.Request.Form;
            switch (nv["key"])
            { 
                case "101": //发送验证码
                    AddAuthCode();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }

        void AddAuthCode()
        {
            //------------------先验证邮箱是否可用-----------------------
            string email = nv["email"];
            bool fl = new T_Personal().AuthEmail(new E_PersonalUser { UserName = email });
            if (!fl)
            {
                HttpContext.Current.Response.Write("-2");   //-2,说明邮箱已存在
                return;
            }

            //随机码
            string emailCode = StringUtil.RndString(6);
            E_Personal data = new E_Personal();
            data.UID = Guid.Parse(nv["uid"]);
            data.EmailCode = emailCode;
            data.UserName = email;

            //发送邮件
            bool f = SendEmail(data.UID.ToString(),emailCode,email);
            if (!f)
            {
                HttpContext.Current.Response.Write("-1");   //-1,说明邮件发送失败
                return;
            }
            bool flag = new T_Personal().AddAuthCode(data);
            if (flag)
            {
                HttpContext.Current.Response.Write("1");    //验证码插入成功
            }
            else
            {
                HttpContext.Current.Response.Write("0");    //验证码插入失败
            }
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        bool SendEmail(string gid,string emailCode,string mailTo)
        {
            //string url = string.Format("{0}RegisterConfirm.aspx?uid={1}&v={2}", Pinsou.Config.SystemConfig.SysURL, uid, code);
            MLMGC.Controls.SendMail sm = new MLMGC.Controls.SendMail();

            string path = Config.RootURL + string.Format("/User/regstep2.aspx?gid={0}&email={1}&code={2}", gid, HttpContext.Current.Server.UrlEncode(mailTo), emailCode);

            string mailbody = string.Format("<p style=\"font-size:14px;font-weight:700;\">请复制该验证码:{0}，完成邮箱验证，以便您在名录宝能顺利进行注册。</p><p style=\"font-size:14px;font-weight:700;\">或者点击这里：<a href='{1}'>继续</a></p>", emailCode, path);
            string errorMessage;
            bool flag = sm.Send(mailTo, "来自名录宝的验证邮件测试邮件", mailbody,out errorMessage);
            return flag;
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