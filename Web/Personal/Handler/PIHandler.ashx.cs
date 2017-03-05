using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MLMGC.COMP;
using MLMGC.BLL.Personal.Config;
using MLMGC.DataEntity.Personal.Config;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;
using System.Net.Json;
using System.Web.SessionState;

namespace Web.Personal.Handler
{
    /// <summary>
    /// PIHandler 的摘要说明
    /// </summary>
    public class PIHandler : IHttpHandler, IRequiresSessionState
    {
        System.Collections.Specialized.NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            nv = System.Web.HttpUtility.ParseQueryString(context.Request.Url.Query);
            switch (nv["key"])
            {
                case "601"://属性设置
                    SetProperty();
                    break;
                case "701"://判断行业是否存在
                    TradeExists();
                    break;
                case "702"://录入新行业
                    TradeAdd();
                    break;
                case "703"://修改行业
                    TradeUpdate();
                    break;
                case "704"://删除行业
                    TradeDelete();
                    break;
                case "705"://获取行业信息
                    TradeShow();
                    break;
                case "711"://判断地区是否存在
                    AreaExists();
                    break;
                case "712"://录入新地区
                    AreaAdd();
                    break;
                case "713"://修改地区
                    AreaUpdate();
                    break;
                case "714"://删除地区
                    AreaDelete();
                    break;
                case "715"://获取地区信息
                    AreaShow();
                    break;
                case "721"://判断来源编码是否存在
                    SourceExists();
                    break;
                case "722"://录入新来源
                    SourceAdd();
                    break;
                case "723"://修改来源
                    SourceUpdate();
                    break;
                case "724"://删除来源
                    SourceDelete();
                    break;
                case "725"://获取来源信息
                    SourceShow();
                    break;
                case "801"://检测意向进展是否存在
                    WishExists();
                    break;
                case "802"://录入新的意向进展状态
                    WishAdd();
                    break;
                case "803"://修改意向进展状态
                    WishUpdate();
                    break;
                case "804"://删除意向进展状态
                    WishDelete();
                    break;
                case "805"://获取来源信息
                    WishShow();
                    break;
                case "811"://检测失败
                    NoTradedExists();
                    break;
                case "812"://录入新失败
                    NoTradedAdd();
                    break;
                case "813"://修改失败
                    NoTradedUpdate();
                    break;
                case "814"://删除失败
                    NoTradedDelete();
                    break;
                case "815"://获取失败
                    NoTradedShow();
                    break;
                case "821"://检索报废理由
                    ScrapExists();
                    break;
                case "822"://录入新报废理由
                    ScrapAdd();
                    break;
                case "823"://修改报废理由
                    ScrapUpdate();
                    break;
                case "824"://删除报废理由
                    ScrapDelete();
                    break;
                case "825"://获取报废理由
                    ScrapShow();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }            
        }

        #region 属性
        /// <summary>
        /// 设置属性
        /// </summary>
        void SetProperty()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            string trade = nv["trade"];
            string area = nv["area"];
            string source = nv["source"];
            E_Property data = new E_Property();
            data.PersonalID = pp.PersonalID;
            data.TradeFlag = trade == "true" ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
            data.AreaFlag = area == "true" ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
            data.SourceFlag = source == "true" ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
            bool b = new T_Property().Set(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }

