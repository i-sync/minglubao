using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal;

namespace MLMGC.BLL.Personal
{
    public class T_ClientInfo
    {
        MLMGC.IDAL.Personal.I_D_ClientInfo dal = MLMGC.DALFactory.Personal.F_D_ClientInfo.Create();

        /// <summary>
        /// 判断名录名是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public bool Exists(E_ClientInfo data)
        {
            return dal.Exists(data);
        }

        /// <summary>
        /// 判断电话和手机是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-14</remarks>
        public DataTable ExistsContact(E_ClientInfo data)
        {
            return dal.ExistsContact(data);
        }
        /// <summary>
        /// 录入新名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public bool Add(E_ClientInfo data)
        {
            return dal.Add(data);
        }
        /// <summary>
        /// 修改名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-26</remarks>
        public bool Update(E_ClientInfo data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 删除名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        //TODO:该方法未使用
        public bool Delete(E_ClientInfo data)
        {
            return dal.Delete(data);
        }
        
        /// <summary>
        /// 批量删除名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        public bool BatchDelete(E_ClientInfo data)
        {
            return dal.BatchDelete(data);
        }
        /// <summary>
        /// 获取名录详细信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        public E_ClientInfo GetModel(E_ClientInfo data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 修改名录状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        public bool UpdateStatus(E_ClientInfo data)
        {
            return dal.UpdateStatus(data);
        }
        /// <summary>
        /// 获取名录状态操作列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-26</remarks>
        public DataTable GetStatusList(E_ClientInfo data)
        {
            return dal.GetStatusList(data);
        }

        #region 查询列表
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        public DataTable Select(E_ClientInfo data)
        {
            return dal.Select(data);
        }
        /// <summary>
        /// 查询潜在客户名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public DataTable LatenceSelect(E_ClientInfo data)
        {
            return dal.LatenceSelect(data);
        }
        
        /// <summary>
        /// 查询意向客户名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public DataTable WishSelect(E_ClientInfo data)
        {
            return dal.WishSelect(data);
        }
        
        /// <summary>
        /// 查询失败客户名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public DataTable NotTradeSelect(E_ClientInfo data)
        {
            return dal.NotTradeSelect(data);
        }

        /// <summary>
        /// 查询失败客户名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public DataTable ScrapSelect(E_ClientInfo data)
        {
            return dal.ScrapSelect(data);
        }

        /// <summary>
        /// 查询成交客户名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        public DataTable TradedSelect(E_ClientInfo data)
        {
            return dal.TradedSelect(data);
        }

        #endregion
        #region 数据导入 导出  qipengfei
        /// <summary>
        /// 名录数据导出
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        public DataSet DataExport(E_ClientInfo data)
        {
            return dal.DataExport(data);
        }

        #endregion

        #region 名录统计
        /// <summary>
        /// 名录统计信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        //TODO:该方法未使用
        public DataTable Statistics(E_ClientInfo data)
        {
            return dal.Statistics(data);
        }

        #endregion
    }
}
