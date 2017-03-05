using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace WebAdmin.Enterprise.Apply
{
    public partial class ApplyDetail : System.Web.UI.Page
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
            int applyid = Requests.GetQueryInt("applyid", 0);
            E_Apply data = new E_Apply();
            data.ApplyID = applyid;
            data = new T_Apply().GetModel(data);
            if (data != null)
            {
                lblName.Text = data.EnterpriseName;
                lblLinkman.Text = data.Linkman;
                lblPosition.Text = data.Position;
                lblTel.Text = data.Tel;
                lblEmail.Text = data.Email;
                lblMobile.Text = data.Mobile;
                lblFax.Text = data.Fax;
                lblAddress.Text = data.Address;
                lblUserAmount.Text = data.UserAmount.ToString();
            }
        }
    }
}