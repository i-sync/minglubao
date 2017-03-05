using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.IDAL.Enterprise;
using MLMGC.DBUtility;


namespace MLMGC.DAL.Enterprise
{
    public class D_Apply:I_D_Apply
    {
        /// <summary>
        /// 企业用户申请
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-11</remarks>
        public bool Add(E_Apply data)
        {
            int rowsAffected = 0;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseName",SqlDbType.VarChar,128),
                new SqlParameter("@Address",SqlDbType.VarChar,128),
                new SqlParameter("@Linkman",SqlDbType.VarChar,64),
                new SqlParameter("@Position",SqlDbType.VarChar,64),
                new SqlParameter("@Tel",SqlDbType.VarChar,32),
                new SqlParameter("@Email",SqlDbType.VarChar,128),
                new SqlParameter("@Mobile",SqlDbType.VarChar,32),
                new SqlParameter("@Fax",SqlDbType.VarChar,32),
                new SqlParameter("@UserAmount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseName;
            parms[1].Value = data.Address;
            parms[2].Value = data.Linkman;
            parms[3].Value = data.Position;
            parms[4].Value = data.Tel;
            parms[5].Value = data.Email;
            parms[6].Value = data.Mobile;
            parms[7].Value = data.Fax;
            parms[8].Value = data.UserAmount;
            DbHelperSQL.RunProcedures("ProcEP_B_Apply_Insert", parms, out rowsAffected);
            return rowsAffected>0;
        }


        /// <summary>
        /// 删除企业申请
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-02</remarks>
        public bool Delete(E_Apply data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@ApplyID",SqlDbType.Int)
            };
            parms[0].Value = data.ApplyID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_Apply_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 查看企业申请详细信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-31</remarks>
        public E_Apply GetModel(E_Apply data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@ApplyID",SqlDbType.Int )
            };
            parms[0].Value = data.ApplyID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Apply_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                data.EnterpriseName = row["EnterpriseName"].ToString();
                data.Linkman = row["Linkman"].ToString();
                data.Position = row["Position"].ToString();
                data.Tel = row["Tel"].ToString();
                data.Email = row["Email"].ToString();
                data.Mobile = row["Mobile"].ToString();
                data.Fax = row["Fax"].ToString();
                data.Address = row["Address"].ToString();
                data.AddDate = Convert.ToDateTime(row["AddDate"]);
                data.UserAmount = Convert.ToInt32(row["UserAmount"]);
                return data;
            }
            return null;
        }

        /// <summary>
        /// 查看企业申请列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-31</remarks>
        public DataTable GetList(E_Apply data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseName",SqlDbType.VarChar,128),
                new SqlParameter("@StartDate",SqlDbType.SmallDateTime),
                new SqlParameter("@EndDate",SqlDbType.SmallDateTime),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@TotalCount",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseName;
            parms[1].Value = data.Page.StartDate;
            parms[2].Value = data.Page.EndDate;           
            parms[3].Value = data.Page.PageIndex;
            parms[4].Value = data.Page.PageSize;
            parms[5].Direction = ParameterDirection.Output;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Apply_ListSelect", parms);
            data.Page.TotalCount = parms[5].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[5].Value);
            return dt;
        }
    }
}