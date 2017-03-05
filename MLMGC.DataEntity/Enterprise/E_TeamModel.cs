using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 团队模型
    /// </summary>
    [Serializable]
    public class E_TeamModel
    {
        /// <summary>
        /// 团队模型编号
        /// </summary>
        public int TeamModelID { get; set; }
        /// <summary>
        /// 企业编号
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 团队模型设置
        /// </summary>
        public string TeamScaleXml { get; set; }
        /// <summary>
        /// 潜在客户共享天数设置
        /// </summary>
        public int? LatenDay { get; set; }
        /// <summary>
        /// 意向客户转为失败客户天数 设置
        /// </summary>
        public int? WishDay { get; set; }
        /// <summary>
        /// 共享潜在客户提前天数
        /// </summary>
        public int? LRemindDay { get; set; }
        /// <summary>
        /// 共享意向客户提前天数
        /// </summary>
        public int? WRemindDay { get; set; }
        /// <summary>
        /// 失败编号
        /// </summary>
        public int? NotTradedID { get; set; }

        /// <summary>
        /// 团队角色信息
        /// </summary>
        public string Child_RoleID { get; set; }
        /// <summary>
        /// 团队角色数量
        /// </summary>
        public string Child_RoleAmount { get; set; }
    }
}
