using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal.Config;

namespace MLMGC.DALFactory.Personal.Config
{
    /// <summary>
    /// 行业属性
    /// </summary>
    public abstract class F_D_Trade
    {
        public static I_D_Trade Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.Config.D_Trade";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Trade)objType;
        }
    }
}
