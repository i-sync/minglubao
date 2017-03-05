using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 微博
    /// </summary>
    public abstract class F_D_Weibo
    {
        public static I_D_Weibo Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Weibo";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Weibo)objType;
        }
    }
}
