using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.DataEntity.Enterprise.Material;
using MLMGC.BLL.Enterprise.Material;
using MLMGC.DataEntity;

namespace Web.Enterprise.Material
{
    public partial class MaterialEdit :MLMGC.Security.EnterprisePage
    {
        string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUpload1.VirtualPath = MLMGC.COMP.Config.EnterpriseMaterialFolder + "\\" + EnterpriceID +"\\";

            type = MLMGC.COMP.Requests.GetQueryString("type").ToLower();
            if (type == "update" && !IsPostBack)
            {
                long materialID = MLMGC.COMP.Requests.GetQueryLong("materialid", 0);
                databind(materialID);
            }            
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="materialID"></param>
        protected void databind(long materialID)
        {
            E_Material data = new E_Material();
            data.MaterialID = materialID;
            data.EnterpriseID = EnterpriceID;
            data = new T_Material().GetModel(data);
            txtMaterialName.Text = data.MaterialName;
            txtClassName.Text = data.ClassName;
            
            //设置上传控件
            FileUpload1.BindList(data.FileName, data.FileSize.ToString(),data.FileType, data.Url);
        }

        /// <summary>
        /// 点击确定处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {            
            //判断是否输入标题和分类
            if (txtMaterialName.Text == "" && txtClassName.Text == "")
            { 
                 MLMGC.COMP.Jscript.ShowMsg("请输入标题和分类", this);
                return;
            }
            else if (txtMaterialName.Text == "")
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入标题", this);
                return;
            }
            else if (txtClassName.Text == "")
            { 
                MLMGC.COMP.Jscript.ShowMsg("请输入分类", this);
                return;
            }
            
            //上传文件
            List<PFileInfo> list=FileUpload1.Upload();
            if (list==null || list.Count == 0)
            {
                MLMGC.COMP.Jscript.ShowMsg("上传文件失败", this);
                return;
            }
            //----------------文件上传成功 生成txt文本 进行文件类型转换---------------

            //----------------------------------------------------------------------

            //----封装对象----
            E_Material data = new E_Material();

            data.MaterialType = EnumMaterialType.项目资料;
            data.EnterpriseID = EnterpriceID;
            data.MaterialName = txtMaterialName.Text;
            data.ClassName = txtClassName.Text;
            data.FileName = list[0].FileName;
            data.FileType = list[0].FileType;
            data.FileSize = Convert.ToInt32(list[0].FileSize);
            data.Url = list[0].FileAddress;

            //判断是添加还是修改
            if (type == "add")
            {               

                bool flag = new T_Material().Add (data);
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "添加项目资料", IP = MLMGC.COMP.Requests.GetRealIP() });
                if (flag)
                {
                    MLMGC.COMP.Jscript.AlertAndRedirect(this, "添加成功", "MaterialList.aspx");
                }
                else
                {
                    MLMGC.COMP.Jscript.ShowMsg("添加失败", this);
                }
            }
            else
            {
                //获取项目资料编号
                long materialID = MLMGC.COMP.Requests.GetQueryLong("materialid", 0);
                data.MaterialID = materialID;

                bool flag = new T_Material().Update(data);
                new MLMGC.BLL.Enterprise.T_Log().Add(new MLMGC.DataEntity.Enterprise.E_Log() { EnterpriseID = EnterpriceID, UserID = UserID, LogTitle = "修改项目资料", IP = MLMGC.COMP.Requests.GetRealIP() });
                if (flag)
                {
                    MLMGC.COMP.Jscript.AlertAndRedirect(this, "修改成功", "MaterialList.aspx");
                }
                else
                {
                    MLMGC.COMP.Jscript.ShowMsg("修改失败", this);
                }
            }

        }
    }
}