using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 名录属性配置
    /// </summary>
    public class D_Property:MLMGC.IDAL.Enterprise.I_D_Property
    {
        /// <summary>
        /// 获取名录属性配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Property Get(E_Property data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int)
            };
            parms[0].Value = data.EnterpriseID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_PropertyConfig_Select", parms);
            if (dt != null && dt.Rows.Count == 1)
            {
                data.PropertyConfigID =Convert.ToInt32(dt.Rows[0]["PropertyConfigID"].ToString());
                data.SourceFlag = dt.Rows[0]["SourceFlag"].ToString().Equals("1") ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
                data.TradeFlag = dt.Rows[0]["TradeFlag"].ToString().Equals("1") ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
                data.AreaFlag = dt.Rows[0]["AreaFlag"].ToString().Equals("1") ? EnumPropertyEnabled.启用 : EnumPropertyEnabled.禁用;
            }
            else
            {
                data = new E_Property();
            }
            return data;
        }
        /// <summary>
        /// 设置名录属性配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Set(E_Property data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@EnterpriseID",SqlDbType.Int),
                new SqlParameter("@SourceFlag",SqlDbType.TinyInt),
                new SqlParameter("@TradeFlag",SqlDbType.TinyInt),
                new SqlParameter("@AreaFlag",SqlDbType.TinyInt)
            };
            parms[0].Value = data.EnterpriseID;
            parms[1].Value = (int)data.SourceFlag;
            parms[2].Value = (int)data.TradeFlag;
            parms[3].Value = (int)data.AreaFlag;
            int ReturnValue = 0;
            DbHelperSQL.RunProcedures("ProcEP_B_PropertyConfig_Update", parms,out ReturnValue);
            return ReturnValue>0;
        }
    }
}
