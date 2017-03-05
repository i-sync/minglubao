using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class E_Menu
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MenuID { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单提示编号集合
        /// </summary>
        public string TipsIDs { get; set; }

        /// <summary>
        /// 菜单提示内容集合
        /// </summary>
        public string TipsNameS { get; set; }

        /// <summary>
        /// 菜单的URL
        /// </summary>
        public string URL { get; set; }
    }
}
