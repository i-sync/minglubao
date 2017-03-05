using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using MLMGC.COMP;
using MLMGC.BLL.WenKu;
using MLMGC.BLL.Enterprise.Material;
using MLMGC.DataEntity.WenKu;
using MLMGC.DataEntity.Enterprise.Material;

namespace Web.Enterprise.WenKu
{
    public partial class MaterialShare :MLMGC.Security.EnterprisePage
    {
        private long sizelimit;        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!long.TryParse(MLMGC.COMP.Config.GetAppSettings("WenKuSizeLimit"), out sizelimit))
            {
                sizelimit = 5242880;//默认大小为5M
            }
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            //加载文件基本信息            
            int id = Requests.GetQueryInt("id", 0);

            E_Material data = new E_Material();
            data.MaterialID = id;
            data.EnterpriseID = EnterpriceID;
            data = new T_Material().GetModel(data);
            txtCaption.Text = data.MaterialName;
            hlUrl.Text  = data.FileName;
            hlUrl.NavigateUrl = MLMGC.COMP.Config.GetEnterpriseMaterialUrl(EnterpriceID,data.Url);
            //用隐藏域存储附件信息
            hfFile.Value = string.Format("{0}|{1}|{2}|{3}",data.FileName,data.FileType,data.FileSize,data.Url);

            //验证要共享的文件是否存在，若存在则不能共享
            bool flag = new T_WenKu().Exists(new E_WenKu() { FileName = data.FileName });
            if (flag)
            {
                Jscript.AlertAndRedirect(this, "该文档已存在无法共享", "../Material/MaterialList.aspx");
                return;
            }


            //获取文库目录分类
            DataTable dt = new T_WenKuClass().GetList();
            
            if (dt == null)
                return;
            foreach (DataRow row in dt.Rows)
            {
                ddlCategory.Items.Add(new ListItem(row["WenKuClassName"].ToString(), row["WenKuClassID"].ToString()));
            }
            //绑定目录分类
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
            
            //获取附件基本信息
            string attach = hfFile.Value;
            string[] arr = attach.Split('|');
            if (arr.Length == 0)
                return;
            if (Convert.ToInt64(arr[2]) > sizelimit)
            {
                Jscript.ShowMsg("文件过大无法共享！", this);
                return;
            }

            //1.-------拷贝对象资料到WenKu目录-------
            //原文件的物理路径
            string filepath = MLMGC.COMP.Config.GetEnterpriseM(EnterpriceID, arr[3]);
            if (File.Exists(filepath))
            {
                //目标文件的物理路径
                string destpath = MLMGC.COMP.Config.GetWenKu(arr[3]);
                File.Copy(filepath, destpath,true);//拷贝原文件
            }
            //-----------------------------------
           
            //2.----------插入WenKu数据------------
            E_WenKu data = new E_WenKu();
            data.EnterpriseID = EnterpriceID;
            data.UserID = 0;
            data.Caption = caption;
            data.Intro = intro;
            data.Keywords = keyword;
            data.WenKuClassID = value;
            data.CustomClassName = custom;
            data.UserType = MLMGC.DataEntity.User.UserType.企业用户;

            data.FileName = arr[0];
            data.SetFileType2 = arr[1];
            data.FileSize = Convert.ToInt32(arr[2]);
            data.FileUrl = arr[3];
            data.StatusFlag = EnumStatusFlag.待审核;

            bool flag = new T_WenKu().Add(data);
            //--------------------------------------------

            if (flag) //如果成功则继续
            {
                //3.-------------修改数据库，标识该资料已被共享------------------
                E_Material dataM = new E_Material();
                dataM.EnterpriseID = EnterpriceID;
                dataM.MaterialID = Requests.GetQueryInt("id", 0);
                dataM.WenKuFlag = EnumWenKuFlag.待审核;
                dataM.WenKuID = data.WenKuID;

                flag = new T_Material().Share(dataM);
                //-------------------------------------------------------------

                //4.--------------------修改监控文件 生成swf文件-------------------
                //转换文档为swf
                System.IO.FileStream fs = new System.IO.FileStream(MLMGC.COMP.Config.MonitorFilePath+data.WenKuID.ToString ()+".txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                sw.WriteLine(string.Format("\r\n{0}|{1}", data.WenKuID, arr[3]));
                sw.Close();
                fs.Close();
                //----------------------------------------------------
            }

            if (flag)
            {
                Jscript.AlertAndRedirect(this, "共享成功", "/enterprise/material/materiallist.aspx");
            }
            else {
                Jscript.ShowMsg("共享失败", this);
            }
        }
    }
}