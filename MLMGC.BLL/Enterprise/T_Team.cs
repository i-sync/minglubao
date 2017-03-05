using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DataEntity.User;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 团队设置
    /// </summary>
    public class T_Team
    {
        MLMGC.IDAL.Enterprise.I_D_Team dal = MLMGC.DALFactory.Enterprise.F_D_Team.Create();
        /// <summary>
        /// 获取企业团队列表
        /// </summary>
        /// <param name="data">EnterpriseID</param>
        /// <returns></returns>
        public DataSet GetList(E_Team data)
        {
            return dal.GetList(data);
        }
        /// <summary>
        /// 获取企业某角色所在同级的团队列表
        /// </summary>
        /// <param name="data">EnterpriseID,TeamModelRoleID</param>
        /// <returns></returns>
        public DataTable GetListForRole(E_Team data)
        {
            return dal.GetListForRole(data);
        }
        /// <summary>
        /// 获取某一团队上级列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet GetTeamParent(E_Team data)
        {
            //未登录或登录超时，直接返回
            if (data.EnterpriseID == 0)
            {
                return null;
            }
            return dal.GetTeamParent(data);
        }
        /// <summary>
        /// 修改团队信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateTeam(E_Team data)
        {
            return dal.UpdateTeam(data);
        }
        /// <summary>
        /// 获取TeamID
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-17</remarks>
        public DataTable GetTeamID(E_User data)
        {
            return dal.GetTeamID(data);
        }
        /// <summary>
        /// 修改团队基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-18</remarks>
        public bool Update(E_Team data)
        {
            return dal.Update(data);
        }
        /// <summary>
        /// 获取单个团队对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-10-18</remarks>
        public E_Team GetModel(E_Team data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 获取团队成员所有下级成员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-19</remarks>
        public DataTable GetTeamMember(E_Team data)
        {
            return dal.GetTeamMember(data);
        }
        /// <summary>
        /// 获取某一领导下面的所有管理团队
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-21</remarks>
        public DataTable GetManageTeam(E_Team data)
        {
            return dal.GetManageTeam(data);
        }
        /// <summary>
        /// 获取某一领导下面的直接成员（下属团队/业务员）  无用
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-10-27</remarks>
        public DataTable GetDirectMember(E_Team data)
        {
            return dal.GetDirectMember(data);
        }
    }
}
