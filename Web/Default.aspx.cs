using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.User;

namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //protected void btnEPLogin_Click(object sender, EventArgs e)
        //{
        //    E_User data = new E_User();
        //    data.UserType = (int)MLMGC.DataEntity.User.UserType.企业用户;
        //    data.EnterpriseCode = txtEPCode.Text;
        //    data.UserName = txtEPUserName.Text;
        //    data.Password = txtEPPassword.Text;
        //    data=new MLMGC.BLL.User.T_User().UserLogin(data);
            
        //    if (data != null)
        //    {
        //        E_EnterpriseUser dataEU = new E_EnterpriseUser();
        //        dataEU.EnterpriseID = data.EnterpriseID;
        //        dataEU.UserID = data.UserID;
        //        dataEU.UserName = data.UserName;
        //        dataEU.Password = data.Password;
        //        dataEU.EPUserTMRID = 0;
        //        new MLMGC.Security.EnterprisePage().Login(dataEU);
        //        MLMGC.Security.ActiveUser.Instance.Login(data.UserID.ToString(), MLMGC.COMP.Requests.GetRealIP());
        //        new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID= data.EnterpriseID,UserID = data.UserID,LogTitle="登录",IP= MLMGC.COMP.Requests.GetRealIP()});
        //        Response.Redirect("enterprise/selectrole.aspx");
        //    }
        //    else
        //    {
        //        MLMGC.COMP.Jscript.ShowMsg("登录信息错误，请重新输入登录信息！", this);
        //    }
        //}

        //protected void btnPLogin_Click(object sender, EventArgs e)
        //{
        //    E_User data = new E_User();
        //    data.UserType = (int)MLMGC.DataEntity.User.UserType.个人用户;
        //    data.UserName = txtPUserName.Text.Trim();
        //    data.Password = txtPPassword.Text.Trim();
        //    data = new MLMGC.BLL.User.T_User().UserLogin(data);

        //    if (data != null)
        //    {
        //        E_PersonalUser dataPU = new E_PersonalUser();
        //        dataPU.UserID = data.UserID;
        //        dataPU.PersonalID = data.EnterpriseID;
        //        dataPU.UserName = data.UserName;
        //        dataPU.Password = data.Password;
        //        new MLMGC.Security.PersonalPage().Login(dataPU);

        //        //登录成功添加日志
        //        data.LoginIP = Request.ServerVariables["Remote_Addr"];
        //        data.Browser = Request.Browser.Type;
        //        data.Resolution = hdResolution.Value;
        //        bool flag = new MLMGC.BLL.User.T_User().AddLoginInfo(data);

        //        Response.Redirect("personal/default.aspx");
        //    }
        //    else
        //    {
        //        MLMGC.COMP.Jscript.ShowMsg("登录信息错误，请重新输入登录信息！", this);
        //    }            
        //}

        /// <summary>
        /// 创建快捷方式
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="URL">URL地址</param>
        private void CreateShortcut(string Title, string URL)
        {
            string strFavoriteFolder;

            // “收藏夹”中 创建 IE 快捷方式
            //strFavoriteFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
           // CreateShortcutFile(Title, URL, strFavoriteFolder);

            // “ 桌面 ”中 创建 IE 快捷方式
            strFavoriteFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            CreateShortcutFile(Title, URL, strFavoriteFolder);

            // “ 链接 ”中 创建 IE 快捷方式
            //strFavoriteFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Favorites) + "\\链接";
            //CreateShortcutFile(Title, URL, strFavoriteFolder);

            //「开始」菜单中 创建 IE 快捷方式
            //strFavoriteFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            //CreateShortcutFile(Title, URL, strFavoriteFolder);

        }

        /// <summary>
        /// 创建快捷方式
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="URL">URL地址</param>
        /// <param name="SpecialFolder">特殊文件夹</param>
        private void CreateShortcutFile(string Title, string URL, string SpecialFolder)
        {
            // Create shortcut file, based on Title
            System.IO.StreamWriter objWriter = System.IO.File.CreateText(SpecialFolder + "\\" + Title + ".url");
            // Write URL to file
            objWriter.WriteLine("[InternetShortcut]");
            objWriter.WriteLine("URL=" + URL);
            // Close file
            objWriter.Close();
        }

        protected void btnShortcut_Click(object sender, System.EventArgs e)
        {
            CreateShortcut("名录宝", @"http:\//www.minglubao.com/");
        }        
    }
}