using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Public;

namespace MLMGC.DALFactory.Public
{
    /// <summary>
    /// 公告（个人）
    /// </summary>
    public class F_D_Announcement
    {
        public static I_D_Announcement Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Public.D_Announcement";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Announcement)objType;
        }
    }
}
