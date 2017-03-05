using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 企业项目
    /// </summary>
    public class E_Item
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int ItemID { get; set; }
        /// <summary>
        /// 企业号
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 项目标题
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 项目简介
        /// </summary>
        public string ItemIntro { get; set; }

        /// <summary>
        /// 口号
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 项目内容
        /// </summary>
        public string ItemContent { get; set; }

        /// <summary>
        /// 项目状态
        /// </summary>
        private ItemStatus _status;
        /// <summary>
        /// 状态
        /// </summary>
        public ItemStatus Status { get { return _status; } set { _status = value; } }

        public int SetStatus
        {
            set
            {
                switch (value)
                { 
                    case 0:
                        _status = ItemStatus.未公开;
                        break;
                    case 1:
                        _status = ItemStatus.公开;
                        break;
                }
            }
        }

        /// <summary>
        /// 使用标识：0=未开通，1=已开通
        /// </summary>
        private ItemOpenFlag _openflag;
        public ItemOpenFlag OpenFlag { get { return _openflag; } set { _openflag = value; } }

        public int SetOpenFlag
        {
            set 
            {
                if (value == 0)
                    _openflag = ItemOpenFlag.未开通;
                else
                    _openflag = ItemOpenFlag.已开通;
            }
        }

        /// <summary>
        /// 项目图片
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// 项目成立时间
        /// </summary>
        public DateTime Established { get; set; }

        /// <summary>
        /// 所在城市编号
        /// </summary>
        public int CityID { get; set; }

        /// <summary>
        /// 数据分页
        /// </summary>
        public E_Page Page { get; set; }
    }

    /// <summary>
    /// 项目申核状态
    /// </summary>
    public enum ItemStatus
    {
        未公开=0,
        公开=1
    }

    /// <summary>
    /// 项目是否在开通
    /// </summary>
    public enum ItemOpenFlag
    { 
        未开通=0,
        已开通=1
    }
}
