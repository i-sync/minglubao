using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.ClientInfo
{
    public partial class Add : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            //绑定名录属性显示
            E_Property data = new T_Property().Get(new E_Property() { EnterpriseID = EnterpriceID });
            trSource.Visible = false;
            trTrade.Visible = false;
            trArea.Visible = false;
            if (data != null)
            {
                if (data.SourceFlag == EnumPropertyEnabled.启用)//判断来源
                {
                    trSource.Visible = true;
                    DataDictionaries.BindProperty(ddlSource, new T_Source().GetShowList(new E_Source() { EnterpriseID = EnterpriceID }));
                }
                if (data.TradeFlag == EnumPropertyEnabled.启用)//判断行业
                {
                    trTrade.Visible = true;
                    DataDictionaries.BindProperty(ddlTrade, new T_Trade().GetShowList(new E_Trade() { EnterpriseID = EnterpriceID }));
                }
                if (data.AreaFlag == EnumPropertyEnabled.启用)//判断地区
                {
                    trArea.Visible = true;
                    DataDictionaries.BindProperty(ddlArea, new T_Area().GetShowList(new E_Area() { EnterpriseID=EnterpriceID}));
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.UserID = UserID;
            data.EPUserTMRID = EPUserTMRID;

            data.ClientName = txtName.Text.Trim();
            data.Address = txtAddress.Text.Trim();
            data.ZipCode = txtZipCode.Text.Trim();
            data.Position = txtPosition.Text.Trim() ;
            data.Linkman = txtLinkman.Text.Trim();
            data.Position = txtPosition.Text.Trim();
            data.Tel = txtTel.Text.Trim();
            data.Mobile = txtMobile.Text.Trim();
            data.Fax = txtFax.Text.Trim();
            data.Website = txtWebsite.Text.Trim();
            data.QQ = txtQQ.Text.Trim();
            data.MSN = txtMSN.Text.Trim();
            data.Email = txtEmail.Text.Trim();
            data.SourceCode = trSource.Visible?txtSourceCode.Text:string.Empty;
            data.TradeCode = trTrade.Visible ? txtTradeCode.Text : string.Empty;
            data.AreaCode = trArea.Visible ? txtAreaCode.Text : string.Empty;
            data.Remark = txtRemark.Text.Trim();
            if (string.IsNullOrWhiteSpace(data.ClientName))//判断是否输入名录名称
            {
                Jscript.ShowMsg("请输入名称", this);
                txtName.Focus();
                return;
            }
            //添加之前再次确认名录名称、电话、手机是否唯一
            bool flag = true;
            DataTable dt = new T_ClientInfo().Exists(new E_ClientInfo { EnterpriseID = data.EnterpriseID, ClientInfoID = data.ClientInfoID, ClientName = data.ClientName });
            if (dt != null && Convert.ToInt32(dt.Rows[0]["Flag"]) > 0)
            {
                flag = false;
            }
            //如果手机不为空
            if (!string.IsNullOrEmpty(data.Mobile.Trim()))
            {
                dt = new T_ClientInfoHelper().ExistsContact(new E_ClientInfoHelper { EnterpriseID = data.EnterpriseID, ClientInfoID = data.ClientInfoID, Type = 1, Value = data.Mobile });
                if (dt != null && Convert.ToInt32(dt.Rows[0]["Flag"]) > 0)
                {
                    flag = false;
                }
            }
            //如果电话不为空
            if (!string.IsNullOrEmpty(data.Tel.Trim()))
            {
                dt = new T_ClientInfoHelper().ExistsContact(new E_ClientInfoHelper { EnterpriseID = data.EnterpriseID, ClientInfoID = data.ClientInfoID, Type = 2, Value = data.Tel });
                if (dt != null && Convert.ToInt32(dt.Rows[0]["Flag"]) > 0)
                {
                    flag = false;
                }
            }
            if (!flag)
            {
                Jscript.ShowMsg("录入失败", this);
                return;
            }
            T_ClientInfo bll = new T_ClientInfo();
            bool b = bll.Add(data);
            if (b)
            {
                //添加操作日志
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "添加名录", IP = MLMGC.COMP.Requests.GetRealIP() });
                Jscript.AlertAndRedirect(this, "录入成功", Request.Url.ToString());
            }
            else
            {
                Jscript.ShowMsg("录入失败", this);
            }
        }
    }
}