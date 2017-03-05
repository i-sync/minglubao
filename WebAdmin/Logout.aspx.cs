using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAdmin
{
    public partial class Logout : MLMGC.Security.AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginOut();
            Response.Redirect("default.aspx");
        }
    }
}