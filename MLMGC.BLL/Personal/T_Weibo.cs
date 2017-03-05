using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.BLL.Personal;
using MLMGC.DataEntity.Personal;
using MLMGC.IDAL.Personal;

namespace MLMGC.BLL.Personal
{
    public class T_Weibo
    {
        I_D_Weibo dal = MLMGC.DALFactory.Personal.F_D_Weibo.Create();

        /// <summary>
        /// 发布微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public bool Add(E_Weibo data)
        { 
            return dal.Add(data);
        }

        /// <summary>
        /// 获取微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public DataTable GetList(E_Weibo data)
        {
            return dal.GetList(data);
        }

        /// <summary>
        /// 获取新微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public DataTable GetNewList(E_Weibo data)
        {
            return dal.GetNewList(data);
        }

        /// <summary>
        /// 获取首页显示微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public DataTable GetMainList(E_Weibo data)
        {
            return dal.GetMainList(data);
        }

        /// <summary>
        /// 个人用户获取自己的微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        public DataTable SelfList(E_Weibo data)
        {
            return dal.SelfList(data);
        }

        /// <summary>
        /// 个人用户删除自己发布的微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        public bool Delete(E_Weibo data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 个人微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-21</remarks>
        public DataTable List(E_Weibo data)
        {
            return dal.List(data);
        }

        /// <summary>
        /// 后台管理员查看所有个人微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-08</remarks>
        public DataTable AdminList(E_Weibo data)
        {
            return dal.AdminList(data);
        }

        /// <summary>
        /// 后台管理员删除个人微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-08</remarks>
        public bool AdminDelete(E_Weibo data)
        {
            return dal.AdminDelete(data);
        }
    }
}
