using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.IDAL.Enterprise;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 企业信息
    /// </summary>
    public class D_Enterprise:I_D_Enterprise
    {
        /// <summary>
        /// 验证企业号是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Exist(E_Enterprise data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseCode",SqlDbType.VarChar,32)
            };
            parms[0].Value = data.EnterpriseCode;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Enterprise_Exist", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 添加新企业
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(E_Enterprise data)
        {
            int rowsAffected = 0;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseCode",SqlDbType.VarChar,32),
                new SqlParameter("@EnterpriseNames",SqlDbType.VarChar,128),
                new SqlParameter("@ItemName",SqlDbType.VarChar,128),
                new SqlParameter("@Linkman",SqlDbType.VarChar,64),
                new SqlParameter("@Position",SqlDbType.VarChar,64),
                new SqlParameter("@Tel",SqlDbType.VarChar,32),
                new SqlParameter("@Mobile",SqlDbType.VarChar,32),
                new SqlParameter("@Fax",SqlDbType.VarChar,32),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@Address",SqlDbType.VarChar,128),
                new SqlParameter("@UserAmount",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@ExpireDate",SqlDbType.SmallDateTime),
                new SqlParameter("@AdminUserName",SqlDbType.VarChar,64),//管理员帐号
                new SqlParameter("@AdminPassword",SqlDbType.VarChar,64)//管理员密码
            };
            parms[0].Value = data.EnterpriseCode;
            parms[1].Value = data.EnterpriseNames;
            parms[2].Value = data.ItemName;
            parms[3].Value = data.Linkman;
            parms[4].Value = data.Position;
            parms[5].Value = data.Tel;
            parms[6].Value = data.Mobile;
            parms[7].Value = data.Fax;
            parms[8].Value = data.Email;
            parms[9].Value = data.Address;
            parms[10].Value = data.UserAmount;
            parms[11].Value = data.StartDate;
            parms[12].Value = data.ExpireDate;
            parms[13].Value = data.AdminUserName;
            parms[14].Value = data.AdminPassword;

            DbHelperSQL.RunProcedures("ProcEP_B_EnterpriseS_Insert", parms, out rowsAffected);
            return rowsAffected;
        }

        /// <summary>
        /// 管理员修改企业基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-02</remarks>
        public bool Update(E_Enterprise data)
        {
            int rowsAffected = 0;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ItemName",SqlDbType.VarChar,128),
                new SqlParameter("@Linkman",SqlDbType.VarChar,64),
                new SqlParameter("@Position",SqlDbType.VarChar,64),
                new SqlParameter("@Tel",SqlDbType.VarChar,32),
                new SqlParameter("@Mobile",SqlDbType.VarChar,32),
                new SqlParameter("@Fax",SqlDbType.VarChar,32),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@Address",SqlDbType.VarChar,128),
                new SqlParameter("@Password",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ItemName;
            parms[2].Value = data.Linkman;
            parms[3].Value = data.Position;
            parms[4].Value = data.Tel;
            parms[5].Value = data.Mobile;
            parms[6].Value = data.Fax;
            parms[7].Value = data.Email;
            parms[8].Value = data.Address;
            parms[9].Value = data.AdminPassword;

            DbHelperSQL.RunProcedures("ProcEP_B_EnterpriseS_Update", parms, out rowsAffected);
            return rowsAffected > 0;
        }

        /// <summary>
        /// 后台管理员修改企业基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-02-09</remarks>
        public bool AdminUpdate(E_Enterprise data)
        {
            int rowsAffected = 0;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@EnterpriseNames",SqlDbType.VarChar,128),
                new SqlParameter("@Linkman",SqlDbType.VarChar,64),
                new SqlParameter("@Position",SqlDbType.VarChar,64),
                new SqlParameter("@Tel",SqlDbType.VarChar,32),
                new SqlParameter("@Mobile",SqlDbType.VarChar,32),
                new SqlParameter("@Fax",SqlDbType.VarChar,32),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@Address",SqlDbType.VarChar,128),
                new SqlParameter("@UserAmount",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@ExpireDate",SqlDbType.SmallDateTime),
                new SqlParameter("@UserName",SqlDbType.VarChar,128),
                new SqlParameter("@Password",SqlDbType.VarChar,128),
                new SqlParameter("@ItemName",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EnterpriseNames;
            parms[2].Value = data.Linkman;
            parms[3].Value = data.Position;
            parms[4].Value = data.Tel;
            parms[5].Value = data.Mobile;
            parms[6].Value = data.Fax;
            parms[7].Value = data.Email;
            parms[8].Value = data.Address;
            parms[9].Value = data.UserAmount;
            parms[10].Value = data.StartDate;
            parms[11].Value = data.ExpireDate;
            parms[12].Value = data.AdminUserName;
            parms[13].Value = data.AdminPassword;
            parms[14].Value = data.ItemName;

            DbHelperSQL.RunProcedures("ProcEP_B_EnterpriseS_AdminUpdate", parms, out rowsAffected);
            return rowsAffected > 0;
        }

        /// <summary>
        /// 删除企业
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 20111-12-02</remarks>
        public bool Delete(E_Enterprise data)
        {
            int rowsAffected = 0;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;

            DbHelperSQL.RunProcedures("ProcEP_B_EnterpriseS_Delete", parms, out rowsAffected);
            return rowsAffected > 0;
        }

        /// <summary>
        /// 获取一个企业的基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>2011-11-21改 田振运添加一些字段</remarks>
        public E_Enterprise Get(E_Enterprise data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Enterprise_Select", parms);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                data.EnterpriseID = int.Parse(row["EnterpriseID"].ToString());
                data.EnterpriseCode = row["EnterpriseCode"].ToString();
                data.EnterpriseNames = row["EnterpriseNames"].ToString();
                data.UserAmount = int.Parse(row["UserAmount"].ToString());

                //2011-11-21改
                data.Linkman = row["Linkman"].ToString();
                data.Tel = row["Tel"].ToString();
                data.ItemName = row["ItemName"].ToString();
                data.StartDate = Convert.ToDateTime(row["StartDate"]);
                data.ExpireDate = Convert.ToDateTime(row["ExpireDate"]);

                //2011-12-02加
                data.Position = row["Position"].ToString();
                data.Mobile = row["Mobile"].ToString();
                data.Fax = row["Fax"].ToString();
                data.Email = row["Email"].ToString();
                data.Address = row["Address"].ToString();
            }
            else
            {
                data = null;
            }
            return data;
        }

        /// <summary>
        /// 管理员查看企业用户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-02</remarks>
        public DataTable GetList(E_Enterprise data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseNames",SqlDbType.VarChar ,128),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime ),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageIndex",SqlDbType.Int ),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseNames;
            parms[1].Value = data.Page.StartDate;
            parms[2].Value = data.Page.EndDate;
            parms[3].Value = data.Page.PageIndex;
            parms[4].Value = data.Page.PageSize;
            parms[5].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_EnterpriseS_ListSelect", parms);
            data.Page.TotalCount = parms[5].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[5].Value);
            return dt;
        }

        /// <summary>
        /// 管理员修改企业状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-02</remarks>
        public bool StatusUpdate(E_Enterprise data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int ),
                new SqlParameter("@Status",SqlDbType .TinyInt )
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.Status;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_Enterprise_StatusUpdate", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 管理员查看企业详细信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-03</remarks>
        public E_Enterprise GetModel(E_Enterprise data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int )
            };
            parms[0].Value = data.EnterpriseID;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_EnterpriseS_DataSelect", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                data.EnterpriseCode = row["EnterpriseCode"].ToString();
                data.EnterpriseNames = row["EnterpriseNames"].ToString();
                data.Linkman = row["Linkman"] != null ? row["Linkman"].ToString() : string.Empty;
                data.Position = row["Position"] != null ? row["Position"].ToString() : string.Empty;
                data.Tel = row["Tel"] != null ? row["Tel"].ToString() : string.Empty;
                data.Email = row["Email"] != null ? row["Email"].ToString() : string.Empty;

                data.Mobile = row["Mobile"] != null ? row["Mobile"].ToString() : string.Empty;
                data.Fax = row["Fax"] != null ? row["Fax"].ToString() : string.Empty;
                data.Address = row["Address"] != null ? row["Address"].ToString() : string.Empty;
                data.UserAmount = row["UserAmount"] != null ? Convert.ToInt32(row["UserAmount"]) : 0;
                data.UserNum = row["UserNum"] != null ? Convert.ToInt32(row["UserNum"]) : 0;
                data.ClientNum = row["ClientNum"] != null ? Convert.ToInt32(row["ClientNum"]) : 0;
                data.StartDate = row["StartDate"] != null ? Convert.ToDateTime(row["StartDate"]) : DateTime.Now;
                data.ExpireDate = row["ExpireDate"] != null ? Convert.ToDateTime (row["ExpireDate"]) :  DateTime.Now;

                data.AdminUserName = row["AdminUserName"] != null ? row["AdminUserName"].ToString() : string.Empty;
                data.AdminPassword = row["AdminPassword"] != null ? row["AdminPassword"].ToString() : string.Empty;
                data.ItemName = row["ItemName"] != null ? row["ItemName"].ToString() : string.Empty;

                return data;
            }
            return null;
        }
    }
}
