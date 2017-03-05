using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.IDAL.Item;
using MLMGC.DataEntity.Item;

namespace MLMGC.BLL.Item
{
    /// <summary>
    /// 项目申请
    /// </summary>
    public class T_ItemApply
    {
        I_D_ItemApply dal = MLMGC.DALFactory.Item.F_D_ItemApply.Create();
        /// <summary>
        /// 添加个人申请
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-09</remarks>
        public bool Add(E_ItemApply data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 总监申述个人申请
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-09</remarks>
        public int Update(E_ItemApply data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 查看申请列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-09</remarks>
        public DataTable GetList(E_ItemApply data)
        {
            return dal.GetList(data);
        }

        /// <summary>
        /// 判断是否已经过申请该项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 20012-05-10</remarks>
        public bool Exists(E_ItemApply data)
        {
            return dal.Exists(data);
        }
    }
}
