using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Item;

namespace MLMGC.IDAL.Item
{
    /// <summary>
    /// 沟通记录
    /// </summary>
    public interface I_D_ItemExchange
    {
        /// <summary>
        /// 添加沟通记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        E_ItemExchange Add(E_ItemExchange data);

        /// <summary>
        /// 获取沟通记录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        DataTable GetList(E_ItemExchange data);
    }
}
