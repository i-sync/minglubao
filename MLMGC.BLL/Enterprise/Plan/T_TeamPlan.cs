using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Plan;

namespace MLMGC.BLL.Enterprise.Plan
{
    /// <summary>
    /// 团队计划
    /// </summary>
    public class T_TeamPlan
    {
        MLMGC.IDAL.Enterprise.Plan.I_D_TeamPlan dal = MLMGC.DALFactory.Enterprise.Plan.F_D_TeamPlan.Create();

        /// <summary>
        /// 修改或添加团队计划
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-01</remarks>
        public bool Update(E_TeamPlan data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 查询团队计划
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-01</remarks>
        public E_TeamPlan GetModel(E_TeamPlan data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 获取团队计划数据列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-11</remarks>
        public DataTable GetTeamPlan(E_TeamPlan data)
        {
            return dal.GetTeamPlan(data);
        }

        /// <summary>
        /// 获取团队计划和实际数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-11</remarks>
        public DataTable GetTeamReal(E_TeamPlan data)
        {
            return dal.GetTeamReal(data);
        }

        /// <summary>
        /// 获取团队某月实际数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-11</remarks>
        public DataTable GetTeamRealMonth(E_TeamPlan data)
        {
            return dal.GetTeamRealMonth(data);
        }
    }
}
