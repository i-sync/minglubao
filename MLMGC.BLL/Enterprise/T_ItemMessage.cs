using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 项目留言
    /// </summary>
    public class T_ItemMessage
    {
        I_D_ItemMessage dal = MLMGC.DALFactory.Enterprise.F_D_ItemMessage.Create();

        /// <summary>
        /// 添加留言信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-27</remarks>
        public bool Add(E_ItemMessage data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 查看留言列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-27</remarks>
        public DataTable GetList(E_ItemMessage data)
        {
            return dal.GetList(data);
        }

        /// <summary>
        /// 管理员获取项目留言列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-28</remarks>
        public DataTable AdminGetList(E_ItemMessage data)
        {
            return dal.AdminGetList(data);
        }

        /// <summary>
        /// 总监删除留言
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-27</remarks>
        public bool Delete(E_ItemMessage data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 后台管理员真正删除
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AdminDelete(E_ItemMessage data)
        {
            return dal.AdminDelete(data);
        }
    }
}
