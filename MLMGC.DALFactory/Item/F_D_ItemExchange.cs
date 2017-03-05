using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DALFactory.Item;
using MLMGC.IDAL.Item;

namespace MLMGC.DALFactory.Item
{
    public abstract class F_D_ItemExchange
    {
        public static I_D_ItemExchange Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Item.D_ItemExchange";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_ItemExchange)objType;
        } 
    }
}
