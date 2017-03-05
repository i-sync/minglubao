using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;
namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 来源属性配置
    /// </summary>
    public abstract class F_D_Source
    {
        public static I_D_Source Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Source";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Source)objType;
        }
    }
}
