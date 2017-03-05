using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
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
        bool ModifyConfig(E_MailConfig data);
    }
}
