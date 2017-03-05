using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Item;

namespace MLMGC.IDAL.Item
{
    /// <summary>
    /// 项目名录
    /// </summary>
    public interface I_D_ItemClientInfo
    {        
        /// <summary>
        /// 判断名录是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        bool Exists(E_ItemClientInfo data);
        
        /// <summary>
        /// 录入新名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        bool Add(E_ItemClientInfo data);
        /// <summary>
        /// 修改名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        bool Update(E_ItemClientInfo data);

        /// <summary>
        /// 删除名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        bool Delete(E_ItemClientInfo data);

        /// <summary>
        /// 获取名录对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        E_ItemClientInfo GetModel(E_ItemClientInfo data);

        /// <summary>
        /// 获取名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        DataTable GetList(E_ItemClientInfo data);

        /// <summary>
        /// 修改名录状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        bool UpdateStatus(E_ItemClientInfo data);
        
        /// <summary>
        /// 共享名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-18</remarks>
        bool UpdateShare(E_ItemClientInfo data);

        /// <summary>
        /// 获取状态日志列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        DataTable GetStatusList(E_ItemClientInfo data);

        #region 名录状态列表
        /// <summary>
        /// 查询潜在客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        DataTable LatenceSelect(E_ItemClientInfo data);

        /// <summary>
        /// 查询意向客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        DataTable WishSelect(E_ItemClientInfo data);

        /// <summary>
        /// 查询失败客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        DataTable NotTradeSelect(E_ItemClientInfo data);

        /// <summary>
        /// 查询报废客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        DataTable ScrapSelect(E_ItemClientInfo data);

        /// <summary>
        /// 查询成交客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        DataTable TradedSelect(E_ItemClientInfo data);

        /// <summary>
        /// 共享名录查询
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-18</remarks>
        DataTable ShareSelect(E_ItemClientInfo data);

        #endregion

        #region 总监查询名录

        /// <summary>
        /// 总监模糊查询列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        DataTable LeaderList(E_ItemClientInfo data);
        
        /// <summary>
        /// 总监查询潜在客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        DataTable LeaderLatenceList(E_ItemClientInfo data);
        /// <summary>
        /// 总监查询意向客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        DataTable LeaderWishList(E_ItemClientInfo data);
        /// <summary>
        /// 总监查询成交客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        DataTable LeaderTradedList(E_ItemClientInfo data);
        /// <summary>
        /// 总监查询失败客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        DataTable LeaderNotTradedList(E_ItemClientInfo data);

        /// <summary>
        /// 总监查询报废客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        DataTable LeaderScrapList(E_ItemClientInfo data);

        /// <summary>
        /// 总监查询已删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-17</remarks>
        DataTable LeaderDeleteList(E_ItemClientInfo data);

        /// <summary>
        /// 总监彻底删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-17</remarks>
        bool ThoroughDelete(E_ItemClientInfo data);


        /// <summary>
        /// 总监清空回收站
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-21</remarks>
        bool ThoroughDeleteAll(E_ItemClientInfo data);

        /// <summary>
        /// 总监删除共享池中所有的名录 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-21</remarks>
        bool DeleteAll(E_ItemClientInfo data);
        #endregion

        /// <summary>
        /// 从共享池中获取名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-21</remarks>
        bool ShiftShare(E_ItemClientInfo data);


        #region 名录从个人导入到项目或从项目导入到个人
        /// <summary>
        /// 从个人-->项目 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-24</remarks>
        DataTable ImportData_PI(E_ItemClientInfo data);

        /// <summary>
        /// 项目-->个人
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-24</remarks>
        DataTable ImportData_IP(E_ItemClientInfo data);
	    #endregion

        #region 总监把名录导入到企业或项目
        /// <summary>
        /// 从企业-->项目 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-25</remarks>
        DataTable ImportData_EI(E_ItemClientInfo data);

        /// <summary>
        /// 项目-->企业
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-25</remarks>
        DataTable ImportData_IE(E_ItemClientInfo data);
        #endregion
    }
}
