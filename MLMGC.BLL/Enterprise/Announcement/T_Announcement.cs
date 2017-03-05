using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Announcement;

namespace MLMGC.BLL.Enterprise.Announcement
{
    /// <summary>
    /// 企业公告
    /// </summary>
    public class T_Announcement
    {
        MLMGC.IDAL.Enterprise.Announcement.I_D_Announcement dal = MLMGC.DALFactory.Enterprise.Announcement.F_D_Announcement.Create();

        /// <summary>
        /// 增加企业公告
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(E_Announcement data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 得到企业公告对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Announcement GetModel(E_Announcement data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 得到企业公告列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Announcement data)
        {
            return dal.GetList(data);
        }
        /// <summary>
        /// 得到上级公告对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Announcement GetLeaderModel(E_Announcement data)
        {
            return dal.GetLeaderModel(data);
        }

        /// <summary>
        /// 得到上级公告列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetLeaderList(E_Announcement data)
        {
            return dal.GetLeaderList(data);
        }

        /// <summary>
        /// 获取自身及所有上级的最新公告
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-07</remarks>
        public DataTable GetNewList(E_Announcement data)
        {
            return dal.GetNewList(data);
        }
    }
}
