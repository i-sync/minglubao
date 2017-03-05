using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MLMGC.BLL.WenKu;
using MLMGC.DataEntity.WenKu;
using MLMGC.COMP;
using System.IO;

namespace Web.WenKu
{
    public partial class Info : System.Web.UI.Page
    {
        protected string FileUrl,FlashUrl;
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
            //获取文库编号
            int id;
            if (!int.TryParse(Request["id"], out id))
            {
                Jscript.AlertAndRedirect(this, "参数错误", "List.aspx");
                return;
            }

            
            //根据编号获取文库详情
            E_WenKu data = new E_WenKu();
            data.WenKuID = id;
            data = new T_WenKu().GetModel(data);
            if (data == null)
            {
                Jscript.ShowMsg("未获得数据", this);
                return;
            }
            //判断swf文件是否存在，若不存在，则直接返回
            string flashpath = MLMGC.COMP.Config.GetWenKu("swf/" + data.FileUrl.Substring(0, data.FileUrl.LastIndexOf(".")) + ".swf");
            if (!File.Exists(flashpath))
            {
                Jscript.CloseWindow("对应的文件未找到");
                return;
            }

            lblCaption.Text = data.Caption;
            lblFileSize.Text = MLMGC.COMP.CommonMethod.FileSize(data.FileSize);
            FileUrl = Config.GetWenKuUrl(data.FileUrl);
            FlashUrl = Config.GetWenKuUrl("swf/"+data.FileUrl.Substring(0, data.FileUrl.LastIndexOf(".")) + ".swf");

            //修改浏览次数
            bool flag = new T_WenKu().UpdateBrowser(data);
        }        
    }
}