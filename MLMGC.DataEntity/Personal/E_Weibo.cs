using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Personal
{
    /// <summary>
    /// 微博
    /// </summary>
    public class E_Weibo
    {
        /// <summary>
        /// 微博编号
        /// </summary>
        public int WeiboID { get; set; }

        /// <summary>
        /// 微博编号集合
        /// </summary>
        public string WeiboIDs { get; set; }
        /// <summary>
        /// 个人编号 
        /// </summary>
        public int PersonalID { get; set; }

        /// <summary>
        /// 用户编号 
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 发布微博内容
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 发布微博时间
        /// </summary>
        public DateTime AddDate { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }


        /// <summary>
        /// 获取多少条数据
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 数据分页
        /// </summary>
        public E_Page Page { get; set; }
    }
}
