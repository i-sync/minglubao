using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 企业申请
    /// </summary>
    public abstract class F_D_Apply
    {
        public static I_D_Apply Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Apply";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Apply)objType;
        }
    }
}
