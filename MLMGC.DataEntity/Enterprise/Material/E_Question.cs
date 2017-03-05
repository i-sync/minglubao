using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise.Material
{
    /// <summary>
    /// 调查问题
    /// </summary>
    [Serializable]
    public class E_Question
    {
        private int _questionid;
        private int _enterpriseid;
        private string _questionname;
        private int _questiontype;
        private DateTime _updatedate;
        private List<E_QuestionItem> _questionitem;
        /// <summary>
        /// Enterprise.EnterpriseID
        /// </summary>
        public int EnterpriseID
        {
            get { return _enterpriseid; }
            set { _enterpriseid = value; }
        }

        /// <summary>
        /// 名录编号
        /// </summary>
        public int ClientInfoID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int EPUserTMRID
        {
            get;
            set;
        }
        /// <summary>
        /// 问题答案编号
        /// </summary>
        public string QuestionItemIDs
        {
            get;
            set;
        }
        /// <summary>
        /// 标识是否删除问题与名录的关系
        /// </summary>
        public int Flag
        {
            get;
            set;
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
        /// 问题名称
        /// </summary>
        public string QuestionName
        {
            get { return _questionname; }
            set { _questionname = value; }
        }
        /// <summary>
        /// 问题类型
        /// </summary>
        public int QuestionType
        {
            get { return _questiontype; }
            set { _questiontype = value; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _updatedate; }
            set { _updatedate = value; }
        }
        /// <summary>
        /// 问题选项集合
        /// </summary>
        public List<E_QuestionItem> QuestionItem
        {
            get { return _questionitem; }
            set { _questionitem = value; }
        }
        /// <summary>
        /// 分页
        /// </summary>
        public E_Page Page
        {
            get;
            set;
        }

    }

    /// <summary>
    /// 问题类型
    /// </summary>
    public enum EnumQuestionType
    { 
        单选=1,
        多选=2
    }
}
