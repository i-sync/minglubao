using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;

namespace Web.Enterprise.Config
{
    public partial class StateScrap : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            T_Scrap bll = new T_Scrap();
            rpList.DataSource = bll.GetList(new E_Scrap() { EnterpriseID = EnterpriceID });
            rpList.DataBind();
        }
    }
}