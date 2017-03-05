using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Personal;
using MLMGC.BLL.Personal.Config;
using MLMGC.DataEntity.Personal;
using MLMGC.DataEntity.Personal.Config;

namespace Web.Personal
{
    public partial class Wish : MLMGC.Security.PersonalPage
    {
        int pageSize = 20, pageIndex = 1;
        protected bool TradeFlag = false, AreaFlag = false, SourceFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            //开始计时
            DateTime StartTime = DateTime.Now;

            //绑定意向程度
            ddlWish.DataSource = new T_Wish().GetList(new E_Wish() { PersonalID =PersonalID });
            ddlWish.DataTextField = "WishName";
            ddlWish.DataValueField = "WishID";
            ddlWish.DataBind();
            ddlWish.Items.Insert(0, new ListItem("", "-1"));
            ddlWish.SelectedValue = Requests.GetQueryInt("wishid", -1).ToString();
            //获取名录属性信息
            E_Property dataProperty = new T_Property().Get(new E_Property() { PersonalID = PersonalID });
            TradeFlag = Convert.ToBoolean((int)dataProperty.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)dataProperty.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)dataProperty.SourceFlag);

            E_ClientInfo data = new E_ClientInfo();
            data. PersonalID =PersonalID;
            //--设置名录属性查询属性
            data.Property = dataProperty;
            data.TradeID = Requests.GetQueryInt("tradeid", -1);
            data.AreaID = Requests.GetQueryInt("areaid", -1);
            data.SourceID = Requests.GetQueryInt("sourceid", -1);
            Property1.PropertyData = dataProperty;
            Property1.AreaID = data.AreaID;
            Property1.SourceID = data.SourceID;
            Property1.TradeID = data.TradeID;

            data.ClientName = Requests.GetQueryString("name");
            txtName.Text = data.ClientName;
            data.Status = EnumClientStatus.意向客户;
            data.WishID = int.Parse(ddlWish.SelectedValue.ToString());

            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new T_ClientInfo().WishSelect(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";

            //停止计时
            DateTime EndTime = DateTime.Now;
            TimeSpan ts = EndTime - StartTime;
            lblExecTime.Text = ts.TotalSeconds.ToString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format(Request.Url.AbsolutePath + "?name={0}&wishid={1}{2}", txtName.Text, ddlWish.SelectedValue, Property1.Query);
            Response.Redirect(url);
        }
    }
}