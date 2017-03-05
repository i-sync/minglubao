using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Personal.Config
{
    /// <summary>
    /// 意向进展
    /// </summary>
    [Serializable]
    public class E_Wish
    {
        private int _wishid;
        private int _personalid;
        private string _wishname;
        private int _wishpercent;
        /// <summary>
        /// 意向编号
        /// </summary>
        public int WishID
        {
            set { _wishid = value; }
            get { return _wishid; }
        }
        /// <summary>
        /// Enterprise.EnterpriseID
        /// </summary>
        public int PersonalID
        {
            set { _personalid = value; }
            get { return _personalid; }
        }
        /// <summary>
        /// 意向名称
        /// </summary>
        public string WishName
        {
            set { _wishname = value; }
            get { return _wishname; }
        }
        /// <summary>
        /// 意向百分比
        /// </summary>
        public int WishPercent
        {
            set { _wishpercent = value; }
            get { return _wishpercent; }
        }
    }
}
