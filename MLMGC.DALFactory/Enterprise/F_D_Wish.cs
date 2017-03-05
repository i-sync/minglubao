using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 意向进展
    /// </summary>
    public abstract class F_D_Wish
    {
        public static I_D_Wish Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Wish";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Wish)objType;
        }
    }
}
