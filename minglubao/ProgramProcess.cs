using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DBUtility;
using System.IO;
using System.Configuration;

namespace minglubao
{
    /// <summary>
    /// 程序处理
    /// </summary>
    public class ProgramProcess
    {

        public ProgramProcess()
        {
        }
        E_Allot _data = null;
        public ProgramProcess(E_Allot data)
        {
            _data = data;
        }

        #region 共享客户、失败客户
        /// <summary>
        /// 执行共享处理
        /// </summary>
        public void Share()
        {
            //datatable获取所有的企业号EnterpriseID
            DataTable dt = MLMGC.DBUtility.DbHelperSQL.RunProcedureTable("ProcServices_B_Enterprise_Select");
            int enterpriseid;
            //循环遍历所有的企业
            foreach (DataRow row in dt.Rows)
            {
                enterpriseid = Convert.ToInt32(row["EnterpriseID"]);
                ShareProcess(enterpriseid);
            }
        }
        /// <summary>
        /// 处理指定企业共享客户数据
        /// </summary>
        /// <param name="EnterpriseID">企业编号</param>
        protected void ShareProcess(int EnterpriseID)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = EnterpriseID;
            int ReturnValue;
            MLMGC.DBUtility.DbHelperSQL.RunProcedures("ProcServices_B_ClientItem_Share", parms, out ReturnValue);
            new Log().WriteLog("企业号：" + EnterpriseID.ToString() + " 共享结果：" + ReturnValue);
        }
        #endregion

        #region 自动分配   qipengfei 2012-01-14
        
        /// <summary>
        /// 处理某一小组自动分配功能
        /// </summary>
        /// <param name="enterpriseId">企业号</param>
        /// <param name="teamId">小组编号</param>
        /// <param name="amount">分配数量</param>
        /// <param name="sort">排序</param>
        /// <param name="mode">分配方式</param>
        public void AutoAllotProcess()
        {
            int ret = -100;
            string info = string.Empty;
            switch (_data.Mode)
            {
                case EnumMode.行业分配:
                case EnumMode.地区分配:
                case EnumMode.来源分配://属性分配
                    ret = AutoAllotProperty(_data);
                    //修改自动分配配置表中的上次和下次的时间
                    UpdateAutoAllotConfigDate(_data);
                    switch (ret)
                    { 
                        case -3:
                            info = "总监取消了该属性,所以不能按该属性分配";
                            break;
                        case -2:
                            info = "判断分配方式不合法";
                            break;
                        case -1:
                            info = "分配配置信息不存在";
                            break;
                        case 0:
                            info = "属性分配失败";
                            break;
                        case 1:
                            info = "属性分配成功";
                            break;
                        default:
                            info = "returnValue："+ret.ToString();
                            break;
                    }
                    break;
                case EnumMode.平均分配://平均分配
                    ret = AutoAllotAvg(_data);
                    //修改自动分配配置表中的上次和下次的时间
                    UpdateAutoAllotConfigDate(_data);
                    break;
                case EnumMode.补差分配://补差分配
                    ret = AutoAllotMarkup(_data);
                    //修改自动分配配置表中的上次和下次的时间
                    UpdateAutoAllotConfigDate(_data);
                    break;
                default://找不到分配方式
                    info="找不到分配方案";
                    break;
            }
            //new Log().WriteLog("分配编号："+_data.AutoAllotConfigID.ToString()+","+info+" 结果："+ ret>0?"成功":"失败");
            new Log().WriteLog(string.Format("分配编号：{0}。结果：分配{1}。详细：{2}",_data.AutoAllotConfigID,ret>0?"成功":"失败",info));
        }
        /// <summary>
        /// 按属性分配
        /// </summary>
        /// <param name="data"></param>
        protected int AutoAllotProperty(E_Allot data)
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

            int returnValue = -1;
            DbHelperSQL.RunProcedures("ProcEP_B_Allot_AutoPropertyAllot", parms, out returnValue);
            return returnValue;
        }

        /// <summary>
        /// 自动平均分配
        /// </summary>
        public int AutoAllotAvg(E_Allot data)
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

            int returnValue = -1;
            DbHelperSQL.RunProcedures("ProcEP_B_Allot_AutoAvgAllot", parms, out returnValue);
            return returnValue;
        }
        /// <summary>
        /// 自动补差分配
        /// </summary>
        public  int AutoAllotMarkup(E_Allot data)
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

            int returnValue = -1;
            DbHelperSQL.RunProcedures("ProcEP_B_Allot_AutoMakeupAllot", parms, out returnValue);
            return returnValue;
        }

        /// <summary>
        /// 修改自动分配配置表中的上次和下次的时间
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int UpdateAutoAllotConfigDate(E_Allot data)
        {
            SqlParameter[] parms = 
            { 
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@AutoAllotConfig", SqlDbType.Int) 
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.AutoAllotConfigID;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_AutoAllotConfig_UpdateDate", parms, out ReturnValue);
            return ReturnValue;
        }

        #endregion
        
    }
}
