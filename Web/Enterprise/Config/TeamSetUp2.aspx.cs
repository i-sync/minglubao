using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise.Config
{
    public partial class TeamSetUp2 : MLMGC.Security.EnterprisePage
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
            //绑定团队列表
            rpList.DataSource = new T_Team().GetList(new E_Team() { EnterpriseID = base.EnterpriceID });
            rpList.DataBind();
        }
                
    }
}