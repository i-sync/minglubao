using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise.Material;
using MLMGC.BLL.Enterprise.Material;

namespace Web.Enterprise.Material
{
    public partial class LookMaterial : MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = MLMGC.COMP.Requests.GetQueryInt("page", 1);
            if (!IsPostBack)
            {
                databind();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind()
        {
            E_Material data = new E_Material();
            data.EnterpriseID = EnterpriceID;
            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;
            data.MaterialType = EnumMaterialType.项目资料;

            rpList.DataSource = new T_Material().GetList(data);
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