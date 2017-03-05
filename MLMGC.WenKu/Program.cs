using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using MLMGC.DBUtility;
using System.Diagnostics;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;

namespace MLMGC.WenKu
{
    class Program
    {
        private static string path;//监控目录路径
        private static string name; //监控文件类型 
        private static string wenkuPath;//存储文件的路径
        private static string flashPath;//flashprinter打印机路径
        private static List<string> list = new List<string>();//用来暂时存储上传的文件名
        private static System.Timers.Timer timer = new System.Timers.Timer(10000);//一分钟
        private static Process pc;

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll ", EntryPoint = "FindWindowEx", SetLastError = true)]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
                
        [DllImport("User32.dll ", EntryPoint = "SendMessage", SetLastError = true)]
        internal static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);
        private static System.Timers.Timer tc = new System.Timers.Timer();

        static void Main(string[] args)
        {
            //E:\名录宝\MLMGC\Monitor\Temp\
            path = ConfigurationManager.AppSettings["MonitorPath"];
            if (!Directory.Exists(path))
            {
                new Log().WriteLog("配置文件指定的临时文件夹不存在，路径："+path);
                return;
            }
            //*.txt
            name = ConfigurationManager.AppSettings["MonitorFile"];
            //E:\名录宝\MLMGC\Web\Resource\WenKu\
            wenkuPath = ConfigurationManager.AppSettings["WenKuPath"];
            if (!Directory.Exists(wenkuPath))
            {
                new Log().WriteLog("配置文件指定的文库文件夹不存在，路径：" + wenkuPath);
                return;
            }
            //D:\Backup\我的文档\下载\FlashPaper2.2\FlashPrinter.exe
            flashPath = ConfigurationManager.AppSettings["path"];
            if (!File.Exists(flashPath))
            {
                new Log().WriteLog("配置文件指定的打印机不存在，路径为："+flashPath);
                return;
            }

            new Log().WriteLog("程序已启动");
            //程序启动后，先检测Temp文件夹中是否有txt，若有就开始转换
            FileInfo[] files = Directory.CreateDirectory(path).GetFiles(name);
            foreach (FileInfo file in files)
            {
                list.Add(file.Name);
            }

            //开始监视文件目录
            new Program().WatchStart(path, name);

            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Cycle);            

            //tc.AutoReset = true;
            tc.Enabled = true;
            tc.Elapsed += new System.Timers.ElapsedEventHandler(tc_Elapsed);



