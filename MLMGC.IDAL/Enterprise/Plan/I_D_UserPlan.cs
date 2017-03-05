using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Plan;

namespace MLMGC.IDAL.Enterprise.Plan
{
    public interface I_D_UserPlan
    {
        /// <summary>
        /// 添加或修改个人计划
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(E_UserPlan data);

        /// <summary>
        /// 查询个人计划
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_UserPlan GetModel(E_UserPlan data);

        /// <summary>
        /// 获取用户指定天的数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-09</remarks>
        DataTable UserDaily(E_UserPlan data);
        /// <summary>
        /// 获取用户指定月的数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-09</remarks>
        DataTable UserMonth(E_UserPlan data);
        /// <summary>
        /// 获取用户指定月的详细数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-10</remarks>
        DataTable UserMonthDetail(E_UserPlan data);
    }
}
