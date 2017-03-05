using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;
using MLMGC.COMP;

namespace Web.Enterprise.Item
{
    public partial class Recycled : MLMGC.Security.EnterprisePage
    {
        int pageSize = 30, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断是否有权限操作
            isPermission();

            pageIndex = Requests.GetQueryInt("page", 1);
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = EnterpriceID;

            data.ClientName = Requests.GetQueryString("name");
            txtName.Text = data.ClientName;
            string startdate = Requests.GetQueryString("startdate");
            string enddate = Requests.GetQueryString("enddate");
            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;
            if (startdate != string.Empty)
            {
                data.Page.StartDate = Convert.ToDateTime(startdate);
                txtStartDate.Text = startdate;
            }
            if (enddate != string.Empty)
            {
                data.Page.EndDate = Convert.ToDateTime(enddate);
                txtEndDate.Text = enddate;
            }

            rpList.DataSource = new T_ItemClientInfo().LeaderDeleteList(data);
            rpList.DataBind();
            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 彻底删除按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string ciids = hdClientInfoIDs.Value;
            hdClientInfoIDs.Value = "";
            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ciids))//判断格式是否正确 格式：1,21,321
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.ClientInfoIDs = ciids;

            bool flag = new T_ItemClientInfo().ThoroughDelete(data);
            if (flag)
            {
                Jscript.AlertAndRedirect(this, "删除成功", "Recycled.aspx");
            }
            else
            {
                Jscript.ShowMsg("删除失败", this);
            }
        }

        /// <summary>
        /// 删除所有名录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = EnterpriceID;

            bool flag = new T_ItemClientInfo().ThoroughDeleteAll(data);
            if (flag)
            {
                Jscript.AlertAndRedirect(this, "删除成功", "Recycled.aspx");
            }
            else
            {
                Jscript.ShowMsg("删除失败", this);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = string.Format(Request.Url.AbsolutePath + "?name={0}&startdate={1}&enddate={2}", txtName.Text.Trim(), txtStartDate.Text, txtEndDate.Text);
            Response.Redirect(url);
        }
    }
}