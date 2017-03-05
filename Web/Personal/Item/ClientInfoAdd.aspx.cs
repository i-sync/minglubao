using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.Item;
using MLMGC.BLL.Item;
using MLMGC.COMP;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;

namespace Web.Personal.Item
{
    public partial class ClientInfoAdd : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断用户是否加入了项目，或者该企业项目是否开通
            IsJoin();

            if (!IsPostBack) { databind(); }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind()
        {           
            //绑定名录属性显示
            E_Property data = new T_Property().Get(new E_Property() { EnterpriseID= EnterpriseID });
            trSource.Visible = false;
            trTrade.Visible = false;
            trArea.Visible = false;
            if (data != null)
            {
                if (data.SourceFlag == EnumPropertyEnabled.启用)//判断来源
                {
                    trSource.Visible = true;
                    DataDictionaries.BindProperty(ddlSource, new T_Source().GetShowList(new E_Source() {EnterpriseID =EnterpriseID, CodeIsValue = true }));
                }
                if (data.TradeFlag == EnumPropertyEnabled.启用)//判断行业
                {
                    trTrade.Visible = true;
                    DataDictionaries.BindProperty(ddlTrade, new T_Trade().GetShowList(new E_Trade() { EnterpriseID = EnterpriseID, CodeIsValue = true }));
                }
                if (data.AreaFlag == EnumPropertyEnabled.启用)//判断地区
                {
                    trArea.Visible = true;
                    DataDictionaries.BindProperty(ddlArea, new T_Area().GetShowList(new E_Area() { EnterpriseID = EnterpriseID, CodeIsValue = true }));
                }
               
            }
             
        }

        /// <summary>
        /// 点击确定按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = EnterpriseID;
            data.UserID = UserID;

            data.ClientName = txtName.Text.Trim();
            data.Address = txtAddress.Text;
            data.ZipCode = txtZipCode.Text;
            data.Position = txtPosition.Text;
            data.Linkman = txtLinkman.Text;
            data.Position = txtPosition.Text;
            data.Tel = txtTel.Text.Trim();
            data.Mobile = txtMobile.Text.Trim();
            data.Fax = txtFax.Text;
            data.Email = txtEmail.Text;
            data.QQ = txtQQ.Text;
            data.MSN = txtMSN.Text;
            data.Website = txtWebsite.Text;
            data.SourceCode = trSource.Visible ? txtSourceCode.Text : string.Empty;
            data.TradeCode = trTrade.Visible ? txtTradeCode.Text : string.Empty;
            data.AreaCode = trArea.Visible ? txtAreaCode.Text : string.Empty;
            data.Remark = txtRemark.Text;
            if (string.IsNullOrWhiteSpace(data.ClientName))//判断是否输入名录名称
            {
                Jscript.ShowMsg("请输入名称", this);
                txtName.Focus();
                return;
            }
            /*
            //添加之前再次确认名录名称、电话、手机是否唯一
            bool b = true;
            //判断名录名是否存在
            b = new T_ClientInfo().Exists(new E_ItemClientInfo() { PersonalID = PersonalID, ClientName = data.ClientName, ClientInfoID = 0 });

            if (b)
            {
                Jscript.ShowMsg("名录名称已存在！", this);
                return;
            }
            DataTable dt;
            b = true;
            //判断手机是否存在
            if (!string.IsNullOrEmpty(data.Mobile))
            {
                dt = new T_ClientInfo().ExistsContact(new E_ItemClientInfo { PersonalID = PersonalID, ClientInfoID = 0, Type = 1, Value = data.Mobile });
                if (dt == null && Convert.ToInt32(dt.Rows[0]["Flag"]) > -1)
                {
                    b = false;
                }
            }

            //判断电话是否存在
            if (!string.IsNullOrEmpty(data.Tel))
            {
                dt = new T_ClientInfo().ExistsContact(new E_ItemClientInfo { PersonalID = PersonalID, ClientInfoID = 0, Type = 2, Value = data.Tel });
                if (dt == null && Convert.ToInt32(dt.Rows[0]["Flag"]) > -1)
                {
                    b = false;
                }
            }
            if (!b)
            {
                Jscript.ShowMsg("录入失败", this);
                return;
            }
            */
            T_ItemClientInfo bll = new T_ItemClientInfo();
            bool flag = bll.Add(data);
            if (flag)
            {
                Jscript.AlertAndRedirect(this, "录入成功", Request.Url.ToString());
            }
            else
            {
                Jscript.ShowMsg("录入失败", this);
            }
            
        }
    }
}