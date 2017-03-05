using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 企业项目
    /// </summary>
    public abstract class F_D_Item
    {
        public static I_D_Item Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Item";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Item)objType;
        }
    }
}
