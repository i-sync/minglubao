using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    public class D_Area:MLMGC.IDAL.Enterprise.I_D_Area
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(E_Area data)
        {
            int ReturnValue;
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@AreaCode", SqlDbType.VarChar,16)};
            parameters[0].Value = data.AreaID;
            parameters[1].Value = data.EnterpriseID;
            parameters[2].Value = data.AreaCode;


            DbHelperSQL.RunProcedures("ProcEP_B_Area_Exists", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_Area data)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@AreaCode", SqlDbType.VarChar,32),
					new SqlParameter("@AreaName", SqlDbType.VarChar,128)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = data.EnterpriseID;
            parameters[2].Value = data.AreaCode;
            parameters[3].Value = data.AreaName;

            DbHelperSQL.RunProcedure("ProcEP_B_Area_Insert", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_Area data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@AreaCode", SqlDbType.VarChar,32),
					new SqlParameter("@AreaName", SqlDbType.VarChar,128)};
            parameters[0].Value = data.AreaID;
            parameters[1].Value = data.EnterpriseID;
            parameters[2].Value = data.AreaCode;
            parameters[3].Value = data.AreaName;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Area_Update", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(E_Area data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)};
            parameters[0].Value = data.AreaID;
            parameters[1].Value = data.EnterpriseID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Area_Delete", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Area GetModel(E_Area data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)};
            parameters[0].Value = data.AreaID;
            parameters[1].Value = data.EnterpriseID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Area_Select", parameters);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.AreaCode = dt.Rows[0]["AreaCode"].ToString();
                data.AreaName = dt.Rows[0]["AreaName"].ToString();
                return data;
            }
            return null;
        }
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetPageList(E_Area data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int),
                    new SqlParameter("@PageSize",SqlDbType.Int),
                    new SqlParameter("@PageIndex",SqlDbType.Int),
                    new SqlParameter("@TotalCount",SqlDbType.Int)
                                        };
            parameters[0].Value = data.EnterpriseID;
            parameters[1].Value = data.Page.PageSize;
            parameters[2].Value = data.Page.PageIndex;
            parameters[3].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Area_PageSelect", parameters);
            data.Page.TotalCount = parameters[3].Value == DBNull.Value ? 0 : Convert.ToInt32(parameters[3].Value);
            return dt;
        }
        /// <summary>
        /// 获取绑定显示的列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetShowList(E_Area data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int),
                    new SqlParameter("@CodeIsValue",SqlDbType.TinyInt)
                                        };
            parameters[0].Value = data.EnterpriseID;
            parameters[1].Value = data.CodeIsValue ? 1 : 2;

            return DbHelperSQL.RunProcedureTable("ProcEP_B_Area_ShowListSelect", parameters);
        }
    }
}
