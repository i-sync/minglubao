using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;

namespace WebAdmin.Enterprise.EnterpriseDB
{
    public partial class List : System.Web.UI.Page
    {
        private int pageIndex = 1, pageSize = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            if (!IsPostBack)
            {
                databind();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        public void databind()
        {
            E_EnterpriseDB data = new E_EnterpriseDB();
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            rpList.DataSource = new T_EnterpriseDB().SelectList(data);
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