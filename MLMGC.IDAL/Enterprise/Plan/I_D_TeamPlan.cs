using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Plan;

namespace MLMGC.IDAL.Enterprise.Plan
{
    public interface I_D_TeamPlan
    {
        /// <summary>
        /// 添加或修改团队计划
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        bool Update(E_TeamPlan data);

        /// <summary>
        /// 查询团队计划
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_TeamPlan GetModel(E_TeamPlan data);

        /// <summary>
        /// 获取团队计划数据列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-11</remarks>
        DataTable GetTeamPlan(E_TeamPlan data);
        /// <summary>
        /// 获取团队实际数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-11</remarks>
        DataTable GetTeamReal(E_TeamPlan data);
        /// <summary>
        /// 获取团队某月实际数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-11</remarks>
        DataTable GetTeamRealMonth(E_TeamPlan data);
    }
}
