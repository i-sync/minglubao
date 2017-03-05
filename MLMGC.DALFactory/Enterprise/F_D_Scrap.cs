using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 报废理由
    /// </summary>
    public abstract class F_D_Scrap
    {
        public static I_D_Scrap Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Scrap";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Scrap)objType;
        }
    }
}
