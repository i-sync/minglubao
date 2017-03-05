using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;


namespace Web.Personal.Item
{
    public partial class Info : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }



        /// <summary>
        /// 绑定页面数据
        /// </summary>
        protected void databind()
        {
            int ciid = Requests.GetQueryInt("ciid", 0);
            //-----------------绑定基本信息------------------------------
            E_ItemClientInfo data = new T_ItemClientInfo().GetModel(new E_ItemClientInfo() { EnterpriseID = EnterpriseID, ClientInfoID = ciid, UserID = 0 });
            if (data == null)
            {
                Response.Write("<script type='text/javascript'>alert('信息不存在');history.go(-1);</script>");
                return;
            }
            ltClientName.Text = data.ClientName;
            ltAddress.Text = data.Address;
            ltZipCode.Text = data.ZipCode;
            ltLinkman.Text = data.Linkman;
            ltPosition.Text = data.Position;
            ltEmail.Text = data.Email;
            ltTel.Text = data.Tel;
            ltMobile.Text = data.Mobile;
            hlWebsite.NavigateUrl = data.Website.IndexOf("http://") == -1 ? "http://" + data.Website : data.Website;
            hlWebsite.Text = data.Website;
            ltFax.Text = data.Fax;
            ltRemark.Text = data.Remark;
            //-----------------绑定名录属性------------------------------
            Property1.SourceID = data.SourceID;
            Property1.TradeID = data.TradeID;
            Property1.AreaID = data.AreaID;
            //-----------------绑定状态------------------------------
            ltStatus.Text = data.Status.ToString();
            //----------------绑定沟通记录---------------------
            rpExchangeList.DataSource = new T_ItemExchange().GetList(new E_ItemExchange() { EnterpriseID = EnterpriseID, ClientInfoID = ciid });
            rpExchangeList.DataBind();

        }
    }
}