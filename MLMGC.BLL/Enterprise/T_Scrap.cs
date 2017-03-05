using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 报废理由
    /// </summary>
    public class T_Scrap
    {
        MLMGC.IDAL.Enterprise.I_D_Scrap dal = MLMGC.DALFactory.Enterprise.F_D_Scrap.Create();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(E_Scrap data)
        {
            return dal.Exists(data);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_Scrap data)
        {
            return dal.Add(data);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_Scrap data)
        {
            return dal.Update(data);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(E_Scrap data)
        {
            return dal.Delete(data);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Scrap GetModel(E_Scrap data)
        {
            return dal.GetModel(data);
        }
        /// <summary>
        ///无分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Scrap data)
        {
            return dal.GetList(data);
        }
    }
}
