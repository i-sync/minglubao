using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    /// <summary>
    /// 项目留言
    /// </summary>
    public class E_ItemMessage
    {
        /// <summary>
        /// 留言编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 企业号
        /// </summary>
        public int EnterpriseID { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string EnterpriseName { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate { get; set; }

        /// <summary>
        /// 删除标识：1=未删除，0=删除
        /// </summary>
        public int DelFlag { get; set; }

        /// <summary>
        /// 数据分页
        /// </summary>
        public E_Page Page { get; set; }
    }
}
