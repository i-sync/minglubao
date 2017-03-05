using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.User
{
    /// <summary>
    /// 个人信息
    /// </summary>
    public class E_Personal :E_PersonalUser
    {
        private System.Guid? _uid;
        private string _emailcode;
        private string _realname;
        private int _sex;
        private string _mobile;
        private string _tel;
        private string _fax;
        private string _address;
        private string _avatar;
        

        /// <summary>
        /// GUID
        /// </summary>
        public Guid? UID
        {
            get { return _uid; }
            set { _uid = value; }
        }
        /// <summary>
        /// 验证码
        /// </summary>
        public string EmailCode
        {
            get { return _emailcode; }
            set { _emailcode = value; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            get { return _realname; }
            set { _realname = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// 个人用户头像
        /// </summary>
        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }      
                
        /// <summary>
        /// 个人邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 个人名录数量
        /// </summary>
        public int ClientNum { get; set; }

        #region 2012-03-09添加如下字段
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Birthday { get; set; }

        private EnumWorkYear _workyears;
        /// <summary>
        /// 工作年限
        /// </summary>
        public EnumWorkYear WorkYears { get { return _workyears; } }
        public int SetWorkYears
        {
            set
            {
                switch (value)
                { 
                    case 0:
                        _workyears = EnumWorkYear.无;
                        break;
                    case 1:
                        _workyears = EnumWorkYear.一年以上;
                        break;
                    case 2:
                        _workyears = EnumWorkYear.二年以上;
                        break;
                    case 3:
                        _workyears = EnumWorkYear.三年以上;
                        break;
                    case 4:
                        _workyears = EnumWorkYear.五年以上;
                        break;
                    case 5:
                        _workyears = EnumWorkYear.八年以上;
                        break;
                    case 6:
                        _workyears = EnumWorkYear.十年以上;
                        break;
                }
            }
        }
        /// <summary>
        /// 居住地
        /// </summary>
        public int CityID { get; set; }
        /// <summary>
        /// 户口所在地
        /// </summary>
        public int HuKouCityID { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord { get; set; }

        private EnumMarital _maritalstatus;
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public EnumMarital MaritalStatus { get { return _maritalstatus; } }
        public int SetMaritalStatus
        {
            set
            {
                if (value == 0)
                    _maritalstatus = EnumMarital.未婚;
                else
                    _maritalstatus = EnumMarital.已婚;
            }
        }

        #endregion

        #region     2012-05-09
        /// <summary>
        /// 个人用户是否已经加入项目组
        /// </summary>
        private EnumItemFlag _itemflag;
        public EnumItemFlag ItemFlag { get { return _itemflag; } set { _itemflag = value; } }

        public int SetItemFlag
        {
            set 
            {
                switch (value)
                { 
                    case 0:
                        _itemflag = EnumItemFlag.未加入项目;
                        break;
                    case 1:
                        _itemflag = EnumItemFlag.已经加入项目;
                        break;
                }
            }
        }
        #endregion

        private E_Page _page = new E_Page();
        /// <summary>
        /// 数据分页
        /// </summary>
        public E_Page Page { get { return _page; } set { _page = value; } }
    }

    /// <summary>
    /// 工作年限
    /// </summary>
    public enum EnumWorkYear
    { 
        无=0,
        一年以上=1,
        二年以上=2,
        三年以上=3,
        五年以上=4,
        八年以上=5,
        十年以上=6
    }

    /// <summary>
    /// 婚姻状况
    /// </summary>
    public enum EnumMarital
    { 
        未婚=0,
        已婚=1
    }

    /// <summary>
    /// 标识个人用户是否已经加入项目
    /// </summary>
    public enum EnumItemFlag
    { 
        未加入项目=0,
        已经加入项目=1
    }
}
