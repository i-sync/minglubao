﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Material;


namespace MLMGC.BLL.Enterprise.Material
{
    /// <summary>
    /// 企业话术
    /// </summary>
    public class T_Talk
    {
        MLMGC.IDAL.Enterprise.Material.I_D_Talk dal = MLMGC.DALFactory.Enterprise.Material.F_D_Talk.Create();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(E_Talk data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(E_Talk data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Delete(E_Talk data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Talk GetModel(E_Talk data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 得到话术列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Talk data)
        {
            return dal.GetList(data);
        }
    }
}