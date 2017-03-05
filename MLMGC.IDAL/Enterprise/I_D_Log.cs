using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Enterprise;
using System.Data;

namespace MLMGC.IDAL.Enterprise
{
    public interface I_D_Log
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-09</remarks>
        bool Add(E_Log data);

        /// <summary>
        /// 查看日志列表 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-09</remarks>
        DataTable GetList(E_Log data);

        /// <summary>
        /// 删除指定日期之前的日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-09</remarks>
        bool Delete(E_Log data);
    }
}
