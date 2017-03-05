/*----------------------------------------------------------------
    // Copyright (C) 2004 北京红手网络技术有限公司 
    // 版权所有。 
    //
    // 文件名：E_Apply.cs
    // 文件功能描述：企业申请信息实体
    // 创建标识：齐鹏飞20110916
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 企业申请信息
    /// </summary>
    [Serializable]
    public class E_Apply
    {
        #region Model
        private int _applyid;
        private string _enterprisename;
        private string _address;
        private string _linkman;
        private string _position;
        private string _tel;
        private string _email;
        private string _mobile;
        private string _fax;
        private int? _useramount;
        private int? _deadline;
        private DateTime? _adddate;
        /// <summary>
        /// 申请编号
        /// </summary>
        public int ApplyID
        {
            set { _applyid = value; }
            get { return _applyid; }
        }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string EnterpriseName
        {
            set { _enterprisename = value; }
            get { return _enterprisename; }
        }
        /// <summary>
        /// 企业地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Linkman
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 职务
        /// </summary>
        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 购买用户数量
        /// </summary>
        public int? UserAmount
        {
            set { _useramount = value; }
            get { return _useramount; }
        }
        /// <summary>
        /// 购买期限（单位：月）
        /// </summary>
        public int? Deadline
        {
            set { _deadline = value; }
            get { return _deadline; }
        }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime? AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        private E_Page _page;
        /// <summary>
        /// 数据分页
        /// </summary>
        public E_Page Page 
        {
            get { return _page; }
            set { _page = value; }
        }
        #endregion Model
    }
}
