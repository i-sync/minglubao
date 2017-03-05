using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;
using MLMGC.COMP;

namespace WebAdmin
{
    public partial class AdminList : MLMGC.Security.AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind()
        {
            rpList.DataSource = new T_Admin().GetList();
            rpList.DataBind();
        }
    }
}