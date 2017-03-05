using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity
{
    /// <summary>
    /// 问题反馈
    /// </summary>
    [Serializable]
    public class E_Feedback
    {
        /// <summary>
        /// 反馈问题编号
        /// </summary>
        public int FeedbackID { get; set; }
        public int? EnterpriseID { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID { get; set; }        
        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 反馈标题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 反馈内容
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 反馈时间
        /// </summary>
        public DateTime AddDate { get; set; }

        /// <summary>
        /// 附件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 附件地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 附件类型
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 附件大小
        /// </summary>
        public int  FileSize { get; set; }

        /// <summary>
        /// 设置分页
        /// </summary>
        public E_Page Page { get; set; }
    }
}
