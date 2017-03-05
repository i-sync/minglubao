using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;
using MLMGC.COMP;

namespace Web.User
{
    public partial class Reg : System.Web.UI.Page
    {
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                databind(); 
            }
        }

        protected void databind()
        {
            //生成新用户编码
            hdUID.Value = Guid.NewGuid().ToString();
        }
    }
}