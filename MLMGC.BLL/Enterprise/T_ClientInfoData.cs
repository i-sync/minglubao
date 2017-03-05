using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.IDAL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 企业名录数据导入导出
    /// </summary>
    public class T_ClientInfoData
    {
        MLMGC.IDAL.Enterprise.I_D_ClientInfoData dal = MLMGC.DALFactory.Enterprise.F_D_ClientInfoData.Create();

        /// <summary>
        /// 业务员导出名录数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-08</remarks>
        //TODO:该方法未使用
        public DataSet DataExport(E_ClientInfo data)
        {
            return dal.DataExport(data);
        }

        /// <summary>
        /// 总监导出名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-05</remarks>
        public DataSet LeaderDataExport(E_ClientInfo data)
        {
            return dal.LeaderDataExport(data);
        }
    }
}
