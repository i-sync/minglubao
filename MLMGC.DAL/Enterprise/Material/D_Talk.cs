using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Material;
using MLMGC.IDAL.Enterprise.Material;
using System.Data.SqlClient;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise.Material
{
    /// <summary>
    /// 企业话术
    /// </summary>
    public class D_Talk:I_D_Talk
    {
        /// <summary>
        /// 新增话术
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-11</remarks>
        public bool Add(E_Talk data)
        {
            int rowsAffected = 0;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@TalkID",SqlDbType .Int ,4),
                new SqlParameter ("@EnterpriseID",SqlDbType .Int ,4),
                new SqlParameter ("@TalkSubject",SqlDbType .VarChar ,128),
                new SqlParameter ("@Detail",SqlDbType .VarChar),
                new SqlParameter("@Sort",SqlDbType.Int)
            };
            parms[0].Direction = ParameterDirection.Output;
            parms[1].Value = data.EnterpriseID;
            parms[2].Value = data.TalkSubject;
            parms[3].Value = data.Detail;
            parms[4].Value = data.Sort;
            DbHelperSQL.RunProcedures("ProcEP_B_Talk_Insert", parms, out rowsAffected);
            data.TalkID = parms[0].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[0].Value);

            return rowsAffected > 0;
        }

        /// <summary>
        /// 更新话术
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-11</remarks>
        public bool Update(E_Talk data)
        {
            int rowsAffected = 0;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@TalkID",SqlDbType .Int ,4),
                new SqlParameter ("@EnterpriseID",SqlDbType .Int ,4),
                new SqlParameter ("@TalkSubject",SqlDbType .VarChar ,128),
                new SqlParameter ("@Detail",SqlDbType .VarChar),
                new SqlParameter ("@Sort",SqlDbType.Int)
            };
            parms[0].Value = data.TalkID;
            parms[1].Value = data.EnterpriseID;
            parms[2].Value = data.TalkSubject;
            parms[3].Value = data.Detail;
            parms[4].Value = data.Sort;
            DbHelperSQL.RunProcedures("ProcEP_B_Talk_Update", parms, out rowsAffected);
            return rowsAffected > 0;
        }

        /// <summary>
        /// 删除话术
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-11</remarks>
        public bool Delete(E_Talk data)
        {
            int rowsAffected = 0;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@TalkID",SqlDbType .Int ,4),
                new SqlParameter("@EnterpriseID",SqlDbType .Int ,4)
            };
            parms[0].Value = data.TalkID;
            parms[1].Value = data.EnterpriseID;
            DbHelperSQL.RunProcedures("ProcEP_B_Talk_Delete", parms, out rowsAffected);

            return rowsAffected > 0;
        }

        /// <summary>
        /// 获取一个实体对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-11</remarks>
        public E_Talk GetModel(E_Talk data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@TalkID",SqlDbType .Int ,4),
                new SqlParameter("@EnterpriseID",SqlDbType .Int ,4)
            };
            parms[0].Value = data.TalkID;
            parms[1].Value = data.EnterpriseID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Talk_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.TalkSubject = dt.Rows[0]["TalkSubject"].ToString();
                data.Detail = dt.Rows[0]["Detail"].ToString();
                data.Sort = Convert.ToInt32(dt.Rows[0]["Sort"]==DBNull.Value?"0":dt.Rows[0]["Sort"]);
                return data;
            }
            return null;
        }

        /// <summary>
        /// 获取话术列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-11</remarks>
        public DataTable GetList(E_Talk data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@EnterpriseID",SqlDbType .Int ,4)
            };
            parms[0].Value = data.EnterpriseID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Talk_ListSelect", parms);
            return dt;
        }
    }
}
