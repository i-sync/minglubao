using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;

namespace Web.Enterprise.Config
{
    public partial class TeamModify : MLMGC.Security.EnterprisePage
    {
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            E_Team data = new E_Team();
            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;
            data = new T_Team().GetModel(data);
            if (data == null)
                return;
            txtTeamName.Text = data.TeamName;
            txtSignature.Text = data.Signature;
        }

        /// <summary>
        /// 点击确定按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string teamName = txtTeamName.Text;
            string signature = txtSignature.Text;
            if (teamName == "")
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入团队名称！", this);
                return;
            }
            else if (signature == "")
            { 
                MLMGC.COMP.Jscript.ShowMsg("请输入团队口号！", this);
                return;
            }
            E_Team data = new E_Team();
            data.EnterpriseID = EnterpriceID;
            data.TeamID = TeamID;
            data.TeamName = teamName;
            data.Signature = signature;
            bool flag = new T_Team().Update(data);
            if (flag)
            {
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "修改团队信息", IP = MLMGC.COMP.Requests.GetRealIP() });
                MLMGC.COMP.Jscript.ShowMsg("修改成功", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("修改失败", this);
            }
        }
    }
}