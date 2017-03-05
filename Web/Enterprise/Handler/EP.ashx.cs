using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Net.Json;
using System.Data;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using System.Collections.Specialized;

namespace Web.Enterprise.Handler
{
    /// <summary>
    /// EP 的摘要说明
    /// </summary>
    public class EP : IHttpHandler, IRequiresSessionState
    {
        MLMGC.Security.EnterprisePage bp;
        NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            bp = new MLMGC.Security.EnterprisePage(true);
            if (bp.UserID < 1)
            {
                context.Response.Write("登录信息超时");
                return;
            }
            nv = HttpContext.Current.Request.QueryString;
            GetNowReservation();
            //context.Response.Write("Hello World");
        }
        /// <summary>
        /// 获取当前显示的预约客户
        /// </summary>
        private void GetNowReservation()
        {
            string ids = nv["ids"];
            if (!string.IsNullOrEmpty(ids) && !MLMGC.COMP.StringUtil.IsStringArrayList(ids))
            {
                HttpContext.Current.Response.Write("Error");
                return;
            }
            DataTable dt = new T_ClientInfoHelper().GetReservationNow(new E_Reservation()
            {
                EnterpriseID = bp.EnterpriceID,
                EPUserTMRID = bp.EPUserTMRID,
                ClientInfoIDs=ids
            });
            JsonArrayCollection jac = new JsonArrayCollection();
            if (dt!=null && dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    JsonObjectCollection colDR = new JsonObjectCollection();
                    colDR.Add(new JsonStringValue("nid", dr["ReservationID"].ToString()));
                    colDR.Add(new JsonStringValue("id", dr["ClientInfoID"].ToString()));
                    colDR.Add(new JsonStringValue("name", dr["ClientName"].ToString()));
                    colDR.Add(new JsonStringValue("date",Convert.ToDateTime(dr["ReservationDate"].ToString()).ToString("yyyy-MM-dd HH:mm")));
                    colDR.Add(new JsonStringValue("minute", dr["AdvanceMinute"].ToString()));
                    colDR.Add(new JsonStringValue("type", dr["ReType"].ToString()));
                    jac.Add(colDR);
                }
            }
            HttpContext.Current.Response.Write(jac.ToString());

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