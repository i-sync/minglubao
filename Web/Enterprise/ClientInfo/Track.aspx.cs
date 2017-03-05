using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.ClientInfo
{
    public partial class Track : MLMGC.Security.EnterprisePage
    {
        int _previousid=0, _nextid=0;
        string _reservation = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }
        /// <summary>
        /// 绑定页面数据
        /// </summary>
        protected void databind()
        {
            int ciid = Requests.GetQueryInt("ciid", 0);
            Operate1.ClientInfoID = ciid;
            //-----------------绑定基本信息------------------------------
            E_ClientInfo data = new T_ClientInfo().GetModel(new E_ClientInfo() { EnterpriseID = EnterpriceID, ClientInfoID = ciid, EPUserTMRID = EPUserTMRID });
            if (data == null)
            {
                Jscript.AlertAndRedirect(this, "无权限查看信息", "/enterprise/clientinfosearch.aspx");
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
            txtWebsite.Text = data.Website;
            txtMobile.Text = data.Mobile;
            txtFax.Text = data.Fax;
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
            ddlWish.DataSource = new T_Wish().GetList(new E_Wish() { EnterpriseID = EnterpriceID });
            ddlWish.DataTextField = "WishName";
            ddlWish.DataValueField = "WishID";
            ddlWish.DataBind();
            //绑定失败理由
            ddlNotTraded.DataSource = new T_NotTraded().GetList(new E_NotTraded() { EnterpriseID = EnterpriceID });
            ddlNotTraded.DataTextField = "NotTradedName";
            ddlNotTraded.DataValueField = "NotTradedID";
            ddlNotTraded.DataBind();
            //绑定报废理由
            ddlScrap.DataSource = new T_Scrap().GetList(new E_Scrap() { EnterpriseID = EnterpriceID });
            ddlScrap.DataTextField = "ScrapName";
            ddlScrap.DataValueField = "ScrapID";
            ddlScrap.DataBind();
            //-----------------绑定名录状态------------------------------
            hdStatus.Value = ((int)data.Status).ToString();
            hdWish.Value = data.WishID.ToString();
            ddlWish.SelectedValue = data.WishID.ToString();
            txtMoney.Text = data.TradedMoney.ToString();
            ddlNotTraded.SelectedValue = data.NotTradedID.ToString();
            ddlScrap.SelectedValue = data.ScrapID.ToString();
            //----------------绑定沟通记录---------------------
            rpExchangeList.DataSource = new T_Exchange().GetList(new E_Exchange() { EnterpriseID = EnterpriceID, ClientInfoID = ciid });
            rpExchangeList.DataBind();

            txtWdate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //----------------绑定 上一个/下一个---------------------
            _reservation = MLMGC.COMP.Requests.GetQueryString("s");
            DataTable dt = new T_ClientInfoHelper().PrevNext(new E_ClientInfoHelper() { 
                EnterpriseID=EnterpriceID,
                EPUserTMRID=EPUserTMRID,
                ClientInfoID=ciid,
                Status=(ushort)data.Status,
                IsReservation=_reservation==""?false:true
            });
            if (dt != null && dt.Rows.Count == 1)
            {
                _previousid = Convert.ToInt32(dt.Rows[0]["PrevID"].ToString());
                _nextid = Convert.ToInt32(dt.Rows[0]["NextID"].ToString());
            }
            if (_previousid == 0) { btnPrevious.Disabled = true; }
            if (_nextid == 0) { btnNext.Disabled = true; }

            Operate1.ClientInfoID = ciid;

            //----------------绑定预约类型-----------------------
            MLMGC.COMP.EnumUtil.BindList<EnumReservationType>(ddlReType);
        }

        protected int PreviousID
        {
            get { return _previousid; }
        }
        protected int NextID { get { return _nextid; } }
        protected string Reservation 
        {
            get { return _reservation; }
        }
    }
}