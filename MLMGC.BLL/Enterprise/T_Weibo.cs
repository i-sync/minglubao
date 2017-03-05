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
    /// 微博
    /// </summary>
    public class T_Weibo
    {
        I_D_Weibo dal = MLMGC.DALFactory.Enterprise.F_D_Weibo.Create();

        /// <summary>
        /// 发布微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-05</remarks>
        public bool Add(E_Weibo data)
        {
            return dal.Add(data);
        }
        /// <summary>
        /// 获取微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2012-01-06</remarks>
        public DataTable GetList(E_Weibo data)
        {
            return dal.GetList(data);
        }
        /// <summary>
        /// 获取新微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-01-06</remarks>
        public DataTable GetNewList(E_Weibo data)
        {
            return dal.GetNewList(data);
        }
        /// <summary>
        /// 获取首页显示微博数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2012-01-07</remarks>
        public DataTable GetMainList(E_Weibo data)
        {
            return dal.GetMainList(data);
        }

        /// <summary>
        /// 企业用户获取自己的微博列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        public DataTable SelfList(E_Weibo data)
        {
            return dal.SelfList(data);
        }

        /// <summary>
        /// 企业用户删除自己发布的微博
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-02</remarks>
        public bool Delete(E_Weibo data)
        {
            return dal.Delete(data);
        }
    }
}
