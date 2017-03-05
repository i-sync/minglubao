using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Personal.Config;

namespace MLMGC.BLL.Personal.Config
{
    /// <summary>
    /// 属性设置
    /// </summary>
    public class T_Property
    {
        //MLMGC.IDAL.Enterprise.I_D_Property dal = MLMGC.DALFactory.Enterprise.F_D_Property.Create();
        MLMGC.IDAL.Personal.Config.I_D_Property dal = MLMGC.DALFactory.Personal.Config.F_D_Property.Create();

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
