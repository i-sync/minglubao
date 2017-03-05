using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Material;

namespace MLMGC.IDAL.Enterprise.Material
{
    /// <summary>
    /// 问题
    /// </summary>
    public interface I_D_Question
    {
        /// <summary>
        /// 增加问题
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Add(E_Question data);
        /// <summary>
        /// 更新问题
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(E_Question data);
        /// <summary>
        /// 删除问题
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Delete(E_Question data);
        /// <summary>
        /// 得到一个问题对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Question GetModel(E_Question data);
        /// <summary>
        /// 获取问题列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_Question data);

        /// <summary>
        /// 获取问题列表（根据ClientItemID来判断问题的答案）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataSet List(E_Question data);

        /// <summary>
        /// 更新调查问卷答案
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        bool UpdateQuestion(E_Question data);

        /// <summary>
        /// 查询与该问题相关的名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        DataTable ListSelect(E_Question data);
    }
}
