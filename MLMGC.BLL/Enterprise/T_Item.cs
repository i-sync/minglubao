using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DALFactory.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 企业项目
    /// </summary>
    public class T_Item
    {
        MLMGC.IDAL.Enterprise.I_D_Item dal = F_D_Item.Create();

        /// <summary>
        /// 添加修改企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-25</remarks>
        public bool Update(E_Item data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 获取企业项目对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-25</remarks>
        public E_Item GetModel(E_Item data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 管理员获取企业项目列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-25</remarks>
        public DataTable GetList(E_Item data)
        {
            return dal.GetList(data);
        }

        /// <summary>
        /// 管理员修改企业项目的申核状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-25</remarks>
        public bool UpdateStatus(E_Item data)
        {
            return dal.UpdateStatus(data);
        }

        /// <summary>
        /// 后台管理员删除企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-26</remarks>
        public bool Delete(E_Item data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 个人用户查看已申核通过的企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianhzenyun 2012-04-26</remarks>
        public DataTable PersonGetList(E_Item data)
        {
            return dal.PersonGetList(data);
        }

        /// <summary>
        /// 后台管理员开通企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-11</remarks>
        public bool UpdateOpenFlag(E_Item data)
        {
            return dal.UpdateOpenFlag(data);
        }
    }
}
