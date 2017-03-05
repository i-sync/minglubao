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
using MLMGC.DataEntity.User;

namespace Web.Enterprise.Leader
{
    public partial class WaitList : MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        //protected int day = 0;
        protected bool TradeFlag = false, AreaFlag = false, SourceFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            if (!IsPostBack) { databind(); }
        }

        /// <summary>
        /// 页面初始化加载数据
        /// </summary>
        protected void databind()
        {
            //是否显示删除按钮
            if (RoleID == (int)EnumRole.总监)
            {
                LSOperate1.HideDelete = false;
            }

            //day = Requests.GetQueryInt("day", 7);
            //txtDay.Text = day.ToString();

            //获取名录属性信息
            E_Property dataProperty = new T_Property().Get(new E_Property() { EnterpriseID = EnterpriceID });
            TradeFlag = Convert.ToBoolean((int)dataProperty.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)dataProperty.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)dataProperty.SourceFlag);

            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;
            data.Mode = EnumClientMode.团队;
            data.Status = EnumClientStatus.待分配名录;
            data.ClientName = Requests.GetQueryString("name");
            txtName.Text = data.ClientName;

            data.Property = dataProperty;
            data.SourceID = Requests.GetQueryInt("sourceid", -1);
            data.TradeID = Requests.GetQueryInt("tradeid", -1);
            data.AreaID = Requests.GetQueryInt("areaid", -1);
            Property1.SourceID = data.SourceID;
            Property1.TradeID = data.TradeID;
            Property1.AreaID = data.AreaID;


            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new T_ClientInfo().LeaderWaitList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format(Request.Url.AbsolutePath + "?name={0}{1}", txtName.Text.Trim(), Property1.Query);
            Response.Redirect(url);
        }

    }
}