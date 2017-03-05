using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Public
{
    /// <summary>
    /// 公告（个人）
    /// </summary>
    public class E_Announcement
    {
        /// <summary>
        /// 公告编号
        /// </summary>
        public long AnnouncementID { get; set; }

        /// <summary>
        /// 公告标题
        /// </summary>
        public string AnnTitle { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        public string AnnContent { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate { get; set; }

        /// <summary>
        /// 要选择的前n条数据
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 数据分页
        /// </summary>
        public E_Page Page { get; set; }
    }
}
