using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personal.Controls
{
    public partial class Operate : System.Web.UI.UserControl
    {
        string _selector = "";
        int _clientinfoid = -1;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
            protected get { return _clientinfoid; }
        }

        /// <summary>
        /// 显示或隐藏发送传真
        /// </summary>
        private bool _showfax = false;
        public bool ShowFax
        {
            protected get { return _showfax; }
            set { _showfax = value; }
        }
        /// <summary>
        /// 显示或隐藏发送短信
        /// </summary>
        private bool _showsms = false;
        public bool ShowSMS
        {
            protected get { return _showsms; }
            set { _showsms = value; }
        }

        private bool _showdelete = true;
        /// <summary>
        /// 显示或隐藏删除按钮
        /// </summary>
        public bool ShowDelete
        {
            protected get { return _showdelete; }
            set { _showdelete = value; }
        }

        /// <summary>
        /// 该字段控制的是个人删除项目名录的按钮：默认为不显示，只有在个人用户进入了项目中过显示
        /// </summary>
        private bool _isshowdelete = false;
        public bool IsShowDelete
        {
            get { return _isshowdelete; }
            set { _isshowdelete = value; }
        }
    }
}