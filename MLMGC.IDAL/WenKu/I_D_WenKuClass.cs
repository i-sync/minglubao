using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.WenKu;
namespace MLMGC.IDAL.WenKu
{
    /// <summary>
    /// 文库分类
    /// </summary>
    public interface I_D_WenKuClass
    {
        /// <summary>
        /// 添加文库分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        bool Add(E_WenKuClass data);

        /// <summary>
        /// 修改文库分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        bool Update(E_WenKuClass data);
        /// <summary>
        /// 添加文库分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        bool Delete(E_WenKuClass data);
        /// <summary>
        /// 查询文库分类对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        E_WenKuClass GetModel(E_WenKuClass data);
        /// <summary>
        /// 获取所有文库分类
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        DataTable GetList();
    }
}
