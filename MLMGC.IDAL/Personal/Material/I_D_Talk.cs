using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal.Material;

namespace MLMGC.IDAL.Personal.Material
{
    /// <summary>
    /// 个人话术
    /// </summary>
    public interface I_D_Talk
    {
        /// <summary>
        /// 增加一条话术
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Add(E_Talk data);
        /// <summary>
        /// 更新一条话术
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(E_Talk data);
        /// <summary>
        /// 删除话术
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Delete(E_Talk data);
        /// <summary>
        /// 得到一个话术对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Talk GetModel(E_Talk data);
        /// <summary>
        /// 获取话术列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_Talk data);
    }
}
