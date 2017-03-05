using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.User;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.User;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.weibo
{
    public partial class My : MLMGC.Security.EnterprisePage
    {
        int pagesize = 30, pageindex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Requests.GetQueryInt("page", 1);
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
            //获取该用户的基本信息
            E_User dataEP = new E_User();
            dataEP.EnterpriseID = EnterpriceID;
            dataEP.UserID = UserID;
            dataEP = new T_User().GetEPModel(dataEP);
            if (dataEP == null)
            {
                Response.Redirect("../main.aspx");
            }
            ltName.Text = dataEP.TrueName;
            imgAvatar.ImageUrl = MLMGC.COMP.Config.GetEnterpriseAvatarUrl(dataEP.Avatar);

            //获取该用户自己发布的微博列表
            E_Weibo data = new E_Weibo();
            data.EnterpriseID = EnterpriceID;
            data.UserID = UserID;
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = pageindex;
            data.Page.PageSize = pagesize;
            rpList.DataSource = new T_Weibo().SelfList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pagesize;
            pageList1.CurrentPageIndex = pageindex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有 <span class='red_font'>{0}</span> 条微博", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";

        }
    }
}