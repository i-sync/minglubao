using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Material;

namespace MLMGC.BLL.Enterprise.Material
{
    /// <summary>
    /// 学习资料
    /// </summary>
    public class T_StudyMaterial
    {
        MLMGC.IDAL.Enterprise.Material.I_D_StudyMaterial dal = MLMGC.DALFactory.Enterprise.Material.F_D_StudyMaterial.Create();

        /// <summary>
        /// 增加学习资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(E_StudyMaterial data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 更新学习资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(E_StudyMaterial data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 删除学习资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Delete(E_StudyMaterial data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 得到学习资料对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_StudyMaterial GetModel(E_StudyMaterial data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 得到学习资料列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_StudyMaterial data)
        {
            return dal.GetList(data);
        }
    }
}
