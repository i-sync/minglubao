using System;
using System.Collections.Generic;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 报废理由
    /// </summary>
    [Serializable]
    public class E_Scrap
    {
        private int _scrapid;
        private int? _enterpriseid;
        private string _scrapname;
        /// <summary>
        /// 报废编号
        /// </summary>
        public int ScrapID
        {
            set { _scrapid = value; }
            get { return _scrapid; }
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
        /// 报废名称
        /// </summary>
        public string ScrapName
        {
            set { _scrapname = value; }
            get { return _scrapname; }
        }
    }
}
