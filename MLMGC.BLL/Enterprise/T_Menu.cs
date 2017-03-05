using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.IDAL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class T_Menu
    {
        MLMGC.IDAL.Enterprise.I_D_Menu dal = MLMGC.DALFactory.Enterprise.F_D_Menu.Create();

        /// <summary>
        /// 修改菜单提示信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        public bool UpdateMenuTips(E_Menu data)
        {
            return dal.UpdateMenuTips(data);
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        public DataTable GetMenuList()
        {
            return dal.GetMenuList();
        }

        /// <summary>
        /// 获取菜单提示列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        public DataTable GetMenuTipsList(E_Menu data)
        {
            return dal.GetMenuTipsList(data);
        }

        /// <summary>
        /// 根据菜单的url获取对应提示信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        //TODO:该方法未使用
        public DataTable GetMenuTips(E_Menu data)
        {
            return dal.GetMenuTips(data);
        }
    }
}
