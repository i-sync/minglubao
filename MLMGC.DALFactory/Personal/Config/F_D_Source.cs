using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal.Config;

namespace MLMGC.DALFactory.Personal.Config
{
    /// <summary>
    /// 来源属性配置
    /// </summary>
    public abstract class F_D_Source
    {
        public static I_D_Source Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.Config.D_Source";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Source)objType;
        }
    }
}
