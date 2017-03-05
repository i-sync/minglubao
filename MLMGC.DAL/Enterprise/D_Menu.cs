using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MLMGC.DataEntity.Enterprise;
using MLMGC.IDAL.Enterprise;
using MLMGC.DBUtility;

namespace MLMGC.DAL.Enterprise
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class D_Menu:I_D_Menu
    {
        /// <summary>
        /// 修改菜单提示信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        public bool UpdateMenuTips(E_Menu data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@MenuID",SqlDbType.Int),
                new SqlParameter("@TipsIDs",SqlDbType.VarChar),
                new SqlParameter("@TipsNameS",SqlDbType.VarChar),
                new SqlParameter("@Separation",SqlDbType.VarChar,2)
            };
            parms[0].Value = data.MenuID;
            parms[1].Value = data.TipsIDs;
            parms[2].Value = data.TipsNameS;
            parms[3].Value = MLMGC.COMP.Config.Separation;
            int ReturnValue;
            DbHelperSQL.RunProcedures("ProcEP_B_PageTips_Update", parms, out ReturnValue);
            return ReturnValue > 0;
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        public DataTable GetMenuList()
        {
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_Menu_SelectList");
            return dt;
        }

        /// <summary>
        /// 获取菜单提示列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        public DataTable GetMenuTipsList(E_Menu data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@MenuID",SqlDbType.Int)
            };
            parms[0].Value = data.MenuID;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_PageTips_Select",parms);
            return dt;
        }

        /// <summary>
        /// 根据菜单的url获取对应提示信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        public DataTable GetMenuTips(E_Menu data)
        {
            SqlParameter[] parms =
            {
                new SqlParameter("@Url",SqlDbType.VarChar,128)
            };
            parms[0].Value = data.URL;
            DataTable dt = DbHelperSQL.RunProcedureTable("ProcEP_B_PageTipsS_Select", parms);
            return dt;
        }
    }
}
