using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MLMGC.BLL.Personal;
using MLMGC.DataEntity.Personal;
using System.Net.Json;
using System.Text.RegularExpressions;
using System.Data;

namespace Web.Personal.Handler
{
    /// <summary>
    /// ClientInfo 的摘要说明
    /// </summary>
    public class ClientInfo : IHttpHandler, IRequiresSessionState
    {
        System.Collections.Specialized.NameValueCollection nv;
        MLMGC.Security.PersonalPage bp;
        
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //---获取用户角色等信息
            bp = new MLMGC.Security.PersonalPage(true);
            if (bp.PersonalID < 1)
            {
                context.Response.Write("timeout");
                return;
            }
            nv = context.Request.Form;
            switch (nv["key"])
            {
                case "exists":   //判断名录是否存在
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
                case "exchange"://新沟通记录
                    Exchange();
                    break;
                case "delete"://批量删除名录信息
                    Delete();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }

        /// <summary>
        /// 判断名录是否存在
        /// </summary>
        private void Exists()
        {
            E_ClientInfo data = new E_ClientInfo();
            data.PersonalID = bp.PersonalID;
            data.ClientName = nv["clientname"];
            string clientinfoid = nv["clientinfoid"];
            data.ClientInfoID = Convert.ToInt32(clientinfoid??"0");
            bool flag = new T_ClientInfo().Exists(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 判断手机或电话号码是否存在
        /// </summary>
        private void ExistsContact()
        {

            string type = nv["type"];
            string value = nv["value"].Trim();
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
            if (!b || string.IsNullOrWhiteSpace(type))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            int ciid = 0;
            int.TryParse(nv["ciid"], out ciid);
            E_ClientInfo data = new E_ClientInfo();
            data.PersonalID = bp.PersonalID;
            data.ClientInfoID = ciid;
            data.Type = Convert.ToInt32(type);
            data.Value = value;
            DataTable dt = new T_ClientInfo().ExistsContact(data);
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
                        result = string.Format("该{0}号码已存在，所在名录：{1}", type == "1" ? "手机" : "电话", dt.Rows[0]["Name"].ToString());
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
        private void UpdateBaseInfo()
        {
            E_ClientInfo data = new E_ClientInfo();
            data.PersonalID = bp.PersonalID;
            data.ClientInfoID = Convert.ToInt32(nv["id"].Trim());
            data.ClientName = nv["clientname"].Trim();
            data.Address = nv["address"];
            data.AreaID = Convert.ToInt32(nv["areaid"].Trim());
            data.Email = nv["email"].Trim();
            data.Fax = nv["fax"].Trim();
            data.Linkman = nv["linkman"].Trim();
            data.Mobile = nv["mobile"].Trim();
            data.Position = nv["position"].Trim();
            data.Website = nv["website"].Trim();
            data.QQ = nv["qq"].Trim();
            data.MSN = nv["msn"].Trim();
            data.Remark = nv["remark"].Trim();
            data.SourceID = Convert.ToInt32(nv["sourceid"].Trim());
            data.Tel = nv["tel"].Trim();
            data.TradeID = Convert.ToInt32(nv["tradeid"].Trim());
            data.ZipCode = nv["zipcode"].Trim();

            //添加之前再次确认名录名称、电话、手机是否唯一
            bool flag = true;
            //判断名录名是否存在
            bool bl = new T_ClientInfo().Exists(new E_ClientInfo() { PersonalID = bp.PersonalID, ClientName = data.ClientName, ClientInfoID = data.ClientInfoID });

            if (bl)
            {
                flag = false;
            }
            DataTable dt;
            //判断手机是否存在
            if (!string.IsNullOrWhiteSpace(data.Mobile))
            {
                dt = new T_ClientInfo().ExistsContact(new E_ClientInfo { PersonalID =bp.PersonalID, ClientInfoID = data.ClientInfoID , Type = 1, Value = data.Mobile });
                if (dt != null && Convert.ToInt32(dt.Rows[0]["Flag"]) > -1)
                {
                    flag = false;
                }
            }

            //判断电话是否存在
            if (!string.IsNullOrEmpty(data.Tel))
            {
                dt = new T_ClientInfo().ExistsContact(new E_ClientInfo { PersonalID = bp.PersonalID, ClientInfoID = data.ClientInfoID, Type = 2, Value = data.Tel });
                if (dt != null && Convert.ToInt32(dt.Rows[0]["Flag"]) > -1)
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
        /// 修改状态
        /// </summary>
        private void UpdateStatus()
        {
            E_ClientInfo data = new E_ClientInfo();
            data.PersonalID = bp.PersonalID;
            data.ClientInfoID = Convert.ToInt32(nv["id"]);
            data.SetStatus = Convert.ToInt32(nv["status"]);
            if (data.Status == EnumClientStatus.所有状态)//判断是否是可用状态
            {
                HttpContext.Current.Response.Write("参数错误啦");
                return;
            }
            if (data.Status == EnumClientStatus.意向客户)
            {
                data.WishID = Convert.ToInt32(nv["wishid"]);
            }
            else if (data.Status == EnumClientStatus.成交客户)
            {
                data.TradedMoney = float.Parse(nv["money"]);
            }
            else if (data.Status == EnumClientStatus.失败客户)
            {
                data.NotTradedID = Convert.ToInt32(nv["nottradedid"]);
            }
            else if (data.Status == EnumClientStatus.报废客户)
            {
                data.ScrapID = Convert.ToInt32(nv["scrapid"]);
            }
            bool b = new T_ClientInfo().UpdateStatus(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 新沟通记录
        /// </summary>
        private void Exchange()
        {
            E_Exchange data = new E_Exchange();
            data.PersonalID = bp.PersonalID;
            data.ClientInfoID = Convert.ToInt32(nv["id"]);
            data.Detail = nv["info"];
            data.ExchangeDate = Convert.ToDateTime(nv["date"]);
            bool b = new T_Exchange().Add(data);
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("result", b ? "1" : "0"));
            colDR.Add(new JsonStringValue("detail", data.Detail));
            colDR.Add(new JsonStringValue("date", Convert.ToDateTime(data.ExchangeDate).ToString("yyyy-MM-dd HH:mm")));
            HttpContext.Current.Response.Write(colDR.ToString());
        }
        /// <summary>
        /// 批量删除名录
        /// </summary>
        private void Delete()
        {
            string ids = nv["ids"];
            if (MLMGC.COMP.StringUtil.IsStringArrayList(ids))
            {
                E_ClientInfo data = new E_ClientInfo();
                data.PersonalID = bp.PersonalID;
                data.ClientInfoIDs = ids;
                bool b = new T_ClientInfo().BatchDelete(data);
                HttpContext.Current.Response.Write(b ? "1" : "0");
            }
            else
            {
                HttpContext.Current.Response.Write("参数错误");
            }
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