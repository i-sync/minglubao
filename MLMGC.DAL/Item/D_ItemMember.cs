using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Item;
using MLMGC.IDAL.Item;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Item
{
    /// <summary>
    /// 项目人员
    /// </summary>
    public class D_ItemMember:I_D_ItemMember
    {

        /// <summary>
        /// 获取该项目的人员列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable GetMemberList(E_ItemMember data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;

            return DbHelperSQL.RunProcedureTable("ProcEP_B_ItemMember_SelectList", parms);
        }

        /// <summary>
        /// 总监删除个人用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-18</remarks>
        public bool Delete(E_ItemMember data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemMemberS_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }
    }
}
