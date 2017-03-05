using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise.Config;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise.Config
{
    /// <summary>
    /// 企业最低标准
    /// </summary>
    public class D_Standard:MLMGC.IDAL.Enterprise.Config.I_D_Standard
    {
        /// <summary>
        /// 添加或更新最低标准
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks >tianzhenyun 2011-10-18</remarks>
        public bool Update(E_Standard data)
        {
            int rowsAffected = 0;
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {               
                new SqlParameter ("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@NewAmount",SqlDbType.Int),
                new SqlParameter ("@CommAmount",SqlDbType.Int ),
                new SqlParameter ("@TradedAmount",SqlDbType.Int),
                new SqlParameter ("@TradedMoney",SqlDbType.Money)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.NewAmount;
            parms[2].Value = data.CommAmount;
            parms[3].Value = data.TradedAmount;
            parms[4].Value = data.TradedMoney;

            DbHelperSQL.ExecProcedure("ProcEP_B_Standard_Update", parms, out rowsAffected);
            
            return rowsAffected > 0;
        }
        /// <summary>
        /// 得到企业最低标准对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-18</remarks>
        public E_Standard GetModel(E_Standard data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int )
            };
            parms[0].Value = data.EnterpriseID;           
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Standard_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.NewAmount = Convert.ToInt32(dt.Rows[0]["NewAmount"]);
                data.CommAmount = Convert.ToInt32(dt.Rows[0]["CommAmount"]);
                data.TradedAmount = Convert.ToInt32(dt.Rows[0]["TradedAmount"]);
                data.TradedMoney = Convert.ToSingle(dt.Rows[0]["TradedMoney"]);
                return data;
            }
            return null;
        }
    }
}