        /// <summary>
        /// 行业是否存在
        /// </summary>
        void TradeExists()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int tradeid = int.Parse(nv["tradeid"]);
            string name = nv["name"];
            E_Trade data = new E_Trade();
            data.PersonalID = pp.PersonalID;
            data.TradeID = tradeid;
            data.TradeName = name;
            bool b = new T_Trade().Exists(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 录入新行业
        /// </summary>
        void TradeAdd()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            string name = nv["name"];
            E_Trade data = new E_Trade();
            data.PersonalID = pp.PersonalID;
            data.TradeID = 0;
            data.TradeCode = "";
            data.TradeName = name;
            int tradeid = new T_Trade().Add(data);
            HttpContext.Current.Response.Write(tradeid);
        }
        /// <summary>
        /// 修改行业
        /// </summary>
        void TradeUpdate()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int tradeid = int.Parse(nv["tradeid"]);
            string name = nv["name"];
            E_Trade data = new E_Trade();
            data.PersonalID = pp.PersonalID;
            data.TradeID = tradeid;
            data.TradeCode = "";
            data.TradeName = name;
            bool b = new T_Trade().Update(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除行业信息
        /// </summary>
        void TradeDelete()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int tradeid = int.Parse(nv["tradeid"]);
            E_Trade data = new E_Trade();
            data.PersonalID = pp.PersonalID;
            data.TradeID = tradeid;
            bool b = new T_Trade().Delete(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 显示行业信息
        /// </summary>
        void TradeShow()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int tradeid = int.Parse(nv["tradeid"]);
            E_Trade data = new E_Trade();
            data.PersonalID = pp.PersonalID;
            data.TradeID = tradeid;
            data = new T_Trade().GetModel(data);
            if (data == null)
            {
                data = new E_Trade();
                data.TradeID = 0;
            }
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("id", data.TradeID.ToString()));
            colDR.Add(new JsonStringValue("code", data.TradeCode));
            colDR.Add(new JsonStringValue("name", data.TradeName));
            HttpContext.Current.Response.Write(colDR.ToString());
        }
        /// <summary>
        /// 地区是否存在
        /// </summary>
        void AreaExists()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int areaid = int.Parse(nv["areaid"]);
            string name = nv["name"];
            E_Area data = new E_Area();
            data.PersonalID = pp.PersonalID;
            data.AreaID = areaid;
            data.AreaName = name;
            bool b = new T_Area().Exists(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }

