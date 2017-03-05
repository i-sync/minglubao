using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DataEntity.User ;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 团队管理
    /// </summary>
    public interface I_D_Team
    {
        /// <summary>
        /// 获取企业团队列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataSet GetList(E_Team data);
        /// <summary>
        /// 获取企业某角色所在同级的团队列表
        /// </summary>
        /// <param name="data">EnterpriseID,TeamModelRoleID</param>
        /// <returns></returns>
        DataTable GetListForRole(E_Team data);
        /// <summary>
        /// 获取某一团队上级列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataSet GetTeamParent(E_Team data);
        /// <summary>
        /// 修改团队信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool UpdateTeam(E_Team data);
        /// <summary>
        /// 根据EPUserTMRID,获取TeamID
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetTeamID(E_User data);
        /// <summary>
        /// 修改团队基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(E_Team data);
        /// <summary>
        /// 获取团队对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Team GetModel(E_Team data);
        /// <summary>
        /// 获取团队成员所有下级
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-19</remarks>
        DataTable GetTeamMember(E_Team data);
        /// <summary>
        /// 获取某一领导下面的所有管理团队
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-21</remarks>
        DataTable GetManageTeam(E_Team data);
        /// <summary>
        /// 获取某一领导下面的直接成员（下属团队/业务员）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-27</remarks>
        DataTable GetDirectMember(E_Team data);
    }
}
