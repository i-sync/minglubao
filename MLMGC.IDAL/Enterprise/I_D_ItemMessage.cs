using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 项目留言
    /// </summary>
    public interface I_D_ItemMessage
    {
        /// <summary>
        /// 添加留言信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-27</remarks>
        bool Add(E_ItemMessage data);

        /// <summary>
        /// 查看留言列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-27</remarks>
        DataTable GetList(E_ItemMessage data);

        /// <summary>
        /// 管理员获取项目留言列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-28</remarks>
        DataTable AdminGetList(E_ItemMessage data);

        /// <summary>
        /// 总监删除留言
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-27</remarks>
        bool Delete(E_ItemMessage data);
        /// <summary>
        /// 后台管理员真正删除
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool AdminDelete(E_ItemMessage data);
    }
}
