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
    public partial class StateNotTraded : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            T_NotTraded bll = new T_NotTraded();
            rpList.DataSource = bll.GetList(new E_NotTraded() { EnterpriseID = EnterpriceID });
            rpList.DataBind();
        }
    }
}