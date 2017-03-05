using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal;

namespace MLMGC.DALFactory.Personal
{
    public abstract class F_D_Exchange
    {
        public static I_D_Exchange Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.D_Exchange";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Exchange)objType;
        }
    }
}
