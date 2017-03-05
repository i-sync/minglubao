using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;

namespace WebAdmin.Enterprise.Apply
{
    public partial class ApplyList : System.Web.UI.Page
    {
        int pageSize = 20, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            string type = Requests.GetQueryString("type");
            if (!IsPostBack)
            {
                if (type == "delete")
                {
                    Delete();
                }
                databind();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind()
        {
            E_Apply data = new E_Apply();
            //读取url参数
            data.EnterpriseName = Requests.GetQueryString("name");
            txtName.Text = data.EnterpriseName;

            string start = Requests.GetQueryString("startdate");
            string end = Requests.GetQueryString("enddate");
            txtStartDate.Value = start;
            txtEndDate.Value = end;
            //初始Pgae类
            data.Page = new MLMGC.DataEntity.E_Page();
            if (start != "")
                data.Page.StartDate = Convert.ToDateTime(start);
            if (end != "")
                data.Page.EndDate = Convert.ToDateTime(end);

            //分页参数
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new T_Apply().GetList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 删除企业申请
        /// </summary>
        protected void Delete()
        {
            int applyid = Requests.GetQueryInt("applyid", 0);
            E_Apply data = new E_Apply();
            data.ApplyID = applyid;
            bool flag = new T_Apply().Delete(data);
            if (flag)
            {
                MLMGC.COMP.Jscript.ShowMsg("删除成功", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("删除失败", this);
            }
        }
        /// <summary>
        /// 点击检索按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format(Request.Url.AbsolutePath + "?name={0}&startdate={1}&enddate={2}", txtName.Text,txtStartDate.Value, txtEndDate.Value);
            Response.Redirect(url);
        }
    }
}