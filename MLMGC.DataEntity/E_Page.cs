using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity
{
    /// <summary>
    /// 分页参数
    /// </summary>
    [Serializable]
    public class E_Page
    {
        private int _pagesize = 20,_pageindex=1,_totalcount=0;
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize { set { _pagesize = value; } get { return _pagesize; } }
        /// <summary>
        /// 当前页码（从1开始）
        /// </summary>
        public int PageIndex { set { _pageindex = value; } get { return _pageindex; } }
        /// <summary>
        /// 记录总数
        /// </summary>
        public int TotalCount { set { _totalcount = value; } get { return _totalcount; } }
        /// <summary>
        /// 检索时间参数：开始时间
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 检索时间参数：截止时间
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
