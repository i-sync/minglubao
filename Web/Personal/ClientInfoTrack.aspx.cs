using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.DataEntity.Personal;
using MLMGC.BLL.Personal;
using MLMGC.BLL.Personal.Config;
using MLMGC.DataEntity.Personal.Config;

namespace Web.Personal
{
    public partial class ClientInfoTrack : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }
        /// <summary>
        /// 绑定页面数据
        /// </summary>
        protected void databind()
        {
            int clientinfoid = Requests.GetQueryInt("id", 0);
            //Operate1.ClientItemID = ciid;
            //-----------------绑定基本信息------------------------------
            E_ClientInfo data = new T_ClientInfo().GetModel(new E_ClientInfo() { PersonalID = PersonalID,ClientInfoID=clientinfoid });
            if (data == null)
            {
                Jscript.AlertAndRedirect(this, "无权限查看信息", "Search.aspx");
                return;
            }

            #region info的绑定
            lblClientName.Text = data.ClientName;
            lblAddress.Text = data.Address;
            lblZipCode.Text = data.ZipCode;
            lblLinkman.Text = data.Linkman;
            lblPosition.Text = data.Position;
            lblEmail.Text = data.Email;
            lblTel.Text = data.Tel;
            lblMobile.Text = data.Mobile;
            hlWebsite.NavigateUrl = data.Website.IndexOf("http://") == -1 ? "http://" + data.Website : data.Website;
            hlWebsite.Text = data.Website;
            lblFax.Text = data.Fax;
            lblQQ.Text = data.QQ;
            lblMSN.Text = data.MSN;
            lblRemark.Text = data.Remark;
            #endregion

            txtClientName.Text = data.ClientName;
            txtAddress.Text = data.Address;
            txtZipCode.Text = data.ZipCode;
            txtLinkman.Text = data.Linkman;
            txtPosition.Text = data.Position;
            txtEmail.Text = data.Email;
            txtTel.Text = data.Tel;
            txtMobile.Text = data.Mobile;
            txtFax.Text = data.Fax;
            txtWebsite.Text = data.Website;
            txtQQ.Text = data.QQ;
            txtMSN.Text = data.MSN;
            txtRemark.Text = data.Remark;
            //-----------------绑定名录属性------------------------------
            Property1.SourceID = data.SourceID;
            Property1.TradeID = data.TradeID;
            Property1.AreaID = data.AreaID;
            Property2.SourceID = data.SourceID;
            Property2.TradeID = data.TradeID;
            Property2.AreaID = data.AreaID;
            //-----------------绑定状态列表------------------------------
            //绑定意向程度
            ddlWish.DataSource = new T_Wish().GetList(new E_Wish() { PersonalID = PersonalID});
            ddlWish.DataTextField = "WishName";
            ddlWish.DataValueField = "WishID";
            ddlWish.DataBind();
            //添加一个“空”
            ddlWish.Items.Insert(0, new ListItem() { Text = "", Value = "0" });

            //绑定失败理由
            ddlNotTraded.DataSource = new T_NotTraded().GetList(new E_NotTraded() { PersonalID = PersonalID });
            ddlNotTraded.DataTextField = "NotTradedName";
            ddlNotTraded.DataValueField = "NotTradedID";
            ddlNotTraded.DataBind();
            //绑定报废理由
            ddlScrap.DataSource = new T_Scrap().GetList(new E_Scrap() { PersonalID = PersonalID });
            ddlScrap.DataTextField = "ScrapName";
            ddlScrap.DataValueField = "ScrapID";
            ddlScrap.DataBind();
            ////-----------------绑定名录状态------------------------------
            hdStatus.Value = ((int)data.Status).ToString();
            hdWish.Value = data.WishID.ToString();
            hdNotTraded.Value = data.NotTradedID.ToString();
            hdScarp.Value = data.ScrapID.ToString();
            ddlWish.SelectedValue = data.WishID.ToString();
            txtMoney.Text = data.TradedMoney.ToString();
            ddlNotTraded.SelectedValue = data.NotTradedID.ToString();
            ddlScrap.SelectedValue = data.ScrapID.ToString();

            Operate1.ClientInfoID = clientinfoid;
            //----------------绑定沟通记录---------------------
            rpExchangeList.DataSource = new T_Exchange().GetList(new E_Exchange() {PersonalID=PersonalID,ClientInfoID =clientinfoid});
            rpExchangeList.DataBind();
        }
    }
}