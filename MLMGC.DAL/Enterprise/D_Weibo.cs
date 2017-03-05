using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.IDAL.Enterprise;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 微博
    /// </summary>
    public class D_Weibo:I_D_Weibo
    {
        /// <summary>
        /// 发布微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-05</remarks>
        public bool Add(E_Weibo data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Detail",SqlDbType.VarChar,512),
                new SqlParameter("@AddDate",SqlDbType.SmallDateTime)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.Detail;
            parms[3].Value = data.AddDate;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Weibo_Insert", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.WeiboID = Convert.ToInt32(dt.Rows[0]["WeiboID"].ToString());
                data.Detail = dt.Rows[0]["Detail"].ToString();
                data.AddDate = Convert.ToDateTime(dt.Rows[0]["AddDate"].ToString());
                data.TrueName = dt.Rows[0]["TrueName"].ToString();
                data.Avatar = dt.Rows[0]["Avatar"].ToString();
                return true;
            }
            return false;
            //data.WeiboID = ReturnValue;
            //return ReturnValue > 0;
        }
        /// <summary>
        /// 获取微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2012-01-06</remarks>
        public DataTable GetList(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.Page.PageSize;
            parms[2].Value = data.Page.PageIndex;
            parms[3].Value = 0;
            parms[3].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_WeiboS_Select", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[3].Value) ? "0" : parms[3].Value);
            return dt;
        }

        /// <summary>
        /// 获取新微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-01-06</remarks>
        public DataTable GetNewList(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@WeiboID",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.WeiboID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_WeiboS_SelectNew", parms);
        }
        /// <summary>
        /// 获取首页显示微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2012-01-07</remarks>
        public DataTable GetMainList(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_WeiboS_SelectTop", parms);
        }

        /// <summary>
        /// 企业用户获取自己的微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        public DataTable SelfList(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.Page.PageSize;
            parms[3].Value = data.Page.PageIndex;
            parms[4].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_WeiboS_SelectList", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[4].Value) ? "0" : parms[4].Value);
            return dt;
        }

        /// <summary>
        /// 企业用户删除自己发布的微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        public bool Delete(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter ("@UserID",SqlDbType.Int),
                new SqlParameter("@WeiboID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.WeiboID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_Weibo_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }
    }
}
