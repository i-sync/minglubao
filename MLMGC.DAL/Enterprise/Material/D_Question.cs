using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Enterprise.Material;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DBUtility;
using MLMGC.COMP;

namespace MLMGC.DAL.Enterprise.Material
{
    /// <summary>
    /// 调查问题
    /// </summary>
    public class D_Question:MLMGC.IDAL.Enterprise.Material.I_D_Question
    {
        /// <summary>
        /// 增加问题
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks >tianzhenyun 2011-10-14</remarks>
        public bool Add(E_Question data)
        {
            int rowsAffected = 0;
                        
            string child_ItemNameS = string.Empty;
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@QuestionID",SqlDbType .Int ),
                new SqlParameter ("@EnterpriseID",SqlDbType .Int ),
                new SqlParameter ("@QuestionName",SqlDbType .VarChar ,128),
                new SqlParameter ("@QuestionType",SqlDbType.TinyInt),
                new SqlParameter ("@Child_Item",SqlDbType .VarChar),
                new SqlParameter ("@Separation",SqlDbType.VarChar ,2)
            };
            parms[0].Direction = ParameterDirection.Output;
            parms[1].Value = data.EnterpriseID;
            parms[2].Value = data.QuestionName;
            parms[3].Value = data.QuestionType;
            //拼装child_Item
            for (int i = 0; i < data.QuestionItem.Count; i++)
            {
                if (i == 0)
                {
                    child_ItemNameS = data.QuestionItem[i].QuestionItemName;
                }
                else
                {
                    //加上分隔符
                    child_ItemNameS +=MLMGC.COMP.Config.Separation + data.QuestionItem[i].QuestionItemName;
                }
            }
            parms[4].Value = child_ItemNameS;
            parms[5].Value = MLMGC.COMP.Config.Separation;
           
            DbHelperSQL.ExecProcedure("ProcEP_B_QuestionS_Insert", parms, out rowsAffected);
            data.QuestionID = Convert.ToInt32(parms[0].Value);

            return rowsAffected > 0;
        }
        /// <summary>
        /// 更新问题
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-14</remarks>
        public bool Update(E_Question data)
        {
            int rowsAffected = 0;
            
            string child_ItemIDs = string.Empty;
            string child_ItemNameS = string.Empty;
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@QuestionID",SqlDbType .Int ),
                new SqlParameter ("@EnterpriseID",SqlDbType .Int ),
                new SqlParameter ("@QuestionName",SqlDbType .VarChar ,128),
                new SqlParameter ("@QuestionType",SqlDbType.TinyInt),
                new SqlParameter ("@Child_ItemIDs",SqlDbType .VarChar),
                new SqlParameter ("@Child_ItemNameS",SqlDbType.VarChar ),
                new SqlParameter ("@Separation",SqlDbType.VarChar ,2),
                new SqlParameter ("@Flag",SqlDbType.TinyInt )
            };
            parms[0].Value = data.QuestionID ;
            parms[1].Value = data.EnterpriseID;
            parms[2].Value = data.QuestionName;
            parms[3].Value = data.QuestionType;
            //拼装child_Item
            for (int i = 0; i < data.QuestionItem.Count; i++)
            {
                if (i == 0)
                {
                    child_ItemIDs = data.QuestionItem[i].QuestionItemID.ToString();
                    child_ItemNameS = data.QuestionItem[i].QuestionItemName;
                }
                else
                {
                    //加上分隔符
                    child_ItemIDs += MLMGC.COMP.Config.Separation + data.QuestionItem[i].QuestionItemID.ToString();
                    child_ItemNameS += MLMGC.COMP.Config.Separation + data.QuestionItem[i].QuestionItemName;
                }
            }
            parms[4].Value = child_ItemIDs;
            parms[5].Value = child_ItemNameS;
            parms[6].Value = MLMGC.COMP.Config.Separation;
            parms[7].Value = data.Flag;

            DbHelperSQL.ExecProcedure("ProcEP_B_QuestionS_Update", parms, out rowsAffected);

