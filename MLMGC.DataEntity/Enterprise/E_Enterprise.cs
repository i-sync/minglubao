using System;
using System.Collections.Generic;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 企业信息实体
    /// </summary>
    [Serializable]
    public class E_Enterprise
    {
        private int _enterpriseid;
        private string _enterprisecode;
        private string _enterprisenames;
        private string _itemname;
        private string _linkman;
        private string _position;
        private string _tel;
        private string _mobile;
        private string _fax;
        private int _status;
        private string _email;
        private string _address;
        private int? _useramount;
        private DateTime? _adddate;
        private DateTime? _startdate;
        private DateTime? _expiredate;
        
        private string _adminusername;
        private string _adminpassword;
        /// <summary>
        /// 企业编号
        /// </summary>
        public int EnterpriseID
        {
            set { _enterpriseid = value; }
            get { return _enterpriseid; }
        }
        /// <summary>
        /// 企业号
        /// </summary>
        public string EnterpriseCode
        {
            set { _enterprisecode = value; }
            get { return _enterprisecode; }
        }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string EnterpriseNames
        {
            set { _enterprisenames = value; }
            get { return _enterprisenames; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName
        {
            set { _itemname = value; }
            get { return _itemname; }
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
        /// 企业状态
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
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
        /// 企业地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 最大用户数量
        /// </summary>
        public int? UserAmount
        {
            set { _useramount = value; }
            get { return _useramount; }
        }
        /// <summary>
        /// 开通日期
        /// </summary>
        public DateTime? AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime? StartDate
        {
            set { _startdate = value; }
            get { return _startdate; }
        }
        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime? ExpireDate
        {
            set { _expiredate = value; }
            get { return _expiredate; }
        }
        /// <summary>
        /// 管理员用户名
        /// </summary>
        public string AdminUserName {
            set { _adminusername = value; }
            get { return _adminusername; }
        }
        /// <summary>
        /// 管理员密码
        /// </summary>
        public string AdminPassword
        {
            set { _adminpassword = value; }
            get { return _adminpassword; }
        }

        /// <summary>
        /// 企业用户实际数量
        /// </summary>
        public int UserNum
        {
            get;
            set;
        }

        /// <summary>
        /// 企业名录数量
        /// </summary>
        public int ClientNum
        {
            get;
            set;
        }

        /// <summary>
        /// 分布处理
        /// </summary>
        public E_Page Page { get; set; }
    }
}
