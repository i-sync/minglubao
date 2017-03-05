using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.User;

namespace MLMGC.BLL.User
{
    /// <summary>
    /// 个人信息
    /// </summary>
    public class T_Personal
    {
        MLMGC.IDAL.User.I_D_Personal dal = MLMGC.DALFactory.User.F_D_Personal.Create();

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddAuthCode(E_Personal data)
        {
            return dal.AddAuthCode(data);
        }
        /// <summary>
        /// 添加个人信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddPersonal(E_Personal data)
        {
            return dal.AddPersonal(data);
        }

        /// <summary>
        /// 验证邮箱是否可用
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AuthEmail(E_PersonalUser data)
        {
            return dal.AuthEmail(data);
        }

        /// <summary>
        /// 个人用户修改密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns> 
        /// <remarks>tianzhenyun 2011-10-21</remarks>
        public bool UpdatePassword(E_User data)
        {
            return dal.UpdatePassword(data);
        }

        /// <summary>
        /// 得到个人实体对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Personal GetModel(E_Personal data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 判断个人信息是否完善
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool IsPerfect(E_Personal data)
        {
            //判断资料是否完善
            if (string.IsNullOrWhiteSpace(data.RealName) || string.IsNullOrWhiteSpace(data.Email) || string.IsNullOrWhiteSpace(data.Mobile))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 个人修改基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(E_Personal data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 个人用户修改头像
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public bool UpdateAvatar(E_Personal data)
        {
            return dal.UpdateAvatar(data);
        }

        /// <summary>
        /// 个人用户找回密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int GetPassword(E_User data)
        {
            return dal.GetPassword(data);
        }

        /// <summary>
        /// 管理员查看个人用户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Personal data)
        {
            return dal.GetList(data);
        }

        /// <summary>
        /// 修改个人用户状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool PersonalStatus(E_Personal data)
        {
            return dal.PersonalStatus(data);
        }
        /// <summary>
        /// 管理员查看个人详细信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Personal SelectModel(E_Personal data)
        {
            return dal.SelectModel(data);
        }

        /// <summary>
        /// 管理员删除个人用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Delete(E_Personal data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 个人用户信息(ID,RealName)列表 用于绑定下拉列表
        /// </summary>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-03-08</reamrks>
        public DataTable DataList()
        {
            return dal.DataList();
        }

        /// <summary>
        /// 获取个人用户所在项目的企业号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public DataTable GetEnterpriseID(E_Personal data)
        {
            return dal.GetEnterpriseID(data);
        }
    }
}
