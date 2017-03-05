using System;
using System.Collections.Generic;
using MLMGC.IDAL.User;
using MLMGC.DALFactory.User;
using MLMGC.DataEntity.User;
using System.Data;

namespace MLMGC.BLL.User
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class T_User
    {
        I_D_User dal = F_D_User.Create();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_User UserLogin(E_User data)
        {
            return dal.UserLogin(data);
        }
        /// <summary>
        /// 获取企业用户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet GetEPList(E_User data)
        {
            return dal.GetEPList(data);
        }

        /// <summary>
        /// 获取企业用户购买数量和已使用数量
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-30</remarks>
        public DataTable GetEPUserCount(E_User data)
        {
            return dal.GetEPUserCount(data);
        }

        /// <summary>
        /// 判断企业用户是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-01</remarks>
        public bool EPUserExist(E_User data)
        {
            return dal.EPUserExist(data);
        }
        /// <summary>
        /// 添加企业新用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddEnterpriseUser(E_User data)
        {
            return dal.AddEnterpriseUser(data);
        }

        /// <summary>
        ///  删除企业用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns>0=删除失败，1=删除成功，-1=用户数据未清空</returns>
        /// <remarks>tianzhenyun 2011-12-19</remarks>
        public int EPUserDelete(E_User data)
        {
            return dal.EPUserDelete(data);
        }
        /// <summary>
        /// 获取企业用户基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-25</remarks>
        public E_User GetEPModel(E_User data)
        {
            return dal.GetEPModel(data);
        }
        /// <summary>
        /// 更改用户状态（启用、禁用）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UserStatus(E_User data)
        {
            return dal.UserStatus(data);
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //TODO:该方法未使用
        public bool ResetPassword(E_User data)
        {
            return dal.ResetPassword(data);
        }
        
        /// <summary>
        /// 设置团队用户角色信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //TODO:该方法未使用
        public int SetTeamUserRole(E_User data)
        {
            return dal.SetTeamUserRole(data);
        }
        /// <summary>
        /// 获取团队用户角色信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetTeamUserRole(E_User data)
        {
            return dal.GetTeamUserRole(data);
        }

        /// <summary>
        /// 获取用户选择角色信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetUserSelectRole(E_EnterpriseUser data)
        {
            return dal.GetUserSelectRole(data);
        }
        /// <summary>
        /// 获取用户操作菜单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetMenuList(E_EnterpriseUser data)
        {
            return dal.GetMenuList(data);
        }

        /// <summary>
        /// 企业用户修改密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns> 
        /// <remarks>tianzhenyun 2011-10-19</remarks>
        public bool UpdatePassword(E_User data)
        {
            return dal.UpdatePassword(data);
        }

        /// <summary>
        /// 企业用户修改头像
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-09</remarks>
        public bool UpdateAvatar(E_User data)
        {
            return dal.UpdateAvatar(data);
        }
        /// <summary>
        /// 获取当前企业用户的角色编号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>qipengfei 2011-11-03</remarks>
        public int GetEPRoleID(E_EnterpriseUser data)
        {
            return dal.GetEPRoleID(data);
        }

        /// <summary>
        /// 个人用户登录日志
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-09</remarks>
        public bool AddLoginInfo(E_User data)
        {
            return dal.AddLoginInfo(data);
        }

        /// <summary>
        /// 管理员查看个人登录信息列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-09</remarks>
        public DataTable GetLoginList(E_User data)
        {
            return dal.GetLoginList(data);
        }

         /// <summary>
        /// 查看个人登录详细信息记录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-10</remarks>
        public DataTable GetLoginInfoList(E_User data)
        {
            return dal.GetLoginInfoList(data);
        }


        #region 品搜用户的自动注册及登录
        /// <summary>
        /// 验证品搜用户是否正确
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-23</remarks>
        public DataTable Pinsou_Verification(E_PinsouUser data)
        {
            return dal.Pinsou_Verification(data);
        }

        /// <summary>
        /// 品搜用户自动注册名录宝用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-23</remarks>
        public int Pinsou_AutoRegister(E_PinsouUser data)
        {
            return dal.Pinsou_AutoRegister(data);
        }

        /// <summary>
        /// 品搜用户自动登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-02-23</remarks>
        public DataTable Pinsou_AutoLogin(E_PinsouUser data)
        {
            return dal.Pinsou_AutoLogin(data);
        }

        #endregion
    }
}