            return rowsAffected > 0;
        }
        /// <summary>
        /// 删除问题
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-14</remarks>
        public bool Delete(E_Question data)
        {
            int rowsAffected = 0;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@QuestionID",SqlDbType .Int ),
                new SqlParameter("@EnterpriseID",SqlDbType .Int )
            };
            parms[0].Value = data.QuestionID;
            parms[1].Value = data.EnterpriseID;
            DbHelperSQL.ExecProcedure("ProcEP_B_QuestionS_Delete", parms, out rowsAffected);

            return rowsAffected > 0;
        }
        /// <summary>
        /// 得到一个问题对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-14</remarks>
        public E_Question GetModel(E_Question data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@QuestionID",SqlDbType .Int ),
                new SqlParameter("@EnterpriseID",SqlDbType .Int )
            };
            parms[0].Value = data.QuestionID;
            parms[1].Value = data.EnterpriseID;            
            DataSet ds = DbHelperSQL.RunProcedureDataSet("ProcEP_B_QuestionS_Select", parms);
            DataTable questionTable = ds.Tables[0];
            DataTable itemTable = ds.Tables [1];
            if ( questionTable != null && questionTable.Rows.Count == 1)
            {
                data.QuestionName = questionTable.Rows[0]["QuestionName"].ToString();
                data.QuestionType = Convert.ToInt32(questionTable.Rows[0]["QuestionType"]);
                data.UpdateDate = Convert.ToDateTime(questionTable.Rows[0]["UpdateDate"]);
                //封装问题选项
                List<E_QuestionItem> list = null;
                if (itemTable != null && itemTable.Rows.Count > 0)
                {
                    list = new List<E_QuestionItem>();
                }
                E_QuestionItem item = null;
                foreach (DataRow row in itemTable.Rows)
                {
                    item = new E_QuestionItem();
                    item.QuestionItemID = Convert.ToInt32(row["QuestionItemID"]);
                    item.QuestionItemName = row["QuestionItemName"].ToString();
                    list.Add(item);
                }
                data.QuestionItem = list;
                return data;
            }
            return null;
        }
        /// <summary>
        /// 获取问题列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-14</remarks>
        public DataTable GetList(E_Question data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@QuestionName",SqlDbType.VarChar ,128),
                new SqlParameter ("@PageIndex",SqlDbType .Int),
                new SqlParameter ("@PageSize",SqlDbType .Int),
                new SqlParameter ("@TotalCount",SqlDbType .Int),
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.QuestionName;
            parms[2].Value = data.Page.PageIndex;
            parms[3].Value = data.Page.PageSize;
            parms[4].Direction = ParameterDirection.Output;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_QuestionS_ListSelect", parms);
            data.Page.TotalCount = parms[4].Value == DBNull.Value ? 0 : Convert.ToInt32(parms[4].Value);
            return dt;
        }

        /// <summary>
        /// 获取问题列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-04</remarks>
        public DataSet List(E_Question data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@ClientInfoID",SqlDbType .Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            DataSet ds = DbHelperSQL.RunProcedureDataSet("ProcEP_B_QuestionS_List", parms);
            return ds;
        }

        /// <summary>
        /// 更新调查问卷答案
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        public bool UpdateQuestion(E_Question data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter ("@EnterpriseID",SqlDbType .Int),
                new SqlParameter ("@ClientInfoID",SqlDbType .Int),
                new SqlParameter ("@EPUserTMRID",SqlDbType .Int ),
                new SqlParameter ("@QuestionItemIDs",SqlDbType.VarChar)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.ClientInfoID;
            parms[2].Value = data.EPUserTMRID;
            parms[3].Value = data.QuestionItemIDs;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_R_CIQuestionS_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 查询与该问题相关的名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        public DataTable ListSelect(E_Question data)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int ),
                new SqlParameter("@QuestionID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = data.QuestionID;
            return DbHelperSQL.RunProcedureTable("ProcEP_B_ClientInfoS_ListSelect", parms);
        }
    }
}
