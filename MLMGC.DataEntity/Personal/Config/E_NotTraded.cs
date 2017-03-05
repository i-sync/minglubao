using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Personal.Config
{
    /// <summary>
    /// 失败理由
    /// </summary>
    [Serializable]
    public class E_NotTraded
    {
        private int _nottradedid;
        private int _personalid;
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
        /// Personal.PersonalID
        /// </summary>
        public int PersonalID
        {
            set { _personalid = value; }
            get { return _personalid; }
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
