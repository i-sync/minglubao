using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MLMGC.BLL.WenKu;
using MLMGC.DataEntity.WenKu;

namespace WebAdmin.WenKu
{
    public partial class WenKuClassList : System.Web.UI.Page
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
            rpList.DataSource = new T_WenKuClass().GetList();
            rpList.DataBind();
        }
    }
}