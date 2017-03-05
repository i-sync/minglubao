using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 名录属性配置
    /// </summary>
    public interface I_D_Property
    {
        /// <summary>
        /// 获取名录属性配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Property Get(E_Property data);
        /// <summary>
        /// 设置名录属性配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Set(E_Property data);
    }
}
