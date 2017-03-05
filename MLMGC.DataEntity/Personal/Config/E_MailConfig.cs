using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Personal.Config
{
    /// <summary>
    /// 邮件配置
    /// </summary>
    [Serializable]
    public class E_MailConfig
    {
        /// <summary>
        /// 个人编号
        /// </summary>
        public int PersonalID { get; set; }       
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// SMTP服务器地址
        /// </summary>
        public string SMTP { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        ///发件 人昵称
        /// </summary>
        public string  Name { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
