using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Item;

namespace MLMGC.IDAL.Item
{
    /// <summary>
    /// 项目申请
    /// </summary>
    public interface I_D_ItemApply
    {
        /// <summary>
        /// 添加个人申请
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-09</remarks>
        bool Add(E_ItemApply data);

        /// <summary>
        /// 总监申述个人申请
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-09</remarks>
        int Update(E_ItemApply data);

        /// <summary>
        /// 查看申请列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-09</remarks>
        DataTable GetList(E_ItemApply data);

        /// <summary>
        /// 判断是否已经过申请该项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 20012-05-10</remarks>
        bool Exists(E_ItemApply data);
    }
}
