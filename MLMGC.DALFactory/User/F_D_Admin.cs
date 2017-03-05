using System;
using System.Collections.Generic;
using MLMGC.IDAL.User;

namespace MLMGC.DALFactory.User
{
    /// <summary>
    /// 管理员管理
    /// </summary>
    public abstract class F_D_Admin
    {
        public static I_D_Admin Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".User.D_Admin";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (MLMGC.IDAL.User.I_D_Admin)objType;
        }
    }
}
