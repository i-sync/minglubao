using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Enterprise.Announcement;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise.Announcement;
using MLMGC.DataEntity.User;

namespace Web.Enterprise.Announcement
{
    public partial class AnnouncementEdit : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 点击确定按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        { 
            //获取界面数据
            string annTitle = txtAnnTitle.Text;
            string annContent = txtAnnContent.Content;
            if (annTitle == "" && annContent == "")
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入公告标题和内容", this);
                return;
            }
            else if (annTitle == "")
            { 
                MLMGC.COMP.Jscript.ShowMsg("请输入公告标题和内容", this);
                return;
            }
            else if (annContent == "")
            { 
                MLMGC.COMP.Jscript.ShowMsg("请输入公告标题和内容", this);
                return;
            }

            //首先根据EPUserTMRID获取TeamID
            E_User user = new E_User();
            user.EnterpriseID = EnterpriceID;
            user.EPUserTMRID = EPUserTMRID;
            DataTable dt = new T_Team().GetTeamID(user);
            if (dt == null || dt.Rows.Count != 1)
                return;
            int teamID = Convert.ToInt32(dt.Rows[0]["TeamID"]);

            //添加公告
            E_Announcement data = new E_Announcement();
            data.EnterpriseID = EnterpriceID;
            data.TeamID = teamID;
            data.AnnTitle = annTitle;
            data.AnnContent = annContent;
            bool flag = new T_Announcement().Add(data);
            if (flag)
            {
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "添加公告", IP = MLMGC.COMP.Requests.GetRealIP() });
                MLMGC.COMP.Jscript.AlertAndRedirect(this, "添加成功", "AnnouncementList.aspx");
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("添加失败", this);
            }
        }
    }
}