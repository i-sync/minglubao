using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity .Enterprise.Material;

namespace MLMGC.IDAL.Enterprise.Material
{
    /// <summary>
    /// 企业话术
    /// </summary>
    public interface I_D_Talk
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Add(E_Talk data);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(E_Talk data);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Delete(E_Talk data);
        /// <summary>
        /// 得到一个实例对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Talk GetModel(E_Talk data);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_Talk data);
    }
}
