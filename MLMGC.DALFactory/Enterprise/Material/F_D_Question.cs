using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise.Material;

namespace MLMGC.DALFactory.Enterprise.Material
{
    /// <summary>
    /// 调查问题
    /// </summary>
    public abstract class F_D_Question
    {
        public static I_D_Question Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.Material.D_Question";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Question)objType;
        }
    }
}
