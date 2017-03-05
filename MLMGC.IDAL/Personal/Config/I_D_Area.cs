using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal.Config;

namespace MLMGC.IDAL.Personal.Config
{
    /// <summary>
    /// 地区属性接口
    /// </summary>
    public interface I_D_Area
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(E_Area data);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(E_Area data);
        /// <summary>
        /// 批量增加地区
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        bool BatchAdd(E_Area data);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(E_Area data);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(E_Area data);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        E_Area GetModel(E_Area data);
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetPageList(E_Area data);
        /// <summary>
        /// 获取绑定显示的列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetShowList(E_Area data);
    }
}
