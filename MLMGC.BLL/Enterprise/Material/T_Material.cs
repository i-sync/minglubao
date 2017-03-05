using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Material;

namespace MLMGC.BLL.Enterprise.Material
{
    /// <summary>
    /// 项目资料
    /// </summary>
    public class T_Material
    {
        MLMGC.IDAL.Enterprise.Material.I_D_Material dal = MLMGC.DALFactory.Enterprise.Material.F_D_Material.Create();

        /// <summary>
        /// 增加项目资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(E_Material data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 更新项目资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(E_Material data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 删除项目资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Delete(E_Material data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 得到项目资料对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Material GetModel(E_Material data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 得到项目资料列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Material data)
        {
            return dal.GetList(data);
        }

        /// <summary>
        /// 企业资料共享
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-16</remarks>
        public bool Share(E_Material data)
        {
            return dal.Share(data);
        }
    }
}
