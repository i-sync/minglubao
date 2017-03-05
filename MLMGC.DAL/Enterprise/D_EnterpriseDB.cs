using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DBUtility;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 企业数据库
    /// </summary>
    public class D_EnterpriseDB:I_D_EnterpriseDB
    {
        /// <summary>
        /// 后台管理员添加数据库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public bool Add(E_EnterpriseDB data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseDBID",SqlDbType.Int),
                new SqlParameter("@DBName",SqlDbType.VarChar,64),
                new SqlParameter("@MaxNum",SqlDbType.Int),
                new SqlParameter("@Path",SqlDbType.VarChar,128)
            };
            parms[0].Direction = ParameterDirection.Output;
            parms[1].Value = data.DBName;
            parms[2].Value = data.MaxNum;
            parms[3].Value = data.Path;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcD_EnterpriseDB_Insert", parms, out ReturnValue);
            data.EnterpriseDBID = parms[0].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[0].Value);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 后台管理员删除数据库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public bool Delete(E_EnterpriseDB data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpirseDBID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseDBID;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcD_EnterpriseDB_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 后台管理员查看最后一条记录
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public E_EnterpriseDB SelectLast()
        {
            E_EnterpriseDB data = null;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcD_EnterpriseDB_SelectLast");
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                data = new E_EnterpriseDB();
                data.EnterpriseDBID = Convert.ToInt32(row["EnterpriseDBID"]);
                data.DBName = row["DBName"].ToString();            
            }
            return data;
        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public E_EnterpriseDB GetModel(E_EnterpriseDB data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseDBID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseDBID;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcD_EnterpriseDB_Select",parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                data.DBName = row["DBName"].ToString();
                data.EnterpriseNum = Convert.ToInt32(row["EnterpriseNum"]);
                data.MaxNum = Convert.ToInt32(row["MaxNum"]);
                return data;
            }
            return null;
        }

        /// <summary>
        /// 后台管理员查看数据库列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public DataTable SelectList(E_EnterpriseDB data)
        {
            SqlParameter[] parms =
            {               
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.Page.PageIndex;
            parms[1].Value = data.Page.PageSize;
            parms[2].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcD_EnterpriseDB_SelectList", parms);
            data.Page.TotalCount = parms[2].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[2].Value);
            return dt;
        }

        /// <summary>
        /// 修改默认数据库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public bool UpdateDefaultFlag(E_EnterpriseDB data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseDBID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseDBID;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcD_EnterpriseDB_UpdateDefaultFlag", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 修改数据库容量（最大容量）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-07</remarks>
        public bool UpdateMaxNum(E_EnterpriseDB data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseDBID",SqlDbType.Int),
                new SqlParameter("@MaxNum",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseDBID;
            parms[1].Value = data.MaxNum;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcD_EnterpriseDB_UpdateMaxNum", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 获取默认库的基本信息
        /// </summary>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-06-01</reamrks>
        public DataTable GetDefault()
        {
            return DbHelperSQL.RunProcedureTable("ProcD_EnterpriseDB_Default");
        }
    }
}
