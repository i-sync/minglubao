using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 意向进展
    /// </summary>
    public class D_Wish:MLMGC.IDAL.Enterprise.I_D_Wish
    {

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(E_Wish data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@WishID",SqlDbType.Int),
                new SqlParameter("@WishName",SqlDbType.NVarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.WishID;
            parms[2].Value = data.WishName;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Wish_Exists", parms, out ReturnValue);
            return ReturnValue == 1;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_Wish data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@WishName",SqlDbType.NVarChar,128),
                new SqlParameter("@WishPercent",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.WishName;
            parms[2].Value = data.WishPercent;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Wish_Insert", parms, out ReturnValue);
            data.WishID = ReturnValue;
            return ReturnValue;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_Wish data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@WishID",SqlDbType.Int),
                new SqlParameter("@WishName",SqlDbType.NVarChar,128),
                new SqlParameter("@WishPercent",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.WishID;
            parms[2].Value = data.WishName;
            parms[3].Value = data.WishPercent;

            int ReturnValue = 0, irowsAffected = 0;
            irowsAffected = DbHelperSQL.RunProcedures("ProcEP_B_Wish_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(E_Wish data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@WishID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.WishID;
            int ReturnValue = 0,irowsAffected=0;
            irowsAffected = DbHelperSQL.RunProcedures("ProcEP_B_Wish_Delete", parms, out ReturnValue);
            return ReturnValue;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Wish GetModel(E_Wish data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@WishID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.WishID;
            DataTable dt=DbHelperSQL.RunProcedureTable("ProcEP_B_Wish_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.WishName = dt.Rows[0]["WishName"].ToString();
                data.WishPercent = int.Parse(dt.Rows[0]["WishPercent"].ToString());
            }
            return data;
        }
        /// <summary>
        ///无分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Wish data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_Wish_ListSelect", parms);
        }
    }
}
