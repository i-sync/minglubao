using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using System.Data;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;
using System.Net.Json;

namespace Web.Personal.Handler
{
    /// <summary>
    /// Item 的摘要说明
    /// </summary>
    public class Item : IHttpHandler,IRequiresSessionState
    {
        NameValueCollection nv;
        MLMGC.Security.PersonalPage pp;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            nv = HttpContext.Current.Request.Form;
            pp = new MLMGC.Security.PersonalPage(true);

            switch (nv["key"])
            { 
                case "clientinfoexists"://判断名录名称手机号，电话号码是否存在
                    ClientInfoExists();
                    break;
                case "updatebase"://修改基本信息
                    UpdateBase();
                    break;
                case "updatestatus"://修改状态
                    UpdateStatus();
                    break;
                case "addexchange":
                    AddExchange();
                    break;
                case "delete":
                    Delete();
                    break;
                case "share":
                    Share();
                    break;
                case "myget":
                    MyGet();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }            
        }

        /// <summary>
        /// 判断名录名称手机电话是否存在
        /// </summary>
        private void ClientInfoExists()
        {
            string type = nv["type"];
            string value = nv["value"].Trim();
            bool b = false;
            if (type == "0")
            {
                b = true;
            }
            else if (type == "1")
            {
                Regex m = new Regex(@"^1(3|5|8)+\d{9}$");//验证手机号
                b = m.IsMatch(value);
            }
            else if(type=="2")
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
            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = pp.EnterpriseID;
            data.ClientInfoID = ciid;
            data.Type = Convert.ToInt32(type);
            data.Value = value;
            bool flag = new T_ItemClientInfo().Exists(data);
            string result = string.Empty;
            if (!flag)
            {
                result = "可以使用！";
            }
            else
            {
                result = string.Format("该{0}已存在", type == "0" ? "名录":type=="1"?"手机号码" : "电话号码");
            }
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("flag", flag ? "0" : "1"));
            colDR.Add(new JsonStringValue("detail", result));
            HttpContext.Current.Response.Write(colDR.ToString());
        }


        /// <summary>
        /// 修改基本信息
        /// </summary>
        private void UpdateBase()
        {
            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = pp.EnterpriseID;
            data.UserID = pp.UserID;
            data.ClientInfoID = Convert.ToInt32(nv["ciid"]);
            data.ClientName = nv["clientname"];
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
            bool flag = false;
            flag = new T_ItemClientInfo().Exists(new E_ItemClientInfo { EnterpriseID = data.EnterpriseID, ClientInfoID = data.ClientInfoID,Type=0, Value = data.ClientName });
            
            //如果手机不为空
            if (!string.IsNullOrEmpty(data.Mobile.Trim()))
            {
                flag = flag || new T_ItemClientInfo().Exists(new E_ItemClientInfo { EnterpriseID = data.EnterpriseID, ClientInfoID = data.ClientInfoID, Type = 1, Value = data.Mobile });               
            }
            //如果电话不为空
            if (!string.IsNullOrEmpty(data.Tel.Trim()))
            {
                flag = flag || new T_ItemClientInfo().Exists(new E_ItemClientInfo { EnterpriseID = data.EnterpriseID, ClientInfoID = data.ClientInfoID, Type = 2, Value = data.Tel });                
            }
            if (flag)
            {
                return;
            }
            bool b = new T_ItemClientInfo().Update(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }


        /// <summary>
        /// 修改名录的状态
        /// </summary>
        private void UpdateStatus()
        {
            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = pp.EnterpriseID;
            data.UserID = pp.UserID;
            data.ClientInfoID = Convert.ToInt32(nv["ciid"]);
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
            bool b = new T_ItemClientInfo().UpdateStatus(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }

        /// <summary>
        /// 添加沟通记录
        /// </summary>
        private void AddExchange()
        {
            E_ItemExchange data = new E_ItemExchange();
            data.EnterpriseID = pp.EnterpriseID;
            data.UserID = pp.UserID;
            data.ClientInfoID = Convert.ToInt32(nv["ciid"]);
            data.Detail = nv["info"];
            data.AddDate = Convert.ToDateTime(nv["date"]);
            data = new T_ItemExchange().Add(data);
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("result", data !=null ? "1" : "0"));
            colDR.Add(new JsonStringValue("detail", data.Detail));
            colDR.Add(new JsonStringValue("date", Convert.ToDateTime(data.AddDate).ToString("yyyy-MM-dd HH:mm")));
            colDR.Add(new JsonStringValue("realname", data.RealName));
            HttpContext.Current.Response.Write(colDR.ToString());
        }

        /// <summary>
        /// 删除名录 
        /// </summary>
        private void Delete()
        {
            string ids = nv["ids"];
            if (MLMGC.COMP.StringUtil.IsStringArrayList(ids))
            {
                E_ItemClientInfo data = new E_ItemClientInfo();
                data.EnterpriseID = pp.EnterpriseID;
                data.UserID = pp.UserID;
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
        /// 个人用户共享项目名录 
        /// </summary>
        private void Share()
        {
            string ids = nv["ids"];
            if (MLMGC.COMP.StringUtil.IsStringArrayList(ids))
            {
                E_ItemClientInfo data = new E_ItemClientInfo();
                data.EnterpriseID = pp.EnterpriseID;
                data.UserID = pp.UserID;
                data.ClientInfoIDs = ids;
                data.Status = EnumClientStatus.共享;
                bool b = new T_ItemClientInfo().UpdateShare(data);
                HttpContext.Current.Response.Write(b ? "1" : "0");
            }
            else
            {
                HttpContext.Current.Response.Write("参数错误");
            }
        }


        /// <summary>
        /// 从共享池中获取名录
        /// </summary>
        private void MyGet()
        {
            string ids = nv["ids"];
            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ids))//判断格式是否正确 格式：1,21,321
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = pp.EnterpriseID;
            data.ClientInfoIDs = ids;
            data.UserID = pp.UserID;
            data.Status = EnumClientStatus.潜在客户;//目标状态
            bool b = new T_ItemClientInfo().ShiftShare(data);
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