using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using MLMGC.COMP;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using System.Text;

namespace Web.Enterprise.Config
{
    public partial class TeamSetUp1 : MLMGC.Security.EnterprisePage
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
            //获取企业购买用户数量
            int userAmount = (int)new MLMGC.BLL.Enterprise.T_Enterprise().Get(new MLMGC.DataEntity.Enterprise.E_Enterprise() { EnterpriseID = base.EnterpriceID }).UserAmount;
            ltUserAmount.Text = userAmount.ToString();

            T_TeamModel blltm = new T_TeamModel();
            E_TeamModel data = blltm.GetTeamScale(new E_TeamModel() { EnterpriseID = base.EnterpriceID });
            if (data == null)
            {
                Jscript.AlertAndRedirect(this, "请先设置团队模型", "TeamModelSetUp.aspx");
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data.TeamScaleXml);
            XmlNodeList root = doc.SelectNodes("root/item");
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            foreach (XmlNode n in root)//遍历所有property节点
            {
                if (n.Attributes["roleID"].Value.Equals("6"))//录入人员
                {
                    continue;
                }
                //dt.Columns.Add(n.Attributes["key"].Value);
                sb.Append(string.Format("<tr><td  class='name'>{0}：</td>", n.ChildNodes[0].InnerText));//增加名称
                if (n.Attributes["readonly"].Value == "true")//显示数量不修改
                {
                    sb.Append("<td>" + n.ChildNodes[1].InnerText + "个</td>");
                }
                else//否则为输入框供管理员修改部门数量
                {
                    sb.Append(string.Format("<td><input type='text' name='txtAmount{1}' class='inputAmount txt1 w50' value='{0}'/>个</td>", n.ChildNodes[1].InnerText, n.Attributes["roleID"].Value));
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            LtSetting.Text = sb.ToString();
            btnSubmit.Visible = root.Count > 2;
                        
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            T_TeamModel blltm = new T_TeamModel();
            E_TeamModel data = blltm.GetTeamScale(new E_TeamModel() { EnterpriseID = base.EnterpriceID });
            if (data == null)
            {
                Jscript.AlertAndRedirect(this, "请先设置团队模型", "TeamModelSetUp.aspx");
                return;
            }
            int teammodeid = data.TeamModelID;

            List<string> aryRole = new List<string>();
            List<string> aryAmount = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data.TeamScaleXml);
            XmlNodeList root = doc.SelectNodes("root/item[@readonly='false']");
            bool bCheck = true;
            int num = 0;
            foreach (XmlNode n in root)//遍历所有property节点
            {
                aryRole.Add(n.Attributes["roleID"].Value);
                aryAmount.Add(Request.Form["txtAmount" + n.Attributes["roleID"].Value].ToString());
                if (int.TryParse(Request.Form["txtAmount" + n.Attributes["roleID"].Value].ToString(), out num) && num>0)
                {
                    n.ChildNodes[1].InnerText = num.ToString();
                }
                else
                    bCheck = false;
            }
            if (!bCheck)
            {
                Jscript.ShowMsg("请输入正确的数据", this);
                return;
            }

            //重新赋值
            data.EnterpriseID = EnterpriceID;
            data.TeamScaleXml = doc.InnerXml;
            data.Child_RoleID = string.Join(",", aryRole.ToArray());
            data.Child_RoleAmount = string.Join(",", aryAmount.ToArray());
            int i = blltm.UpdateTeamScale(data);
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "设置团队规模", IP = MLMGC.COMP.Requests.GetRealIP() });
            switch (i)
            {
                case 1:
                    Response.Redirect("TeamSetUp2.aspx");
                    break;
                case -1:
                    Jscript.ShowMsg("请先清空需要删除的团队中的数据。", this);
                    break;
                default:
                    Jscript.ShowMsg("修改失败", this);
                    break;
            }
        }
    }
}