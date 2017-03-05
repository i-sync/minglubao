using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DataEntity.Item;
using MLMGC.BLL.Item;
using MLMGC.BLL.Enterprise;
using System.Collections.Specialized;

namespace Web.Enterprise.Handler
{
    /// <summary>
    /// Item 的摘要说明
    /// </summary>
    public class Item : IHttpHandler, IRequiresSessionState
    {
        NameValueCollection nv;
        MLMGC.Security.EnterprisePage bp;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            nv = HttpContext.Current.Request.Form;
            bp = new MLMGC.Security.EnterprisePage(true);
            switch (nv["key"])
            {
                case "deletemessage"://企业总监删除个人用户留言
                    DeleteMessage();
                    break;
                case "updatestatus": //企业总监申述个人申请
                    UpdateStatus();
                    break;
                case "deletemember"://企业总监删除个人用户
                    DeleteMember();
                    break;
                case "delete":    //企业总监删除名录
                    Delete();
                    break;
                case "deleteall":   //企业总监 删除所有共享名录
                    DeleteAll();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }

        /// <summary>
        /// 总监删除个人用户留言信息
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
            bool flag = new T_ItemMessage().Delete(data);
            HttpContext.Current.Response.Write(flag?"1":"0");
        }

        /// <summary>
        /// 企业总监申述个人用户项目申请
        /// </summary>
        private void UpdateStatus()
        {
            int aid, status,type;
            if (!int.TryParse(nv["aid"], out aid) || !int.TryParse(nv["status"], out status) || !int.TryParse(nv["type"], out type))
            {
                HttpContext.Current.Response.Write("0");
                return;
            }
            E_ItemApply data = new E_ItemApply();
            data.EnterpriseID = bp.EnterpriceID;
            data.ApplyType = type == 1 ? EnumApplyType.申请加入 : EnumApplyType.申请退出;
            data.ApplyID = aid;
            data.SetStatus = status;
            int result = new T_ItemApply().Update(data);
            HttpContext.Current.Response.Write(result.ToString());
        }

        /// <summary>
        /// 总监删除个人用户
        /// </summary>
        private void DeleteMember()
        { 
            int uid;
            if (!int.TryParse(nv["uid"], out uid))
            {
                HttpContext.Current.Response.Write("0");
                return;
            }
            //判断是否为总监,若不是则返回。
            if (bp.RoleID != ((int)MLMGC.DataEntity.User.EnumRole.总监))
            {
                HttpContext.Current.Response.Write("0");
                return;
            }
            E_ItemMember data = new E_ItemMember();
            data.EnterpriseID = bp.EnterpriceID;
            data.UserID = uid;
            bool flag = new T_ItemMember().Delete(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 企业总监删除名录
        /// </summary>
        private void Delete()
        {
            string ids = nv["ids"];
            if (MLMGC.COMP.StringUtil.IsStringArrayList(ids))
            {
                E_ItemClientInfo data = new E_ItemClientInfo();
                data.EnterpriseID = bp.EnterpriceID;
                data.UserID = 0;
                data.ClientInfoIDs = ids;
                bool b = new T_ItemClientInfo().Delete(data);
                HttpContext.Current.Response.Write(b ? "1" : "0");
            }
            else
            {
                HttpContext.Current.Response.Write("参数错误");
            }
        }

        /// <summary>
        /// 企业总监删除所有共享名录
        /// </summary>
        private void DeleteAll()
        {
            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = bp.EnterpriceID;
            data.Status = MLMGC.DataEntity.Item.EnumClientStatus.共享;
            bool b = new T_ItemClientInfo().DeleteAll(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
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