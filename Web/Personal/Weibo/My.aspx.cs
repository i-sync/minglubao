using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.User;
using MLMGC.BLL.Personal;
using MLMGC.BLL.Public;
using MLMGC.DataEntity;
using MLMGC.DataEntity.Personal;
using MLMGC.DataEntity.User;
using MLMGC.DataEntity.Public;

namespace Web.Personal.Weibo
{
    public partial class My : MLMGC.Security.PersonalPage
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

        protected void databind()
        {
            //个人信息
            E_Personal dataPersonal = new E_Personal();
            dataPersonal.UserID = UserID;
            dataPersonal.PersonalID = PersonalID;
            dataPersonal = new T_Personal().GetModel(dataPersonal);
            if (dataPersonal == null)
            {
                Response.Redirect("../main.aspx");
            }
            ltName.Text = dataPersonal.RealName;
            imgAvatar.ImageUrl = MLMGC.COMP.Config.GetPersonalAvatarUrl(dataPersonal.Avatar);
            //微博信息
            T_Weibo bll = new T_Weibo();
            E_Weibo data = new E_Weibo();
            data.PersonalID = PersonalID;
            data.Page = new E_Page();
            data.Page.PageSize = pagesize;
            data.Page.PageIndex = pageindex;
            rpList.DataSource = bll.SelfList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pagesize;
            pageList1.CurrentPageIndex = pageindex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有 <span class='red_font'>{0}</span> 条微博", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";

            //获取最新的n条公告信息
            rpListAnn.DataSource = new T_Announcement().GetNewList(new E_Announcement() { Count = 15 });
            rpListAnn.DataBind();
        }
    }
}