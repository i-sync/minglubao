using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    public class E_Weibo
    {
        /// <summary>
        /// 企业号
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 微博编号
        /// </summary>
        public int WeiboID { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 微博内容
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string TrueName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 分页参数
        /// </summary>
        public E_Page Page { get; set; }
    }
}
