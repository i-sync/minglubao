using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using MLMGC.DataEntity.Enterprise.Material;
using MLMGC.BLL.Enterprise.Material;
using MLMGC.COMP;

namespace Web.Enterprise.Material
{
    public partial class TalkEdit : MLMGC.Security.EnterprisePage
    {
        string type = string .Empty ;
        protected void Page_Load(object sender, EventArgs e)
        {
            //type = Request.QueryString["type"] ?? string.Empty;       
            type = Requests.GetQueryString("type").ToLower();
            if (type == "update" && !IsPostBack)
            {
                //int talkID = Convert .ToInt32 (Request .QueryString ["TalkID"]);
                int talkID = Requests.GetQueryInt("talkid", 0);
                databind(talkID);
            }
            //tian jia
            else if(type == "add" && !IsPostBack)
            {
                int sort = Requests.GetQueryInt("max", 0);
                txtSort.Text = sort.ToString();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="talkID"></param>
        protected void databind(int talkID)
        { 
            E_Talk data = new E_Talk();
            data.TalkID = talkID ;
            data.EnterpriseID =EnterpriceID;
            data = new T_Talk().GetModel (data);
            txtTalkSubject.Text = data.TalkSubject;
            txtTalkDetail.Content= data .Detail;
            txtSort.Text = data.Sort.ToString();
        }

        /// <summary>
        /// 点击确定按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        { 
            //获取界面数据并验证
            string subject = txtTalkSubject.Text;
            string detail = txtTalkDetail.Content;
            if (subject == "")
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入标题", this);
                return;
            }
            else if (detail == "")
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入内容", this);
                return;
            }
            E_Talk data = new E_Talk();
            data.EnterpriseID = EnterpriceID;            
            data.TalkSubject = txtTalkSubject.Text;
            data.Detail = txtTalkDetail.Content;
            data.Sort = Convert.ToInt32(txtSort.Text);

            if (type == "add")
            {                
                bool flag = new T_Talk().Add(data);
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "添加话术", IP = MLMGC.COMP.Requests.GetRealIP() });
                if (flag)
                {
                    MLMGC.COMP.Jscript.AlertAndRedirect(this, "添加成功", "TalkList.aspx");
                }
                else
                {
                    MLMGC.COMP.Jscript.ShowMsg("添加失败", this);
                }
            }
            else
            {
                //data.TalkID = Convert.ToInt32(Request.QueryString["TalkID"]);
                data.TalkID = MLMGC.COMP.Requests.GetQueryInt("talkid", 0);
                bool flag = new T_Talk().Update(data);
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "修改话术", IP = MLMGC.COMP.Requests.GetRealIP() });
                if (flag)
                {
                    MLMGC.COMP.Jscript.AlertAndRedirect(this, "修改成功", "TalkList.aspx");
                }
                else
                {
                    MLMGC.COMP.Jscript.ShowMsg("修改失败", this);
                }
            }
        }
    }
}