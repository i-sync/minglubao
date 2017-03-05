using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Personal.Config
{
    /// <summary>
    /// 报废理由
    /// </summary>
    [Serializable]
    public class E_Scrap
    {
        private int _scrapid;
        private int _personalid;
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
        /// Personal.PersonalID
        /// </summary>
        public int PersonalID
        {
            set { _personalid = value; }
            get { return _personalid; }
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
