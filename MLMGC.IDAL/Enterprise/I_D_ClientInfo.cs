using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;
using System.Data;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 企业名录信息
    /// </summary>
    public interface I_D_ClientInfo
    {
        /// <summary>
        /// 判断名录名称是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-02</remarks>
        DataTable Exists(E_ClientInfo data);
        /// <summary>
        /// 录入新名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Add(E_ClientInfo data);
        #region 获取列表
        /// <summary>
        /// 获取名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_ClientInfo data);
        /// <summary>
        /// 获取业务员潜在名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>        
        DataTable GetLatenceList(E_ClientInfo data);
        /// <summary>
        /// 获取业务员意向名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetWishList(E_ClientInfo data);
        /// <summary>
        /// 获取业务员成交名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetTradedList(E_ClientInfo data);

        /// <summary>
        /// 获取共享名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-17</remarks>
        DataTable GetShareList(E_ClientInfo data);
        #endregion

        #region 领导名录列表
        /// <summary>
        /// 领导 统计信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-19</remarks>
        DataTable LeaderStatistics(E_ClientInfo data);
        /// <summary>
        /// 领导 统计 失败
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-24</remarks>
        DataTable LeaderStatisticsNotTraded(E_ClientInfo data);
        /// <summary>
        /// 领导 统计 报废
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-24</remarks>
        DataTable LeaderStatisticsScrap(E_ClientInfo data);
        /// <summary>
        /// 领导  统计 成交名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-24</remarks>
        DataTable LeaderStatisticsTraded(E_ClientInfo data);

        /// <summary>
        /// 领导模糊查询列表(第一个为查询列表、)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-19</remarks>
        DataSet LeaderList(E_ClientInfo data);
        /// <summary>
        /// 领导待分配列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable LeaderWaitList(E_ClientInfo data);
        /// <summary>
        /// 领导查询潜在客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-20</remarks>
        DataTable LeaderLatenceList(E_ClientInfo data);
        /// <summary>
        /// 领导查询意向客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-20</remarks>
        DataTable LeaderWishList(E_ClientInfo data);
        /// <summary>
        /// 领导查询成交客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-21</remarks>
        DataTable LeaderTradedList(E_ClientInfo data);
        /// <summary>
        /// 领导查询失败客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-21</remarks>
        DataTable LeaderNotTradedList(E_ClientInfo data);

        /// <summary>
        /// 领导查询报废客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-21</remarks>
        DataTable LeaderScrapList(E_ClientInfo data);
        
        #endregion

        /// <summary>
        /// 获取名录详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_ClientInfo GetModel(E_ClientInfo data);
        /// <summary>
        /// 修改名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-13</remarks>
        bool Update(E_ClientInfo data);
        /// <summary>
        /// 批量名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-21</remarks>
        bool Delete(E_ClientInfo data);
        /// <summary>
        /// 修改名录状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-13</remarks>
        bool UpdateStatus(E_ClientInfo data);
        /// <summary>
        /// 修改名录位置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool UpdateMode(E_ClientInfo data);
        /// <summary>
        /// 获取状态列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-14</remarks>
        DataTable GetStatusList(E_ClientInfo data);
        /// <summary>
        /// 将名录转为自己所用
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-18</remarks>
        bool ShiftShare(E_ClientInfo data);

        /// <summary>
        /// 获取待分配名录数量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-28</remarks>
        int WaitCount(E_ClientInfo data);

        /// <summary>
        /// 删除某状态下的所有名录（报废、失败、共享）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-06</remarks>
        bool DeleteAll(E_ClientInfo data);

        /// <summary>
        /// 共享某状态下的所有名录（报废、失败）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-06</remarks>
        bool ShareAll(E_ClientInfo data);
    }
}
