using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DBUtility;
using MLMGC.COMP;

namespace MLMGC.DAL.Enterprise
{
    public class D_ClientInfo : MLMGC.IDAL.Enterprise.I_D_ClientInfo
    {
        #region 业务员名录列表
        /// <summary>
        /// 获取名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-11</remarks>
        public DataTable GetList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@Linkman",SqlDbType.NVarChar,128),
                new SqlParameter("@Tel",SqlDbType.VarChar,128),
                new SqlParameter("@Mobile",SqlDbType.VarChar,128),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = (int)data.Property.SourceFlag;
            parms[2].Value = (int)data.Property.AreaFlag;
            parms[3].Value = (int)data.Property.TradeFlag;
            parms[4].Value = data.SourceID;
            parms[5].Value = data.AreaID;
            parms[6].Value = data.TradeID;
            parms[7].Value = (int)data.Mode;
            parms[8].Value = data.EPUserTMRID;
            parms[9].Value = data.TeamID;
            parms[10].Value = (int)data.Status;
            parms[11].Value = data.ClientName;
            parms[12].Value = data.Linkman;
            parms[13].Value = data.Tel;
            parms[14].Value = data.Mobile;
            parms[15].Value = data.Email;
            parms[16].Value = data.Page.PageSize;
            parms[17].Value = data.Page.PageIndex;
            parms[18].Value = 0;
            parms[18].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_Select", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[18].Value)?"0":parms[18].Value);
            
            return dt;
        }

