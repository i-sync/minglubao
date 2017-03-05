using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 行业属性
    /// </summary>
    public class T_Trade
    {
        MLMGC.IDAL.Enterprise.I_D_Trade dal = MLMGC.DALFactory.Enterprise.F_D_Trade.Create();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(E_Trade data)
        {
            return dal.Exists(data);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_Trade data)
        {
            return dal.Add(data);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_Trade data)
        {
            return dal.Update(data);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(E_Trade data)
        {
            return dal.Delete(data);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Trade GetModel(E_Trade data)
        {
            return dal.GetModel(data);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Trade data)
        {
            return dal.GetList(data);
        }
        /// <summary>
        /// 获取绑定显示的列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetShowList(E_Trade data)
        {
            return dal.GetShowList(data);
        }
    }
}
