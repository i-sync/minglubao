using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal;

namespace MLMGC.DALFactory.Personal
{
    /// <summary>
    /// 微博
    /// </summary>
    public class F_D_Weibo
    {
        public static I_D_Weibo Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.D_Weibo";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Weibo)objType;
        }
    }
}
