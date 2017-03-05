using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity.Enterprise;
using MLMGC.BLL.Enterprise;
using MLMGC.COMP;

namespace Web.Enterprise.Config
{
    public partial class Item : MLMGC.Security.EnterprisePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            //绑定状态
            EnumUtil.BindList<ItemStatus>(rbStatus);

            E_Item data = new T_Item().GetModel(new E_Item() { EnterpriseID = EnterpriceID });
            if (data != null)
            {
                txtItemName.Text = data.ItemName;
                txtItemIntro.Text = data.ItemIntro;
                txtSignature.Text = data.Signature;
                txtItemContent.Content = data.ItemContent;
                imgPhoto.ImageUrl = MLMGC.COMP.Config.GetEnterpriseItemPhotoUrl(data.Photo);
                hdUrl.Value = MLMGC.COMP.Config.GetEnterpriseItemPhotoUrl(data.Photo);
                txtEstablished.Text = data.Established.ToShortDateString();
                //txtCityID.Text = data.CityID.ToString();
                rbStatus.SelectedValue = ((int)data.Status).ToString();
                region.RegionID = data.CityID;
            }
        }

        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtItemName.Text.Trim();
            string intro = txtItemIntro.Text.Trim();
            string signature = txtSignature.Text.Trim();
            string content = txtItemContent.Content;
            string established = txtEstablished.Text.Trim();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(content))
            {
                Jscript.ShowMsg("请认真填写以上内容!", this);
                return;
            }

            E_Item data = new E_Item();
            data.EnterpriseID = EnterpriceID;
            data.ItemName = name;
            data.ItemIntro = intro;
            data.Signature = signature;
            data.ItemContent = content;
            data.SetStatus = Convert.ToInt32(rbStatus.SelectedValue);
            data.Photo = hdUrl.Value.Substring(hdUrl.Value.LastIndexOf("/") + 1);
            if (!string.IsNullOrEmpty(established))
            {
                data.Established = Convert.ToDateTime(established);
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
                Jscript.ShowMsg("保存成功", this);
                databind();
            }
            else
            {
                Jscript.ShowMsg("保存失败", this);
            }
        }
    }
}