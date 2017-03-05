using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 名录沟通记录
    /// </summary>
    public interface I_D_Exchange
    {
        /// <summary>
        /// 录入新沟通记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-14</remarks>
        bool Add(E_Exchange data);
        /// <summary>
        /// 获取名录下的沟通列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-14</remarks>
        DataTable GetList(E_Exchange data);
    }
}
