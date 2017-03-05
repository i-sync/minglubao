using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.Config
{
    public partial class PropertySource : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            E_Source data = new E_Source();
            data.EnterpriseID = EnterpriceID;
            rpList.DataSource = new T_Source().GetList(data);
            rpList.DataBind();
        }
    }
}