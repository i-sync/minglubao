using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal.Config;

namespace MLMGC.DALFactory.Personal.Config
{
    /// <summary>
    /// 报废理由
    /// </summary>
    public abstract class F_D_Scrap
    {
        public static I_D_Scrap Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.Config.D_Scrap";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Scrap)objType;
        }
    }
}
