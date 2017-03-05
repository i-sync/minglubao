using System;
using System.Collections.Generic;
using MLMGC.DataEntity.User;
using MLMGC.IDAL.User;
using MLMGC.DALFactory.User;
using System.Data;

namespace MLMGC.BLL.User
{
    public class T_Admin
    {
        I_D_Admin dal = F_D_Admin.Create();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="data">username,password,usertype</param>
        /// <returns></returns>
        public E_Admin UserLogin(E_Admin data)
        {
            dal = F_D_Admin.Create();
            return dal.UserLogin(data);
        }

        /// <summary>
        /// 管理员用户修改密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public bool UpdatePassword(E_Admin data)
        {
            return dal.UpdatePassword(data);
        }


        /// <summary>
        /// 判断管理员是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns>存在:true    不存在:false</returns>
        /// <remarks>tianzhenyun 2012-03-27</remarks>
        public bool Exists(E_Admin data)
        {
            return dal.Exists(data);
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public bool Add(E_Admin data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public bool Update(E_Admin data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public bool Delete(E_Admin data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 获取管理员对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public E_Admin GetModel(E_Admin data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-26</remarks>
        public DataTable GetList()
        {
            return dal.GetList();
        }
    }
}
