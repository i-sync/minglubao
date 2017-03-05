using System;
using System.Collections.Generic;
using MLMGC.IDAL.User;


namespace MLMGC.DALFactory.User
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public abstract class F_D_User
    {
        public static I_D_User Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".User.D_User";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (MLMGC.IDAL.User.I_D_User)objType;
        }
    }
}
