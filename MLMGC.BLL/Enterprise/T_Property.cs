using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    public class T_Property
    {
        MLMGC.IDAL.Enterprise.I_D_Property dal = MLMGC.DALFactory.Enterprise.F_D_Property.Create();

        /// <summary>
        /// 获取名录属性配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Property Get(E_Property data)
        {
            return dal.Get(data);
        }
        /// <summary>
        /// 设置名录属性配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Set(E_Property data)
        {
            return dal.Set(data);
        }
    }
}
