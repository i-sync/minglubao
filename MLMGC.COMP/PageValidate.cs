using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace MLMGC.COMP
{
    public class PageValidate
    {

        /// <summary>
        /// 获取传递过来的Url地址是否包含登录码
        /// </summary>
        /// <param name="urlValue">Url的值</param>
        /// <param name="loginCode">登录码</param>
        /// <returns>具体的值，如果是否，是非法操作</returns>
        public static string  GetLoginCodeUrl(string urlValue, string loginCode)
        {
            string[] arrUrlValue = urlValue.Split('|');
            if (arrUrlValue[1] == loginCode)
            {
                return arrUrlValue[0];
            }
            return "";
        }

        public static void SkipMistakePage()
        {
            Jscript.JavaScriptLocationHref("http://www.123.com");
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public static int ValidateEnUrlID()
        {
            SymmetricMethod encryptMethod = new SymmetricMethod();
            int enID = 0;
            if (HttpContext.Current.Request.QueryString["EnID"] != null)
            {
                string enStr = GetLoginCodeUrl(encryptMethod.Decrypto(HttpContext.Current.Request.QueryString["EnID"].Replace(" ", "+")), HttpContext.Current.Request.Cookies["LoginCode"].Value.Trim());
                if (enStr.Trim() != "")
                {
                    enID = int.Parse(enStr);
                }
                else
                {
                    SkipMistakePage();
                }
            }
            else
            {
                enID = int.Parse(HttpContext.Current.Request.Cookies["EnID"].Value);
            }
            return enID;
        }


        public static void LoadEnInfoCss()
        {
            if (HttpContext.Current.Request.QueryString["Preview"] != null)
            {

                HttpContext.Current.Response.Write("<link href=\"../Style/EnInfoPreview.css\" rel=\"stylesheet\" type=\"text/css\" />");

               
            }
            else
            {
                HttpContext.Current.Response.Write("<link href=\"../Style/EnInfoShow.css\" rel=\"stylesheet\" type=\"text/css\" />");
               
            }
        }
    }
}
