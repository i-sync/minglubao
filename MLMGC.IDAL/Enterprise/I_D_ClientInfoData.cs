using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 企业名录导入，导出
    /// </summary>
    public interface I_D_ClientInfoData
    {
        /// <summary>
        /// 名录信息导出
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-08</remarks>
        DataSet DataExport(E_ClientInfo data);

        /// <summary>
        /// 总监导出名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-05</remarks>
        DataSet LeaderDataExport(E_ClientInfo data);
    }
}
