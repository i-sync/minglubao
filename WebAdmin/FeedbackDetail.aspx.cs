using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL;
using MLMGC.COMP;
using MLMGC.DataEntity;

namespace WebAdmin
{
    public partial class FeedbackDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Requests.GetQueryInt("id", 0);
            if (!IsPostBack)
            {
                databind(id);
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        protected void databind(int id)
        {
            E_Feedback data = new E_Feedback();
            data.FeedbackID = id;
            data = new T_Feedback().GetModel(data);
            if (data == null)
                return;
            lblSubject.Text = data.Subject;
            lblDetail.Text = data.Detail;
            lblAddDate.Text = data.AddDate.ToString("yyyy-MM-dd HH:mm");
            //判断是否有附件
            if (string.IsNullOrWhiteSpace(data.Url))
            {
                imgFile.ImageUrl = data.Url;
            }
        }
    }
}