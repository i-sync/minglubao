using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Personal.Material;
using MLMGC.DataEntity.Personal.Material;

namespace Web.Personal.Material
{
    public partial class TalkList :MLMGC.Security.PersonalPage
    {
        protected int max;
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["actionname"] ?? string.Empty;
            if (type.ToLower() == "delete")
            {
                int talkID = MLMGC.COMP.Requests.GetQueryInt("talkid",0);
                Delete(talkID);
            }
            if (!IsPostBack)
            {
                databind();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind()
        {
            E_Talk data = new E_Talk();
            data.PersonalID = PersonalID;
            
            DataTable dt = new T_Talk().GetList(data);
            object o = dt.Compute("Max(Sort)", "true");
            max = Convert.ToInt32(o == DBNull.Value ? "0" : o);
            rpList.DataSource = dt;
            rpList.DataBind();
        }

        /// <summary>
        /// 删除话术
        /// </summary>
        /// <param name="talkID"></param>
        public void Delete(int talkID)
        {
            E_Talk data = new E_Talk();
            data.TalkID = talkID;
            data.PersonalID = PersonalID;
            bool flag = new T_Talk().Delete(data);
            if (flag)
            {
                MLMGC.COMP.Jscript.ShowMsg("删除成功", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("删除失败", this);
            }
        }
    }
}