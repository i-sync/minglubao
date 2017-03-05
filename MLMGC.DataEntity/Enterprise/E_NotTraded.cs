using System;
using System.Collections.Generic;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 失败理由
    /// </summary>
    [Serializable]
    public class E_NotTraded
    {
        private int _nottradedid;
        private int? _enterpriseid;
        private string _nottradedname;
        /// <summary>
        /// 失败编号
        /// </summary>
        public int NotTradedID
        {
            set { _nottradedid = value; }
            get { return _nottradedid; }
        }
        /// <summary>
        /// Enterprise.EnterpriseID
        /// </summary>
        public int? EnterpriseID
        {
            set { _enterpriseid = value; }
            get { return _enterpriseid; }
        }
        /// <summary>
        /// 失败名称
        /// </summary>
        public string NotTradedName
        {
            set { _nottradedname = value; }
            get { return _nottradedname; }
        }
    }
}
