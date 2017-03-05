using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;

namespace Web.Enterprise
{
    public partial class Navigator : MLMGC.Security.EnterprisePage
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

            E_EnterpriseUser data = new E_EnterpriseUser();
            data.UserID = UserID;
            data.EnterpriseID = EnterpriceID;
            data.EPUserTMRID = EPUserTMRID;

            DataTable dt = new T_User().GetUserSelectRole(data);
            if (dt != null && dt.Rows.Count >= 1)
            {                 
                //var v = from a in dt.Rows where a["EPUserTMRID"] = EPUserTMRID select new { Team=a["TeamName"],Role=a["RoleName"]};
                DataRow [] dr = dt.Select("EPUserTMRID =" + EPUserTMRID);
                if (dr.Length > 0)
                {
                    //ltCurRole.Text = dr[0]["RoleName"].ToString();
                    //ltCurTeam.Text = dr[0]["TeamName"].ToString();

                    hlRole.Text = dr[0]["RoleName"].ToString();
                }
                hlRole.NavigateUrl = dt.Rows.Count > 1 ? "selectrole.aspx" : "javascript:void(0);";
                //DataRow[] rows = dt.Select("EPUserTMRID <>" + EPUserTMRID);
                //var v = from a in rows select new { TeamName = a["TeamName"], RoleName = a["RoleName"], TeamID = a["TeamID"], EPUserTMRID = a["EPUserTMRID"], RoleID = a["RoleID"] };
                //rpRole.DataSource = v;
                //rpRole.DataBind();
            }

            //获取企业基本信息
            E_Enterprise dataEP = new E_Enterprise { EnterpriseID = EnterpriceID };
            dataEP = new T_Enterprise().Get(dataEP);
            if (dataEP != null)
            {
                epName.Text = dataEP.EnterpriseNames;
                epLinkman.Text = dataEP.Linkman;
                epTel.Text = dataEP.Tel;
                epItemName.Text = dataEP.ItemName ?? "";
            }
        }
    }
}