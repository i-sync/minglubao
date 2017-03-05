using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Material;

namespace MLMGC.IDAL.Enterprise.Material
{
    /// <summary>
    /// 学习资料
    /// </summary>
    public interface I_D_StudyMaterial
    {
        /// <summary>
        /// 增加学习资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Add(E_StudyMaterial data);
        /// <summary>
        /// 更新学习资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(E_StudyMaterial data);
        /// <summary>
        /// 删除学习资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Delete(E_StudyMaterial data);
        /// <summary>
        /// 得到一个学习资料对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_StudyMaterial GetModel(E_StudyMaterial data);
        /// <summary>
        /// 获取学习资料列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_StudyMaterial data);
    }
}
