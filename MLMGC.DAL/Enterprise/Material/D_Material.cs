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
    /// 项目资料
    /// </summary>
    public class D_Material:MLMGC.IDAL.Enterprise.Material.I_D_Material
    {
        /// <summary>
        /// 增加项目资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks >tianzhenyun 2011-10-12</remarks>
        public bool Add(E_Material data)
        {
            int rowsAffected = 0;
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@MaterialID",SqlDbType.BigInt),
                new SqlParameter ("@EnterpriseID",SqlDbType .Int ,4),
                new SqlParameter ("@MaterialName",SqlDbType .VarChar ,128),
                new SqlParameter ("@ClassName",SqlDbType .VarChar ,64),
                new SqlParameter ("@FileName",SqlDbType .VarChar ,128),
                new SqlParameter ("@Url",SqlDbType .VarChar,128),
                new SqlParameter ("@FileType",SqlDbType .VarChar,16),
                new SqlParameter ("@FileSize",SqlDbType .Int ),
                new SqlParameter ("@MaterialType",SqlDbType.TinyInt)
            };
            parms[0].Direction = ParameterDirection.Output;
            parms[1].Value = data.EnterpriseID;
            parms[2].Value = data.MaterialName;
            parms[3].Value = data.ClassName;
            parms[4].Value = data.FileName;
            parms[5].Value = data.Url;
            parms[6].Value = data.FileType;
            parms[7].Value = data.FileSize;
            parms[8].Value = (int)data.MaterialType;
            
            DbHelperSQL.ExecProcedure("ProcEP_B_MaterialS_Insert", parms, out rowsAffected);
            data.MaterialID = Convert.ToInt32(parms[0].Value);

            return rowsAffected > 0;
        }
        /// <summary>
        /// 更新项目资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-13</remarks>
        public bool Update(E_Material data)
        {
            int rowsAffected = 0;
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@MaterialID",SqlDbType.BigInt),
                new SqlParameter ("@EnterpriseID",SqlDbType .Int ,4),
                new SqlParameter ("@MaterialName",SqlDbType .VarChar ,128),
                new SqlParameter ("@ClassName",SqlDbType .VarChar ,64),
                new SqlParameter ("@FileName",SqlDbType .VarChar ,128),
                new SqlParameter ("@Url",SqlDbType .VarChar,128),
                new SqlParameter ("@FileType",SqlDbType .VarChar,16),
                new SqlParameter ("@FileSize",SqlDbType .Int )
            };
            parms[0].Value = data.MaterialID;
            parms[1].Value = data.EnterpriseID;
            parms[2].Value = data.MaterialName;
            parms[3].Value = data.ClassName;
            parms[4].Value = data.FileName;
            parms[5].Value = data.Url;
            parms[6].Value = data.FileType;
            parms[7].Value = data.FileSize;

            DbHelperSQL.ExecProcedure("ProcEP_B_MaterialS_Update", parms, out rowsAffected);
            
            return rowsAffected > 0;
        }
        /// <summary>
        /// 删除项目资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-13</remarks>
        public bool Delete(E_Material data)
        {
            int rowsAffected = 0;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@MaterialID",SqlDbType .Int ),
                new SqlParameter("@EnterpriseID",SqlDbType .Int )
            };
            parms[0].Value = data.MaterialID;
            parms[1].Value = data.EnterpriseID;
            DbHelperSQL.ExecProcedure("ProcEP_B_MaterialS_Delete", parms, out rowsAffected);

            return rowsAffected > 0;
        }
        /// <summary>
        /// 得到一个项目资料对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-13</remarks>
        public E_Material GetModel(E_Material data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@MaterialID",SqlDbType .Int ),
                new SqlParameter("@EnterpriseID",SqlDbType .Int )
            };
            parms[0].Value = data.MaterialID;
            parms[1].Value = data.EnterpriseID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_MaterialS_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.MaterialName = dt.Rows[0]["MaterialName"].ToString();
                data.ClassName = dt.Rows[0]["ClassName"].ToString();
                data.FileName = dt.Rows[0]["FileName"].ToString();
                data.Url = dt.Rows[0]["Url"].ToString();
                data.FileType = dt.Rows[0]["FileType"].ToString();
                data.FileSize = Convert.ToInt32(dt.Rows[0]["FileSize"]);
                return data;
            }
            return null;
        }
        /// <summary>
        /// 获取项目资料列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-13</remarks>
        public DataTable GetList(E_Material data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@MaterialType",SqlDbType.TinyInt),
                new SqlParameter ("@PageIndex",SqlDbType .Int),
                new SqlParameter ("@PageSize",SqlDbType .Int),
                new SqlParameter ("@TotalCount",SqlDbType .Int),
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = (int)data.MaterialType;
            parms[2].Value = data.Page.PageIndex;
            parms[3].Value = data.Page.PageSize;
            parms[4].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_MaterialS_ListSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(parms[4].Value==DBNull.Value?0:parms[4].Value);
            return dt;
        }

        /// <summary>
        /// 企业资料共享
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-16</remarks>
        public bool Share(E_Material data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@ID",SqlDbType.BigInt),
                new SqlParameter ("@WenKuFlag",SqlDbType.TinyInt),
                new SqlParameter ("@WenKuID",SqlDbType.BigInt),
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.MaterialID;
            parms[2].Value = (int)data.WenKuFlag;
            parms[3].Value = data.WenKuID;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_WenKu_Share", parms, out ReturnValue);
            return ReturnValue > 0;
        }
    }
}
