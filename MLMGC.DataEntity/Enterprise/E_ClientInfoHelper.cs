using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 名录辅助操作
    /// </summary>
    [Serializable]
    public class E_ClientInfoHelper
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        public int? EnterpriseID { get; set; }
        /// <summary>
        /// 名录项目编号
        /// </summary>
        public int? ClientInfoID { get; set; }
        /// <summary>
        /// 名录项目编号  多个
        /// </summary>
        public string ClientInfoIDs { get; set; }
        /// <summary>
        /// 企业用户角色
        /// </summary>
        public int? EPUserTMRID { get; set; }
        /// <summary>
        /// 团队编号
        /// </summary>
        public int? TeamID { get; set; }
        public int? TeamModelRoleID { get; set; }
        public string Flag { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public uint? Status { get; set; }
        /// <summary>
        /// 是否为预约
        /// </summary>
        public bool? IsReservation { get; set; }

        /// <summary>
        /// 是否锁定：1=锁定，0=解锁
        /// </summary>
        public int IsLock { get; set; }

        /// <summary>
        /// 标识是手机还是电话：1=手机，2=电话
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 手机或电话的值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 数据分页
        /// </summary>
        public E_Page Page { get; set; }
    }
}
