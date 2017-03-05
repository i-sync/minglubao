using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Personal.Config;

namespace MLMGC.DALFactory.Personal.Config
{
    /// <summary>
    /// 邮件配置
    /// </summary>
    public abstract class F_D_MailConfig
    {
        public static I_D_MailConfig Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Personal.Config.D_MailConfig";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_MailConfig)objType;
        }
    }
}
