using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;
using System.Text.RegularExpressions;

namespace Web.Enterprise.Controls
{
    /// <summary>
    /// 企业名录属性
    /// </summary>
    public partial class Property : System.Web.UI.UserControl
    {
        protected int? _sourceid, _areaid, _tradeid;
        bool _ShowLabelStyle = false;
        protected bool TradeFlag = false, AreaFlag = false, SourceFlag = false;
        protected E_Property data = null;
        public string Query
        {
            get {
                string url =string.Format("&sourceid={0}&areaid={1}&tradeid={2}",SourceID,AreaID,TradeID);
                return Regex.Replace(url, "&[a-z]*=-1", "");
            }
        }
        /// <summary>
        /// 获取或设置来源编号
        /// </summary>
        public int? SourceID
        {
            set { _sourceid = value; }
            get { return ddlSource.Enabled?Convert.ToInt32(ddlSource.SelectedValue.ToString()):-1; }
        }
        /// <summary>
        /// 获取或设置地区编号
        /// </summary>
        public int? AreaID
        {
            set { _areaid = value; }
            get { return ddlArea.Enabled?Convert.ToInt32(ddlArea.SelectedValue.ToString()):-1; }
        }
        /// <summary>
        /// 获取或设置行业编号
        /// </summary>
        public int? TradeID
        {
            set { _tradeid = value; }
            get { return ddlTrade.Enabled?Convert.ToInt32(ddlTrade.SelectedValue.ToString()):-1; }
        }
        /// <summary>
        /// 设置属性
        /// </summary>
        public E_Property PropertyData
        {
            set
            {
                data = value;
            }
        }
        /// <summary>
        /// 是否显示标签样式（默认不显示）
        /// </summary>
        public bool ShowLabelStyle { set { _ShowLabelStyle = value; } protected get { return _ShowLabelStyle; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            MLMGC.Security.EnterprisePage eppage = this.Page as MLMGC.Security.EnterprisePage;
            int enterpriceID;
            if (eppage == null)
            {
                MLMGC.Security.PersonalPage ppage = this.Page as MLMGC.Security.PersonalPage;
                enterpriceID = ppage.EnterpriseID;
            }
            else
            { 
                enterpriceID = eppage.EnterpriceID;
            }
            
            if (data == null)//判断是否传递过来参数
            {
                data = new T_Property().Get(new E_Property() { EnterpriseID = enterpriceID });
            }
            TradeFlag = Convert.ToBoolean((int)data.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)data.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)data.SourceFlag);

            if (data.SourceFlag == EnumPropertyEnabled.启用)//判断来源
            {
                DataDictionaries.BindProperty(ddlSource, new T_Source().GetShowList(new E_Source() { EnterpriseID = enterpriceID,CodeIsValue=false }));
            }
            else
            {
                ddlSource.Enabled = false;
            }
            if (data.TradeFlag == EnumPropertyEnabled.启用)//判断行业
            {
                DataDictionaries.BindProperty(ddlTrade, new T_Trade().GetShowList(new E_Trade() { EnterpriseID = enterpriceID,CodeIsValue=false }));
            }
            else
            {
                ddlTrade.Enabled = false;
            }
            if (data.AreaFlag == EnumPropertyEnabled.启用)//判断地区
            {
                DataDictionaries.BindProperty(ddlArea, new T_Area().GetShowList(new E_Area() { EnterpriseID = enterpriceID,CodeIsValue=false }));
            }
            else
            {
                ddlArea.Enabled = false;
            }
            //增加默认值
            ddlSource.Items.Insert(0, new ListItem("  ", "-1"));
            ddlTrade.Items.Insert(0, new ListItem("  ", "-1"));
            ddlArea.Items.Insert(0, new ListItem("  ", "-1"));
            //设置默认选项
            if (_sourceid != null) { ddlSource.SelectedValue = _sourceid.ToString(); lblSource.Text = ddlSource.SelectedItem.Text; }
            if (_tradeid != null) { ddlTrade.SelectedValue = _tradeid.ToString(); lblTrade.Text = ddlTrade.SelectedItem.Text; }
            if (_areaid != null) { ddlArea.SelectedValue = _areaid.ToString(); lblArea.Text = ddlArea.SelectedItem.Text; }
        }
    }
}