using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Enterprise.Config;

namespace MLMGC.IDAL.Enterprise.Config
{
    public interface I_D_Standard
    {
        /// <summary>
        /// 添加或修改企业最低标准
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(E_Standard data);
        /// <summary>
        /// 查询企业最低标准
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Standard GetModel(E_Standard data);
    }
}
