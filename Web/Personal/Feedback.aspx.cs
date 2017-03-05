using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLMGC.DataEntity;
using MLMGC.BLL;

namespace Web.Personal
{
    public partial class Feedback : MLMGC.Security.PersonalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUpload1.VirtualPath = MLMGC.COMP.Config.FeedbackFolder + "\\";
        }

        /// <summary>
        /// 点击保存按钮处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //判断是否输入标题和分类
            if (string.IsNullOrWhiteSpace(txtSubject.Text) && string.IsNullOrWhiteSpace(txtDetail.Text))
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入标题和描述", this);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入标题", this);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtDetail.Text))
            {
                MLMGC.COMP.Jscript.ShowMsg("请输入描述", this);
                return;
            }

            //----封装对象----
            E_Feedback data = new E_Feedback();
            data.UserID = UserID;
            data.UserType = (int)MLMGC.DataEntity.User.UserType.个人用户;
            data.Subject = txtSubject.Text;
            data.Detail = txtDetail.Text;

            //判断是否上传附件
            if (FileUpload1.HasFiles)
            {
                //上传文件
                List<PFileInfo> list = FileUpload1.Upload();
                if (list==null || list.Count == 0)
                {
                    MLMGC.COMP.Jscript.ShowMsg("上传文件失败", this);
                    return;
                }
                data.FileName = list[0].FileName;
                data.FileType = list[0].FileType;
                data.FileSize = Convert.ToInt32(list[0].FileSize);
                data.Url = list[0].FileAddress;
            }
            else
            {
                data.FileName = "";
                data.FileType = "";
                data.FileSize = 0;
                data.Url = "";
            }
            

            bool flag = new T_Feedback().Add(data);
            if (flag)
            {
                MLMGC.COMP.Jscript.ShowMsg("添加成功", this);
            }
            else
            {
                MLMGC.COMP.Jscript.ShowMsg("添加失败", this);
            }
        }
    }
}