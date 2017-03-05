using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise.Plan
{
    /// <summary>
    /// 团队计划
    /// </summary>
    public class E_TeamPlan
    {
        /// <summary>
        /// Enterprise.EnterpiseID
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int EPUserTMRID { get; set; }
        /// <summary>
        /// 团队计划编号 
        /// </summary>
        public int TeamPlanID { get; set; }
        /// <summary>
        /// 团队编号 
        /// </summary>
        public int TeamID { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>
        public DateTime YearMonty { get; set; }
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
