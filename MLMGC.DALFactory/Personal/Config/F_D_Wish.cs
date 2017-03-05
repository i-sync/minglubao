using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal.Config;

namespace MLMGC.DALFactory.Personal.Config
{
    /// <summary>
    /// 意向进展
    /// </summary>
    public abstract class F_D_Wish
    {
        public static I_D_Wish Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.Config.D_Wish";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Wish)objType;
        }
    }
}
