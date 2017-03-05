using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;
using System.Data;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 企业名录信息
    /// </summary>
    public class T_ClientInfo
    {
        MLMGC.IDAL.Enterprise.I_D_ClientInfo dal = MLMGC.DALFactory.Enterprise.F_D_ClientInfo.Create();
        
        /// <summary>
        /// 判断名录名称是否存在 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-02</remarks>
        public DataTable Exists(E_ClientInfo data)
        {
            return dal.Exists(data);
        }
        /// <summary>
        /// 录入新名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(E_ClientInfo data)
        {
            return dal.Add(data);
        }
        #region 业务人员 名录列表
        /// <summary>
        /// 获取名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_ClientInfo data)
        {
            if (data.Mode == EnumClientMode.业务员)
            {
                switch (data.Status)
                {
                    case EnumClientStatus.潜在客户:
                        return dal.GetLatenceList(data);                        
                    case EnumClientStatus.意向客户:
                        return dal.GetWishList(data);
                    case EnumClientStatus.成交客户:
                        return dal.GetTradedList(data);
                    default:
                        return dal.GetList(data);
                }
            }
            else if (data.Mode == EnumClientMode.共享)
            {
                return dal.GetShareList(data);
            }
            return null;
        }
        #endregion

        #region 领导获取名录列表
        /// <summary>
        /// 领导 统计信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-19</remarks>
        public DataTable LeaderStatistics(E_ClientInfo data)
        {
            return dal.LeaderStatistics(data);
        }
        /// <summary>
        /// 领导 统计 失败
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-24</remarks>
        public DataTable LeaderStatisticsNotTraded(E_ClientInfo data)
        {
            return dal.LeaderStatisticsNotTraded(data);
        }
        /// <summary>
        /// 领导 统计 报废
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-24</remarks>
        public DataTable LeaderStatisticsScrap(E_ClientInfo data)
        {
            return dal.LeaderStatisticsScrap(data);
        }
        /// <summary>
        /// 领导  统计 成交名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-24</remarks>
        public DataTable LeaderStatisticsTraded(E_ClientInfo data)
        {
            return dal.LeaderStatisticsTraded(data);
        }
        /// <summary>
        /// 领导模糊查询列表(第一个为查询列表、第二为统计)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-19</remarks>
        public DataSet LeaderList(E_ClientInfo data)
        {
            return dal.LeaderList(data);
        }
        /// <summary>
        /// 领导查询待分配列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-19</remarks>
        public DataTable LeaderWaitList(E_ClientInfo data)
        {
            return dal.LeaderWaitList(data);
        }
        /// <summary>
        /// 领导查询潜在客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-20</remarks>
        public DataTable LeaderLatenceList(E_ClientInfo data)
        {
            return dal.LeaderLatenceList(data);
        }
        /// <summary>
        /// 领导查询意向客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-20</remarks>
        public DataTable LeaderWishList(E_ClientInfo data)
        {
            return dal.LeaderWishList(data);
        }
        /// <summary>
        /// 领导查询成交客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-21</remarks>
        public DataTable LeaderTradedList(E_ClientInfo data)
        {
            return dal.LeaderTradedList(data);
        }
        /// <summary>
        /// 领导查询失败客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-21</remarks>
        public DataTable LeaderNotTradedList(E_ClientInfo data)
        {
            return dal.LeaderNotTradedList(data);
        }
        /// <summary>
        /// 领导查询报废客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengefi 2011-10-21</remarks>
        public DataTable LeaderScrapList(E_ClientInfo data)
        {
            return dal.LeaderScrapList(data);
        }

        #endregion

        /// <summary>
        /// 获取共享名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetShareList(E_ClientInfo data)
        {
            return dal.GetShareList(data);
        }

        /// <summary>
        /// 获取名录详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-13</remarks>
        public E_ClientInfo GetModel(E_ClientInfo data)
        {
            return dal.GetModel(data);
        }
        /// <summary>
        /// 修改名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-13</remarks>
        public bool Update(E_ClientInfo data)
        {
            return dal.Update(data);
        }
        /// <summary>
        /// 批量名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-21</remarks>
        public bool Delete(E_ClientInfo data)
        {
            return dal.Delete(data);
        }
        /// <summary>
        /// 修改名录状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-13</remarks>
        public bool UpdateStatus(E_ClientInfo data)
        {
            return dal.UpdateStatus(data);
        }
        /// <summary>
        /// 修改名录位置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateMode(E_ClientInfo data)
        {
            return dal.UpdateMode(data);
        }
        /// <summary>
        /// 获取状态列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2010-10-14</remarks>
        public DataTable GetStatusList(E_ClientInfo data)
        {
            return dal.GetStatusList(data);
        }
        /// <summary>
        /// 将名录转为自己所用
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-18</remarks>
        public bool ShiftShare(E_ClientInfo data)
        {
            return dal.ShiftShare(data);
        }

        /// <summary>
        /// 删除某状态下的所有名录（报废、失败、共享）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-06</remarks>
        public bool DeleteAll(E_ClientInfo data)
        {
            return dal.DeleteAll(data);
        }

        /// <summary>
        /// 共享某状态下的所有名录（报废、失败）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-06</remarks>
        public bool ShareAll(E_ClientInfo data)
        {
            return dal.ShareAll(data);
        }

        #region 数量统计
        /// <summary>
        /// 获取待分配名录数量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-28</remarks>
        public int WaitCount(E_ClientInfo data)
        {
            return dal.WaitCount(data);
        }
        #endregion
    }
}
