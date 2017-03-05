using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;
namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 邮件配置
    /// </summary>
    public class T_MailConfig
    {
        MLMGC.IDAL.Enterprise.I_D_MailConfig dal = MLMGC.DALFactory.Enterprise.F_D_MailConfig.Create();

        /// <summary>
        /// 获取邮件配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_MailConfig GetConfig(E_MailConfig data)
        {
            return dal.GetConfig(data);
        }
        /// <summary>
        /// 修改邮件配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ModifyConfig(E_MailConfig data)
        {
            return dal.ModifyConfig(data);
        }
    }
}
