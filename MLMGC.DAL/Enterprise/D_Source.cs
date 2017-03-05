using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 来源属性
    /// </summary>
    public class D_Source:MLMGC.IDAL.Enterprise.I_D_Source
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(E_Source data)
        {
            int ReturnValue;
            SqlParameter[] parameters = {
					new SqlParameter("@SourceID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@SourceCode", SqlDbType.VarChar,16)};
            parameters[0].Value = data.SourceID;
            parameters[1].Value = data.EnterpriseID;
            parameters[2].Value = data.SourceCode;


            DbHelperSQL.RunProcedures("ProcEP_B_Source_Exists", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_Source data)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SourceID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@SourceCode", SqlDbType.VarChar,32),
					new SqlParameter("@SourceName", SqlDbType.VarChar,128),
                    new SqlParameter("@Putin",SqlDbType.Int),
                    new SqlParameter("@Intro",SqlDbType.VarChar,512)
                                        };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = data.EnterpriseID;
            parameters[2].Value = data.SourceCode;
            parameters[3].Value = data.SourceName;
            parameters[4].Value = data.Putin;
            parameters[5].Value = data.Intro;

            DbHelperSQL.RunProcedure("ProcEP_B_Source_Insert", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_Source data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SourceID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@SourceCode", SqlDbType.VarChar,32),
					new SqlParameter("@SourceName", SqlDbType.VarChar,128),
                    new SqlParameter("@Putin",SqlDbType.Int),
                    new SqlParameter("@Intro",SqlDbType.VarChar,512)
                                        };
            parameters[0].Value = data.SourceID;
            parameters[1].Value = data.EnterpriseID;
            parameters[2].Value = data.SourceCode;
            parameters[3].Value = data.SourceName;
            parameters[4].Value = data.Putin;
            parameters[5].Value = data.Intro;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Source_Update", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(E_Source data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SourceID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)};
            parameters[0].Value = data.SourceID;
            parameters[1].Value = data.EnterpriseID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Source_Delete", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Source GetModel(E_Source data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SourceID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)};
            parameters[0].Value = data.SourceID;
            parameters[1].Value = data.EnterpriseID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Source_Select", parameters);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                data.SourceCode = row["SourceCode"].ToString();
                data.SourceName = row["SourceName"].ToString();
                data.Putin = Convert.ToInt32(row["Putin"] == DBNull.Value ? 0 : row["Putin"]);
                data.Intro = row["Intro"].ToString();
                return data;
            }
            return null;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Source data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int)
                                        };
            parameters[0].Value = data.EnterpriseID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Source_ListSelect", parameters);
            return dt;
        }

        /// <summary>
        /// 获取绑定显示的列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetShowList(E_Source data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int),
                    new SqlParameter("@CodeIsValue",SqlDbType.TinyInt)
                                        };
            parameters[0].Value = data.EnterpriseID;
            parameters[1].Value = data.CodeIsValue ? 1 : 2;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_Source_ShowListSelect", parameters);
        }
    }
}
