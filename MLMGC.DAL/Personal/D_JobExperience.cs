using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Personal;
using MLMGC.IDAL.Personal;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Personal
{
    /// <summary>
    /// 工作经验
    /// </summary>
    public class D_JobExperience:I_D_JobExperience
    {
        /// <summary>
        /// 添加工作经验
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>
        public bool Add(E_JobExperience data)
        {
            int ReturnValue;
            SqlParameter[] parms = 
            {
                new SqlParameter("@JobExperienceID", SqlDbType.BigInt),
				new SqlParameter("@PersonalID", SqlDbType.Int),
				new SqlParameter("@StartDate", SqlDbType.SmallDateTime),
				new SqlParameter("@EndDate", SqlDbType.SmallDateTime),
				new SqlParameter("@CompanyName", SqlDbType.VarChar,128),
				new SqlParameter("@Scale", SqlDbType.Int),
				new SqlParameter("@Departments", SqlDbType.VarChar,64),
				new SqlParameter("@Position", SqlDbType.VarChar,64),
                new SqlParameter("@JobDescription",SqlDbType.VarChar,512),
                new SqlParameter("@UserID",SqlDbType.Int)
            };
            parms[0].Direction = ParameterDirection.Output;
            parms[1].Value = data.PersonalID;
            parms[2].Value = data.StartDate;
            parms[3].Value = data.EndDate;
            parms[4].Value = data.CompanyName;
            parms[5].Value = (int)data.Scale;
            parms[6].Value = data.Departments;
            parms[7].Value = data.Position;
            parms[8].Value = data.JobDescription;
            parms[9].Value = data.UserID;
            DbHelperSQL.RunProcedures("ProcPI_B_JobExperienceS_Insert", parms, out ReturnValue);
            data.JobExperienceID = Convert.ToInt32(parms[0].Value);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 修改工作经验
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>
        public bool Update(E_JobExperience data)
        { 
            int ReturnValue;
            SqlParameter[] parms = 
            {
                new SqlParameter("@JobExperienceID", SqlDbType.BigInt),
				new SqlParameter("@PersonalID", SqlDbType.Int),
				new SqlParameter("@StartDate", SqlDbType.SmallDateTime),
				new SqlParameter("@EndDate", SqlDbType.SmallDateTime),
				new SqlParameter("@CompanyName", SqlDbType.VarChar,128),
				new SqlParameter("@Scale", SqlDbType.Int),
				new SqlParameter("@Departments", SqlDbType.VarChar,64),
				new SqlParameter("@Position", SqlDbType.VarChar,64),
                new SqlParameter("@JobDescription",SqlDbType.VarChar,512),
                new SqlParameter("@UserID",SqlDbType.Int)
            };
            parms[0].Value = data.JobExperienceID;
            parms[1].Value = data.PersonalID;
            parms[2].Value = data.StartDate;
            parms[3].Value = data.EndDate;
            parms[4].Value = data.CompanyName;
            parms[5].Value = (int)data.Scale;
            parms[6].Value = data.Departments;
            parms[7].Value = data.Position;
            parms[8].Value = data.JobDescription;
            parms[9].Value = data.UserID;
            DbHelperSQL.RunProcedures("ProcPI_B_JobExperienceS_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 删除工作经验
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>
        public bool Delete(E_JobExperience data)
        { 
            SqlParameter[] parms = 
            {
                new SqlParameter("@JobExperienceID", SqlDbType.BigInt),
				new SqlParameter("@PersonalID", SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int)
            };
            parms[0].Value = data.JobExperienceID;
            parms[1].Value = data.PersonalID;
            parms[2].Value = data.UserID;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcPI_B_JobExperienceS_Delete", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 查看工作经验列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>        
        public DataTable GetList(E_JobExperience data)
        {
            SqlParameter[] parms = 
            {
				new SqlParameter("@PersonalID", SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int)
            };
            parms[0].Value = data.PersonalID;
            parms[1].Value = data.UserID;

            return DbHelperSQL.RunProcedureTable("ProcPI_B_JobExperienceS_SelectList", parms);
        }

        /// <summary>
        /// 获取工作经验对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-09</reamrks>  
        public E_JobExperience GetModel(E_JobExperience data)
        {
            SqlParameter[] parms = 
            {
                new SqlParameter("@JobExperienceID", SqlDbType.BigInt),
				new SqlParameter("@PersonalID", SqlDbType.Int),
                new SqlParameter("@UserID",SqlDbType.Int)
            };
            parms[0].Value = data.JobExperienceID;
            parms[1].Value = data.PersonalID;
            parms[2].Value = data.UserID;

            DataTable dt = DbHelperSQL.RunProcedureTable("ProcPI_B_JobExperienceS_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                
                //封装对象
                data.StartDate = row["StartDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["StartDate"]);
                if (row["EndDate"] != DBNull.Value)
                {
                    data.EndDate = Convert.ToDateTime(row["EndDate"]);
                }
                data.CompanyName = row["CompanyName"].ToString();
                data.SetScale = row["Scale"] == DBNull.Value ? 0 : Convert.ToInt32(row["Scale"]);
                data.Departments = row["Departments"].ToString();
                data.Position = row["Position"].ToString();
                data.JobDescription = row["JobDescription"].ToString();
                return data;
            }
            return null;
        }
    }
}
