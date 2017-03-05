using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise.Material;

namespace MLMGC.DALFactory.Enterprise.Material
{
    /// <summary>
    /// 学习资料
    /// </summary>
    public class F_D_StudyMaterial
    {
        public static I_D_StudyMaterial Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.Material.D_StudyMaterial";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_StudyMaterial)objType;
        }
    }
}
