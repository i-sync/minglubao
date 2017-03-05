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
    public partial class Top : MLMGC.Security.EnterprisePage
    {
        protected DataTable dtMenu;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            //绑定菜单
            //获取所有的菜单
            dtMenu = new T_User().GetMenuList(new E_EnterpriseUser() { EPUserTMRID = base.EPUserTMRID, EnterpriseID = EnterpriceID, UserID = UserID });


            //查找一级节点
            IEnumerable<System.Data.DataRow> firstNode =
                from item in dtMenu.AsEnumerable()
                where item.Field<byte>("DeptID") == 0
                select item;
            rpFirstMenu.DataSource = firstNode.CopyToDataTable<DataRow>();
            rpFirstMenu.DataBind();

        }
    }
}