using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.DataEntity.Item
{
    /// <summary>
    /// 项目名录
    /// </summary>
    public class E_ItemClientInfo
    {
        private int _enterpriseid;
        private int _clientinfoid;
        private int _userid;
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
        private string _sourcecode;
        private string _tradecode;
        private string _areacode;

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
            set { _clientinfoid = value; }
            get { return _clientinfoid; }
        }

        /// <summary>
        /// 名录编号字符串
        /// </summary>
        public string ClientInfoIDs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 个人编号
        /// </summary>
        public int PersonalID { get; set; }

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
        /// 判断类型0=名录名称，1=手机，2=电话
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 对应的值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 来源名称
        /// </summary>
        public string SourceCode
        {
            set { _sourcecode = value; }
            get { return _sourcecode; }
        }
        /// <summary>
        /// 行业名称
        /// </summary>
        public string TradeCode
        {
            set { _tradecode = value; }
            get { return _tradecode; }
        }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string AreaCode
        {
            set { _areacode = value; }
            get { return _areacode; }
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

        private EnumClientStatus _tarstatus;
        /// <summary>
        /// 目标名录状态
        /// </summary>
        public EnumClientStatus TarStatus { get { return _tarstatus; } set { _tarstatus = value; } }
        public int SetTarStatus
        {
            set
            {
                switch (value)
                {
                    case 0:
                        _tarstatus = EnumClientStatus.待分配名录;
                        break;
                    case 1:
                        _tarstatus = EnumClientStatus.潜在客户;
                        break;
                    case 2:
                        _tarstatus = EnumClientStatus.意向客户;
                        break;
                    case 3:
                        _tarstatus = EnumClientStatus.成交客户;
                        break;
                    case 4:
                        _tarstatus = EnumClientStatus.失败客户;
                        break;
                    case 5:
                        _tarstatus = EnumClientStatus.报废客户;
                        break;
                    case 6:
                        _tarstatus = EnumClientStatus.共享;
                        break;
                    default:
                        _tarstatus = EnumClientStatus.所有状态;
                        break;
                }
            }
        }

        /// <summary>
        /// 分页参数
        /// </summary>
        public E_Page Page { get; set; }

        public int EPUserMTRID { get; set; }
        public int TeamID { get; set; }
        /// <summary>
        /// 转换名录数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 是否导入沟通记录：0＝不导入，1＝导入
        /// </summary>
        public int IsExchange { get; set; }
    }
    /// <summary>
    /// 名录状态
    /// </summary>
    public enum EnumClientStatus
    {
        所有状态 = -1,
        待分配名录 = 0,
        潜在客户 = 1,
        意向客户 = 2,
        成交客户 = 3,
        失败客户 = 4,
        报废客户 = 5,
        共享=6
    }
}
