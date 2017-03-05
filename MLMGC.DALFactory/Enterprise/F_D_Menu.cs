using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class F_D_Menu
    {
        public static I_D_Menu Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Menu";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Menu)objType;
        }
    }
}
