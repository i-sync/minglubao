using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
namespace MLMGC.COMP
{
    public static class PageHelper
    {
        #region 绑定下拉框
        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="DataTxt">数据源字段</param>
        /// <param name="DataValue">数据值</param>
        public static void BindDropDownList(DropDownList list, DataTable dt, string DataTxt, string DataValue)
        {
            if ( dt!=null && dt.Rows.Count > 0)
            {
                list.DataSource = dt;
                list.DataTextField = DataTxt;
                list.DataValueField = DataValue;
                list.DataBind();
            }
            list.Items.Add(new ListItem("未设", "0"));
            list.SelectedValue = "0";
        }
        #endregion

        #region 绑定下拉框
        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="DataTxt">数据源字段</param>
        /// <param name="DataValue">数据值</param>
        public static void BindDropDownList1(DropDownList list, DataTable dt, string DataTxt, string DataValue)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                list.DataSource = dt;
                list.DataTextField = DataTxt;
                list.DataValueField = DataValue;
                list.DataBind();
            }
        }
        #endregion

        #region 绑定下拉框
        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="DataTxt">数据源字段</param>
        /// <param name="DataValue">数据值</param>
        public static void BindDropDownList2(DropDownList list, DataTable dt, string DataTxt, string DataValue)
        {

            if (dt != null && dt.Rows.Count > 0)
            {
                list.DataSource = dt;
                list.DataTextField = DataTxt;
                list.DataValueField = DataValue;
                list.DataBind();
            }
            list.Items.Insert(0,"");
            list.SelectedIndex = 0;
        }
        #endregion

        /// <summary>
        /// 根据值id获取值内容
        /// </summary>
        /// <param name="id">id值</param>
        /// <param name="valueName">字段为id的名称</param>
        /// <param name="txtName">返回的内容的字段名称</param>
        /// <param name="dt">数据表</param>
        /// <returns></returns>
        public static string GetTxtByValue(int id, string valueName, string txtName, DataTable dt)
        {
            try
            {
                //DataTable dt = mExpressAcc.GetTypeList();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[valueName].ToString() == id.ToString())
                        {
                            return row[txtName].ToString();
                        }
                    }
                }
            }
            catch
            {
                return "";
            }
            return "";
        }

        /// <summary>
        /// 根据值id获取值内容
        /// </summary>
        /// <param name="id">id值</param>
        /// <param name="valueName">字段为id的名称</param>
        /// <param name="txtName">返回的内容的字段名称</param>
        /// <param name="dt">数据表</param>
        /// <returns></returns>
        public static string GetTxtByValue(string ids, string valueName, string txtName, DataTable dt)
        {
            //DataTable dt = mExpressAcc.GetTypeList();
            string strNames = "";
            string[] arr = ids.Split(',');
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (row[valueName].ToString() == arr[i].ToString())
                            {
                                //return row[txtName].ToString();
                                strNames += row[txtName].ToString() + "，";
                            }
                        }
                    }
                }
                if (strNames.EndsWith("，"))
                {
                    strNames = strNames.Substring(0, strNames.Length - 1);
                }
            }
            catch
            {
                strNames = "";
            }
            return strNames;
        }
        /// <summary>
        /// 绑定年份下拉列表
        /// </summary>
        public static void BindDropDownYear(DropDownList ddlYear)
        {
            //绑定年份
            int i = 0;
            for (i = 2009; i <= 2019; i++)
            {
                ddlYear.Items.Add(i.ToString());
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            }
        }
        /// <summary>
        /// 绑定月份下拉列表
        /// </summary>
        public static void BindDropDownMonth(DropDownList ddlMonth)
        {
            //绑定月份
            for (int i = 1; i <= 12; i++)
            {
                ddlMonth.Items.Add(i.ToString());
                ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            }
        }

        /// <summary>
        /// 绑定日下拉列表
        /// </summary>
        public static void BindDropDownDay(DropDownList ddlDay)
        {
            //绑定日
            for (int i = 1; i < 32; i++)
            {
                ddlDay.Items.Add(i.ToString());
                ddlDay.SelectedValue = DateTime.Now.Day.ToString();
            }
        }

        /// <summary>
        /// 绑定小时下拉列表
        /// </summary>
        public static void BindDropDownHour(DropDownList ddlHour)
        {
            //绑定小时
            for (int i = 1; i < 24; i++)
            {
                ddlHour.Items.Add(i.ToString());
                ddlHour.SelectedValue = DateTime.Now.Hour.ToString();
            }
        }

        /// <summary>
        /// 显示上传后的图片
        /// </summary>
        /// <param name="strJosn">Josn格式的字符串</param>
        public static string ShowPicture(string strJosn, string strFolder, Page page,out string strNewPath)
        {
            strNewPath = "";
            string[] arr = strJosn.Split(',');
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(page.Server.MapPath(arr[1]));
            if (fileInfo.Exists)
            {
                //string strNewFolderPath = Server.MapPath("/UserControls/uploadify/files/");
                //string strNewFilePath = page.Server.MapPath(strFolder) + arr[0].ToString();
                string strNewFilePath = strFolder + arr[0].ToString();
                System.IO.FileInfo fileInfoNew = new System.IO.FileInfo(page.Server.MapPath(strNewFilePath));
                if (!fileInfoNew.Exists)
                {
                    if (!fileInfoNew.Exists)
                    {
                        fileInfo.MoveTo(page.Server.MapPath(strNewFilePath));
                    }
                    else
                    {
                        fileInfoNew.Delete();
                        fileInfo.MoveTo(page.Server.MapPath(strNewFilePath));
                    }
                }
                strNewPath = strNewFilePath;
                //this.UvImg1.JsonFile = FY.COMP.StringUtil.FileToJson("", strNewFilePath.Replace("\\", "/"), "");
                return COMP.StringUtil.FileToJson(arr[0].ToString(), strNewFilePath.Replace("\\", "/"), arr[2].ToString());
            }
            return "";
        }
        /// <summary>
        /// 高亮显示关键字
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string HighlightKeyword(string str, string key)
        {
            if (string.IsNullOrWhiteSpace(str)) { return str; }
            if (string.IsNullOrEmpty(key)) { return str; }

            MatchCollection mc = Regex.Matches(str, key, RegexOptions.IgnoreCase);
            string [] array = Regex.Split(str, key, RegexOptions.IgnoreCase);
            string result = string.Empty;
            for(int i = 0;i<array.Length;i++)
            {
                if (i != array.Length - 1)
                    result += array[i] + string.Format("<font style='color:red;'>{0}</font>", mc[i].Groups[0].Value);
                else
                    result += array[i];
            }
            return result;
            //return Regex.Replace(str, key,string.Format("<font style='color:red;'>{0}</font>",key),RegexOptions.IgnoreCase);
        }

        
    }
}
