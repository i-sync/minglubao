using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Item;

namespace MLMGC.DALFactory.Item
{
    /// <summary>
    /// 项目人员
    /// </summary>
    public abstract class F_D_ItemMember
    {
        public static I_D_ItemMember Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Item.D_ItemMember";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_ItemMember)objType;
        }
    }
}
