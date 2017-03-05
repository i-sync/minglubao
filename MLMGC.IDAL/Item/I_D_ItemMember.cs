using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Item;

namespace MLMGC.IDAL.Item
{
    /// <summary>
    /// 项目人员
    /// </summary>
    public interface I_D_ItemMember
    {
        /// <summary>
        /// 获取该项目的人员列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        DataTable GetMemberList(E_ItemMember data);

        /// <summary>
        /// 总监删除个人用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-18</remarks>
        bool Delete(E_ItemMember data);
    }
}
