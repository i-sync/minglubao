using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.WenKu;

namespace MLMGC.IDAL.WenKu
{
    /// <summary>
    /// 文库下载日志
    /// </summary>
    public interface I_D_WenKuDownload
    {
        /// <summary>
        /// 下载文档记录数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        bool Add(E_WenKuDownload data);

        /// <summary>
        /// 查看下载记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        DataTable GetList(E_WenKuDownload data);
    }
}
