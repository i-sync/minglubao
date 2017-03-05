using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.User;

namespace MLMGC.DALFactory.User
{
    public abstract class F_D_Personal
    {
        /// <summary>
        /// 个人注册信息
        /// </summary>
        /// <returns></returns>
        public static I_D_Personal Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".User.D_Personal";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Personal)objType;
        }
    }
}
