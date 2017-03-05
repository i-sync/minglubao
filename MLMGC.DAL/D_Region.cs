using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity;
using MLMGC.DBUtility;
using MLMGC.IDAL;

namespace MLMGC.DAL
{
    public class D_Region:I_D_Region
    {
        /// <summary>
        /// 获取地区列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetList()
        {
            return DbHelperSQL.RunProcedureTable("ProcB_Region_SelectList");
        }
    }
}
