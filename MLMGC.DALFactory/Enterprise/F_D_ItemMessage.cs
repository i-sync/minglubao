using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 项目留言
    /// </summary>
    public abstract class F_D_ItemMessage
    {
        public static I_D_ItemMessage Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_ItemMessage";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_ItemMessage)objType;
        }
    }
}
