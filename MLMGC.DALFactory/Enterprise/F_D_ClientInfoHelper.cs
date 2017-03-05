using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 名录辅助操作
    /// </summary>
    public abstract class F_D_ClientInfoHelper
    {
        public static I_D_ClientInfoHelper Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_ClientInfoHelper";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_ClientInfoHelper)objType;
        }
    }
}
