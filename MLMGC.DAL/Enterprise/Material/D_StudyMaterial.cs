using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Enterprise.Material;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise.Material
{
    /// <summary>
    /// 学习资料
    /// </summary>
    public class D_StudyMaterial:MLMGC.IDAL.Enterprise.Material.I_D_StudyMaterial
    {
        /// <summary>
        /// 增加学习资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks >tianzhenyun 2011-10-13</remarks>
        public bool Add(E_StudyMaterial data)
        {
            int rowsAffected = 0;
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@StudyMaterialID",SqlDbType.BigInt),
                new SqlParameter ("@EnterpriseID",SqlDbType .Int ,4),
                new SqlParameter ("@MaterialName",SqlDbType .VarChar ,128),
                new SqlParameter ("@FileName",SqlDbType .VarChar ,128),
                new SqlParameter ("@Url",SqlDbType .VarChar,128),
                new SqlParameter ("@FileType",SqlDbType .VarChar,16),
                new SqlParameter ("@FileSize",SqlDbType .Int )
            };
            parms[0].Direction = ParameterDirection.Output;
            parms[1].Value = data.EnterpriseID;
            parms[2].Value = data.MaterialName;
            parms[3].Value = data.StudyMateFile.FileName;
            parms[4].Value = data.StudyMateFile.Url;
            parms[5].Value = data.StudyMateFile.FileType;
            parms[6].Value = data.StudyMateFile.FileSize;

            DbHelperSQL.ExecProcedure("ProcEP_B_StudyMaterialS_Insert", parms, out rowsAffected);
            data.StudyMaterialID = Convert.ToInt32(parms[0].Value);

            return rowsAffected > 0;
        }
        /// <summary>
        /// 更新学习资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-12</remarks>
        public bool Update(E_StudyMaterial data)
        {
            int rowsAffected = 0;
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@StudyMaterialID",SqlDbType.BigInt),
                new SqlParameter ("@EnterpriseID",SqlDbType .Int ,4),
                new SqlParameter ("@MaterialName",SqlDbType .VarChar ,128),
                new SqlParameter ("@FileName",SqlDbType .VarChar ,128),
                new SqlParameter ("@Url",SqlDbType .VarChar,128),
                new SqlParameter ("@FileType",SqlDbType .VarChar,16),
                new SqlParameter ("@FileSize",SqlDbType .Int )
            };
            parms[0].Value = data.StudyMaterialID;
            parms[1].Value = data.EnterpriseID;
            parms[2].Value = data.MaterialName;
            parms[3].Value = data.StudyMateFile.FileName;
            parms[4].Value = data.StudyMateFile.Url;
            parms[5].Value = data.StudyMateFile.FileType;
            parms[6].Value = data.StudyMateFile.FileSize;

            DbHelperSQL.ExecProcedure("ProcEP_B_StudyMaterialS_Update", parms, out rowsAffected);

            return rowsAffected > 0;
        }
        /// <summary>
        /// 删除学习资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Delete(E_StudyMaterial data)
        {
            int rowsAffected = 0;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@StudyMaterialID",SqlDbType .Int ),
                new SqlParameter("@EnterpriseID",SqlDbType .Int )
            };
            parms[0].Value = data.StudyMaterialID;
            parms[1].Value = data.EnterpriseID;
            DbHelperSQL.ExecProcedure("ProcEP_B_StudyMaterialS_Delete", parms, out rowsAffected);

            return rowsAffected > 0;
        }
        /// <summary>
        /// 得到一个学习资料对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_StudyMaterial GetModel(E_StudyMaterial data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@StudyMaterialID",SqlDbType .Int ),
                new SqlParameter("@EnterpriseID",SqlDbType .Int )
            };
            parms[0].Value = data.StudyMaterialID;
            parms[1].Value = data.EnterpriseID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_StudyMaterialS_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.MaterialName = dt.Rows[0]["MaterialName"].ToString();
                data.StudyMateFile = new E_StudyMateFile();
                data.StudyMateFile.FileName = dt.Rows[0]["FileName"].ToString();
                data.StudyMateFile.Url = dt.Rows[0]["Url"].ToString();
                data.StudyMateFile.FileSize = Convert.ToInt32(dt.Rows[0]["FileSize"]);
                data.StudyMateFile.FileType = dt.Rows[0]["FileType"].ToString();
                return data;
            }
            return null;
        }
        /// <summary>
        /// 获取学习资料列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_StudyMaterial data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@PageIndex",SqlDbType .Int),
                new SqlParameter ("@PageSize",SqlDbType .Int),
                new SqlParameter ("@TotalCount",SqlDbType .Int),
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.Page.PageIndex;
            parms[2].Value = data.Page.PageSize;
            parms[3].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_StudyMaterialS_ListSelect", parms);
            data.Page.TotalCount = parms[3].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[3].Value);
            return dt;
        }
    }
}
