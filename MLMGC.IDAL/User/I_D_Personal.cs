using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.User;

namespace MLMGC.IDAL.User
{
    public interface I_D_Personal
    {
        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool AddAuthCode(E_Personal data);
        /// <summary>
        /// 添加个人信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int AddPersonal(E_Personal data);

        /// <summary>
        /// 验证邮箱是否可用
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool AuthEmail(E_PersonalUser data);

        /// <summary>
        /// 个人用户修改密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool UpdatePassword(E_User data);

        /// <summary>
        /// 查询个人信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Personal GetModel(E_Personal data);
        /// <summary>
        /// 个人用户修改个人信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(E_Personal data);

        /// <summary>
        /// 个人用户修改头像
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        bool UpdateAvatar(E_Personal data);

        /// <summary>
        /// 个人用户找回密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int GetPassword(E_User data);

        /// <summary>
        /// 管理查看个人用户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_Personal data);

        /// <summary>
        /// 修改个人状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool PersonalStatus(E_Personal data);

        /// <summary>
        /// 管理员查看个人详细基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Personal SelectModel(E_Personal data);

        /// <summary>
        /// 管理员删除个人用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Delete(E_Personal data);

        /// <summary>
        /// 个人用户信息(ID,RealName)列表 用于绑定下拉列表
        /// </summary>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-08</reamrks>
        DataTable DataList();

        /// <summary>
        /// 获取个人用户所在项目的企业号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        DataTable GetEnterpriseID(E_Personal data);
    }
}
