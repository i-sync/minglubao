using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 企业数据库
    /// </summary>
    public interface I_D_EnterpriseDB
    {
        /// <summary>
        /// 后台管理员添加数据库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        bool Add(E_EnterpriseDB data);

        /// <summary>
        /// 后台管理员删除数据库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        bool Delete(E_EnterpriseDB data);

        /// <summary>
        /// 后台管理员查看最后一条记录
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        E_EnterpriseDB SelectLast();

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        E_EnterpriseDB GetModel(E_EnterpriseDB data);

        /// <summary>
        /// 后台管理员查看数据库列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        DataTable SelectList(E_EnterpriseDB data);

        /// <summary>
        /// 修改默认数据库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        bool UpdateDefaultFlag(E_EnterpriseDB data);

        /// <summary>
        /// 修改数据库容量（最大容量）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-07</remarks>
        bool UpdateMaxNum(E_EnterpriseDB data);

        /// <summary>
        /// 获取默认库的基本信息
        /// </summary>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-06-01</reamrks>
        DataTable GetDefault();
    }
}
