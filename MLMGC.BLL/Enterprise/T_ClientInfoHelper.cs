using System;
using System.Data;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 企业名录辅助操作
    /// </summary>
    public class T_ClientInfoHelper
    {
        MLMGC.IDAL.Enterprise.I_D_ClientInfoHelper dal = MLMGC.DALFactory.Enterprise.F_D_ClientInfoHelper.Create();

        /// <summary>
        /// 判断电话和手机是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-09</remarks>
        public DataTable ExistsContact(E_ClientInfoHelper data)
        {
            return dal.ExistsContact(data);
        }

        /// <summary>
        /// 预约
        /// </summary>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-07</remarks>
        public bool Reservation(E_Reservation data)
        {
            return dal.Reservation(data);
        }

        /// <summary>
        /// 查询预约列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        public DataTable GetReservationList(E_ClientInfoHelper data)
        {
            return dal.GetReservationList(data);
        }
        /// <summary>
        /// 获取窗口提醒名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-23</remarks>
        public DataTable GetReservationNow(E_Reservation data)
        {
            return dal.GetReservationNow(data);
        }

        /// <summary>
        /// 删除预约名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        public bool DeleteReservation(E_Reservation data)
        {
            return dal.DeleteReservation(data);
        }

        /// <summary>
        /// 获取指定名录上一个、下一个
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-08</remarks>
        public DataTable PrevNext(E_ClientInfoHelper data)
        {
            return dal.PrevNext(data);
        }

        /// <summary>
        /// 获取邮箱/手机 列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-08</remarks>
        public DataTable SelectOperate(E_ClientInfoHelper data)
        {
            return dal.SelectOperate(data);
        }

        /// <summary>
        /// 获取按属性对比
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Flag">source/area/trade</param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-10</remarks>
        public DataTable ComparisonProperty(E_ClientInfoHelper data, string Flag)
        {
            return dal.ComparisonProperty(data, Flag);
        }

        /// <summary>
        /// 按Team对比
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-11</remarks>
        public DataTable ComparisonTeam(E_ClientInfoHelper data)
        {
            return dal.ComparisonTeam(data);
        }
        /// <summary>
        /// 按销售人员对比
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-10</remarks>
        public DataTable ComparisonSalesman(E_ClientInfoHelper data)
        {
            return dal.ComparisonSalesman(data);
        }
        /// <summary>
        /// 按时间对比
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-11</remarks>
        public DataTable ComparisonDate(E_ClientInfoHelper data)
        {
            return dal.ComparisonDate(data);
        }

        /// <summary>
        /// 获取某一管理者所管理的所有管理角色信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-11</remarks>
        public DataTable GetLeaderRole(E_ClientInfoHelper data)
        {
            return dal.GetLeaderRole(data);
        }

        /// <summary>
        /// 根据关键字查询企业中所有名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-23</remarks>
        public DataTable GetClientInfoList(E_ClientInfo data)
        {
            return dal.GetClientInfoList(data);
        }

         /// <summary>
        /// 把报废或失败的名录上报给上级
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-28</remarks>
        public bool Report(E_ClientInfoHelper data)
        {
            return dal.Report(data);
        }

        /// <summary>
        /// 查看录入人员录入名录统计信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-06</remarks>
        //TODO:该方法未使用
        public DataTable GetInputStatistics(E_ClientInfoHelper data)
        {
            return dal.GetInputStatistics(data);
        }

         /// <summary>
        /// 业务锁定或解锁名录:1=锁定，0=解锁
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-1-4</remarks>
        public bool IsLock(E_ClientInfoHelper data)
        {
            return dal.IsLock(data);
        }

        /// <summary>
        /// 管理员查看已删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remraks>tianzhenyun 2012-02-14</remraks>
        public DataTable LeaderDeleteSelect(E_ClientInfo data)
        {
            return dal.LeaderDeleteSelect(data);
        }

        /// <summary>
        /// 管理员还原删除客户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-14</remarks>
        public bool LeaderRestore(E_ClientInfo data)
        {
            return dal.LeaderRestore(data);
        }

        /// <summary>
        /// 彻底删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-15</remarks>
        public bool LeaderThoroughDelete(E_ClientInfoHelper data)
        {
            return dal.LeaderThoroughDelete(data);
        }
    }
}
