using System;
using System.Collections.Generic;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 名录信息
    /// </summary>
    [Serializable]
    public class E_ClientInfo
    {
        private int _clientinfoid;
        private int? _enterpriseid;
        private string _clientname;
        private string _address;
        private string _zipcode;
        private string _linkman;
        private string _position;
        private string _tel;
        private string _mobile;
        private string _fax;
        private string _website;
        private string _email;
        private string _qq;
        private string _msn;
        private string _remark;
        private int? _userid;
        private int? _epusertmrid;
        private string _sourcecode;
        private string _tradecode;
        private string _areacode;
        /// <summary>
        /// 名录编号
        /// </summary>
        public int ClientInfoID
        {
            set { _clientinfoid = value; }
            get { return _clientinfoid; }
        }
        
        /// <summary>
        /// 名录项目编号
        /// </summary>
        public string ClientInfoIDs { get; set; }
        /// <summary>
        /// Enterprise.EnterpriseID
        /// </summary>
        public int? EnterpriseID
        {
            set { _enterpriseid = value; }
            get { return _enterpriseid; }
        }
        /// <summary>
        /// 名录名称
        /// </summary>
        public string ClientName
        {
            set { _clientname = value; }
            get { return _clientname; }
        }
        /// <summary>
        /// 名录地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string ZipCode
        {
            set { _zipcode = value; }
            get { return _zipcode; }
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
        /// 职位
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
        /// 网址
        /// </summary>
        public string Website
        {
            get { return _website; }
            set { _website = value; }
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
        /// QQ
        /// </summary>
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }    
        }
        /// <summary>
        /// MSN
        /// </summary>
        public string MSN
        {
            get { return _msn; }
            set { _msn = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// User.UserID
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 所在团队编号
        /// </summary>
        public int? TeamID { get; set; }
        /// <summary>
        /// 用户模型角色编号
        /// </summary>
        public int? EPUserTMRID
        {
            set { _epusertmrid = value; }
            get { return _epusertmrid; }
        }
        /// <summary>
        /// 查看团队的编号
        /// </summary>
        public int? LookTeamID { get; set; }
        /// <summary>
        /// 来源编号
        /// </summary>
        public int? SourceID { get; set; }
        /// <summary>
        /// 地区编号
        /// </summary>
        public int? AreaID { get; set; }
        /// <summary>
        /// 行业编号
        /// </summary>
        public int? TradeID { get; set; }
        /// <summary>
        /// 意向编号
        /// </summary>
        public int? WishID { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        public float? TradedMoney { get; set; }
        /// <summary>
        /// 失败编号
        /// </summary>
        public int? NotTradedID { get; set; }
        /// <summary>
        /// 报废编号
        /// </summary>
        public int? ScrapID { get; set; }
        /// <summary>
        /// 来源编码
        /// </summary>
        public string SourceCode
        {
            set { _sourcecode = value; }
            get { return _sourcecode; }
        }
        /// <summary>
        /// 行业编码
        /// </summary>
        public string TradeCode
        {
            set { _tradecode = value; }
            get { return _tradecode; }
        }
        /// <summary>
        /// 地区编码
        /// </summary>
        public string AreaCode
        {
            set { _areacode = value; }
            get { return _areacode; }
        }
        private EnumClientMode _mode;
        /// <summary>
        /// 位置
        /// </summary>
        public EnumClientMode Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        /// <summary>
        /// 检索关键字
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 预留字段
        /// </summary>
        public string Fields { get; set; }

        public int SetMode
        {
            set
            {
                switch (value)
                {
                    case 1:
                        _mode = EnumClientMode.团队;
                        break;
                    case 2:
                        _mode = EnumClientMode.共享;
                        break;
                    default:
                        _mode = EnumClientMode.业务员;
                        break;
                }
            }
        }
        private EnumClientStatus _status;
        /// <summary>
        ///状态
        /// </summary>
        public EnumClientStatus Status { get { return _status; } set { _status = value; } }
        /// <summary>
        /// 通过状态值设置状态
        /// </summary>
        public int SetStatus
        {
            set
            {
                switch (value)
                {
                    case 0:
                        _status = EnumClientStatus.待分配名录;
                        break;
                    case 1:
                        _status = EnumClientStatus.潜在客户;
                        break;
                    case 2:
                        _status = EnumClientStatus.意向客户;
                        break;
                    case 3:
                        _status = EnumClientStatus.成交客户;
                        break;
                    case 4:
                        _status = EnumClientStatus.失败客户;
                        break;
                    case 5:
                        _status = EnumClientStatus.报废客户;
                        break;
                    case 6:
                        _status = EnumClientStatus.共享;
                        break;
                    default:
                        _status = EnumClientStatus.所有状态;
                        break;
                }
            }
        }
        private E_Property _property;
        /// <summary>
        /// 名录属性配置
        /// </summary>
        public E_Property Property
        {
            set { _property = value; }
            get { return _property; }
        }
        /// <summary>
        /// 分页参数
        /// </summary>
        public E_Page Page { get; set; }
    }
    /// <summary>
    /// 名录位置
    /// </summary>
    public enum EnumClientMode
    {
        业务员 = 0,
        团队 = 1,
        共享 = 2
    }
    /// <summary>
    /// 名录状态
    /// </summary>
    /// <remarks>企业名录数据导出时，使用了该枚举</remarks>
    public enum EnumClientStatus
    {
        所有状态 = -1,
        待分配名录 = 0,
        潜在客户 = 1,
        意向客户 = 2,
        成交客户 = 3,
        失败客户 = 4,
        报废客户 = 5,
        共享 = 6
    }

    /// <summary>
    /// 名录操作状态
    /// </summary>
    public enum EnumOperateType
    { 
        录入=1,
        分配=2,
        更改状态=3,
        共享=4,
        还原=5
    }
}
