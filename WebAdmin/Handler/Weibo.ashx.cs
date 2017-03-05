using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MLMGC.BLL.Personal;
using MLMGC.DataEntity.Personal;

namespace WebAdmin.Handler
{
    /// <summary>
    /// Weibo 的摘要说明
    /// </summary>
    public class Weibo : IHttpHandler,IRequiresSessionState
    {
        System.Collections.Specialized.NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            nv = HttpContext.Current.Request.Form;
            context.Response.ContentType = "text/plain";
            string type = nv["key"];
            switch (type)
            { 
                case "delete":
                    DeleteWeibo();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }

        /// <summary>
        /// 后台管理员删除个人微博
        /// </summary>
        private void DeleteWeibo()
        {
            string ids = nv["ids"];
            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ids))//判断格式是否正确 格式：1,21,321
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }

            E_Weibo data = new E_Weibo();
            data.WeiboIDs = ids;

            bool flag = new T_Weibo().AdminDelete(data);
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