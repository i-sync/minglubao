using System;
using System.Collections.Generic;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 来源属性设置
    /// </summary>
    [Serializable]
    public class E_Source
    {
        private int _sourceid;
        private int? _enterpriseid;
        private string _sourcecode;
        private string _sourcename;
        private int? _putin;
        private string _intro;
        private bool _codeisvalue=true;
        /// <summary>
        /// 来源编号
        /// </summary>
        public int SourceID
        {
            set { _sourceid = value; }
            get { return _sourceid; }
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
        /// 来源编码
        /// </summary>
        public string SourceCode
        {
            set { _sourcecode = value; }
            get { return _sourcecode; }
        }
        /// <summary>
        /// 来源名称
        /// </summary>
        public string SourceName
        {
            set { _sourcename = value; }
            get { return _sourcename; }
        }
        /// <summary>
        /// 投入
        /// </summary>
        public int? Putin
        {
            set { _putin = value; }
            get { return _putin; }
        }
        /// <summary>
        /// 简介
        /// </summary>
        public string Intro
        {
            set { _intro = value; }
            get { return _intro; }
        }
        /// <summary>
        /// 编码做为值(默认：ture)
        /// </summary>
        public bool CodeIsValue
        {
            set { _codeisvalue = value; }
            get { return _codeisvalue; }
        }
    }
}