        /// <summary>
        /// 获取业务员潜在名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-03</remarks>
        public DataTable GetLatenceList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = (int)data.Property.SourceFlag;
            parms[2].Value = (int)data.Property.AreaFlag;
            parms[3].Value = (int)data.Property.TradeFlag;
            parms[4].Value = data.SourceID;
            parms[5].Value = data.AreaID;
            parms[6].Value = data.TradeID;
            parms[7].Value = (int)data.Mode;
            parms[8].Value = data.EPUserTMRID;
            parms[9].Value = data.TeamID;
            parms[10].Value = (int)data.Status;
            parms[11].Value = data.ClientName;
            parms[12].Value = data.Page.PageSize;
            parms[13].Value = data.Page.PageIndex;
            parms[14].Value = 0;
            parms[14].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_LatenceSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[14].Value) ? "0" : parms[14].Value);

            return dt;
        }

        /// <summary>
        /// 获取业务员意向名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <remarks>qipengfei 2011-10-17</remarks>
        /// <returns></returns>
        public DataTable GetWishList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@WishID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = (int)data.Property.SourceFlag;
            parms[2].Value = (int)data.Property.AreaFlag;
            parms[3].Value = (int)data.Property.TradeFlag;
            parms[4].Value = data.SourceID;
            parms[5].Value = data.AreaID;
            parms[6].Value = data.TradeID;
            parms[7].Value = (int)data.Mode;
            parms[8].Value = data.EPUserTMRID;
            parms[9].Value = data.WishID;
            parms[10].Value = (int)data.Status;
            parms[11].Value = data.ClientName;
            parms[12].Value = data.Page.PageSize;
            parms[13].Value = data.Page.PageIndex;
            parms[14].Value = 0;
            parms[14].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_WishSelect", parms);
            data.Page.TotalCount = parms[14].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[14].Value);
            return dt;
        }

        /// <summary>
        /// 获取业务员成交名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-17</remarks>
        public DataTable GetTradedList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@TradedMoney",SqlDbType.Money),
                new SqlParameter("@Status",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = (int)data.Property.SourceFlag;
            parms[2].Value = (int)data.Property.AreaFlag;
            parms[3].Value = (int)data.Property.TradeFlag;
            parms[4].Value = data.SourceID;
            parms[5].Value = data.AreaID;
            parms[6].Value = data.TradeID;
            parms[7].Value = (int)data.Mode;
            parms[8].Value = data.EPUserTMRID;
            parms[9].Value = data.TradedMoney;
            parms[10].Value = (int)data.Status;
            parms[11].Value = data.ClientName;
            parms[12].Value = data.Page.PageSize;
            parms[13].Value = data.Page.PageIndex;
            parms[14].Value = 0;
            parms[14].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_TradedSelect", parms);
            data.Page.TotalCount = parms[14].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[14].Value);
            return dt;
        }


        /// <summary>
        /// 获取共享名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-17</remarks>
        public DataTable GetShareList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = (int)data.Property.SourceFlag;
            parms[2].Value = (int)data.Property.AreaFlag;
            parms[3].Value = (int)data.Property.TradeFlag;
            parms[4].Value = data.SourceID;
            parms[5].Value = data.AreaID;
            parms[6].Value = data.TradeID;
            parms[7].Value = (int)data.Mode;
            parms[8].Value = data.ClientName;
            parms[9].Value = data.Page.PageSize;
            parms[10].Value = data.Page.PageIndex;
            parms[11].Value = 0;
            parms[11].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_ShareSelect", parms);
            data.Page.TotalCount = parms[11].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[11].Value);
            return dt;
        }
        #endregion

        #region 领导查询名录列表
        /// <summary>
        /// 领导 统计信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-19</remarks>
        public DataTable LeaderStatistics(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt)                
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_Statistics", parms);
        }

        /// <summary>
        /// 领导 统计 失败
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-24</remarks>
        public DataTable LeaderStatisticsNotTraded(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt)                
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_NotStatistics", parms);
        }
        /// <summary>
        /// 领导 统计 报废
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-24</remarks>
        public DataTable LeaderStatisticsScrap(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt)                
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_ScrapStatistics", parms);
        }

        /// <summary>
        /// 领导  统计 成交名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-24</remarks>
        public DataTable LeaderStatisticsTraded(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt)                
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_TradedStatistics", parms);
        }
        /// <summary>
        /// 领导模糊查询列表(第一个为查询列表、)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-19</remarks>
        public DataSet LeaderList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = data.ClientName;
            parms[3].Value = data.Page.PageSize;
            parms[4].Value = data.Page.PageIndex;
            parms[5].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedureDataSet("ProcEP_B_ClientInfoS_LeaderSelect", parms);
            data.Page.TotalCount = parms[5].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[5].Value);
            return ds;
        }

        /// <summary>
        /// 领导待分配列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable LeaderWaitList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            parms[4].Value = data.ClientName;
            parms[5].Value = (int)data.Property.SourceFlag;
            parms[6].Value = (int)data.Property.AreaFlag;
            parms[7].Value = (int)data.Property.TradeFlag;
            parms[8].Value = data.SourceID;
            parms[9].Value = data.AreaID;
            parms[10].Value = data.TradeID;
            parms[11].Value = data.Page.StartDate;
            parms[12].Value = data.Page.EndDate;
            parms[13].Value = data.Page.PageSize;
            parms[14].Value = data.Page.PageIndex;
            parms[15].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_LeaderWaitSelect", parms);
            data.Page.TotalCount = parms[15].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[15].Value);
            return dt;
        }
        /// <summary>
        /// 领导查询潜在客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-20</remarks>
        public DataTable LeaderLatenceList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter ("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            parms[4].Value = data.EPUserTMRID;
            parms[5].Value = data.ClientName;
            parms[6].Value = (int)data.Property.SourceFlag;
            parms[7].Value = (int)data.Property.AreaFlag;
            parms[8].Value = (int)data.Property.TradeFlag;
            parms[9].Value = data.SourceID;
            parms[10].Value = data.AreaID;
            parms[11].Value = data.TradeID;
            parms[12].Value = data.Page.StartDate;
            parms[13].Value = data.Page.EndDate;
            parms[14].Value = data.Page.PageSize;
            parms[15].Value = data.Page.PageIndex;
            parms[16].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_LeaderLatenceSelect", parms);
            data.Page.TotalCount = parms[16].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[16].Value);
            return dt;
        }

        /// <summary>
        /// 领导查询意向客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-20</remarks>
        public DataTable LeaderWishList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@WishID",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            parms[4].Value = data.EPUserTMRID;
            parms[5].Value = data.ClientName;
            parms[6].Value = (int)data.Property.SourceFlag;
            parms[7].Value = (int)data.Property.AreaFlag;
            parms[8].Value = (int)data.Property.TradeFlag;
            parms[9].Value = data.SourceID;
            parms[10].Value = data.AreaID;
            parms[11].Value = data.TradeID;
            parms[12].Value = data.WishID;
            parms[13].Value = data.Page.StartDate;
            parms[14].Value = data.Page.EndDate;
            parms[15].Value = data.Page.PageSize;
            parms[16].Value = data.Page.PageIndex;
            parms[17].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_LeaderWishSelect", parms);
            data.Page.TotalCount = parms[17].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[17].Value);
            return dt;
        }
        /// <summary>
        /// 领导查询成交客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-21</remarks>
        public DataTable LeaderTradedList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            parms[4].Value = data.EPUserTMRID;
            parms[5].Value = data.ClientName;
            parms[6].Value = (int)data.Property.SourceFlag;
            parms[7].Value = (int)data.Property.AreaFlag;
            parms[8].Value = (int)data.Property.TradeFlag;
            parms[9].Value = data.SourceID;
            parms[10].Value = data.AreaID;
            parms[11].Value = data.TradeID;
            parms[12].Value = data.Page.StartDate;
            parms[13].Value = data.Page.EndDate;

            parms[14].Value = data.Page.PageSize;
            parms[15].Value = data.Page.PageIndex;
            parms[16].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_LeaderTradedSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[16].Value)?"0":parms[16].Value);
            return dt;
        }
        /// <summary>
        /// 领导查询失败客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-21</remarks>
        public DataTable LeaderNotTradedList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@LookTeamID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            parms[4].Value = data.LookTeamID;
            parms[5].Value = data.ClientName;
            parms[6].Value = (int)data.Property.SourceFlag;
            parms[7].Value = (int)data.Property.AreaFlag;
            parms[8].Value = (int)data.Property.TradeFlag;
            parms[9].Value = data.SourceID;
            parms[10].Value = data.AreaID;
            parms[11].Value = data.TradeID;
            parms[12].Value = data.NotTradedID;

            parms[13].Value = data.Page.PageSize;
            parms[14].Value = data.Page.PageIndex;
            parms[15].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_LeaderNotTradedSelect", parms);
            data.Page.TotalCount = parms[15].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[15].Value);
            return dt;
        }

        /// <summary>
        /// 领导查询报废客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-21</remarks>
        public DataTable LeaderScrapList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@LookTeamID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@ScrapID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            parms[4].Value = data.LookTeamID;
            parms[5].Value = data.ClientName;
            parms[6].Value = (int)data.Property.SourceFlag;
            parms[7].Value = (int)data.Property.AreaFlag;
            parms[8].Value = (int)data.Property.TradeFlag;
            parms[9].Value = data.SourceID;
            parms[10].Value = data.AreaID;
            parms[11].Value = data.TradeID;
            parms[12].Value = data.ScrapID;

            parms[13].Value = data.Page.PageSize;
            parms[14].Value = data.Page.PageIndex;
            parms[15].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_LeaderScrapSelect", parms);
            data.Page.TotalCount = parms[15].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[15].Value);
            return dt;
        }
        #endregion

        #region 名录基本信息操作
        /// <summary>
        /// 判断名录名称是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-02</remarks>
        public DataTable Exists(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128)                
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.ClientName;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_Exists", parms);
        }

        /// <summary>
        /// 添加新名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@Address",SqlDbType.VarChar,128),
                new SqlParameter("@ZipCode",SqlDbType.VarChar,8),
                new SqlParameter("@Linkman",SqlDbType.VarChar,64),
                new SqlParameter("@Position",SqlDbType.VarChar,64),
                new SqlParameter("@Tel",SqlDbType.VarChar,32),
                new SqlParameter("@Mobile",SqlDbType.VarChar,16),
                new SqlParameter("@Fax",SqlDbType.VarChar,32),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@QQ",SqlDbType.VarChar,128),
                new SqlParameter("@MSN",SqlDbType.VarChar,128),
                new SqlParameter("@Remark",SqlDbType.VarChar),
                new SqlParameter("@SourceCode",SqlDbType.VarChar,16),
                new SqlParameter("@TradeCode",SqlDbType.VarChar,16),
                new SqlParameter("@AreaCode",SqlDbType.VarChar,16),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter ("@Website",SqlDbType.VarChar,128),
                new SqlParameter("@ClientInfoID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientName;
            parms[2].Value = data.Address;
            parms[3].Value = data.ZipCode;
            parms[4].Value = data.Linkman;
            parms[5].Value = data.Position;
            parms[6].Value = data.Tel;
            parms[7].Value = data.Mobile;
            parms[8].Value = data.Fax;
            parms[9].Value = data.Email;
            parms[10].Value = data.QQ;
            parms[11].Value = data.MSN;
            parms[12].Value = data.Remark;
            parms[13].Value = data.SourceCode;
            parms[14].Value = data.TradeCode;
            parms[15].Value = data.AreaCode;
            parms[16].Value = data.EPUserTMRID;
            parms[17].Value = data.Website;
            parms[18].Direction = ParameterDirection.Output;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientInfoS_Insert", parms, out ReturnValue);
            if (ReturnValue > 0)//判断是否录入成功
            {
                data.ClientInfoID = Convert.ToInt32(parms[18].Value);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取名录详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-13</remarks>
        public E_ClientInfo GetModel(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.EPUserTMRID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_DataSelect", parms);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["ClientInfoID"] != DBNull.Value)
            {
                //----------------基本信息----------------
                data.ClientInfoID = Convert.ToInt32(dt.Rows[0]["ClientInfoID"].ToString());
                data.ClientName = dt.Rows[0]["ClientName"].ToString();
                data.Address = dt.Rows[0]["Address"].ToString();
                data.ZipCode = dt.Rows[0]["ZipCode"].ToString();
                data.Linkman = dt.Rows[0]["Linkman"].ToString();
                data.Position = dt.Rows[0]["Position"].ToString();
                data.Tel = dt.Rows[0]["Tel"].ToString();
                data.Mobile = dt.Rows[0]["Mobile"].ToString();
                data.Fax = dt.Rows[0]["Fax"].ToString();
                data.Website = dt.Rows[0]["Website"].ToString();
                data.Email = dt.Rows[0]["Email"].ToString();
                data.QQ = dt.Rows[0]["QQ"].ToString();
                data.MSN = dt.Rows[0]["MSN"].ToString();
                data.Remark = dt.Rows[0]["Remark"].ToString();
                //----------------名录状态----------------
                data.SetStatus = Convert.ToInt32(dt.Rows[0]["Status"]);
                //----------------名录类型----------------
                data.SetMode = Convert.ToInt32(dt.Rows[0]["Mode"]);
                //----------------名录属性----------------
                if (!Convert.IsDBNull(dt.Rows[0]["AreaID"]))//----地区编号
                {
                    data.AreaID = Convert.ToInt32(dt.Rows[0]["AreaID"]);
                }
                if (!Convert.IsDBNull(dt.Rows[0]["SourceID"]))//----来源编号
                {
                    data.SourceID = Convert.ToInt32(dt.Rows[0]["SourceID"]);
                }
                if (!Convert.IsDBNull(dt.Rows[0]["TradeID"]))//----行业编号
                {
                    data.TradeID = Convert.ToInt32(dt.Rows[0]["TradeID"]);
                }
                //----------------名录各状态值----------------
                if (!Convert.IsDBNull(dt.Rows[0]["wishid"]))//----意向编号
                {
                    data.WishID = Convert.ToInt32(dt.Rows[0]["wishid"]);
                }
                if (!Convert.IsDBNull(dt.Rows[0]["TradedMoney"]))//----成交金额
                {
                    data.TradedMoney = float.Parse(dt.Rows[0]["TradedMoney"].ToString());
                }
                if (!Convert.IsDBNull(dt.Rows[0]["NotTradedID"]))//----失败编号
                {
                    data.NotTradedID = Convert.ToInt32(dt.Rows[0]["NotTradedID"]);
                }
                if (!Convert.IsDBNull(dt.Rows[0]["ScrapID"]))//----报废编号
                {
                    data.ScrapID = Convert.ToInt32(dt.Rows[0]["ScrapID"]);
                }
            }
            else
            {
                data = null;
            }
            return data;
        }

        /// <summary>
        /// 修改名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-13</remarks>
        public bool Update(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@Address",SqlDbType.VarChar,128),
                new SqlParameter("@ZipCode",SqlDbType.VarChar,8),
                new SqlParameter("@Linkman",SqlDbType.VarChar,64),
                new SqlParameter("@Position",SqlDbType.VarChar,64),
                new SqlParameter("@Tel",SqlDbType.VarChar,32),
                new SqlParameter("@Mobile",SqlDbType.VarChar,16),
                new SqlParameter("@Fax",SqlDbType.VarChar,32),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@QQ",SqlDbType.VarChar,128),
                new SqlParameter("@MSN",SqlDbType.VarChar,128),
                new SqlParameter("@Remark",SqlDbType.VarChar),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@Website",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientName;
            parms[2].Value = data.Address;
            parms[3].Value = data.ZipCode;
            parms[4].Value = data.Linkman;
            parms[5].Value = data.Position;
            parms[6].Value = data.Tel;
            parms[7].Value = data.Mobile;
            parms[8].Value = data.Fax;
            parms[9].Value = data.Email;
            parms[10].Value = data.QQ;
            parms[11].Value = data.MSN;
            parms[12].Value = data.Remark;
            parms[13].Value = data.SourceID;
            parms[14].Value = data.TradeID;
            parms[15].Value = data.AreaID;
            parms[16].Value = data.ClientInfoID;
            parms[17].Value = data.Website;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientInfoS_Update", parms, out ReturnValue);
            if (ReturnValue > 0)//修改成功
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 批量删除名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-21</remarks>
        public bool Delete(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar)
                
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.ClientInfoIDs;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientInfoS_Delete", parms, out ReturnValue);
            if (ReturnValue > 0)//删除成功
            {
                return true;
            }
            return false;
        }


        #endregion

        #region 名录状态
        /// <summary>
        /// 修改名录状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-13</remarks>
        public bool UpdateStatus(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@WishID",SqlDbType.Int),
                new SqlParameter("@TradedMoney",SqlDbType.Money),
                new SqlParameter("@NotTradedID",SqlDbType.Int),
                new SqlParameter("@ScrapID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@TeamID",SqlDbType.Int)
                
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = (int)data.Status;
            parms[3].Value = data.EPUserTMRID;
            parms[4].Value = data.WishID;
            parms[5].Value = data.TradedMoney;
            parms[6].Value = data.NotTradedID;
            parms[7].Value = data.ScrapID;
            parms[8].Value = (int)data.Mode;
            parms[9].Value = data.TeamID;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientItemS_UpdateStatus", parms, out ReturnValue);
            if (ReturnValue > 0)//修改成功
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改名录位置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateMode(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int)
                
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoIDs;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            parms[4].Value = data.EPUserTMRID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientItemS_UpdateMode", parms, out ReturnValue);
            if (ReturnValue > 0)//修改成功
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取状态列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-14</remarks>
        public DataTable GetStatusList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_StatusLogS_Select", parms);
        }

        /// <summary>
        /// 将名录转为自己所用
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-18</remarks>
        public bool ShiftShare(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@CurMode",SqlDbType.TinyInt),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoIDs;
            parms[2].Value = data.EPUserTMRID;
            parms[3].Value = (int)EnumClientMode.共享;
            parms[4].Value = (int)EnumClientMode.业务员;
            parms[5].Value = (int)EnumClientStatus.潜在客户;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientItemS_UpdateShift", parms, out ReturnValue);
            if (ReturnValue > 0)//转移成功
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 删除某状态下的所有名录（报废、失败、共享）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-06</remarks>
        public bool DeleteAll(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.TeamID;
            parms[3].Value = (int)data.Mode;
            parms[4].Value = (int)data.Status;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientInfoS_DeleteAll", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 共享某状态下的所有名录（报废、失败）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-06</remarks>
        public bool ShareAll(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.TeamID;
            parms[3].Value = (int)data.Mode;
            parms[4].Value = (int)data.Status;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientInfoS_ShareAll", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        #endregion
        #region 数量统计
        /// <summary>
        /// 获取待分配名录数量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-28</remarks>
        public int WaitCount(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            using (SqlDataReader rd = DbHelperSQL.RunProcedure("ProcEP_B_ClientItemS_Statistics", parms))
            {
                rd.Read();
                return Convert.ToInt32(rd[0]);
            }
        }
        #endregion

    }
}
