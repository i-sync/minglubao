using System;
using System.Data;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 名录辅助操作
    /// </summary>
    public interface I_D_ClientInfoHelper
    {
        /// <summary>
        /// 判断电话和手机是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-09</remarks>
        DataTable ExistsContact(E_ClientInfoHelper data);
        /// <summary>
        /// 预约
        /// </summary>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-07</remarks>
        bool Reservation(E_Reservation data);
        /// <summary>
        /// 查询预约列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        DataTable GetReservationList(E_ClientInfoHelper data);
        /// <summary>
        /// 获取窗口提醒名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-23</remarks>
        DataTable GetReservationNow(E_Reservation data);

        /// <summary>
        /// 删除预约名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-07</remarks>
        bool DeleteReservation(E_Reservation data);

        /// <summary>
        /// 获取指定名录上一个、下一个
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-08</remarks>
        DataTable PrevNext(E_ClientInfoHelper data);

        /// <summary>
        /// 获取邮箱/手机 列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-08</remarks>
        DataTable SelectOperate(E_ClientInfoHelper data);

        /// <summary>
        /// 获取按属性对比
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Flag">source/area/trade</param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-10</remarks>
        DataTable ComparisonProperty(E_ClientInfoHelper data, string Flag);
        /// <summary>
        /// 按Team对比
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-11</remarks>
        DataTable ComparisonTeam(E_ClientInfoHelper data);
        /// <summary>
        /// 按销售人员对比
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-10</remarks>
        DataTable ComparisonSalesman(E_ClientInfoHelper data);
        /// <summary>
        /// 按时间对比
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-11</remarks>
        DataTable ComparisonDate(E_ClientInfoHelper data);
        /// <summary>
        /// 获取某一管理者所管理的所有管理角色信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-11</remarks>
        DataTable GetLeaderRole(E_ClientInfoHelper data);

        /// <summary>
        /// 根据关键字查询企业中所有名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-23</remarks>
        DataTable GetClientInfoList(E_ClientInfo data);

        /// <summary>
        /// 把报废或失败的名录上报给上级
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-28</remarks>
        bool Report(E_ClientInfoHelper data);

        /// <summary>
        /// 查看录入人员录入名录统计信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-06</remarks>
        DataTable GetInputStatistics(E_ClientInfoHelper data);

        /// <summary>
        /// 业务锁定或解锁名录:1=锁定，0=解锁
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-1-4</remarks>
        bool IsLock(E_ClientInfoHelper data);

        /// <summary>
        /// 管理员查看已删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remraks>tianzhenyun 2012-02-14</remraks>
        DataTable LeaderDeleteSelect(E_ClientInfo data);

        /// <summary>
        /// 管理员还原删除的客户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-14</remarks>
        bool LeaderRestore(E_ClientInfo data);

        /// <summary>
        /// 彻底删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-15</remarks>
        bool LeaderThoroughDelete(E_ClientInfoHelper data);
    }
}
