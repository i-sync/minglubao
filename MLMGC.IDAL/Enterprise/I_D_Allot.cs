using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;
using System.Data;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 名录分配
    /// </summary>
    public interface I_D_Allot
    {
        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-27</remarks>
        bool Update(E_Allot data);
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-28</remarks>
        DataSet Select(E_Allot data);
        /// <summary>
        /// 查看已选择的名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-02</remarks>
        DataTable ListResultSelect(E_Allot data);
        #region 名录分配
        /// <summary>
        /// 按属性自动分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-01</remarks>
        DataTable AutoPropertyAllot(E_Allot data);
        /// <summary>
        /// 自动平均分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-01</remarks>
        DataTable AutoAvgAllot(E_Allot data);
        /// <summary>
        /// 自动补差分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-01</remarks>
        DataTable AutoMarkupAllot(E_Allot data);        
        /// <summary>
        /// 手工平均分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-02</remarks>
        bool ManualAvgAllot(E_Allot data);
        /// <summary>
        /// 手工补差分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool ManualMarkupAllot(E_Allot data);
        /// <summary>
        /// 手工按属性分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool ManualPropertyAllot(E_Allot data);
        /// <summary>
        /// 手工指定分配
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-02</remarks>
        bool ManualSpecifiedAllot(E_Allot data);
        /// <summary>
        /// 名录转移
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-07</remarks>
        bool ShiftAllot(E_Allot data);

        /// <summary>
        /// 名录分配统计
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-26</remarks>
        DataTable AllotStatistics(E_Allot data);
        #endregion

        #region 自动分配 配置信息

        /// <summary>
        /// 修改自动分配配置信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-14</remarks>
        bool UpdateAutoConfig(E_Allot data);
        /// <summary>
        /// 获取自行分配配置信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-14</remarks>
        E_Allot GetModelConfig(E_Allot data);
        #endregion
    }
}
