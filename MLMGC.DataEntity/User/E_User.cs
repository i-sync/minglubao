/*----------------------------------------------------------------
    // Copyright (C) 2004 北京红手网络技术有限公司 
    // 版权所有。 
    //
    // 文件名：User.cs
    // 文件功能描述：用户实体信息
    // 创建标识：齐鹏飞20110916
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.User
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Serializable]
    public class E_User
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 登录帐号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 个人用户编号
        /// </summary>
        public int PersonalID { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }
        /// <summary>
        /// 企业码
        /// </summary>
        public string EnterpriseCode { get; set; }
        /// <summary>
        /// 企业编号
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 用户角色编号
        /// </summary>
        public int EPUserTMRID { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string TrueName { get; set; }
        /// <summary>
        /// 用户状态（启用、禁用）
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleID { get; set; }


        /// <summary>
        /// 企业用户头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 筛选类型，0=三个月未登录，1= 活跃
        /// </summary>
        public int Type { get; set; }

        #region 个人登录记录
        /// <summary>
        /// 登录编号
        /// </summary>
        public int LoginInfoID { get; set; }        
        /// <summary>
        /// 用户登录IP
        /// </summary>
        public string LoginIP { get; set; }
        /// <summary>
        /// 用户登录时使用的浏览器
        /// </summary>
        public string Browser { get; set; }
        /// <summary>
        /// 分辨率
        /// </summary>
        public string Resolution { get; set; }
        #endregion

        /// <summary>
        /// 角色配置
        /// 格式：9:20,10:21  角色编号:团队编号,角色编号:团队编号
        /// </summary>
        public string RoleSetting { get; set; }

        private E_Page _page = new E_Page();
        /// <summary>
        /// 分页显示
        /// </summary>
        public E_Page Page { set { _page = value; } get { return _page; } }
    }
    /// <summary>
    /// 【枚举】用户类型
    /// </summary>
    public enum UserType
    {
        企业用户 = 1,
        个人用户 = 2
    }
    /// <summary>
    /// 【枚举】用户状态
    /// </summary>
    public enum UserStatus
    {
        启用 = 1,
        禁用 = 2
    }
    /// <summary>
    /// 【枚举】用户角色
    /// </summary>
    public enum EnumRole
    {
        系统管理员 = 1,
        总监 = 2,
        经理 = 3,
        组长 = 4,
        销售人员 = 5,
        录入人员 = 6
    }
}
