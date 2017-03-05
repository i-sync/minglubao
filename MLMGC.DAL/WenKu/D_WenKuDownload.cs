using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.WenKu;
using MLMGC.IDAL.WenKu;
using MLMGC.DBUtility;
using MLMGC.DataEntity.User;

namespace MLMGC.DAL.WenKu
{
    /// <summary>
    /// 文库下载日志
    /// </summary>
    public class D_WenKuDownload:I_D_WenKuDownload
    {
        /// <summary>
        /// 下载文档记录数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public bool Add(E_WenKuDownload data)
        {
            SqlParameter[] parms = 
            {
				new SqlParameter("@WenKuID", SqlDbType.Int),				
				new SqlParameter("@UserID", SqlDbType.Int),				
				new SqlParameter("@EnterpriseID", SqlDbType.Int),
				new SqlParameter("@UserType",SqlDbType.TinyInt)
            };
            parms[0].Value = data.WenKuID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.EnterpriseID;
            parms[3].Value = (int)data.UserType;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcB_WenkuDownloads_Insert", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 查看下载记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public DataTable GetList(E_WenKuDownload data)
        {
            return null;
        }
    }
}
