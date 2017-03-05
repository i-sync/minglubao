using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DBUtility;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 企业名录导入导出
    /// </summary>
    public class D_ClientInfoData:I_D_ClientInfoData
    {
        /// <summary>
        /// 业务员导出名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-08</remarks>
        public DataSet DataExport(E_ClientInfo data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int ),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.EPUserTMRID ;
            parms[2].Value = (int)data.Status;
            return DbHelperSQL.RunProcedureDataSet("ProcEP_B_ClientInfoS_ExportSelect", parms);
        }

        /// <summary>
        /// 总监导出名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-05</remarks>
        public DataSet LeaderDataExport(E_ClientInfo data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int ),
                new SqlParameter("@Status",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = (int)data.Status;
            return DbHelperSQL.RunProcedureDataSet("ProcEP_B_ClientInfoS_LeaderExportSelect", parms);
        }
    }
}
