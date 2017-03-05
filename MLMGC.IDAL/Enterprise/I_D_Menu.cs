using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 菜单
    /// </summary>
    public interface I_D_Menu
    {
        /// <summary>
        /// 修改菜单提示信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        bool UpdateMenuTips(E_Menu data);

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        DataTable GetMenuList();

        /// <summary>
        /// 获取菜单提示列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        DataTable GetMenuTipsList(E_Menu data);

        /// <summary>
        /// 根据菜单的url获取对应提示信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-10</remarks>
        DataTable GetMenuTips(E_Menu data);
    }
}
