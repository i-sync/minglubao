using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.WenKu;
using MLMGC.IDAL.WenKu;
using MLMGC.DALFactory.WenKu;

namespace MLMGC.BLL.WenKu
{
    /// <summary>
    /// 文库分类 
    /// </summary>
    public class T_WenKuClass
    {
        I_D_WenKuClass dal = F_D_WenKuClass.Create();


        /// <summary>
        /// 添加文库分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public bool Add(E_WenKuClass data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 修改文库分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public bool Update(E_WenKuClass data)
        {
            return dal.Update(data);
        }
        /// <summary>
        /// 添加文库分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public bool Delete(E_WenKuClass data)
        {
            return dal.Delete(data);
        }
        /// <summary>
        /// 查询文库分类对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-19</remarks>
        public E_WenKuClass GetModel(E_WenKuClass data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 获取所有文库分类
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public DataTable GetList()
        {
            return dal.GetList();
        }
    }
}
