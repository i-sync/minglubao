using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.User;
using MLMGC.BLL.Personal;
using MLMGC.DataEntity.User;
using MLMGC.DataEntity.Personal;
using MLMGC.COMP;

namespace Web.Enterprise.Item
{
    public partial class PersonalInfo : MLMGC.Security.EnterprisePage
    {
        private int userid,personalid;       
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = Requests.GetQueryInt("uid", 0);
            personalid = Requests.GetQueryInt("pid", 0);
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
            data.UserID = userid;
            data.PersonalID = personalid;
            data = new T_Personal().GetModel(data);
            if (data == null)
            {
                return;
            }
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
            
            //获取个人的工作经验 
            E_JobExperience dataJob = new E_JobExperience();
            dataJob.PersonalID = personalid;
            dataJob.UserID = userid;

            rpList.DataSource = new T_JobExperience().GetList(dataJob);
            rpList.DataBind();
        }

    }
}