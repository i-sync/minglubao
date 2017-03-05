using System;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;
using System.Text;
using System.Web.Security;
using System.Collections.Generic;
using System.Configuration;

using System.Data;

namespace MLMGC.COMP
{
    /// <summary>
    /// 对一些字符串进行操作的类
    /// 创建时间：2006-8-3
    /// 创建者：马先光
    /// </summary>
    public class StringUtil
    {
        private static string passWord;	//加密字符串

        /// <summary>
        /// 判断输入是否数字
        /// </summary>
        /// <param name="num">要判断的字符串</param>
        /// <returns></returns>
        static public bool VldInt(string num)
        {
            #region
            try
            {
                int i;
                return Int32.TryParse(num, out i);
            }
            catch { return false; }
            #endregion
        }

        /// <summary>
        /// 返回文本编辑器替换后的字符串
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        static public string GetHtmlEditReplace(string str)
        {
            #region
            return str.Replace("'", "''").Replace("&nbsp;", " ").Replace(",", "，").Replace("%", "％").Replace("script", "").Replace(".js", "");
            #endregion
        }

        /// <summary>
        /// 截取字符串函数
        /// </summary>
        /// <param name="str">所要截取的字符串</param>
        /// <param name="num">截取字符串的长度</param>
        /// <returns></returns>
        static public string GetSubString(string str, int num = 20)
        {
            string strReturn = string.Empty;
            int index = 0;
            int i = 0;
            while (index < num * 2 && i < str.Length)
            {
                strReturn += str[i];
                if (str[i] < 128)//半角字符
                {
                    index++;
                }
                else
                {
                    index += 2;
                }
                i++;
            }
            return (str.Length > strReturn.Length) ? strReturn + "..." : strReturn;
        }
        static public string GetSubString(object obj, int num = 20)
        {
            #region
            if (obj == null) { return ""; }
            return (obj.ToString().Length > num) ? obj.ToString().Substring(0, num) + "..." : obj.ToString();
            #endregion
        }

        /// <summary>
        /// 过滤输入信息
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>
        public static string InputText(string text, int maxLength)
        {
            #region
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
            text = text.Replace("'", "''");
            return text;
            #endregion
        }

        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <returns></returns>
        private string GenerateCheckCode()
        {
            #region
            int number;
            char code;
            string checkCode = String.Empty;

            System.Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('2' + (char)(number % 10));
                else
                    code = (char)('P' + (char)(number % 26));

                checkCode += code.ToString().ToUpper();
            }

            HttpContext.Current.Response.Cookies.Add(new HttpCookie("CheckCode", checkCode));

