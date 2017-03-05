using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.Public;
using MLMGC.BLL.Public;

namespace Web.Ann
{
    public partial class Info : System.Web.UI.Page
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
            int id = MLMGC.COMP.Requests.GetQueryInt("id", 0);
            if (id == 0)
            {
                MLMGC.COMP.Jscript.AlertAndRedirect(this, "信息不存在", "index.aspx");
                return;
            }
            E_Announcement data = new E_Announcement();
            data.AnnouncementID = id;
            data = new T_Announcement().GetModel(data);
            if (data != null)
            {
                ltAnnTitle.Text = data.AnnTitle;
                ltAddDate.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", data.AddDate);
                ltContent.Text = data.AnnContent;
            }
            else
            {
                MLMGC.COMP.Jscript.AlertAndRedirect(this, "信息不存在", "index.aspx");
                return;
            }
        }
    }
}