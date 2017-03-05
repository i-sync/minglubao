using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Personal.Material;
using MLMGC.BLL.Personal.Material;

namespace Web.Personal.Info
{
    public partial class Talk :MLMGC.Security.PersonalPage
    {
        protected bool flag = false;//默认不显示添加按钮
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
            E_Talk data = new E_Talk();
            data.PersonalID = PersonalID;
            DataTable dt = new T_Talk().GetList(data);
            if (dt==null||dt.Rows.Count == 0)
            {
                flag = true;
            }
            rpList.DataSource = dt;
            rpList.DataBind();
        }
    }
}