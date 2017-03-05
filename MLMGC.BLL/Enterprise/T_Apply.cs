using System;
using System.Data;
using System.Collections.Generic;
using MLMGC.DALFactory.Enterprise;
using MLMGC.IDAL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 企业申请
    /// </summary>
    public class T_Apply
    {
        I_D_Apply dal = F_D_Apply.Create();

        /// <summary>
        /// 添加企业申请
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(E_Apply data)
        {
            return dal.Add(data);
        }
        /// <summary>
        /// 删除企业申请
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-02</remarks>
        public bool Delete(E_Apply data)
        {
            return dal.Delete(data);
        }
        /// <summary>
        /// 查看企业申请详细信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-31</remarks>
        public E_Apply GetModel(E_Apply data)
        {
            return dal.GetModel(data);
        }
        /// <summary>
        /// 查看企业申请列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-31</remarks>
        public DataTable GetList(E_Apply data)
        {
            return dal.GetList(data);
        }
    }
}
