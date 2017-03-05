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
    /// 地区属性设置
    /// </summary>
    public class D_Area : MLMGC.IDAL.Personal.Config.I_D_Area
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public bool Exists(E_Area data)
        {
            int ReturnValue;
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4),
					new SqlParameter("@AreaName", SqlDbType.VarChar,128)};
            parameters[0].Value = data.AreaID;
            parameters[1].Value = data.PersonalID;
            parameters[2].Value = data.AreaName;


            DbHelperSQL.RunProcedures("ProcPI_B_Area_Exists", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public int Add(E_Area data)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4),
					new SqlParameter("@AreaCode", SqlDbType.VarChar,32),
					new SqlParameter("@AreaName", SqlDbType.VarChar,128)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = data.PersonalID;
            parameters[2].Value = data.AreaCode;
            parameters[3].Value = data.AreaName;

            DbHelperSQL.RunProcedure("ProcPI_B_Area_Insert", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
        /// <summary>
        /// 批量增加地区
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        public bool BatchAdd(E_Area data)
        {
            SqlParameter[] parms = 
            {
			    new SqlParameter("@PersonalID", SqlDbType.Int,4),
			    new SqlParameter("@Child_AreaCode", SqlDbType.NVarChar),
			    new SqlParameter("@Child_AreaName", SqlDbType.NVarChar),
                new SqlParameter("@Separation", SqlDbType.VarChar,2)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.AreaCodeS;
            parms[2].Value = data.AreaNameS;
            parms[3].Value = MLMGC.COMP.Config.Separation;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_Area_BatchInsert", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public bool Update(E_Area data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4),
					new SqlParameter("@AreaCode", SqlDbType.VarChar,32),
					new SqlParameter("@AreaName", SqlDbType.VarChar,128)};
            parameters[0].Value = data.AreaID;
            parameters[1].Value = data.PersonalID;
            parameters[2].Value = data.AreaCode;
            parameters[3].Value = data.AreaName;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_Area_Update", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public bool Delete(E_Area data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4)};
            parameters[0].Value = data.AreaID;
            parameters[1].Value = data.PersonalID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_Area_Delete", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public E_Area GetModel(E_Area data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4)};
            parameters[0].Value = data.AreaID;
            parameters[1].Value = data.PersonalID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_Area_Select", parameters);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.AreaCode = dt.Rows[0]["AreaCode"].ToString();
                data.AreaName = dt.Rows[0]["AreaName"].ToString();
                return data;
            }
            return null;
        }
        /// <summary>
        /// 获取地区列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public DataTable GetPageList(E_Area data)
        {
            SqlParameter[] parameters = 
            {
				new SqlParameter("@PersonalID", SqlDbType.Int)
            };
            parameters[0].Value = data.PersonalID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_Area_ListSelect", parameters);            
            return dt;
        }
        /// <summary>
        /// 获取绑定显示的列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public DataTable GetShowList(E_Area data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PersonalID", SqlDbType.Int),
                    new SqlParameter("@CodeIsValue",SqlDbType.TinyInt)
                                        };
            parameters[0].Value = data.PersonalID;
            parameters[1].Value = data.CodeIsValue ? 1 : 2;

            return DbHelperSQL.RunProcedureTable("ProcPI_B_Area_ShowListSelect", parameters);
        }
    }
}
