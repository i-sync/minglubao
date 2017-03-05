using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal.Config;

namespace MLMGC.DALFactory.Personal.Config
{
    /// <summary>
    /// 失败理由
    /// </summary>
    public abstract class F_D_NotTraded
    {
        public static I_D_NotTraded Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.Config.D_NotTraded";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_NotTraded)objType;
        }
    }
}
