using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise.Announcement;

namespace MLMGC.IDAL.Enterprise.Announcement
{
    /// <summary>
    /// 企业公告
    /// </summary>
    public interface I_D_Announcement
    {
        /// <summary>
        /// 增加公告
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Add(E_Announcement data);
        
        /// <summary>
        /// 得到一个公告对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Announcement GetModel(E_Announcement data);
        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetList(E_Announcement data);
        /// <summary>
        /// 得到上级公告对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        E_Announcement GetLeaderModel(E_Announcement data);
        /// <summary>
        /// 获取上级公告列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        DataTable GetLeaderList(E_Announcement data);

        /// <summary>
        /// 获取自身及所有上级的最新公告
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-07</remarks>
        DataTable GetNewList(E_Announcement data);
    }
}
