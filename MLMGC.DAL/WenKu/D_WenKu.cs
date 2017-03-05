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
    /// 文库
    /// </summary>
    public class D_WenKu:I_D_WenKu
    {
        /// <summary>
        /// 判断文档是否已经存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns>true:存在，false:不存在</returns>
        /// <remarks>tianzhenyun 2012-03-21</remarks>
        public bool Exists(E_WenKu data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@FileName",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.FileName;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_WenKu_Exists", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 添加文档
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public bool Add(E_WenKu data)
        {
            SqlParameter[] parms = 
            {
				new SqlParameter("@WenKuClassID", SqlDbType.Int),
				new SqlParameter("@CustomClassName", SqlDbType.VarChar,128),
				new SqlParameter("@Caption", SqlDbType.VarChar,256),
				new SqlParameter("@Intro", SqlDbType.VarChar,1024),
				new SqlParameter("@FileName", SqlDbType.VarChar,128),
				new SqlParameter("@Keywords", SqlDbType.VarChar,512),
				new SqlParameter("@FileSize", SqlDbType.Int),
				new SqlParameter("@FileType", SqlDbType.TinyInt),
				new SqlParameter("@FileUrl", SqlDbType.VarChar,128),
				new SqlParameter("@UserID", SqlDbType.Int),
				new SqlParameter("@UserType", SqlDbType.TinyInt),
				new SqlParameter("@EnterpriseID", SqlDbType.Int),
                new SqlParameter("@StatusFlag",SqlDbType.TinyInt)
            };
            parms[0].Value = data.WenKuClassID;
            parms[1].Value = data.CustomClassName;
            parms[2].Value = data.Caption;
            parms[3].Value = data.Intro;
            parms[4].Value = data.FileName;
            parms[5].Value = data.Keywords;
            parms[6].Value = data.FileSize;
            parms[7].Value = (int)data.FileType;
            parms[8].Value = data.FileUrl;
            parms[9].Value = data.UserID;
            parms[10].Value = (int)data.UserType;
            parms[11].Value = data.EnterpriseID;
            parms[12].Value = data.StatusFlag;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_WenKu_Insert", parms, out ReturnValue);
            data.WenKuID = ReturnValue;
            return ReturnValue > 0;
        }

        /// <summary>
        /// 获取文档的对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public E_WenKu GetModel(E_WenKu data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WenKuID",SqlDbType.BigInt)
            };
            parms[0].Value = data.WenKuID;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcB_WenKu_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                data.Caption = row["Caption"].ToString();
                data.FileUrl = row["FileUrl"].ToString();
                data.SetFileType = Convert.ToInt32(row["FileType"] == DBNull.Value ? 0 : row["FileType"]);
                data.ReadNum = Convert.ToInt32(row["ReadNum"] == DBNull.Value ? 0 : row["ReadNum"]);
                data.DownNum = Convert.ToInt32(row["DownNum"] == DBNull.Value ? 0 : row["DownNum"]);
                data.AddDate = Convert.ToDateTime(row["AddDate"]);
                data.WenKuClassID = Convert.ToInt32(row["WenKuClassID"] == DBNull.Value ? 0 : row["WenKuClassID"]);
                data.CustomClassName = row["CustomClassName"].ToString();
                data.Keywords = row["Keywords"].ToString();
                data.FileName = row["FileName"].ToString();
                data.FileSize = Convert.ToInt32(row["FileSize"] == DBNull.Value ? 0 : row["FileSize"]);
                data.SetStatusFlag = Convert.ToInt32(row["StatusFlag"] == DBNull.Value ? 0 : row["StatusFlag"]);
                return data;
            }
            return null;
        }

        /// <summary>
        /// 获取文档列表 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public DataTable GetList(E_WenKu data)
        {
            SqlParameter[] parms = 
            {
				new SqlParameter("@WenKuClassID", SqlDbType.Int),				
				new SqlParameter("@Keywords", SqlDbType.VarChar,512),				
				new SqlParameter("@FileType", SqlDbType.TinyInt),
				new SqlParameter("@StatusFlag",SqlDbType.TinyInt),				
				new SqlParameter("@PageIndex", SqlDbType.Int),
				new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.TinyInt),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.WenKuClassID;
            parms[1].Value = data.Keywords;
            parms[2].Value = (int)data.FileType;
            parms[3].Value = (int)data.StatusFlag;
            parms[4].Value = data.Page.PageIndex;
            parms[5].Value = data.Page.PageSize;
            parms[6].Direction = ParameterDirection.Output;
            parms[7].Value = data.UserID;
            parms[8].Value = data.EnterpriseID;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcB_WenKu_PageList", parms);
            data.Page.TotalCount = Convert.ToInt32(parms[6].Value==DBNull.Value?0:parms[6].Value);
            return dt;
        }

        /// <summary>
        /// 后台管理员审核文档
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public bool UpdateStatus(E_WenKu data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WenKuIDs",SqlDbType.VarChar),
                new SqlParameter("@StatusFlag",SqlDbType.TinyInt)
            };
            parms[0].Value = data.WenKuIDs;
            parms[1].Value = (int)data.StatusFlag;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_WenKu_UpdateStatus", parms, out ReturnValue);
            return ReturnValue > 0;
        }
                
        /// <summary>
        /// 后台管理员删除审核未通过或下线文库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public bool Delete(E_WenKu data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WenKuID",SqlDbType.BigInt)
            };
            parms[0].Value = data.WenKuID;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_WenKu_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 后台管理员批量删除审核未通过或下线文库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public DataTable BatchDelete(E_WenKu data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WenKuIDs",SqlDbType.VarChar)
            };
            parms[0].Value = data.WenKuIDs;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcB_WenKu_BatchDelete", parms);
            return dt;
        }

        /// <summary>
        /// 获取要转换的文库列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-22</remarks>
        public DataTable ConvertList(E_WenKu data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WenKuIDs",SqlDbType.VarChar)
            };
            parms[0].Value = data.WenKuIDs;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcB_WenKu_ConvertList", parms);
            return dt;
        }

        /// <summary>
        /// 修改浏览次数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-22</reamrks>
        public bool UpdateBrowser(E_WenKu data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@WenKuID",SqlDbType.BigInt)
            };
            parms[0].Value = data.WenKuID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_WenKu_UpdateBrowser", parms, out ReturnValue);
            return ReturnValue > 0;
        }
    }
}
