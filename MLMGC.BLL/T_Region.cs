using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DALFactory;
using MLMGC.DataEntity;
using MLMGC.IDAL;

namespace MLMGC.BLL
{
    /// <summary>
    /// 地区
    /// </summary>
    public class T_Region
    {
        I_D_Region dal = F_D_Region.Create();

        public DataTable GetList()
        {
            return dal.GetList();
        }
    }
}
