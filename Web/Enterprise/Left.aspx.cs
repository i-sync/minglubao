using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.User;
using MLMGC.BLL.User;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;

namespace Web.Enterprise
{
    public partial class Left : MLMGC.Security.EnterprisePage
    {
        protected int kid;
        protected DataTable dtMenu;
        protected bool ShowTip = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            kid = RoleID;
            //读取用户头像:若没有设置头像则根据性别选择默认的头像
            E_User dataAvatar = new E_User();
            dataAvatar.EnterpriseID = EnterpriceID;
            dataAvatar.UserID = UserID;
            dataAvatar = new T_User().GetEPModel(dataAvatar);
            if (dataAvatar != null)
            {
                string url = dataAvatar.Avatar == "" ? "/images/guanliyuan.jpg" : MLMGC.COMP.Config.GetEnterpriseAvatarUrl(dataAvatar.Avatar);
                imgAvatar.ImageUrl = url;
            }

            E_EnterpriseUser data = new E_EnterpriseUser();
            data.UserID = UserID;
            data.EnterpriseID = EnterpriceID;
            data.EPUserTMRID = EPUserTMRID;

            //ShowReservationTip = (RoleID == ((int)EnumRole.销售人员));

            DataTable dt = new T_User().GetUserSelectRole(data);
            if (dt != null && dt.Rows.Count >= 1)
            {
                //var v = from a in dt.Rows where a["EPUserTMRID"] = EPUserTMRID select new { Team=a["TeamName"],Role=a["RoleName"]};
                DataRow[] dr = dt.Select("EPUserTMRID =" + EPUserTMRID);
                if (dr.Length > 0)
                {
                    ltRole.Text = dr[0]["RoleName"].ToString();
                    //lblRole.Text = dr[0]["RoleName"].ToString();
                    ltTrueName.Text = dr[0]["TrueName"].ToString();

                    int firstlogin = Convert.ToInt32(dr[0]["FirstLogin"]);
                    if (firstlogin == 0)
                        ShowTip = true;
                }
            }

            //绑定菜单
            //获取所有的菜单
            dtMenu = new T_User().GetMenuList(new E_EnterpriseUser() { EPUserTMRID = base.EPUserTMRID, EnterpriseID = EnterpriceID, UserID = UserID });
            
            //查找二级节点 
            IEnumerable<System.Data.DataRow> secondNode =
                from item in dtMenu.AsEnumerable()
                where item.Field<byte>("DeptID") == 1
                select item;
            rpSecondMenu.DataSource = secondNode.CopyToDataTable<DataRow>();
            rpSecondMenu.DataBind();
        }


        /// <summary>
        /// 绑定三级节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpSecondMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater repeater = e.Item.FindControl("rpThirdMenu") as Repeater;
                DataRowView row = e.Item.DataItem as DataRowView;
                if (row == null) { return; }
                int menuid = Convert.ToInt32(row["MenuID"]);
                //查找三级节点 
                IEnumerable<System.Data.DataRow> thirdNode =
                    from item in dtMenu.AsEnumerable()
                    where item.Field<int>("PID") == menuid
                    select item;
                repeater.DataSource = thirdNode.CopyToDataTable<DataRow>();
                repeater.DataBind();
            }
        }
    }
}