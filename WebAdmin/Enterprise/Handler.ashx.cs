using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;
using MLMGC.DataEntity.Enterprise;

namespace WebAdmin.Enterprise
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class Handler : IHttpHandler
    {
        System.Collections.Specialized.NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            nv = System.Web.HttpUtility.ParseQueryString(context.Request.Url.Query);
            switch (nv["key"])
            {
                case "100":
                    EnterpriseCodeExist();
                    break;
                case "status":
                    StatusUpdate();
                    break;
                case "itemstatus":
                    ItemStatus();
                    break;
                case "delete":
                    Delete();
                    break;
                case "itemdelete":
                    ItemDelete();
                    break;
                case "deletemessage":
                    DeleteMessage();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
            
        }
        /// <summary>
        /// 检验企业号是否已经存在
        /// </summary>
        public void EnterpriseCodeExist()
        {
            if (string.IsNullOrEmpty(nv["code"]))
            {
                HttpContext.Current.Response.Write("0");
            }
            else
            {
                HttpContext.Current.Response.Write(new MLMGC.BLL.Enterprise.T_Enterprise().Exist(new E_Enterprise(){ EnterpriseCode=nv["code"]})?"1":"2");
            }
        }

        /// <summary>
        /// 更新企业状态
        /// </summary>
        /// <remarks>tianzhenyun 2011-11-03</remarks>
        public void StatusUpdate()
        {
            int enterpriseid = Convert.ToInt32(nv["eid"]);
            int status = Convert.ToInt32(nv["status"]);
            E_Enterprise data = new E_Enterprise();
            data.EnterpriseID = enterpriseid;
            data.Status = status;
            bool flag = new T_Enterprise().StatusUpdate(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 申核企业项目状态
        /// </summary>
        public void ItemStatus()
        {
            int eid;
            if(!int.TryParse(nv["eid"],out eid))
            {
                HttpContext.Current.Response.Write("0");
                return;
            }
            E_Item data = new E_Item();
            data.EnterpriseID = eid;
            //data.Status = MLMGC.DataEntity.Enterprise.ItemStatus.申核通过;
            bool flag = new T_Item().UpdateStatus(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 删除企业
        /// </summary>
        /// <remarks>tianzhenyun 2011-12-02</remarks>
        public void Delete()
        {
            int enterpriseid = Convert.ToInt32(nv["eid"]);
            E_Enterprise data = new E_Enterprise();
            data.EnterpriseID = enterpriseid;
            bool flag = new T_Enterprise().Delete(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 后台管理员删除企业项目
        /// </summary>
        /// <remarks>tianzhenyun 2012-04-26</remarks>
        public void ItemDelete()
        {
            int eid;
            if (!int.TryParse(nv["eid"], out eid))
            {
                HttpContext.Current.Response.Write("0");
                return;
            }
            E_Item data = new E_Item();
            data.EnterpriseID = eid;
            bool flag = new T_Item().Delete(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 删除个人用户留言信息
        /// </summary>
        private void DeleteMessage()
        {
            int mid;
            if (!int.TryParse(nv["mid"], out mid))
            {
                HttpContext.Current.Response.Write("0");
                return;
            }
            E_ItemMessage data = new E_ItemMessage();
            data.ID = mid;
            bool flag = new T_ItemMessage().AdminDelete(data);
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