using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.IDAL.Enterprise;
using MLMGC.DBUtility;
using MLMGC.COMP;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 团队模型
    /// </summary>
    public class D_TeamModel : I_D_TeamModel
    {
        /// <summary>
        /// 获取团队模型列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            return DbHelperSQL.RunProcedureDataSet("ProcEP_D_TeamModel_Select", null);
        }

        /// <summary>
        /// 获取团队模型结构
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-12</remarks>
        public DataTable GetTeamModel(E_TeamModel data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_TeamScaleS_Select", parms);
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
        /// 获取企业团队模型配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_TeamModel GetTeamScale(E_TeamModel data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            DataSet ds = DbHelperSQL.RunProcedureDataSet("ProcEP_B_TeamScale_Select", parms);
            if (Data.DataSetIsNotNull(ds))
            {
                data.TeamModelID = Convert.ToInt32(ds.Tables[0].Rows[0]["TeamModelID"]);
                data.TeamScaleXml=ds.Tables[0].Rows[0]["TeamScaleXml"].ToString();
                data.LatenDay = Convert.ToInt32(ds.Tables[0].Rows[0]["LatenDay"]);
                data.LRemindDay = Convert.ToInt32(ds.Tables[0].Rows[0]["LRemindDay"]);
                data.WishDay = Convert.ToInt32(ds.Tables[0].Rows[0]["WishDay"]);
                data.WRemindDay = Convert.ToInt32(ds.Tables[0].Rows[0]["WRemindDay"]);
                data.NotTradedID = Convert.ToInt32(ds.Tables[0].Rows[0]["NotTradedID"]);
            }
            else
            {
                data = null;//尚未设置团队规模
            }
            return data;
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
        /// 获取企业团队模型下的角色列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet GetEnterpriseRole(E_TeamModel data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            return DbHelperSQL.RunProcedureDataSet("ProcEP_R_TeamModelRoleS_Select", parms);
        }
        /// <summary>
        /// 获取企业图
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-28</remarks>
        public DataSet GetEnterpriseMap(E_TeamModel data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            return DbHelperSQL.RunProcedureDataSet("ProcR_TeamMember_Map", parms);
        }

        /// <summary>
        /// 修改期限 共享 潜在客户、意向客户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-31</remarks>
        public bool UpdateDeadLine(E_TeamModel data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@LatenDay",SqlDbType.SmallInt),
                new SqlParameter("@WishDay",SqlDbType.SmallInt),
                new SqlParameter("@LRemindDay",SqlDbType.TinyInt),
                new SqlParameter("@WRemindDay",SqlDbType.TinyInt),
                new SqlParameter("@NotTradedID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.LatenDay;
            parms[2].Value = data.WishDay;
            parms[3].Value = data.LRemindDay;
            parms[4].Value = data.WRemindDay;
            parms[5].Value = data.NotTradedID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_TeamScale_UpdateDeadLine", parms, out ReturnValue);
            return ReturnValue > 0;
        }
    }
}
