using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Personal.Config;
using MLMGC.DataEntity.Personal.Config;

namespace Web.Personal.Config
{
    public partial class PropertySource :MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind()
        {
            E_Source data = new E_Source();
            data.PersonalID = PersonalID;
            rpList.DataSource = new T_Source().GetList(data);
            rpList.DataBind();
        }
    }
}