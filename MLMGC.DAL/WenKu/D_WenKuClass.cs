using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.WenKu;
using MLMGC.IDAL.WenKu;
using MLMGC.DBUtility;

namespace MLMGC.DAL.WenKu
{
    /// <summary>
    /// 文库分类
    /// </summary>
    public class D_WenKuClass:I_D_WenKuClass
    {

        /// <summary>
        /// 添加文库分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public bool Add(E_WenKuClass data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WenKuClassName",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.WenKuClassName;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_WenKuClass_Insert", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 修改文库分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public bool Update(E_WenKuClass data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WenKuClassID",SqlDbType.Int),
                new SqlParameter("@WenKuClassName",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.WenKuClassID;
            parms[1].Value = data.WenKuClassName;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_WenKuClass_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 添加文库分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public bool Delete(E_WenKuClass data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WenKuClassID",SqlDbType.Int)
            };
            parms[0].Value = data.WenKuClassID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_WenKuClass_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 查询文库分类对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public E_WenKuClass GetModel(E_WenKuClass data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WenKuClassID",SqlDbType.Int)
            };
            parms[0].Value = data.WenKuClassID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcB_WenKuClass_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.WenKuClassName = dt.Rows[0]["WenKuClassName"].ToString();
                return data;
            }
            return null;
        }

        /// <summary>
        /// 获取所有文库分类
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public DataTable GetList()
        {
            return DbHelperSQL.RunProcedureTable("ProcB_WenKuClass_List");
        }
    }
}
