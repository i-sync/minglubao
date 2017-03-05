using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;
using MLMGC.BLL.Personal;
using MLMGC.DataEntity.Personal;

namespace Web.Personal
{
    public partial class Modify : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            //获取个人基本信息
            E_Personal data = new E_Personal();
            data.UserID = UserID;
            data.PersonalID = PersonalID;
            data = new T_Personal().GetModel(data);
            if (data == null)
            {
                return;
            }
            EnumUtil.BindList<EnumWorkYear>(ddlWorkYear);
            EnumUtil.BindList<EnumScale>(ddlScale);
            //-----------Info---------
            lblBName.Text = data.RealName;
            lblBSex.Text = data.Sex == 0 ? "男" : "女";
            lblBMarital.Text = data.MaritalStatus.ToString();
            lblBBirthday.Text = string.Format("{0:yyyy-MM-dd}", data.Birthday);
            lblBWorkYear.Text = data.WorkYears.ToString();
            //居住地
            //户口所在地
            lblBEmail.Text = data.Email;
            lblBMobile.Text = data.Mobile;
            lblBTel.Text = data.Tel;
            lblBFax.Text = data.Fax;
            lblBKeyword.Text = data.KeyWord;
            lblBAddress.Text = data.Address;

            //-----------Edit----------
            txtBName.Text = data.RealName;
            rdBGender.SelectedValue = data.Sex.ToString ();
            rdBMarital.SelectedValue = ((int)data.MaritalStatus).ToString();
            txtBBirthday.Text = string.Format("{0:yyyy-MM-dd}", data.Birthday);
            ddlWorkYear.SelectedValue = ((int)data.WorkYears).ToString();
            //居住地
            //户口所在地
            txtBEmail.Text = data.Email;
            txtBMobile.Text = data.Mobile;
            txtBTel.Text = data.Tel;
            txtBFax.Text = data.Fax;
            txtBKeyword.Text = data.KeyWord;
            txtBAddress.Text = data.Address;


            //获取个人的工作经验 
            E_JobExperience dataJob = new E_JobExperience();
            dataJob.PersonalID = PersonalID;
            dataJob.UserID = UserID;

            rpList.DataSource = new T_JobExperience().GetList(dataJob);
            rpList.DataBind();
        }
    }
}