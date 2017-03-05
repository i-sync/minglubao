using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal;

namespace MLMGC.DALFactory.Personal
{
    /// <summary>
    /// 个人名录信息
    /// </summary>
    public abstract class F_D_ClientInfo
    {
        public static I_D_ClientInfo Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.D_ClientInfo";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_ClientInfo)objType;
        }
    }
}
