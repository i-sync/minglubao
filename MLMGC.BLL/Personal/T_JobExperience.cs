using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal;
using MLMGC.BLL.Personal;
using MLMGC.DALFactory.Personal;
using MLMGC.IDAL.Personal;

namespace MLMGC.BLL.Personal
{
    public class T_JobExperience
    {
        I_D_JobExperience dal = F_D_JobExperience.Create();
        /// <summary>
        /// 添加工作经验
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>
        public bool Add(E_JobExperience data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 修改工作经验
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>
        public bool Update(E_JobExperience data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 删除工作经验
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>
        public bool Delete(E_JobExperience data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 查看工作经验列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>        
        public DataTable GetList(E_JobExperience data)
        {
            return dal.GetList(data);
        }

        /// <summary>
        /// 获取工作经验对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>  
        public E_JobExperience GetModel(E_JobExperience data)
        {
            return dal.GetModel(data);
        }
    }
}
