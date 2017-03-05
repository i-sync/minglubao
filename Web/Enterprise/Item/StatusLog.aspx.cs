using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;

namespace Web.Enterprise.Item
{
    public partial class StatusLog : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }
        /// <summary>
        /// 绑定状态日志列表
        /// </summary>
        protected void databind()
        {
            rpList.DataSource = new T_ItemClientInfo().GetStatusList(new E_ItemClientInfo() { EnterpriseID = EnterpriceID, ClientInfoID = Requests.GetQueryInt("ciid", 0)});
            rpList.DataBind();
        }
    }
}