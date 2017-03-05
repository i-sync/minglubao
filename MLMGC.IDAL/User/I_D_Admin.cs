using System;
using System.Collections.Generic;
using MLMGC.DataEntity.User;
using System.Data;

namespace MLMGC.IDAL.User
{
    /// <summary>
    /// 管理员管理
    /// </summary>
    public interface I_D_Admin
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="data">username,password</param>
        /// <returns></returns>
        E_Admin UserLogin(E_Admin data);

        /// <summary>
        /// 管理员用户修改密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        bool UpdatePassword(E_Admin data);

        /// <summary>
        /// 判断管理员是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-27</remarks>
        bool Exists(E_Admin data);

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        bool Add(E_Admin data);

        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        bool Update(E_Admin data);

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        bool Delete(E_Admin data);

        /// <summary>
        /// 获取管理员对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        E_Admin GetModel(E_Admin data);

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        DataTable GetList();
    }
}
