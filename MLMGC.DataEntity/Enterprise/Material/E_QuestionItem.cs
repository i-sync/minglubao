using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise.Material
{
    /// <summary>
    /// 问题选项
    /// </summary>
    [Serializable]
    public class E_QuestionItem
    {
        private long _questionitemid;
        private int _enterpriseid;
        private int _questionid;
        private string _questionitemname;
        /// <summary>
        /// 问题选项编号
        /// </summary>
        public long QuestionItemID
        {
            get { return _questionitemid; }
            set { _questionitemid = value; }
        }

        /// <summary>
        /// Enterprise.EnterpriseID
        /// </summary>
        public int EnterpriseID
        {
            get { return _enterpriseid; }
            set { _enterpriseid = value; }
        }
        /// <summary>
        /// 问题编号
        /// </summary>
        public int QuestionID
        {
            get { return _questionid; }
            set { _questionid = value; }
        }
        /// <summary>
        /// 问题选项名称
        /// </summary>
        public string QuestionItemName
        {
            get { return _questionitemname; }
            set { _questionitemname = value; }
        }

        /// <summary>
        /// 标识该选项是否为选中
        /// </summary>
        public bool Flag
        {
            get;
            set;
        }
    }
}
