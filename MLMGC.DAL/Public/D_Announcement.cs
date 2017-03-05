using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.IDAL.Public;
using MLMGC.DataEntity.Public;

namespace MLMGC.DAL.Public
{
    public class D_Announcement:I_D_Announcement
    {       
        /// <summary>
        /// 修改公告（个人）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public bool Update(E_Announcement data)
        {
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@AnnouncementID",SqlDbType.BigInt),
                new SqlParameter ("@AnnTitle",SqlDbType .VarChar ,128),
                new SqlParameter ("@AnnContent",SqlDbType .VarChar)
            };
            parms[0].Value = data.AnnouncementID;
            parms[1].Value = data.AnnTitle;
            parms[2].Value = data.AnnContent;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_Announcement_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 删除公告（个人）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public bool Delete(E_Announcement data)
        {
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@AnnouncementID",SqlDbType.BigInt)
            };
            parms[0].Value = data.AnnouncementID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_Announcement_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 根据公告编号获取公告信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public E_Announcement GetModel(E_Announcement data)
        {
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@AnnouncementID",SqlDbType.BigInt)
            };
            parms[0].Value = data.AnnouncementID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcB_Announcement_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.AnnTitle = dt.Rows[0]["AnnTitle"].ToString();
                data.AnnContent = dt.Rows[0]["AnnContent"].ToString();
                data.AddDate = Convert.ToDateTime(dt.Rows[0]["AddDate"]);
                return data;
            }
            return null;
        }

        /// <summary>
        /// 获取最新的前几条数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public DataTable GetNewList(E_Announcement data)
        {
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@Count",SqlDbType.Int)
            };
            parms[0].Value = data.Count;
            DataTable dt =DbHelperSQL.RunProcedureTable("ProcB_Announcement_NewList", parms);
            return dt;
        }

        /// <summary>
        /// 获取分页数据列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public DataTable GetList(E_Announcement data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@PageIndex",SqlDbType .Int),
                new SqlParameter ("@PageSize",SqlDbType .Int),
                new SqlParameter ("@TotalCount",SqlDbType .Int)
            };
            parms[0].Value = data.Page.PageIndex;
            parms[1].Value = data.Page.PageSize;
            parms[2].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcB_Announcement_SelectList", parms);
            data.Page.TotalCount = parms[2].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[2].Value);
            return dt;
        }
    }
}
