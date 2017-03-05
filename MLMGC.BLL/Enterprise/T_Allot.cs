using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;
using System.Data;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 名录分配
    /// </summary>
    public class T_Allot
    {
        MLMGC.IDAL.Enterprise.I_D_Allot dal = MLMGC.DALFactory.Enterprise.F_D_Allot.Create();

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-27</remarks>
        public bool Update(E_Allot data)
        {
            return dal.Update(data);
        }
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-28</remarks>
        public DataSet Select(E_Allot data)
        {
            return dal.Select(data);
        }
        /// <summary>
        /// 自动分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-01</remarks>
        public DataTable AutoAllot(E_Allot data)
        {
            DataTable dt = null;
            switch (data.Mode)
            {
                case EnumMode.行业分配:
                case EnumMode.地区分配:
                case EnumMode.来源分配:
                    dt= dal.AutoPropertyAllot(data);
                    break;
                case EnumMode.平均分配:
                    dt=dal.AutoAvgAllot(data);
                    break;
                case EnumMode.补差分配:
                    dt = dal.AutoMarkupAllot(data);
                    break;
                default:
                    break;
            }
            return dt;
        }
        /// <summary>
        /// 手工分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-02</remarks>
        public bool ManualAllot(E_Allot data)
        {
            bool b = false;
            switch (data.AllotType)
            {
                case "trade":
                case "area":
                case "source":
                    b = dal.ManualPropertyAllot(data);
                    break;
                case "avg":
                    b = dal.ManualAvgAllot(data);
                    break;
                case "makeup":
                    b = dal.ManualMarkupAllot(data);
                    break;
                case "specified":
                    b = dal.ManualSpecifiedAllot(data);
                    break;
                default:
                    break;
            }
            return b;
        }
        /// <summary>
        /// 名录转移
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-07</remarks>
        public bool ShiftAllot(E_Allot data)
        {
            return dal.ShiftAllot(data);
        }

        /// <summary>
        /// 查看已选择的名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-02</remarks>
        public DataTable ListResultSelect(E_Allot data)
        {
            return dal.ListResultSelect(data);
        }

        /// <summary>
        /// 名录分配统计
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-26</remarks>
        public DataTable AllotStatistics(E_Allot data)
        {
            return dal.AllotStatistics(data);
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
            return dal.UpdateAutoConfig(data);
        }
        /// <summary>
        /// 获取自行分配配置信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-14</remarks>
        public E_Allot GetModelConfig(E_Allot data)
        {
            return dal.GetModelConfig(data);
        }
        #endregion
    }
}
