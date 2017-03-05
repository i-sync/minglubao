using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 名录分配
    /// </summary>
    public abstract class F_D_Allot
    {
        public static I_D_Allot Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Allot";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Allot)objType;
        }
    }
}