        /// <summary>
        /// 录入新地区
        /// </summary>
        void AreaAdd()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            //string code = nv["code"];
            string name = nv["name"];
            E_Area data = new E_Area();
            data.PersonalID = pp.PersonalID;
            data.AreaID = 0;
            data.AreaCode = "";
            data.AreaName = name;
            int areaid = new T_Area().Add(data);
            HttpContext.Current.Response.Write(areaid);
        }
        /// <summary>
        /// 修改地区
        /// </summary>
        void AreaUpdate()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int areaid = int.Parse(nv["areaid"]);
            //string code = nv["code"];
            string name = nv["name"];
            E_Area data = new E_Area();
            data.PersonalID = pp.PersonalID;
            data.AreaID = areaid;
            data.AreaCode = "";
            data.AreaName = name;
            bool b = new T_Area().Update(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除地区
        /// </summary>
        void AreaDelete()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int areaid = int.Parse(nv["areaid"]);
            E_Area data = new E_Area();
            data.PersonalID = pp.PersonalID;
            data.AreaID = areaid;
            bool b = new T_Area().Delete(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 显示地区信息
        /// </summary>
        void AreaShow()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int areaid = int.Parse(nv["areaid"]);
            E_Area data = new E_Area();
            data.PersonalID = pp.PersonalID;
            data.AreaID = areaid;
            data = new T_Area().GetModel(data);
            if (data == null)
            {
                data = new E_Area();
                data.AreaID = 0;
            }
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("id", data.AreaID.ToString()));
            colDR.Add(new JsonStringValue("code", data.AreaCode));
            colDR.Add(new JsonStringValue("name", data.AreaName));
            HttpContext.Current.Response.Write(colDR.ToString());
        }

        /// <summary>
        /// 来源是否存在
        /// </summary>
        void SourceExists()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int sourceid = int.Parse(nv["sourceid"]);
            string name = nv["name"];
            E_Source data = new E_Source();
            data.PersonalID = pp.PersonalID;
            data.SourceID = sourceid;
            data.SourceName = name;
            bool b = new T_Source().Exists(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }

        /// <summary>
        /// 录入新来源
        /// </summary>
        void SourceAdd()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            
            string name = nv["name"];
            int putin;
            if (!int.TryParse(nv["putin"], out putin))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            string intro = nv["intro"];
            E_Source data = new E_Source();
            data.PersonalID = pp.PersonalID;
            data.SourceID = 0;
            data.SourceCode = "";
            data.SourceName = name;
            data.Putin = putin;
            data.Intro = intro;
            int areaid = new T_Source().Add(data);
            HttpContext.Current.Response.Write(areaid);
        }
        /// <summary>
        /// 修改来源
        /// </summary>
        void SourceUpdate()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int sourceid = int.Parse(nv["sourceid"]);
       
            string name = nv["name"];
            int putin ;
            if (!int.TryParse(nv["putin"], out putin))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            string intro = nv["intro"];
            E_Source data = new E_Source();
            data.PersonalID = pp.PersonalID;
            data.SourceID = sourceid;
            data.SourceCode = "";
            data.SourceName = name;
            data.Putin = putin;
            data.Intro = intro;
            bool b = new T_Source().Update(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除来源
        /// </summary>
        void SourceDelete()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int sourceid = int.Parse(nv["sourceid"]);
            E_Source data = new E_Source();
            data.PersonalID = pp.PersonalID;
            data.SourceID = sourceid;
            bool b = new T_Source().Delete(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 显示来源信息
        /// </summary>
        void SourceShow()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int sourceid = int.Parse(nv["sourceid"]);
            E_Source data = new E_Source();
            data.PersonalID = pp.PersonalID;
            data.SourceID = sourceid;
            data = new T_Source().GetModel(data);
            if (data == null)
            {
                data = new E_Source();
                data.SourceID = 0;
            }
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("id", data.SourceID.ToString()));
            colDR.Add(new JsonStringValue("code", data.SourceCode));
            colDR.Add(new JsonStringValue("name", data.SourceName));
            colDR.Add(new JsonStringValue("putin", data.Putin.ToString()));
            colDR.Add(new JsonStringValue("intro", data.Intro));
            HttpContext.Current.Response.Write(colDR.ToString());
        }
        #endregion

        #region 意向进展设置
        /// <summary>
        /// 意向进展状态是否存在
        /// </summary>
        void WishExists()
        {
            //MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int wishid = int.Parse(nv["wishid"]);
            string name = nv["name"];
            E_Wish data = new E_Wish();
            data.PersonalID = pp.PersonalID;
            data.WishID = wishid;
            data.WishName = name;
            bool b = new T_Wish().Exists(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 录入新意向进展状态
        /// </summary>
        void WishAdd()
        {
            //MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            string name = nv["name"];
            int percent = int.Parse(nv["percent"]);
            E_Wish data = new E_Wish();
            data.PersonalID = pp.PersonalID;
            data.WishID = 0;
            data.WishName = name;
            data.WishPercent = percent;
            int tradeid = new T_Wish().Add(data);
            HttpContext.Current.Response.Write(tradeid);
        }
        /// <summary>
        /// 修改意向进展状态
        /// </summary>
        void WishUpdate()
        {
            //MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int wishid = int.Parse(nv["wishid"]);
            string name = nv["name"];
            int percent = int.Parse(nv["percent"]);
            E_Wish data = new E_Wish();
            data.PersonalID = pp.PersonalID;
            data.WishID = wishid;
            data.WishName = name;
            data.WishPercent = percent;
            bool b = new T_Wish().Update(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除意向进展信息
        /// </summary>
        void WishDelete()
        {
            //MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int wishid = int.Parse(nv["wishid"]);
            E_Wish data = new E_Wish();
            data.PersonalID = pp.PersonalID;
            data.WishID = wishid;
            bool b = new T_Wish().Delete(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 获取显示意向进展状态信息
        /// </summary>
        void WishShow()
        {
            //MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int wishid = int.Parse(nv["wishid"]);
            E_Wish data = new E_Wish();
            data.PersonalID = pp.PersonalID;
            data.WishID = wishid;
            data = new T_Wish().GetModel(data);
            if (data == null)
            {
                data = new E_Wish();
                data.WishID = 0;
            }
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("id", data.WishID.ToString()));
            colDR.Add(new JsonStringValue("name", data.WishName));
            colDR.Add(new JsonStringValue("percent", data.WishPercent.ToString()));
            HttpContext.Current.Response.Write(colDR.ToString());
        }
        #endregion

        #region 失败
        /// <summary>
        /// 失败是否存在
        /// </summary>
        void NoTradedExists()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int nottradedid = 0;
            int.TryParse(nv["nottradedid"], out nottradedid);
            string name = nv["name"];
            E_NotTraded data = new E_NotTraded();
            data.PersonalID = pp.PersonalID;
            data.NotTradedID = nottradedid;
            data.NotTradedName = name;
            bool b = new T_NotTraded().Exists(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 录入新失败
        /// </summary>
        void NoTradedAdd()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            string name = nv["name"];
            E_NotTraded data = new E_NotTraded();
            data.PersonalID = pp.PersonalID;
            data.NotTradedID = 0;
            data.NotTradedName = name;
            int tradeid = new T_NotTraded().Add(data);
            HttpContext.Current.Response.Write(tradeid);
        }
        /// <summary>
        /// 修改失败状态
        /// </summary>
        void NoTradedUpdate()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int nottradedid = 0;
            int.TryParse(nv["nottradedid"], out nottradedid);
            string name = nv["name"];
            E_NotTraded data = new E_NotTraded();
            data.PersonalID = pp.PersonalID;
            data.NotTradedID = nottradedid;
            data.NotTradedName = name;
            bool b = new T_NotTraded().Update(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除失败信息
        /// </summary>
        void NoTradedDelete()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int nottradedid = 0;
            int.TryParse(nv["nottradedid"], out nottradedid);
            E_NotTraded data = new E_NotTraded();
            data.PersonalID = pp.PersonalID;
            data.NotTradedID = nottradedid;
            bool b = new T_NotTraded().Delete(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 获取显示失败状态信息
        /// </summary>
        void NoTradedShow()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int nottradedid = 0;
            int.TryParse(nv["nottradedid"], out nottradedid);
            E_NotTraded data = new E_NotTraded();
            data.PersonalID = pp.PersonalID;
            data.NotTradedID = nottradedid;
            data = new T_NotTraded().GetModel(data);
            if (data == null)
            {
                data = new E_NotTraded();
                data.NotTradedID = 0;
            }
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("id", data.NotTradedID.ToString()));
            colDR.Add(new JsonStringValue("name", data.NotTradedName));
            HttpContext.Current.Response.Write(colDR.ToString());
        }
        #endregion

        #region 报废理由
        
        /// <summary>
        /// 报废理由是否存在
        /// </summary>
        void ScrapExists()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int scrapid = 0;
            int.TryParse(nv["scrapid"], out scrapid);
            string name = nv["name"];
            E_Scrap data = new E_Scrap();
            data.PersonalID = pp.PersonalID;
            data.ScrapID = scrapid;
            data.ScrapName = name;
            bool b = new T_Scrap().Exists(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 录入新报废理由
        /// </summary>
        void ScrapAdd()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            string name = nv["name"];
            E_Scrap data = new E_Scrap();
            data.PersonalID = pp.PersonalID;
            data.ScrapID = 0;
            data.ScrapName = name;
            int scrapid = new T_Scrap().Add(data);
            HttpContext.Current.Response.Write(scrapid);
        }
        /// <summary>
        /// 修改报废理由
        /// </summary>
        void ScrapUpdate()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int scrapid = 0;
            int.TryParse(nv["scrapid"], out scrapid);
            string name = nv["name"];
            E_Scrap data = new E_Scrap();
            data.PersonalID = pp.PersonalID;
            data.ScrapID = scrapid;
            data.ScrapName = name;
            bool b = new T_Scrap().Update(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除报废理由
        /// </summary>
        void ScrapDelete()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int scrapid = 0;
            int.TryParse(nv["scrapid"], out scrapid);
            E_Scrap data = new E_Scrap();
            data.PersonalID = pp.PersonalID;
            data.ScrapID = scrapid;
            bool b = new T_Scrap().Delete(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 获取显示报废理由
        /// </summary>
        void ScrapShow()
        {
            MLMGC.Security.PersonalPage pp = new MLMGC.Security.PersonalPage(true);
            int scrapid = 0;
            int.TryParse(nv["scrapid"], out scrapid);
            E_Scrap data = new E_Scrap();
            data.PersonalID = pp.PersonalID;
            data.ScrapID = scrapid;
            data = new T_Scrap().GetModel(data);
            if (data == null)
            {
                data = new E_Scrap();
                data.ScrapID = 0;
            }
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("id", data.ScrapID.ToString()));
            colDR.Add(new JsonStringValue("name", data.ScrapName));
            HttpContext.Current.Response.Write(colDR.ToString());
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}