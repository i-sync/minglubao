using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Personal.Config
{
    /// <summary>
    /// 行业属性
    /// </summary>
    [Serializable]
    public class E_Trade
    {
        private int _tradeid;
        private int _personalid;
        private string _tradecode;
        private string _tradename;
        private bool _codeisvalue = true;
        /// <summary>
        /// 行业编号
        /// </summary>
        public int TradeID
        {
            set { _tradeid = value; }
            get { return _tradeid; }
        }
        /// <summary>
        /// Personal.PersonalID
        /// </summary>
        public int PersonalID
        {
            set { _personalid = value; }
            get { return _personalid; }
        }
        /// <summary>
        /// 行业编码
        /// </summary>
        public string TradeCode
        {
            set { _tradecode = value; }
            get { return _tradecode; }
        }
        /// <summary>
        /// 行业编码 多个
        /// </summary>
        public string TradeCodeS { get; set; }
        /// <summary>
        /// 行业名称 多个
        /// </summary>
        public string TradeNameS { get; set; }
        /// <summary>
        /// 行业名称
        /// </summary>
        public string TradeName
        {
            set { _tradename = value; }
            get { return _tradename; }
        }
        /// <summary>
        /// 编码做为值(默认：true)
        /// </summary>
        public bool CodeIsValue
        {
            set { _codeisvalue = value; }
            get { return _codeisvalue; }
        }
    }
}
