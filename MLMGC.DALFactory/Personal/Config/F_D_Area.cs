using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal.Config;

namespace MLMGC.DALFactory.Personal.Config
{
    /// <summary>
    /// 地区属性配置
    /// </summary>
    public abstract class F_D_Area
    {
        public static I_D_Area Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.Config.D_Area";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Area)objType;
        }
    }
}
