using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.COMP;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;
using System.Web.UI.HtmlControls;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;

namespace Web.Enterprise.User
{
    public partial class UserEdit : MLMGC.Security.EnterprisePage
    {
        protected string type = string.Empty;
        int num = 0, count = 0;
        protected int userid;
        T_Team bllTeam = new T_Team();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = MLMGC.COMP.Requests.GetQueryString("type");
            userid = MLMGC.COMP.Requests.GetQueryInt("uid", 0);
            if (!IsPostBack) 
            {
                DataBindInfo();
                if (type == "update")
                {
                    databind();
                }
            }
        }

        protected void DataBindInfo()
        { 
            //---------获取企业购买用户数量及使用数量
            DataTable dtUser = new T_User().GetEPUserCount(new E_User { EnterpriseID = EnterpriceID });
            if (dtUser != null && dtUser.Rows.Count == 1)
            {
                num = Convert.ToInt32(dtUser.Rows[0]["Num"]);
                count = Convert.ToInt32(dtUser.Rows[0]["Count"]);
                liNum.Text = num.ToString();
                liCount.Text = count.ToString();
            }
            if (num >= count)
            {
                txtPassword.Enabled = false;
                txtTrueName.Enabled = false;
                txtUserName.Enabled = false;
                btnSubmit.Enabled = false;
            }
            dt = new T_User().GetTeamUserRole(new E_User() { EnterpriseID = EnterpriceID, UserID = userid });
            DataSet ds = new T_TeamModel().GetEnterpriseRole(new E_TeamModel() { EnterpriseID = EnterpriceID });
            rpList.DataSource = ds;
            rpList.DataBind();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind()
        {            
            
            E_User data = new E_User();
            data.EnterpriseID = EnterpriceID;
            data.UserID = userid;
            data = new T_User().GetEPModel(data);
            if (data != null)
            {
                txtUserName.Text = data.UserName;
                //txtPassword.Text = data.Password;
                txtTrueName.Text = data.TrueName;
            }
            else
            {
                MLMGC.COMP.Jscript.AlertAndRedirect(this, "用户不存在", "userlist.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            E_User data = new E_User();
            T_User bll = new T_User();
            //检测数据合法
            if (!string.IsNullOrEmpty(hdRoleInfo.Value) && !new System.Text.RegularExpressions.Regex("^\\d+:\\d+(,\\d+:\\d+)*$").IsMatch(hdRoleInfo.Value))
            {
                MLMGC.COMP.Jscript.ShowMsg("数据错误，无法完成操作", this);
                return;
            }
            data.UserName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (type == "add" && string.IsNullOrEmpty(password))
            {
                MLMGC.COMP.Jscript.ShowMsg("您第一次操作，请输入密码！", this);
                return;
            }
            data.Password = string.IsNullOrEmpty(password)?"":MLMGC.COMP.EncryptString.EncryptPassword( password);
            data.UserType = (int)UserType.企业用户;
            data.EnterpriseID = EnterpriceID;
            data.TrueName = txtTrueName.Text.Trim();
            data.UserID = userid;
            data.RoleSetting = hdRoleInfo.Value;
            int result=bll.AddEnterpriseUser(data);
            if (result>=1)
            {
                //添加操作日志
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "管理员添加企业用户", IP = MLMGC.COMP.Requests.GetRealIP() });
                MLMGC.COMP.Jscript.AlertAndRedirect(this, "保存成功","userlist.aspx");
            }
            else if (result == -2)
            {
                MLMGC.COMP.Jscript.ShowMsg("您选择的角色已经有相关人员，请去掉该角色之前的相关人员", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("操作失败", this);
            }
        }

        protected void rpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                int teammodelrole = int.Parse(drv["TeamModelRoleID"].ToString());
                RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rblTeam");
                HtmlInputCheckBox hicb = (HtmlInputCheckBox)e.Item.FindControl("cblRole");
                hicb.Value = teammodelrole.ToString();

                rbl.DataSource = bllTeam.GetListForRole(new E_Team() { EnterpriseID = EnterpriceID, TeamModelRoleID = teammodelrole });
                rbl.DataTextField = "TeamName";
                rbl.DataValueField = "TeamID";
                rbl.DataBind();

                if (dt!=null && dt.Select("TeamModelRoleID=" + teammodelrole).Count() > 0)
                {
                    hicb.Checked = true;
                    rbl.SelectedValue = dt.Select("TeamModelRoleID=" + teammodelrole)[0]["TeamID"].ToString();
                }
                else
                {
                    rbl.Enabled = false;
                }
            }
        }
    }
}