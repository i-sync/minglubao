using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Enterprise.Config;

namespace MLMGC.BLL.Enterprise.Config
{
    /// <summary>
    /// 企业最低标准
    /// </summary>
    public class T_Standard
    {
        MLMGC.IDAL.Enterprise.Config.I_D_Standard dal = MLMGC.DALFactory.Enterprise.Config.F_D_Standard.Create();

        /// <summary>
        /// 添加或更新最低标准
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(E_Standard data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 查询企业最低标准
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Standard GetModel(E_Standard data)
        {
            return dal.GetModel(data);
        }
    }
}
