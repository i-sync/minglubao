using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Item
{
    /// <summary>
    /// 项目成员
    /// </summary>
    public class E_ItemMember
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int MemberID { get; set; }

        /// <summary>
        /// Enterprise.EnterpriseID
        /// </summary>
        public int EnterpriseID { get; set; }

        /// <summary>
        /// Item.ItemID
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        /// User.UserID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string RealName { get; set; }
    }
}
