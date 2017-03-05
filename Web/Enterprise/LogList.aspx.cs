using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.COMP;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise
{
    public partial class LogList : MLMGC.Security.EnterprisePage
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
        /// 数据绑定
        /// </summary>
        protected void databind()
        { 
            //------绑定用户列表------           
            E_User data = new E_User();
            data.EnterpriseID = EnterpriceID;
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = 1;
            data.Page.PageSize = 1000;
            DataTable dt = new T_User().GetEPList(data).Tables[0];
            ddlObject.Items.Add(new ListItem("", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddlObject.Items.Add(new ListItem(string.Format("{0}", dr["TrueName"]), dr["UserID"].ToString()));
            }

            //---------绑定数据列表-----------
            string start = Requests.GetQueryString("start");
            string end = Requests.GetQueryString("end");
            int userid = Requests.GetQueryInt("userid",0);
            ddlObject.SelectedValue = userid.ToString();
            E_Log log = new E_Log();
            log.EnterpriseID = EnterpriceID;
            log.UserID = userid;
            log.Page = new MLMGC.DataEntity.E_Page();
            log.Page.PageIndex = pageIndex;
            log.Page.PageSize = pageSize;
            if (start != "")
            {
                log.Page.StartDate = Convert.ToDateTime(start);
                txtStartDate.Text = start;
            }
            if (end != "")
            {
                log.Page.EndDate = Convert.ToDateTime(end);
                txtEndDate.Text = end;
            }
            DataTable dtList = new T_Log().GetList(log);
            rpList.DataSource = dtList;
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = log.Page.TotalCount;
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
            string url = string.Format(Request.Url.AbsolutePath + "?userid={0}&start={1}&end={2}", ddlObject.SelectedValue, txtStartDate.Text, txtEndDate.Text);
            Response.Redirect(url);
        }

        /// <summary>
        /// 清空三个月之前的日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>0:删除所有日志,1:删除三月之前的日志</remarks>
        protected void btnClearPart_Click(object sender, EventArgs e)
        {
            Delete(1);
        }

        /// <summary>
        /// 清空所有日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>0:删除所有日志,1:删除三月之前的日志</remarks>
        protected void btnClearAll_Click(object sender, EventArgs e)
        {            
            Delete(0);
        }

        protected void Delete(int type)
        {
            E_Log data = new E_Log();
            data.EnterpriseID = EnterpriceID;
            data.Type = type;
            bool flag = new T_Log().Delete(data);
            if (flag)
            {
                Jscript.AlertAndRedirect(this, "删除成功", "LogList.aspx");
            }
            else
            {
                Jscript.ShowMsg("删除失败", this);
            }
        }
    }
}