using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DBUtility;
using System.Data.SqlClient;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 行业属性
    /// </summary>
    public class D_Trade:MLMGC.IDAL.Enterprise.I_D_Trade
    {

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(E_Trade data)
        {
            int ReturnValue;
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@TradeCode", SqlDbType.VarChar,32)};
            parameters[0].Value =data.TradeID;
            parameters[1].Value = data.EnterpriseID;
            parameters[2].Value = data.TradeCode;


            DbHelperSQL.RunProcedures("ProcEP_B_Trade_Exists", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_Trade data)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@TradeCode", SqlDbType.VarChar,32),
					new SqlParameter("@TradeName", SqlDbType.VarChar,128)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = data.EnterpriseID;
            parameters[2].Value = data.TradeCode;
            parameters[3].Value = data.TradeName;

            DbHelperSQL.RunProcedure("ProcEP_B_Trade_Insert", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_Trade data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@TradeCode", SqlDbType.VarChar,32),
					new SqlParameter("@TradeName", SqlDbType.VarChar,128)};
            parameters[0].Value = data.TradeID;
            parameters[1].Value = data.EnterpriseID;
            parameters[2].Value = data.TradeCode;
            parameters[3].Value = data.TradeName;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Trade_Update", parameters, out ReturnValue);
            return ReturnValue>0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(E_Trade data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)};
            parameters[0].Value = data.TradeID;
            parameters[1].Value = data.EnterpriseID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_Trade_Delete", parameters, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Trade GetModel(E_Trade data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4),
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4)};
            parameters[0].Value = data.TradeID;
            parameters[1].Value = data.EnterpriseID;
            DataTable dt=DbHelperSQL.RunProcedureTable("ProcEP_B_Trade_Select", parameters);
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
        public DataTable GetList(E_Trade data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int)
                                        };
            parameters[0].Value = data.EnterpriseID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_Trade_ListSelect", parameters);
        }
        /// <summary>
        /// 获取绑定显示的列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetShowList(E_Trade data)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@EnterpriseID", SqlDbType.Int),
                    new SqlParameter("@CodeIsValue",SqlDbType.TinyInt)
                                        };
            parameters[0].Value = data.EnterpriseID;
            parameters[1].Value = data.CodeIsValue ? 1 : 2;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_Trade_ShowListSelect", parameters);
        }
    }
}
