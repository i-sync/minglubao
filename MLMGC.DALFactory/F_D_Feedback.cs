using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL;

namespace MLMGC.DALFactory
{
    /// <summary>
    /// 问题反馈
    /// </summary>
    public abstract class F_D_Feedback
    {
        public static I_D_Feedback Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".D_Feedback";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Feedback)objType;
        }
    }
}
