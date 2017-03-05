using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise.Data
{
    public partial class Recycled : MLMGC.Security.EnterprisePage
    {
        int pageSize = 30, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            E_ClientInfo data = new E_ClientInfo();
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

            rpList.DataSource = new T_ClientInfoHelper().LeaderDeleteSelect(data);
            rpList.DataBind();
            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 还原到共享池处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRestore_Click(object sender, EventArgs e)
        {
            string ciids = hdClientInfoIDs.Value;
            hdClientInfoIDs.Value = "";
            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ciids))//判断格式是否正确 格式：1,21,321
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_ClientInfo data = new E_ClientInfo();
            data.EnterpriseID = EnterpriceID;
            data.Mode = EnumClientMode.共享;
            data.Status = EnumClientStatus.共享;
            data.EPUserTMRID = EPUserTMRID;
            data.ClientInfoIDs = ciids;

            bool flag = new T_ClientInfoHelper().LeaderRestore(data);
            if (flag)
            {
                Jscript.AlertAndRedirect(this, "还原成功", "Recycled.aspx");
            }
            else
            {
                Jscript.ShowMsg("还原失败", this);
            }
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
            E_ClientInfoHelper data = new E_ClientInfoHelper();
            data.EnterpriseID = EnterpriceID;
            data.ClientInfoIDs = ciids;

            bool flag = new T_ClientInfoHelper().LeaderThoroughDelete(data);
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
            string url = string.Format(Request.Url.AbsolutePath + "?name={0}&startdate={1}&enddate={2}", txtName.Text.Trim(),txtStartDate.Text,txtEndDate.Text);
            Response.Redirect(url);
        }
    }
}