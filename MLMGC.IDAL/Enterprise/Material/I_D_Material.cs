using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DataEntity.Enterprise.Material;

namespace MLMGC.IDAL.Enterprise.Material
{
    /// <summary>
    /// 项目资料
    /// </summary>
    public interface I_D_Material
    {
        /// <summary>
        /// 增加项目资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Add(E_Material data);
        /// <summary>
        /// 更新项目资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(E_Material data);
        /// <summary>
        /// 删除项目资料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Delete(E_Material data);
        /// <summary>
        /// 得到一个项目资料对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Material GetModel(E_Material data);
        /// <summary>
        /// 获取项目资料列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_Material data);


        /// <summary>
        /// 企业资料共享
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-16</remarks>
        bool Share(E_Material data);
    }
}
