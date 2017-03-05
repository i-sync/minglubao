using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Personal.Config
{
    /// <summary>
    /// 名录属性配置
    /// </summary>
    [Serializable]
    public class E_Property
    {
        public E_Property()
        {
            SourceFlag = EnumPropertyEnabled.禁用;
            AreaFlag = EnumPropertyEnabled.禁用;
            TradeFlag = EnumPropertyEnabled.禁用;
        }
        /// <summary>
        /// 名录属性配置编号
        /// </summary>
        public int PropertyConfigID { get; set; }
        /// <summary>
        /// 个人编号
        /// </summary>
        public int PersonalID { get; set; }
        /// <summary>
        /// 来源启用标识
        /// </summary>
        public EnumPropertyEnabled SourceFlag { get; set; }
        /// <summary>
        /// 行业启用标识
        /// </summary>
        public EnumPropertyEnabled TradeFlag { get; set; }
        /// <summary>
        /// 地区启用标识
        /// </summary>
        public EnumPropertyEnabled AreaFlag { get; set; }
    }
    /// <summary>
    /// 属性启用
    /// </summary>
    public enum EnumPropertyEnabled
    {
        启用 = 1,
        禁用 = 0
    }
}
