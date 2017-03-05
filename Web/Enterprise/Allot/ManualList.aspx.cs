using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise.Allot
{
    public partial class ManualList :MLMGC.Security.EnterprisePage
    {
        int pageSize =20, pageIndex = 1;
        protected bool TradeFlag = false, AreaFlag = false, SourceFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            if (!IsPostBack) { databind(); }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind()
        {
            E_Property dataProperty = new T_Property().Get(new E_Property { EnterpriseID = EnterpriceID });
            TradeFlag = Convert.ToBoolean((int)dataProperty.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)dataProperty.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)dataProperty.SourceFlag);

            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;
            data.Mode = EnumClientMode.团队;
            data.Status = EnumClientStatus.待分配名录;
            data.Property = dataProperty;
            data.ClientName = Requests.GetQueryString("name");
            data.SourceID = Requests.GetQueryInt("sourceid", -1);
            data.AreaID = Requests.GetQueryInt("areaid", -1);
            data.TradeID = Requests.GetQueryInt("tradeid", -1);

            //设置分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            string start = Requests.GetQueryString("startdate");
            string end = Requests.GetQueryString("enddate");
            if (!string.IsNullOrWhiteSpace(start))
                data.Page.StartDate = Convert.ToDateTime(start);
            if(!string.IsNullOrWhiteSpace(end))
                data.Page.EndDate = Convert.ToDateTime(end);
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            rpList.DataSource = new T_ClientInfo().LeaderWaitList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }
    }
}