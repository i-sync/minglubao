using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal.Config;

namespace MLMGC.DALFactory.Personal.Config
{
    /// <summary>
    /// 名录属性配置
    /// </summary>
    public abstract class F_D_Property
    {
        public static I_D_Property Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.Config.D_Property";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Property)objType;
        }
    }
}
