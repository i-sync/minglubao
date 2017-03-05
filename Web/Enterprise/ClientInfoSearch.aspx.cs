using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise
{
    public partial class ClientInfoSearch : MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected bool TradeFlag = false, AreaFlag = false, SourceFlag = false;
        string[] aryTypeField = { "ClientName", "Linkman", "Tel", "Mobile", "Email" };
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Convert.ToInt32(Request.QueryString["page"] ?? "1");
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            //获取名录属性信息
            E_Property dataProperty = new T_Property().Get(new E_Property() { EnterpriseID = EnterpriceID });
            TradeFlag = Convert.ToBoolean((int)dataProperty.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)dataProperty.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)dataProperty.SourceFlag);

            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.UserID = UserID;
            data.EPUserTMRID = EPUserTMRID;
            data.TeamID = 0;
            data.Property = dataProperty;
            txtKeyword.Text = MLMGC.COMP.Requests.GetQueryString("keyword");
            ddlType.SelectedIndex = MLMGC.COMP.Requests.GetQueryInt("type",0);
            data.ClientName = ddlType.SelectedIndex==0?txtKeyword.Text:string.Empty;
            data.Linkman = ddlType.SelectedIndex == 1 ? txtKeyword.Text : string.Empty;
            data.Tel = ddlType.SelectedIndex == 2 ? txtKeyword.Text : string.Empty;
            data.Mobile = ddlType.SelectedIndex == 3 ? txtKeyword.Text : string.Empty;
            data.Email = ddlType.SelectedIndex == 4 ? txtKeyword.Text : string.Empty;
            data.Mode = EnumClientMode.业务员;
            data.Status = EnumClientStatus.所有状态;

            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new T_ClientInfo().GetList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }
        /// <summary>
        /// 获取状态名称
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public string GetStatusName(object v)
        {
            return MLMGC.COMP.EnumUtil.GetName<EnumClientStatus>(v.ToString());
        }
    }
}