using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Item;
using MLMGC.IDAL.Item;

namespace MLMGC.BLL.Item
{
    /// <summary>
    /// 项目名录 
    /// </summary>
    public class T_ItemClientInfo
    {
        I_D_ItemClientInfo dal = MLMGC.DALFactory.Item.F_D_ItemClientInfo.Create();


        /// <summary>
        /// 判断名录名称手机电话是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public bool Exists(E_ItemClientInfo data)
        {
            return dal.Exists(data);
        }
        /// <summary>
        /// 添加新名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public bool Add(E_ItemClientInfo data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 修改名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public bool Update(E_ItemClientInfo data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 删除名录信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public bool Delete(E_ItemClientInfo data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 获取名录对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public E_ItemClientInfo GetModel(E_ItemClientInfo data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 修改名录状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public bool UpdateStatus(E_ItemClientInfo data)
        {
            return dal.UpdateStatus(data);  
        }

        /// <summary>
        /// 共享名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-18</remarks>
        public bool UpdateShare(E_ItemClientInfo data)
        {
            return dal.UpdateShare(data);
        }


        /// <summary>
        /// 获取名录列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-14</remarks>
        public DataTable GetList(E_ItemClientInfo data)
        {
            return dal.GetList(data);
        }

        /// <summary>
        /// 获取状态日志列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable GetStatusList(E_ItemClientInfo data)
        {
            return dal.GetStatusList(data);
        }

        #region 名录状态列表
        /// <summary>
        /// 查询潜在客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable LatenceSelect(E_ItemClientInfo data)
        {
            return dal.LatenceSelect(data);
        }

        /// <summary>
        /// 查询意向客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable WishSelect(E_ItemClientInfo data)
        {
            return dal.WishSelect(data);
        }

        /// <summary>
        /// 查询失败客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable NotTradeSelect(E_ItemClientInfo data)
        {
            return dal.NotTradeSelect(data);
        }

        /// <summary>
        /// 查询报废客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable ScrapSelect(E_ItemClientInfo data)
        {
            return dal.ScrapSelect(data);
        }

        /// <summary>
        /// 查询成交客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-15</remarks>
        public DataTable TradedSelect(E_ItemClientInfo data)
        {
            return dal.TradedSelect(data);
        }


        /// <summary>
        /// 共享名录查询
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-18</remarks>
        public DataTable ShareSelect(E_ItemClientInfo data)
        {
            return dal.ShareSelect(data);
        }

        #endregion

        #region 总监查询名录
        
        /// <summary>
        /// 领导模糊查询列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderList(E_ItemClientInfo data)
        {
            return dal.LeaderList(data);
        }

        /// <summary>
        /// 总监查询潜在客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderLatenceList(E_ItemClientInfo data)
        {
            return dal.LeaderLatenceList(data);
        }
        /// <summary>
        /// 总监查询意向客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderWishList(E_ItemClientInfo data)
        {
            return dal.LeaderWishList(data);
        }

        /// <summary>
        /// 领导查询成交客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderTradedList(E_ItemClientInfo data)
        {
            return dal.LeaderTradedList(data);
        }

        /// <summary>
        /// 总监查询失败客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderNotTradedList(E_ItemClientInfo data)
        {
            return dal.LeaderNotTradedList(data);
        }

        /// <summary>
        /// 总监查询报废客户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-16</remarks>
        public DataTable LeaderScrapList(E_ItemClientInfo data)
        {
            return dal.LeaderScrapList(data);
        }

        /// <summary>
        /// 总监查询已删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-17</remarks>
        public DataTable LeaderDeleteList(E_ItemClientInfo data)
        {
            return dal.LeaderDeleteList(data);
        }

        /// <summary>
        /// 总监彻底删除名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-17</remarks>
        public bool ThoroughDelete(E_ItemClientInfo data)
        {
            return dal.ThoroughDelete(data);
        }


        /// <summary>
        /// 总监清空回收站
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-21</remarks>
        public bool ThoroughDeleteAll(E_ItemClientInfo data)
        {
            return dal.ThoroughDeleteAll(data);
        }

        /// <summary>
        /// 总监删除共享池中所有的名录 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-21</remarks>
        public bool DeleteAll(E_ItemClientInfo data)
        {
            return dal.DeleteAll(data);
        }

        #endregion

        /// <summary>
        /// 从共享池中获取名录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-21</remarks>
        public bool ShiftShare(E_ItemClientInfo data)
        {
            return dal.ShiftShare(data);
        }



        #region 名录从个人导入到项目或从项目导入到个人
        /// <summary>
        /// 从个人-->项目 personal-->item
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-24</remarks>
        public DataTable ImportData_PI(E_ItemClientInfo data)
        {
            return dal.ImportData_PI(data);
        }

        /// <summary>
        /// 项目-->个人 item-->personal
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-24</remarks>
        public DataTable ImportData_IP(E_ItemClientInfo data)
        {
            return dal.ImportData_IP(data);
        }
        #endregion

        #region 总监把名录导入到企业或项目
        /// <summary>
        /// 从企业-->项目 enterprise-->item
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-25</remarks>
        public DataTable ImportData_EI(E_ItemClientInfo data)
        {
            return dal.ImportData_EI(data);
        }

        /// <summary>
        /// 项目-->企业 item-->enterprise
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-25</remarks>
        public DataTable ImportData_IE(E_ItemClientInfo data)
        {
            return dal.ImportData_IE(data);
        }
        #endregion
    }
}
