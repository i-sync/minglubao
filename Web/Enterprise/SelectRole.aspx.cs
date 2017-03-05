using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;
using MLMGC.COMP;

namespace Web.Enterprise
{
    public partial class SelectRole : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }
        protected void databind()
        {
            int teamid = Requests.GetQueryInt("teamid", 0);
            int epuid = Requests.GetQueryInt("epuid", 0);
            int roleid = Requests.GetQueryInt("roleid", 0);
            if (teamid > 0 && epuid > 0)
            {
                setSession(UserID, UserName, Password, EnterpriceID, epuid, teamid,roleid);
                Response.Redirect("/enterprise/index.html");
            }
            //判断用户是否为多角色信息
            E_EnterpriseUser data = new E_EnterpriseUser();
            data.UserID = UserID;
            data.EnterpriseID = EnterpriceID;
            data.EPUserTMRID = 0;
            DataTable dt = new T_User().GetUserSelectRole(data);
            if (dt.Rows.Count<1)
            {
                MLMGC.COMP.Jscript.AlertAndRedirect(this, "无对应角色，请联系管理员", "../");
                LoginOut();
                return;
            }
            else if (dt.Rows.Count == 1)
            {
                setSession(UserID, UserName, Password, EnterpriceID, Convert.ToInt32(dt.Rows[0]["EPUserTMRID"]), Convert.ToInt32(dt.Rows[0]["TeamID"]),Convert.ToInt32(dt.Rows[0]["RoleID"]));
                Response.Redirect("/enterprise/index.html");
            }
            else
            {
                rpList.DataSource = dt;
                rpList.DataBind();
            }
        }
    }
}