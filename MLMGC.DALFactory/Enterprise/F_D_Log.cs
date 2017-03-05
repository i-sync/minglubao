using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class F_D_Log
    {
        public static I_D_Log Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Log";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Log)objType;
        }
    }
}
