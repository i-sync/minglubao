using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 报废理由
    /// </summary>
    public class D_Scrap:MLMGC.IDAL.Enterprise.I_D_Scrap
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(E_Scrap data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ScrapID",SqlDbType.Int),
                new SqlParameter("@ScrapName",SqlDbType.NVarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ScrapID;
            parms[2].Value = data.ScrapName;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Scrap_Exists", parms, out ReturnValue);
            return ReturnValue == 1;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_Scrap data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ScrapName",SqlDbType.NVarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ScrapName;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Scrap_Insert", parms, out ReturnValue);
            data.ScrapID= ReturnValue;
            return ReturnValue;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_Scrap data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ScrapID",SqlDbType.Int),
                new SqlParameter("@ScrapName",SqlDbType.NVarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ScrapID;
            parms[2].Value = data.ScrapName;

            int ReturnValue = 0, irowsAffected = 0;
            irowsAffected = DbHelperSQL.RunProcedures("ProcEP_B_Scrap_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(E_Scrap data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ScrapID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ScrapID;
            int ReturnValue = 0, irowsAffected = 0;
            irowsAffected = DbHelperSQL.RunProcedures("ProcEP_B_Scrap_Delete", parms, out ReturnValue);
            return ReturnValue;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Scrap GetModel(E_Scrap data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ScrapID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ScrapID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Scrap_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.ScrapName = dt.Rows[0]["ScrapName"].ToString();
            }
            return data;
        }
        /// <summary>
        ///无分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Scrap data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_Scrap_ListSelect", parms);
        }
    }
}
