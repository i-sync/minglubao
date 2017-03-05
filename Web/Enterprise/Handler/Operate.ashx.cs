using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using System.Data;
using System.Net.Json;

namespace Web.Enterprise.Handler
{
    /// <summary>
    /// Operate 的摘要说明
    /// </summary>
    public class Operate : IHttpHandler, IRequiresSessionState
    {
        MLMGC.Security.EnterprisePage bp;
        NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //---获取用户角色等信息
            bp = new MLMGC.Security.EnterprisePage(true);
            if (bp.UserID < 1)
            {
                context.Response.Write("登录信息超时");
                return;
            }
            nv = HttpContext.Current.Request.Form;
            switch (nv["act"])
            {
                case "share"://共享
                    Share();
                    break;
                case "shareall"://共享全部
                    ShareAll();
                    break;
                case "delete":
                    Delete();
                    break;
                case "deleteall":
                    DeleteAll();
                    break;
                case "getobj"://获取分配对象
                    GetObj();
                    break;
                case "shift"://分配 转移
                    Shift();
                    break;
                case "report"://上报名录
                    Report();
                    break;
                case "lock"://锁定解锁
                    Lock();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }

        /// <summary>
        /// 共享名录
        /// </summary>
        private void Share()
        {
            string ciids = nv["ids"];
            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ciids))//判断格式是否正确 格式：1,21,321
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = bp.EnterpriceID;
            data.EPUserTMRID = bp.EPUserTMRID;
            data.Mode = EnumClientMode.共享;
            data.Status = EnumClientStatus.共享;
            data.ClientInfoIDs = ciids;
            bool b = new T_ClientInfo().UpdateMode(data);
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = bp.EnterpriceID, UserID = bp.UserID, LogTitle = "共享名录", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }

        /// <summary>
        /// 共享某状态下全部名录
        /// </summary>
        private void ShareAll()
        {
            int mode, status;
            if (!int.TryParse(nv["mode"],out mode) || !int.TryParse(nv["status"],out status))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = bp.EnterpriceID;
            data.EPUserTMRID = bp.EPUserTMRID;
            data.TeamID = bp.TeamID;
            data.SetMode = mode;
            data.SetStatus = status;

            bool flag = new T_ClientInfo().ShareAll(data);
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = bp.EnterpriceID, UserID = bp.UserID, LogTitle = "共享名录", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }
        /// <summary>
        /// 删除名录
        /// </summary>
        private void Delete()
        {
            string ciids = nv["ids"];
            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ciids))//判断格式是否正确 格式：1,21,321
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = bp.EnterpriceID;
            data.EPUserTMRID = bp.EPUserTMRID;
            data.ClientInfoIDs = ciids;
            bool b = new T_ClientInfo().Delete(data);
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = bp.EnterpriceID, UserID = bp.UserID, LogTitle = "删除名录", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        
        /// <summary>
        /// 删除某状态下所有名录
        /// </summary>
        private void DeleteAll()
        {
            int mode, status;
            if (!int.TryParse(nv["mode"], out mode) || !int.TryParse(nv["status"], out status))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = bp.EnterpriceID;
            data.EPUserTMRID = bp.EPUserTMRID;
            data.TeamID = bp.TeamID;
            data.SetMode = mode;
            data.SetStatus = status;

            bool flag = new T_ClientInfo().DeleteAll(data);
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = bp.EnterpriceID, UserID = bp.UserID, LogTitle = "删除名录", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 获取分配对象
        /// </summary>
        private void GetObj()
        {
            JsonArrayCollection jac = new JsonArrayCollection();
            //------绑定用户列表------
            DataTable dt = new T_Team().GetTeamMember(new E_Team { EnterpriseID = bp.EnterpriceID, TeamID = bp.TeamID });
            foreach (DataRow dr in dt.Rows)
            {
                JsonObjectCollection colDR = new JsonObjectCollection();
                colDR.Add(new JsonStringValue("text", string.Format("【{0}】{1}", dr["RoleName"], dr["TrueName"])));
                colDR.Add(new JsonStringValue("value", dr["EPUserTMRID"].ToString()));
                jac.Add(colDR);
            }
            HttpContext.Current.Response.Write(jac.ToString());
        }
        /// <summary>
        /// 名录转移
        /// </summary>
        private void Shift()
        {
            int objid = 0;
            if (!int.TryParse(nv["objid"], out objid))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            string ids = nv["ciids"];
            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ids))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            bool b = new T_Allot().ShiftAllot(new E_Allot()
            {
                EnterpriseID = bp.EnterpriceID,
                TeamID = bp.TeamID,
                ObjIDs = objid.ToString(),
                ClientInfoIDs = ids
            });
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = bp.EnterpriceID, UserID = bp.UserID, LogTitle = "名录转移", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(Convert.ToInt16(b));
        }

        /// <summary>
        /// 上报名录
        /// </summary>
        private void Report()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            string ciids = nv["ids"];
            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ciids))//判断格式是否正确 格式：1,21,321
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_ClientInfoHelper data = new E_ClientInfoHelper();
            data.EnterpriseID = ep.EnterpriceID;
            data.EPUserTMRID = ep.EPUserTMRID;
            data.TeamID = ep.TeamID;
            data.ClientInfoIDs = ciids;
            bool flag = new T_ClientInfoHelper().Report(data);
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = bp.EnterpriceID, UserID = bp.UserID, LogTitle = "名录上报", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 锁定解锁名录：1=锁定，0=解锁
        /// </summary>
        private void Lock()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            string ciids = nv["ids"];
            int islock = Convert.ToInt32(nv["islock"]);

            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ciids))//判断格式是否正确 格式：1,21,321
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            if (islock > 1 || islock < 0)
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }

            E_ClientInfoHelper data = new E_ClientInfoHelper();
            data.EnterpriseID = ep.EnterpriceID;
            data.EPUserTMRID = ep.EPUserTMRID;
            data.ClientInfoIDs = ciids;
            data.IsLock = islock;
            bool flag = new T_ClientInfoHelper().IsLock(data);
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = bp.EnterpriceID, UserID = bp.UserID, LogTitle = "名录锁定与解锁", IP = MLMGC.COMP.Requests.GetRealIP() });
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