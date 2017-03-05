using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DALFactory.Item;
using MLMGC.IDAL.Item;

namespace MLMGC.DALFactory.Item
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class F_D_ItemClientInfo
    {
        public static I_D_ItemClientInfo Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Item.D_ItemClientInfo";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_ItemClientInfo)objType;
        } 
    }
}
