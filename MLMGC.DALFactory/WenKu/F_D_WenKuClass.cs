using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.WenKu;

namespace MLMGC.DALFactory.WenKu
{
    /// <summary>
    /// 文库分类
    /// </summary>
    public abstract class F_D_WenKuClass
    {
        public static I_D_WenKuClass Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".WenKu.D_WenKuClass";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_WenKuClass)objType;
        }
    }
}
