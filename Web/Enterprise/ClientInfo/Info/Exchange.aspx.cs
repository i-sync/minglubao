using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.Info
{
    public partial class Exchange : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }
        protected void databind()
        {
            int ciid = Requests.GetQueryInt("ciid", 0);
            //----------------绑定沟通记录---------------------
            rpExchangeList.DataSource = new T_Exchange().GetList(new E_Exchange() { EnterpriseID = EnterpriceID, ClientInfoID = ciid });
            rpExchangeList.DataBind();
        }
    }
}