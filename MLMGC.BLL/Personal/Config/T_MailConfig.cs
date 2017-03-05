using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Personal.Config;

namespace MLMGC.BLL.Personal.Config
{
    /// <summary>
    /// 邮件配置
    /// </summary>
    public class T_MailConfig
    {
        //MLMGC.IDAL.Enterprise.I_D_MailConfig dal = MLMGC.DALFactory.Enterprise.F_D_MailConfig.Create();
        MLMGC.IDAL.Personal.Config.I_D_MailConfig dal = MLMGC.DALFactory.Personal.Config.F_D_MailConfig.Create();

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
        public bool SetConfig(E_MailConfig data)
        {
            return dal.SetConfig(data);
        }
    }
}
