using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Item;
using MLMGC.IDAL.Item;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Item
{
    /// <summary>
    /// 项目名录
    /// </summary>
    public class D_ItemClientInfo:I_D_ItemClientInfo
    {
        /// <summary>
        /// 判断名录名称手机电话是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public bool Exists(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@Type",SqlDbType.TinyInt),
                new SqlParameter("@Value",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.Type;
            parms[3].Value = data.Value;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemClientInfoS_Exists", parms, out ReturnValue);
            return ReturnValue > 0;
        }
                
        /// <summary>
        /// 添加新名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public bool Add(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@UserID",SqlDbType.Int),
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
                new SqlParameter("@SourceCode",SqlDbType.VarChar,16),
                new SqlParameter("@TradeCode",SqlDbType.VarChar,16),
                new SqlParameter("@AreaCode",SqlDbType.VarChar,16),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@Website",SqlDbType.VarChar,128),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.UserID;
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
            parms[13].Value = data.SourceCode;
            parms[14].Value = data.TradeCode;
            parms[15].Value = data.AreaCode;
            parms[16].Value = (int)EnumClientStatus.潜在客户;
            parms[17].Value = data.Website;
            parms[18].Direction = ParameterDirection.Output;
            parms[19].Value = data.EnterpriseID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemClientInfoS_Insert", parms, out ReturnValue);
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
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public bool Update(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@UserID",SqlDbType.Int),
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
                new SqlParameter("@Website",SqlDbType.VarChar,128),
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.UserID;
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
            parms[18].Value = data.EnterpriseID;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemClientInfoS_Update", parms, out ReturnValue);
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
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public bool Delete(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.VarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.ClientInfoIDs;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemClientInfoS_Delete", parms, out ReturnValue);
            return ReturnValue > 0; 
        }

        /// <summary>
        /// 获取名录对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public E_ItemClientInfo GetModel(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.UserID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_DataSelect", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                //----------------基本信息----------------
                data.ClientInfoID = Convert.ToInt32(dt.Rows[0]["ClientInfoID"].ToString());
                data.ClientName = dt.Rows[0]["ClientName"].ToString();
                data.Address = dt.Rows[0]["Address"].ToString();
                data.ZipCode = dt.Rows[0]["ZipCode"].ToString();
                data.Linkman = dt.Rows[0]["Linkman"].ToString();
                data.Position = dt.Rows[0]["Position"].ToString();
                data.Tel = dt.Rows[0]["Tel"].ToString();
                data.Mobile = dt.Rows[0]["Mobile"].ToString();
                data.Fax = dt.Rows[0]["Fax"].ToString();
                data.Website = dt.Rows[0]["Website"].ToString();
                data.Email = dt.Rows[0]["Email"].ToString();
                data.QQ = dt.Rows[0]["QQ"].ToString();
                data.MSN = dt.Rows[0]["MSN"].ToString();
                data.Remark = dt.Rows[0]["Remark"].ToString();
                //----------------名录状态----------------
                data.SetStatus = Convert.ToInt32(dt.Rows[0]["Status"]);
                //----------------名录属性----------------
                if (!Convert.IsDBNull(dt.Rows[0]["AreaID"]))//----地区编号
                {
                    data.AreaID = Convert.ToInt32(dt.Rows[0]["AreaID"]);
                }
                if (!Convert.IsDBNull(dt.Rows[0]["SourceID"]))//----来源编号
                {
                    data.SourceID = Convert.ToInt32(dt.Rows[0]["SourceID"]);
                }
                if (!Convert.IsDBNull(dt.Rows[0]["TradeID"]))//----行业编号
                {
                    data.TradeID = Convert.ToInt32(dt.Rows[0]["TradeID"]);
                }
                //----------------名录各状态值----------------
                if (!Convert.IsDBNull(dt.Rows[0]["wishid"]))//----意向编号
                {
                    data.WishID = Convert.ToInt32(dt.Rows[0]["wishid"]);
                }
                if (!Convert.IsDBNull(dt.Rows[0]["TradedMoney"]))//----成交金额
                {
                    data.TradedMoney = float.Parse(dt.Rows[0]["TradedMoney"].ToString());
                }
                if (!Convert.IsDBNull(dt.Rows[0]["NotTradedID"]))//----失败编号
                {
                    data.NotTradedID = Convert.ToInt32(dt.Rows[0]["NotTradedID"]);
                }
                if (!Convert.IsDBNull(dt.Rows[0]["ScrapID"]))//----报废编号
                {
                    data.ScrapID = Convert.ToInt32(dt.Rows[0]["ScrapID"]);
                }
                return data;
            }
            return null;
        }

        /// <summary>
        /// 修改名录状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public bool UpdateStatus(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@WishID",SqlDbType.Int),
                new SqlParameter("@TradedMoney",SqlDbType.Money),
                new SqlParameter("@NotTradedID",SqlDbType.Int),
                new SqlParameter("@ScrapID",SqlDbType.Int),
                
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = (int)data.Status;
            parms[3].Value = data.UserID;
            parms[4].Value = data.WishID;
            parms[5].Value = data.TradedMoney;
            parms[6].Value = data.NotTradedID;
            parms[7].Value = data.ScrapID;

            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemClientInfoS_UpdateStatus", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 共享名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-18</remarks>
        public bool UpdateShare(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar),
                new SqlParameter("@Status",SqlDbType.TinyInt)
                
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.ClientInfoIDs;
            parms[3].Value = (int)data.Status;
            int ReturnValue ;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemClientInfoS_UpdateShare", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 获取名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public DataTable GetList(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@Linkman",SqlDbType.NVarChar,128),
                new SqlParameter("@Tel",SqlDbType.VarChar,128),
                new SqlParameter("@Mobile",SqlDbType.VarChar,128),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = (int)data.Property.SourceFlag;
            parms[3].Value = (int)data.Property.AreaFlag;
            parms[4].Value = (int)data.Property.TradeFlag;
            parms[5].Value = data.SourceID;
            parms[6].Value = data.AreaID;
            parms[7].Value = data.TradeID;
            parms[8].Value = (int)data.Status;
            parms[9].Value = data.ClientName;
            parms[10].Value = data.Linkman;
            parms[11].Value = data.Tel;
            parms[12].Value = data.Mobile;
            parms[13].Value = data.Email;
            parms[14].Value = data.Page.PageSize;
            parms[15].Value = data.Page.PageIndex;
            parms[16].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_ListSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[16].Value) ? "0" : parms[16].Value);

            return dt;
        }

        /// <summary>
        /// 获取状态日志列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable GetStatusList(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ItemStatusLog_ListSelect", parms);
        }


        #region 名录状态列表
        /// <summary>
        /// 查询潜在客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable LatenceSelect(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
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
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.ClientName;
            parms[3].Value = data.Status;
            parms[4].Value = (int)data.Property.SourceFlag;
            parms[5].Value = (int)data.Property.TradeFlag;
            parms[6].Value = (int)data.Property.AreaFlag;
            parms[7].Value = data.SourceID;
            parms[8].Value = data.TradeID;
            parms[9].Value = data.AreaID;
            parms[10].Value = data.Page.PageIndex;
            parms[11].Value = data.Page.PageSize;
            parms[12].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_LatenceSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(parms[12].Value == DBNull.Value ? 0 : parms[12].Value);
            return dt;
        }

        /// <summary>
        /// 查询意向客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable WishSelect(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@SourceFlag",SqlDbType.Int),
                new SqlParameter("@TradeFlag",SqlDbType.Int),
                new SqlParameter("@AreaFlag",SqlDbType.Int),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@WishID",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.ClientName;
            parms[3].Value = data.Status;
            parms[4].Value = (int)data.Property.SourceFlag;
            parms[5].Value = (int)data.Property.TradeFlag;
            parms[6].Value = (int)data.Property.AreaFlag;
            parms[7].Value = data.SourceID;
            parms[8].Value = data.TradeID;
            parms[9].Value = data.AreaID;
            parms[10].Value = data.WishID;
            parms[11].Value = data.Page.PageIndex;
            parms[12].Value = data.Page.PageSize;
            parms[13].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_WishSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(parms[13].Value == DBNull.Value ? 0 : parms[13].Value);
            return dt;
        }

        /// <summary>
        /// 查询失败客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable NotTradeSelect(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@SourceFlag",SqlDbType.Int),
                new SqlParameter("@TradeFlag",SqlDbType.Int),
                new SqlParameter("@AreaFlag",SqlDbType.Int),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.ClientName;
            parms[3].Value = data.Status;
            parms[4].Value = (int)data.Property.SourceFlag;
            parms[5].Value = (int)data.Property.TradeFlag;
            parms[6].Value = (int)data.Property.AreaFlag;
            parms[7].Value = data.SourceID;
            parms[8].Value = data.TradeID;
            parms[9].Value = data.AreaID;
            parms[10].Value = data.NotTradedID;
            parms[11].Value = data.Page.PageIndex;
            parms[12].Value = data.Page.PageSize;
            parms[13].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_NotTradedSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(parms[13].Value == DBNull.Value ? 0 : parms[13].Value);
            return dt;
        }

        /// <summary>
        /// 查询报废客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable ScrapSelect(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@SourceFlag",SqlDbType.Int),
                new SqlParameter("@TradeFlag",SqlDbType.Int),
                new SqlParameter("@AreaFlag",SqlDbType.Int),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@ScrapID",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.ClientName;
            parms[3].Value = data.Status;
            parms[4].Value = (int)data.Property.SourceFlag;
            parms[5].Value = (int)data.Property.TradeFlag;
            parms[6].Value = (int)data.Property.AreaFlag;
            parms[7].Value = data.SourceID;
            parms[8].Value = data.TradeID;
            parms[9].Value = data.AreaID;
            parms[10].Value = data.ScrapID;
            parms[11].Value = data.Page.PageIndex;
            parms[12].Value = data.Page.PageSize;
            parms[13].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_ScrapSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(parms[13].Value == DBNull.Value ? 0 : parms[13].Value);
            return dt;
        }

        /// <summary>
        /// 查询成交客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable TradedSelect(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@SourceFlag",SqlDbType.Int),
                new SqlParameter("@TradeFlag",SqlDbType.Int),
                new SqlParameter("@AreaFlag",SqlDbType.Int),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradedMoney",SqlDbType.Money),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.ClientName;
            parms[3].Value = data.Status;
            parms[4].Value = (int)data.Property.SourceFlag;
            parms[5].Value = (int)data.Property.TradeFlag;
            parms[6].Value = (int)data.Property.AreaFlag;
            parms[7].Value = data.SourceID;
            parms[8].Value = data.TradeID;
            parms[9].Value = data.AreaID;
            parms[10].Value = data.TradedMoney;
            parms[11].Value = data.Page.PageIndex;
            parms[12].Value = data.Page.PageSize;
            parms[13].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_TradedSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(parms[13].Value == DBNull.Value ? 0 : parms[13].Value);
            return dt; 
        }


        /// <summary>
        /// 共享名录查询
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-18</remarks>
        public DataTable ShareSelect(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = (int)data.Status;
            parms[2].Value = data.ClientName;
            parms[3].Value = (int)data.Property.SourceFlag;
            parms[4].Value = (int)data.Property.AreaFlag;
            parms[5].Value = (int)data.Property.TradeFlag;
            parms[6].Value = data.SourceID;
            parms[7].Value = data.AreaID;
            parms[8].Value = data.TradeID;
            parms[9].Value = data.Page.PageIndex;
            parms[10].Value = data.Page.PageSize;
            parms[11].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_ShareSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(parms[11].Value==DBNull.Value?0:parms[11].Value);
            return dt;
        }

        #endregion


        #region 总监查询名录列表

        /// <summary>
        /// 总监模糊查询列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderList(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientName;
            if(data.Status != EnumClientStatus.所有状态)
            parms[2].Value = (int)data.Status;
            parms[3].Value = data.Page.PageSize;
            parms[4].Value = data.Page.PageIndex;
            parms[5].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_LeaderListSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[5].Value) ? "0" : parms[5].Value);
            return dt;
        }

        /// <summary>
        /// 总监查询潜在客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderLatenceList(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = (int)data.Status;
            parms[3].Value = data.ClientName;
            parms[4].Value = (int)data.Property.SourceFlag;
            parms[5].Value = (int)data.Property.AreaFlag;
            parms[6].Value = (int)data.Property.TradeFlag;
            parms[7].Value = data.SourceID;
            parms[8].Value = data.AreaID;
            parms[9].Value = data.TradeID;
            parms[10].Value = data.Page.StartDate;
            parms[11].Value = data.Page.EndDate;

            parms[12].Value = data.Page.PageSize;
            parms[13].Value = data.Page.PageIndex;
            parms[14].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_LeaderLatenceSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[14].Value) ? "0" : parms[14].Value);
            return dt;
        }

        /// <summary>
        /// 总监查询意向客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderWishList(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = (int)data.Status;
            parms[3].Value = data.ClientName;
            parms[4].Value = (int)data.Property.SourceFlag;
            parms[5].Value = (int)data.Property.AreaFlag;
            parms[6].Value = (int)data.Property.TradeFlag;
            parms[7].Value = data.SourceID;
            parms[8].Value = data.AreaID;
            parms[9].Value = data.TradeID;
            parms[10].Value = data.Page.StartDate;
            parms[11].Value = data.Page.EndDate;

            parms[12].Value = data.Page.PageSize;
            parms[13].Value = data.Page.PageIndex;
            parms[14].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_LeaderWishSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[14].Value) ? "0" : parms[14].Value);
            return dt;
        }


        /// <summary>
        /// 总监查询成交客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderTradedList(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = (int)data.Status;
            parms[3].Value = data.ClientName;
            parms[4].Value = (int)data.Property.SourceFlag;
            parms[5].Value = (int)data.Property.AreaFlag;
            parms[6].Value = (int)data.Property.TradeFlag;
            parms[7].Value = data.SourceID;
            parms[8].Value = data.AreaID;
            parms[9].Value = data.TradeID;
            parms[10].Value = data.Page.StartDate;
            parms[11].Value = data.Page.EndDate;

            parms[12].Value = data.Page.PageSize;
            parms[13].Value = data.Page.PageIndex;
            parms[14].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_LeaderTradedSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[14].Value) ? "0" : parms[14].Value);
            return dt;
        }

        /// <summary>
        /// 总监查询失败客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderNotTradedList(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@NotTradedID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = (int)data.Status;
            parms[3].Value = data.ClientName;
            parms[4].Value = (int)data.Property.SourceFlag;
            parms[5].Value = (int)data.Property.AreaFlag;
            parms[6].Value = (int)data.Property.TradeFlag;
            parms[7].Value = data.SourceID;
            parms[8].Value = data.AreaID;
            parms[9].Value = data.TradeID;
            parms[10].Value = data.NotTradedID;

            parms[11].Value = data.Page.PageSize;
            parms[12].Value = data.Page.PageIndex;
            parms[13].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_LeaderNotTradedSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[13].Value) ? "0" : parms[13].Value);
            return dt;
        }

        /// <summary>
        /// 总监查询失败客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderScrapList(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@ClientName",SqlDbType.NVarChar,128),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@SourceID",SqlDbType.Int),
                new SqlParameter("@AreaID",SqlDbType.Int),
                new SqlParameter("@TradeID",SqlDbType.Int),
                new SqlParameter("@ScrapID",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = (int)data.Status;
            parms[3].Value = data.ClientName;
            parms[4].Value = (int)data.Property.SourceFlag;
            parms[5].Value = (int)data.Property.AreaFlag;
            parms[6].Value = (int)data.Property.TradeFlag;
            parms[7].Value = data.SourceID;
            parms[8].Value = data.AreaID;
            parms[9].Value = data.TradeID;
            parms[10].Value = data.ScrapID;

            parms[11].Value = data.Page.PageSize;
            parms[12].Value = data.Page.PageIndex;
            parms[13].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_LeaderScrapSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[13].Value) ? "0" : parms[13].Value);
            return dt;
        }


        /// <summary>
        /// 总监查询已删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-17</remarks>
        public DataTable LeaderDeleteList(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientName",SqlDbType.VarChar,128),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageSize",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientName;
            parms[2].Value = data.Page.StartDate;
            parms[3].Value = data.Page.EndDate;
            parms[4].Value = data.Page.PageSize;
            parms[5].Value = data.Page.PageIndex;
            parms[6].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfoS_LeaderDeleteSelect", parms);
            data.Page.TotalCount = Convert.ToInt32(DBNull.Value.Equals(parms[6].Value) ? "0" : parms[6].Value);
            return dt;
        }

        /// <summary>
        /// 总监彻底删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-17</remarks>
        public bool ThoroughDelete(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoIDs;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemClientInfoS_ThoroughDelete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 总监清空回收站
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-21</remarks>
        public bool ThoroughDeleteAll(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            int ReturnValue ;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemClientInfoS_ThoroughDeleteAll", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 总监删除共享池中所有的名录 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-21</remarks>
        public bool DeleteAll(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = (int)data.Status;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemClientInfoS_DeleteAll", parms, out ReturnValue);
            return ReturnValue > 0;
        }
        
        #endregion
        
        /// <summary>
        /// 从共享池中获取名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-21</remarks>
        public bool ShiftShare(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ClientInfoIDs",SqlDbType.NVarChar),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoIDs;
            parms[2].Value = data.UserID;
            parms[3].Value = (int)data.Status;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_ItemClientInfoS_UpdateShift", parms, out ReturnValue);

            return ReturnValue > 0;
        }


        #region 名录从个人导入到项目或从项目导入到个人
        /// <summary>
        /// 从个人-->项目 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-24</remarks>
        public DataTable ImportData_PI(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@TarStatus",SqlDbType.TinyInt),
                new SqlParameter("@TotalCount",SqlDbType.Int),
                new SqlParameter("@IsExchange",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.PersonalID;
            parms[2].Value = data.UserID;
            if (data.Status != EnumClientStatus.所有状态)
            parms[3].Value = (int)data.Status;
            parms[4].Value = (int)data.TarStatus;
            parms[5].Value = data.TotalCount;
            parms[6].Value = data.IsExchange;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfo_PI_One", parms);
        }

        /// <summary>
        /// 项目-->个人
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-24</remarks>
        public DataTable ImportData_IP(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@PersonalID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@TarStatus",SqlDbType.TinyInt),
                new SqlParameter("@TotalCount",SqlDbType.Int),
                new SqlParameter("@IsExchange",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.PersonalID;
            parms[2].Value = data.UserID;
            if (data.Status != EnumClientStatus.所有状态)
            parms[3].Value = (int)data.Status;
            parms[4].Value = (int)data.TarStatus;
            parms[5].Value = data.TotalCount;
            parms[6].Value = data.IsExchange;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfo_IP_One", parms);
        }
        #endregion

        #region 总监把名录导入到企业或项目
        /// <summary>
        /// 从企业-->项目 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-25</remarks>
        public DataTable ImportData_EI(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@TarStatus",SqlDbType.TinyInt),
                new SqlParameter("@TotalCount",SqlDbType.Int),
                new SqlParameter("@IsExchange",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            if (data.Status != EnumClientStatus.所有状态)
            parms[1].Value = (int)data.Status;
            parms[2].Value = (int)data.TarStatus;
            parms[3].Value = data.TotalCount;
            parms[4].Value = data.IsExchange;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfo_EI_One", parms);
        }

        /// <summary>
        /// 项目-->企业
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-25</remarks>
        public DataTable ImportData_IE(E_ItemClientInfo data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int),
                new SqlParameter("@EPUserTMRID",SqlDbType.Int),
                new SqlParameter("@TeamID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@TarStatus",SqlDbType.TinyInt),
                new SqlParameter("@TotalCount",SqlDbType.Int),
                new SqlParameter("@IsExchange",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.UserID;
            parms[2].Value = data.EPUserMTRID;
            parms[3].Value = data.TeamID;
            if(data.Status != EnumClientStatus.所有状态)
            parms[4].Value = (int)data.Status;
            parms[5].Value = (int)data.TarStatus;
            parms[6].Value = data.TotalCount;
            parms[7].Value = data.IsExchange;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ItemClientInfo_IE_One", parms);
        }
        #endregion
    }
}
