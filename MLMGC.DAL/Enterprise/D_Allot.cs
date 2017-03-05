using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 名录分配
    /// </summary>
    public class D_Allot:MLMGC.IDAL.Enterprise.I_D_Allot
    {
        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-27</remarks>
        public bool Update(E_Allot data)
        {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int),
                 new SqlParameter("@AmountLimit",SqlDbType.Int),
                 new SqlParameter("@ObjIDs",SqlDbType.NVarChar),
                 new SqlParameter("@TradeIDs",SqlDbType.NVarChar),
                 new SqlParameter("@AreaIDs",SqlDbType.NVarChar),
                 new SqlParameter("@SourceIDs",SqlDbType.NVarChar),
                 new SqlParameter("@Separation",SqlDbType.VarChar,2)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value =Convert.ToInt32(data.Limit);
            parms[3].Value = data.ObjIDs;
            parms[4].Value = data.TradeS;
            parms[5].Value = data.AreaS;
            parms[6].Value = data.SourceS;
            parms[7].Value = MLMGC.COMP.Config.Separation;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_AllotConfigS_Update", parms, out ReturnValue);
            if (ReturnValue > 0)//判断是否修改成功
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-28</remarks>
        public DataSet Select(E_Allot data)
        {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            return DbHelperSQL.RunProcedureDataSet("ProcEP_B_AllotConfigS_Select", parms);
        }
        #region 名录分配
        /// <summary>
        /// 按属性自动分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-01</remarks>
        public DataTable AutoPropertyAllot(E_Allot data)
        {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int),
                 new SqlParameter("@Mode",SqlDbType.TinyInt),
                 new SqlParameter("@Status",SqlDbType.TinyInt),
                 new SqlParameter("@Amount",SqlDbType.Int),
                 new SqlParameter("@Sort",SqlDbType.NVarChar,32),
                 new SqlParameter("@AllotMode",SqlDbType.TinyInt),
                 new SqlParameter("ReturnValue",SqlDbType.Int, 4, ParameterDirection.ReturnValue,false, 0, 0, string.Empty, DataRowVersion.Default, null)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)EnumClientMode.团队;
            parms[3].Value = (int)EnumClientStatus.待分配名录;
            parms[4].Value = data.AllotAmount;
            parms[5].Value = data.AllotSort;
            parms[6].Value = Convert.ToInt16(data.Mode);

            DataTable dt=DbHelperSQL.RunProcedureTable("ProcEP_B_Allot_AutoPropertyAllot", parms);
            if (parms[7].Value.ToString().Equals("1"))
            {
                return dt;
            }
            return null;
        }
        /// <summary>
        /// 自动平均分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-01</remarks>
        public DataTable AutoAvgAllot(E_Allot data)
        {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int),
                 new SqlParameter("@Mode",SqlDbType.TinyInt),
                 new SqlParameter("@Status",SqlDbType.TinyInt),
                 new SqlParameter("@Amount",SqlDbType.Int),
                 new SqlParameter("@Sort",SqlDbType.NVarChar,32),
                 new SqlParameter("ReturnValue",SqlDbType.Int, 4, ParameterDirection.ReturnValue,false, 0, 0, string.Empty, DataRowVersion.Default, null)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)EnumClientMode.团队;
            parms[3].Value = (int)EnumClientStatus.待分配名录;
            parms[4].Value = data.AllotAmount;
            parms[5].Value = data.AllotSort;

            DataTable dt=DbHelperSQL.RunProcedureTable("ProcEP_B_Allot_AutoAvgAllot", parms);
            if (parms[6].Value.ToString().Equals("1"))
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 自动补差分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-01</remarks>
        public DataTable AutoMarkupAllot(E_Allot data)
        {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int),
                 new SqlParameter("@Mode",SqlDbType.TinyInt),
                 new SqlParameter("@Status",SqlDbType.TinyInt),
                 new SqlParameter("@Amount",SqlDbType.Int),
                 new SqlParameter("@Sort",SqlDbType.NVarChar,32),
                 new SqlParameter("ReturnValue",SqlDbType.Int, 4, ParameterDirection.ReturnValue,false, 0, 0, string.Empty, DataRowVersion.Default, null)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)EnumClientMode.团队;
            parms[3].Value = (int)EnumClientStatus.待分配名录;
            parms[4].Value = data.AllotAmount;
            parms[5].Value = data.AllotSort;
            

            DataTable dt=DbHelperSQL.RunProcedureTable("ProcEP_B_Allot_AutoMakeupAllot", parms);
            if (parms[6].Value.ToString().Equals("1"))
            {
                return dt;
            }
            return null;
        }


        /// <summary>
        /// 手工平均分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-02</remarks>
        public bool ManualAvgAllot(E_Allot data) {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int),
                 new SqlParameter("@Mode",SqlDbType.TinyInt),
                 new SqlParameter("@Status",SqlDbType.TinyInt),
                 new SqlParameter("@ObjIDs",SqlDbType.NVarChar),
                 new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)EnumClientMode.团队;
            parms[3].Value = (int)EnumClientStatus.待分配名录;
            parms[4].Value = data.ObjIDs;
            parms[5].Value = data.ClientInfoIDs;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Allot_ManualAvgAllot", parms, out ReturnValue);
            return ReturnValue>0;
        }
        /// <summary>
        /// 手工补差分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ManualMarkupAllot(E_Allot data) {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int),
                 new SqlParameter("@Mode",SqlDbType.TinyInt),
                 new SqlParameter("@Status",SqlDbType.TinyInt),
                 new SqlParameter("@ObjIDs",SqlDbType.NVarChar),
                 new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)EnumClientMode.团队;
            parms[3].Value = (int)EnumClientStatus.待分配名录;
            parms[4].Value = data.ObjIDs;
            parms[5].Value = data.ClientInfoIDs;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Allot_ManualMakeupAllot", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 手工按属性分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ManualPropertyAllot(E_Allot data) {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int),
                 new SqlParameter("@Mode",SqlDbType.TinyInt),
                 new SqlParameter("@Status",SqlDbType.TinyInt),
                 new SqlParameter("@ObjIDs",SqlDbType.NVarChar),
                 new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar),
                 new SqlParameter("@AllotType",SqlDbType.NVarChar,32)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)EnumClientMode.团队;
            parms[3].Value = (int)EnumClientStatus.待分配名录;
            parms[4].Value = data.ObjIDs;
            parms[5].Value = data.ClientInfoIDs;
            parms[6].Value = data.AllotType;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Allot_ManualPropertyAllot", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 手工指定分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-02</remarks>
        public bool ManualSpecifiedAllot(E_Allot data)
        {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int),
                 new SqlParameter("@Mode",SqlDbType.TinyInt),
                 new SqlParameter("@Status",SqlDbType.TinyInt),
                 new SqlParameter("@ObjID",SqlDbType.Int),
                 new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = (int)EnumClientMode.团队;
            parms[3].Value = (int)EnumClientStatus.待分配名录;
            parms[4].Value = data.ObjIDs;
            parms[5].Value = data.ClientInfoIDs;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Allot_ManualSpecifiedAllot", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 名录转移
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-07</remarks>
        public bool ShiftAllot(E_Allot data)
        {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int),
                 new SqlParameter("@ObjID",SqlDbType.Int),
                 new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = data.ObjIDs;
            parms[3].Value = data.ClientInfoIDs;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Allot_ShiftAllot", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        #endregion

        /// <summary>
        /// 查看已选择的名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-02</remarks>
        public DataTable ListResultSelect(E_Allot data)
        {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@ClientInfoIDs",SqlDbType .VarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoIDs;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfo_ListResultSelect", parms);
        }

        /// <summary>
        /// 名录分配统计
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-26</remarks>
        public DataTable AllotStatistics(E_Allot data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = data.Page.StartDate;
            parms[3].Value = data.Page.EndDate;
            parms[4].Value = data.Page.PageSize;
            parms[5].Value = data.Page.PageIndex;
            parms[6].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Allot_Statistics", parms);
            data.Page.TotalCount = Convert.ToInt32(parms[6].Value);
            return dt;
        }

        #region 自动分配 配置信息

        /// <summary>
        /// 修改自动分配配置信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-14</remarks>
        public bool UpdateAutoConfig(E_Allot data)
        {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int),
                 new SqlParameter("@Available",SqlDbType.TinyInt),
                 new SqlParameter("@Amount",SqlDbType.Int),
                 new SqlParameter("@Sort",SqlDbType.VarChar,32),
                 new SqlParameter("@Mode",SqlDbType.TinyInt),
                 new SqlParameter("@Cycle",SqlDbType.Int),
                 new SqlParameter("@AllotTime",SqlDbType.VarChar,8)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;
            parms[2].Value = data.Available;
            parms[3].Value = data.AllotAmount;
            parms[4].Value = data.AllotSort;
            parms[5].Value = (int)data.Mode;
            parms[6].Value = data.Cycle;
            parms[7].Value = data.AllotTime;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_AutoAllotConfig_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 获取自行分配配置信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-14</remarks>
        public E_Allot GetModelConfig(E_Allot data)
        {
            SqlParameter[] parms =
            {
                 new SqlParameter("@EnterpriseID",SqlDbType.Int),
                 new SqlParameter("@TeamID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.TeamID;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_AutoAllotConfig_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            { 
                DataRow row= dt.Rows[0];
                data.Available = Convert.ToInt32(row["Available"]);
                data.AllotAmount = Convert.ToInt32(row["Amount"]);
                data.AllotSort = row["Sort"].ToString();
                data.SetMode = Convert.ToInt32(row["Mode"]);
                data.Cycle = Convert.ToInt32(row["Cycle"]);
                data.AllotTime = row["AllotTime"].ToString();
                if(row["LastDate"] != DBNull.Value )
                    data.LastDate = Convert.ToDateTime(row["LastDate"]);
                data.NextDate = Convert.ToDateTime(row["NextDate"]);
                return data;
            }
            return null;
        }
        #endregion
    }
}
