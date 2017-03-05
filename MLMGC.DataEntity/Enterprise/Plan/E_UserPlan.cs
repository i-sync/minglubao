using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise.Plan
{
    /// <summary>
    /// 个人计划
    /// </summary>
    public class E_UserPlan
    {
        /// <summary>
        /// Enterprise.EnterpiseID
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 编号 
        /// </summary>
        public int EPUserTMRID { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>
        public DateTime YearMonty { get; set; }
        /// <summary>
        /// 录入新的名录数
        /// </summary>
        public int NewAmount { get; set; }
        /// <summary>
        /// 沟通名录数量
        /// </summary>
        public int ContactAmount { get; set; }
        /// <summary>
        /// 交易数量
        /// </summary>
        public int TradedAmount { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public float TradedMoney { get; set; }
    }
}
