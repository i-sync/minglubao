using System;
using System.Collections.Generic;
using MLMGC.IDAL.User;
using MLMGC.DataEntity.User;
using System.Data;
using MLMGC.DBUtility;
using System.Data.SqlClient;

namespace MLMGC.DAL.User
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class D_User : I_D_User
    {
        #region 用户登录
        /// <summary>
        /// 企业用户登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_User UserLogin(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserName",SqlDbType.VarChar,128),
                new SqlParameter("@Password",SqlDbType.VarChar,128),
                new SqlParameter("@UserType",SqlDbType.TinyInt),
                new SqlParameter("@EPCode",SqlDbType.VarChar,32)
            };
            parms[0].Value = data.UserName;
            parms[1].Value = data.Password;
            parms[2].Value = data.UserType;
            parms[3].Value = data.EnterpriseCode;
            DataSet ds = DbHelperSQL.RunProcedure("ProcB_UserS_Login", parms, "ds");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                data.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                data.EnterpriseID = int.Parse(ds.Tables[0].Rows[0]["EnterpriseID"].ToString());
            }
            else
            {
                data = null;
            }
            return data;
        }

        #endregion

        /// <summary>
        /// 获取企业用户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet GetEPList(E_User data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserName",SqlDbType.VarChar,64),
                new SqlParameter("@TrueName",SqlDbType.VarChar,64),
                new SqlParameter("@RoleID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserName;
            parms[2].Value = data.TrueName;
            parms[3].Value = data.RoleID;

            parms[4].Value = data.Page.PageSize;
            parms[5].Value = data.Page.PageIndex;
            parms[6].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedureDataSet("ProcB_UserS_EPSelect", parms);
            data.Page.TotalCount = parms[6].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[6].Value);
            return ds;
        }

        /// <summary>
        /// 判断企业用户是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-01</remarks>
        public bool EPUserExist(E_User data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@UserName",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.UserName;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_UserS_EPExisit", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 添加企业用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddEnterpriseUser(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@UserName",SqlDbType.VarChar,128),
                new SqlParameter("@Password",SqlDbType.VarChar,128),
                new SqlParameter("@TrueName",SqlDbType.VarChar,128),
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@Settings",SqlDbType.NVarChar)
            };
            parms[0].Value = data.UserID;
            parms[1].Value = data.UserName;
            parms[2].Value = data.Password;
            parms[3].Value = data.TrueName;
            parms[4].Value = data.EnterpriseID;
            parms[5].Value = data.RoleSetting;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcB_UserS_EPInsert", parms, out ReturnValue);
            return ReturnValue;
        }

        /// <summary>
        ///  删除企业用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns>0=删除失败，1=删除成功，-1=用户数据未清空</returns>
        /// <remarks>tianzhenyun 2011-12-19</remarks>
        public int EPUserDelete(E_User data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int )
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_UserS_EPDelete", parms, out ReturnValue);
            return ReturnValue;
        }

        /// <summary>
        /// 获取企业用户购买数量和已使用数量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-30</remarks>
        public DataTable GetEPUserCount(E_User data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            return DbHelperSQL.RunProcedureTable("ProcB_UserS_GetEPUserCount", parms);
        }

        /// <summary>
        /// 获取企业用户基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-25</remarks>
        public E_User GetEPModel(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcB_UserS_GetEPModel", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.UserName = dt.Rows[0]["UserName"].ToString();
                data.Password = dt.Rows[0]["Password"].ToString();
                data.TrueName = dt.Rows[0]["TrueName"].ToString();
                data.Avatar = dt.Rows[0]["Avatar"].ToString();// == DBNull.Value ? "/images/guanliyuan.jpg" : dt.Rows[0]["Avatar"].ToString();
                return data;
            }
            return null;
        }

        /// <summary>
        /// 更改用户状态（启用、禁用）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UserStatus(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.Status;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcB_UserS_StatusUpdate", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ResetPassword(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Password",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.Password;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcB_UserS_ResetPassword", parms, out ReturnValue);
            return ReturnValue > 0;
        }
       
        /// <summary>
        /// 设置团队用户角色信息
        /// </summary>
        /// <param name="data"></param>
        public int SetTeamUserRole(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Settings",SqlDbType.NVarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.RoleSetting;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_R_EPUserTMRS_Update", parms, out ReturnValue);
            return ReturnValue;
        }

        /// <summary>
        /// 获取团队用户角色信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetTeamUserRole(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            return DbHelperSQL.RunProcedureTable("ProcEP_R_EPUserTMRS_Select", parms);
        }
        /// <summary>
        /// 获取用户角色信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetUserSelectRole(E_EnterpriseUser data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.EPUserTMRID;
            return DbHelperSQL.RunProcedureTable("ProcEP_R_EPUserTMRS_SelectRole", parms);
        }

        /// <summary>
        /// 获取用户操作菜单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetMenuList(E_EnterpriseUser data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.EPUserTMRID;
            return DbHelperSQL.RunProcedureTable("ProcEP_R_TMRMenuS_Select", parms);
        }

        /// <summary>
        /// 企业用户修改密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-19</remarks>
        public bool UpdatePassword(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@OldPassword",SqlDbType.VarChar,128),
                new SqlParameter("@NewPassword",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.Password;
            parms[3].Value = data.NewPassword;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcB_UserS_UpdatePassword", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 企业用户修改头像
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-09</remarks>
        public bool UpdateAvatar(E_User data)
        {
            SqlParameter [] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter ("@UserID",SqlDbType.Int),
                new SqlParameter("@Avatar",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.Avatar;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_User_EPUpdateAvatar", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 获取当前企业用户的角色编号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-03</remarks>
        public int GetEPRoleID(E_EnterpriseUser data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_R_EPUserTMRS_GetRoleID", parms);
            int roleid = 0;
            if (dt != null && dt.Rows.Count == 1)
            {
                int.TryParse(dt.Rows[0]["RoleID"].ToString(), out roleid);
            }
            return roleid;
        }

        /// <summary>
        /// 个人用户登录日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-09</remarks>
        public bool AddLoginInfo(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@LoginIP",SqlDbType.VarChar,32),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Browser",SqlDbType.VarChar,64),
                new SqlParameter("@Resolution",SqlDbType.VarChar,64)
            };
            parms[0].Value = data.LoginIP;
            parms[1].Value = data.UserID;
            parms[2].Value = data.Browser;
            parms[3].Value = data.Resolution;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_LoginInfoS_Insert", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 管理员查看个人登录信息列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-09</remarks>
        public DataTable GetLoginList(E_User data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@UserName",SqlDbType.VarChar,64),
                new SqlParameter("@UserType",SqlDbType.TinyInt),
                new SqlParameter("@Type",SqlDbType.TinyInt),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.UserName;
            parms[1].Value = (int)UserType.个人用户;
            parms[2].Value = data.Type;
            parms[3].Value = data.Page.StartDate;
            parms[4].Value = data.Page.EndDate;
            parms[5].Value = data.Page.PageIndex;
            parms[6].Value = data.Page.PageSize;
            parms[7].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_LoginInfoS_ListSelect", parms);
            data.Page.TotalCount = parms[7].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[7].Value);
            return dt;
        }

        /// <summary>
        /// 查看个人登录详细信息记录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-10</remarks>
        public DataTable GetLoginInfoList(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@LoginInfoID",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.LoginInfoID;
            parms[1].Value = data.Page.PageIndex;
            parms[2].Value = data.Page.PageSize;
            parms[3].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_LoginInfo_Select", parms);
            data.Page.TotalCount = parms[3].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[3].Value);
            return dt;
        }


        #region 品搜用户的自动注册及登录
        /// <summary>
        /// 验证品搜用户是否正确
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-23</remarks>
        public DataTable Pinsou_Verification(E_PinsouUser data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserID",SqlDbType.BigInt),
                new SqlParameter("@UserName",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.Pinsou_UserID;
            parms[1].Value = data.UserName;
            return DbHelperSQL.RunProcedureTable("Pinsou_UserInfo_Verification", parms);
        }

        /// <summary>
        /// 品搜用户自动注册名录宝用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-23</remarks>
        public int Pinsou_AutoRegister(E_PinsouUser data)
        {
            SqlParameter[] parms = 
            {
				new SqlParameter("@pinsou_UserID", SqlDbType.BigInt),
				new SqlParameter("@Email", SqlDbType.VarChar,128),
				new SqlParameter("@UserType", SqlDbType.TinyInt),
				new SqlParameter("@Status", SqlDbType.TinyInt),
				new SqlParameter("@Password", SqlDbType.VarChar,128),
				new SqlParameter("@Mobile", SqlDbType.VarChar,11),
				new SqlParameter("@Fax", SqlDbType.VarChar,64),
				new SqlParameter("@UserID", SqlDbType.Int),
				new SqlParameter("@PersonalID", SqlDbType.Int)
            };
            parms[0].Value = data.Pinsou_UserID;
            parms[1].Value = data.Email;
            parms[2].Value = UserType.个人用户;
            parms[3].Value = MLMGC.DataEntity.User.UserStatus.启用;
            parms[4].Value = data.Password;
            parms[5].Value = data.Mobile;
            parms[6].Value = data.Fax;
            parms[7].Direction = ParameterDirection.Output;
            parms[8].Direction = ParameterDirection.Output;
            int ReturnValue;
            DbHelperSQL.RunProcedures("Pinsou_UserInfo_AutoRegister", parms, out ReturnValue);
            data.mlb_UserID = Convert.ToInt32(parms[7].Value);
            data.PersonalID = Convert.ToInt32(parms[8].Value);
            return ReturnValue;
        }

        /// <summary>
        /// 品搜用户自动登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-23</remarks>
        public DataTable Pinsou_AutoLogin(E_PinsouUser data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.BigInt),
                new SqlParameter("@UserID",SqlDbType.BigInt),
                new SqlParameter("@UserName",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.ID;
            parms[1].Value = data.Pinsou_UserID;
            parms[2].Value = data.UserName;
            return DbHelperSQL.RunProcedureTable("Pinsou_UserInfo_AutoLogin", parms);
        }
        #endregion
    }
}
