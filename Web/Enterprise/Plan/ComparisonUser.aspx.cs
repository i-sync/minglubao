using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;

namespace Web.Enterprise.Plan
{
    public partial class ComparisonUser : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dtNow = DateTime.Now;
                txtStartDate.Text = new DateTime(dtNow.Year, dtNow.Month, 1).ToString("yyyy-MM-dd");
                databind();
            }
        }

        protected void databind()
        {
            E_ClientInfoHelper data = new E_ClientInfoHelper();
            T_ClientInfoHelper bll = new T_ClientInfoHelper();

            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;
            data.EPUserTMRID = EPUserTMRID;
            data.Page = new MLMGC.DataEntity.E_Page();
            DateTime dtStart, dtEnd;
            if (DateTime.TryParse(txtStartDate.Text, out dtStart))
            {
                data.Page.StartDate = dtStart;
            }
            if (DateTime.TryParse(txtEndDate.Text, out dtEnd))
            {
                data.Page.EndDate = dtEnd;
            }

            rpList.DataSource = bll.ComparisonSalesman(data);
            rpList.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            databind();
        }
    }
}