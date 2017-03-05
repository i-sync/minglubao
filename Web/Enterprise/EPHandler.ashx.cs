using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Data;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;
using System.Net.Json;

namespace Web.Enterprise
{
    /// <summary>
    /// 名录异步操作文件
    /// </summary>
    public class EPHandler : IHttpHandler, IRequiresSessionState
    {
        System.Collections.Specialized.NameValueCollection nv;
        MLMGC.Security.EnterprisePage ep;
        public void ProcessRequest(HttpContext context)
        {
            nv = System.Web.HttpUtility.ParseQueryString(context.Request.Url.Query);
            ep = new MLMGC.Security.EnterprisePage(true);
            switch (nv["key"])
            {
                case "101"://获取团队信息（用于修改）
                    GetTeamInfo();
                    break;
                case "102"://修改团队信息
                    UpdateTeam();
                    break;
                case "201"://启用、禁用
                    UserStatus();
                    break;
                //case "202"://重置密码
                //    ResetPassword();
                //    break;
                case "203"://删除用户
                    DeleteUser();
                    break;
                case "501"://设置属性
                    SetProperty();
                    break;
                //case "601"://设置用户角色
                //    SetUserRole();
                //    break;
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
        #region Team
        /// <summary>
        /// 获取团队信息
        /// </summary>
        public void GetTeamInfo()
        {
            int teamid = int.Parse(nv["teamid"].ToString());
            DataSet ds = new T_Team().GetTeamParent(new E_Team() { TeamID = teamid,EnterpriseID=ep.EnterpriceID });
            JsonArrayCollection jac = new JsonArrayCollection();

            if (MLMGC.COMP.Data.DataSetIsNotNull(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    JsonObjectCollection colDR = new JsonObjectCollection();
                    colDR.Add(new JsonStringValue("text", dr["TeamName"].ToString()));
                    colDR.Add(new JsonStringValue("value", dr["TeamID"].ToString()));
                    jac.Add(colDR);
                }
            }
            else
            {
                JsonObjectCollection colDR = new JsonObjectCollection();
                colDR.Add(new JsonStringValue("text", "无"));
                colDR.Add(new JsonStringValue("value", "0"));
                jac.Add(colDR);
            }
            HttpContext.Current.Response.Write(jac.ToString());
        }
        /// <summary>
        /// 修改团队信息
        /// </summary>
        public void UpdateTeam()
        {
            int teamid = int.Parse(nv["teamid"]);
            string teamname = nv["teamname"].Trim();
            int pid = int.Parse(nv["pid"]);
            bool b = new T_Team().UpdateTeam(new E_Team() {EnterpriseID=ep.EnterpriceID, TeamID = teamid, TeamName = teamname, PID = pid });
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "管理员修改团队信息", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? 1 : 0);
        }
        #endregion

        #region User
        /// <summary>
        /// 用户状态更改
        /// </summary>
        void UserStatus()
        {
            int status = int.Parse(nv["status"].ToString());
            int uid = int.Parse(nv["uid"].ToString());
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            status = status > 1 ? 1 : status;

            E_User data = new E_User();
            data.EnterpriseID = ep.EnterpriceID;
            data.UserID = uid;
            data.Status = status;
            bool b = new T_User().UserStatus(data);
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "管理员更改用户的状态", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        ///// <summary>
        ///// 重置密码
        ///// </summary>
        //void ResetPassword()
        //{
        //    int uid = int.Parse(nv["uid"].ToString());
        //    MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);

        //    E_User data = new E_User();
        //    data.EnterpriseID = ep.EnterpriceID;
        //    data.UserID = uid;
        //    data.Password = "888888";
        //    bool b = new T_User().ResetPassword(data);
        //    HttpContext.Current.Response.Write(b ? "1" : "0");
        //}
        /// <summary>
        /// 删除用户
        /// </summary>
        void DeleteUser()
        {
            int uid = int.Parse(nv["uid"].ToString());
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);

            E_User data = new E_User();
            data.EnterpriseID = ep.EnterpriceID;
            data.UserID = uid;
            int i = new T_User().EPUserDelete(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "管理员删除企业用户", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(i);
        }
        #endregion

        //#region 角色
        ///// <summary>
        ///// 设置用户角色信息
        ///// </summary>
        //void SetUserRole()
        //{
        //    MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
        //    int uid = int.Parse(nv["uid"]);
        //    string v = nv["v"];
        //    int i = new T_User().SetTeamUserRole(new E_User() { EnterpriseID = ep.EnterpriceID, UserID = uid, RoleSetting = v });
        //    HttpContext.Current.Response.Write(i);
        //}
        //#endregion

        #region 属性
        /// <summary>
        /// 设置属性
        /// </summary>
        void SetProperty()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            string trade = nv["trade"];
            string area = nv["area"];
            string source = nv["source"];
            E_Property data = new E_Property();
            data.EnterpriseID = ep.EnterpriceID;
            data.TradeFlag = trade=="true" ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
            data.AreaFlag = area=="true" ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
            data.SourceFlag = source=="true" ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
            bool b = new T_Property().Set(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }

        /// <summary>
        /// 行业是否存在
        /// </summary>
        void TradeExists()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int tradeid = int.Parse(nv["tradeid"]);
            string code = nv["code"];
            E_Trade data = new E_Trade();
            data.EnterpriseID = ep.EnterpriceID;
            data.TradeID = tradeid;
            data.TradeCode = code;
            bool b = new T_Trade().Exists(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 录入新行业
        /// </summary>
        void TradeAdd()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            string code = nv["code"];
            string name = nv["name"];
            E_Trade data = new E_Trade();
            data.EnterpriseID = ep.EnterpriceID;
            data.TradeID = 0;
            data.TradeCode = code;
            data.TradeName = name;
            int tradeid = new T_Trade().Add(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "添加行业", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(tradeid);
        }
        /// <summary>
        /// 修改行业
        /// </summary>
        void TradeUpdate()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int tradeid = int.Parse(nv["tradeid"]);
            string code = nv["code"];
            string name = nv["name"];
            E_Trade data = new E_Trade();
            data.EnterpriseID = ep.EnterpriceID;
            data.TradeID = tradeid;
            data.TradeCode = code;
            data.TradeName = name;
            bool b = new T_Trade().Update(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "修改行业", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除行业信息
        /// </summary>
        void TradeDelete()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int tradeid = int.Parse(nv["tradeid"]);
            E_Trade data = new E_Trade();
            data.EnterpriseID = ep.EnterpriceID;
            data.TradeID = tradeid;
            bool b = new T_Trade().Delete(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "删除行业", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 显示行业信息
        /// </summary>
        void TradeShow()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int tradeid = int.Parse(nv["tradeid"]);
            E_Trade data = new E_Trade();
            data.EnterpriseID = ep.EnterpriceID;
            data.TradeID = tradeid;
            data = new T_Trade().GetModel(data);
            if (data==null)
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
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int areaid = int.Parse(nv["areaid"]);
            string code = nv["code"];
            E_Area data = new E_Area();
            data.EnterpriseID = ep.EnterpriceID;
            data.AreaID = areaid;
            data.AreaCode = code;
            bool b = new T_Area().Exists(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }

        /// <summary>
        /// 录入新地区
        /// </summary>
        void AreaAdd()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            string code = nv["code"];
            string name = nv["name"];
            E_Area data = new E_Area();
            data.EnterpriseID = ep.EnterpriceID;
            data.AreaID = 0;
            data.AreaCode = code;
            data.AreaName = name;
            int areaid = new T_Area().Add(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "添加地区", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(areaid);
        }
        /// <summary>
        /// 修改地区
        /// </summary>
        void AreaUpdate()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int areaid = int.Parse(nv["areaid"]);
            string code = nv["code"];
            string name = nv["name"];
            E_Area data = new E_Area();
            data.EnterpriseID = ep.EnterpriceID;
            data.AreaID = areaid;
            data.AreaCode = code;
            data.AreaName = name;
            bool b = new T_Area().Update(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "修改地区", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除地区
        /// </summary>
        void AreaDelete()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int areaid = int.Parse(nv["areaid"]);
            E_Area data = new E_Area();
            data.EnterpriseID = ep.EnterpriceID;
            data.AreaID = areaid;
            bool b = new T_Area().Delete(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "删除地区", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 显示地区信息
        /// </summary>
        void AreaShow()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int areaid = int.Parse(nv["areaid"]);
            E_Area data = new E_Area();
            data.EnterpriseID = ep.EnterpriceID;
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
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int sourceid = int.Parse(nv["sourceid"]);
            string code = nv["code"];
            E_Source data = new E_Source();
            data.EnterpriseID = ep.EnterpriceID;
            data.SourceID = sourceid;
            data.SourceCode = code;
            bool b = new T_Source().Exists(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }

        /// <summary>
        /// 录入新来源
        /// </summary>
        void SourceAdd()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            string code = nv["code"];
            string name = nv["name"];
            string putin = nv["putin"];
            string intro = nv["intro"];
            
            E_Source data = new E_Source();
            data.EnterpriseID = ep.EnterpriceID;
            data.SourceID = 0;
            data.SourceCode = code;
            data.SourceName = name;
            //if (!string.IsNullOrEmpty(putin))
            //{
            //    data.Putin = Convert.ToInt32(putin);
            //}
            int num;
            if (!int.TryParse(putin, out num))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            data.Putin = num;
            data.Intro = intro;
            int areaid = new T_Source().Add(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "添加来源", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(areaid);
        }
        /// <summary>
        /// 修改来源
        /// </summary>
        void SourceUpdate()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int sourceid = int.Parse(nv["sourceid"]);
            string code = nv["code"];
            string name = nv["name"];
            string putin = nv["putin"];
            string intro = nv["intro"];

            E_Source data = new E_Source();
            data.EnterpriseID = ep.EnterpriceID;
            data.SourceID = sourceid;
            data.SourceCode = code;
            data.SourceName = name;
            if (putin != null)
            {
                data.Putin = Convert.ToInt32(putin);
            }
            data.Intro = intro;
            bool b = new T_Source().Update(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "修改来源", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除来源
        /// </summary>
        void SourceDelete()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int sourceid = int.Parse(nv["sourceid"]);
            E_Source data = new E_Source();
            data.EnterpriseID = ep.EnterpriceID;
            data.SourceID = sourceid;
            bool b = new T_Source().Delete(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "删除来源", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 显示来源信息
        /// </summary>
        void SourceShow()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int sourceid = int.Parse(nv["sourceid"]);
            E_Source data = new E_Source();
            data.EnterpriseID = ep.EnterpriceID;
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
            colDR.Add(new JsonStringValue("putin",data.Putin.ToString()));
            colDR.Add(new JsonStringValue("intro",data.Intro));
            HttpContext.Current.Response.Write(colDR.ToString());
        }
        #endregion
        #region 状态
        /// <summary>
        /// 意向进展状态是否存在
        /// </summary>
        void WishExists()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int wishid = int.Parse(nv["wishid"]);
            string name = nv["name"];
            E_Wish data = new E_Wish();
            data.EnterpriseID = ep.EnterpriceID;
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
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            string name = nv["name"];
            int percent = int.Parse(nv["percent"]);
            E_Wish data = new E_Wish();
            data.EnterpriseID = ep.EnterpriceID;
            data.WishID = 0;
            data.WishName = name;
            data.WishPercent =percent;
            int tradeid = new T_Wish().Add(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "添加意向状态", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(tradeid);
        }
        /// <summary>
        /// 修改意向进展状态
        /// </summary>
        void WishUpdate()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int wishid = int.Parse(nv["wishid"]);
            string name = nv["name"];
            int percent = int.Parse(nv["percent"]);
            E_Wish data = new E_Wish();
            data.EnterpriseID = ep.EnterpriceID;
            data.WishID = wishid;
            data.WishName = name;
            data.WishPercent =percent;
            bool b = new T_Wish().Update(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "修改意向状态", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除意向进展信息
        /// </summary>
        void WishDelete()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int wishid = int.Parse(nv["wishid"]);
            E_Wish data = new E_Wish();
            data.EnterpriseID = ep.EnterpriceID;
            data.WishID = wishid;
            int result = new T_Wish().Delete(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "删除意向状态", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(result.ToString());
        }
        /// <summary>
        /// 获取显示意向进展状态信息
        /// </summary>
        void WishShow()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int wishid = int.Parse(nv["wishid"]);
            E_Wish data = new E_Wish();
            data.EnterpriseID = ep.EnterpriceID;
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
        /// <summary>
        /// 失败是否存在
        /// </summary>
        void NoTradedExists()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int nottradedid = 0;
            int.TryParse(nv["nottradedid"],out nottradedid);
            string name = nv["name"];
            E_NotTraded data = new E_NotTraded();
            data.EnterpriseID = ep.EnterpriceID;
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
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            string name = nv["name"];
            E_NotTraded data = new E_NotTraded();
            data.EnterpriseID = ep.EnterpriceID;
            data.NotTradedID = 0;
            data.NotTradedName= name;
            int tradeid = new T_NotTraded().Add(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "添加失败理由", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(tradeid);
        }
        /// <summary>
        /// 修改失败状态
        /// </summary>
        void NoTradedUpdate()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int nottradedid = 0;
            int.TryParse(nv["nottradedid"], out nottradedid);
            string name = nv["name"];
            E_NotTraded data = new E_NotTraded();
            data.EnterpriseID = ep.EnterpriceID;
            data.NotTradedID =nottradedid;
            data.NotTradedName = name;
            bool b = new T_NotTraded().Update(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "修改失败理由", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除失败信息
        /// </summary>
        void NoTradedDelete()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int nottradedid = 0;
            int.TryParse(nv["nottradedid"], out nottradedid);
            E_NotTraded data = new E_NotTraded();
            data.EnterpriseID = ep.EnterpriceID;
            data.NotTradedID = nottradedid;
            int result = new T_NotTraded().Delete(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "删除失败理由", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(result.ToString());
        }
        /// <summary>
        /// 获取显示失败状态信息
        /// </summary>
        void NoTradedShow()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int nottradedid = 0;
            int.TryParse(nv["nottradedid"], out nottradedid);
            E_NotTraded data = new E_NotTraded();
            data.EnterpriseID = ep.EnterpriceID;
            data.NotTradedID = nottradedid;
            data = new T_NotTraded().GetModel(data);
            if (data == null)
            {
                data = new E_NotTraded();
                data.NotTradedID= 0;
            }
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("id", data.NotTradedID.ToString()));
            colDR.Add(new JsonStringValue("name", data.NotTradedName));
            HttpContext.Current.Response.Write(colDR.ToString());
        }
        /// <summary>
        /// 报废理由是否存在
        /// </summary>
        void ScrapExists()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int scrapid = 0;
            int.TryParse(nv["scrapid"], out scrapid);
            string name = nv["name"];
            E_Scrap data = new E_Scrap();
            data.EnterpriseID = ep.EnterpriceID;
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
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            string name = nv["name"];
            E_Scrap data = new E_Scrap();
            data.EnterpriseID = ep.EnterpriceID;
            data.ScrapID = 0;
            data.ScrapName = name;
            int scrapid = new T_Scrap().Add(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "添加报废理由", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(scrapid);
        }
        /// <summary>
        /// 修改报废理由
        /// </summary>
        void ScrapUpdate()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int scrapid = 0;
            int.TryParse(nv["scrapid"], out scrapid);
            string name = nv["name"];
            E_Scrap data = new E_Scrap();
            data.EnterpriseID = ep.EnterpriceID;
            data.ScrapID = scrapid;
            data.ScrapName = name;
            bool b = new T_Scrap().Update(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "修改报废理由", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        /// <summary>
        /// 删除报废理由
        /// </summary>
        void ScrapDelete()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int scrapid = 0;
            int.TryParse(nv["scrapid"], out scrapid);
            E_Scrap data = new E_Scrap();
            data.EnterpriseID = ep.EnterpriceID;
            data.ScrapID =scrapid;
            int result = new T_Scrap().Delete(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = ep.EnterpriceID, UserID = ep.UserID, LogTitle = "删除报废理由", IP = MLMGC.COMP.Requests.GetRealIP() });
            HttpContext.Current.Response.Write(result.ToString());
        }
        /// <summary>
        /// 获取显示报废理由
        /// </summary>
        void ScrapShow()
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            int scrapid = 0;
            int.TryParse(nv["scrapid"], out scrapid);
            E_Scrap data = new E_Scrap();
            data.EnterpriseID = ep.EnterpriceID;
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