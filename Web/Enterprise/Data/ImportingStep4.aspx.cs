using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Enterprise.Data
{
    public partial class ImportingStep4 : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            E_ImportingResult result = new ImportingData(EnterpriceID, EPUserTMRID).ImportingDB();
            ltSucc.Text = result.SuccNum.ToString();
            ltFail.Text = result.FailNum.ToString();
            plResult.Visible = true;
        }
    }
}