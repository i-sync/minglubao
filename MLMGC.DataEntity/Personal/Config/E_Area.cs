﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Personal.Config
{
    /// <summary>
    /// 地区属性
    /// </summary>
    [Serializable]
    public class E_Area
    {
        private int _areaid;
        private int _personalid;
        private string _areacode;
        private string _areaname;
        private E_Page _page = new E_Page();
        private bool _codeisvalue = true;
        /// <summary>
        /// 地区编号
        /// </summary>
        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
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
        /// 地区编码
        /// </summary>
        public string AreaCode
        {
            set { _areacode = value; }
            get { return _areacode; }
        }
        /// <summary>
        /// 地区编码 多个
        /// </summary>
        public string AreaCodeS { get; set; }
        /// <summary>
        /// 地区名称 多个
        /// </summary>
        public string AreaNameS { get; set; }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string AreaName
        {
            set { _areaname = value; }
            get { return _areaname; }
        }
        /// <summary>
        /// 编码做为值(默认：true)
        /// </summary>
        public bool CodeIsValue
        {
            set { _codeisvalue = value; }
            get { return _codeisvalue; }
        }
        /// <summary>
        /// 分页参数
        /// </summary>
        public E_Page Page
        {
            set { _page = value; }
            get { return _page; }
        }
    }
}
