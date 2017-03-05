using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Web;

namespace MLMGC.COMP
{
    /// <summary>
    /// 加密 解密
    /// </summary>
    public class EncryptString
    {
        private static byte[] Key64 = { 42, 16, 93, 156, 78, 4, 218, 32 };
        private static byte[] IV64 = { 55, 103, 246, 79, 36, 99, 167, 3 };
        private static byte[] Key192 = {42, 16, 93, 156, 78, 4, 218, 32,15, 167,
    44,80, 26, 250, 155, 112,2, 94, 11, 204, 119, 35, 184, 197};
        private static byte[] IV192 = {55, 103, 246, 79, 36, 99, 167, 3,42,
    5, 62,83, 184, 7, 209, 13,145, 23, 200, 58, 173, 10, 121, 222};
        public static String Encrypt(String valueString)
        {
            if (valueString != "")
            {   //定义DES的Provider
                DESCryptoServiceProvider desprovider =
                new DESCryptoServiceProvider();
                //定义内存流
                MemoryStream memoryStream = new MemoryStream();
                //定义加密流
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                desprovider.CreateEncryptor(Key64, IV64),
                CryptoStreamMode.Write);
                //定义写IO流
                StreamWriter writerStream = new StreamWriter(cryptoStream);
                //写入加密后的字符流
                writerStream.Write(valueString);
                writerStream.Flush();
                cryptoStream.FlushFinalBlock();
                memoryStream.Flush();
                //返回加密后的字符串
                return (Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length));
            }
            return (null);
        }
        public static String Decrypt(String valueString)
        {
            if (valueString != "")
            {   //定义DES的Provider
                DESCryptoServiceProvider desprovider =
                new DESCryptoServiceProvider();
                //转换解密的字符串为二进制
                byte[] buffer = Convert.FromBase64String(valueString);
                //定义内存流
                MemoryStream memoryStream = new MemoryStream();
                //定义加密流
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                desprovider.CreateEncryptor(Key64, IV64),
                CryptoStreamMode.Read);
                //定义读IO流
                StreamReader readerStream = new StreamReader(cryptoStream);
                //返回解密后的字符串
                return (readerStream.ReadToEnd());
            }
            return (null);
        }
        public static String EncryptTripleDES(String valueString)
        {
            if (valueString != "")
            {   //定义TripleDES的Provider
                TripleDESCryptoServiceProvider triprovider =
                new TripleDESCryptoServiceProvider();
                //定义内存流
                MemoryStream memoryStream = new MemoryStream();
                //定义加密流
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                triprovider.CreateEncryptor(Key192, IV192),
                CryptoStreamMode.Write);
                //定义写IO流
                StreamWriter writerStream = new StreamWriter(cryptoStream);
                //写入加密后的字符流
                writerStream.Write(valueString);
                writerStream.Flush();
                cryptoStream.FlushFinalBlock();
                memoryStream.Flush();
                //返回加密后的字符串
                return (Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length));
            }
            return (null);
        }
        public static String DecryptTripleDES(String valueString)
        {
            if (valueString != "")
            {   //定义TripleDES的Provider
                TripleDESCryptoServiceProvider triprovider =
                new TripleDESCryptoServiceProvider();
                //转换解密的字符串为二进制
                byte[] buffer = Convert.FromBase64String(valueString);
                //定义内存流
                MemoryStream memoryStream = new MemoryStream();
                //定义加密流

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                triprovider.CreateEncryptor(Key64, IV64),
                CryptoStreamMode.Read);
                //定义读IO流
                StreamReader readerStream = new StreamReader(cryptoStream);
                //返回解密后的字符串
                return (readerStream.ReadToEnd());
            }
            return (null);
        }
        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncryptPassword(string password)
        {
            password = password + "pwd";
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
        }
    }

}
