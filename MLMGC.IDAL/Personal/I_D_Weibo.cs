using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal;

namespace MLMGC.IDAL.Personal
{
    /// <summary>
    /// 微博
    /// </summary>
    public interface I_D_Weibo
    {
        /// <summary>
        /// 发布微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        bool Add(E_Weibo data);

        /// <summary>
        /// 获取微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        DataTable GetList(E_Weibo data);

        /// <summary>
        /// 获取新微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        DataTable GetNewList(E_Weibo data);
        /// <summary>
        /// 获取首页显示微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        DataTable GetMainList(E_Weibo data);

        /// <summary>
        /// 个人用户获取自己的微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        DataTable SelfList(E_Weibo data);

        /// <summary>
        /// 个人用户删除自己发布的微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        bool Delete(E_Weibo data);

        /// <summary>
        /// 个人微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-21</remarks>
        DataTable List(E_Weibo data);

        /// <summary>
        /// 后台管理员查看所有个人微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-08</remarks>
        DataTable AdminList(E_Weibo data);

        /// <summary>
        /// 后台管理员删除个人微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-08</remarks>
        bool AdminDelete(E_Weibo data);
    }
}