            Console.ReadLine();
            new Log().WriteLog("程序已结束");
        }

        /// <summary>
        /// 监视密码框是否弹出，弹出就关闭。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void tc_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {            
            IntPtr passworHwnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, null, "密码");
            if (passworHwnd != IntPtr.Zero)
            {
                //0x0010是  WM_CLOSE的值
                SendMessage(passworHwnd, 0x0010, IntPtr.Zero, "0");
            }
        }

        /// <summary>
        /// 监视目录是否有文件被创建
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filter"></param>
        private void WatchStart(string path,string name)
        {
            try
            {
                FileSystemWatcher watch = new FileSystemWatcher(path , name);
                watch.EnableRaisingEvents = true;
                watch.Created += new FileSystemEventHandler(watch_Created);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 文件被创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void watch_Created(object sender, FileSystemEventArgs e)
        {            
            list.Add(e.Name);            
        }

        /// <summary>
        /// 周期执行判断list中是否有新的文件，若有 则转换
        /// </summary>
        protected static void Cycle(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (list.Count == 0)
                return;

            //打印list
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("----------------");

            //停止计时
            timer.Enabled = false;
            //循环转换
            for (int i = 0; i < list.Count; )
            {
                //读取创建的txt中的内容
                string content = File.ReadAllLines(path + list[i]).Last();
                ConvertProcess(content);

                //删除物理文件
                if (File.Exists(path + list[i]))
                {
                    File.Delete(path + list[i]);
                }
                //从list中删除
                list.RemoveAt(i);

                //打印剩余要转换的文件
                Console.WriteLine("剩余要转换的文件：{0}个{1}", list.Count, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"));
                foreach (string s in list)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("****************");
            }

            //开启计时
            timer.Enabled = true;
        }

        protected static void ConvertProcess(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return ;
            string[] array = content.Split('|');
            if (array.Length == 0)
                return ;
            Console.WriteLine(content);
            new Log().WriteLog(content);
            try
            {
                Converter(Convert.ToInt32(array[0]),wenkuPath, array[1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                new Log().WriteLog(ex.Message);
            }
        }

        /// <summary>
        /// 转换Swf
        /// </summary>
        /// <param name="id"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        protected static void Converter(int id, string path, string name)
        {
            if (File.Exists(path + name))
            {
                int swfFlag = 1;//默认是转换成功。
                //判断文档类型，是否被加密等
                if (!IsEncryption(path + name))
                {
                    new Log().WriteLog("开始转换");
                    DateTime startTime = DateTime.Now;
                    Console.WriteLine("开始转换,时间：" + startTime.ToString("yyyy-MM-dd HH:mm:ss:ms"));
                    using (pc = new Process())
                    {
                        pc.StartInfo.FileName = flashPath;
                        pc.StartInfo.Arguments = string.Format("{0} -o {1}",
                            path + name,
                            path + "swf\\" + name.Substring(0, name.LastIndexOf(".")) + ".swf");
                        pc.StartInfo.CreateNoWindow = true;
                        pc.StartInfo.UseShellExecute = false;
                        pc.StartInfo.RedirectStandardInput = false;
                        pc.StartInfo.RedirectStandardOutput = false;
                        pc.StartInfo.RedirectStandardError = true;
                        //pc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        pc.Start();
                        //判断外部进程是否结束，如果 没有结束则继续等待。
                        while (!pc.HasExited)
                        {
                            System.Threading.Thread.Sleep(1000);
                            TimeSpan ts = DateTime.Now - startTime;
                            if (ts.TotalMinutes >= 10)//超时，停止转换
                            {
                                Console.WriteLine("执行时间已超过10分钟");
                                //结束当前进程，修改数据库，标识该文件转换失败
                                pc.Kill();
                                //结束所有FlashPrinter
                                foreach (Process p in Process.GetProcessesByName("FlashPrinter"))
                                {
                                    p.Kill();
                                }
                                swfFlag = 2;//转换失败
                                break;
                            }
                        }
                        pc.WaitForExit();
                        pc.Close();
                        pc.Dispose();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }
                    //等待FlashPrinter退出
                    while (Process.GetProcessesByName("FlashPrinter").Length > 0)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                    System.Threading.Thread.Sleep(5000);

                    Console.WriteLine("转换结束,时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"));
                    new Log().WriteLog("结束转换");
                }
                else
                {
                    swfFlag = 2;//转换失败
                    Console.WriteLine("文件已被加密或格式不正确");
                }
                //操作数据库：修改转换标识
                DbHelperSQL.ExecuteSql(string.Format("update B_WenKu set swfFlag = {0} where WenKuID={1}",swfFlag,id));
            }
            else
            {
                Console.WriteLine("文件不存在");
                new Log().WriteLog("文件不存在");
            }
        }

        /// <summary>
        /// 判断文件是否加密
        /// </summary>
        /// <param name="path"></param>
        /// <returns>加密返回true，没加密返回false</returns>
        private static bool IsEncryption(string path)
        {
            bool flag = false;//默认没有加密
            object p = path;
            string suffix = path.Substring(path.LastIndexOf(".")).ToUpper();
            switch (suffix)
            { 
                case ".DOC":
                case ".DOCX":
                    Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                    Document doc= new Document();
                    try
                    {
                        doc = word.Documents.Open(ref p);
                        flag = false ;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        new Log().WriteLog(ex.Message);
                        flag = true ;
                    }
                    doc.Close();
                    word.Quit();
                    break;
                case ".XLS":
                case ".XLSX":
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook xls;
                    try
                    {
                        xls = excel.Workbooks.Open(path);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        new Log().WriteLog(ex.Message);
                        flag = true;
                    }
                    excel.Quit();
                    GC.Collect();
                    break;
                case ".PPT":
                case ".PPTX":
                    Microsoft.Office.Interop.PowerPoint.Application point = new Microsoft.Office.Interop.PowerPoint.Application();
                    Presentation ppt ;
                    point.Visible = MsoTriState.msoTrue;
                    try
                    {
                        ppt = point.Presentations.Open(path);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        new Log().WriteLog(ex.Message);
                        flag = true; 
                    }
                    point.Quit();
                    GC.Collect();
                    break;   
                
                default:
                    break;
            }
            return flag;
        }
    }


}
