using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise.Material;
using MLMGC.BLL.Enterprise.Material;

namespace Web.Enterprise.Info
{
    public partial class Talk : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
            
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind()
        {
            rpList.DataSource = new T_Talk().GetList(new E_Talk() { EnterpriseID=EnterpriceID });
            rpList.DataBind();
        }
    }
}