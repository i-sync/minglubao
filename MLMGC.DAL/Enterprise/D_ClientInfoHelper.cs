using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DBUtility;
using MLMGC.COMP;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 名录管理 帮助操作
    /// </summary>
    public class D_ClientInfoHelper:MLMGC.IDAL.Enterprise.I_D_ClientInfoHelper
    {
        /// <summary>
        /// 判断电话和手机是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-09</remarks>
        public DataTable ExistsContact(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@Type",SqlDbType.TinyInt),
                new SqlParameter("@Value",SqlDbType.VarChar,16)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.Type;
            parms[3].Value = data.Value;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfos_ExistsContact", parms);
        }

        /// <summary>
        /// 预约
        /// </summary>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-07</remarks>
        public bool Reservation(E_Reservation data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@ReservationDate",SqlDbType.SmallDateTime),
                new SqlParameter("@AdvanceMinute",SqlDbType.TinyInt),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@ReType",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.ReservationDate;
            parms[3].Value = data.AdvanceMinute;
            parms[4].Value = data.EPUserTMRID;
            parms[5].Value = (int)data.ReservationType;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Reservation_Insert", parms, out ReturnValue);
            
            return ReturnValue>0;
        }

        /// <summary>
        /// 查询预约列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        public DataTable GetReservationList(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.Page.StartDate;
            parms[3].Value = data.Page.EndDate;
            parms[4].Value = data.Page.PageIndex;
            parms[5].Value = data.Page.PageSize;
            parms[6].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ReservationS_ListSelect", parms);
            data.Page.TotalCount = parms[6].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[6].Value);
            return dt;
        }
        /// <summary>
        /// 获取窗口提醒名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-23</remarks>
        public DataTable GetReservationNow(E_Reservation data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@NotClientInfoIDs",SqlDbType.NVarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.ClientInfoIDs;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ReservationS_NowSelect", parms);
        }

        /// <summary>
        /// 删除预约名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        public bool DeleteReservation(E_Reservation data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@ReservationID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.ReservationID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_Reservation_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 获取指定名录上一个、下一个
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-08</remarks>
        public DataTable PrevNext(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@IsReservation",SqlDbType.Bit)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.ClientInfoID;
            parms[3].Value = data.Status;
            parms[4].Value =Convert.ToUInt16(data.IsReservation);
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_PrevNext", parms);
        }
        /// <summary>
        /// 获取邮箱/手机 列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-08</remarks>
        public DataTable SelectOperate(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoIDs;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_SelectOperate", parms);
        }
        /// <summary>
        /// 获取按属性对比
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Flag">source/area/trade</param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-10</remarks>
        public DataTable ComparisonProperty(E_ClientInfoHelper data,string Flag)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@Flag",SqlDbType.NVarChar,6),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = Flag;
            parms[3].Value = data.Page.StartDate;
            parms[4].Value = data.Page.EndDate;

            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_ComparisonProperty", parms);
        }
        /// <summary>
        /// 按Team对比
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-11</remarks>
        public DataTable ComparisonTeam(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@TeamModelRoleID",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.TeamID;
            parms[3].Value = data.TeamModelRoleID;
            parms[4].Value = data.Page.StartDate;
            parms[5].Value = data.Page.EndDate;

            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfos_ComparisonTeam", parms);
        }
        /// <summary>
        /// 按销售人员对比
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-10</remarks>
        public DataTable ComparisonSalesman(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.TeamID;
            parms[3].Value = data.Page.StartDate;
            parms[4].Value = data.Page.EndDate;

            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfos_ComparisonUser", parms);
        }

        /// <summary>
        /// 按时间对比
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-11</remarks>
        public DataTable ComparisonDate(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Flag",SqlDbType.NVarChar,6)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = data.Flag;

            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfos_ComparisonDate", parms);
        }
        /// <summary>
        /// 获取某一管理者所管理的所有管理角色信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-11</remarks>
        public DataTable GetLeaderRole(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;

            return DbHelperSQL.RunProcedureTable("ProcEP_R_TeamModelRoleS_GetIsLeader", parms);
        }

        /// <summary>
        /// 根据关键字查询企业中所有名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-23</remarks>
        public DataTable GetClientInfoList(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@Keyword",SqlDbType.VarChar),
                new SqlParameter("@Fields",SqlDbType .VarChar),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = data.EPUserTMRID;
            parms[3].Value = data.Keyword;
            parms[4].Value = data.Fields;
            parms[5].Value = (int)data.Property.SourceFlag;
            parms[6].Value = (int)data.Property.AreaFlag;
            parms[7].Value = (int)data.Property.TradeFlag;
            parms[8].Value = data.SourceID;
            parms[9].Value = data.AreaID;
            parms[10].Value = data.TradeID;
            parms[11].Value = data.Page.PageSize;
            parms[12].Value = data.Page.PageIndex;
            parms[13].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfo_ListSelect", parms);
            data.Page.TotalCount = parms[13].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[13].Value);
            return dt;
        }

        /// <summary>
        /// 把报废或失败的名录上报给上级
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-28</remarks>
        public bool Report(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoIDs;
            parms[2].Value = data.TeamID;
            parms[3].Value = data.EPUserTMRID;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientItemS_Report", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 查看录入人员录入名录统计信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-06</remarks>
        public DataTable GetInputStatistics(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_InputStatisticsSelect", parms);
        }

        /// <summary>
        /// 业务锁定或解锁名录:1=锁定，0=解锁
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-1-4</remarks>
        public bool IsLock(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@IsLock",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoIDs;
            parms[2].Value = data.EPUserTMRID;
            parms[3].Value = data.IsLock;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientItem_Lock", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 管理员查看已删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remraks>tianzhenyun 2012-02-14</remraks>
        public DataTable LeaderDeleteSelect(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientName;
            parms[2].Value = data.Page.StartDate;
            parms[3].Value = data.Page.EndDate;
            parms[4].Value = data.Page.PageSize;
            parms[5].Value = data.Page.PageIndex;
            parms[6].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_LeaderDeleteSelect", parms);
            data.Page.TotalCount = parms[6].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[6].Value);
            return dt;
        }

        /// <summary>
        /// 管理员还原删除的客户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-14</remarks>
        public bool LeaderRestore(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar),
                new SqlParameter("@Mode",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter ("@EPUserTMRID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoIDs;
            parms[2].Value = (int)data.Mode;
            parms[3].Value = (int)data.Status;
            parms[4].Value = data.EPUserTMRID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientInfoS_LeaderRestore", parms, out ReturnValue);
            return ReturnValue > 0;//修改成功
        }

        /// <summary>
        /// 彻底删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-15</remarks>
        public bool LeaderThoroughDelete(E_ClientInfoHelper data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoIDs;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientInfoS_ThoroughDelete", parms, out ReturnValue);
            return ReturnValue > 0;//修改成功
        }
    }
}
