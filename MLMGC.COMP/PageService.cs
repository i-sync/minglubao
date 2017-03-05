using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MLMGC.COMP
{
    public class PageService
    {
        /// <summary>
        /// 根据名称集合获得所对应的值集合
        /// </summary>
        /// <param name="names">名称集合</param>
        /// <returns>值集合</returns>
        public static List<string> GetListStringByNames(List<string> names,HttpRequest request)
        {
            NameValueCollection nvc = request.Form;
            List<List<string>> nameValues = new List<List<string>>();
            foreach (string name in names)
            {
                if (nvc.GetValues(name) == null)
                {
                    return null;
                }
                nameValues.Add(nvc.GetValues(name).ToList<string>());
            }
            StringBuilder[] sbNameValues = new StringBuilder[nameValues.Count];
            int i = 0;
            foreach (List<string> nameValue in nameValues)
            {
                sbNameValues[i] = new StringBuilder();
                foreach (string value in nameValue)
                {
                    sbNameValues[i].Append(StringUtil.safety(value)).Append(",");
                }
                sbNameValues[i].Remove(sbNameValues[i].Length - 1, 1);
                i++;
            }
            return GetListString(sbNameValues);
        }

        /// <summary>
        /// 将StringBuilder数组转化为string泛型集合
        /// </summary>
        /// <param name="sbs"></param>
        /// <returns>string集合</returns>
        public static List<string> GetListString(StringBuilder[] sbs)
        {
            List<string> listString = new List<string>();
            foreach (StringBuilder sb in sbs)
            {
                listString.Add(sb.ToString());
            }
            return listString;
        }

        /// <summary>
        /// 清空指定控件中的文本域和隐藏域
        /// </summary>
        /// <param name="control"></param>
        public static void ClearField(Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                if (ctl.GetType().Name == "TextBox")
                {
                    (ctl as TextBox).Text = "";
                }
                else if (ctl.GetType().Name == "HiddenField")
                {
                    (ctl as HiddenField).Value = "";
                }
            }
        }

        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DateCast(object date)
        {
            string strDate = "";
            if (date != DBNull.Value && date != null)
            {
                strDate = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
                if (Convert.ToDateTime(date).CompareTo(new DateTime(1900, 1, 1)) == 0)
                {
                    strDate = "";
                }
                else if (Convert.ToDateTime(date).CompareTo(new DateTime(1800, 1, 1)) == 0)
                {
                    strDate = "";
                }                
            }
            return strDate;
        }

    }
}
