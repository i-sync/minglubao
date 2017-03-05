using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise.Material;

namespace MLMGC.DALFactory.Enterprise.Material
{
    /// <summary>
    /// 项目资料
    /// </summary>
    public abstract class F_D_Material
    {
        public static I_D_Material Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.Material.D_Material";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Material)objType;
        }
    }
}
