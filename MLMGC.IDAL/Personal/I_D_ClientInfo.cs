using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Personal;

namespace MLMGC.IDAL.Personal
{
    /// <summary>
    /// 个人名录信息
    /// </summary>
    public interface I_D_ClientInfo
    {
        /// <summary>
        /// 判断名录是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Exists(E_ClientInfo data);
        /// <summary>
        /// 判断电话和手机是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-14</remarks>
        DataTable ExistsContact(E_ClientInfo data);

        /// <summary>
        /// 录入新名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Add(E_ClientInfo data);
        /// <summary>
        /// 修改名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-26</remarks>
        bool Update(E_ClientInfo data);

        /// <summary>
        /// 删除名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        bool Delete(E_ClientInfo data);
        
        /// <summary>
        /// 批量删除名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        bool BatchDelete(E_ClientInfo data);
        /// <summary>
        /// 获取名录详细信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        E_ClientInfo GetModel(E_ClientInfo data);
        /// <summary>
        /// 修改名录状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-26</remarks>
        bool UpdateStatus(E_ClientInfo data);
        /// <summary>
        /// 获取名录状态操作列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-26</remarks>
        DataTable GetStatusList(E_ClientInfo data);
    
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        DataTable Select(E_ClientInfo data);
        /// <summary>
        /// 查询潜在客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        DataTable LatenceSelect(E_ClientInfo data);

        /// <summary>
        /// 查询意向客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        DataTable WishSelect(E_ClientInfo data);
        
        /// <summary>
        /// 查询失败客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        DataTable NotTradeSelect(E_ClientInfo data);
        
        /// <summary>
        /// 查询报废客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        DataTable ScrapSelect(E_ClientInfo data);
        
        /// <summary>
        /// 查询报废客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-25</remarks>
        DataTable TradedSelect(E_ClientInfo data);
        #region 数据导入 导出  qipengfei
        /// <summary>
        /// 名录数据导出
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        DataSet DataExport(E_ClientInfo data);

        #endregion

        #region 统计信息
        /// <summary>
        /// 名录统计信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-25</remarks>
        DataTable Statistics(E_ClientInfo data);
        #endregion
    }
}
