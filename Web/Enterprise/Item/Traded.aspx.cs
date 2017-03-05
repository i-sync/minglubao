using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.Item
{
    public partial class Traded : MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected bool TradeFlag = false, AreaFlag = false, SourceFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);

            //判断是否有权限操作
            isPermission();

            if (!IsPostBack) { databind(); }
        }

        /// <summary>
        /// 绑定页面加载数据
        /// </summary>
        protected void databind()
        {
            //------初始化查询日期------
            txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-01");
            txtEndDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            //------绑定用户列表------
            E_ItemMember dataT = new E_ItemMember();
            dataT.EnterpriseID = EnterpriceID;
            DataTable dt = new T_ItemMember().GetMemberList(dataT);
            ddlObject.DataSource = dt;
            ddlObject.DataTextField = "RealName";
            ddlObject.DataValueField = "UserID";
            ddlObject.DataBind();
            //插入一个“全部”选项
            ddlObject.Items.Insert(0, new ListItem("全部", "0"));
            
            //-------查询对象------------
            ddlObject.SelectedValue = Requests.GetQueryString("objid");

            //----------查询结果-----------
            //获取名录属性信息
            E_Property dataProperty = new T_Property().Get(new E_Property() { EnterpriseID = EnterpriceID });
            TradeFlag = Convert.ToBoolean((int)dataProperty.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)dataProperty.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)dataProperty.SourceFlag);


            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.Status = MLMGC.DataEntity.Item.EnumClientStatus.成交客户;
            data.UserID = Convert.ToInt32(ddlObject.SelectedValue);
            //data.EPUserTMRID = Convert.ToInt32(ddlObject.SelectedValue);
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
            string start = Requests.GetQueryString("start");
            string end = Requests.GetQueryString("end");
            if (!string.IsNullOrEmpty(start))
            {
                data.Page.StartDate = Convert.ToDateTime(start);
                txtStartDate.Text = Convert.ToDateTime(start).ToShortDateString();
            }
            else
            {
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-01");
                data.Page.StartDate = Convert.ToDateTime(txtStartDate.Text);
            }
            if (!string.IsNullOrEmpty(end))
            {
                data.Page.EndDate = Convert.ToDateTime(end);
                txtEndDate.Text = Convert.ToDateTime(end).ToShortDateString();
            }
            else
            {
                txtEndDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                data.Page.EndDate = Convert.ToDateTime(txtEndDate.Text);
            }
            //绑定数据
            rpList.DataSource = new T_ItemClientInfo().LeaderTradedList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
            //-----------------------------
        }
    }
}