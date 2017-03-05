using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MLMGC.COMP
{
    /// <summary>
    /// 加密解密类 By LGM
    /// 2009-11-23
    /// </summary>
    public static class CryptUtil
    {
        /// <summary>
        /// DES + Base64 加密
        /// </summary>
        /// <param name="input">明文字符串</param>
        /// <returns>已加密字符串</returns>
        public static string DesBase64EncryptForID5(string input)
        {
            System.Security.Cryptography.DES des = System.Security.Cryptography.DES.Create();
            des.Mode = System.Security.Cryptography.CipherMode.CBC;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            byte[] Key = new byte[8] { 56, 50, 55, 56, 56, 55, 49, 49 };
            byte[] IV = new byte[8] { 56, 50, 55, 56, 56, 55, 49, 49 };

            ct = des.CreateEncryptor(Key, IV);

            byt = Encoding.GetEncoding("GB2312").GetBytes(input); //根据 GB2312 编码对字符串处理，转换成 byte 数组

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            byte[] answer = ms.ToArray();
            for (int j = 0; j < answer.Length; j++)
            {
                Console.Write(answer[j].ToString() + " ");
            }
            Console.WriteLine();
            return Convert.ToBase64String(ms.ToArray()); // 将加密的 byte 数组依照 Base64 编码转换成字符串
        }

        
        /// <summary>
        /// DES + Base64 解密
        /// </summary>
        /// <param name="input">密文字符串</param>
        /// <returns>解密字符串</returns>
        public static string DesBase64DecryptForID5(string input)
        {
            System.Security.Cryptography.DES des = System.Security.Cryptography.DES.Create();
            des.Mode = System.Security.Cryptography.CipherMode.CBC;
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            byte[] Key = new byte[8] { 56, 50, 55, 56, 56, 55, 49, 49 };
            byte[] IV = new byte[8] { 56, 50, 55, 56, 56, 55, 49, 49 };

            ct = des.CreateDecryptor(Key, IV);
            byt = Convert.FromBase64String(input); // 将 密文 以 Base64 编码转换成 byte 数组

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Encoding.GetEncoding("GB2312").GetString(ms.ToArray()); // 将 明文 以 GB2312 编码转换成字符串
        }

    }
}
