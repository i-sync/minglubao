using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

using MLMGC.DataEntity.User;
using MLMGC.DataEntity.Personal;
using MLMGC.BLL.Personal;
using MLMGC.DBUtility;
using MLMGC.COMP;

namespace TestDataInsert
{
    public class Program
    {
        /*
        //获取配置信息
        private static string enterprisecode = string.Empty;
        private static string enterprisename = string.Empty;
        private static string itemname = string.Empty;
        private static int useramount;
        private static DateTime startdate = DateTime.Now;
        private static DateTime expiredate = DateTime.Now.AddYears(3);
        private static string adminusername = string.Empty;
        private static string adminpassword = string.Empty;

        private static int teammodelid = 4;
        private static string teamscalexml = string.Empty;

        */

        //配置信息
        private static string name = string.Empty;
        private static int num = 10000;

        /// <summary>
        /// 主方法
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            #region 企业


            /*
            Console.WriteLine("开始："+DateTime.Now.ToLongTimeString());
            InitConfig();
            Console.WriteLine("初始化完成");

            try
            {
                StartProgram();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("添加完成"+DateTime.Now.ToLongTimeString());
            Console.ReadLine();
            

            //添加名录
            try
            {
                for (int i = 47; i < 48; i++)
                {
                    new Program().AddClientInfo(i, "mlb18");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                new Log().WriteLog(ex.Message);
            }
             * * */
            #endregion

            name = ConfigurationManager.AppSettings["name"];
            num = Convert.ToInt32(ConfigurationManager.AppSettings["num"]);

            try
            {
                AddClientInfo(name, num);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("出错：" + ex.Message);
                new Log().WriteLog("出错:" + ex.Message);
            }
        }

        #region 企业测试数据
        
