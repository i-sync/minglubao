using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity;

namespace MLMGC.BLL
{
    /// <summary>
    /// 问题反馈
    /// </summary>
    public class T_Feedback
    {
        MLMGC.IDAL.I_D_Feedback dal = MLMGC.DALFactory.F_D_Feedback.Create();

        /// <summary>
        /// 添加问题反馈
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(E_Feedback data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 查看反馈信息详情 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Feedback GetModel(E_Feedback data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 查看反馈信息列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Feedback data)
        {
            return dal.GetList(data);
        }
    }
}
