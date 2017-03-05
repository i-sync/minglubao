using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Enterprise;
using MLMGC.IDAL.Enterprise;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 企业项目
    /// </summary>
    public class D_Item:I_D_Item
    {
        /// <summary>
        /// 修改添加企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianhzenyun 2012-04-25</remarks>
        public bool Update(E_Item data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ItemName",SqlDbType.VarChar,128),
                new SqlParameter("@ItemIntro",SqlDbType.VarChar,1024),
                new SqlParameter("@ItemContent",SqlDbType.VarChar),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@Photo",SqlDbType.VarChar,128),
                new SqlParameter("@Established",SqlDbType.SmallDateTime),
                new SqlParameter("@CityID",SqlDbType.Int),
                new SqlParameter("@Signature",SqlDbType.VarChar,128)
            };

            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ItemName;
            parms[2].Value = data.ItemIntro;
            parms[3].Value = data.ItemContent;
            parms[4].Value = data.Status;
            parms[5].Value = data.Photo;
            parms[6].Value = data.Established;
            parms[7].Value = data.CityID;
            parms[8].Value = data.Signature;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_Item_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 获取企业项目对象 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianhzenyun 2012-04-25</remarks>
        public E_Item GetModel(E_Item data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };

            parms[0].Value = data.EnterpriseID;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Item_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                data.ItemID = Convert.ToInt32(row["ItemID"]);
                data.ItemName = row["ItemName"].ToString();
                data.ItemIntro = row["ItemIntro"].ToString();
                data.Signature = row["Signature"].ToString();
                data.ItemContent = row["ItemContent"].ToString();
                data.SetStatus = row["Status"]==DBNull.Value ?0:Convert.ToInt32(row["Status"]);
                data.Photo = row["Photo"].ToString();
                data.Established = row["Established"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["Established"]);
                data.CityID = row["CityID"] == DBNull.Value ? 0 : Convert.ToInt32(row["CityID"]);
                data.SetOpenFlag = row["OpenFlag"] == DBNull.Value ? 0 : Convert.ToInt32(row["OpenFlag"]);
                return data;
            }
            return null;
        }

        /// <summary>
        /// 管理员获取企业项目列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianhzenyun 2012-04-25</remarks>
        public DataTable GetList(E_Item data)
        {
            SqlParameter[] parms =
            {               
                new SqlParameter("@ItemName",SqlDbType.VarChar,128),
                new SqlParameter("@Status",SqlDbType.Int),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.ItemName;
            parms[1].Value = (int)data.Status;
            parms[2].Value = data.Page.PageIndex;
            parms[3].Value = data.Page.PageSize;
            parms[4].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Item_SelectList",parms);
            data.Page.TotalCount = parms[4].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[4].Value);
            return dt;
        }

        /// <summary>
        /// 管理员修改企业项目的申核状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianhzenyun 2012-04-25</remarks>
        public bool UpdateStatus(E_Item data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@Status",SqlDbType.TinyInt)
            };

            parms[0].Value = data.EnterpriseID;
            parms[1].Value = (int)data.Status;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_Item_UpdateStatus", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 后台管理员删除企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-26</remarks>
        public bool Delete(E_Item data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };

            parms[0].Value = data.EnterpriseID;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_Item_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 个人用户查看已申核通过的企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianhzenyun 2012-04-26</remarks>
        public DataTable PersonGetList(E_Item data)
        {
            SqlParameter[] parms =
            {                
                new SqlParameter("@ItemName",SqlDbType.VarChar,128),
                new SqlParameter("@Status",SqlDbType.TinyInt),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.ItemName;
            parms[1].Value = (int)ItemStatus.公开;
            parms[2].Value = data.Page.PageIndex;
            parms[3].Value = data.Page.PageSize;
            parms[4].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_Item_SelectList", parms);
            data.Page.TotalCount = parms[4].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[4].Value);
            return dt;
        }

        /// <summary>
        /// 后台管理员开通企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-11</remarks>
        public bool UpdateOpenFlag(E_Item data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@ItemID",SqlDbType.Int),
                new SqlParameter("@OpenFlag",SqlDbType.TinyInt)
            };

            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ItemID;
            parms[2].Value = (int)data.OpenFlag;

            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_Item_UpdateOpenFlag", parms, out ReturnValue);
            return ReturnValue > 0;
        }
    }
}
