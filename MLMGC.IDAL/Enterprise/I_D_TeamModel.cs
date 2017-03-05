using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 团队模型
    /// </summary>
    public interface I_D_TeamModel
    {
        /// <summary>
        /// 获取团队模型列表
        /// </summary>
        /// <returns></returns>
        DataSet GetList();

        /// <summary>
        /// 获取团队模型结构
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-12</remarks>
        DataTable GetTeamModel(E_TeamModel data);
        /// <summary>
        /// 设置企业团队模型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int SetTeamModel(E_TeamModel data);
        /// <summary>
        /// 获取企业团队模型配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_TeamModel GetTeamScale(E_TeamModel data);
        /// <summary>
        /// 更新企业团队模型配置 各团队数量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int UpdateTeamScale(E_TeamModel data);
        /// <summary>
        /// 获取企业团队模型下的角色列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataSet GetEnterpriseRole(E_TeamModel data);
        /// <summary>
        /// 获取企业图
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-28</remarks>
        DataSet GetEnterpriseMap(E_TeamModel data);

        /// <summary>
        /// 修改期限 共享 潜在客户、意向客户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-31</remarks>
        bool UpdateDeadLine(E_TeamModel data);
    }
}
