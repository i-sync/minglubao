using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 日志
    /// </summary>
    public class E_Log
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 日志编号
        /// </summary>
        public int LogID { get; set; }
        /// <summary>
        /// 用户编号 
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string LogTitle { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 数据分页
        /// </summary>
        public E_Page Page { get; set; }
    }
}
