using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Enterprise.Material;
using MLMGC.DataEntity.Enterprise.Material;

namespace Web.Enterprise.Material
{
    public partial class TalkList : MLMGC.Security.EnterprisePage
    {
        protected int max;
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["actionname"]??string.Empty;
            if (type.ToLower () == "delete")
            {
                int talkID = Convert.ToInt32(Request.QueryString["talkid"]);
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
            data.EnterpriseID = EnterpriceID;
            DataTable dt =new T_Talk().GetList(data);
            object o = dt.Compute("Max(Sort)", "true");
            max = Convert.ToInt32(o==DBNull.Value?"0":o);
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
            data.EnterpriseID = EnterpriceID;
            bool flag = new T_Talk().Delete(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "删除话术", IP = MLMGC.COMP.Requests.GetRealIP() });
            if (flag)
            {
                MLMGC.COMP.Jscript.ShowMsg("删除成功",this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("删除失败", this);
            }
        }
    }
}