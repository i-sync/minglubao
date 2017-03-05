using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Personal.Config;

namespace MLMGC.DataEntity.Personal
{
    /// <summary>
    /// 个人名录信息
    /// </summary>
    [Serializable]
    public class E_ClientInfo
    {
        private int _clientinfoid;
        private int _personalid;
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
        private string _sourcename;
        private string _tradename;
        private string _areaname;
        /// <summary>
        /// 名录编号
        /// </summary>
        public int ClientInfoID
        {
            set { _clientinfoid = value; }
            get { return _clientinfoid; }
        }

        /// <summary>
        /// 名录编号字符串
        /// </summary>
        public string ClientInfoIDs { get; set; }
        
        /// <summary>
        /// Personal.PersonalID
        /// </summary>
        public int PersonalID
        {
            set { _personalid = value; }
            get { return _personalid; }
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
        /// 判断类型1=手机，2=电话
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 手机或电话的值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 来源名称
        /// </summary>
        public string SourceName
        {
            set { _sourcename = value; }
            get { return _sourcename; }
        }
        /// <summary>
        /// 行业名称
        /// </summary>
        public string TradeName
        {
            set { _tradename = value; }
            get { return _tradename; }
        }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string AreaName
        {
            set { _areaname = value; }
            get { return _areaname; }
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
                    default:
                        _status = EnumClientStatus.所有状态;
                        break;
                }
            }
        }
       
        /// <summary>
        /// 分页参数
        /// </summary>
        public E_Page Page { get; set; }
    }    
    /// <summary>
    /// 名录状态
    /// </summary>
    public enum EnumClientStatus
    {
        所有状态 = 0,
        潜在客户 = 1,
        意向客户 = 2,
        成交客户 = 3,
        失败客户 = 4,
        报废客户 = 5
    }
}
