using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.WenKu;
using MLMGC.BLL.WenKu;
using MLMGC.COMP;

namespace WebAdmin.WenKu
{
    public partial class CheckList : System.Web.UI.Page
    {
        int pageIndex = 1, pageSize = 20;
        protected bool WaitAudit = false;//待审核
        protected bool OffLine = false;//下线
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
            //获取文库列表
            E_WenKu data = new E_WenKu();
            data.WenKuClassID = -1;
            data.Keywords = Requests.GetQueryString("keywords");
            txtName.Text = data.Keywords;
            data.SetStatusFlag = Requests.GetQueryInt("status",0);
            hfStatus.Value = ((int)data.StatusFlag).ToString ();//隐藏域用来存储审核状态
            
            
            //控制按钮的显示与隐藏
            if (data.StatusFlag == EnumStatusFlag.待审核)
            {
                WaitAudit = true;
            }
            else if (data.StatusFlag == EnumStatusFlag.审核通过且上线)
            {
                OffLine = true;
            }

            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            rpList.DataSource = new T_WenKu().GetList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 点击检索按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format("{0}?keywords={1}&status={2}", Request.Url.AbsolutePath, txtName.Text.Trim(),hfStatus.Value);
            Response.Redirect(url);
        }
    }
}