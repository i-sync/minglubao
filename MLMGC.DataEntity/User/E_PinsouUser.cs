using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.User
{
    /// <summary>
    /// 品搜用户信息
    /// </summary>
    [Serializable]
    public class E_PinsouUser
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 品搜用户编号
        /// </summary>
        public long Pinsou_UserID { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int mlb_UserID { get; set; }
        /// <summary>
        /// 个人编号 
        /// </summary>
        public int PersonalID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 邮箱 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
    }
}
