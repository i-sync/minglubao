using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.WenKu;

namespace MLMGC.DALFactory.WenKu
{
    /// <summary>
    /// 文库
    /// </summary>
    public abstract class F_D_WenKu
    {
        public static I_D_WenKu Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".WenKu.D_WenKu";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_WenKu)objType;
        }
    }
}
