using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.DataEntity.Personal;
using MLMGC.IDAL.Personal;

namespace MLMGC.DAL.Personal
{
    public class D_Weibo:I_D_Weibo
    {
        /// <summary>
        /// 发布微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public bool Add(E_Weibo data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@Detail",SqlDbType.VarChar,512),
                new SqlParameter("@AddDate",SqlDbType.SmallDateTime)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.Detail;
            parms[2].Value = data.AddDate;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_WeiboS_Insert", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.WeiboID = Convert.ToInt32(dt.Rows[0]["WeiboID"].ToString());
                data.Detail = dt.Rows[0]["Detail"].ToString();
                data.AddDate = Convert.ToDateTime(dt.Rows[0]["AddDate"].ToString());
                data.RealName = dt.Rows[0]["RealName"].ToString();
                data.Avatar = dt.Rows[0]["Avatar"].ToString();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public DataTable GetList(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.Page.PageSize;
            parms[1].Value = data.Page.PageIndex;
            parms[2].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_WeiboS_Select", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[2].Value) ? "0" : parms[2].Value);
            return dt;
        }

        /// <summary>
        /// 获取新微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public DataTable GetNewList(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WeiboID",SqlDbType.Int)
            };
            parms[0].Value = data.WeiboID;
            return DbHelperSQL.RunProcedureTable("ProcPI_B_WeiboS_SelectNew", parms);
        }
        /// <summary>
        /// 获取首页显示微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public DataTable GetMainList(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WeiboID",SqlDbType.Int),
                new SqlParameter("@Count",SqlDbType.Int)
            };
            parms[0].Value = data.WeiboID;
            parms[1].Value = data.Count;
            return DbHelperSQL.RunProcedureTable("ProcPI_B_WeiboS_SelectTop",parms);
        }

        /// <summary>
        /// 个人用户获取自己的微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        public DataTable SelfList(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.Page.PageSize;
            parms[2].Value = data.Page.PageIndex;
            parms[3].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_WeiboS_SelectList", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[3].Value) ? "0" : parms[3].Value);
            return dt;
        }

        /// <summary>
        /// 个人用户删除自己发布的微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        public bool Delete(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@WeiboID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.WeiboID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcPI_B_WeiboS_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 个人微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-21</remarks>
        public DataTable List(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@WeiboID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.WeiboID;
            parms[2].Value = data.Page.PageSize;
            parms[3].Value = data.Page.PageIndex;
            parms[4].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_WeiboS_List", parms);
            data.Page.TotalCount = parms[4].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[4].Value);
            return dt;
        }

        /// <summary>
        /// 后台管理员查看所有个人微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-08</remarks>
        public DataTable AdminList(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@Detail",SqlDbType.NVarChar,512),
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.Detail;
            parms[1].Value = data.PersonalID;
            parms[2].Value = data.Page.PageSize;
            parms[3].Value = data.Page.PageIndex;
            parms[4].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_WeiboS_AdminSelectList", parms);
            data.Page.TotalCount = parms[4].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[4].Value);
            return dt;
        }

        /// <summary>
        /// 后台管理员删除个人微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-08</remarks>
        public bool AdminDelete(E_Weibo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WeiboIDs",SqlDbType.NVarChar)
            };
            parms[0].Value = data.WeiboIDs;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcPI_B_WeiboS_AdminDelete", parms, out ReturnValue);
            return ReturnValue > 0;
        }
    }
}
