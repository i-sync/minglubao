using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal;

namespace MLMGC.DALFactory.Personal
{
    /// <summary>
    /// 工作经验
    /// </summary>
    public abstract class F_D_JobExperience
    {
        public static I_D_JobExperience Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.D_JobExperience";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_JobExperience)objType;
        }
    }
}
