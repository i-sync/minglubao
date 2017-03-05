using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using System.Data;

namespace Web.Enterprise.Plan
{
    public partial class ComparisonDate : MLMGC.Security.EnterprisePage
    {
        string flag = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                flag = Requests.GetQueryString("flag");
                databind();
            }
        }

        protected void databind()
        {
            E_ClientInfoHelper data = new E_ClientInfoHelper();
            T_ClientInfoHelper bll = new T_ClientInfoHelper();

            data.EnterpriseID = EnterpriceID;
            data.EPUserTMRID = EPUserTMRID;
            data.TeamID = TeamID;
            data.Flag = flag;
            DataTable dt = bll.ComparisonDate(data);

            rpListDate.DataSource = dt;
            rpListDate.DataBind();

            rpList.DataSource = dt;
            rpList.DataBind();
        }
    }
}