using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.User;

namespace Web.Personal
{
    public partial class Default : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }
        /// <summary>
        /// 初始化页面数据
        /// </summary>
        protected void databind()
        {
            E_Personal data = new E_Personal();
            data.UserID = UserID;
            data.PersonalID = PersonalID;
            data = new MLMGC.BLL.User.T_Personal().GetModel(data);
            if (data == null) { return; }
            ltName.Text = data.RealName;
            ltLoginName.Text = UserName;
            ltMobile.Text = data.Mobile;

            //头像
            imgAvatar.ImageUrl = MLMGC.COMP.Config.GetPersonalAvatarUrl(data.Avatar);
        }
    }
}