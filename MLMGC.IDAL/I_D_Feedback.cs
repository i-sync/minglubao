using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity;

namespace MLMGC.IDAL
{
    /// <summary>
    /// 问题反馈
    /// </summary>
    public interface I_D_Feedback
    {
        /// <summary>
        /// 添加问题反馈信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Add(E_Feedback data);

        /// <summary>
        /// 查看反馈信息详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Feedback GetModel(E_Feedback data);
        /// <summary>
        /// 管理员查看反馈信息列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_Feedback data);
    }
}