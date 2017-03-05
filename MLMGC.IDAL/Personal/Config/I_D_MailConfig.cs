using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Personal.Config;

namespace MLMGC.IDAL.Personal.Config
{
    /// <summary>
    /// 邮件发送配置
    /// </summary>
    public interface I_D_MailConfig
    {
        /// <summary>
        /// 获取邮件配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_MailConfig GetConfig(E_MailConfig data);
        /// <summary>
        /// 修改邮件配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool SetConfig(E_MailConfig data);
    }
}
