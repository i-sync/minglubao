using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise.Material;
using MLMGC.BLL.Enterprise.Material;

namespace Web.Enterprise.Material
{
    public partial class MaterialList :MLMGC.Security.EnterprisePage
    {
        int pageSize = 20, pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = MLMGC.COMP.Requests.GetString("type").ToLower();
            pageIndex = MLMGC.COMP.Requests.GetQueryInt("page", 1);
            if (type == "delete")
            {
                long materialid = MLMGC.COMP.Requests.GetQueryLong("materialid",0);
                Delete(materialid);
            }
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
            E_Material data = new E_Material();
            data.MaterialType = EnumMaterialType.项目资料;
            data.EnterpriseID = EnterpriceID;
            //分页参数
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageSize = pageSize;
            data.Page.PageIndex = pageIndex;

            rpList.DataSource = new  T_Material().GetList(data);
            rpList.DataBind();
            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 删除项目资料
        /// </summary>
        /// <param name="materialID"></param>
        protected void Delete(long materialID)
        {
            E_Material data = new E_Material();
            data.MaterialID = materialID;
            data.EnterpriseID = EnterpriceID;
            bool flag = new T_Material().Delete(data);
            new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "删除项目资料", IP = MLMGC.COMP.Requests.GetRealIP() });
            if (flag)
            {
                //MLMGC.COMP.Jscript.AlertAndRedirect(this, "删除成功", "MaterialList.aspx");
                MLMGC.COMP.Jscript.ShowMsg("删除成功", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("删除失败", this);
            }
        }

        /// <summary>
        /// 判断当前资料是否已共享
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public string Share(object flag,object id)
        {
            string info = string.Empty;
            switch (flag.ToString())
            { 
                case "0":
                    info = string.Format("<a href=\"../WenKu/MaterialShare.aspx?id={0}\">共享</a>", id);
                    break;
                case "1":
                    info = EnumWenKuFlag.待审核.ToString ();
                    break;
                case "2":
                    info = EnumWenKuFlag.审核通过.ToString ();
                    break;
                case "3":
                    info = EnumWenKuFlag.审核未通过.ToString ();
                    break;
            }
            return info;
        }
    }
}