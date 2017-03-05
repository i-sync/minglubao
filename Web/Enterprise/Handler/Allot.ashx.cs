using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Web.SessionState;
using MLMGC.COMP;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using System.Data;
using System.Net.Json;

namespace Web.Enterprise.Handler
{
    /// <summary>
    /// 分配处理程序
    /// </summary>
    public class Allot : IHttpHandler, IRequiresSessionState
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
            nv = HttpContext.Current.Request.QueryString;
            switch (nv["key"])
            {
                case "setting"://设置分配信息
                    Setting();
                    break;
                case "auto"://自动分配
                    AutoAllot();
                    break;
                case "manual"://手动分配
                    ManualAllot();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }
        /// <summary>
        /// 设置分配设置
        /// </summary>
        private void Setting()
        {
            //------------判断数据是否合法---------------------
            string aryObj=nv["objid"].Replace('|',',');
            if (!StringUtil.IsStringArrayList(aryObj))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            string[] aryTrade=nv["trade"].Split('|');
            string[] aryArea=nv["area"].Split('|');
            string[] arySource = nv["source"].Split('|');
            if (aryTrade.Length != aryArea.Length || aryArea.Length != arySource.Length)
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            for (int i = 0; i < aryTrade.Length; i++)
            {
                if (!string.IsNullOrEmpty(aryTrade[i]) && !StringUtil.IsStringArrayList(aryTrade[i]))
                {
                    HttpContext.Current.Response.Write("参数错误");
                    return;
                }
                if (!string.IsNullOrEmpty(aryArea[i]) && !StringUtil.IsStringArrayList(aryArea[i]))
                {
                    HttpContext.Current.Response.Write("参数错误");
                    return;
                }
                if (!string.IsNullOrEmpty(arySource[i]) && !StringUtil.IsStringArrayList(arySource[i]))
                {
                    HttpContext.Current.Response.Write("参数错误");
                    return;
                }
            }

            E_Allot data = new E_Allot();
            data.EnterpriseID = bp.EnterpriceID;
            data.TeamID = bp.TeamID;
            int limit = 0;
            int.TryParse(nv["limit"], out limit);
            data.Limit = limit;
            data.ObjIDs=aryObj.Replace(",",MLMGC.COMP.Config.Separation);
            data.TradeS = string.Join(MLMGC.COMP.Config.Separation, aryTrade);
            data.AreaS = string.Join(MLMGC.COMP.Config.Separation, aryArea);
            data.SourceS = string.Join(MLMGC.COMP.Config.Separation, arySource);
            T_Allot bll = new T_Allot();
            bool b = bll.Update(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = bp.EnterpriceID, UserID = bp.UserID, LogTitle = "分配设置", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b?"1":"0");
        }
        /// <summary>
        /// 自动分配
        /// </summary>
        private void AutoAllot()
        {
            int amount = 0,type=0;
            int.TryParse(nv["num"], out amount);
            string sort = nv["orderby"];
            int.TryParse(nv["type"], out type);

            //---------------验证数据是否正确---------------
            if (amount <= 0)
            {
                HttpContext.Current.Response.Write("参数错误");
                HttpContext.Current.Response.End();
            }
            if (!(new string[] { "asc", "desc" }).Contains(sort))
            {
                HttpContext.Current.Response.Write("参数错误");
                HttpContext.Current.Response.End();
            }
            if (type<2 || type>6)
            {
                HttpContext.Current.Response.Write("参数错误");
                HttpContext.Current.Response.End();
            }

            E_Allot data = new E_Allot();
            data.EnterpriseID = bp.EnterpriceID;
            data.TeamID = bp.TeamID;
            data.AllotAmount = amount;
            data.AllotSort = sort;
            data.SetMode = type;
            T_Allot bll = new T_Allot();
            DataTable dt = bll.AutoAllot(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = bp.EnterpriceID, UserID = bp.UserID, LogTitle = "自动分配", IP = MLMGC.COMP.Requests.GetRealIP() });

            JsonArrayCollection jac = new JsonArrayCollection();
            if (dt != null)
            {    
                foreach (DataRow dr in dt.Rows)
                {
                    jac.Add(new JsonObjectCollection() { new JsonStringValue("objName", dr[0].ToString()), new JsonStringValue("Amount", dr[1].ToString()) });
                }
                HttpContext.Current.Response.Write("succ");
            }
            else
                HttpContext.Current.Response.Write("error");
        }
        /// <summary>
        /// 手动分配
        /// </summary>
        private void ManualAllot()
        {
            string type = nv["type"];
            string objids= nv["objids"];
            string ciids = nv["ids"];
            //---------------验证数据是否正确---------------
            if (!(new string[] { "specified", "avg", "makeup", "trade", "area", "source" }).Contains(type)//分配方式
                || !MLMGC.COMP.StringUtil.IsStringArrayList(objids)//对象
                || !MLMGC.COMP.StringUtil.IsStringArrayList(ciids)//分配名录
                )
            {
                HttpContext.Current.Response.Write("参数错误");
                HttpContext.Current.Response.End();
            }

            if (type.Equals("specified") && !StringUtil.VldInt(objids))
            {
                HttpContext.Current.Response.Write("参数错误");
                HttpContext.Current.Response.End();
            }
            E_Allot data = new E_Allot();
            data.EnterpriseID = bp.EnterpriceID;
            data.TeamID = bp.TeamID;
            data.AllotType = type;
            data.ObjIDs = objids;
            data.ClientInfoIDs = ciids;
            T_Allot bll = new T_Allot();
            bool b = bll.ManualAllot(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = bp.EnterpriceID, UserID = bp.UserID, LogTitle = "手动分配", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b?"1":"0");
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