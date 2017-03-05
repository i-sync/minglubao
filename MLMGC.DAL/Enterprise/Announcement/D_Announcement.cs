using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Enterprise.Announcement;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise.Announcement
{
    /// <summary>
    /// 企业公告
    /// </summary>
    public class D_Announcement:MLMGC.IDAL.Enterprise.Announcement.I_D_Announcement
    {
        /// <summary>
        /// 增加企业公告
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks >tianzhenyun 2011-10-17</remarks>
        public bool Add(E_Announcement data)
        {
            int rowsAffected = 0;
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@AnnouncementID",SqlDbType.BigInt),
                new SqlParameter ("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@TeamID",SqlDbType.Int ),
                new SqlParameter ("@AnnTitle",SqlDbType .VarChar ,128),
                new SqlParameter ("@AnnContent",SqlDbType .VarChar)
            };
            parms[0].Direction = ParameterDirection.Output;
            parms[1].Value = data.EnterpriseID;
            parms[2].Value = data.TeamID;
            parms[3].Value = data.AnnTitle;
            parms[4].Value = data.AnnContent;

            DbHelperSQL.ExecProcedure("ProcEP_B_AnnouncementS_Insert", parms, out rowsAffected);
            data.AnnouncementID = Convert.ToInt32(parms[0].Value);

            return rowsAffected > 0;
        }
        /// <summary>
        /// 得到一个公告对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-17</remarks>
        public E_Announcement GetModel(E_Announcement data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@AnnouncementID",SqlDbType .BigInt ),
                new SqlParameter("@EnterpriseID",SqlDbType .Int ),
                new SqlParameter("@TeamID",SqlDbType.Int)
            };
            parms[0].Value = data.AnnouncementID;
            parms[1].Value = data.EnterpriseID;
            parms[2].Value = data.TeamID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_AnnouncementS_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.AnnouncementID = Convert.ToInt64(dt.Rows[0]["AnnouncementID"]);
                data.AnnTitle = dt.Rows[0]["AnnTitle"].ToString();
                data.AnnContent = dt.Rows[0]["AnnContent"].ToString();
                data.AddDate = Convert.ToDateTime(dt.Rows[0]["AddDate"]);
                return data;
            }
            return null;
        }
        /// <summary>
        /// 获取企业公告列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-17</remarks>
        public DataTable GetList(E_Announcement data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@TeamID",SqlDbType .Int ),
                new SqlParameter ("@PageIndex",SqlDbType .Int),
                new SqlParameter ("@PageSize",SqlDbType .Int),
                new SqlParameter ("@TotalCount",SqlDbType .Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = data.Page.PageIndex;
            parms[3].Value = data.Page.PageSize;
            parms[4].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_AnnouncementS_ListSelect", parms);
            data.Page.TotalCount = parms[4].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[4].Value);
            return dt;
        }
        /// <summary>
        /// 得到上级公告对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-18</remarks>
        public E_Announcement GetLeaderModel(E_Announcement data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@AnnouncementID",SqlDbType .BigInt ),
                new SqlParameter("@EnterpriseID",SqlDbType .Int ),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType .Int )
            };
            parms[0].Value = data.AnnouncementID;
            parms[1].Value = data.EnterpriseID;
            parms[2].Value = data.TeamID;
            parms[3].Value = data.EPUserTMRID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_AnnouncementS_SelectLeader", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.AnnouncementID = Convert.ToInt64(dt.Rows[0]["AnnouncementID"]);
                data.AnnTitle = dt.Rows[0]["AnnTitle"].ToString();
                data.AnnContent = dt.Rows[0]["AnnContent"].ToString();
                data.AddDate = Convert.ToDateTime(dt.Rows[0]["AddDate"]);
                return data;
            }
            return null;
        }
        /// <summary>
        /// 获取上级公告列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-18</remarks>
        public DataTable GetLeaderList(E_Announcement data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@TeamID",SqlDbType .Int ),
                new SqlParameter ("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter ("@PageIndex",SqlDbType .Int),
                new SqlParameter ("@PageSize",SqlDbType .Int),
                new SqlParameter ("@TotalCount",SqlDbType .Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = data.EPUserTMRID;
            parms[3].Value = data.Page.PageIndex;
            parms[4].Value = data.Page.PageSize;
            parms[5].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_AnnouncementS_ListSelectLeader", parms);
            data.Page.TotalCount = Convert.ToInt32(parms[5].Value==DBNull.Value?0:parms[5].Value);
            return dt;
        }

        /// <summary>
        /// 获取自身及所有上级的最新公告
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-07</remarks>
        public DataTable GetNewList(E_Announcement data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@TeamID",SqlDbType .Int )
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_AnnouncementS_NewListSelect", parms);
        }
    }
}
