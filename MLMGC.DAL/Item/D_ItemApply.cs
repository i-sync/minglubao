using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.IDAL.Item;
using MLMGC.DataEntity.Item;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Item
{
    /// <summary>
    /// 项目申请
    /// </summary>
    public class D_ItemApply :I_D_ItemApply
    {
        /// <summary>
        /// 添加个人申请（加入或退出）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-09</remarks>
        public bool Add(E_ItemApply data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@ItemID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int ),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@Type",SqlDbType.TinyInt),
                new SqlParameter("@Reason",SqlDbType.VarChar,1024),
            };
            parms[0].Value = data.ItemID;
            parms[1].Value = data.UserID;
            parms[2].Value = (int)EnumApply.未查看;
            parms[3].Value = (int)data.ApplyType;
            parms[4].Value = data.Reason;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemApply_Insert", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 总监申核个人申请
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-09</remarks>
        public int Update(E_ItemApply data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ApplyID",SqlDbType.Int ),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@Type",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ApplyID;
            parms[2].Value = (int)data.Status;
            parms[3].Value = (int)data.ApplyType;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemApply_Update", parms, out ReturnValue);
            return ReturnValue;
        }

        /// <summary>
        /// 查看申请列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-09</remarks>
        public DataTable GetList(E_ItemApply data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@ItemID",SqlDbType.Int ),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.Int),
                new SqlParameter("@Type",SqlDbType.TinyInt),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.ItemID;
            parms[1].Value = data.UserID;
            parms[2].Value = (int)data.Status;
            parms[3].Value = (int)data.ApplyType;
            parms[4].Value = data.Page.StartDate;
            parms[5].Value = data.Page.EndDate;
            parms[6].Value = data.Page.PageIndex;
            parms[7].Value = data.Page.PageSize;
            parms[8].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemApply_SelectList", parms);
            data.Page.TotalCount = parms[8].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[8].Value);
            return dt;
        }

        /// <summary>
        /// 判断是否已经过申请该项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 20012-05-10</remarks>
        public bool Exists(E_ItemApply data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@ItemID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int ),
                new SqlParameter("@Type",SqlDbType.TinyInt)
            };
            parms[0].Value = data.ItemID;
            parms[1].Value = data.UserID;
            parms[2].Value = (int)data.ApplyType;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemApply_Exists", parms, out ReturnValue);
            return ReturnValue > 0;
        }
    }
}
