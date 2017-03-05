using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;

namespace WebAdmin.Enterprise
{
    public partial class ItemInfo : System.Web.UI.Page
    {
        int eid,iid;
        private int pageIndex = 1;
        private int pageSize = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
            eid = Requests.GetQueryInt("eid", 0);
            iid = Requests.GetQueryInt("iid", 0);
            pageIndex = Requests.GetQueryInt("page", 1);
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
            MLMGC.COMP.EnumUtil.BindList<ItemStatus>(rbStatus);

            E_Item data = new T_Item().GetModel(new E_Item() { EnterpriseID = eid });
            if (data != null)
            {
                txtItemName.Text = data.ItemName;
                txtItemIntro.Text = data.ItemIntro;
                txtSignature.Text = data.Signature;
                txtContent.Content = data.ItemContent;
                imgPhoto.ImageUrl = MLMGC.COMP.Config.GetEnterpriseItemPhotoUrl(data.Photo);
                hdUrl.Value = MLMGC.COMP.Config.GetEnterpriseItemPhotoUrl(data.Photo);
                txtEstablished.Text = data.Established.ToShortDateString();
                //txtCityID.Text = data.CityID.ToString();
                rbStatus.SelectedValue = ((int)data.Status).ToString();
                region.RegionID = data.CityID;

                //项目是否使用
                ltOpenFlag.Text = data.OpenFlag.ToString();
                btnOpenFlag.Visible = data.OpenFlag == ItemOpenFlag.未开通;              
            }

            loadMessage();
        }

        /// <summary>
        /// 加载留言信息
        /// </summary>
        protected void loadMessage()
        {
            E_ItemMessage data = new E_ItemMessage();
            data.EnterpriseID = eid;
            data.Page = new MLMGC.DataEntity.E_Page();
            data.Page.PageIndex = pageIndex;
            data.Page.PageSize = pageSize;

            rpList.DataSource = new T_ItemMessage().GetList(data);
            rpList.DataBind();

            //设置分页样式
            pageList1.PageSize = pageSize;
            pageList1.CurrentPageIndex = pageIndex;
            pageList1.RecordCount = data.Page.TotalCount;
            pageList1.CustomInfoHTML = string.Format("共有记录 <span class='red_font'>{0}</span> 条", pageList1.RecordCount);
            pageList1.TextAfterPageIndexBox = "&nbsp;页/" + pageList1.PageCount + "&nbsp;";
        }

        /// <summary>
        /// 点击使用按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOpenFlag_Click(object sender, EventArgs e)
        {
            E_Item data = new E_Item();
            data.EnterpriseID = eid;
            data.ItemID = iid;
            data.OpenFlag = ItemOpenFlag.已开通;

            bool flag = new T_Item().UpdateOpenFlag(data);
            if (flag)
            {
                Jscript.ShowMsg("开通成功！",this);
                databind();
            }
            else
            {
                Jscript.ShowMsg("开通失败！",this);
            }
        }

        /// <summary>
        /// 点击确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        { 
            //获取界面数据
            string name = txtItemName.Text.Trim();
            string intro = txtItemIntro.Text.Trim();
            string signature = txtSignature.Text.Trim();
            string content = txtContent.Content;
            string established = txtEstablished.Text.Trim();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(content))
            {
                Jscript.ShowMsg("请认真填写以上内容!", this);
                return;
            }

            E_Item data = new E_Item();
            data.EnterpriseID = eid;
            data.ItemName = name;
            data.ItemIntro = intro;
            data.Signature = signature;
            data.ItemContent = content;
            data.SetStatus = Convert.ToInt32(rbStatus.SelectedValue);
            data.Photo = hdUrl.Value.Substring(hdUrl.Value.LastIndexOf("/") + 1);
            if (!string.IsNullOrEmpty(established))
            {
                data.Established = Convert.ToDateTime(txtEstablished.Text.Trim());
            }
            else
            {
                data.Established = DateTime.Now;
            }
            data.CityID = region.RegionID;
            bool flag = new T_Item().Update(data);
            //Jscript.ShowMsg(string.Format("保存{0}",flag?"成功":"失败"), this);
            if (flag)
            {
                //Jscript.ShowMsg("保存成功", this);
                databind();
                Jscript.AlertAndRedirect(this, "修改成功", "ItemList.aspx?page="+Requests.GetQueryString("page"));
            }
            else
            {
                Jscript.ShowMsg("保存失败", this);
            }
        }
    }
}