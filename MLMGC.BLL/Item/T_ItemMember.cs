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
    /// 项目人员
    /// </summary>
    public class T_ItemMember
    {
        I_D_ItemMember dal = MLMGC.DALFactory.Item.F_D_ItemMember.Create();

        /// <summary>
        /// 获取该项目的人员列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable GetMemberList(E_ItemMember data)
        {
            return dal.GetMemberList(data);
        }

        /// <summary>
        /// 总监删除个人用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-18</remarks>
        public bool Delete(E_ItemMember data)
        {
            return dal.Delete(data);
        }
    }
}
