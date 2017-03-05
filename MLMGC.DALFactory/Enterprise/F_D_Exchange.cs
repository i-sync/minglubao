using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 名录沟通记录
    /// </summary>
    public abstract class F_D_Exchange
    {
        public static I_D_Exchange Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Exchange";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Exchange)objType;
        }
    }
}
