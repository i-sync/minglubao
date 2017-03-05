using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;


namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 名录沟通记录
    /// </summary>
    public class D_Exchange : MLMGC.IDAL.Enterprise.I_D_Exchange
    {
        /// <summary>
        /// 录入新沟通记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-14</remarks>
        public bool Add(E_Exchange data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@Detail",SqlDbType.NVarChar,512),
                new SqlParameter("@ExchangeDate",SqlDbType.DateTime),
                new SqlParameter("@ReturnValue",SqlDbType.Int, 4, ParameterDirection.ReturnValue,false, 0, 0, string.Empty, DataRowVersion.Default, null)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.EPUserTMRID;
            parms[3].Value = data.Detail;
            parms[4].Value = Convert.ToDateTime(data.ExchangeDate).ToString("yyyy-MM-dd HH:mm:ss");
            string returnValue = "";
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ExchangeS_Insert", parms, parms.Length - 1, ref returnValue);
            if (returnValue.Equals("0"))
            {
                return false;
            }
            if (dt != null && dt.Rows.Count == 1)//判断是否录入成功
            {
                data.Detail = dt.Rows[0]["Detail"].ToString();
                data.ExchangeDate = Convert.ToDateTime(dt.Rows[0]["ExchangeDate"]);
                data.UserInfo = dt.Rows[0]["UserInfo"].ToString();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取名录下的沟通列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-14</remarks>
        public DataTable GetList(E_Exchange data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_Exchange_Select", parms);
        }
    }
}
