using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Configuration;
using System.IO;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DBUtility;

namespace minglubao
{
    public partial class ServiceMain : ServiceBase
    {
        System.Timers.Timer timerShare = new System.Timers.Timer(60000);//名录共享 一分钟
        System.Timers.Timer timerAllot = new System.Timers.Timer(60000);//自动分配 一分钟
        Thread threadShare = null;//共享客户
        Thread threadAllot = null;//自动分配
        //获取监视文件路径
        private string MonitorPath = string.Empty;

        public ServiceMain()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            new Log().WriteLog("服务已启动");
            //共享客户
            timerShare.Enabled = false;
            timerShare.AutoReset = true;
            timerShare.Elapsed += new System.Timers.ElapsedEventHandler(Share_Elapsed);
            GC.KeepAlive(timerShare);
            //名录分配
            timerAllot.Enabled = false;
            timerAllot.AutoReset = true;
            timerAllot.Elapsed += new System.Timers.ElapsedEventHandler(Allot_Elapsed);
            GC.KeepAlive(timerAllot);

            //E:\名录宝\MLMGC\Monitor\MLMGC.WenKu.exe
            if (!ConfigurationManager.AppSettings.AllKeys.Contains("Monitor"))
            {
                new Log().WriteLog("配置文件中不包含节点Monitor");
                return;
            }
            MonitorPath = ConfigurationManager.AppSettings["Monitor"];
            if (!MLMGC.COMP.CommonMethod.FileExists(MonitorPath))
            {
                new Log().WriteLog("配置文件指定的文件不存在，路径为："+MonitorPath);
                return;
            }

            //启动转换程序
            StartMoniotr();
        }

        protected override void OnStop()
        {
            if (MLMGC.COMP.CommonMethod.FileExists(MonitorPath))
            {
                //停止转换程序
                string filename = MonitorPath;//E:\名录宝\MLMGC\Monitor\MLMGC.WenKu.exe
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);//MLMGC.WenKu.exe
                filename = filename.Substring(0, filename.LastIndexOf("."));
                Process[] list = Process.GetProcessesByName(filename);
                foreach (Process p in list)
                {
                    p.Kill();
                }
                new Log().WriteLog("转换程序已停止");
            }
            new Log().WriteLog("服务已停止");
        }

        #region 共享客户
        /// <summary>
        /// 共享客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Share_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            threadShare = new System.Threading.Thread(new System.Threading.ThreadStart(ShareProcess));
            threadShare.Start();
        }
        /// <summary>
        /// 共享客户程序
        /// </summary>
        protected void ShareProcess()
        {
            //判断当前时间是否为指定时间
            string sharetime = ConfigurationManager.AppSettings["ShareTime"].ToString();
            if (DateTime.Now.ToString("HH:mm") == sharetime)//判断当前时间是否与指定共享时间相等
            {
                new Log().WriteLog("名录共享开始");
                timerShare.Enabled = false;
                try
                {
                    new ProgramProcess().Share();
                }
                catch(Exception mye)
                {
                    new Log().WriteLog("共享错误："+mye.StackTrace.ToString());
                }
                timerShare.Enabled = true;
                new Log().WriteLog("名录共享结束");
            }
        }
        #endregion
        #region 自动分配
        protected void Allot_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            threadAllot = new System.Threading.Thread(new System.Threading.ThreadStart(AllotProcess));
            threadAllot.Start();
        }
        protected void AllotProcess()
        {
            DataTable dt = MLMGC.DBUtility.DbHelperSQL.RunProcedureTable("ProcEP_B_AutoAllotConfig_ListSelect");//待分配列表
            
            //循环遍历所有的企业
            foreach (DataRow row in dt.Rows)
            {
                E_Allot data  = new E_Allot();
                data.AutoAllotConfigID = Convert.ToInt32(row["AutoAllotConfigID"]);
                data.EnterpriseID = Convert.ToInt32(row["EnterpriseID"]);
                data.TeamID = Convert.ToInt32(row["TeamID"]);
                data.AllotAmount = Convert.ToInt32(row["Amount"]);
                data.AllotSort = row["Sort"].ToString();
                data.SetMode = Convert.ToInt32(row["Mode"]);
                //new Thread(new ParameterizedThreadStart(AutoAllotProcess)).Start(data);

                new Thread(new ThreadStart(new ProgramProcess(data).AutoAllotProcess)).Start();
                
            }
        }

        #endregion

        #region 文档格式转换
       
        /// <summary>
        /// 开启文库转换控制台应用程序
        /// </summary>
        protected void StartMoniotr()
        {
            System.Diagnostics.Process pc = new System.Diagnostics.Process();
            pc.StartInfo.FileName = MonitorPath;
            pc.StartInfo.UseShellExecute = false;
            pc.StartInfo.CreateNoWindow = true;
            pc.Start();
            new Log().WriteLog("转换控制台程序已启动");
        }
        #endregion
    }
}
