using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 企业项目
    /// </summary>
    public interface I_D_Item
    {
        /// <summary>
        /// 添加修改企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-25</remarks>
        bool Update(E_Item data);

        /// <summary>
        /// 获取企业项目对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-25</remarks>
        E_Item GetModel(E_Item data);

        /// <summary>
        /// 管理员获取企业项目列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-25</remarks>
        DataTable GetList(E_Item data);

        /// <summary>
        /// 管理员修改企业项目的申核状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-25</remarks>
        bool UpdateStatus(E_Item data);

        /// <summary>
        /// 后台管理员删除企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-26</remarks>
        bool Delete(E_Item data);
        
        /// <summary>
        /// 个人用户查看已申核通过的企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-04-26</remarks>
        DataTable PersonGetList(E_Item data);

        /// <summary>
        /// 后台管理员开通企业项目
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-11</remarks>
        bool UpdateOpenFlag(E_Item data);
    }
}
