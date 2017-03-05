using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.DataEntity.Personal.Config;

namespace MLMGC.DAL.Personal.Config
{
    /// <summary>
    /// 行业属性
    /// </summary>
    public class D_Trade : MLMGC.IDAL.Personal.Config.I_D_Trade
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public bool Exists(E_Trade data)
        {
            int ReturnValue;
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4),
					new SqlParameter("@TradeName", SqlDbType.VarChar,128)};
            parameters[0].Value = data.TradeID;
            parameters[1].Value = data.PersonalID;
            parameters[2].Value = data.TradeName;


            DbHelperSQL.RunProcedures("ProcPI_B_Trade_Exists", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public int Add(E_Trade data)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4),
					new SqlParameter("@TradeCode", SqlDbType.VarChar,32),
					new SqlParameter("@TradeName", SqlDbType.VarChar,128)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = data.PersonalID ;
            parameters[2].Value = data.TradeCode;
            parameters[3].Value = data.TradeName;

            DbHelperSQL.RunProcedure("ProcPI_B_Trade_Insert", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
        /// <summary>
        /// 批量增加行业
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        public bool BatchAdd(E_Trade data)
        {
            SqlParameter[] parms = 
            {
			    new SqlParameter("@PersonalID", SqlDbType.Int,4),
			    new SqlParameter("@Child_TradeCode", SqlDbType.NVarChar),
			    new SqlParameter("@Child_TradeName", SqlDbType.NVarChar),
                new SqlParameter("@Separation", SqlDbType.VarChar,2)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.TradeCodeS;
            parms[2].Value = data.TradeNameS;
            parms[3].Value = MLMGC.COMP.Config.Separation;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_Trade_BatchInsert", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public bool Update(E_Trade data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4),
					new SqlParameter("@TradeCode", SqlDbType.VarChar,32),
					new SqlParameter("@TradeName", SqlDbType.VarChar,128)};
            parameters[0].Value = data.TradeID;
            parameters[1].Value = data.PersonalID;
            parameters[2].Value = data.TradeCode;
            parameters[3].Value = data.TradeName;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_Trade_Update", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public bool Delete(E_Trade data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4)};
            parameters[0].Value = data.TradeID;
            parameters[1].Value = data.PersonalID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_Trade_Delete", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public E_Trade GetModel(E_Trade data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4),
					new SqlParameter("@PersonalID", SqlDbType.Int,4)};
            parameters[0].Value = data.TradeID;
            parameters[1].Value = data.PersonalID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_Trade_Select", parameters);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.TradeCode = dt.Rows[0]["TradeCode"].ToString();
                data.TradeName = dt.Rows[0]["TradeName"].ToString();
                return data;
            }
            return null;
        }
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public DataTable GetList(E_Trade data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PersonalID", SqlDbType.Int)
                                        };
            parameters[0].Value = data.PersonalID;
            return DbHelperSQL.RunProcedureTable("ProcPI_B_Trade_ListSelect", parameters);
        }
        /// <summary>
        /// 获取绑定显示的列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-20</remarks>
        public DataTable GetShowList(E_Trade data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PersonalID", SqlDbType.Int),
                    new SqlParameter("@CodeIsValue",SqlDbType.TinyInt)
                                        };
            parameters[0].Value = data.PersonalID;
            parameters[1].Value = data.CodeIsValue ? 1 : 2;
            return DbHelperSQL.RunProcedureTable("ProcPI_B_Trade_ShowListSelect", parameters);
        }
    }
}
