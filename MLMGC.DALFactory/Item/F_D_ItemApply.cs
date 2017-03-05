using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Item;

namespace MLMGC.DALFactory.Item
{
    /// <summary>
    /// 项目申请
    /// </summary>
    public abstract class F_D_ItemApply
    {
        public static I_D_ItemApply Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Item.D_ItemApply";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_ItemApply)objType;
        }
    }
}
