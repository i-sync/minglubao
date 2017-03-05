using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;
using MLMGC.BLL.Personal;
using MLMGC.DataEntity.Personal;
using MLMGC.BLL.Public;
using MLMGC.DataEntity.Public;

namespace Web.Personal
{
    public partial class Main : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { databind(); }
        }

        protected void databind()
        {
            E_Personal data = new E_Personal();
            data.UserID = UserID;
            data.PersonalID = PersonalID;
            data = new T_Personal().GetModel(data);
            if (data == null) { return; }
            ltName.Text = data.RealName;
            imgAvatar.ImageUrl = MLMGC.COMP.Config.GetPersonalAvatarUrl(data.Avatar);
            //ltSex.Text = data.Sex == 1 ? "男" : "女";
            //ltMobile.Text = data.Mobile;
            //ltTel.Text = data.Tel;
            //ltFax.Text = data.Fax;
            //ltAddress.Text = data.Address;


            //DataTable dt = new T_ClientInfo().Statistics(new E_ClientInfo() { PersonalID=PersonalID });
            //if (dt.Select("[Status] is null").Length > 0)//总量
            //{
            //    LtAmount.Text = dt.Select("[Status] is null")[0]["Amount"].ToString();
            //}
            //if (dt.Select("[Status]="+(int)EnumClientStatus.潜在客户).Length > 0)//潜在客户
            //{
            //    LtAmount1.Text = dt.Select("[Status]=" + (int)EnumClientStatus.潜在客户)[0]["Amount"].ToString();
            //}
            //if (dt.Select("[Status]=" + (int)EnumClientStatus.意向客户).Length > 0)//意向客户
            //{
            //    LtAmount2.Text = dt.Select("[Status]=" + (int)EnumClientStatus.意向客户)[0]["Amount"].ToString();
            //}
            //if (dt.Select("[Status]=" + (int)EnumClientStatus.成交客户).Length > 0)//成交
            //{
            //    LtAmount3.Text = dt.Select("[Status]=" + (int)EnumClientStatus.成交客户)[0]["Amount"].ToString();
            //}
            //if (dt.Select("[Status]=" + (int)EnumClientStatus.失败客户).Length > 0)//失败
            //{
            //    LtAmount4.Text = dt.Select("[Status]=" + (int)EnumClientStatus.失败客户)[0]["Amount"].ToString();
            //}
            //if (dt.Select("[Status]=" + (int)EnumClientStatus.报废客户).Length > 0)//报废
            //{
            //    LtAmount5.Text = dt.Select("[Status]=" + (int)EnumClientStatus.报废客户)[0]["Amount"].ToString();
            //}

            //显示最新的前几条微博
            rpListWeibo.DataSource = new T_Weibo().GetMainList(new E_Weibo() {WeiboID=0, Count =5});
            rpListWeibo.DataBind();

            //获取最新的n条公告信息
            rpListAnn.DataSource = new T_Announcement().GetNewList(new E_Announcement() { Count = 15});
            rpListAnn.DataBind();
        }
    }
}