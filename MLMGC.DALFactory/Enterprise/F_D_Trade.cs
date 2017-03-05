using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 行业属性
    /// </summary>
    public abstract class F_D_Trade
    {
        public static I_D_Trade Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Trade";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Trade)objType;
        }
    }
}
