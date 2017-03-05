using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace MLMGC.COMP
{


    /// <summary>
    /// ADD BY PJ
    /// 2009-07-16
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// 执行DataTable中的查询返回新的DataTable
        /// </summary>
        /// <param name="dt">源数据DataTable</param>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static DataTable GetNewDataTable(DataTable dt, string condition)
        {
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            DataRow[] dr = dt.Select(condition);
            for (int i = 0; i < dr.Length; i++)
            {
                newdt.ImportRow((DataRow)dr[i]);
            }
            return newdt;//返回的查询结果
        }
        /// <summary>
        /// 判断DataSet是否为空，如果表中没有数据也返回false
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        /// <remarks>齐鹏飞 2011.04.12</remarks>
        public static bool DataSetIsNotNull(DataSet ds)
        {
            return ds==null?false:ds.Tables.Count == 0 ? false : ds.Tables[0].Rows.Count == 0 ? false : true;
        }
        /// <summary>
        /// 获取是否警告
        /// </summary>
        /// <param name="date"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string GetWarning(DateTime date, int day)
        {
            TimeSpan ts = DateTime.Now - date;
            return ts.Days > day ? " warning" : "";
        }
        /// <summary>
        /// 获取是否警告
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string GetWarning(object obj, int day,object warn)
        {
            if (warn.ToString() == "1")
            {
                return "warn";
            }
            DateTime dt;
            if(DateTime.TryParse(obj.ToString(),out dt)){
                return GetWarning(dt, day);
            }
            return "";
        }

        /// <summary>
        /// 是否显示锁定
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Lock(object obj)
        {
            return obj.ToString() == "1" ? "<span style='color:Red;'>[锁定]</span>" : "";
        }

    }
}
