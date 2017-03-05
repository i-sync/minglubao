using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Enterprise.weibo
{
    public static class WEIBOHelper
    {
        /// <summary>
        /// 获取显示的时间
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ShowTime(object obj)
        {
            DateTime dt;
            if (DateTime.TryParse(obj.ToString(), out dt))
            {
                TimeSpan ts = DateTime.Now - dt;
                DateTime dtToday = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime dtDtday = new DateTime(dt.Year, dt.Month, dt.Day);
                if (ts.TotalDays < 1 && dtDtday==dtToday)
                {
                    if (ts.TotalHours < 1)
                    {
                        if (ts.TotalSeconds <1)
                        {
                            return "刚刚";
                        }
                        else if (ts.TotalMinutes < 1)
                        {
                            return string.Format("{0}秒钟前", ts.Seconds.ToString());
                        }
                        else
                        {
                            return string.Format("{0}分钟前", ts.Minutes.ToString());
                        }
                    }
                    else
                    {
                        return string.Format("{0}", dt.ToString("HH:mm"));
                    }
                }
                else if (dtDtday.AddDays(1)==dtToday)
                {
                    return string.Format("昨天 {0}", dt.ToString("HH:mm"));
                }
                else
                {
                    return dt.ToString("yyyy-MM-dd HH:mm");
                }
            }
            return obj.ToString();
        }
    }
}