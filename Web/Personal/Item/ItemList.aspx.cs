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

namespace Web.Personal.Item
{
    public partial class ItemList : MLMGC.Security.PersonalPage
    {
        protected int pageIndex = 1;
        protected int pageSize = 20;
        protected int itemid =0;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            //判断该人员是否已经加入了项目
            if (EnterpriseID != 0)
            {
                E_Item item = new T_Item().GetModel(new E_Item() { EnterpriseID = EnterpriseID });
                if (item != null)
                {
                    itemid = item.ItemID;
                    lblStatus.Text = string.Format("您已经加入了<a href=\"iteminfo.aspx?eid={0}&iid={1}&backurl={3}\" >[{2}]</a>,不能在申请其它项目了！",EnterpriseID,item.ItemID,item.ItemName,"itemlist.aspx");
                    btnJump.Visible = true;
                }
            }
            else
            {
                lblStatus.Text = "您还未加入项目，请申请项目！";
            }

            string name = Requests.GetQueryString("name");
            E_Item data = new E_Item();
            data.ItemName = name.Trim();
            txtName.Text = name;
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            DataTable dt = new T_Item().PersonGetList(data);
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
        /// 显示申核状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string Status(object obj)
        {
            return ((ItemStatus)Convert.ToInt32(obj)).ToString();
        }
    }
}