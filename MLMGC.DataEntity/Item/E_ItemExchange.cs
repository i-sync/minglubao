using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Item
{
    /// <summary>
    /// 项目名录沟通
    /// </summary>
    public class E_ItemExchange
    {
        /// <summary>
        /// 企业号
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 名录编号
        /// </summary>
        public int ClientInfoID { get; set; }
        /// <summary>
        /// 沟通内容
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// 沟通日期
        /// </summary>
        public DateTime AddDate { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string RealName { get; set; }
    }
}
