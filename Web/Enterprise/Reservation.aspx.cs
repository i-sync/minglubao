using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise
{
    public partial class Reservation :MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            if (!IsPostBack)
            {
                databind();               
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind()
        {
            E_ClientInfoHelper data = new E_ClientInfoHelper();
            data.EnterpriseID = EnterpriceID;
            data.EPUserTMRID = EPUserTMRID;

            string start = Requests.GetQueryString("startdate");
            string end = Requests.GetQueryString("enddate");
           
            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;
            if (start != "")
            {
                data.Page.StartDate = Convert.ToDateTime(start);
            }
            else
            {
                data.Page.StartDate = DateTime.Now;
            }
            if (end != "")
            {
                data.Page.EndDate = Convert.ToDateTime(end);
            }
            else
            {
                data.Page.EndDate = DateTime.Now.AddDays(1);
            }

            txtStartDate.Text =Convert.ToDateTime(data.Page.StartDate).ToString("yyyy-MM-dd");
            txtEndDate.Text = Convert.ToDateTime(data.Page.EndDate).ToString("yyyy-MM-dd");

            rpList.DataSource = new T_ClientInfoHelper().GetReservationList(data);
            rpList.DataBind();
            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }
                

        /// <summary>
        /// 检索按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format(Request.Url.AbsolutePath + "?startdate={0}&enddate={1}",txtStartDate.Text, txtEndDate.Text);
            Response.Redirect(url);
        }

        /// <summary>
        /// 读取预约类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected string GetReType(object type)
        {
            if (type == null || type == DBNull.Value)
                return "";
            int t = Convert.ToInt32(type);
            EnumReservationType rt = (EnumReservationType)t;
            return rt.ToString();
        }
    }
}