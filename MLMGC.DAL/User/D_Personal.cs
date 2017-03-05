using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.DataEntity.User;

namespace MLMGC.DAL.User
{
    /// <summary>
    /// 注册个人信息
    /// </summary>
    public class D_Personal :MLMGC.IDAL.User.I_D_Personal
    {
        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-21</remarks>
        public bool AddAuthCode(E_Personal data)
        {
            int ReturnValue;
            SqlParameter[] parms = 
            {
				new SqlParameter("@UID", SqlDbType.UniqueIdentifier),
				new SqlParameter("@Email", SqlDbType.VarChar,128),
				new SqlParameter("@EmailCode", SqlDbType.VarChar,64)
            };
            parms[0].Value = data.UID;
            parms[1].Value = data.UserName;
            parms[2].Value = data.EmailCode;

            DbHelperSQL.RunProcedures("ProcPI_B_AuthCode_Insert", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 个人注册
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-21</remarks>
        public int AddPersonal(E_Personal data)
        {
            int ReturnValue;
            SqlParameter[] parms = 
            {
				new SqlParameter("@UID", SqlDbType.UniqueIdentifier),
				new SqlParameter("@Email", SqlDbType.VarChar,128),
				new SqlParameter("@EmailCode", SqlDbType.VarChar,64),
				new SqlParameter("@UserType", SqlDbType.TinyInt),
				new SqlParameter("@Status", SqlDbType.TinyInt),
				new SqlParameter("@Password", SqlDbType.VarChar,128),
				new SqlParameter("@RealName", SqlDbType.VarChar,64),
				new SqlParameter("@Sex", SqlDbType.TinyInt),
				new SqlParameter("@Mobile", SqlDbType.VarChar,11),
				new SqlParameter("@Tel", SqlDbType.VarChar,64),
				new SqlParameter("@Fax", SqlDbType.VarChar,64),
				new SqlParameter("@Address", SqlDbType.VarChar,128),
				new SqlParameter("@UserID", SqlDbType.Int),
				new SqlParameter("@PersonalID", SqlDbType.Int)
            };
            parms[0].Value = data.UID;
            parms[1].Value = data.UserName;
            parms[2].Value = data.EmailCode;
            parms[3].Value = UserType.个人用户;
            parms[4].Value = UserStatus.启用;
            parms[5].Value = data.Password;
            parms[6].Value = data.RealName;
            parms[7].Value = data.Sex;
            parms[8].Value = data.Mobile;
            parms[9].Value = data.Tel;
            parms[10].Value = data.Fax;
            parms[11].Value = data.Address;
            parms[12].Direction = ParameterDirection.Output;
            parms[13].Direction = ParameterDirection.Output;

            DbHelperSQL.RunProcedures("ProcPI_B_PersonalS_Insert", parms, out ReturnValue);
            
            return ReturnValue;
        }

        /// <summary>
        /// 验证邮箱是否可用
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AuthEmail(E_PersonalUser data)
        {
            int ReturnValue;
            SqlParameter[] parms = 
            {
				new SqlParameter("@UserName", SqlDbType.VarChar,128)
            };
            parms[0].Value = data.UserName;

            DbHelperSQL.RunProcedures("ProcB_User_AuthEmail", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 个人用户修改密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-21</remarks>
        public bool UpdatePassword(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@OldPassword",SqlDbType.VarChar,128),
                new SqlParameter("@NewPassword",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.Password;
            parms[3].Value = data.NewPassword;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcB_UserS_PIUpdatePassword", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 得到个人实体对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-21</remarks>
        public E_Personal GetModel(E_Personal data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.UserID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_Personal_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                data.RealName = row["RealName"].ToString();
                data.Sex = Convert.ToInt32(row["Sex"]);
                data.Mobile = row["Mobile"].ToString();
                data.Tel = row["Tel"].ToString();
                data.Fax = row["Fax"].ToString();
                data.Address = row["Address"].ToString();
                data.Avatar = row["Avatar"] == DBNull.Value ? "" : row["Avatar"].ToString();

                //2012-03-09
                data.Email = row["Email"].ToString();
                data.Birthday = row["Birthday"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["Birthday"]);
                data.SetWorkYears = row["WorkYears"] == DBNull.Value ? 0 : Convert.ToInt32(row["WorkYears"]);
                data.CityID = row["CityID"] == DBNull.Value ? 0 : Convert.ToInt32(row["CityID"]);
                data.HuKouCityID = row["HuKouCityID"] == DBNull.Value ? 0 : Convert.ToInt32(row["HuKouCityID"]);
                data.KeyWord = row["KeyWord"].ToString();
                data.SetMaritalStatus = row["MaritalStatus"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaritalStatus"]);

                //2012-05-09
                data.SetItemFlag = row["ItemFlag"] == DBNull.Value ? 0 : Convert.ToInt32(row["ItemFlag"]);
                return data;
            }
            return null;
        }

        /// <summary>
        /// 个人用户修改信息
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-21</remarks>
        public bool Update(E_Personal data)
        {
            int ReturnValue;
            SqlParameter[] parms = 
            {
                new SqlParameter("@UserID", SqlDbType.Int),
				new SqlParameter("@PersonalID", SqlDbType.Int),
				new SqlParameter("@RealName", SqlDbType.VarChar,64),
				new SqlParameter("@Sex", SqlDbType.TinyInt),
				new SqlParameter("@Mobile", SqlDbType.VarChar,11),
				new SqlParameter("@Tel", SqlDbType.VarChar,64),
				new SqlParameter("@Fax", SqlDbType.VarChar,64),
				new SqlParameter("@Address", SqlDbType.VarChar,128),
				
                //2012-03-09日改，添加以下参数
                new SqlParameter("@Email", SqlDbType.VarChar,128),
				new SqlParameter("@Birthday", SqlDbType.SmallDateTime),
				new SqlParameter("@WorkYears", SqlDbType.TinyInt),
				new SqlParameter("@CityID", SqlDbType.Int),
				new SqlParameter("@HuKouCityID", SqlDbType.Int),
				new SqlParameter("@KeyWord", SqlDbType.VarChar,256),
                new SqlParameter("@MaritalStatus",SqlDbType.TinyInt)
            };
            parms[0].Value = data.UserID;
            parms[1].Value = data.PersonalID ;
            parms[2].Value = data.RealName;
            parms[3].Value = data.Sex;
            parms[4].Value = data.Mobile;
            parms[5].Value = data.Tel;
            parms[6].Value = data.Fax;
            parms[7].Value = data.Address;

            parms[8].Value = data.Email;
            parms[9].Value = data.Birthday;
            parms[10].Value = (int)data.WorkYears;
            parms[11].Value = data.CityID;
            parms[12].Value = data.HuKouCityID;
            parms[13].Value = data.KeyWord;
            parms[14].Value = (int)data.MaritalStatus;

            DbHelperSQL.RunProcedures("ProcPI_B_Personal_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 个人用户修改头像
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public bool UpdateAvatar(E_Personal data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@UserID", SqlDbType.Int),
				new SqlParameter("@PersonalID", SqlDbType.Int),
				new SqlParameter("@Avatar", SqlDbType.VarChar,128)			
            };
            parms[0].Value = data.UserID;
            parms[1].Value = data.PersonalID;
            parms[2].Value = data.Avatar;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_User_PIUpdateAvatar", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 个人用户找回密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-24</remarks>
        public int GetPassword(E_User data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserName",SqlDbType.VarChar ,128),
                new SqlParameter("@UserType",SqlDbType.TinyInt),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@Password",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.UserName;
            parms[1].Value = data.UserType;
            parms[2].Value = data.Status;
            parms[3].Direction = ParameterDirection.Output;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcB_UserS_GetPassword", parms, out ReturnValue);
            if (ReturnValue == 1)
            {
                data.Password = parms[3].Value.ToString();
            }
            else
            {
                data = null;
            }
            return ReturnValue;
        }

        /// <summary>
        /// 管理员查看个人用户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-27</remarks>
        public DataTable GetList(E_Personal data)
        { 
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserName",SqlDbType.VarChar ,128),
                new SqlParameter("@RealName",SqlDbType .VarChar,128),
                new SqlParameter("@UserType",SqlDbType.TinyInt),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime ),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageIndex",SqlDbType.Int ),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.UserName;
            parms[1].Value = data.RealName;
            parms[2].Value = (int)UserType.个人用户;
            parms[3].Value = data.Page.StartDate;
            parms[4].Value = data.Page.EndDate;
            parms[5].Value = data.Page.PageIndex;
            parms[6].Value = data.Page.PageSize;                 
            parms[7].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_PersonalS_ListSelect", parms);
            data.Page.TotalCount = parms[7].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[7].Value);
            return dt;
        }

        /// <summary>
        /// 修改个人用户状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-27</remarks>
        public bool PersonalStatus(E_Personal data)
        { 
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@PersonalID",SqlDbType.Int ),
                new SqlParameter("@Status",SqlDbType.TinyInt)                
            };
            parms[0].Value = data.UserID;
            parms[1].Value = data.PersonalID;
            parms[2].Value = data.Status;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_UserS_PIStatusUpdate", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 管理员查看个人基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-27</remarks>
        public E_Personal SelectModel(E_Personal data)
        { 
        
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@PersonalID",SqlDbType.Int )            
            };
            parms[0].Value = data.UserID;
            parms[1].Value = data.PersonalID;
            
            DataTable dt  =DbHelperSQL.RunProcedureTable("ProcB_UserS_PISelect", parms);
            if (dt != null && dt.Rows.Count == 1)
            { 
                DataRow row = dt.Rows[0];
                data.UserName = row["UserName"].ToString();
                data.Password = row["Password"].ToString();
                data.RealName = row["RealName"].ToString();
                data.Mobile = row["Mobile"].ToString();
                data.Tel = row["Tel"].ToString();
                data.Fax = row["Fax"].ToString();
                data.Address = row["Address"].ToString();
                data.Email = row["Email"].ToString();
                data.ClientNum = Convert.ToInt32(row["ClientNum"]);
                return data;
            }
            return null;
        }

        /// <summary>
        /// 管理员删除个人用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-27</remarks>
        public int Delete(E_Personal data)
        { 
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@PersonalID",SqlDbType.Int )            
            };
            parms[0].Value = data.UserID;
            parms[1].Value = data.PersonalID;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_UserS_PIDelete", parms,out ReturnValue);
            return ReturnValue;
        }


        /// <summary>
        /// 个人用户信息(ID,RealName)列表 用于绑定下拉列表
        /// </summary>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-08</reamrks>
        public DataTable DataList()
        {
            return DbHelperSQL.RunProcedureTable("ProcPI_B_Personal_List");
        }


        /// <summary>
        /// 获取个人用户所在项目的企业号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public DataTable GetEnterpriseID(E_Personal data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@PersonalID",SqlDbType.Int )            
            };
            parms[0].Value = data.UserID;
            parms[1].Value = data.PersonalID;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_GetEnterpriseID", parms);
            return dt;
        }
    }
}
