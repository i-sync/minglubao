using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise.Config;

namespace MLMGC.DALFactory.Enterprise.Config
{
    /// <summary>
    /// 企业最低标准
    /// </summary>
    public abstract class F_D_Standard
    {
        public static I_D_Standard Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.Config.D_Standard";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Standard)objType;
        }
    }
}
