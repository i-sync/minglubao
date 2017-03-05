using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DataEntity.User;
using System.Data;
using MLMGC.COMP;

namespace Web.Enterprise.Leader
{
    public partial class NotTradedList : MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected bool TradeFlag = false, AreaFlag = false, SourceFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            if (!IsPostBack) { databind(); }
        }
        /// <summary>
        /// 绑定页面加载数据
        /// </summary>
        protected void databind()
        {
            //名录位置、状态
            LSOperate1.Mode = 1;//在团队中
            LSOperate1.Status = 4;//失败客户
            //是否显示上报按钮
            if (RoleID != (int)EnumRole.总监)
            {
                LSOperate1.HideReport = false;
            }
            else
            {
                LSOperate1.HideDelete = false;
                LSOperate1.HideDeleteAll = false;
            }

            //------绑定失败理由------
            ddlNotTraded.DataSource = new T_NotTraded().GetList(new E_NotTraded() { EnterpriseID = EnterpriceID });
            ddlNotTraded.DataTextField = "NotTradedName";
            ddlNotTraded.DataValueField = "NotTradedID";
            ddlNotTraded.DataBind();
            ddlNotTraded.Items.Insert(0, new ListItem("", "-1"));
            //------绑定团队列表------
            E_Team dataT = new E_Team();
            dataT.EnterpriseID = EnterpriceID;
            dataT.TeamID = TeamID;
            DataTable dt = new T_Team().GetManageTeam(dataT);
            foreach (DataRow dr in dt.Rows)
            {
                ddlObject.Items.Add(new ListItem(dr["TeamName"].ToString(), dr["TeamID"].ToString()));
            }
            //------绑定统计信息------
            E_ClientInfo dataCI = new E_ClientInfo();
            dataCI.EnterpriseID = EnterpriceID;
            dataCI.TeamID = TeamID;
            dataCI.Mode = EnumClientMode.团队;
            dataCI.Status = EnumClientStatus.失败客户;

            rpStatistics.DataSource = new T_ClientInfo().LeaderStatisticsNotTraded(dataCI);
            rpStatistics.DataBind();

            //-------查询对象------------
            ddlObject.SelectedValue = Requests.GetQueryString("objid");

            //-----------查询结果-------------------
            //获取名录属性信息
            E_Property dataProperty = new T_Property().Get(new E_Property() { EnterpriseID = EnterpriceID });
            TradeFlag = Convert.ToBoolean((int)dataProperty.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)dataProperty.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)dataProperty.SourceFlag);

            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;
            data.Mode = EnumClientMode.团队;
            data.Status = EnumClientStatus.失败客户;
            data.LookTeamID = Convert.ToInt32(ddlObject.SelectedValue);
            data.ClientName = Requests.GetQueryString("keyword");
            txtName.Text = data.ClientName;
            data.Property = dataProperty;
            data.SourceID = Requests.GetQueryInt("sourceid", -1);
            data.TradeID = Requests.GetQueryInt("tradeid", -1);
            data.AreaID = Requests.GetQueryInt("areaid", -1);
            Property1.SourceID = data.SourceID;
            Property1.TradeID = data.TradeID;
            Property1.AreaID = data.AreaID;

            data.NotTradedID = Requests.GetQueryInt("nottradedid", -1);
            ddlNotTraded.SelectedValue = data.NotTradedID.ToString();

            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;
            //绑定数据
            rpList.DataSource = new T_ClientInfo().LeaderNotTradedList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
            //-------------------------------------
        }
    }
}