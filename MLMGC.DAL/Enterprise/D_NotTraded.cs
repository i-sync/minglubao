using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 失败理由
    /// </summary>
    public class D_NotTraded:MLMGC.IDAL.Enterprise.I_D_NotTraded
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int),
                new SqlParameter("@NotTradedName",SqlDbType.NVarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.NotTradedID;
            parms[2].Value = data.NotTradedName;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_NotTraded_Exists", parms, out ReturnValue);
            return ReturnValue == 1;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@NotTradedName",SqlDbType.NVarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.NotTradedName;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_NotTraded_Insert", parms, out ReturnValue);
            data.NotTradedID = ReturnValue;
            return ReturnValue;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int),
                new SqlParameter("@NotTradedName",SqlDbType.NVarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.NotTradedID;
            parms[2].Value = data.NotTradedName;

            int ReturnValue = 0, irowsAffected = 0;
            irowsAffected = DbHelperSQL.RunProcedures("ProcEP_B_NotTraded_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.NotTradedID;
            int ReturnValue = 0, irowsAffected = 0;
            irowsAffected = DbHelperSQL.RunProcedures("ProcEP_B_NotTraded_Delete", parms, out ReturnValue);
            return ReturnValue;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_NotTraded GetModel(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.NotTradedID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_NotTraded_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.NotTradedName = dt.Rows[0]["NotTradedName"].ToString();
            }
            return data;
        }
        /// <summary>
        ///无分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_NotTraded_ListSelect", parms);
        }
    }
}
