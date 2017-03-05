using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.DataEntity.Personal.Config;

namespace MLMGC.DAL.Personal.Config
{
    /// <summary>
    /// 来源属性
    /// </summary>
    public class D_Source : MLMGC.IDAL.Personal.Config.I_D_Source
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public bool Exists(E_Source data)
        {
            int ReturnValue;
            SqlParameter[] parameters = {
					new SqlParameter("@SourceID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4),
					new SqlParameter("@SourceName", SqlDbType.VarChar,128)};
            parameters[0].Value = data.SourceID;
            parameters[1].Value = data.PersonalID;
            parameters[2].Value = data.SourceName;


            DbHelperSQL.RunProcedures("ProcPI_B_Source_Exists", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public int Add(E_Source data)
        {
            int rowsAffected;
            SqlParameter[] parameters = 
            {
			    new SqlParameter("@SourceID", SqlDbType.Int,4),
			    new SqlParameter("@PersonalID", SqlDbType.Int,4),
			    new SqlParameter("@SourceCode", SqlDbType.VarChar,32),
			    new SqlParameter("@SourceName", SqlDbType.VarChar,128),
                new SqlParameter("@Putin",SqlDbType.Int),
                new SqlParameter("@Intro",SqlDbType.VarChar,512)
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = data.PersonalID;
            parameters[2].Value = data.SourceCode;
            parameters[3].Value = data.SourceName;
            parameters[4].Value = data.Putin;
            parameters[5].Value = data.Intro;

            DbHelperSQL.RunProcedure("ProcPI_B_Source_Insert", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
        /// <summary>
        /// 批量增加来源
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        public bool BatchAdd(E_Source data)
        {
            SqlParameter[] parms = 
            {
			    new SqlParameter("@PersonalID", SqlDbType.Int,4),
			    new SqlParameter("@Child_SourceCode", SqlDbType.NVarChar),
			    new SqlParameter("@Child_SourceName", SqlDbType.NVarChar),
                new SqlParameter("@Separation", SqlDbType.VarChar,2)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.SourceCodeS;
            parms[2].Value = data.SourceNameS;
            parms[3].Value = MLMGC.COMP.Config.Separation;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_Source_BatchInsert", parms, out ReturnValue);
            return ReturnValue>0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public bool Update(E_Source data)
        {
            SqlParameter[] parameters = 
            {
				new SqlParameter("@SourceID", SqlDbType.Int,4),
				new SqlParameter("@PersonalID", SqlDbType.Int,4),
				new SqlParameter("@SourceCode", SqlDbType.VarChar,32),
				new SqlParameter("@SourceName", SqlDbType.VarChar,128),
                new SqlParameter("@Putin",SqlDbType.Int),
                new SqlParameter("@Intro",SqlDbType.VarChar,512)
            };
            parameters[0].Value = data.SourceID;
            parameters[1].Value = data.PersonalID;
            parameters[2].Value = data.SourceCode;
            parameters[3].Value = data.SourceName;
            parameters[4].Value = data.Putin;
            parameters[5].Value = data.Intro;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_Source_Update", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public bool Delete(E_Source data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SourceID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4)};
            parameters[0].Value = data.SourceID;
            parameters[1].Value = data.PersonalID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_Source_Delete", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public E_Source GetModel(E_Source data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SourceID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4)};
            parameters[0].Value = data.SourceID;
            parameters[1].Value = data.PersonalID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_Source_Select", parameters);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.SourceCode = dt.Rows[0]["SourceCode"].ToString();
                data.SourceName = dt.Rows[0]["SourceName"].ToString();
                data.Putin = Convert.ToInt32(dt.Rows[0]["Putin"]);
                data.Intro = dt.Rows[0]["Intro"].ToString();
                return data;
            }
            return null;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public DataTable GetList(E_Source data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PersonalID", SqlDbType.Int)
                                        };
            parameters[0].Value = data.PersonalID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_Source_ListSelect", parameters);
            return dt;
        }

        /// <summary>
        /// 获取绑定显示的列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public DataTable GetShowList(E_Source data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PersonalID", SqlDbType.Int),
                    new SqlParameter("@CodeIsValue",SqlDbType.TinyInt)
                                        };
            parameters[0].Value = data.PersonalID;
            parameters[1].Value = data.CodeIsValue ? 1 : 2;
            return DbHelperSQL.RunProcedureTable("ProcPI_B_Source_ShowListSelect", parameters);
        }
    }
}
