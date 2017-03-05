using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.DataEntity.Enterprise.Plan;
using MLMGC.IDAL.Enterprise.Plan;

namespace MLMGC.DAL.Enterprise.Plan
{
    /// <summary>
    /// 个人计划
    /// </summary>
    public class D_UserPlan:I_D_UserPlan
    {
        /// <summary>
        /// 修改或添加个人计划
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-01</remarks>
        public bool Update(E_UserPlan data)
        {
            int ReturnValue;
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int),
                new SqlParameter("@EPUserTMRID",SqlDbType .Int),
                new SqlParameter("@YearMonth",SqlDbType .SmallDateTime),
                new SqlParameter("@NewAmount",SqlDbType.Int),
                new SqlParameter("@ContactAmount",SqlDbType.Int),
                new SqlParameter("@TradedAmount",SqlDbType.Int),
                new SqlParameter("@TradedMoney",SqlDbType.Money)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.YearMonty;
            parms[3].Value = data.NewAmount;
            parms[4].Value = data.ContactAmount;
            parms[5].Value = data.TradedAmount;
            parms[6].Value = data.TradedMoney;

            DbHelperSQL.RunProcedures("ProcEP_B_UserPlan_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 查询个人计划
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-01</remarks>
        public E_UserPlan GetModel(E_UserPlan data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int),
                new SqlParameter("@EPUserTMRID",SqlDbType .Int),
                new SqlParameter("@YearMonth",SqlDbType .SmallDateTime)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.YearMonty;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_UserPlan_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.NewAmount = Convert.ToInt32(dt.Rows[0]["NewAmount"]);
                data.ContactAmount = Convert.ToInt32(dt.Rows[0]["ContactAmount"]);
                data.TradedAmount = Convert.ToInt32(dt.Rows[0]["TradedAmount"]);
                data.TradedMoney = Convert.ToSingle(dt.Rows[0]["TradedMoney"]);
                return data;
            }
            return null;
        }
        /// <summary>
        /// 获取用户指定天的数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-09</remarks>
        public DataTable UserDaily(E_UserPlan data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int),
                new SqlParameter("@EPUserTMRID",SqlDbType .Int),
                new SqlParameter("@Date",SqlDbType .SmallDateTime)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.YearMonty;

            return DbHelperSQL.RunProcedureTable("ProcEP_B_UserPlanS_Daily", parms);
        }

        /// <summary>
        /// 获取用户指定月的数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-09</remarks>
        public DataTable UserMonth(E_UserPlan data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int),
                new SqlParameter("@EPUserTMRID",SqlDbType .Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;

            return DbHelperSQL.RunProcedureTable("ProcEP_B_UserPlanS_Month", parms);
        }

        /// <summary>
        /// 获取用户指定月的详细数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-10</remarks>
        public DataTable UserMonthDetail(E_UserPlan data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int),
                new SqlParameter("@EPUserTMRID",SqlDbType .Int),
                new SqlParameter("@YearMonth",SqlDbType.VarChar,8)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.YearMonty.ToString("yyyy/MM", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            return DbHelperSQL.RunProcedureTable("ProcEP_B_UserPlanS_MonthDetail", parms);
        }
    }
}
