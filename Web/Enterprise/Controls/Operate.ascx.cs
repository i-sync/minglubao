using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Web.Enterprise.Controls
{
    public partial class Operate : System.Web.UI.UserControl
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }
        protected void databind()
        {
            //添加样式及js文件
            MLMGC.Controls.PageHeader.AddJS(this.Page, "/JS/popup_layer.js");
            MLMGC.Controls.PageHeader.AddJS(this.Page, "JS/poptip.js");

            //代码动态添加JS文件的引用
            MLMGC.Controls.PageHeader.AddCSS(Page, "/Styles/core.css");
            MLMGC.Controls.PageHeader.AddCSS(Page, "/Styles/msgbox.css");
        }
        string _selector = "";
        protected int _clientinfoid = -1;
        /// <summary>
        /// JQuery 选择器(多选框名称)
        /// </summary>
        public string selector
        {
            set { _selector = value; }
            protected get { return _selector; }
        }
        /// <summary>
        /// 项目名录编号
        /// </summary>
        public int ClientInfoID
        {
            set { _clientinfoid = value; }
        }
        bool _showshare = true;
         bool _showsms = false;
         bool _showlock = false;
        /// <summary>
        /// 是否显示共享
        /// </summary>
        public bool ShowShare
        {
            set { _showshare = value; }
            protected get { return _showshare; }
        }
        /// <summary>
        /// 是否显示发送短信
        /// </summary>
        public bool ShowSMS
        {
            protected get { return _showsms; }
            set { _showsms = value; }
        }
        /// <summary>
        /// 是否显示锁定和解锁：默认不显示（只有业务员的潜在和意向显示）
        /// </summary>
        public bool ShowLock
        {
            protected get { return _showlock; }
            set { _showlock = value; }
        }
    }
}