        /*
        /// <summary>
        /// 初始化配置信息
        /// </summary>
        private static void InitConfig()
        {
            enterprisecode = ConfigurationManager.AppSettings["EnterpriseCode"];
            enterprisename = ConfigurationManager.AppSettings["EnterpriseName"];
            itemname = ConfigurationManager.AppSettings["ItemName"];
            useramount = Convert.ToInt32(ConfigurationManager.AppSettings["UserAmount"]);
            startdate = Convert.ToDateTime(ConfigurationManager.AppSettings["StartDate"]);
            expiredate = Convert.ToDateTime(ConfigurationManager.AppSettings["ExpireDate"]);
            adminusername = ConfigurationManager.AppSettings["AdminUserName"];
            adminpassword = ConfigurationManager.AppSettings["AdminPassword"];

            teammodelid = Convert.ToInt32(ConfigurationManager.AppSettings["TeamModelID"]);
            teamscalexml = ConfigurationManager.AppSettings["TeamScaleXml"];
        }

        /// <summary>
        /// 开始添加测试数据
        /// </summary>
        private static void StartProgram()
        {
            Console.WriteLine("请输入要添加的企业数量：");
            string content = Console.ReadLine();
            int num;
            while(!int.TryParse(content, out num))
            {
                Console.WriteLine("输入错误请继续：");
                content = Console.ReadLine();
            }

            string code=enterprisecode;
            string name=enterprisename;
            //InsertData(code, name);
            for (int i = 0; i < num; i++)
            {
                //Console.WriteLine(string .Format("第{0}个企业",i+1));
                code = code.Substring(0, 4) + (Convert.ToInt32(code.Substring(4)) + 1).ToString();
                name = name.Substring(0, 2) + (Convert.ToInt32(name.Substring(2)) + 1).ToString();
                if (!InsertData(code, name))
                {
                    Console.WriteLine("出错");
                    new Log().WriteLog("出错");
                    break;
                }
            } 
            //然后把最后的企业号修改到配置文件中，为了下次可直接运行。
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");
            appsection.Settings["EnterpriseCode"].Value = code;
            appsection.Settings["EnterpriseName"].Value = name;
            config.Save(); 
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <returns></returns>
        private static bool InsertData(string code,string name)
        {
            bool flag;
            int EnterpriseID = new Program().AddEnterprise(code,name);
            if (EnterpriseID <= 0)
            {
                new Log().WriteLog("添加企业基本信息失败");
                Console.WriteLine("添加企业基本信息失败");
                return false;
            }

            flag = new Program().AddUser(EnterpriseID);
            if (!flag)
            {
                new Log().WriteLog("添加用户失败");
                Console.WriteLine("添加用户失败");
                return false;
            }

            flag = new Program().AddClientInfo(EnterpriseID, name);
            if (!flag)
            {
                new Log().WriteLog("添加名录失败");
                Console.WriteLine("添加名录失败");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 添加企业
        /// </summary>
        /// <returns></returns>
        private int AddEnterprise(string code,string name)
        {
            int EnterpriseID = 0;
            //---添加企业----
            E_Enterprise EPdata = new E_Enterprise();
            EPdata.EnterpriseCode = code;
            EPdata.EnterpriseNames = name;
            EPdata.ItemName = itemname;
            EPdata.UserAmount = useramount;
            EPdata.StartDate = startdate;
            EPdata.ExpireDate = expiredate;
            EPdata.AdminUserName = adminusername;
            EPdata.AdminPassword = MLMGC.COMP.EncryptString.EncryptPassword(adminpassword);

            DateTime now = DateTime.Now;
            EnterpriseID = new DataSql().Add(EPdata);
            Console.WriteLine("添加企业时间:" + (DateTime.Now - now).TotalMilliseconds.ToString());
            if (EnterpriseID == 0)
            {
                //new Log().WriteLog("添加企业出错");
                //Console.WriteLine("添加企业出错");
                return 0;
            }

            new Log().WriteLog("添加企业成功，企业号：" + EnterpriseID.ToString());
            Console.WriteLine("添加企业成功,企业号：" + EnterpriseID.ToString());
            //-------------------

            //------------设置企业团队模型------------
            E_TeamModel TMdata = new E_TeamModel();
            TMdata.EnterpriseID = EnterpriseID;
            TMdata.TeamModelID = teammodelid;
            now = DateTime.Now;
            int result = new DataSql().SetTeamModel(TMdata);
            Console.WriteLine("设置团队模型时间：" + (DateTime.Now - now).TotalMilliseconds.ToString());
            if (result <= 0)
            {
                //new Log().WriteLog("设置团队模型出错");
                //Console.WriteLine("设置团队模型出错");
                return 0;
            }
            //new Log().WriteLog("设置团队模型成功");
            //Console.WriteLine("设置团队模型成功");
            //---------------------------------------

            //----------设置企业团队规模---------
            E_TeamModel data = new E_TeamModel();
            data.EnterpriseID = EnterpriseID;
            data.TeamScaleXml = teamscalexml;
            data.Child_RoleID = "3,4";//经理roleid 3,组长roleid 4;
            data.Child_RoleAmount = "2,4";//经理 2，组长 3;
            result = new DataSql().UpdateTeamScale(data);
            if (result < 0)
            {
                //new Log().WriteLog("设置企业团队规模出错");
                //Console.WriteLine("设置企业团队规模出错");
                return 0;
            }
            //new Log().WriteLog("设置企业团队规模成功");
            //Console.WriteLine("设置企业团队规模成功");
            //----------------------------------

            //---------修改团队信息（指定上级）----------
            string sql = string.Format("UPDATE dbo.EP_B_Team SET pid= 3 WHERE EnterpriseID={0} AND TeamType=2 AND TeamModelRoleID =9;UPDATE t SET t.pid = 2 FROM (SELECT TOP 2 * FROM dbo.EP_B_Team WHERE EnterpriseID={0} AND TeamType=2 AND TeamModelRoleID =9) t;", EnterpriseID);
            //new Log().WriteLog(sql);
            //Console.WriteLine(sql);
            now = DateTime.Now;
            DbHelperSQL.ExecuteSql(sql);
            Console.WriteLine("修改团队上级时间：" + (DateTime.Now - now).TotalMilliseconds.ToString());
            //new Log().WriteLog("修改团队信息完成");
            //Console.WriteLine("修改团队信息完成");
            //-----------------------------------------

            //new Log().WriteLog("添加企业完成");
            //Console.WriteLine("添加企业完成");
            return EnterpriseID;
        }

        /// <summary>
        /// 添加企业用户
        /// </summary>
        /// <returns></returns>
        private bool AddUser(int EnterpriseID)
        {
            if (EnterpriseID == 0)
            {
                new Log().WriteLog("没有企业号");
                Console.WriteLine("没有企业号");
                return false;
            }
            E_User data = new E_User();
            data.EnterpriseID = EnterpriseID;
            data.UserName = "zongjian";
            data.Password = MLMGC.COMP.EncryptString.EncryptPassword("123456");
            data.UserType = (int)UserType.企业用户;
            data.TrueName = "总监";
            data.RoleSetting = "7:1";
            if (new DataSql().AddEnterpriseUser(data) < 1)
            {
                new Log().WriteLog("添加总监失败");
                Console.WriteLine("添加总监失败");
                return false ;
            }
            //new Log().WriteLog("添加总监成功");
            //Console.WriteLine("添加总监成功");

            //经理
            for (int i = 0; i < 2; i++)
            {
                data.UserName = string.Format("jili{0}", i + 1);
                data.TrueName = string.Format("经理{0}", i + 1);
                data.RoleSetting = string.Format("8:{0}", i + 2);
                if (new DataSql().AddEnterpriseUser(data) < 1)
                {
                    new Log().WriteLog(string.Format("添加经理{0}失败",i+1));
                    Console.WriteLine(string.Format("添加经理{0}失败", i + 1));
                    return false;
                }
                //new Log().WriteLog(string.Format("添加经理{0}成功", i + 1));
                //Console.WriteLine(string.Format("添加经理{0}成功", i + 1));
            }

            //组长

            for (int i = 0; i < 4; i++) 
            {
                data.UserName = string.Format("zuzhang{0}", i + 1);
                data.TrueName = string.Format("组长{0}", i + 1);
                data.RoleSetting = string.Format("9:{0}", i+4);
                if (new DataSql().AddEnterpriseUser(data) < 1)
                {
                    new Log().WriteLog(string.Format("添加组长{0}失败", i + 1));
                    Console.WriteLine(string.Format("添加组长{0}失败", i + 1));
                    return false;
                }
                //new Log().WriteLog(string.Format("添加组长{0}成功", i + 1));
                //Console.WriteLine(string.Format("添加组长{0}成功", i + 1));
            }

            //业务员
            for (int i = 0; i < 100; i++)
            {
                data.UserName = string.Format("yewuyuan{0}", i + 1);
                data.TrueName = string.Format("业务员{0}", i + 1);
                data.RoleSetting = string.Format("10:{0}", i/25 + 4);
                DateTime now = DateTime.Now;
                if (new DataSql().AddEnterpriseUser(data) < 1)
                {
                    new Log().WriteLog(string.Format("添加业务员{0}失败", i + 1));
                    Console.WriteLine(string.Format("添加业务员{0}失败", i + 1));
                    return false;
                }
                double d =(DateTime.Now - now).TotalMilliseconds;
                if(d>=250)
                Console.WriteLine("添加一个业务员时间：" + d.ToString ());
                //new Log().WriteLog(string.Format("添加业务员{0}成功", i + 1));
                //Console.WriteLine(string.Format("添加业务员{0}成功", i + 1));
            }
            //new Log().WriteLog("添加用户完成");
            //Console.WriteLine("添加用户完成");
            return true;
        }

        /// <summary>
        /// 添加名录
        /// </summary>
        /// <returns></returns>
        private bool AddClientInfo(int EnterpriseID, string name)
        {
            if (EnterpriseID == 0)
            {
                new Log().WriteLog("没有企业号");
                Console.WriteLine("没有企业号");
                return false;
            }
            bool flag;
            //查询所有业务员 
            string sql = string.Format("select EPUserTMRID from EP_R_EPUserTMR where EnterpriseID ={0} and TeamModelRoleID =10", EnterpriseID);
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt == null)
            {
                new Log().WriteLog("没有找到业务员");
                Console.WriteLine("没有找到业务员");
                return false;
            }
            int EPUserTMRID = 0;

            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = EnterpriseID;
            foreach (DataRow row in dt.Rows)
            {
                EPUserTMRID = Convert.ToInt32(row["EPUserTMRID"]);
                data.EPUserTMRID = EPUserTMRID;
                Console.WriteLine(data.EPUserTMRID);
                DateTime now = DateTime.Now;
                for (int i = 0; i < 40000; i++) //每个人5条名录
                {
                    data.ClientName = string.Format("{0}{1}{2}", name, EPUserTMRID, i);
                    flag = new DataSql().Add(data);
                    if (!flag)
                    {
                        new Log().WriteLog(string.Format("添加{0}的第{1}个名录出错", EPUserTMRID, i));
                        Console.WriteLine(string.Format("添加{0}的第{1}个名录出错", EPUserTMRID, i));
                        return false;
                    }
                }
                Console.WriteLine((DateTime.Now - now).TotalSeconds.ToString());
            }
            //Console.WriteLine("添加名录完成");
            //new Log().WriteLog("添加名录完成");
            return true;
        }
        * */
        #endregion


        #region 个人

        /// <summary>
        /// 添加名录 
        /// </summary>
        /// <returns></returns>
        public static bool AddClientInfo(string name,int num)
        {
            E_ClientInfo data = new E_ClientInfo();
            T_ClientInfo bll = new T_ClientInfo();
            data.PersonalID = 9;
            Console.WriteLine("开始添加："+DateTime.Now.ToShortTimeString());
            new Log().WriteLog("开始添加：" + DateTime.Now.ToShortTimeString());
            bool flag = false;
            for (int i = 1; i <= num; i++)
            {
                data.ClientName = string.Format("{0}{1}", name, i);
                flag = bll.Add(data);
                if (!flag)
                {
                    Console.WriteLine("添加出错!");
                    new Log().WriteLog("添加出错!");
                    break;
                }
                if (i % 1000 == 0)
                    Console.WriteLine(string.Format("已经添加{0}条，时间：{1}", i , DateTime.Now.ToShortTimeString()));

            }
            Console.WriteLine("添加完成：" + DateTime.Now.ToShortTimeString());
            new Log().WriteLog("添加完成：" + DateTime.Now.ToShortTimeString());
            
            return flag;
        }

        #endregion

    }
}
