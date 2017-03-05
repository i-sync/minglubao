using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.DataEntity.Personal;
using MLMGC.BLL.Personal;

namespace Web.Personal
{
    public partial class Search : MLMGC.Security.PersonalPage
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
        /// 绑定列表
        /// </summary>
        protected void databind()
        {
            //开始计时
            DateTime StartTime = DateTime.Now;

            E_ClientInfo data = new E_ClientInfo();
            data.PersonalID = PersonalID;
            //--设置名录属性查询属性
            
            data.ClientName = Requests.GetQueryString("name");
            txtName.Text = data.ClientName;

            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new T_ClientInfo().Select(data);
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
            string url = string.Format(Request.Url.AbsolutePath + "?name={0}", txtName.Text);
            Response.Redirect(url);
        }
    }
}