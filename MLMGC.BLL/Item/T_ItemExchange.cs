using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Item;
using MLMGC.IDAL.Item;

namespace MLMGC.BLL.Item
{
    /// <summary>
    /// 沟通记录
    /// </summary>
    public class T_ItemExchange
    {
        I_D_ItemExchange dal = MLMGC.DALFactory.Item.F_D_ItemExchange.Create();

        /// <summary>
        /// 添加沟通记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public E_ItemExchange Add(E_ItemExchange data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 获取沟通记录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable GetList(E_ItemExchange data)
        {
            return dal.GetList(data);
        }
    }
}
