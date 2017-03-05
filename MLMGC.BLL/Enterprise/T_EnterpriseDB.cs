using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MLMGC.DataEntity.Enterprise;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.BLL.Enterprise
{
    /// <summary>
    /// 企业数据库
    /// </summary>
    public class T_EnterpriseDB
    {
        I_D_EnterpriseDB dal = MLMGC.DALFactory.Enterprise.F_D_EnterpriseDB.Create();

        /// <summary>
        /// 获取下一个数据库名称
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-04</remarks>
        public string NextName()
        {
            string DBName = string.Empty;
            E_EnterpriseDB data = SelectLast();
            if (data == null)
            {
                DBName = "EP_00001";
            }
            else
            {
                int num = Convert.ToInt32(data.DBName.Substring(3));
                DBName = string.Format("EP_{0:d5}", num + 1);
            }
            return DBName;
        }
        /// <summary>
        /// 后台管理员添加数据库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public bool Add(E_EnterpriseDB data)
        {
            return dal.Add(data);
        }

        /// <summary>
        /// 后台管理员删除数据库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public bool Delete(E_EnterpriseDB data)
        {
            return dal.Delete(data);
        }

        /// <summary>
        /// 后台管理员查看最后一条记录
        /// </summary>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public E_EnterpriseDB SelectLast()
        {
            return dal.SelectLast();
        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public E_EnterpriseDB GetModel(E_EnterpriseDB data)
        {
            return dal.GetModel(data);
        }

        /// <summary>
        /// 后台管理员查看数据库列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public DataTable SelectList(E_EnterpriseDB data)
        {
            return dal.SelectList(data);
        }

        /// <summary>
        /// 修改默认数据库
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-03</remarks>
        public bool UpdateDefaultFlag(E_EnterpriseDB data)
        {
            return dal.UpdateDefaultFlag(data);
        }
        
        /// <summary>
        /// 修改数据库容量（最大容量）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-05-07</remarks>
        public bool UpdateMaxNum(E_EnterpriseDB data)
        {
            return dal.UpdateMaxNum(data);
        }

        /// <summary>
        /// 获取默认库的基本信息
        /// </summary>
        /// <returns></returns>
        /// <reamrks>tianzhenyun 2012-06-01</reamrks>
        public DataTable GetDefault()
        {
            return dal.GetDefault();
        }
    }
}
