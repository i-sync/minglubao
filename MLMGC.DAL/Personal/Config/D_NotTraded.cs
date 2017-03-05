using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Personal.Config;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Personal.Config
{
    /// <summary>
    /// 失败理由
    /// </summary>
    public class D_NotTraded :MLMGC.IDAL.Personal.Config.I_D_NotTraded
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <reamrks>tianzhenyun 2011-10-19</reamrks>
        public bool Exists(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int),
                new SqlParameter("@NotTradedName",SqlDbType.NVarChar,128)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.NotTradedID;
            parms[2].Value = data.NotTradedName;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_NotTraded_Exists", parms, out ReturnValue);
            return ReturnValue == 1;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <reamrks>tianzhenyun 2011-10-19</reamrks>
        public int Add(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@NotTradedName",SqlDbType.NVarChar,128)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.NotTradedName;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_NotTraded_Insert", parms, out ReturnValue);
            data.NotTradedID = ReturnValue;
            return ReturnValue;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <reamrks>tianzhenyun 2011-10-19</reamrks>
        public bool Update(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int),
                new SqlParameter("@NotTradedName",SqlDbType.NVarChar,128)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.NotTradedID;
            parms[2].Value = data.NotTradedName;

            int ReturnValue = 0, irowsAffected = 0;
            irowsAffected = DbHelperSQL.RunProcedures("ProcPI_B_NotTraded_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <reamrks>tianzhenyun 2011-10-19</reamrks>
        public bool Delete(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.NotTradedID;
            int ReturnValue = 0, irowsAffected = 0;
            irowsAffected = DbHelperSQL.RunProcedures("ProcPI_B_NotTraded_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <reamrks>tianzhenyun 2011-10-19</reamrks>
        public E_NotTraded GetModel(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.NotTradedID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_NotTraded_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.NotTradedName = dt.Rows[0]["NotTradedName"].ToString();
            }
            return data;
        }
        /// <summary>
        ///无分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2011-10-19</reamrks>
        public DataTable GetList(E_NotTraded data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            return DbHelperSQL.RunProcedureTable("ProcPI_B_NotTraded_ListSelect", parms);
        }
    }
}
