using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MLMGC.COMP;
using MLMGC.DataEntity.User;
using MLMGC.DataEntity.Personal;
using MLMGC.BLL.User;
using MLMGC.BLL.Personal;
using System.Net.Json;
using System.Text.RegularExpressions;

namespace Web.Personal.Handler
{
    /// <summary>
    /// Info 个人资料的添加、修改、删除、查看等
    /// </summary>
    public class Info : IHttpHandler,IRequiresSessionState
    {
        NameValueCollection nv;
        MLMGC.Security.PersonalPage pp;
        public void ProcessRequest(HttpContext context)
        {
            pp = new MLMGC.Security.PersonalPage(true);
            nv = HttpContext.Current.Request.Form;
            context.Response.ContentType = "text/plain";
            string type = nv["key"];
            switch (type)
            { 
                case "updatebase"://修改个人基本信息
                    UpdateBase();
                    break;
                case "updatejob"://个人用户添加/修改工作信息
                    UpdateJob();
                    break;
                case "deletejob"://个人用户删除工作信息
                    DeleteJob();
                    break;
                case "getjob"://个人用户查询工作信息详情
                    GetJob();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }

        /// <summary>
        /// 修改个人基本信息
        /// </summary>
        private void UpdateBase()
        { 
            //获取界面数据
            string name = nv["name"];
            int gender,marital,workyear;
            DateTime birthday;
            if (!int.TryParse(nv["gender"], out gender) || !int.TryParse(nv["marital"], out marital) ||!int.TryParse(nv["workyear"],out workyear) || !DateTime.TryParse(nv["birthday"],out birthday))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            string email = nv["email"];
            string mobile = nv["mobile"];
            string tel = nv["tel"];
            string fax = nv["fax"];
            string keyword = nv["keyword"];
            string address = nv["address"];

            //验证邮箱、手机、电话格式是否正确 
            bool flag = new Regex(@"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$").IsMatch(email);
            flag = flag & new Regex(@"^1(3|5|8)+\d{9}$").IsMatch(mobile);
            if(!string .IsNullOrEmpty(tel))
                flag = flag & new Regex(@"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$").IsMatch(tel);
            if(!string.IsNullOrEmpty(fax))
                flag = flag & new Regex(@"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$").IsMatch(fax);

            if (!flag)
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_Personal data = new E_Personal();
            data.PersonalID = pp.PersonalID;
            data.UserID = pp.UserID;

            data.RealName = name;
            data.Sex = gender;
            data.SetMaritalStatus = marital;
            data.SetWorkYears = workyear;
            data.Birthday = birthday;
            data.Email = email;
            data.Mobile = mobile;
            data.Tel = tel;
            data.Fax = fax;
            data.KeyWord = keyword;
            data.Address = address;
            bool b = new T_Personal().Update(data);
            HttpContext.Current.Response.Write(b ? "1" : "0");
        }
        
        /// <summary>
        /// 修改工作信息
        /// </summary>
        private void UpdateJob()
        {
            //获取数据
            DateTime startdate;
            int jobid=0,scale;
            string type = nv["type"];
            if (type == "update")
            {
                if (!int.TryParse(nv["jobid"], out jobid))
                {
                    HttpContext.Current.Response.Write("参数错误");
                    return;
                }
            }
            if (!DateTime.TryParse(nv["startdate"], out startdate) || !int.TryParse(nv["scale"], out scale) ||string.IsNullOrEmpty(nv["companyname"]))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            string companyname = nv["companyname"];
            string departments = nv["departments"];
            string position = nv["position"];
            string description = nv["description"];

            E_JobExperience data = new E_JobExperience();
            data.JobExperienceID = jobid;
            data.UserID = pp.UserID;
            data.PersonalID = pp.PersonalID;
            data.StartDate = startdate;
            if (nv["enddate"] == "")
                data.EndDate = null;
            else
                data.EndDate = Convert.ToDateTime(nv["enddate"]);
            data.CompanyName = companyname;
            data.SetScale = scale;
            data.Departments = departments;
            data.Position = position;
            data.JobDescription = description;
            bool flag;
            if (type == "add")
            {
                 flag= new T_JobExperience().Add(data);
            }
            else
            {
                flag = new T_JobExperience().Update(data);
            }
            HttpContext.Current.Response.Write(flag ? data.JobExperienceID.ToString() : "0");
        }
        /// <summary>
        /// 删除工作信息
        /// </summary>
        private void DeleteJob()
        {
            int jobid;
            if (!int.TryParse(nv["jobid"], out jobid))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }

            E_JobExperience data = new E_JobExperience();
            data.PersonalID = pp.PersonalID;
            data.UserID = pp.UserID;
            data.JobExperienceID = jobid;

            bool flag = new T_JobExperience().Delete(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 获取个人经验信息详情
        /// </summary>
        private void GetJob()
        {
            int jobid;
            if (!int.TryParse(nv["jobid"],out jobid))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }

            E_JobExperience data = new E_JobExperience();
            data.PersonalID = pp.PersonalID;
            data.UserID = pp.UserID;
            data.JobExperienceID = jobid;

            data = new T_JobExperience().GetModel(data);
            if (data != null)
            {
                JsonObjectCollection colDR = new JsonObjectCollection();
                colDR.Add(new JsonStringValue("startdate", string.Format("{0:yyyy-MM-dd}",data.StartDate)));
                colDR.Add(new JsonStringValue("enddate", string.Format("{0:yyyy-MM-dd}",data.EndDate)));
                colDR.Add(new JsonStringValue("companyname", data.CompanyName));
                colDR.Add(new JsonStringValue("scale", data.Scale.ToString ()));
                colDR.Add(new JsonStringValue("departments", data.Departments));
                colDR.Add(new JsonStringValue("position", data.Position));
                colDR.Add(new JsonStringValue("description", data.JobDescription));
                HttpContext.Current.Response.Write(colDR.ToString());                
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}