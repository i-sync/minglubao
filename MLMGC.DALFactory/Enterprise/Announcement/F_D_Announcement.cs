using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise.Announcement;

namespace MLMGC.DALFactory.Enterprise.Announcement
{
    /// <summary>
    /// 企业公告
    /// </summary>
    public abstract class F_D_Announcement
    {
        public static I_D_Announcement Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.Announcement.D_Announcement";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Announcement)objType;
        }
    }
}
