using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using MLMGC.DataEntity.WenKu;
using MLMGC.BLL.WenKu;
using System.Web.SessionState;
using System.Net.Json;

namespace Web.Handler
{
    /// <summary>
    /// WenKu 的摘要说明
    /// </summary>
    public class WenKu : IHttpHandler,IRequiresSessionState
    {
        NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            nv = HttpContext.Current.Request.Form;
            switch (nv["key"])
            { 
                case "download":
                    Download();
                    break;
                case "exists":
                    Exists();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
                   
            }
        }

        /// <summary>
        /// 添加下载记录
        /// </summary>
        private void Download()
        {
            //获取文库id
            int id;
            string usertype = nv["usertype"];
            if (!int.TryParse(nv["id"], out id))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_WenKuDownload data = new E_WenKuDownload();
            data.WenKuID = id;
            //判断用户类型：1=企业用户，2=个人用户
            if (usertype == "1")
            {
                MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
                data.UserID = ep.UserID;
                data.EnterpriseID = ep.EnterpriceID;
                data.UserType = MLMGC.DataEntity.User.UserType.企业用户;
            }
            else
            {
                MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
                data.UserID = pp.UserID;
                data.UserType = MLMGC.DataEntity.User.UserType.个人用户;
            }

            bool flag = new T_WenKuDownload().Add(data);
            //声明返回json对象
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("flag", flag ? "1" : "0"));

            //成功添加数据之后 再次获取原文件的地址。
            E_WenKu dataW = new T_WenKu().GetModel(new E_WenKu() { WenKuID = id });
            if (dataW != null)
            {
                colDR.Add(new JsonStringValue("url", MLMGC.COMP.Config.GetWenKuUrl(dataW.FileUrl)));
            }

            HttpContext.Current.Response.Write(colDR.ToString());
        }

        /// <summary>
        /// 判断上传的文档是否存在
        /// </summary>
        private void Exists()
        {
            string filename = nv["filename"];
            if (string.IsNullOrWhiteSpace(filename))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }

            E_WenKu data = new E_WenKu();
            data.FileName = filename;

            bool flag = new T_WenKu().Exists(data);
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