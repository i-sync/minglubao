using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.IDAL.WenKu;
using MLMGC.DataEntity.WenKu;
using MLMGC.DALFactory.WenKu;

namespace MLMGC.BLL.WenKu
{
    /// <summary>
    /// 文库
    /// </summary>
    public class T_WenKu
    {
        I_D_WenKu dal = F_D_WenKu.Create();

        /// <summary>
        /// 判断文档是否已经存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns>true:存在，false:不存在</returns>
        /// <remarks>tianzhenyun 2012-03-21</remarks>
        public bool Exists(E_WenKu data)
        {
            return dal.Exists(data);
        }

        /// <summary>
        /// 添加文档
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public bool Add(E_WenKu data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 获取文档的对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public E_WenKu GetModel(E_WenKu data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 获取文档列表 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public DataTable GetList(E_WenKu data)
        {
            return dal.GetList(data) ;
        }

        /// <summary>
        /// 后台管理员审核文档
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public bool UpdateStatus(E_WenKu data)
        {
            return dal.UpdateStatus(data);
        }

        /// <summary>
        /// 后台管理员删除审核未通过或下线文库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public bool Delete(E_WenKu data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 后台管理员批量删除审核未通过或下线文库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public DataTable BatchDelete(E_WenKu data)
        {
            return dal.BatchDelete(data);
        }

        /// <summary>
        /// 获取要转换的文库列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-22</remarks>
        public DataTable ConvertList(E_WenKu data)
        {
            return dal.ConvertList(data);
        }

        /// <summary>
        /// 修改浏览次数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-22</reamrks>
        public bool UpdateBrowser(E_WenKu data)
        {
            return dal.UpdateBrowser(data);
        }
    }
}
