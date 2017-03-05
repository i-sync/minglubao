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
    /// 个人名录信息
    /// </summary>
    public class D_ClientInfo : MLMGC.IDAL.Personal.I_D_ClientInfo
    {
        /// <summary>
        /// 判断名录名是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-24</remarks>
        public bool Exists(E_ClientInfo data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.ClientName;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_ClientInfo_Exists", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 判断电话和手机是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-14</remarks>
        public DataTable ExistsContact(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@Type",SqlDbType.TinyInt),
                new SqlParameter("@Value",SqlDbType.VarChar,16)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.Type;
            parms[3].Value = data.Value;
            return DbHelperSQL.RunProcedureTable("ProcPI_B_ClientInfo_ExistsContact", parms);
        }

        /// <summary>
        /// 添加新名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-24</remarks>
        public bool Add(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@Address",SqlDbType.VarChar,128),
                new SqlParameter("@ZipCode",SqlDbType.VarChar,8),
                new SqlParameter("@Linkman",SqlDbType.VarChar,64),
                new SqlParameter("@Position",SqlDbType.VarChar,64),
                new SqlParameter("@Tel",SqlDbType.VarChar,32),
                new SqlParameter("@Mobile",SqlDbType.VarChar,16),
                new SqlParameter("@Fax",SqlDbType.VarChar,32),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@QQ",SqlDbType.VarChar,128),
                new SqlParameter("@MSN",SqlDbType.VarChar,128),
                new SqlParameter("@Remark",SqlDbType.VarChar),
                new SqlParameter("@SourceName",SqlDbType.VarChar,16),
                new SqlParameter("@TradeName",SqlDbType.VarChar,16),
                new SqlParameter("@AreaName",SqlDbType.VarChar,16),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@Website",SqlDbType.VarChar,128),
                new SqlParameter("@ClientInfoID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientName;
            parms[2].Value = data.Address;
            parms[3].Value = data.ZipCode;
            parms[4].Value = data.Linkman;
            parms[5].Value = data.Position;
            parms[6].Value = data.Tel;
            parms[7].Value = data.Mobile;
            parms[8].Value = data.Fax;
            parms[9].Value = data.Email;
            parms[10].Value = data.QQ;
            parms[11].Value = data.MSN;
            parms[12].Value = data.Remark;
            parms[13].Value = data.SourceName;
            parms[14].Value = data.TradeName;
            parms[15].Value = data.AreaName;
            parms[16].Value = (int)EnumClientStatus.潜在客户;
            parms[17].Value = data.Website;
            parms[18].Direction = ParameterDirection.Output;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_ClientInfoS_Insert", parms, out ReturnValue);
            if (ReturnValue > 0)//判断是否录入成功
            {
                data.ClientInfoID = Convert.ToInt32(parms[18].Value);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-26</remarks>
        public bool Update(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                 new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@Address",SqlDbType.VarChar,128),
                new SqlParameter("@ZipCode",SqlDbType.VarChar,8),
                new SqlParameter("@Linkman",SqlDbType.VarChar,64),
                new SqlParameter("@Position",SqlDbType.VarChar,64),
                new SqlParameter("@Tel",SqlDbType.VarChar,32),
                new SqlParameter("@Mobile",SqlDbType.VarChar,16),
                new SqlParameter("@Fax",SqlDbType.VarChar,32),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@QQ",SqlDbType.VarChar,128),
                new SqlParameter("@MSN",SqlDbType.VarChar,128),
                new SqlParameter("@Remark",SqlDbType.VarChar),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@Website",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.ClientName;
            parms[3].Value = data.Address;
            parms[4].Value = data.ZipCode;
            parms[5].Value = data.Linkman;
            parms[6].Value = data.Position;
            parms[7].Value = data.Tel;
            parms[8].Value = data.Mobile;
            parms[9].Value = data.Fax;
            parms[10].Value = data.Email;
            parms[11].Value = data.QQ;
            parms[12].Value = data.MSN;
            parms[13].Value = data.Remark;
            parms[14].Value = data.SourceID;
            parms[15].Value = data.TradeID;
            parms[16].Value = data.AreaID;
            parms[17].Value = data.Website;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_ClientInfoS_Update", parms, out ReturnValue);
            if (ReturnValue > 0)//修改成功
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        public bool Delete(E_ClientInfo data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientInfoID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_ClientInfoS_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 批量删除名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        public bool BatchDelete(E_ClientInfo data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientInfoIDs;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_ClientInfoS_BatchDelete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 获取名录详细信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        public E_ClientInfo GetModel(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientInfoID;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_ClientInfoS_DataSelect", parms);
            if (dt != null && dt.Rows.Count == 1)
            { 
                DataRow row = dt.Rows[0];
                data.ClientName = row["ClientName"].ToString();
                data.Address = row["Address"].ToString();
                data.ZipCode = row["ZipCode"].ToString();
                data.Linkman = row["LinkMan"].ToString();
                data.Position = row["Position"].ToString();
                data.Tel = row["Tel"].ToString();
                data.Mobile = row["Mobile"].ToString();
                data.Fax = row["Fax"].ToString();
                data.Email = row["Email"].ToString();
                data.SetStatus= Convert.ToInt32(row["Status"]);
                data.QQ = row["QQ"].ToString();
                data.MSN = row["MSN"].ToString();
                data.Remark = row["Remark"].ToString();
                data.Website = row["Website"].ToString();
                data.SourceID = Convert.ToInt32(!DBNull.Value.Equals(row["SourceID"])?row["SourceID"]:"0");
                data.AreaID = Convert.ToInt32(!DBNull.Value.Equals(row["AreaID"]) ? row["AreaID"] : "0");
                data.TradeID = Convert.ToInt32(!DBNull.Value.Equals(row["TradeID"]) ? row["TradeID"] : "0");
                data.WishID = Convert.ToInt32(!DBNull.Value.Equals(row["WishID"]) ? row["WishID"] : "0");
                data.NotTradedID = Convert.ToInt32(!DBNull.Value.Equals(row["NotTradedID"])?row["NotTradedID"]:"0");
                data.ScrapID = Convert.ToInt32(!DBNull.Value.Equals(row["ScrapID"])?row["ScrapID"]:"0");
                data.TradedMoney = Convert.ToSingle(!DBNull.Value.Equals(row["Amount"]) ? row["Amount"] : "0");
                return data;
            }
            return null;
        }

        /// <summary>
        /// 修改名录状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        public bool UpdateStatus(E_ClientInfo data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@WishID",SqlDbType.Int),
                new SqlParameter("@Amount",SqlDbType.Money),
                new SqlParameter("@NotTradedID",SqlDbType.Int),
                new SqlParameter("@ScrapID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = (int)data.Status;
            parms[3].Value = data.WishID;
            parms[4].Value = data.TradedMoney;
            parms[5].Value = data.NotTradedID;
            parms[6].Value = data.ScrapID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcPI_B_ClientInfoS_UpdateStatus", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        /// <summary>
        /// 获取名录状态操作列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-26</remarks>
        public DataTable GetStatusList(E_ClientInfo data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientInfoID;
            return DbHelperSQL.RunProcedureTable("ProcPI_B_ClientLogS_Select", parms);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        public DataTable Select(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientName;
            parms[2].Value = data.Page.PageIndex;
            parms[3].Value = data.Page.PageSize;
            parms[4].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_ClientInfoS_Select", parms);
            data.Page.TotalCount = parms[4].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[4].Value);
            return dt;
        }
        /// <summary>
        /// 查询个人潜在客户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public DataTable LatenceSelect(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@SourceFlag",SqlDbType.Int),
                new SqlParameter("@TradeFlag",SqlDbType.Int),
                new SqlParameter("@AreaFlag",SqlDbType.Int),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientName;
            parms[2].Value = data.Status;
            parms[3].Value = (int)data.Property.SourceFlag;
            parms[4].Value = (int)data.Property.TradeFlag;
            parms[5].Value = (int)data.Property.AreaFlag;
            parms[6].Value = data.SourceID;
            parms[7].Value = data.TradeID;
            parms[8].Value = data.AreaID;
            parms[9].Value = data.Page.PageIndex;
            parms[10].Value = data.Page.PageSize;
            parms[11].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_ClientInfoS_LatenceSelect", parms);
            data.Page.TotalCount = parms[11].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[11].Value);
            return dt;
        }

        /// <summary>
        /// 查询个人意向客户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public DataTable WishSelect(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@SourceFlag",SqlDbType.Int),
                new SqlParameter("@TradeFlag",SqlDbType.Int),
                new SqlParameter("@AreaFlag",SqlDbType.Int),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@WishID",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientName;
            parms[2].Value = (int)data.Status;
            parms[3].Value = (int)data.Property.SourceFlag;
            parms[4].Value = (int)data.Property.TradeFlag;
            parms[5].Value = (int)data.Property.AreaFlag;
            parms[6].Value = data.SourceID;
            parms[7].Value = data.TradeID;
            parms[8].Value = data.AreaID;
            parms[9].Value = data.Page.PageIndex;
            parms[10].Value = data.Page.PageSize;
            parms[11].Value = data.WishID;
            parms[12].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_ClientInfoS_WishSelect", parms);
            data.Page.TotalCount = parms[12].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[12].Value);
            return dt;
        }

        /// <summary>
        /// 查询失败客户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public DataTable NotTradeSelect(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@SourceFlag",SqlDbType.Int),
                new SqlParameter("@TradeFlag",SqlDbType.Int),
                new SqlParameter("@AreaFlag",SqlDbType.Int),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientName;
            parms[2].Value = data.Page.StartDate;
            parms[3].Value = data.Page.EndDate;
            parms[4].Value = data.Status;
            parms[5].Value = (int)data.Property.SourceFlag;
            parms[6].Value = (int)data.Property.TradeFlag;
            parms[7].Value = (int)data.Property.AreaFlag;
            parms[8].Value = data.SourceID;
            parms[9].Value = data.TradeID;
            parms[10].Value = data.AreaID;
            parms[11].Value = data.Page.PageIndex;
            parms[12].Value = data.Page.PageSize;
            parms[13].Value = data.NotTradedID;
            parms[14].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_ClientInfoS_NotTradeSelect", parms);
            data.Page.TotalCount = parms[14].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[14].Value);
            return dt;
        }

        /// <summary>
        /// 查询报废客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public DataTable ScrapSelect(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@SourceFlag",SqlDbType.Int),
                new SqlParameter("@TradeFlag",SqlDbType.Int),
                new SqlParameter("@AreaFlag",SqlDbType.Int),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@ScrapID",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int),
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientName;
            parms[2].Value = data.Page.StartDate;
            parms[3].Value = data.Page.EndDate;
            parms[4].Value = data.Status;
            parms[5].Value = (int)data.Property.SourceFlag;
            parms[6].Value = (int)data.Property.TradeFlag;
            parms[7].Value = (int)data.Property.AreaFlag;
            parms[8].Value = data.SourceID;
            parms[9].Value = data.TradeID;
            parms[10].Value = data.AreaID;
            parms[11].Value = data.Page.PageIndex;
            parms[12].Value = data.Page.PageSize;
            parms[13].Value = data.ScrapID;
            parms[14].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_ClientInfoS_ScrapSelect", parms);
            data.Page.TotalCount = parms[14].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[14].Value);
            return dt;
        }

        /// <summary>
        /// 查询成交客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public DataTable TradedSelect(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@SourceFlag",SqlDbType.Int),
                new SqlParameter("@TradeFlag",SqlDbType.Int),
                new SqlParameter("@AreaFlag",SqlDbType.Int),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int),
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.ClientName;
            parms[2].Value = data.Page.StartDate;
            parms[3].Value = data.Page.EndDate;
            parms[4].Value = data.Status;
            parms[5].Value = (int)data.Property.SourceFlag;
            parms[6].Value = (int)data.Property.TradeFlag;
            parms[7].Value = (int)data.Property.AreaFlag;
            parms[8].Value = data.SourceID;
            parms[9].Value = data.TradeID;
            parms[10].Value = data.AreaID;
            parms[11].Value = data.Page.PageIndex;
            parms[12].Value = data.Page.PageSize;
            parms[13].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_ClientInfoS_TradedSelect", parms);
            data.Page.TotalCount = parms[13].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[13].Value);
            return dt;
        }

        #region 数据导入 导出  qipengfei
        /// <summary>
        /// 名录数据导出
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        public DataSet DataExport(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = (int)data.Status;

            return DbHelperSQL.RunProcedureDataSet("ProcPI_B_ClientInfoS_ExportSelect", parms);
        }

        #endregion

        /// <summary>
        /// 名录统计信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        public DataTable Statistics(E_ClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@PersonalID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;

            return DbHelperSQL.RunProcedureTable("ProcPI_B_ClientInfo_Statistics", parms);
        }
    }
}
