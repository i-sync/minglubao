using System;
using System.IO;

namespace MLMGC.COMP
{
	public class Paths {
		/// <summary>
		/// 获得当前绝对路径
		/// </summary>
		/// <param name="strPath">指定的路径</param>
		/// <returns>绝对路径</returns>
		public static string GetMapPath(string strPath) {
			if (System.Web.HttpContext.Current != null)
				return System.Web.HttpContext.Current.Server.MapPath(strPath);
			else
				//非web程序引用
				return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
		}

        public static string DeleteFile(string strPath)
        {
            string path = GetMapPath(strPath);
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo != null)
            {
                fileInfo.Delete();
                return "成功";
            }
            return "失败";
        }
	}
}
