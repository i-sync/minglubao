using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity;

namespace MLMGC.IDAL
{
    public interface I_D_Region
    {
        /// <summary>
        /// 获取所有地区
        /// </summary>
        /// <returns></returns>
        DataTable GetList();
    }
}
