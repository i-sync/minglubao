using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;

namespace WebAdmin.Enterprise
{
    public partial class ItemList : System.Web.UI.Page
    {
        protected int pageIndex = 1;
        protected int pageSize = 20;
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
        protected void databind()
        {
            //获取检索名称
            string name = Requests.GetQueryString("name");
            E_Item data = new E_Item();
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;
            
            data.ItemName = name.Trim();
            txtName.Text = name;

            DataTable dt = new T_Item().GetList(data);
            rpList.DataSource = dt;
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 点击按名称进行检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format("{0}?name={1}", Request.Url.AbsolutePath, txtName.Text.Trim());
            Response.Redirect(url);
        }

        /// <summary>
        /// 项目是否公开
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string Status(object obj)
        {
            return ((ItemStatus)Convert.ToInt32(obj)).ToString();
        }

        /// <summary>
        /// 项目是否使用
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string OpenFlag(object obj)
        {
            return ((ItemOpenFlag)Convert.ToInt32(obj)).ToString();
        }
    }
}