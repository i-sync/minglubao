using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 名录沟通记录实体
    /// </summary>
    [Serializable]
    public class E_Exchange
    {
        private int _enterpriseid;
        private int? _epusertmrid;
        /// <summary>
        /// 企业编号
        /// </summary>
        public int EnterpriseID
        {
            set { _enterpriseid = value; }
            get { return _enterpriseid; }
        }
        /// <summary>
        /// 名录项目编号
        /// </summary>
        public int ClientInfoID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户模型角色编号
        /// </summary>
        public int? EPUserTMRID
        {
            set { _epusertmrid = value; }
            get { return _epusertmrid; }
        }
        /// <summary>
        /// 沟通内容
        /// </summary>
        public string Detail { get; set; }
        public string UserInfo { get; set; }
        /// <summary>
        /// 沟通时间
        /// </summary>
        public DateTime? ExchangeDate { get; set; }
    }
}
