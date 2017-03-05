﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using MLMGC.COMP;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using System.Net.Json;

namespace Web.Enterprise.weibo
{
    /// <summary>
    /// Weibo 的摘要说明
    /// </summary>
    public class Weibo : IHttpHandler,IRequiresSessionState
    {
        System.Collections.Specialized.NameValueCollection nv;
        MLMGC.Security.EnterprisePage ep;
        public void ProcessRequest(HttpContext context)
        {
            nv = System.Web.HttpUtility.ParseQueryString(context.Request.Url.Query);
            ep = new MLMGC.Security.EnterprisePage(true);

            switch (nv["key"].ToString())
            { 
                case "add":
                    Add();
                    break;
                case "delete":
                    Delete();
                    break;
                case "newlist":
                    NewList();
                    break;
                default:
                    context.Response.Write("error");
                    break;
            }
        }

        /// <summary>
        /// 发布微博
        /// </summary>
        public void Add()
        {
            nv.Clear();
            nv = HttpContext.Current.Request.Form;
            string detail = nv["weibo"];
            if (string.IsNullOrEmpty(detail))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_Weibo data = new E_Weibo();
            data.EnterpriseID = ep.EnterpriceID;
            data.UserID = ep.UserID;
            data.Detail = MLMGC.COMP.Weibo.WeiboContent( detail);
            data.AddDate = DateTime.Now;
            bool flag = new T_Weibo().Add(data);
            if (flag)
            {
                //添加操作日志
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "发布微博", IP = MLMGC.COMP.Requests.GetRealIP() });
                //HttpContext.Current.Response.Write("{\"type\":\"succ\",\"data\":{\"weiboid\":" + data.WeiboID.ToString() + ",\"username\": \"" + data.TrueName + "\",\"date\": \"" + data.AddDate.ToString("HH:mm") + "\",\"showdate\":\"" + WEIBOHelper.ShowTime(data.AddDate) + "\",\"weibo\": \"" + data.Detail.Replace("\"", "'") + "\",\"img\":\"" + MLMGC.COMP.Config.GetEnterpriseAvatarUrl(data.Avatar) + "\"}}");
                HttpContext.Current.Response.Write("succ");
            }
            else
            {
                HttpContext.Current.Response.Write("error");
                //HttpContext.Current.Response.Write("{\"type\":\"error\",\"data\":{\"weiboid\":0}}");
            }
        }

        /// <summary>
        /// 删除自己发布的微博
        /// </summary>
        public void Delete()
        {
            int weiboid = 0;
            if (!int.TryParse(nv["weiboid"], out weiboid))
            {
                return;
            }
            E_Weibo data = new E_Weibo();
            data.EnterpriseID = ep.EnterpriceID;
            data.UserID = ep.UserID;
            data.WeiboID = weiboid;
            bool flag = new T_Weibo().Delete(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 获取最新微博信息
        /// </summary>
        public void NewList()
        {
            int weiboid = 0;
            if (!int.TryParse(nv["weiboid"], out weiboid))
            {
                //return;
            }
            E_Weibo data = new E_Weibo();
            data.EnterpriseID = ep.EnterpriceID;
            data.WeiboID = weiboid;
            T_Weibo bll = new T_Weibo();
            DataTable dt=bll.GetNewList(data);
            JsonArrayCollection jac = new JsonArrayCollection();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    JsonObjectCollection colDR = new JsonObjectCollection();
                    colDR.Add(new JsonStringValue("weiboid", dr["weiboid"].ToString()));
                    colDR.Add(new JsonStringValue("username", dr["TrueName"].ToString()));
                    colDR.Add(new JsonStringValue("date", dr["AddDate"].ToString()));
                    colDR.Add(new JsonStringValue("showdate", WEIBOHelper.ShowTime(dr["AddDate"].ToString())));
                    colDR.Add(new JsonStringValue("weibo", dr["Detail"].ToString()));
                    colDR.Add(new JsonStringValue("img", MLMGC.COMP.Config.GetEnterpriseAvatarUrl(dr["Avatar"].ToString())));
                    jac.Add(colDR);
                }
            }
            HttpContext.Current.Response.Write("{\"list\":" + jac.ToString() + "}");

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