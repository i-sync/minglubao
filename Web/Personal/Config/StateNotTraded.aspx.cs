using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Personal.Config;
using MLMGC.BLL.Personal.Config;

namespace Web.Personal.Config
{
    public partial class StateNotTraded :MLMGC.Security.PersonalPage
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
            T_NotTraded bll = new T_NotTraded();
            rpList.DataSource = bll.GetList(new E_NotTraded() { PersonalID=PersonalID });
            rpList.DataBind();
        }
    }
}