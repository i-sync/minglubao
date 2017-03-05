using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal.Config;

namespace MLMGC.IDAL.Personal.Config
{
    /// <summary>
    /// 失败理由
    /// </summary>
    public interface I_D_NotTraded
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(E_NotTraded data);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(E_NotTraded data);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(E_NotTraded data);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(E_NotTraded data);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        E_NotTraded GetModel(E_NotTraded data);
        /// <summary>
        ///无分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_NotTraded data);
    }
}
