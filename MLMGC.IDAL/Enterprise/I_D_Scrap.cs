using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 报废理由
    /// </summary>
    public interface I_D_Scrap
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(E_Scrap data);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(E_Scrap data);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(E_Scrap data);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(E_Scrap data);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        E_Scrap GetModel(E_Scrap data);
        /// <summary>
        ///无分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_Scrap data);
    }
}
