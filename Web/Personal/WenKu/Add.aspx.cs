using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.COMP;
using MLMGC.DataEntity.WenKu;
using MLMGC.BLL.WenKu;
using MLMGC.BLL.User;
using MLMGC.DataEntity;
using MLMGC.DataEntity.User;
using System.Configuration;

namespace Web.Personal.WenKu
{
    public partial class Add :MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //设置上传控件的虚拟路径
            FileUpload1.VirtualPath = MLMGC.COMP.Config.WenKuFolder+"\\";
            FileUpload1.FileExt = MLMGC.COMP.Config.GetAppSettings("WenKuFileExt");
            long sizelimit;
            if (long.TryParse(MLMGC.COMP.Config.GetAppSettings("WenKuSizeLimit"), out sizelimit))
            {
                sizelimit = 5242880;//默认为5M;
            }
            FileUpload1.SizeLimit = sizelimit;
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            //获取个人信息，判断他的信息是否完善，如果不完善，跳转到个人资料页面进行填写。
            E_Personal dataPersonal = new E_Personal();
            dataPersonal.UserID = UserID;
            dataPersonal.PersonalID = PersonalID;
            dataPersonal = new T_Personal().GetModel(dataPersonal);
            if (dataPersonal == null)
            {
                Response.Redirect("../main.aspx");
            }
            //判断资料是否完善
            if (!new T_Personal().IsPerfect(dataPersonal))
            {
                Jscript.AlertAndRedirect(this, "个人信息不完善", "../Modify.aspx");
                return;
            }


            //获取文库目录分类
            DataTable dt = new T_WenKuClass().GetList();            
            if (dt == null)
                return;
            //绑定目录分类
            foreach (DataRow row in dt.Rows)
            {
                ddlCategory.Items.Add(new ListItem(row["WenKuClassName"].ToString (),row["WenKuClassID"].ToString ()));
            }            
            ddlCategory.Items.Add(new ListItem("其它", "0"));
        }

        /// <summary>
        /// 点击上传按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string caption = txtCaption.Text.Trim();
            string intro = txtIntro.Text.Trim();
            string keyword = txtKeyword.Text.Trim();
            string custom = txtCustom.Text.Trim();
            int value = Convert.ToInt32(ddlCategory.SelectedValue);

            if (string.IsNullOrEmpty(caption))
            {
                Jscript.ShowMsg("请输入标题", this);
                return;
            }
            if (value == -1 && string.IsNullOrWhiteSpace(custom))
            {
                Jscript.ShowMsg("请输入自定义分类", this);
                return;
            }

            //上传文件
            List<PFileInfo> list=FileUpload1.Upload();
            if (list==null || list.Count == 0)
            {
                MLMGC.COMP.Jscript.ShowMsg("上传文件失败", this);
                return;
            }

            //--------判断该文件是否已存在--------
            bool b = new T_WenKu().Exists(new E_WenKu() { FileName = list[0].FileName });
            if (b)
            {
                Jscript.ShowMsg("该文件已存在", this);
                return;
            }
            //-----------------------------------
            
            E_WenKu data = new E_WenKu();
            data.UserType = MLMGC.DataEntity.User.UserType.个人用户;
            data.UserID = UserID;
            data.Caption = caption;
            data.Intro = intro;
            data.Keywords = keyword;
            data.WenKuClassID = value;
            data.CustomClassName = custom;

            data.SetFileType2 = list[0].FileType;
            data.FileName = list[0].FileName;
            data.FileUrl = list[0].FileAddress;
            data.FileSize = Convert.ToInt32(list[0].FileSize);
            data.StatusFlag = EnumStatusFlag.待审核;

            bool flag = new T_WenKu().Add(data);

            if (flag)
            {
                try
                {
                    //转换文档为swf
                    System.IO.FileStream fs = new System.IO.FileStream(MLMGC.COMP.Config.MonitorFilePath+data.WenKuID.ToString()+".txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                    sw.WriteLine(string.Format("\r\n{0}|{1}", data.WenKuID, list[0].FileAddress));
                    sw.Close();
                    fs.Close();
                }
                catch
                {
                    
                }
            }
            if (flag)
            {
                Jscript.AlertAndRedirect(this, "上传成功", "Add.aspx");
            }
            else
            {
                Jscript.ShowMsg("上传失败！", this);
            }
        }
    }
}