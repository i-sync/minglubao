using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 企业信息
    /// </summary>
    public abstract class F_D_Enterprise
    {
        public static I_D_Enterprise Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Enterprise";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Enterprise)objType;
        }
    }
}
