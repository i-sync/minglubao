using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Public;

namespace MLMGC.IDAL.Public
{
    /// <summary>
    /// 公告（个人）
    /// </summary>
    public interface I_D_Announcement
    {
        /// <summary>
        /// 修改公告（个人）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        bool Update(E_Announcement data);

        /// <summary>
        /// 删除公告（个人）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        bool Delete(E_Announcement data);

        /// <summary>
        /// 根据公告编号获取公告信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        E_Announcement GetModel(E_Announcement data);

        /// <summary>
        /// 获取最新的前几条数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        DataTable GetNewList(E_Announcement data);

        /// <summary>
        /// 获取分页数据列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        DataTable GetList(E_Announcement data);
    }
}
