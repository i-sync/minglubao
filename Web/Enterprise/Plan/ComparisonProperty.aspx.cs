using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise.Plan
{
    public partial class ComparisonProperty :MLMGC.Security.EnterprisePage
    {
        string flag = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            flag = Requests.GetQueryString("flag");
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

            rpList.DataSource = bll.ComparisonProperty(data, flag);
            rpList.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            databind();
        }
    }
}