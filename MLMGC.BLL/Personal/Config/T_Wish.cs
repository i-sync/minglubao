using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal.Config;

namespace MLMGC.BLL.Personal.Config
{
    /// <summary>
    /// 意向进展
    /// </summary>
    public class T_Wish
    {
        //MLMGC.IDAL.Enterprise.I_D_Wish dal = MLMGC.DALFactory.Enterprise.F_D_Wish.Create();
        MLMGC.IDAL.Personal.Config.I_D_Wish dal = MLMGC.DALFactory.Personal.Config.F_D_Wish.Create();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(E_Wish data)
        {
            return dal.Exists(data);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_Wish data)
        {
            return dal.Add(data);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_Wish data)
        {
            return dal.Update(data);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(E_Wish data)
        {
            return dal.Delete(data);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Wish GetModel(E_Wish data)
        {
            return dal.GetModel(data);
        }
        /// <summary>
        ///无分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Wish data)
        {
            return dal.GetList(data);
        }
    }
}
