using System;
using System.Data;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 企业用户申请
    /// </summary>
    public interface I_D_Apply
    {
        /// <summary>
        /// 企业申请
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Add(E_Apply data);

        /// <summary>
        /// 删除企业申请
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-02</remarks>
        bool Delete(E_Apply data);
        /// <summary>
        /// 查看企业申请详细信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Apply GetModel(E_Apply data);
        /// <summary>
        /// 查看企业申请列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_Apply data);
    }
}
