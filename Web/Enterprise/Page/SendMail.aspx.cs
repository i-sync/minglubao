using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;
using MLMGC.DataEntity.Enterprise.Material;
using System.Data;

namespace Web.Enterprise.Page
{
    public partial class SendMail : MLMGC.Security.EnterprisePage
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
            string type = Requests.GetQueryString("type");
            string ids = Requests.GetQueryString("ids");
            //显示邮件配置信息
            E_MailConfig data = new T_MailConfig().GetConfig(new E_MailConfig()
            {
                EnterpriseID = base.EnterpriceID,
                UserID = UserID
            });
            if (data == null)
            {
                //隐藏发送邮件信息
                plSend.Visible = false;
                return;
            }
            else
            {
                //隐藏配置信息
                plConfig.Visible = false;
                lbSendUser.Text = data.Name;
                lbSendUser.ToolTip = "发送邮箱：" + data.Email;
            }
            //----------------读取邮件地址----------------
            if (StringUtil.IsStringArrayList(ids))
            {
                DataTable dt = new T_ClientInfoHelper().SelectOperate(new E_ClientInfoHelper() {EnterpriseID=EnterpriceID,ClientInfoIDs=ids });
                List<string> listEmail = new List<string>();
                List<string> listErr = new List<string>();
                //--遍历取出邮箱地址
                foreach (DataRow dr in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["Email"].ToString()))
                    {
                        listEmail.Add(dr["Email"].ToString());
                    }
                    else
                    {
                        listErr.Add(dr["ClientName"].ToString());
                    }
                }
                txtReceiveEmail.Text = string.Join(",", listEmail.ToArray());
                if (listErr.Count > 0)
                {
                    lbErrClient.Text = "部分客户无邮箱地址无法发送邮件";// +string.Join(",", listErr);
                }
            }
            //----------------显示项目资料信息----------------
            E_Material dataM = new E_Material();
            dataM.EnterpriseID = EnterpriceID;
            dataM.Page = new MLMGC.DataEntity.E_Page();
            dataM.Page.PageSize = 0;
            dataM.Page.PageIndex = 1;

            rpList.DataSource = new MLMGC.BLL.Enterprise.Material.T_Material().GetList(dataM);
            rpList.DataBind();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            //验证数据是否正确
            string email = txtReceiveEmail.Text.Trim();
            string subject=txtSubject.Text.Trim();
            string content = txtContent.Text.Trim();
            //if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(subject))
            //{
            //    Jscript.ShowMsg("请", this);
            //}
            //显示邮件配置信息
            E_MailConfig data = new T_MailConfig().GetConfig(new E_MailConfig()
            {
                EnterpriseID = base.EnterpriceID,
                UserID = UserID
            });
            if (data == null)
            {
                Jscript.ShowMsg("读取配置失败", this);
                return;
            }
            //处理附件地址
            string[] listAtt=hdAttachment.Value.Split(',');
            for(int i=0;i<listAtt.Length;i++)
            {
                listAtt[i] = MLMGC.COMP.Config.GetEnterpriseM(EnterpriceID,listAtt[i]);
            }

            MLMGC.Controls.SendMail SM = new MLMGC.Controls.SendMail(data.Email, data.SMTP,data.Port, data.UserName, data.Password, data.Name,listAtt.ToList());
            string errorMessage = string.Empty ;
            string[] eArray = email.Split(',');
            bool flag = true;
            foreach (string s in eArray)
            {
                flag = flag && SM.Send(s, subject, content, out errorMessage);
            }
            //添加操作日志
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "发送电子邮件", IP = MLMGC.COMP.Requests.GetRealIP() });
            Jscript.ShowMsg("发送" + (flag ? "成功" : "失败"+ errorMessage), this);
        }
    }
}