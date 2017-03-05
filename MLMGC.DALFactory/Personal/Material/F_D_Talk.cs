using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal.Material;

namespace MLMGC.DALFactory.Personal.Material
{
    /// <summary>
    /// 个人话术
    /// </summary>
    public abstract class F_D_Talk
    {
        public static I_D_Talk Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.Material.D_Talk";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Talk)objType;
        }
    }
}
