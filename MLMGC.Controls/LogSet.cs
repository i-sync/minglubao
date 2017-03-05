using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MLMGC.Controls
{
    class LogSet
    {
        /// <summary>
        /// 日志文件大小
        /// </summary>
        private int fileSize;


        /// <summary>
        /// 日志文件的路径
        /// </summary>
        private string fileLogPath;


        /// <summary>
        /// 日志文件的名称
        /// </summary>
        private string logFileName;


        /// <summary>
        /// 构造函数,初始化日志文件大小[2M]
        /// 可以使用相关属性对其进行更改.
        /// </summary>
        public LogSet()
        {
            //初始化大于2M日志文件将自动删除;
            this.fileSize = 2048 * 1024;//2M
            //默认路径
            this.fileLogPath = AppDomain.CurrentDomain.BaseDirectory + "/Log/";
            this.logFileName = "MailLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        }

        /// <summary>
        /// 获取或设置定义日志文件大小
        /// </summary>
        public int FileSize
        {
            set
            {
                fileSize = value;
            }
            get
            {
                return fileSize;
            }
        }


        /// <summary>
        /// 获取或设置日志文件的路径
        /// </summary>
        public string FileLogPath
        {
            set
            {
                this.fileLogPath = value;
            }
            get
            {
                return this.fileLogPath;
            }
        }


        /// <summary>
        /// 获取或设置日志文件的名称
        /// </summary>
        public string LogFileName
        {
            get
            {
                this.logFileName = "MailLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                return this.logFileName;
            }

        }

        /// <summary>
        /// 向指定目录中的文件中追加日志文件,日志文件的名称将由传递的参数决定.
        /// </summary>
        /// <param name="Message">要写入的内容</param>
        public void WriteLog(string Message)
        {
            //DirectoryInfo path=new DirectoryInfo(LogFileName);
            //如果日志文件目录不存在,则创建
            if (!Directory.Exists(this.fileLogPath))
            {
                Directory.CreateDirectory(this.fileLogPath);
            }
            try
            {
                FileStream fs = new FileStream(this.fileLogPath + LogFileName, FileMode.Append);
                StreamWriter strwriter = new StreamWriter(fs);
                try
                {
                    DateTime d = DateTime.Now;
                    strwriter.WriteLine("时间:" + d.ToString());
                    strwriter.WriteLine("\t" + Message);
                    strwriter.WriteLine();
                    strwriter.Flush();
                }
                catch (Exception ee)
                {
                    Console.WriteLine("Mail_:" + ee.ToString());
                }
                finally
                {
                    strwriter.Close();
                    strwriter = null;
                    fs.Close();
                    fs = null;
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine("日志文件没有打开,详细信息如下:" + ee.ToString());
            }
        }


    }
}
