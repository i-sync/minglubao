using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using MLMGC.BLL.WenKu;
using MLMGC.DataEntity.WenKu;
using System.Net.Json;
using System.IO;
using System.Data;

namespace WebAdmin.Handler
{
    /// <summary>
    /// WenKu 的摘要说明
    /// </summary>
    public class WenKu : IHttpHandler
    {
        NameValueCollection nv;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            nv = HttpContext.Current.Request.Form;
            switch (nv["key"])
            { 
                case "addclass"://添加文库分类
                    AddClass();
                    break;
                case "updateclass"://修改文库分类 
                    UpdateClass();
                    break;
                case "deleteclass"://删除文库分类
                    DeleteClass();
                    break;
                case "getclass"://获取文库分类对象
                    GetClass();
                    break;
                case "updatestatus": //修改文档的审核状态 
                    UpdateStatus();
                    break;
                case "deletewenku": //删除文库
                    DeleteWenKu();
                    break;
                case "batchdelete": //批量删除文库
                    BatchDelete();
                    break;
                case "convert"://转换文档
                    Convert();
                    break;
                default:
                    context.Response.Write("Hello World");
                    break;
            }
        }

        /// <summary>
        /// 添加文库分类
        /// </summary>
        private void AddClass()
        {
            string name = nv["name"].Trim();
            if (string.IsNullOrEmpty(name))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_WenKuClass data = new E_WenKuClass();
            data.WenKuClassName = name;
            bool flag = new T_WenKuClass().Add(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 修改文库分类
        /// </summary>
        private void UpdateClass()
        {
            string name = nv["name"].Trim();
            int id;
            if (!int.TryParse(nv["id"],out id)||string.IsNullOrEmpty(name))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_WenKuClass data = new E_WenKuClass();
            data.WenKuClassID = id;
            data.WenKuClassName = name;
            bool flag = new T_WenKuClass().Update(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 删除文库分类
        /// </summary>
        private void DeleteClass()
        {
            int id;
            if (!int.TryParse(nv["id"], out id))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_WenKuClass data = new E_WenKuClass();
            data.WenKuClassID = id;
            bool flag = new T_WenKuClass().Delete(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 查询文库分类对象
        /// </summary>
        private void GetClass()
        {
            int id;
            if (!int.TryParse(nv["id"], out id))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_WenKuClass data = new E_WenKuClass();
            data.WenKuClassID = id;
            data = new T_WenKuClass().GetModel(data);
            JsonObjectCollection colDR = new JsonObjectCollection();
            colDR.Add(new JsonStringValue("flag", data!=null ? "1" : "0"));
            colDR.Add(new JsonStringValue("id", data.WenKuClassID.ToString()));
            colDR.Add(new JsonStringValue("name", data.WenKuClassName));
            HttpContext.Current.Response.Write(colDR.ToString());
        }

        /// <summary>
        /// 修改文库审核状态
        /// </summary>
        private void UpdateStatus()
        {
            int status;
            string ids = nv["ids"];
            if (!int.TryParse(nv["status"], out status) || !MLMGC.COMP.StringUtil.IsStringArrayList(ids))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_WenKu data = new E_WenKu();
            data.WenKuIDs = ids;
            data.SetStatusFlag = status;
            bool flag = new T_WenKu().UpdateStatus(data);
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 后台管理员删除审核未通过或已下线文档
        /// </summary>
        private void DeleteWenKu()
        {
            int id;
            if (!int.TryParse(nv["id"], out id))
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }
            E_WenKu data = new E_WenKu();
            data.WenKuID = id;
            data = new T_WenKu().GetModel(data);
            string filename = data.FileUrl;
            bool flag = new T_WenKu().Delete(data);

            if (flag)//如果删除成功,则删掉对应的物理文件
            {
                string path = MLMGC.COMP.Config.GetWenKu(filename);
                if (File.Exists(path))//判断原文件是否存在
                {
                    File.Delete(path);
                }
                string swfpath = MLMGC.COMP.Config.GetWenKu("swf\\" + filename.Substring(0, filename.LastIndexOf(".")) + ".swf");
                if (File.Exists(swfpath)) //判断swf文件是否存在
                {
                    File.Delete(swfpath);
                }
            }
            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 批量删除文库
        /// </summary>
        private void BatchDelete()
        {
            string ids = nv["ids"];
            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ids))//判断格式是否正确 格式：1,21,321
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }

            E_WenKu data = new E_WenKu();
            data.WenKuIDs = ids;
            DataTable dt = new T_WenKu().BatchDelete(data);
            bool flag = false;
            if (dt != null)
            {
                if (dt.Rows[0]["WenKuID"].ToString() == "-1")//删除失败
                {

                }
                else
                { 
                    //循环删除物理文件
                    foreach (DataRow row in dt.Rows)
                    {
                        string filename = row["FileUrl"].ToString();
                        string path = MLMGC.COMP.Config.GetWenKu(filename);
                        if (File.Exists(path))//判断原文件是否存在
                        {
                            File.Delete(path);
                        }
                        string swfpath = MLMGC.COMP.Config.GetWenKu("swf\\" + filename.Substring(0, filename.LastIndexOf(".")) + ".swf");
                        if (File.Exists(swfpath)) //判断swf文件是否存在
                        {
                            File.Delete(swfpath);
                        }
                    }
                    flag = true;
                }
            }

            HttpContext.Current.Response.Write(flag ? "1" : "0");
        }

        /// <summary>
        /// 转换文档
        /// </summary>
        private void Convert()
        {
            string ids = nv["ids"];
            if (!MLMGC.COMP.StringUtil.IsStringArrayList(ids))//判断格式是否正确 格式：1,21,321
            {
                HttpContext.Current.Response.Write("参数错误");
                return;
            }

            E_WenKu data = new E_WenKu();
            data.WenKuIDs = ids;

            ///获取要转换的文库列表
            DataTable dt = new T_WenKu().ConvertList(data);

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    //先检测要创建的txt文本是否存在，若存在则删除
                    string path = MLMGC.COMP.Config.MonitorFilePath + row["WenKuID"].ToString() + ".txt";
                    if(File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    //再创建 转换文档为swf
                    System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                    sw.WriteLine(string.Format("\r\n{0}|{1}", row["WenKuID"], row["FileUrl"]));
                    sw.Close();
                    fs.Close();
                }
                HttpContext.Current.Response.Write("1");
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("0");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}