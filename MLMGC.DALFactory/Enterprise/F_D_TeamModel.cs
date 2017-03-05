using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    public class F_D_TeamModel
    {
        public static I_D_TeamModel Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_TeamModel";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_TeamModel)objType;
        }
    }
}
