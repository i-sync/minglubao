using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Public;
using MLMGC.BLL.Public;

namespace WebAdmin.Public
{
    public partial class AnnEdit : System.Web.UI.Page
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
        public void databind()
        {
            int aid = MLMGC.COMP.Requests.GetQueryInt("aid", 0);
            E_Announcement data = new T_Announcement().GetModel(new E_Announcement() { AnnouncementID = aid });
            if (data != null)
            {
                txtAnnTitle.Text = data.AnnTitle;
                txtAnnContent.Content = data.AnnContent;
            }
        }

        /// <summary>
        /// 点击确定按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = txtAnnTitle.Text;
            string content = txtAnnContent.Content;
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                MLMGC.COMP.Jscript.ShowMsg("请认真填写以上内容", this);
                return;
            }
            int aid = MLMGC.COMP.Requests.GetQueryInt("aid", 0);

            E_Announcement data = new E_Announcement();
            data.AnnouncementID = aid;
            data.AnnTitle = title;
            data.AnnContent = content;
            bool flag = new T_Announcement().Update(data);
            if (flag)
            {
                MLMGC.COMP.Jscript.AlertAndRedirect(this, "操作成功", "AnnList.aspx");
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("操作失败", this);
            }
        }
    }
}