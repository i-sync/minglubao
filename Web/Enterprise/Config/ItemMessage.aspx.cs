using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.Config
{
    public partial class ItemMessage :MLMGC.Security.EnterprisePage
    {
        private int pageIndex = 1;
        private int pageSize = 20;

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
            E_Item data = new T_Item().GetModel(new E_Item() { EnterpriseID = EnterpriceID });
            if (data != null)
            {
                ltItemName.Text = data.ItemName;
                ltItemIntro.Text = data.ItemIntro;
                ltSignature.Text = data.Signature;
                ltItemContent.Text = data.ItemContent;
                imgPhoto.ImageUrl = MLMGC.COMP.Config.GetEnterpriseItemPhotoUrl(data.Photo);
                ltEstablished.Text = data.Established.ToShortDateString();
                region.RegionID = data.CityID;
            }

            loadMessage();
        }

        /// <summary>
        /// 加载留言信息
        /// </summary>
        protected void loadMessage()
        {
            E_ItemMessage data = new E_ItemMessage();
            data.EnterpriseID = EnterpriceID;
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            rpList.DataSource = new T_ItemMessage().GetList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }
    }
}