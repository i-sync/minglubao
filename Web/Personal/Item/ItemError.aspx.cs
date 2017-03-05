using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;

namespace Web.Personal.Item
{
    public partial class ItemError : System.Web.UI.Page
    {
        protected int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Requests.GetQueryInt("type", 0);
            if (!IsPostBack)
            {
                databind();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind()
        {
            string tips = string.Empty;

            switch (type)
            {
                case 1:
                    tips = "您还没有加入项目，所有无法查看！";
                    break;
                case 2:
                    tips = "您所加入的企业项目还未开通，所有无法查看！";
                    break;
                default:
                    tips = "您还没有加入项目无法操作或您所加入的企业项目还未开通！";
                    break;
            }
            ltContent.Text = tips;
        }
    }
}