using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using System.Data;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise.Allot
{
    public partial class ManualResult : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind()
        {
            E_Allot data = new E_Allot();
            data.EnterpriseID = EnterpriceID;
            data.ClientInfoIDs = Requests.GetQueryString("ids");
            DataTable dt = new T_Allot().ListResultSelect(data);
            rpList.DataSource = dt;
            rpList.DataBind();

            lblCount.Text = dt.Rows.Count.ToString();
        }
    }
}