            return checkCode;
            #endregion
        }
        /// <summary>
        /// 生成随机数数组
        /// </summary>
        /// <param name="randomcount"></param>
        /// <returns></returns>
        static public int[] Arrrandom(int randomcount)
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] arrNum = new int[randomcount];
            int tmp = 0;
            int minValue = 10000;
            int maxValue = randomcount;
            for (int i = 10000; i < randomcount; i++)
            {
                tmp = ra.Next(minValue, maxValue); //随机取数
                arrNum[i] = getNum(arrNum, tmp, minValue, maxValue, ra); //取出值赋到数组中
            }
            return arrNum;
        }
        /// <summary>
        /// 生成单个随机数
        /// </summary>
        /// <param name="randomcount"></param>
        /// <returns></returns>
        static public int getNum(int[] arrNum, int tmp, int minValue, int maxValue, Random ra)
        {
            int n = 0;
            while (n <= arrNum.Length - 1)
            {
                if (arrNum[n] == tmp) //利用循环判断是否有重复
                {
                    tmp = ra.Next(minValue, maxValue); //重新随机获取。
                    getNum(arrNum, tmp, minValue, maxValue, ra);//递归:如果取出来的数字和已取得的数字有重复就重新随机获取。
                }
                n++;
            }
            return tmp;
        }
        /// <summary>
        /// 生成验证码图片
        /// </summary>
        public void CreateCheckCodeImage()
        {
            #region
            string checkCode = GenerateCheckCode();
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)), 22);
            Graphics g = Graphics.FromImage(image);

            try
            {
                //生成随机生成器
                Random random = new Random();

                //清空图片背景色
                g.Clear(Color.White);

                ////画图片的背景噪音线
                //for (int i = 0; i < 25; i++)
                //{
                //    int x1 = random.Next(image.Width);
                //    int x2 = random.Next(image.Width);
                //    int y1 = random.Next(image.Height);
                //    int y2 = random.Next(image.Height);

                //    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                //}

                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Regular | System.Drawing.FontStyle.Regular));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(checkCode, font, brush, 2, 2);

                //画图片的前景噪音点
                //for (int i = 0; i < 100; i++)
                //{
                //    int x = random.Next(image.Width);
                //    int y = random.Next(image.Height);

                //    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                //}

                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentType = "image/Gif";
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
            #endregion
        }


        /// <summary>
        /// 获取汉字第一个拼音
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string getSpells(string input)
        {
            #region
            int len = input.Length;
            string reVal = "";
            for (int i = 0; i < len; i++)
            {
                reVal += getSpell(input.Substring(i, 1));
            }
            return reVal;
            #endregion
        }

        static public string getSpell(string cn)
        {
            #region
            byte[] arrCN = Encoding.Default.GetBytes(cn);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "?";
            }
            else return cn;
            #endregion
        }


        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="BJstr"></param>
        /// <returns></returns>
        static public string GetQuanJiao(string BJstr)
        {
            #region
            char[] c = BJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 0)
                    {
                        b[0] = (byte)(b[0] - 32);
                        b[1] = 255;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }

            string strNew = new string(c);
            return strNew;

            #endregion
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="QJstr"></param>
        /// <returns></returns>
        static public string GetBanJiao(string QJstr)
        {
            #region
            char[] c = QJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            string strNew = new string(c);
            return strNew;
            #endregion
        }

        #region 加密的类型
        /// <summary>
        /// 加密的类型
        /// </summary>
        public enum PasswordType
        {
            SHA1,
            MD5
        }
        #endregion


        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="PasswordString">要加密的字符串</param>
        /// <param name="PasswordFormat">要加密的类别</param>
        /// <returns></returns>
        static public string EncryptPassword(string PasswordString, string PasswordFormat)
        {
            #region
            switch (PasswordFormat)
            {
                case "SHA1":
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "SHA1");
                        break;
                    }
                case "MD5":
                    {
                        passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "MD5");
                        break;
                    }
                default:
                    {
                        passWord = string.Empty;
                        break;
                    }
            }
            return passWord;
            #endregion
        }

        /// <summary>
        /// 显示TextArea的内容
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        static public string ShowTextArea(object txt)
        {
            if (txt == null)
            {
                return "";
            }
            return Regex.Replace(txt.ToString(),"\r\n","<br/>");
        }

        //-----------------------------------ADD BY PJ---------------------------------------------

        /// <summary>
        /// 移除字符串最后一个字符,通常用于去除最后的分隔符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveLastOne(string str)
        {
            if (str == "" || str == null)
            {
                return "";
            }
            return str.Substring(0, str.Length - 1);
        }

        /// <summary>
        /// 字符串转换string[]数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="split"></param>
        /// <returns></returns>
        public static string[] StringToArray(string str, string split)
        {
            string[] arrStr = str.Split(new char[] { char.Parse(split) });
            return arrStr;
        }
        /// <summary>
        /// 字符串转换string[]数组,默认逗号分隔
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] StringToArray(string str)
        {
            string[] arrStr = str.Split(new char[] { ',' });
            return arrStr;
        }

        /// <summary>
        /// 字符串转换string[]数组,默认逗号分隔
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] StringToArray(string str, char chr)
        {
            string[] arrStr = str.Split(new char[] { chr });
            return arrStr;
        }

        /// <summary>
        /// 传入文件信息重新组合JSON字符串
        /// </summary>
        /// <param name="sNvar_ANameS">文件名</param>
        /// <param name="sNVar_AAddrS">路径</param>
        /// <param name="sFloat_ASizeS">大小</param>
        /// <returns></returns>
        public static string FileToJson(string sNvar_ANameS, string sNVar_AAddrS, string sFloat_ASizeS)
        {
            //将传进来的参数拆分
            string[] arrNvar_ANameS = sNvar_ANameS.Split(new char[] { ',' });
            string[] arrNVar_AAddrS = sNVar_AAddrS.Split(new char[] { ',' });
            string[] arrFloat_ASizeS = sFloat_ASizeS.Split(new char[] { ',' });

            //重新组合
            string strJson = "";
            for (int i = 0; i < arrNvar_ANameS.Length; ++i)
            {
                strJson += "{\"fileName\":\"" + arrNvar_ANameS[i] + "\",\"filePath\":\"" + arrNVar_AAddrS[i] + "\",\"fileSize\":\"" + arrFloat_ASizeS[i] + "\"}" + ";";
            }
            return strJson.Substring(0, strJson.Length - 1);
        }

        /// <summary>
        /// 传入文件信息重新组合DataTable
        /// </summary>
        /// <param name="sNvar_ANameS">文件名</param>
        /// <param name="sNVar_AAddrS">路径</param>
        /// <param name="sFloat_ASizeS">大小</param>
        /// <returns></returns>
        public static DataTable FileToDataTable(string sNvar_ANameS, string sNVar_AAddrS, string sFloat_ASizeS)
        {
            //将传进来的参数拆分
            string[] arrNvar_ANameS = sNvar_ANameS.Split(new char[] { ',' });
            string[] arrNVar_AAddrS = sNVar_AAddrS.Split(new char[] { ',' });
            string[] arrFloat_ASizeS = sFloat_ASizeS.Split(new char[] { ',' });

            //重新组合
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(String));
            dt.Columns.Add("Nvar_AName", typeof(String));
            dt.Columns.Add("Var_AAddr", typeof(String));
            dt.Columns.Add("Float_ASize", typeof(String));
            for (int i = 0; i < arrNvar_ANameS.Length; ++i)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = i.ToString();
                dr["Nvar_AName"] = arrNvar_ANameS[i].ToString();
                dr["Var_AAddr"] = arrNVar_AAddrS[i].ToString();
                dr["Float_ASize"] = arrFloat_ASizeS[i].ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 去除HTML标记
        /// 王洪岐110616
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string StripHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = Regex.Replace(Htmlstring, @"\s+", " ");//多个空格替换成一个
            Htmlstring = Htmlstring.Trim();
            return Htmlstring;
        }

        /// <summary>
        /// 过滤危险字符
        /// </summary>
        /// <param name="sql">需要过滤的sql语句</param>
        /// <returns>过滤后的sql语句</returns>
        public static string safety(string sql)
        {
            if (string.IsNullOrEmpty(sql)) return string.Empty;
            sql = sql.Trim(new char[]{' '});
            sql = sql.Replace("<", "＜");
            sql = sql.Replace(">", "＞");
            sql = sql.Replace("'", "＇");
            sql = sql.Replace("--", "－－");
            sql = sql.Replace(";", "；");
            //sql = sql.Replace("%", "");
            //sql = sql.Replace(" ", "");
            //sql = sql.Replace("*", "");
            return sql;
        }

        /// <summary>
        /// 过滤查询中关键词中的特殊符号
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string safeSql(string sql)
        {
            if (string.IsNullOrEmpty(sql)) return string.Empty;
            sql = sql.Trim();
            sql = sql.Replace("<", " ");
            sql = sql.Replace(">", " ");
            sql = sql.Replace("%", " ");
            sql = sql.Replace("*", " ");
            sql = sql.Replace("'", " ");
            //sql = sql.Replace("--", " ");
            sql = sql.Replace(";", " ");
            //string str = "[]|［］（）〔〕【】〈〉「」『』﹙﹚﹛﹜﹝﹞、。，；:\"\"?";
            //for (int i = 0; i < str.Length; i++)
            //{
            //    sql = sql.Replace(str[i].ToString(), " ");
            //}
            //sql = sql.Replace(" ", "");
            return sql.Trim();
        }

        #region 枚举值
        /// <summary>
        /// 日期枚举值
        /// </summary>
        public enum DatePart
        {
            /// <summary>
            /// 年
            /// </summary>
            YY,
            /// <summary>
            /// 月
            /// </summary>
            MM,
            /// <summary>
            /// 日
            /// </summary>
            DD,
            /// <summary>
            /// 时
            /// </summary>
            HH,
            /// <summary>
            /// 分
            /// </summary>
            MI,
            /// <summary>
            /// 秒
            /// </summary>
            SS,
            /// <summary>
            /// 毫秒
            /// </summary>
            MS
        }

        #endregion
        #region DateDiff()，返回两个日期的时间差
        /// <summary>
        /// 返回两个日期的时间差
        /// </summary>
        /// <param name="datepart">DatePart枚举值</param>
        /// <param name="starttime">起始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns></returns>
        public static long DateDiff(DatePart datepart, DateTime starttime, DateTime endtime)
        {
            long rtn = 0;
            TimeSpan start = new TimeSpan(starttime.Ticks);
            TimeSpan end = new TimeSpan(endtime.Ticks);
            TimeSpan delta = end.Subtract(start);
            long year = endtime.Year - starttime.Year;
            long month = year * 12 + (endtime.Month - starttime.Month);
            long day = (long)delta.TotalDays;
            long hour = (long)delta.TotalHours;
            long minute = (long)delta.TotalMinutes;
            long second = (long)delta.TotalSeconds;
            long milliseconds = (long)delta.TotalMilliseconds;
            switch (datepart)
            {
                case DatePart.YY:
                    rtn = year;
                    break;
                case DatePart.MM:
                    rtn = month;
                    break;
                case DatePart.DD:
                    rtn = day;
                    break;
                case DatePart.HH:
                    rtn = hour;
                    break;
                case DatePart.MI:
                    rtn = minute;
                    break;
                case DatePart.SS:
                    rtn = second;
                    break;
                case DatePart.MS:
                    rtn = milliseconds;
                    break;
            }
            return rtn;
        }

        #endregion


        //----------------------------------END--------------------------------------------------

        //---------------------------------王思维-----------------------------------------------//
        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="Length">字符串长度</param>
        /// <param name="Seed">随机函数种子值</param>
        /// <returns>指定长度的随机字符串</returns>
        public static string RndString(int Length, int[] Seed=null)
        {
            string strSep = ",";
            char[] chrSep = strSep.ToCharArray();

            //这里定义字符集
            string strChar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z"
             + ",A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,W,X,Y,Z";

            string[] aryChar = strChar.Split(chrSep, strChar.Length);

            string strRandom = string.Empty;
            Random Rnd;
            if (Seed != null && Seed.Length > 0)
            {
                Rnd = new Random(Seed[0]);
            }
            else
            {
                Rnd = new Random();
            }

            //生成随机字符串
            for (int i = 0; i < Length; i++)
            {
                strRandom += aryChar[Rnd.Next(aryChar.Length)];
            }

            return strRandom;
        }

        /// <summary>
        /// 生成上传文件的路径前缀
        /// </summary>
        /// <param name="strModelName">子系统名称WebConfig中配置名</param>
        /// <returns></returns>
        public static string GetAttachPath(string strModelName)
        {
            return ConfigurationManager.AppSettings["ServerPath"].ToString() + "/" + ConfigurationManager.AppSettings["VirtualName"].ToString() + "/" + ConfigurationManager.AppSettings[strModelName].ToString();
        }

        /// <summary>
        /// 生成上传文件的路径前缀
        /// </summary>
        /// <param name="strModelName">子系统名称WebConfig中配置名</param>
        /// <returns></returns>
        public static string GetVirtualPath(string strModelName)
        {
            return ConfigurationManager.AppSettings["Folder"].ToString() + "/" + ConfigurationManager.AppSettings[strModelName].ToString();
        }

        /// <summary>
        /// 截取固定长度的字符串，并以"..."补充
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="n">需截取的长度</param>
        /// <returns>截取后的字符串</returns>
        public static string CutStr(string str, int n,bool IsAddFlag=true)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(str);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                if (tempLen > n)
                    break;

                try
                {
                    tempString += str.Substring(i, 1);
                }
                catch
                {
                    break;
                }
            }
            if (IsAddFlag)
            {
                //如果截过则加上半个省略号
                byte[] mybyte = System.Text.Encoding.Default.GetBytes(str);
                if (mybyte.Length > n)
                    tempString += "...";
            }

            return tempString;
        }

        ///// <summary>
        ///// 判断是否经过加密狗授权
        ///// </summary>
        ///// <returns></returns>
        //public static bool IsAuthorization()
        //{
        //    bool flag = false;
        //    string hid = ConfigurationManager.AppSettings["HandleId"].ToString();
        //    //string hid = "2831795492";
        //    //uint uid = uint.Parse( ConfigurationManager.AppSettings["UId"].ToString());
        //    uint uid = 756961004;
        //    string dogHid = BJLawyeeDog.BJLawyeeDog.GetHandle(uid).ToString();
        //    if (dogHid == hid)
        //    {
        //        flag = true;
        //    }
        //    else
        //    {
        //        flag = false;
        //    }
        //    return flag;
        //}
        /// <summary>
        /// 判断是否为字符串数组（格式：1,2,3,10,3）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsStringArrayList(string str)
        {
            if (str == null) { return false; }
             Regex reg = new Regex("^\\d+(,\\d+)*$");
             return reg.IsMatch(str);
        }
         /// <summary>
        /// 判断是否为字符串数组（格式：1,2,3,10,3）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsStringArrayList(object obj)
        {
            return IsStringArrayList(obj.ToString());
        }

    }
}
