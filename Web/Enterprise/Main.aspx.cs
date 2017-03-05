using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Enterprise;
using MLMGC.BLL.User;
using MLMGC.DataEntity.Enterprise;
using MLMGC.DataEntity.User;
using MLMGC.BLL.Enterprise.Announcement;
using MLMGC.DataEntity.Enterprise.Announcement;

namespace Web.Enterprise
{
    public partial class Main : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            //获取企业用户列表
            E_User dataU = new E_User();
            dataU.EnterpriseID = EnterpriceID;
            dataU.Page.PageIndex = 1;
            dataU.Page.PageSize = 100;

            //获取自身及所有上级的最新公告
            rpListAnn.DataSource = new T_Announcement().GetNewList(new E_Announcement { EnterpriseID = EnterpriceID, TeamID = TeamID });
            rpListAnn.DataBind();

            rpList.DataSource = new T_User().GetEPList(dataU);
            rpList.DataBind();

            ////得到最新公告
            //E_Announcement data = new E_Announcement();
            //data.EnterpriseID = EnterpriceID;
            //data.TeamID = TeamID;
            //data.AnnouncementID = -1;
            //data = new T_Announcement().GetModel(data);
            //if (data != null)
            //{
            //    ltAnn.Text = string.Format("【{0}】{1}", data.AddDate.ToString("yyyy-MM-dd HH:mm"), data.AnnContent);
            //}
            //---微博
            rpListWeibo.DataSource = new T_Weibo().GetMainList(new E_Weibo() { EnterpriseID = EnterpriceID });
            rpListWeibo.DataBind();
        }
    }
}