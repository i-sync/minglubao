using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 企业名录信息
    /// </summary>
    public abstract class F_D_ClientInfo
    {
        public static I_D_ClientInfo Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_ClientInfo";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_ClientInfo)objType;
        }
    }
}
