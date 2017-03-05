using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.DataEntity;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;
using System.Configuration;

namespace Web.Personal.Avatar
{
    public partial class Avatar : MLMGC.Security.PersonalPage
    {
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
            E_Personal data = new E_Personal();
            data.PersonalID = PersonalID;
            data.UserID = UserID;
            data = new T_Personal().GetModel(data);
            if (data != null)
            {
                string url = data.Avatar == "" ? "/images/guanliyuan.jpg" : MLMGC.COMP.Config.GetPersonalAvatarUrl(data.Avatar);
                imgAvatar.ImageUrl = url;
            }
        }

        /// <summary>
        /// 提交头像处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdUrl.Value == "")
            {
                MLMGC.COMP.Jscript.ShowMsg("请选择头像", this);
                return;
            }
            E_Personal data = new E_Personal();

            data.PersonalID = PersonalID;
            data.UserID = UserID;
            data.Avatar = hdUrl.Value.Substring(hdUrl.Value.LastIndexOf("/") + 1);

            bool flag = new T_Personal().UpdateAvatar(data);
            if (flag)
            {
                //new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "修改头像", IP = MLMGC.COMP.Requests.GetRealIP() });
                MLMGC.COMP.Jscript.AlertAndRedirect(this,"修改成功","Avatar.aspx");
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("修改失败", this);
            }
        }
    }
}