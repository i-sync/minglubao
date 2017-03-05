using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal;

namespace MLMGC.IDAL.Personal
{
    /// <summary>
    /// 工作经验
    /// </summary>
    public interface I_D_JobExperience
    {
        /// <summary>
        /// 添加工作经验
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>
        bool Add(E_JobExperience data);

        /// <summary>
        /// 修改工作经验
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>
        bool Update(E_JobExperience data);

        /// <summary>
        /// 删除工作经验
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>
        bool Delete(E_JobExperience data);

        /// <summary>
        /// 查看工作经验列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>        
        DataTable GetList(E_JobExperience data);

        /// <summary>
        /// 获取工作经验对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>  
        E_JobExperience GetModel(E_JobExperience data);
    }
}
