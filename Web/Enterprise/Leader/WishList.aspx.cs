using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.User;
using MLMGC.DataEntity.Enterprise;
using System.Data;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.Leader
{
    public partial class WishList : MLMGC.Security.EnterprisePage
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
            //是否显示删除按钮
            if (RoleID == (int)EnumRole.总监)
            {
                LSOperate1.HideDelete = false;
            }

            //txtDay.Text = MLMGC.COMP.Config.WarningDay.ToString();
            //------绑定意向程度------
            ddlWish.DataSource = new T_Wish().GetList(new E_Wish() { EnterpriseID = EnterpriceID });
            ddlWish.DataTextField = "WishName";
            ddlWish.DataValueField = "WishID";
            ddlWish.DataBind();
            ddlWish.Items.Insert(0, new ListItem("", "-1"));
            //------绑定用户列表------
            E_Team dataT = new E_Team();
            dataT.EnterpriseID = EnterpriceID;
            dataT.TeamID = TeamID;
            DataTable dt = new T_Team().GetTeamMember(dataT);
            foreach (DataRow dr in dt.Rows)
            {
                ddlObject.Items.Add(new ListItem(string.Format("【{0}】{1}", dr["RoleName"], dr["TrueName"]), dr["EPUserTMRID"].ToString()));
            }
            //------绑定统计信息------
            E_ClientInfo dataCI = new E_ClientInfo();
            dataCI.EnterpriseID = EnterpriceID;
            dataCI.TeamID = TeamID;
            dataCI.Mode = EnumClientMode.业务员;
            dataCI.Status = EnumClientStatus.意向客户;

            rpStatistics.DataSource = new T_ClientInfo().LeaderStatistics(dataCI);
            rpStatistics.DataBind();
            //-------查询对象------------
            ddlObject.SelectedValue = Requests.GetQueryString("objid");

            //-------------查询结果-------------
            //获取名录属性信息
            E_Property dataProperty = new T_Property().Get(new E_Property() { EnterpriseID = EnterpriceID });
            TradeFlag = Convert.ToBoolean((int)dataProperty.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)dataProperty.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)dataProperty.SourceFlag);

            string startdate = Requests.GetQueryString("startdate");
            string enddate = Requests.GetQueryString("enddate");

            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;
            data.Mode = EnumClientMode.业务员;
            data.Status = EnumClientStatus.意向客户;

            data.EPUserTMRID = Convert.ToInt32(ddlObject.SelectedValue);
            data.ClientName = Requests.GetQueryString("name");
            txtName.Text = data.ClientName;
            data.Property = dataProperty;
            data.SourceID = Requests.GetQueryInt("sourceid", -1);
            data.TradeID = Requests.GetQueryInt("tradeid", -1);
            data.AreaID = Requests.GetQueryInt("areaid", -1);
            data.WishID = Requests.GetQueryInt("wishid", -1);
            ddlWish.SelectedValue = data.WishID.ToString();
            Property1.SourceID = data.SourceID;
            Property1.TradeID = data.TradeID;
            Property1.AreaID = data.AreaID;

            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;
            if (startdate != string.Empty)
            {
                data.Page.StartDate = Convert.ToDateTime(startdate);
                txtStartDate.Text = Convert.ToDateTime(startdate).ToShortDateString();
            }
            if (enddate != string.Empty)
            {
                data.Page.EndDate = Convert.ToDateTime(enddate);
                txtEndDate.Text = Convert.ToDateTime(enddate).ToShortDateString();
            }
            //绑定数据
            rpList.DataSource = new T_ClientInfo().LeaderWishList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
            //-----------------------------------
        }
    }
}