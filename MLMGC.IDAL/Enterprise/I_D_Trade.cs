using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 行业属性接口
    /// </summary>
    public interface I_D_Trade
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(E_Trade data);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(E_Trade data);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(E_Trade data);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(E_Trade data);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        E_Trade GetModel(E_Trade data);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_Trade data);
        /// <summary>
        /// 获取绑定显示的列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetShowList(E_Trade data);
    }
}
