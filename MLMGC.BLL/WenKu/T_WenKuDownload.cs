using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.WenKu;
using MLMGC.IDAL.WenKu;
using MLMGC.DALFactory.WenKu;

namespace MLMGC.BLL.WenKu
{
    /// <summary>
    /// 文库下载日志
    /// </summary>
    public class T_WenKuDownload
    {
        I_D_WenKuDownload dal = F_D_WenKuDownload.Create();

         /// <summary>
        /// 下载文档记录数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public bool Add(E_WenKuDownload data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 查看下载记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public DataTable GetList(E_WenKuDownload data)
        {
            return dal.GetList(data) ;
        }
    }
}
