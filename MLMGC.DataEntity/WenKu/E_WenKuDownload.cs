using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.User;

namespace MLMGC.DataEntity.WenKu
{
    /// <summary>
    /// 文库下载日志
    /// </summary>
    public class E_WenKuDownload
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 文库编号 
        /// </summary>
        public long WenKuID { get; set; }
        /// <summary>
        /// 扣除 名录币
        /// </summary>
        public float MoneyPoint { get; set; }
        /// <summary>
        /// 下载日期
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 企业编号
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType UserType { get; set; }
    }
}
