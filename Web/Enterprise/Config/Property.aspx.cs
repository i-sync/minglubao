using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;

namespace Web.Enterprise.Config
{
    public partial class Property : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            E_Property data = new T_Property().Get(new E_Property() { EnterpriseID=EnterpriceID});
            if (data != null)
            {
                cbTrade.Checked = (data.TradeFlag == EnumPropertyEnabled.启用);
                cbArea.Checked = (data.AreaFlag == EnumPropertyEnabled.启用);
                cbSource.Checked = (data.SourceFlag == EnumPropertyEnabled.启用);
            }
        }
    }
}