using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.DataEntity;
using MLMGC.IDAL;

namespace MLMGC.DAL
{
    /// <summary>
    /// 问题反馈
    /// </summary>
    public class D_Feedback:MLMGC.IDAL.I_D_Feedback
    {
        /// <summary>
        /// 添加问题反馈
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-28</remarks>
        public bool Add(E_Feedback data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@UserType",SqlDbType.TinyInt ),
                new SqlParameter("@Subject",SqlDbType.VarChar,128),
                new SqlParameter("@Detail",SqlDbType.VarChar),
                new SqlParameter("@FileName",SqlDbType.VarChar,128),
                new SqlParameter("@Url",SqlDbType.VarChar,128),
                new SqlParameter("@FileType",SqlDbType.VarChar,16),
                new SqlParameter("@FileSize",SqlDbType.Int ),
                new SqlParameter ("@FeedbackID",SqlDbType.Int),
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.UserID;
            parms[1].Value = data.UserType;
            parms[2].Value = data.Subject;
            parms[3].Value = data.Detail;
            parms[4].Value = data.FileName;
            parms[5].Value = data.Url;
            parms[6].Value = data.FileType;
            parms[7].Value = data.FileSize;
            parms[8].Direction = ParameterDirection.Output;
            parms[9].Value = data.EnterpriseID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_FeedbackS_Insert", parms, out ReturnValue);
            data.FeedbackID = parms[8].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[8].Value);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 查看反馈信息的详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-28</remarks>
        public E_Feedback GetModel(E_Feedback data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@FeedbackID",SqlDbType.Int)
            };
            parms[0].Value = data.FeedbackID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcB_FeedbackS_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                data.Subject = row["Subject"].ToString();
                data.Detail = row["Detail"].ToString();
                data.AddDate = Convert.ToDateTime(row["AddDate"]);
                data.FileName = row["FileName"].ToString();
                data.Url = row["Url"].ToString();
                return data;
            }
            return null;
        }

        /// <summary>
        /// 查看问题反馈列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-28</remarks>
        public DataTable GetList(E_Feedback data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserType",SqlDbType.TinyInt ),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.UserType;
            parms[1].Value = data.Page.StartDate;
            parms[2].Value = data.Page.EndDate;
            parms[3].Value = data.Page.PageIndex;
            parms[4].Value = data.Page.PageSize;
            parms[5].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcB_Feedback_ListSelect", parms);
            data.Page.TotalCount = parms[5].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[5].Value);
            return dt;
        }
    }
}
