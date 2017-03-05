using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;
using System.Data.SqlClient;
using System.Data;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 邮件配置
    /// </summary>
    public class D_MailConfig:MLMGC.IDAL.Enterprise.I_D_MailConfig
    {
        #region I_D_MailConfig 成员
        /// <summary>
        /// 获取邮件配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_MailConfig GetConfig(E_MailConfig data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_MailConfigS_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.Email = dt.Rows[0]["Email"].ToString();
                data.SMTP = dt.Rows[0]["SMTP"].ToString();
                data.Port = int.Parse(dt.Rows[0]["Port"].ToString());
                data.UserName = dt.Rows[0]["UserName"].ToString();
                data.Password = dt.Rows[0]["Password"].ToString();
                data.Name = dt.Rows[0]["Name"].ToString();
            }
            else
            {
                data = null;
            }
            return data;
        }
        /// <summary>
        /// 修改邮件配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ModifyConfig(E_MailConfig data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@SMTP",SqlDbType.VarChar,128),
                new SqlParameter("@Port",SqlDbType.TinyInt),
                new SqlParameter("@UserName",SqlDbType.VarChar,128),
                new SqlParameter("@Password",SqlDbType.VarChar,128),
                new SqlParameter("@Name",SqlDbType.NVarChar,64)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.Email;
            parms[3].Value = data.SMTP;
            parms[4].Value = data.Port;
            parms[5].Value = data.UserName;
            parms[6].Value = data.Password;
            parms[7].Value = data.Name;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_MailConfigS_Modify", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        #endregion
    }
}
