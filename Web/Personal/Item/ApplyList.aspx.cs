using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;
using MLMGC.COMP;

namespace Web.Personal.Item
{
    public partial class ApplyList : MLMGC.Security.PersonalPage
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
        protected void databind()
        {
            EnumUtil.BindList<EnumApply>(rbStatus);

            int status = Requests.GetQueryInt("status", -1);
            rbStatus.SelectedValue = status.ToString();
            E_ItemApply data = new E_ItemApply();

            data.SetStatus = status;
            data.ApplyType = EnumApplyType.申请加入;
            data.UserID = UserID;
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            rpList.DataSource = new T_ItemApply().GetList(data);
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
            string url = string.Format("{0}?status={1}", Request.Url.AbsolutePath, rbStatus.SelectedValue);
            Response.Redirect(url);
        }

        protected string Status(object obj)
        {
            return ((EnumApply)Convert.ToInt32(obj)).ToString();
        }
    }
}