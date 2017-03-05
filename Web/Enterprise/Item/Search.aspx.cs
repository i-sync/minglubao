using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;
using MLMGC.COMP;
using System.Data;

namespace Web.Enterprise.Item
{
    public partial class Search : MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = Requests.GetQueryInt("page", 1);
            //判断是否有权限操作
            isPermission();
            if (!IsPostBack) { databind(); }
        }


        /// <summary>
        /// 页面初始化加载数据
        /// </summary>
        protected void databind()
        {
            //绑定名录状态
            EnumUtil.BindList<MLMGC.DataEntity.Item.EnumClientStatus>(rbStatus);
            rbStatus.Items.RemoveAt(0);//删除待分配
            rbStatus.Items.RemoveAt(rbStatus.Items.Count - 2);//删除共享
            rbStatus.SelectedIndex = rbStatus.Items.Count - 1;//默认所有状态选中

            E_ItemClientInfo data = new E_ItemClientInfo();
            data.EnterpriseID = EnterpriceID;

            data.ClientName = Requests.GetQueryString("name");
            txtName.Text = data.ClientName;

            data.SetStatus = Requests.GetQueryInt("status", 0);
            rbStatus.SelectedValue = ((int)data.Status).ToString();

            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            DataTable dt = new T_ItemClientInfo().LeaderList(data);
            if (dt != null && dt.Rows.Count > 0)//判断是否有数据返回
            {
                //绑定列表
                rpList.DataSource = dt;
                rpList.DataBind();
            }

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }
    }
}