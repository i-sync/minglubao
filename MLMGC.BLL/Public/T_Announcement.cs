using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Public;
using MLMGC.IDAL.Public;

namespace MLMGC.BLL.Public
{
    /// <summary>
    /// 公告（个人）
    /// </summary>
    public class T_Announcement
    {
        I_D_Announcement dal = MLMGC.DALFactory.Public.F_D_Announcement.Create();
        
        /// <summary>
        /// 修改公告（个人）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public bool Update(E_Announcement data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 删除公告（个人）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public bool Delete(E_Announcement data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 根据公告编号获取公告信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public E_Announcement GetModel(E_Announcement data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 获取最新的前几条数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public DataTable GetNewList(E_Announcement data)
        {
            return dal.GetNewList(data);
        }

        /// <summary>
        /// 获取分页数据列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-01-12</remarks>
        public DataTable GetList(E_Announcement data)
        {
            return dal.GetList(data);
        }
    }
}
