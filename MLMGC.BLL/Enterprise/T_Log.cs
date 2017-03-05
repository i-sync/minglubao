using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class T_Log
    {
        I_D_Log dal = MLMGC.DALFactory.Enterprise.F_D_Log.Create();
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-09</remarks>
        public bool Add(E_Log data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 查看日志列表 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-09</remarks>
        public DataTable GetList(E_Log data)
        {
            return dal.GetList(data);
        }

        /// <summary>
        /// 删除指定日期之前的日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-09</remarks>
        public bool Delete(E_Log data)
        {
            return dal.Delete(data);
        }
    }
}
