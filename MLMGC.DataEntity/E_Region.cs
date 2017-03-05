using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity
{
    /// <summary>
    /// 地区
    /// </summary>
    public class E_Region
    {
        /// <summary>
        /// 地区编号
        /// </summary>
        public int RegionID { get; set; }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public string Selected { get; set; }
     
        /// <summary>
        /// 子节点
        /// </summary>
        public List<E_Region> List { get; set; }
    }
}
