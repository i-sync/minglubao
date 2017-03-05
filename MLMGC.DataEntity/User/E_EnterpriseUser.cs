using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.User
{
    /// <summary>
    /// 企业用户登录验证信息实体
    /// </summary>
    [Serializable]
    public class E_EnterpriseUser
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 登录帐号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 企业编号
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 用户角色信息
        /// </summary>
        public int EPUserTMRID { get; set; }
        /// <summary>
        /// 团队编号
        /// </summary>
        public int TeamID { get; set; }
        /// <summary>
        /// D_Role.RoleID
        /// </summary>
        public int RoleID { get; set; }
    }
}
