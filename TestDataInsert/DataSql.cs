using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DataEntity.User;
using MLMGC.DBUtility;

namespace TestDataInsert
{
    /// <summary>
    /// 数据访问
    /// </summary>
    public class DataSql
    {
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
            return rowsAffected ;
        }

        /// <summary>
        /// 设置企业团队模型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int SetTeamModel(E_TeamModel data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamModelID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamModelID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_TeamScale_Update", parms, out ReturnValue);
            return ReturnValue;
        }

        /// <summary>
        /// 更新企业团队模型配置 各团队数量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int UpdateTeamScale(E_TeamModel data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamScaleXml",SqlDbType.Xml),
                new SqlParameter("@Child_RoleID",SqlDbType.NVarChar),
                new SqlParameter("@Child_RoleAmount",SqlDbType.NVarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamScaleXml;
            parms[2].Value = data.Child_RoleID;
            parms[3].Value = data.Child_RoleAmount;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_TeamScaleS_UpdateTeamScale", parms, out ReturnValue);
            return ReturnValue;
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
        /// 添加新名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@Address",SqlDbType.VarChar,128),
                new SqlParameter("@ZipCode",SqlDbType.VarChar,8),
                new SqlParameter("@Linkman",SqlDbType.VarChar,64),
                new SqlParameter("@Position",SqlDbType.VarChar,64),
                new SqlParameter("@Tel",SqlDbType.VarChar,32),
                new SqlParameter("@Mobile",SqlDbType.VarChar,16),
                new SqlParameter("@Fax",SqlDbType.VarChar,32),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@QQ",SqlDbType.VarChar,128),
                new SqlParameter("@MSN",SqlDbType.VarChar,128),
                new SqlParameter("@Remark",SqlDbType.VarChar),
                new SqlParameter("@SourceCode",SqlDbType.VarChar,16),
                new SqlParameter("@TradeCode",SqlDbType.VarChar,16),
                new SqlParameter("@AreaCode",SqlDbType.VarChar,16),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter ("@Website",SqlDbType.VarChar,128),
                new SqlParameter("@ClientInfoID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientName;
            parms[2].Value = data.Address;
            parms[3].Value = data.ZipCode;
            parms[4].Value = data.Linkman;
            parms[5].Value = data.Position;
            parms[6].Value = data.Tel;
            parms[7].Value = data.Mobile;
            parms[8].Value = data.Fax;
            parms[9].Value = data.Email;
            parms[10].Value = data.QQ;
            parms[11].Value = data.MSN;
            parms[12].Value = data.Remark;
            parms[13].Value = data.SourceCode;
            parms[14].Value = data.TradeCode;
            parms[15].Value = data.AreaCode;
            parms[16].Value = data.EPUserTMRID;
            parms[17].Value = data.Website;
            parms[18].Direction = ParameterDirection.Output;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ClientInfoS_Insert", parms, out ReturnValue);
            if (ReturnValue > 0)//判断是否录入成功
            {
                data.ClientInfoID = Convert.ToInt32(parms[18].Value);
                return true;
            }
            return false;
        }
    }
}
