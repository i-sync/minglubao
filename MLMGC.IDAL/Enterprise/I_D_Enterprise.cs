using System;
using System.Collections.Generic;
using MLMGC.DataEntity.Enterprise;
using System.Data;

namespace MLMGC.IDAL.Enterprise
{
    /// <summary>
    /// 企业信息
    /// </summary>
    public interface I_D_Enterprise
    {
        /// <summary>
        /// 检索企业号是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Exist(E_Enterprise data);
        /// <summary>
        /// 添加新企业
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(E_Enterprise data);

        /// <summary>
        /// 管理员修改企业基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-02</remarks>
        bool Update(E_Enterprise data);

        /// <summary>
        /// 后台管理员修改企业基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-09</remarks>
        bool AdminUpdate(E_Enterprise data);

        /// <summary>
        /// 删除企业
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 20111-12-02</remarks>
        bool Delete(E_Enterprise data);
        /// <summary>
        /// 获取一个企业的基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Enterprise Get(E_Enterprise data);
        /// <summary>
        /// 管理查看企业用户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-03</remarks>
        DataTable GetList(E_Enterprise data);
        /// <summary>
        /// 修改企业状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-03</remarks>
        bool StatusUpdate(E_Enterprise data);

        /// <summary>
        /// 管理员查看企业详细信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-03</remarks>
        E_Enterprise GetModel(E_Enterprise data);
    }
}
