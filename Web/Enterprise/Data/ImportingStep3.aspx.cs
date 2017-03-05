using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.Enterprise.Data
{
    public partial class ImportingStep3 : MLMGC.Security.EnterprisePage
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
            DataTable dt = new ImportingData(EnterpriceID,EPUserTMRID).DataList();
            gvList.DataSource = dt;
            gvList.DataBind();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportingStep4.aspx");
        }
    }
}