using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL;

namespace MLMGC.DALFactory
{
    public abstract class F_D_Region
    {
        public static I_D_Region Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".D_Region";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Region)objType;
        }
    }
}
