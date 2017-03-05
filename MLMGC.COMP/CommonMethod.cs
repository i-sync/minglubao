using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;

namespace MLMGC.COMP
{
    /// <summary>
    /// 页面级通用方法
    /// </summary>
    /// <remarks>齐鹏飞 2011.05</remarks>
    public class CommonMethod
    {
        /// <summary>
        /// 自定义增加选择项内容
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="Value">默认值"-1"</param>
        /// <param name="Text">默认值"请选择"</param>
        public static void InsertSelected(DropDownList ddl, string Value="-1", string Text = "请选择")
        {
            ListItem liDefault = new ListItem("——" + Text + "——", Value);
            ddl.Items.Insert(0, liDefault);
        }

        /// <summary>
        /// 判断指定的文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns>存在:true,不存在:false</returns>
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// 根据文件大小返回MB或KB字符串大小
        /// </summary>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public static string FileSize(int fileSize)
        {
            return fileSize > 1048575 ? string.Format("{0:f1}MB", fileSize / 1048576.0) : string.Format("{0:f1}KB", fileSize / 1024.0);
        }
    }
}
