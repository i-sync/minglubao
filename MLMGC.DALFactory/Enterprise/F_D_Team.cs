using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;
namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 团队管理
    /// </summary>
    public abstract class F_D_Team
    {
        public static I_D_Team Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Team";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Team)objType;
        }
    }
}
