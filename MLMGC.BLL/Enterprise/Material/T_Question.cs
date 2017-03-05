using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Material;

namespace MLMGC.BLL.Enterprise.Material
{
    /// <summary>
    /// 调查问题
    /// </summary>
    public class T_Question
    {
        MLMGC.IDAL.Enterprise.Material.I_D_Question dal = MLMGC.DALFactory.Enterprise.Material.F_D_Question.Create();

        /// <summary>
        /// 增加调查问题
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(E_Question data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 更新调查问题
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(E_Question data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 删除调查问题
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Delete(E_Question data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 得到调查问题对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Question GetModel(E_Question data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 得到调查问题列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Question data)
        {
            return dal.GetList(data);
        }

        /// <summary>
        /// 调查问题列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet List(E_Question data)
        {
            return dal.List(data);
        }

         /// <summary>
        /// 更新调查问卷答案
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        public bool UpdateQuestion(E_Question data)
        {
            return dal.UpdateQuestion(data);
        }

        /// <summary>
        /// 查询与该问题相关的名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        public DataTable ListSelect(E_Question data)
        {
            return dal.ListSelect(data);
        }
    }
}
