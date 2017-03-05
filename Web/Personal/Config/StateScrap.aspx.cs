using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Personal.Config;
using MLMGC.DataEntity.Personal.Config;

namespace Web.Personal.Config
{
    public partial class StateScrap : MLMGC.Security.PersonalPage
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
            T_Scrap bll = new T_Scrap();
            rpList.DataSource = bll.GetList(new E_Scrap() {PersonalID  = PersonalID });
            rpList.DataBind();
        }
    }
}