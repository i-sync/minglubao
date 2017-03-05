using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Personal;
using MLMGC.DataEntity.Personal;
using MLMGC.DataEntity;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;
using MLMGC.BLL.Public;
using MLMGC.DataEntity.Public;

namespace Web.Personal.Weibo
{
    public partial class Index : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

            //获取最新的n条公告信息
            rpListAnn.DataSource = new T_Announcement().GetNewList(new E_Announcement() { Count = 15 });
            rpListAnn.DataBind();
        }
    }
}