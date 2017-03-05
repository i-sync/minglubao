using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;
using System.Data;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 名录沟通记录
    /// </summary>
    public class T_Exchange
    {
        MLMGC.IDAL.Enterprise.I_D_Exchange dal = MLMGC.DALFactory.Enterprise.F_D_Exchange.Create();
        /// <summary>
        /// 录入新沟通记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-14</remarks>
        public bool Add(E_Exchange data)
        {
            return dal.Add(data);
        }
        /// <summary>
        /// 获取名录下的沟通列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-14</remarks>
        public DataTable GetList(E_Exchange data)
        {
            return dal.GetList(data);
        }
    }
}
