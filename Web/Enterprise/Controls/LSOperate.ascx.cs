using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Enterprise.Controls
{
    /// <summary>
    /// 领导名录操作控制
    /// </summary>
    public partial class LSOperate : System.Web.UI.UserControl
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

            //代码动态添加JS文件的引用
            MLMGC.Controls.PageHeader.AddCSS(Page, "/Styles/core.css");
        }
        string _selector = "";
        bool _hideshare = false;
        bool _hideshareall = true;
        bool _hidereport = true;
        bool _hidedelete = true;
        bool _hidedeleteall = true;
        /// <summary>
        /// JQuery 选择器(多选框名称) 所有多选框
        /// </summary>
        public string selector
        {
            set { _selector = value; }
            protected get { return _selector; }
        }
        /// <summary>
        /// 是否隐藏共享操作
        /// </summary>
        public bool HideShare
        {
            set { _hideshare = value; }
            protected get { return _hideshare; }
        }

        /// <summary>
        /// 是否隐藏共享所有
        /// </summary>
        public bool HideShareAll
        {
            get { return _hideshareall; }
            set { _hideshareall = value; }
        }

        /// <summary>
        /// 是否隐藏删除按钮：只有总监才能删除名录
        /// </summary>
        public bool HideDelete
        {
            set { _hidedelete = value; }
            protected get { return _hidedelete; }
        }

        /// <summary>
        /// 是否隐藏删除所有按钮
        /// </summary>
        public bool HideDeleteAll
        {
            get { return _hidedeleteall; }
            set { _hidedeleteall = value; }
        }

        /// <summary>
        /// 是否隐藏上报
        /// </summary>
        public bool HideReport
        {
            get { return _hidereport; }
            set { _hidereport = value; }
        }

        /// <summary>
        /// 位置：1-团队，2-共享，0-业务员
        /// </summary>
        public int Mode { get; set; }
        /// <summary>
        /// 状态：0=待分配名录，1=潜在客户，2=意向客户，3=成交客户，4=未成交客户，5=报废客户，6=共享
        /// </summary>
        public int Status { get; set; }
    }
}