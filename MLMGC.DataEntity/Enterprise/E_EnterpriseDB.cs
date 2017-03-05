using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    public class E_EnterpriseDB
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int EnterpriseDBID { get; set; }

        /// <summary>
        /// 数据库文件存放位置
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DBName { get; set; }

        /// <summary>
        /// 存放企业数量
        /// </summary>
        public int EnterpriseNum { get; set; }

        /// <summary>
        /// 是否为默认数据库
        /// </summary>
        public int DefaultFlag { get; set; }

        /// <summary>
        /// 数据库最大容纳多少个企业
        /// </summary>
        public int MaxNum { get; set; }
        /// <summary>
        /// 数据分页
        /// </summary>
        public E_Page Page { get; set; }
    }
}
