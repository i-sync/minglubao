using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DataEntity.User;
using MLMGC.IDAL.Enterprise;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 团队设置
    /// </summary>
    public class D_Team:I_D_Team
    {
        /// <summary>
        /// 获取企业团队列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet GetList(E_Team data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            return DbHelperSQL.RunProcedure("ProcEP_B_TeamS_Select", parms, "ds");
        }
        /// <summary>
        /// 获取企业某角色所在同级的团队列表
        /// </summary>
        /// <param name="data">EnterpriseID,TeamModelRoleID</param>
        /// <returns></returns>
        public DataTable GetListForRole(E_Team data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamModelRoleID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamModelRoleID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_TeamS_RoleSelect", parms);
        }
        /// <summary>
        /// 获取某一团队上级列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet GetTeamParent(E_Team data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@TeamID",SqlDbType.Int),
                 new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.TeamID;
            parms[1].Value = data.EnterpriseID;
            return DbHelperSQL.RunProcedure("ProcEP_B_TeamS_ParentSelect", parms, "ds");
        }

        /// <summary>
        /// 修改团队信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateTeam(E_Team data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@TeamName",SqlDbType.VarChar,128),
                new SqlParameter("@PID",SqlDbType.Int),
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.TeamID;
            parms[1].Value = data.TeamName;
            parms[2].Value = data.PID;
            parms[3].Value = data.EnterpriseID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Team_Update", parms, out ReturnValue);
            return ReturnValue>0;
        }

        /// <summary>
        /// 获取TeamID
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <rearks>tianzhenyun 2011-10-17</rearks>
        public DataTable GetTeamID(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType .Int ),
                new SqlParameter ("@EPUserTMRID",SqlDbType.Int )
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_TeamMemberS_SelectTeamID", parms);
        }

        /// <summary>
        /// 修改团队基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-18</remarks>
        public bool Update(E_Team data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {               
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int ),
                new SqlParameter("@TeamName",SqlDbType .VarChar,128),
                new SqlParameter("@Signature",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = data.TeamName;
            parms[3].Value = data.Signature;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Team_UpdateBase", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 获取团队对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-18</remarks>
        public E_Team GetModel(E_Team data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Team_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.TeamName = dt.Rows[0]["TeamName"].ToString();
                data.Signature = dt.Rows[0]["Signature"].ToString();
                return data;
            }
            return null; 
        }
        /// <summary>
        /// 获取团队成员所有下级
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-19</remarks>
        public DataTable GetTeamMember(E_Team data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            return DbHelperSQL.RunProcedureTable("ProcEP_R_TeamMemberS_Select", parms);
        }

        /// <summary>
        /// 获取某一领导下面的所有管理团队
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-21</remarks>
        public DataTable GetManageTeam(E_Team data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_Team_SelectManage", parms);
        }
        /// <summary>
        /// 获取某一领导下面的直接成员（下属团队/业务员）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-27</remarks>
        public DataTable GetDirectMember(E_Team data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_TeamS_SelecttDirectMember", parms);
        }
    }
}
