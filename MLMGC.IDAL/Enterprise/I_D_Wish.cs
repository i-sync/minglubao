using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 意向进展
    /// </summary>
    public interface I_D_Wish
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(E_Wish data);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(E_Wish data);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(E_Wish data);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(E_Wish data);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        E_Wish GetModel(E_Wish data);
        /// <summary>
        ///获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_Wish data);
    }
}
