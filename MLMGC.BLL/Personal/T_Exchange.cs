using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal;

namespace MLMGC.BLL.Personal
{
    /// <summary>
    /// 名录沟通记录
    /// </summary>
    public class T_Exchange
    {
        MLMGC.IDAL.Personal.I_D_Exchange dal = MLMGC.DALFactory.Personal.F_D_Exchange.Create();

        /// <summary>
        /// 添加沟通名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(E_Exchange data)
        {
            return dal.Add(data);
        }
        
        /// <summary>
        /// 获取沟通记录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Exchange data)
        {
            return dal.GetList(data);
        }
    }
}
