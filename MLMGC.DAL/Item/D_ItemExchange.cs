using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Item;
using MLMGC.IDAL.Item;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Item
{
    /// <summary>
    /// 沟通记录
    /// </summary>
    public class D_ItemExchange :I_D_ItemExchange
    {
        /// <summary>
        /// 添加沟通记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public E_ItemExchange Add(E_ItemExchange data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Detail",SqlDbType.NVarChar,512)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.UserID;
            parms[3].Value = data.Detail;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemExchange_Insert", parms);
            if (dt != null && dt.Rows.Count == 1)
            { 
                DataRow row = dt.Rows[0];
                data.ClientInfoID = Convert.ToInt32(row["ClientInfoID"]);
                data.Detail = row["Detail"].ToString();
                data.AddDate = Convert.ToDateTime(row["AddDate"]);
                data.RealName = row["RealName"].ToString();
                return data;
            }
            return null;
        }

        /// <summary>
        /// 获取沟通记录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable GetList(E_ItemExchange data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ItemExchange_ListSelect", parms);
        }
    }
}
