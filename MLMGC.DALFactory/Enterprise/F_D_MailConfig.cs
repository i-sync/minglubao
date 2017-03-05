using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 邮件配置
    /// </summary>
    public abstract class F_D_MailConfig
    {
        public static I_D_MailConfig Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_MailConfig";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_MailConfig)objType;
        }
    }
}
