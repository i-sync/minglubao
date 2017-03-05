using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Item
{
    /// <summary>
    /// 项目申请
    /// </summary>
    public class E_ItemApply
    {
        /// <summary>
        /// 申请编号
        /// </summary>
        public int ApplyID { get; set; }

        /// <summary>
        /// 企业号
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public int ItemID { get; set; }
        /// <summary>
        /// User.UserID 
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 项目申请状态
        /// </summary>
        private EnumApply _status;
        public EnumApply Status { get { return _status; } set { _status = value;} }
        public int SetStatus
        {
            set
            {
                switch (value)
                { 
                    case -1:
                        _status = EnumApply.全部;
                        break;
                    case 0:
                        _status = EnumApply.未查看;
                        break;
                    case 1:
                        _status = EnumApply.申请通过;
                        break;
                    case 2:
                        _status = EnumApply.申请未通过;
                        break;
                    case 3:
                        _status = EnumApply.已加入项目;
                        break;
                }
            }
        }

        /// <summary>
        /// 申请类型：1=申请加入，2=申请退出
        /// </summary>
        private EnumApplyType _applytype ;
        public EnumApplyType ApplyType
        {
            get { return _applytype; }
            set { _applytype = value; }
        }

        /// <summary>
        /// 退出原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 数据分页
        /// </summary>
        public E_Page Page { get; set; }
    }

    /// <summary>
    /// 项目申请状态
    /// </summary>
    public enum EnumApply
    { 
        全部=-1,
        未查看=0,
        申请通过=1,
        申请未通过=2,
        已加入项目=3
    }
    
    /// <summary>
    /// 申请类型：1=申请加入，2=申请退出
    /// </summary>
    public enum EnumApplyType
    {
        申请加入=1,
        申请退出=2
    }
}
