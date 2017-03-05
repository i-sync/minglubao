using System;
using System.Collections.Generic;

namespace MLMGC.DataEntity.Enterprise
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
        /// 企业编号
        /// </summary>
        public int EnterpriseID { get; set; }
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
        启用=1,
        禁用=0
    }
}
