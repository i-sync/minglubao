using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 团队设置
    /// </summary>
    [Serializable]
    public class E_Team
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 团队角色编号
        /// </summary>
        public int TeamModelRoleID { get; set; }
        /// <summary>
        /// 团队编号
        /// </summary>
        public int? TeamID { get; set; }
        /// <summary>
        /// 团队名称
        /// </summary>
        public string TeamName { get; set; }
        /// <summary>
        /// 团队口号
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 上级编号 Team.TeamID
        /// </summary>
        public int? PID { get; set; }
    }
}
