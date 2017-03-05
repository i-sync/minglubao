using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise.Material;
using MLMGC.BLL.Enterprise.Material;
using System.Net.Json;
using System.Data;
using System.Text.RegularExpressions;

namespace Web.Enterprise.Handler
{
    /// <summary>
    /// 客户信息处理程序
    /// </summary>
    public class CIHandler : IHttpHandler,IRequiresSessionState
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
            try
            {
                switch (context.Request.QueryString["act"])
                {
                    case "exists"://判断名录名是否存在
                        Exists();
                        break;
                    case "existscontact"://判断手机或电话是否存在
                        ExistsContact();
                        break;
                    case "updatebase"://修改基本信息
                        UpdateBaseInfo();
                        break;
                    case "updatestatus"://修改状态
                        UpdateStatus();
                        break;
                    case "subquestion":
                        Subquestion();
                        break;
                    case "exchange"://新沟通记录
                        Exchange();
                        break;
                    case "myget"://从共享中转移用户信息
                        MyGet();
                        break;
                    case "reservation"://预约
                        Reservation();
                        break;
                    case "cancelreser":
                        CancelReser();
                        break;
                    default:
                        context.Response.Write("Hello World");
                        break;
                }
            }
            catch(Exception mye)
            {
                context.Response.Write("请求错误:"+mye.Message.ToString());
            }
        }

        /// <summary>
        /// 判断名录名称是否存在
        /// </summary>
        /// <remarks>tianzhenyun 2011-11-02</remarks>
        private void Exists()
        {
            string clientname = HttpContext.Current.Request.QueryString["name"];
            if (string.IsNullOrWhiteSpace(clientname))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            int ciid =0;
            int.TryParse(HttpContext.Current.Request.QueryString["ciid"], out ciid);
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = bp.EnterpriceID;
            data.ClientInfoID = ciid;
            data.ClientName = clientname;
            DataTable dt = new T_ClientInfo().Exists(data);
            string result = string.Empty;
            bool flag = false;
            if (dt != null && dt.Rows.Count == 1)
            {
                int mode = Convert.ToInt32(dt.Rows[0]["Flag"]);
                switch (mode)
                {
                    case -1:
                        flag = true;
                        result = "这个名称可以使用！";
                        break;
                    case 0:
                        result = "该名称已存在，在" + dt.Rows[0]["ObjName"].ToString() + "手中。";
                        break;
                    case 1:
                        result = "该名称已存在，在" + dt.Rows[0]["ObjName"].ToString() + "团队中。";
                        break;
                    case 2:
                        result = "该名称已存在，在" + dt.Rows[0]["ObjName"].ToString();
                        break;
                }
            }

            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("flag", flag ? "1" : "0"));
            colDR.Add(new JsonStringValue("detail", result));
            HttpContext.Current.Response.Write(colDR.ToString());
        }

        /// <summary>
        /// 判断手机或电话是否存在
        /// </summary>
        /// <remarks>tianzhenyun 2011-11-02</remarks>
        private void ExistsContact()
        {
            string type = nv["type"];
            string value = nv["value"];
            bool b = false;
            if (type == "1")
            {
                Regex m = new Regex(@"^1(3|5|8)+\d{9}$");//验证手机号
                b = m.IsMatch(value);
            }
            else
            {
                Regex t = new Regex(@"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$");//验证电话
                b = t.IsMatch(value);
            }
            if (!b||string.IsNullOrWhiteSpace(type))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            int ciid = 0;
            int.TryParse(nv["ciid"], out ciid);
            E_ClientInfoHelper data = new E_ClientInfoHelper();
            data.EnterpriseID = bp.EnterpriceID;
            data.ClientInfoID = ciid;
            data.Type = Convert.ToInt32(type);
            data.Value = value;
            DataTable dt = new T_ClientInfoHelper().ExistsContact(data);
            string result = string.Empty;
            bool flag = false;
            if (dt != null && dt.Rows.Count == 1)
            {
                int mode = Convert.ToInt32(dt.Rows[0]["Flag"]);
                switch (mode)
                {
                    case -1:
                        flag = true;
                        result = "这个号码可以使用！";
                        break;                    
                    case 1:
                        result =string.Format("该{0}号码已存在，所在名录：{1}",type=="1"?"手机":"电话", dt.Rows[0]["Name"].ToString()) ;
                        break;
                }
            }

            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("flag", flag ? "1" : "0"));
            colDR.Add(new JsonStringValue("detail", result));
            HttpContext.Current.Response.Write(colDR.ToString());
        }

        /// <summary>
        /// 修改基本信息
        /// </summary>
        public void UpdateBaseInfo()
        {
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = bp.EnterpriceID;
            data.ClientInfoID = Convert.ToInt32(nv["ciid"]);
            data.ClientName=nv["clientname"];
            data.Address = nv["address"];
            data.AreaID = Convert.ToInt32(nv["areaid"]);
            data.Website = nv["website"];
            data.Email = nv["email"];
            data.Fax = nv["fax"];
            data.Linkman = nv["linkman"];
            data.Mobile = nv["mobile"];
            data.Position = nv["position"];
            data.QQ = nv["qq"];
            data.MSN = nv["msn"];
            data.Remark = nv["remark"];
            data.SourceID = Convert.ToInt32(nv["sourceid"]);
            data.Tel = nv["tel"];
            data.TradeID = Convert.ToInt32(nv["tradeid"]);
            data.ZipCode = nv["zipcode"];
            //修改之前再次确认名录名称、电话、手机是否唯一
            bool flag = true;
            DataTable dt = new T_ClientInfo().Exists(new E_ClientInfo { EnterpriseID = data.EnterpriseID, ClientInfoID = data.ClientInfoID, ClientName = data.ClientName });
            if (dt != null && Convert.ToInt32(dt.Rows[0]["Flag"]) > 0)
            {
                flag = false;
            }
            //如果手机不为空
            if (!string.IsNullOrEmpty(data.Mobile.Trim()))
            {
                dt = new T_ClientInfoHelper().ExistsContact(new E_ClientInfoHelper { EnterpriseID = data.EnterpriseID, ClientInfoID = data.ClientInfoID, Type = 1, Value = data.Mobile });
                if (dt != null && Convert.ToInt32(dt.Rows[0]["Flag"]) > 0)
                {
                    flag = false;
                }
            }
            //如果电话不为空
            if (!string.IsNullOrEmpty(data.Tel.Trim()))
            {
                dt = new T_ClientInfoHelper().ExistsContact(new E_ClientInfoHelper { EnterpriseID = data.EnterpriseID, ClientInfoID = data.ClientInfoID, Type = 2, Value = data.Tel });
                if (dt != null && Convert.ToInt32(dt.Rows[0]["Flag"]) > 0)
                {
                    flag = false;
                }
            }
            if (!flag)
            {
                return;
            }
            bool b = new T_ClientInfo().Update(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 修改名录状态
        /// </summary>
        public void UpdateStatus()
        {
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID =bp.EnterpriceID;
            data.EPUserTMRID = bp.EPUserTMRID;
            data.ClientInfoID = Convert.ToInt32(nv["ciid"]);
            data.SetStatus = Convert.ToInt32(nv["status"]);
            data.Mode = EnumClientMode.业务员;
            data.TeamID =0;
            if (data.Status == EnumClientStatus.所有状态 || data.Status == EnumClientStatus.待分配名录)//判断是否是可用状态
            {
                HttpContext.Current.Response.Write("参数错误啦");
                return;
            }
            if (data.Status == EnumClientStatus.意向客户)
            {
                data.WishID = Convert.ToInt32(nv["wishid"]);
            }
            else if(data.Status==EnumClientStatus.成交客户)
            {
                data.TradedMoney = float.Parse(nv["money"]);
            }
            else if (data.Status == EnumClientStatus.失败客户)
            {
                data.NotTradedID = Convert.ToInt32(nv["nottradedid"]);
                data.Mode = EnumClientMode.团队;
                data.TeamID = bp.TeamID;
            }
            else if (data.Status == EnumClientStatus.报废客户)
            {
                data.ScrapID = Convert.ToInt32(nv["scrapid"]);
                data.Mode = EnumClientMode.团队;
                data.TeamID = bp.TeamID;
            }
            bool b = new T_ClientInfo().UpdateStatus(data);
            HttpContext.Current.Response.Write(b?"1":"0");
        }
        /// <summary>
        /// 沟通交流记录
        /// </summary>
        public void Exchange()
        {
            int ciid;
            DateTime dtDate;
            bool bCheck = true,b=false;
            if (!int.TryParse(nv["ciid"], out ciid))
            {
                bCheck = false;
            }
            if (!DateTime.TryParse(nv["date"], out dtDate))
            {
                bCheck = false;
            }
            E_Exchange data = new E_Exchange();
            data.EnterpriseID = bp.EnterpriceID;
            data.EPUserTMRID = bp.EPUserTMRID;
            data.ClientInfoID = ciid;
            data.Detail = nv["info"];
            data.ExchangeDate =dtDate;
            if (bCheck)
            {
                b = new T_Exchange().Add(data);
            }
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("result", b?"1":"0"));
            colDR.Add(new JsonStringValue("detail", data.Detail));
            colDR.Add(new JsonStringValue("date",Convert.ToDateTime(data.ExchangeDate).ToString("yyyy-MM-dd HH:mm")));
            colDR.Add(new JsonStringValue("info", data.UserInfo));
            HttpContext.Current.Response.Write(colDR.ToString());
        }

        /// <summary>
        /// 修改调查问卷
        /// </summary>
        public void Subquestion()
        {
            int clientinfoid = Convert.ToInt32(nv["ciid"]);
            string itemids = nv["itemids"];
            E_Question data = new E_Question();
            data.EnterpriseID = bp.EnterpriceID;
            data.ClientInfoID = clientinfoid;
            data.EPUserTMRID = bp.EPUserTMRID;
            data.QuestionItemIDs = itemids;
            bool flag = new T_Question().UpdateQuestion(data);
            
            HttpContext.Current.Response.Write(flag?"1":"0");
        }

        /// <summary>
        /// 将客户放入我的潜在客户库
        /// </summary>
        public void MyGet()
        {
            string ciids = nv["ciid"];
            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ciids))//判断格式是否正确 格式：1,21,321
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = bp.EnterpriceID;
            data.EPUserTMRID = bp.EPUserTMRID;
            data.ClientInfoIDs = ciids;
            bool b = new T_ClientInfo().ShiftShare(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 预约
        /// </summary>
        private void Reservation()
        {
            int ciid,type;
            ushort minute;
            DateTime dt;
            if (!int.TryParse(nv["ciid"], out ciid))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            if (!DateTime.TryParse(nv["time"], out dt))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            if (!UInt16.TryParse(nv["minute"], out minute))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            if(!int.TryParse(nv["type"],out type))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            //E_ClientInfoHelper data = new E_ClientInfoHelper();
            //data.EnterpriseID = bp.EnterpriceID;
            //data.EPUserTMRID = bp.EPUserTMRID;
            //data.ClientItemID =ciid;
            //data.ReservationDate=dt;
            //data.AdvanceMinute =minute;
            E_Reservation data = new E_Reservation();
            data.EnterpriseID = bp.EnterpriceID;
            data.EPUserTMRID = bp.EPUserTMRID;
            data.ClientInfoID = ciid;
            data.ReservationDate = dt;
            data.AdvanceMinute = minute;
            data.SetType = type;
            bool b = new T_ClientInfoHelper().Reservation(data);
            HttpContext.Current.Response.Write(Convert.ToInt32(b));
        }

        /// <summary>
        /// 取消预约名录
        /// </summary>
        public void CancelReser()
        {
            int rid;
            if (!int.TryParse(nv["rid"], out rid))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }

            E_Reservation data = new E_Reservation();
            data.EnterpriseID = bp.EnterpriceID;
            data.EPUserTMRID = bp.EPUserTMRID;
            data.ReservationID = rid;
            bool flag = new T_ClientInfoHelper().DeleteReservation(data);
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