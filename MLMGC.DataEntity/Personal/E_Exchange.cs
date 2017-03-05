using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Personal
{
    /// <summary>
    /// 名录沟通记录
    /// </summary>
    [Serializable]
    public class E_Exchange
    {
        /// <summary>
        /// Personal.PersonalID
        /// </summary>
        public int PersonalID { get; set; }
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
        public DateTime ExchangeDate { get; set; }
    }
}
