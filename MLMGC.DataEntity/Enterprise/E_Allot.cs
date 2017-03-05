using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 名录分配
    /// </summary>
    [Serializable]
    public class E_Allot
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        public int? EnterpriseID { get; set; }
        /// <summary>
        /// 团队编号
        /// </summary>
        public int? TeamID { get; set; }
        /// <summary>
        /// 限制数量
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// 分配数量
        /// </summary>
        public int? AllotAmount { get; set; }
        /// <summary>
        /// 对象编号
        /// </summary>
        public string ObjIDs { get; set; }
        /// <summary>
        /// 行业
        /// </summary>
        public string TradeS { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string AreaS { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string SourceS { get; set; }
        /// <summary>
        /// 分配方式
        /// </summary>
        public string AllotType { get; set; }

        /// <summary>
        /// 排列方式
        /// </summary>
        public string AllotSort { get; set; }
        /// <summary>
        /// 自动分配编号
        /// </summary>
        public int? AutoAllotConfigID { get; set; }

        /// <summary>
        /// 分配类型
        /// </summary>
        private EnumMode _mode;
        public EnumMode Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public int SetMode
        {
            set
            {
                switch (value)
                {
                    case 1:
                        _mode = EnumMode.指定分配;
                        break;
                    case 2:
                        _mode = EnumMode.平均分配;
                        break;
                    case 3:
                        _mode = EnumMode.补差分配;
                        break;
                    case 4:
                        _mode = EnumMode.行业分配;
                        break;
                    case 5:
                        _mode = EnumMode.地区分配;
                        break;
                    case 6:
                        _mode = EnumMode.来源分配;
                        break;
                    default:
                        _mode =EnumMode.NULL;
                        break;
                }
            }
        }

        /// <summary>
        /// 是否启用自动分配：0=禁用，1=启用
        /// </summary>
        public int Available { get; set; }

        /// <summary>
        /// 自动分配循环周期
        /// </summary>
        public int Cycle { get; set; }

        /// <summary>
        /// 自动分配时间
        /// </summary>
        public string AllotTime { get; set; }

        /// <summary>
        /// 上次执行时间
        /// </summary>
        public DateTime? LastDate { get; set; }

        /// <summary>
        /// 下次执行时间
        /// </summary>
        public DateTime? NextDate { get; set; }

        /// <summary>
        /// 名录编号字符串
        /// </summary>
        public string ClientInfoIDs { get; set; }

        /// <summary>
        /// 数据分布
        /// </summary>
        public E_Page Page { get; set; }
    }


    public enum EnumType
    {
        手动分配 = 1,
        自动分配 = 2
    }

    public enum EnumMode
    {
        NULL = -1,
        指定分配 = 1,
        平均分配 = 2,
        补差分配 = 3,
        行业分配 = 4,
        地区分配 = 5,
        来源分配 = 6
    }
}
