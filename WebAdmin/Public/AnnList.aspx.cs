using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.Public;
using MLMGC.BLL.Public;

namespace WebAdmin.Public
{
    public partial class AnnList : System.Web.UI.Page
    {
        int pageIndex = 1,pageSize = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = MLMGC.COMP.Requests.GetQueryInt("page", 1);
            string type = MLMGC.COMP.Requests.GetQueryString("type");
            if (type == "delete")
            {
                Delete();
            }
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
            E_Announcement data = new E_Announcement();
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            rpList.DataSource = new T_Announcement().GetList(data);
            rpList.DataBind();
            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 删除公告
        /// </summary>
        public void Delete()
        {
            int aid = MLMGC.COMP.Requests.GetQueryInt("aid", 0);
            bool flag = new T_Announcement().Delete(new E_Announcement() { AnnouncementID = aid });
            if (flag)
            {
                MLMGC.COMP.Jscript.AlertAndRedirect(this, "删除成功", "AnnList.aspx");
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("删除失败", this);
            }
        }
    }
}