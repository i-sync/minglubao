using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Enterprise;
using MLMGC.IDAL.Enterprise;
using MLMGC.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace MLMGC.DAL.Enterprise
{
    public class D_Log:I_D_Log
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-09</remarks>
        public bool Add(E_Log data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@LogTitle",SqlDbType.VarChar,512),
                new SqlParameter("@IP",SqlDbType.VarChar,64)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.LogTitle;
            parms[3].Value = data.IP;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_Log_Insert", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 查看日志列表 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-09</remarks>
        public DataTable GetList(E_Log data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.Page.StartDate;
            parms[3].Value = data.Page.EndDate;
            parms[4].Value = data.Page.PageIndex;
            parms[5].Value = data.Page.PageSize;
            parms[6].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_LogS_ListSelect", parms);
            if (dt != null)
            {
                data.Page.TotalCount = Convert.ToInt32(parms[6].Value);
            }
            return dt;
        }

        /// <summary>
        /// 删除指定日期之前的日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-09</remarks>
        public bool Delete(E_Log data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@Type",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.Type;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_Log_Delete", parms, out ReturnValue);
            return ReturnValue >= 0;
        }
    }
}
