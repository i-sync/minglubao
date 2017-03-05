using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.COMP;
using MLMGC.BLL.Personal;
using MLMGC.DataEntity.Personal;
using MLMGC.DataEntity;

namespace Web.Personal.Weibo
{
    public partial class List : MLMGC.Security.PersonalPage
    {
        int pagesize = 20, pageindex = 1;
        protected string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Requests.GetQueryInt("page", 1);
            type = Requests.GetQueryString("type");  //判断是否为个人或公共
            if (!IsPostBack)
            {
                databind();
            }
        }

        public void databind()
        {
            //微博信息
            T_Weibo bll = new T_Weibo();
            E_Weibo data = new E_Weibo();
            data.PersonalID =type=="personal"? PersonalID:0;
            data.WeiboID = Requests.GetQueryInt("weiboid", 0);
            data.Page = new E_Page();
            data.Page.PageSize = pagesize;
            data.Page.PageIndex = pageindex;
            rpList.DataSource = bll.List(data);
            rpList.DataBind();

            //设置分页样式
            mlmgcPaging.PageSize = pagesize;
            mlmgcPaging.RecordCount = data.Page.TotalCount;
            mlmgcPaging.CurrentPage = pageindex;
        }
    }
}