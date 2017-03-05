using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;

namespace Web.Enterprise
{
    public partial class EnterpriseEdit : MLMGC.Security.EnterprisePage
    {
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
            E_Enterprise data = new E_Enterprise();
            data.EnterpriseID = EnterpriceID;
            data = new T_Enterprise().GetModel(data);
            if (data != null)
            {
                ltEPCode.Text= data.EnterpriseCode;
                ltEPName.Text = data.EnterpriseNames;

                txtAddress.Text = data.Address;
                txtEmail.Text = data.Email;
                txtFax.Text = data.Fax;
                txtItemName.Text = data.ItemName;
                txtLinkman.Text = data.Linkman;
                txtMobile.Text = data.Mobile;
                txtPosition.Text = data.Position;
                txtTel.Text = data.Tel;

                txtStartDate.Text =Convert.ToDateTime(data.StartDate).ToString("yyyy-MM-dd");
                txtExpireDate.Text =Convert.ToDateTime(data.ExpireDate).ToString("yyyy-MM-dd");
                txtUserNum.Text = data.UserNum.ToString();
                txtUserName.Text = data.AdminUserName;
                //txtPassword.Text = data.AdminPassword;
            }
        }

        //点击修改按钮处理事件
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            E_Enterprise data = new E_Enterprise();
            data.EnterpriseID = EnterpriceID;
            data.ItemName = txtItemName.Text;
            data.Position = txtPosition.Text;
            data.Tel = txtTel.Text;
            data.Email = txtEmail.Text;
            data.Mobile = txtMobile.Text;
            data.Fax = txtFax.Text;
            data.Address = txtAddress.Text;
            data.Linkman = txtLinkman.Text;
            string password = txtPassword.Text.Trim();
            data.AdminPassword =string.IsNullOrEmpty(password)?"":MLMGC.COMP.EncryptString.EncryptPassword(password);

            bool flag = new T_Enterprise().Update(data);
            if (flag)
            {
                //添加操作日志
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "修改企业基本信息", IP = MLMGC.COMP.Requests.GetRealIP() });
                MLMGC.COMP.Jscript.ShowMsg("修改成功", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("修改失败", this);
            }
        }
    }
}