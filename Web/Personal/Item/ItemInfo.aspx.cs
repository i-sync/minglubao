using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using MLMGC.COMP;
using MLMGC.BLL.User;
using MLMGC.DataEntity.User;
using MLMGC.BLL.Item;
using MLMGC.DataEntity.Item;

namespace Web.Personal.Item
{
    public partial class ItemInfo : MLMGC.Security.PersonalPage
    {
        private int eid,iid;
        private int pageIndex = 1;
        private int pageSize = 10;

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
            //加载项目信息
            E_Item data = new T_Item().GetModel(new E_Item() { EnterpriseID = eid });
            if (data != null)
            {
                ltItemName.Text = data.ItemName;
                ltItemIntro.Text = data.ItemIntro;
                ltSignature.Text = data.Signature;
                ltItemContent.Text = data.ItemContent;
                imgPhoto.ImageUrl = MLMGC.COMP.Config.GetEnterpriseItemPhotoUrl(data.Photo);
                ltEstablished.Text = data.Established.ToShortDateString();
                //txtCityID.Text = data.CityID.ToString();
                region.RegionID = data.CityID;
            }

            //加载个人信息
            E_Personal pData = new T_Personal().GetModel(new E_Personal() { PersonalID = PersonalID,UserID = UserID });
            if (pData != null)
            {
                txtUserName.Text = pData.RealName;
                txtMobile.Text = pData.Mobile;
                txtTel.Text = pData.Tel;
                txtEmail.Text = pData.Email;
                txtAddress.Text = pData.Address;

                //判断个人是否已经加入了项目
                if (pData.ItemFlag == EnumItemFlag.已经加入项目)
                {
                    btnApply.Enabled = false;
                }
            }

            //判断个人是否已经申请过了该项目
            if (btnApply.Enabled)//若btnApply不可以用，说明他已经加入了项目，就不用再判断他是否申请过该项目了。
            {
                bool flag = new T_ItemApply().Exists(new E_ItemApply() { ItemID = iid, UserID = UserID,ApplyType = EnumApplyType.申请加入 });
                if (flag)
                {
                    btnApply.Text = "申请已提交，正在申核。";
                    btnApply.Enabled = false;
                }
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
        /// 申请该项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnApply_Click(object sender, EventArgs e)
        {
            E_ItemApply data = new E_ItemApply();
            data.ItemID = iid;
            data.ApplyType = EnumApplyType.申请加入;
            data.UserID = UserID;
            data.Reason = "";

            bool flag = new T_ItemApply().Add(data);
            if (flag)
            {
                Jscript.ShowMsg("申请成功",this);
                databind();
            }
            else
            {
                Jscript.ShowMsg("留言失败！", this);
            }
        }



        /// <summary>
        /// 提交留言处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        { 
            //获取界面数据
            string username = txtUserName.Text.Trim();
            string mobile = txtMobile.Text.Trim();
            string tel = txtTel.Text.Trim();
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(message))
            {
                Jscript.ShowMsg("请请认真填写以上内容！",this);
                return;
            }

            E_ItemMessage data = new E_ItemMessage();
            data.ItemID = iid;
            data.UserID = UserID;
            data.UserName = username;
            data.Mobile = mobile;
            data.Tel = tel;
            data.Address = address;
            data.Email = email;
            data.Message = message;

            bool flag = new T_ItemMessage().Add(data);
            if (flag)
            {
                loadMessage();
                txtMessage.Text = "";
            }
            else
            {
                Jscript.ShowMsg("留言失败！", this);
            }
        }
    }
}