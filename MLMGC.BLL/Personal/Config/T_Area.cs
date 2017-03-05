using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal.Config;

namespace MLMGC.BLL.Personal.Config
{
    /// <summary>
    /// 地区属性
    /// </summary>
    public class T_Area
    {
        //MLMGC.IDAL.Enterprise.I_D_Area dal = MLMGC.DALFactory.Enterprise.F_D_Area.Create();
        MLMGC.IDAL.Personal.Config.I_D_Area dal = MLMGC.DALFactory.Personal.Config.F_D_Area.Create();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(E_Area data)
        {
            return dal.Exists(data);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_Area data)
        {
            return dal.Add(data);
        }
        /// <summary>
        /// 批量增加地区
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        public bool BatchAdd(E_Area data)
        {
            return dal.BatchAdd(data);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_Area data)
        {
            return dal.Update(data);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(E_Area data)
        {
            return dal.Delete(data);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_Area GetModel(E_Area data)
        {
            return dal.GetModel(data);
        }
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetPageList(E_Area data)
        {
            return dal.GetPageList(data);
        }
        /// <summary>
        /// 获取绑定显示的列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetShowList(E_Area data)
        {
            return dal.GetShowList(data);
        }
    }
}
