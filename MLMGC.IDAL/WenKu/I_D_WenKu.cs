using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.WenKu;

namespace MLMGC.IDAL.WenKu
{
    /// <summary>
    /// 文库
    /// </summary>
    public interface I_D_WenKu
    {
        /// <summary>
        /// 判断文档是否已经存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-21</remarks>
        bool Exists(E_WenKu data);

        /// <summary>
        /// 添加文档
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        bool Add(E_WenKu data);

        /// <summary>
        /// 获取文档的对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        E_WenKu GetModel(E_WenKu data);

        /// <summary>
        /// 获取文档列表 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        DataTable GetList(E_WenKu data);

        /// <summary>
        /// 后台管理员审核文档
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        bool UpdateStatus(E_WenKu data);

        /// <summary>
        /// 后台管理员删除审核未通过或下线文库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        bool Delete(E_WenKu data);

        /// <summary>
        /// 后台管理员批量删除审核未通过或下线文库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        DataTable BatchDelete(E_WenKu data);

        /// <summary>
        /// 获取要转换的文库列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-22</remarks>
        DataTable ConvertList(E_WenKu data);

        /// <summary>
        /// 修改浏览次数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-22</reamrks>
        bool UpdateBrowser(E_WenKu data);
    }
}
