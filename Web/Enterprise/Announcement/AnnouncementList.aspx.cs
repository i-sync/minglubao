using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.Enterprise.Announcement;
using MLMGC.BLL.Enterprise.Announcement;

namespace Web.Enterprise.Announcement
{
    public partial class AnnouncementList : MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = MLMGC.COMP.Requests.GetQueryInt("page", 1);
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
            //得到最新公告
            E_Announcement data = new E_Announcement();            
            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;
            data.AnnouncementID = -1;
            data = new T_Announcement().GetModel(data);
            if (data != null)
            {
                lblTitle.Text = data.AnnTitle;
                lblAddDate.Text = data.AddDate.ToString("yyyy-MM-dd HH:mm");
                lblContent.Text = data.AnnContent;
            }

            //获取公告列表
            data = new E_Announcement();
            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;
            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new T_Announcement().GetList(data);
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