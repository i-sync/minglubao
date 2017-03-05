using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.COMP;

namespace Web.Personal.Data
{
    public partial class ImportingStep2 : MLMGC.Security.PersonalPage
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
            //读取绑定标题
            DataTable dt = new ImportingData(PersonalID).TitleSource();
            BindDropDownList(ddlName, dt);
            BindDropDownList(ddlAddress, dt);
            BindDropDownList(ddlZipCode, dt);
            BindDropDownList(ddlWebiSite, dt);
            BindDropDownList(ddlLinkman, dt);
            BindDropDownList(ddlPosition, dt);
            BindDropDownList(ddlTel, dt);
            BindDropDownList(ddlMobile, dt);
            BindDropDownList(ddlFax, dt);
            BindDropDownList(ddlEmail, dt);
            BindDropDownList(ddlQQ, dt);
            BindDropDownList(ddlMSN, dt);
            BindDropDownList(ddlRemark, dt);
        }
        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        /// <param name="ddl">下拉框</param>
        /// <param name="liSource">数据源</param>
        protected void BindDropDownList(DropDownList ddl, DataTable dt)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = "Text";
            ddl.DataValueField = "Value";
            ddl.DataBind();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlName.SelectedValue))
            {
                Jscript.ShowMsg("名录名称必须选择", this);
                return;
            }
            if (!CheckDropDownList())
            {
                Jscript.ShowMsg("设置重复,请重新设置", this);
                return;
            }
            //保存设置
            List<E_CorreField> list = new List<E_CorreField>();
            list.Add(new E_CorreField() { Name = "ClientName", Source = ddlName.SelectedValue });
            list.Add(new E_CorreField() { Name = "Address", Source = ddlAddress.SelectedValue });
            list.Add(new E_CorreField() { Name = "ZipCode", Source = ddlZipCode.SelectedValue });
            list.Add(new E_CorreField() { Name = "WebiSite", Source = ddlWebiSite.SelectedValue });
            list.Add(new E_CorreField() { Name = "Linkman", Source = ddlLinkman.SelectedValue });
            list.Add(new E_CorreField() { Name = "Position", Source = ddlPosition.SelectedValue });
            list.Add(new E_CorreField() { Name = "Tel", Source = ddlTel.SelectedValue });
            list.Add(new E_CorreField() { Name = "Mobile", Source = ddlMobile.SelectedValue });
            list.Add(new E_CorreField() { Name = "Fax", Source = ddlFax.SelectedValue });
            list.Add(new E_CorreField() { Name = "Email", Source = ddlEmail.SelectedValue });
            list.Add(new E_CorreField() { Name = "QQ", Source = ddlQQ.SelectedValue });
            list.Add(new E_CorreField() { Name = "MSN", Source = ddlMSN.SelectedValue });
            list.Add(new E_CorreField() { Name = "Remark", Source = ddlRemark.SelectedValue });
            bool b = new ImportingData(PersonalID).SaveConfiguration(list);
            if (b)
            {
                Response.Redirect("ImportingStep3.aspx");
            }
            else
            {
                Jscript.ShowMsg("保存失败", this);
            }
        }
        /// <summary>
        /// 检查下拉框内容是否有重复
        /// </summary>
        /// <returns></returns>
        protected bool CheckDropDownList()
        {
            List<string> ary = new List<string>();
            ary.Add(ddlName.SelectedValue);
            return CheckValue(ddlAddress.SelectedValue, ref ary) && CheckValue(ddlZipCode.SelectedValue, ref ary) && CheckValue(ddlWebiSite.SelectedValue, ref ary) && CheckValue(ddlLinkman.SelectedValue, ref ary) && CheckValue(ddlPosition.SelectedValue, ref ary) && CheckValue(ddlTel.SelectedValue, ref ary) && CheckValue(ddlMobile.SelectedValue, ref ary) && CheckValue(ddlFax.SelectedValue, ref ary) && CheckValue(ddlEmail.SelectedValue, ref ary) && CheckValue(ddlQQ.SelectedValue, ref ary) && CheckValue(ddlMSN.SelectedValue, ref ary) && CheckValue(ddlRemark.SelectedValue, ref ary);
        }
        protected bool CheckValue(string str, ref List<string> ary)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            if (ary.Contains(str))
            {
                return false;
            }
            return true;
        }
    }
}