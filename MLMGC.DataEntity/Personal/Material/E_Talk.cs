using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Personal.Material
{
    /// <summary>
    /// 个人话术
    /// </summary>
    [Serializable]
    public class E_Talk
    {
        private int _talkid;
        private int _personalid;
        private string _talksubject;
        private string _detail;
        private DateTime _adddate;
        private int _sort;

        /// <summary>
        /// 话术编号
        /// </summary>
        public int TalkID
        {
            get { return _talkid; }
            set { _talkid = value; }
        }
        /// <summary>
        /// Personal.PersonalID
        /// </summary>
        public int PersonalID
        {
            get { return _personalid; }
            set { _personalid = value; }
        }
        /// <summary>
        /// 话术标题
        /// </summary>
        public string TalkSubject
        {
            get { return _talksubject; }
            set { _talksubject = value; }
        }
        /// <summary>
        /// 话术内容
        /// </summary>
        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }
        /// <summary>
        /// 话术添加时间
        /// </summary>
        public DateTime AddDate
        {
            get { return _adddate; }
            set { _adddate = value; }
        }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
    }
}
