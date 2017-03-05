using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise.Config
{
    /// <summary>
    /// 企业最低标准
    /// </summary>
    [Serializable]
    public class E_Standard
    {
        private int _enterpriseid;
        private int _newamount;
        private int _commamount;
        private int _tradedamount;
        private float _tradedmoney;
               
        /// <summary>
        /// Enterprise.EnterpriseID
        /// </summary>
        public int EnterpriseID
        {
            get { return _enterpriseid; }
            set { _enterpriseid = value; }
        }
        /// <summary>
        /// 录入数量
        /// </summary>
        public int NewAmount
        {
            get { return _newamount; }
            set { _newamount = value; }
        }
        /// <summary>
        /// 沟通数量
        /// </summary>
        public int CommAmount
        {
            get { return _commamount; }
            set { _commamount = value; }
        }

        /// <summary>
        /// 交易数量
        /// </summary>
        public int TradedAmount
        {
            get { return _tradedamount; }
            set { _tradedamount = value; }
        }

        /// <summary>
        /// 交易金额
        /// </summary>
        public float TradedMoney
        {
            get { return _tradedmoney; }
            set { _tradedmoney = value; }
        }
    }
}
