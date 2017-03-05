using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAdmin.Controls
{
    public partial class Ueditor : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected int _width = 435;

        /// <summary>
        /// 获取或设置编辑器中的内容
        /// </summary>
        public string Content
        {
            get { return txtContent.Text; }
            set { txtContent.Text = value; }
        }

        /// <summary>
        /// 设置编辑器的宽度
        /// </summary>
        public int Width
        {
            set
            {
                if (value > 100 && value < 800)
                {
                    _width = value;
                }
            }
        }
    }
}