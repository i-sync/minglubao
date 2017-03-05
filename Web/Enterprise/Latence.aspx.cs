using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise
{
    /// <summary>
    /// 【业务人员】潜在客户
    /// </summary>
    public partial class Latence : MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected int day=14;
        protected bool TradeFlag = false, AreaFlag = false, SourceFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            
            if (!IsPostBack)
            {
                databind();
            }
        }

        /// <summary>
        /// 如果Last为null,则根据upate时间计算
        /// </summary>
        /// <param name="last"></param>
        /// <param name="update"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        protected string GetWarning(object last, object update, int day,object warn)
        {
            if (warn.ToString() == "1")
            {
                return "warn";
            }
            if (last != DBNull.Value)
            {
                TimeSpan ts = DateTime.Now - Convert.ToDateTime(last) ;
                return ts.Days > day ? " warning" : "";
            }
            else
            { 
                TimeSpan ts = DateTime.Now - Convert.ToDateTime(update) ;
                return ts.Days > day ? " warning" : "";
            }
        }

        protected void databind()
        {
            day = Requests.GetQueryInt("day", MLMGC.COMP.Config.WarningDay);
            txtDay.Text = day.ToString();
            //获取名录属性信息
            E_Property dataProperty = new T_Property().Get(new E_Property() { EnterpriseID = EnterpriceID });
            TradeFlag =Convert.ToBoolean((int)dataProperty.TradeFlag);
            AreaFlag = Convert.ToBoolean((int)dataProperty.AreaFlag);
            SourceFlag = Convert.ToBoolean((int)dataProperty.SourceFlag);

            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.UserID = UserID;
            data.EPUserTMRID = EPUserTMRID;
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
            data.Mode = EnumClientMode.业务员;
            data.Status = EnumClientStatus.潜在客户;

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format(Request.Url.AbsolutePath+"?name={0}&day={1}{2}",txtName.Text.Trim(),txtDay.Text,Property1.Query);
            Response.Redirect(url);
        }
    }
}