using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.IDAL.Enterprise;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 项目留言
    /// </summary>
    public class D_ItemMessage :I_D_ItemMessage
    {
        /// <summary>
        /// 添加留言信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-27</remarks>
        public bool Add(E_ItemMessage data)
        {
            SqlParameter[] parms = 
            {
				new SqlParameter("@ItemID", SqlDbType.Int),
				new SqlParameter("@UserID", SqlDbType.Int),
				new SqlParameter("@UserName", SqlDbType.VarChar,128),
				new SqlParameter("@Mobile", SqlDbType.VarChar,11),
				new SqlParameter("@Tel", SqlDbType.VarChar,64),
				new SqlParameter("@Email", SqlDbType.VarChar,128),
				new SqlParameter("@Address", SqlDbType.VarChar,128),
				new SqlParameter("@Message", SqlDbType.VarChar,1024)				
            };
            parms[0].Value = data.ItemID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.UserName;
            parms[3].Value = data.Mobile;
            parms[4].Value = data.Tel;
            parms[5].Value = data.Email;
            parms[6].Value = data.Address;
            parms[7].Value = data.Message;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemMessage_Insert", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 查看留言列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-27</remarks>
        public DataTable GetList(E_ItemMessage data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.Page.PageSize;
            parms[2].Value = data.Page.PageIndex;
            parms[3].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemMessage_SelectList", parms);
            data.Page.TotalCount = parms[3].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[3].Value);
            return dt;
        }

        /// <summary>
        /// 管理员获取项目留言列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-28</remarks>
        public DataTable AdminGetList(E_ItemMessage data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseName",SqlDbType.VarChar,128),                
				new SqlParameter("@ItemName", SqlDbType.VarChar,64),
				new SqlParameter("@UserName", SqlDbType.VarChar,128),
				new SqlParameter("@Mobile", SqlDbType.VarChar,11),
				new SqlParameter("@Email", SqlDbType.VarChar,128),
                new SqlParameter("@DelFlag", SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseName;
            parms[1].Value = data.ItemName;
            parms[2].Value = data.UserName;
            parms[3].Value = data.Mobile;
            parms[4].Value = data.Email;
            parms[5].Value = data.DelFlag;
            parms[6].Value = data.Page.PageSize;
            parms[7].Value = data.Page.PageIndex;
            parms[8].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemMessage_AdminSelectList", parms);
            data.Page.TotalCount = parms[8].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[8].Value);
            return dt;
        }

        /// <summary>
        /// 总监删除留言(更改留言的DelFlag为0)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-27</remarks>
        public bool Delete(E_ItemMessage data)
        {
            SqlParameter[] parms = 
            {
				new SqlParameter("@ID", SqlDbType.Int)		
            };
            parms[0].Value = data.ID;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemMessage_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 后台管理员真正删除
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AdminDelete(E_ItemMessage data)
        {
            SqlParameter[] parms = 
            {
				new SqlParameter("@ID", SqlDbType.Int)		
            };
            parms[0].Value = data.ID;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemMessage_AdminDelete", parms, out ReturnValue);
            return ReturnValue > 0;
        }
    }
}
