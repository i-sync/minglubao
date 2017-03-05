using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Personal;
using MLMGC.DataEntity.Personal;
using MLMGC.COMP;

namespace Web.Personal.Info
{
    public partial class StatusLog : MLMGC.Security.PersonalPage
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
            rpList.DataSource = new T_ClientInfo().GetStatusList(new E_ClientInfo() { PersonalID = PersonalID, ClientInfoID = Requests.GetQueryInt("id", 0) });
            rpList.DataBind();
        }
    }
}