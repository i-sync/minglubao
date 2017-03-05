using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise.Material
{
    /// <summary>
    /// 学习资料
    /// </summary>
    [Serializable]
    public class E_StudyMaterial
    {
        private long _studymaterialid;
        private int _enterpriseid;
        private string _materialname;
        private DateTime _updatedate;
        private E_StudyMateFile _studymatefile;
        /// <summary>
        /// 学习资料编号
        /// </summary>
        public long StudyMaterialID
        {
            get { return _studymaterialid; }
            set { _studymaterialid = value; }
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
        /// 学习资料标题
        /// </summary>
        public string MaterialName
        {
            get { return _materialname; }
            set { _materialname = value; }
        }
       
        /// <summary>
        /// 学习资料更新时间
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _updatedate; }
            set { _updatedate = value; }
        }
        
        /// <summary>
        /// 学习资料附件
        /// </summary>
        public E_StudyMateFile StudyMateFile
        {
            get { return _studymatefile; }
            set { _studymatefile = value; }
        }

        /// <summary>
        /// 分页参数
        /// </summary>
        public E_Page Page { get; set; }
    }
}
