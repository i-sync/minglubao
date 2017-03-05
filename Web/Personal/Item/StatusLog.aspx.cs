using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;
using MLMGC.COMP;

namespace Web.Personal.Item
{
    public partial class StatusLog : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //判断用户是否加入了项目，或者该企业项目是否开通
            if (EnterpriseID == 0)
            {
                Jscript.ShowMsg("您还没有加入项目无法操作!", this);
                return;
            }
            else if (!IsOpen)
            {
                Jscript.ShowMsg("您所加入的企业项目还未开通!", this);
                return;
            }

            if (!IsPostBack) { databind(); }
        }
        /// <summary>
        /// 绑定状态日志列表
        /// </summary>
        protected void databind()
        {
            rpList.DataSource = new T_ItemClientInfo().GetStatusList(new E_ItemClientInfo() { EnterpriseID = EnterpriseID, ClientInfoID = Requests.GetQueryInt("ciid", 0),UserID = UserID });
            rpList.DataBind();
        }
    }
}