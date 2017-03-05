using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.Config
{
    public partial class PropertyTrade : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            E_Trade data = new E_Trade();
            data.EnterpriseID = EnterpriceID;
            rpList.DataSource = new T_Trade().GetList(data);
            rpList.DataBind();

        }
    }
}