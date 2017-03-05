using System;
using System.Collections.Generic;
using System.Data;
using MLMGC.DALFactory.Enterprise;
using MLMGC.IDAL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    public class T_TeamModel
    {
        I_D_TeamModel dal = F_D_TeamModel.Create();
        /// <summary>
        /// 获取团队模型列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            return dal.GetList();
        }

         /// <summary>
        /// 获取团队模型结构
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-12</remarks>
        //TODO:该方法未使用
        public DataTable GetTeamModel(E_TeamModel data)
        {
            return dal.GetTeamModel(data);
        }
        /// <summary>
        /// 设置企业团队模型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int SetTeamModel(E_TeamModel data)
        {
            return dal.SetTeamModel(data);
        }
        /// <summary>
        /// 获取企业团队模型配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_TeamModel GetTeamScale(E_TeamModel data)
        {
            return dal.GetTeamScale(data);
        }

        /// <summary>
        /// 更新企业团队模型配置 各团队数量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int UpdateTeamScale(E_TeamModel data)
        {
            return dal.UpdateTeamScale(data);
        }
        /// <summary>
        /// 获取企业团队模型下的角色列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet GetEnterpriseRole(E_TeamModel data)
        {
            return dal.GetEnterpriseRole(data);
        }

        /// <summary>
        /// 获取企业图
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-28</remarks>
        public DataSet GetEnterpriseMap(E_TeamModel data)
        {
            return dal.GetEnterpriseMap(data);
        }

        /// <summary>
        /// 修改期限  共享 潜在客户、意向客户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-31</remarks>
        public bool UpdateDeadLine(E_TeamModel data)
        {
            return dal.UpdateDeadLine(data);
        }
    }
}
