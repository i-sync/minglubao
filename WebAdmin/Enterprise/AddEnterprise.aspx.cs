using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;
using System.Data;

namespace WebAdmin.Enterprise
{
    public partial class AddEnterprise : MLMGC.Security.AdminPage
    {
        string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int enterpriseid = Requests.GetQueryInt("eid", 0);
            type = Requests.GetQueryString("type");
            if (!IsPostBack)
            {
                if (type == "update")
                {
                    databind(enterpriseid);
                }
                else
                {
                    loaddefaultdb();
                }
            }
        }

        /// <summary>
        /// 加载默认数据库基本信息
        /// </summary>
        protected void loaddefaultdb()
        {
            DataTable dt = new T_EnterpriseDB().GetDefault();
            string td = string.Empty;
            if (dt != null && dt.Rows.Count ==1 )
            {
                DataRow row = dt.Rows[0];
                if (Convert.ToInt32(row["EnterpriseNum"]) < Convert.ToInt32(row["MaxNum"]))
                {
                    td = string.Format("<td><span style='color:green;'>您创建的企业数据表将放在[{0}]库中,数据库中当前企业数量：{1},最大数量：{2}。</span></td>", row["DBName"], row["EnterpriseNum"], row["MaxNum"]);
                }
                else
                {
                    td = "<td><span style='color:red;'>目前默认数据库已满，请设更改或创建默认数据库后再操作！</span></td>";
                    btnSubmit.Enabled = false;
                }
            }
            else 
            {
                td = "<td><span style='color:red;'>目前没有默认数据库，您无法创建企业，请设置默认数据库后再操作！</span></td>";
                btnSubmit.Enabled = false;
            }
            string msg = string.Format("<td style='height:50px;' class='title'>提示：</td>{0}",td);
            ltTips.Text = msg;
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="enterpriseid"></param>
        protected void databind(int enterpriseid)
        {
            E_Enterprise data = new E_Enterprise();
            data.EnterpriseID = enterpriseid;
            data = new T_Enterprise().GetModel(data);
            if (data == null)
                return;
            txtEPCode.Enabled = false;
            txtEPCode.Text = data.EnterpriseCode;
            txtEPName.Text = data.EnterpriseNames;
            txtItemName.Text = data.ItemName;
            txtLinkman.Text = data.Linkman;
            txtPosition.Text = data.Position;
            txtTel.Text = data.Tel;
            txtEmail.Text = data.Email;
            txtMobile.Text = data.Mobile;
            txtFax.Text = data.Fax;
            txtAddress.Text = data.Address;
            txtUserAmount.Text = data.UserAmount.ToString();
            txtStartDate.Text = Convert.ToDateTime(data.StartDate ?? DateTime.Now).ToShortDateString();
            txtEndDate.Text = Convert.ToDateTime(data.ExpireDate ?? DateTime.Now).ToShortDateString();
            txtAdminUserName.Text = data.AdminUserName;
            //txtAdminPassword.Text = data.AdminPassword;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //获取界面数据
            E_Enterprise data = new E_Enterprise();
            data.EnterpriseCode = txtEPCode.Text.Trim();
            data.EnterpriseNames = txtEPName.Text.Trim();
            data.ItemName = txtItemName.Text.Trim();
            data.Linkman = txtLinkman.Text.Trim();
            data.Position = txtPosition.Text.Trim();
            data.Tel = txtTel.Text.Trim();
            data.Mobile = txtMobile.Text.Trim();
            data.Fax = txtFax.Text.Trim();
            data.Email = txtEmail.Text.Trim();
            data.Address = txtAddress.Text.Trim();
            data.UserAmount = int.Parse(txtUserAmount.Text.Trim());
            data.StartDate = DateTime.Parse(txtStartDate.Text.Trim());
            data.ExpireDate = DateTime.Parse(txtEndDate.Text.Trim());
            data.AdminUserName = txtAdminUserName.Text.Trim();
            string password = txtAdminPassword.Text.Trim();
            data.AdminPassword = string.IsNullOrEmpty(password)?"":EncryptString.EncryptPassword(password);
            if (type == "update")
            {
                int enterpriseid = Requests.GetQueryInt("eid", 0);
                data.EnterpriseID = enterpriseid;
                bool b = new T_Enterprise().AdminUpdate(data);
                //MLMGC.COMP.Jscript.ShowMsg("修改" + (b ? "成功" : "失败"), this);
                if (b)
                {
                    MLMGC.COMP.Jscript.AlertAndRedirect(this, "修改成功", "List.aspx");
                }
                else
                {
                    MLMGC.COMP.Jscript.ShowMsg("修改失败", this);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(data.AdminPassword))
                {
                    MLMGC.COMP.Jscript.ShowMsg("第一次操作，请输入密码", this);
                    return;
                }
                int result = new T_Enterprise().Add(data);
                if (result>0)
                {
                    MLMGC.COMP.Jscript.AlertAndRedirect(this, "添加成功", "List.aspx");
                }
                else if(result ==-2)
                {
                    MLMGC.COMP.Jscript.ShowMsg("请创建或设置默认数据库", this);
                }
                else
                {
                    MLMGC.COMP.Jscript.ShowMsg("添加失败", this);
                }
            }                
        }
         
    }
}