using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal;

namespace MLMGC.IDAL.Personal
{
    /// <summary>
    /// 名录沟通记录
    /// </summary>
    public interface I_D_Exchange
    {
        /// <summary>
        /// 添加沟通记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        bool Add(E_Exchange data);

        /// <summary>
        /// 获取名录沟通列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        DataTable GetList(E_Exchange data);
    }
}
