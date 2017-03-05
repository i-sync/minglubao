using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MLMGC.COMP;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;
using System.Web.SessionState;
using System.Net.Json;

namespace WebAdmin.Handler
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class User : IHttpHandler,IRequiresSessionState
    {
        System.Collections.Specialized.NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            nv = context.Request.Form;
            context.Response.ContentType = "text/plain";
            string type = nv["type"];
            switch (type)
            { 
                case "status":
                    Status();
                    break;
                case "delete":
                    Delete();
                    break;
                case "adminexists":
                    AdminExists();
                    break;
                case "admindelete":
                    AdminDelete();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }
        /// <summary>
        /// 修改个人用户状态
        /// </summary>
        public void Status()
        {
            int uid = Convert.ToInt32(nv["uid"]);
            int pid = Convert .ToInt32( nv["pid"]);
            int status = Convert.ToInt32(nv["status"]);

            E_Personal data = new E_Personal();
            data.UserID = uid;
            data.PersonalID = pid;
            data.Status = status;
            bool flag = new T_Personal().PersonalStatus(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }
        /// <summary>
        /// 删除个人用户
        /// </summary>
        public void Delete()
        { 
            int uid = Convert.ToInt32(nv["uid"]);
            int pid = Convert .ToInt32( nv["pid"]); 
            
            E_Personal data = new E_Personal();
            data.UserID = uid;
            data.PersonalID = pid;
            int result = new T_Personal().Delete(data);
            HttpContext.Current.Response.Write(result);
        }

        /// <summary>
        /// 判断管理员是否存在
        /// </summary>
        private void AdminExists()
        {
            int id;
            if (!int.TryParse(nv["id"], out id))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            string name = nv["name"];

            E_Admin data = new E_Admin();
            data.AdminID = id;
            data.UserName = name;

            bool flag = new T_Admin().Exists(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }
               
        /// <summary>
        /// 删除管理员
        /// </summary>
        private void AdminDelete()
        {
            int id;
            if (!int.TryParse(nv["id"], out id))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_Admin data = new E_Admin();
            data.AdminID = id;

            bool flag = new T_Admin().Delete(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
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