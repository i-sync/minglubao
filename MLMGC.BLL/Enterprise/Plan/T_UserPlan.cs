using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Enterprise.Plan;
using System.Data;

namespace MLMGC.BLL.Enterprise.Plan
{
    /// <summary>
    /// 个人计划
    /// </summary>
    public class T_UserPlan
    {
        MLMGC.IDAL.Enterprise.Plan.I_D_UserPlan dal = MLMGC.DALFactory.Enterprise.Plan.F_D_UserPlan.Create();

        /// <summary>
        /// 修改或添加个人计划
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-01</remarks>
        public bool Update(E_UserPlan data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 查询个人计划
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-01</remarks>
        public E_UserPlan GetModel(E_UserPlan data)
        {
            return dal.GetModel(data);
        }
        /// <summary>
        /// 获取用户指定天的数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-09</remarks>
        public DataTable UserDaily(E_UserPlan data)
        {
            return dal.UserDaily(data);
        }

        /// <summary>
        /// 获取用户指定月的数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-09</remarks>
        public DataTable UserMonth(E_UserPlan data)
        {
            return dal.UserMonth(data);
        }

         /// <summary>
        /// 获取用户指定月的详细数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-10</remarks>
        public DataTable UserMonthDetail(E_UserPlan data)
        {
            return dal.UserMonthDetail(data);
        }
    }
}
