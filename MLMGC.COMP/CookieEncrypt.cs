using System;
using System.Collections.Generic;
using System.Web;

namespace MLMGC.COMP
{
    /// <summary>
    /// cookie 加密 解密
    /// </summary>
    public class CookieEncrypt
    {
        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="cookie"></param>
        public static void SetCookie(HttpCookie cookie)
        {
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
        /// <summary>
        /// 设置加密后的Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueString"></param>
        public static void SetCookie(String key, String valueString)
        {
            key = HttpContext.Current.Server.UrlEncode(key);
            valueString = HttpContext.Current.Server.UrlEncode(valueString);
            HttpCookie cookie = new HttpCookie(key, valueString);
            SetCookie(cookie);
        }
        /// <summary>
        /// 设置加密后的Cookie，并设置Cookie的有效时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueString"></param>
        /// <param name="expires"></param>
        public static void SetCookie(String key, String valueString, DateTime expires)
        {
            key = HttpContext.Current.Server.UrlEncode(key);
            valueString = HttpContext.Current.Server.UrlEncode(valueString);
            HttpCookie cookie = new HttpCookie(key, valueString);
            cookie.Expires = expires;
            SetCookie(cookie);
        }
        /// <summary>
        /// 设置使用TripleDES加密后的Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueString"></param>
        public static void SetTripleDESEncryptedCookie(String key, String valueString)
        {
            key = EncryptString.EncryptTripleDES(key);
            valueString = EncryptString.EncryptTripleDES(valueString);
            SetCookie(key, valueString);
        }
        /// <summary>
        /// 设置使用TripleDES加密后的Cookie，并设置Cookie的有效时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueString"></param>
        /// <param name="expires"></param>
        public static void SetTripleDESEncryptedCookie(String key, String valueString, DateTime expires)
        {
            key = EncryptString.EncryptTripleDES(key);
            valueString = EncryptString.EncryptTripleDES(valueString);
            SetCookie(key, valueString, expires);
        }
        /// <summary>
        /// 设置使用DES加密后的Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueString"></param>
        public static void SetEncryptedCookie(String key, String valueString)
        {
            key = EncryptString.Encrypt(key);
            valueString = EncryptString.Encrypt(valueString);
            SetCookie(key, valueString);
        }
        /// <summary>
        /// 设置使用DES加密后的Cookie，并设置Cookie的有效时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueString"></param>
        /// <param name="expires"></param>
        public static void SetEncryptedCookie(String key, String valueString, DateTime expires)
        {
            key = EncryptString.Encrypt(key);
            valueString = EncryptString.Encrypt(valueString);
            SetCookie(key, valueString, expires);
        }
        /// <summary>
        /// 获取使用TripleDES解密后的Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String GetTripleDESEncryptedCookieValue(String key)
        {
            key = EncryptString.EncryptTripleDES(key);
            String valueString = GetCookieValue(key);
            valueString = EncryptString.DecryptTripleDES(valueString);
            return (valueString);
        }
        /// <summary>
        /// 获取使用DES解密后的Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String GetEncryptedCookieValue(String key)
        {
            key = EncryptString.Encrypt(key);
            String valueString = GetCookieValue(key);
            valueString = EncryptString.Decrypt(valueString);
            return (valueString);
        }
        /// <summary>
        /// 通过关键字获取Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static HttpCookie GetCookie(String key)
        {
            key = HttpContext.Current.Server.UrlEncode(key);
            return (HttpContext.Current.Request.Cookies.Get(key));
        }
        /// <summary>
        /// 通过关键字获取Cookie的value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String GetCookieValue(String key)
        {
            String valueString = GetCookie(key).Value;
            valueString = HttpContext.Current.Server.UrlDecode(valueString);
            return (valueString);
        }
    }
}
