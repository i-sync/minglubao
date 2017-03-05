using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.Enterprise;
using System.Data;

namespace MLMGC.IDAL.Enterprise
{
    public interface I_D_Weibo
    {
        /// <summary>
        /// 发布微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-05</remarks>
        bool Add(E_Weibo data);
        /// <summary>
        /// 获取微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2012-01-06</remarks>
        DataTable GetList(E_Weibo data);
        /// <summary>
        /// 获取新微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-01-06</remarks>
        DataTable GetNewList(E_Weibo data);
        /// <summary>
        /// 获取首页显示微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2012-01-07</remarks>
        DataTable GetMainList(E_Weibo data);

        /// <summary>
        /// 企业用户获取自己的微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        DataTable SelfList(E_Weibo data);

        /// <summary>
        /// 企业用户删除自己发布的微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        bool Delete(E_Weibo data);
    }
}
