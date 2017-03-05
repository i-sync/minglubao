using System;
using System.Collections.Generic;
using MLMGC.DataEntity.User;
using MLMGC.DBUtility;
using MLMGC.IDAL.User;
using System.Data.SqlClient;
using System.Data;
using MLMGC.COMP;

namespace MLMGC.DAL.User
{
    public class D_Admin : I_D_Admin
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="data">username,password</param>
        /// <returns></returns>
        public E_Admin UserLogin(E_Admin data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@UserName",SqlDbType.VarChar,64),
                new SqlParameter("@Password",SqlDbType.VarChar,64)
            };
            parms[0].Value = data.UserName;
            parms[1].Value = data.Password;
            DataSet ds = DbHelperSQL.RunProcedureDataSet("ProcB_Admin_Login", parms);

            if (Data.DataSetIsNotNull(ds))
            {
                data.AdminID =int.Parse(ds.Tables[0].Rows[0]["AdminID"].ToString());
                return data;
            }
            return null;
        }

        /// <summary>
        /// 管理员用户修改密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public bool UpdatePassword(E_Admin data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@AdminID",SqlDbType.Int),
                new SqlParameter("@OldPassword",SqlDbType.VarChar,64),
                new SqlParameter("@NewPassword",SqlDbType.VarChar,64)
            };
            parms[0].Value = data.AdminID;
            parms[1].Value = data.Password;
            parms[2].Value = data.NewPassword;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_Admin_UpdatePassword", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 判断管理员是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns>存在:true    不存在:false</returns>
        /// <remarks>tianzhenyun 2012-03-27</remarks>
        public bool Exists(E_Admin data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@AdminID",SqlDbType.Int),
                new SqlParameter("@UserName",SqlDbType.VarChar,64)
            };
            parms[0].Value = data.AdminID;
            parms[1].Value = data.UserName;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_Admin_Exists", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public bool Add(E_Admin data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@UserName",SqlDbType.VarChar,64),
                new SqlParameter("@Password",SqlDbType.VarChar,64)
            };
            parms[0].Value = data.UserName;
            parms[1].Value = data.Password;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_Admin_Insert", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public bool Update(E_Admin data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@AdminID",SqlDbType.Int),
                new SqlParameter("@UserName",SqlDbType.VarChar,64),
                new SqlParameter("@Password",SqlDbType.VarChar,64)
            };
            parms[0].Value = data.AdminID;
            parms[1].Value = data.UserName;
            parms[2].Value = data.Password;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_Admin_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public bool Delete(E_Admin data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@AdminID",SqlDbType.Int)
            };
            parms[0].Value = data.AdminID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_Admin_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 获取管理员对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public E_Admin GetModel(E_Admin data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@AdminID",SqlDbType.Int)
            };
            parms[0].Value = data.AdminID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcB_Admin_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.UserName = dt.Rows[0]["UserName"].ToString();
                data.Password = dt.Rows[0]["Password"].ToString();
                return data;
            }
            return null;
        }

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public DataTable GetList()
        {
            return DbHelperSQL.RunProcedureTable("ProcB_Admin_SelectList");
        }
    }
}
