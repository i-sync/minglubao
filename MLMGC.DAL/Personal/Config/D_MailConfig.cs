using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.DataEntity.Personal.Config;

namespace MLMGC.DAL.Personal.Config
{
    /// <summary>
    /// 邮件配置
    /// </summary>
    public class D_MailConfig : MLMGC.IDAL.Personal.Config.I_D_MailConfig
    {
        #region I_D_MailConfig 成员
        /// <summary>
        /// 获取邮件配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public E_MailConfig GetConfig(E_MailConfig data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@PersonalID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_MailConfig_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.Email = dt.Rows[0]["Email"].ToString();
                data.SMTP = dt.Rows[0]["SMTP"].ToString();
                data.Port = int.Parse(dt.Rows[0]["Port"].ToString());
                data.Name = dt.Rows[0]["Name"].ToString();
                data.UserName = dt.Rows[0]["UserName"].ToString();
                data.Password = dt.Rows[0]["Password"].ToString();
                return data;
            }
            return null;
        }
        /// <summary>
        /// 修改邮件配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public bool SetConfig(E_MailConfig data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@SMTP",SqlDbType.VarChar,128),
                new SqlParameter("@Port",SqlDbType.TinyInt),
                new SqlParameter("@UserName",SqlDbType.VarChar,128),
                new SqlParameter("@Password",SqlDbType.VarChar,128),
                new SqlParameter("@Name",SqlDbType.VarChar,64)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.Email;
            parms[2].Value = data.SMTP;
            parms[3].Value = data.Port;
            parms[4].Value = data.UserName;
            parms[5].Value = data.Password;
            parms[6].Value = data.Name;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_MailConfig_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        #endregion
    }
}
