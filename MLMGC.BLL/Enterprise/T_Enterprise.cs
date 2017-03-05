using System;
using System.Collections.Generic;
using MLMGC.DALFactory.Enterprise;
using MLMGC.IDAL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using System.Data;

namespace MLMGC.BLL.Enterprise
{
    public class T_Enterprise
    {
        I_D_Enterprise dal = F_D_Enterprise.Create();
        /// <summary>
        /// 判断企业号是否存在
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Exist(E_Enterprise data)
        {
            return dal.Exist(data);
        }
        /// <summary>
        /// 添加新企业
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(E_Enterprise data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 管理员修改企业基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-12-02</remarks>
        public bool Update(E_Enterprise data)
        {
            return dal.Update(data);
        }

        /// <summary>
        /// 后台管理员修改企业基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-02-09</remarks>
        public bool AdminUpdate(E_Enterprise data)
        {
            return dal.AdminUpdate(data);
        }

        /// <summary>
        /// 删除企业
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 20111-12-02</remarks>
        public bool Delete(E_Enterprise data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 获取一个企业的基本信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public E_Enterprise Get(E_Enterprise data)
        {
            return dal.Get(data);
        }

        /// <summary>
        /// 管理员查看企业用户列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetList(E_Enterprise data)
        {
            return dal.GetList(data);
        }

        /// <summary>
        /// 管理员修改企业状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-02</remarks>
        public bool StatusUpdate(E_Enterprise data)
        {
            return dal.StatusUpdate(data);
        }
        /// <summary>
        /// 管理员查看企业详细信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2011-11-03</remarks>
        public E_Enterprise GetModel(E_Enterprise data)
        {
            return dal.GetModel(data);
        }
    }
}
