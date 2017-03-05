using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise.Config
{
    public partial class TeamModelSetUp : MLMGC.Security.EnterprisePage
    {
        /// <summary>
        /// 团队模型编号
        /// </summary>
        protected int teammodeid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            T_TeamModel blltm = new T_TeamModel();
            //获取企业购买用户数量
            int userAmount = (int)new MLMGC.BLL.Enterprise.T_Enterprise().Get(new MLMGC.DataEntity.Enterprise.E_Enterprise() { EnterpriseID = base.EnterpriceID }).UserAmount;
            ltUserAmount.Text = userAmount.ToString();
            //获取团队模型数据
            DataSet ds = blltm.GetList();
            if (ds != null)
            {
                int LeastUserAmount = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    RadioButton rb = (RadioButton)Page.FindControl("rbModel" + dr["TeamModelID"].ToString());
                    if (rb == null) { continue; }
                    rb.Text = dr["TeamModelName"].ToString();
                    //li.Value = dr["TeamModelID"].ToString();
                    LeastUserAmount = int.Parse(dr["LeastUserAmount"].ToString());
                    rb.Enabled = userAmount > LeastUserAmount;
                }
            }
            //绑定用户设置信息
            E_TeamModel data = blltm.GetTeamScale(new E_TeamModel() { EnterpriseID = base.EnterpriceID });
            if (data != null)
            {
                teammodeid = data.TeamModelID;
                switch (data.TeamModelID)
                {
                    case 2:
                        rbModel2.Checked = true;
                        LtSelectModel.Text = "已经选择模型：<b style=\" color:Red;\">" + rbModel2.Text + "</b>";
                        break;
                    case 3:
                        rbModel3.Checked = true;
                        LtSelectModel.Text = "已经选择模型：<b style=\" color:Red;\">" + rbModel3.Text + "</b>";
                        break;
                    case 4:
                        rbModel4.Checked = true;
                        LtSelectModel.Text = "已经选择模型：<b style=\" color:Red;\">" + rbModel4.Text + "</b>";
                        break;
                    default:
                        break;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!rbModel2.Checked && !rbModel3.Checked && !rbModel4.Checked)
            {
                MLMGC.COMP.Jscript.ShowMsg("请选择模型", this);
                return;
            }

            int oldmodelid = 0;
            //获取旧团队模型
            //绑定用户设置信息
            E_TeamModel data = new T_TeamModel().GetTeamScale(new E_TeamModel() { EnterpriseID = base.EnterpriceID });
            if (data != null)
            {
                oldmodelid = data.TeamModelID;
            }

            int modelid = rbModel2.Checked ? 2 : (rbModel3.Checked ? 3 : 4);
            //如果新的团队模型与旧团队模型相同，则直接跳转界面
            if (modelid != 2 && oldmodelid == modelid)
            {
                Response.Redirect("TeamSetUp1.aspx");
            }
            int result = new T_TeamModel().SetTeamModel(new E_TeamModel() { EnterpriseID = this.EnterpriceID, TeamModelID = modelid });
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "修改企业团队模型", IP = MLMGC.COMP.Requests.GetRealIP() });
            if (result == -1)
                MLMGC.COMP.Jscript.ShowMsg("请取消现有模型中在新模型中不存在的角色", this);
            else if (result == -2)
            {
                MLMGC.COMP.Jscript.ShowMsg("现有团队中存在失败，报废或潜在名录，请操作后再修改", this);
            }
            else if (result > 0)
            {
                //判断当前设置的是否为3级或4级，若是则跳转到下一界面
                if (modelid == 3 || modelid == 4)
                {
                    Response.Redirect("TeamSetUp1.aspx");
                }
                else if (modelid == 2)
                {
                    Response.Redirect("TeamSetUp2.aspx");
                }
                else
                {
                    MLMGC.COMP.Jscript.ShowMsg("修改成功", this);
                }
            }
            else
                MLMGC.COMP.Jscript.ShowMsg("设置模型失败", this);
        }
    }
}