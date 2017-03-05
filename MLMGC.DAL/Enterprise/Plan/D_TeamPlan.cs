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
    public class D_TeamPlan:I_D_TeamPlan
    {
        /// <summary>
        /// 修改或添加团队计划
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-01</remarks>
        public bool Update(E_TeamPlan data)
        {
            int ReturnValue;
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int),
                new SqlParameter("@TeamID",SqlDbType .Int),
                new SqlParameter("@YearMonth",SqlDbType .SmallDateTime),
                new SqlParameter("@TradedAmount",SqlDbType.Int),
                new SqlParameter("@TradedMoney",SqlDbType.Money)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = data.YearMonty;
            parms[3].Value = data.TradedAmount;
            parms[4].Value = data.TradedMoney;

            DbHelperSQL.RunProcedures("ProcEP_B_TeamPlan_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 查询团队计划
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-01</remarks>
        public E_TeamPlan GetModel(E_TeamPlan data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int),
                new SqlParameter("@TeamID",SqlDbType .Int),
                new SqlParameter("@YearMonth",SqlDbType .SmallDateTime)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = data.YearMonty;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_TeamPlan_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.TradedAmount = Convert.ToInt32(dt.Rows[0]["TradedAmount"]);
                data.TradedMoney = Convert.ToSingle(dt.Rows[0]["TradedMoney"]);
                return data;
            }
            return null;
        }

        /// <summary>
        /// 获取团队计划数据列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-11</remarks>
        public DataTable GetTeamPlan(E_TeamPlan data)
        { 
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter ("@TeamID",SqlDbType.Int),
                new SqlParameter("@Date",SqlDbType .SmallDateTime)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.TeamID;
            parms[3].Value = data.YearMonty;

            return DbHelperSQL.RunProcedureTable("ProcEP_B_TeamPlanS_PlanDaily", parms);
        }

        /// <summary>
        /// 获取团队实际数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-11</remarks>
        public DataTable GetTeamReal(E_TeamPlan data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType .Int),
                new SqlParameter("@Date",SqlDbType .SmallDateTime)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.TeamID;
            parms[3].Value = data.YearMonty;

            return DbHelperSQL.RunProcedureTable("ProcEP_B_TeamPlanS_RealDaily", parms);
        }

        /// <summary>
        /// 获取团队某月实际数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-11</remarks>
        public DataTable GetTeamRealMonth(E_TeamPlan data)
        { 
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter ("@TeamID",SqlDbType.Int),
                new SqlParameter("@Date",SqlDbType .SmallDateTime)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            parms[2].Value = data.TeamID;
            parms[3].Value = data.YearMonty;

            return DbHelperSQL.RunProcedureTable("ProcEP_B_TeamPlanS_RealMonth", parms);
        }
    }
}
