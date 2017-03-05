using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 企业数据库
    /// </summary>
    public abstract class F_D_EnterpriseDB
    {
        public static I_D_EnterpriseDB Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_EnterpriseDB";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_EnterpriseDB)objType;
        }
    }
}
