using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.DataEntity.Personal;

namespace MLMGC.DAL.Personal
{
    /// <summary>
    /// 名录沟通记录
    /// </summary>
    public class D_Exchange:MLMGC.IDAL.Personal.I_D_Exchange
    {
        /// <summary>
        /// 添加名录沟通记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        public bool Add(E_Exchange data)
        { 
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@Detail",SqlDbType.VarChar ,512),
                new SqlParameter("@ExchangeDate",SqlDbType.SmallDateTime)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.Detail;
            parms[3].Value = data.ExchangeDate;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_Exchange_Insert", parms, out ReturnValue);
            
            return ReturnValue>0;
        }
        
        /// <summary>
        /// 获取名录沟通记录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        public DataTable GetList(E_Exchange data)
        { 
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientInfoID;
            return DbHelperSQL.RunProcedureTable("ProcPI_B_Exchange_ListSelect", parms);            
        }
    }
}
