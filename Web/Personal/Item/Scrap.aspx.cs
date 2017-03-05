using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;
using MLMGC.COMP;

namespace Web.Personal.Item
{
    /// <summary>
    /// 报废名录
    /// </summary>
    public partial class Scrap : MLMGC.Security.PersonalPage
    {
        int pageSize = 20, pageIndex = 1;
        protected bool TradeFlag = false, AreaFlag = false, SourceFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);

            //判断用户是否加入了项目，或者该企业项目是否开通
            IsJoin();

            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            //绑定意向程度
            ddlScrap.DataSource = new T_Scrap().GetList(new E_Scrap() { EnterpriseID = EnterpriseID });
            ddlScrap.DataTextField = "ScrapName";
            ddlScrap.DataValueField = "ScrapID";
            ddlScrap.DataBind();
            ddlScrap.Items.Insert(0, new ListItem("", "-1"));
            ddlScrap.SelectedValue = Requests.GetQueryInt("scrapid", -1).ToString();
            //获取名录属性信息
            E_Property dataProperty = new T_Property().Get(new E_Property() { EnterpriseID = EnterpriseID });
            TradeFlag = Convert.ToBoolean((int)dataProperty.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)dataProperty.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)dataProperty.SourceFlag);

            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = EnterpriseID;
            data.UserID = UserID;
            //--设置名录属性查询属性
            data.Property = dataProperty;
            data.TradeID = Requests.GetQueryInt("tradeid", -1);
            data.AreaID = Requests.GetQueryInt("areaid", -1);
            data.SourceID = Requests.GetQueryInt("sourceid", -1);
            Property1.AreaID = data.AreaID;
            Property1.SourceID = data.SourceID;
            Property1.TradeID = data.TradeID;

            //读取url参数
            data.ClientName = Requests.GetQueryString("name");
            txtName.Text = data.ClientName;

            data.Status = MLMGC.DataEntity.Item.EnumClientStatus.报废客户;
            data.ScrapID = int.Parse(ddlScrap.SelectedValue.ToString());

            //初始Pgae类
            data.Page = new MLMGC.DataEntity.E_Page();
            //分页参数
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new T_ItemClientInfo().ScrapSelect(data);
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
            string url = string.Format(Request.Url.AbsolutePath + "?name={0}&scrapid={1}{2}", txtName.Text, ddlScrap.SelectedValue,Property1.Query);
            Response.Redirect(url);
        }
    }
}