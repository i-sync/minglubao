using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Enterprise
{
    public partial class Logout :System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MLMGC.Security.EnterprisePage ep = new MLMGC.Security.EnterprisePage(true);
            MLMGC.Security.ActiveUser.Instance.Logout(ep.UserID.ToString());
            ep.LoginOut();
            Response.Redirect("~");
        }
    }
}