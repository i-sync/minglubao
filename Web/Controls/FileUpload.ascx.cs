using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using MLMGC.DataEntity;
using Newtonsoft.Json;
using System.Text;
using MLMGC.COMP;

namespace Web.Controls
{
    public partial class FileUpload : System.Web.UI.UserControl
    {
        #region 控件参数设置

        private string _folder = ConfigurationManager.AppSettings["Folder"].ToString();//上传文件的存放物理路径
        private string _virtualPath = ConfigurationManager.AppSettings["VirtualPath"].ToString();//自定义文件的虚拟路径分类目录
        private string _virtualPath2 = ConfigurationManager.AppSettings["VirtualPath"].ToString();//上传文件的虚拟路径
        private int _simUploadLimit = int.Parse(ConfigurationManager.AppSettings["SimUploadLimit"].ToString());//上传文件的个数
        private long _sizeLimit = long.Parse(ConfigurationManager.AppSettings["SizeLimit"].ToString());//上传文件大小50M,单位字节
        private string _fileExt = ConfigurationManager.AppSettings["FileExt"].ToString();//上传文件类型
        private bool _IsHave = bool.Parse(ConfigurationManager.AppSettings["IsHave"].ToString());//是否必须上传文件
        private string _funName = string.Empty;//方法名称        
        #region 属性
        /// <summary>
        /// js方法名称
        /// </summary>
        public string FunName { get { return _funName; } set { _funName = value; } }
        /// <summary>
        /// 存放路径,可设置此属性自定义文件保存路径,默认E:\名路宝\
        /// </summary>
        [CategoryAttribute("存放路径"), DescriptionAttribute(@"可设置此属性自定义文件保存路径,默认E:\名路宝\")]
        public string Folder
        {
            get
            {
                return _folder;
            }
            set
            {
                _folder = value;
            }
        }

        /// <summary>
        /// 可设置此属性自定义文件的虚拟路径分类目录,默认根目录/
        /// </summary>
        [CategoryAttribute("文件虚拟路径"), DescriptionAttribute(@"可设置此属性自定义文件的虚拟路径分类目录,默认根目录/")]
        public string VirtualPath
        {
            get
            {
                return _virtualPath;
            }
            set
            {
                _virtualPath = value;
            }
        }

        /// <summary>
        /// 可设置此属性自定义文件的虚拟路径,默认根目录/
        /// </summary>
        [CategoryAttribute("文件虚拟路径"), DescriptionAttribute(@"可设置此属性自定义文件的虚拟路径,默认根目录/")]
        public string VirtualPath2
        {
            get
            {
                return _virtualPath2;
            }
            set
            {
                _virtualPath2 = value;
            }
        }

        /// <summary>
        /// 上传文件的个数
        /// </summary>
        [CategoryAttribute("ID Settings"), DescriptionAttribute("SimUploadLimit of the customer")]
        public int SimUploadLimit
        {
            get
            {
                return _simUploadLimit;
            }
            set
            {
                _simUploadLimit = value;
            }
        }

        /// <summary>
        /// 上传文件大小
        /// </summary>
        [CategoryAttribute("SizeLimit Settings"), DescriptionAttribute("SizeLimit of the customer")]
        public long SizeLimit
        {
            get
            {
                return _sizeLimit;
            }
            set
            {
                _sizeLimit = value;
            }
        }

        /// <summary>
        /// 上传文件类型
        /// </summary>
        [CategoryAttribute("FileExt Settings"), DescriptionAttribute("FileExt of the customer")]
        public string FileExt
        {
            get
            {
                return _fileExt;
            }
            set
            {
                _fileExt = value.ToLower();
            }
        }

        /// <summary>
        /// 是否必须上传文件
        /// </summary>
        [CategoryAttribute("是否必须上传文件"), DescriptionAttribute("是否必须上传文件,默认必须")]
        public bool IsHave
        {
            get
            {
                return _IsHave;
            }
            set
            {
                _IsHave = value;
            }
        }
        /// <summary>
        /// 是否有上传文件
        /// </summary>
        [CategoryAttribute("是否有上传文件"), DescriptionAttribute("是否有上传文件")]
        public bool HasFiles
        {
            get
            {
                return Request.Files.Count > 1;
            }
        }

        #endregion

        #endregion

        #region 绑定字段名属性

        private string _fieldID = "ID"; //绑定文件ID字段名
        private string _fieldName = "Nvar_AName"; //绑定文件名称字段名
        private string _fieldAddress = "NVar_AAddr"; //绑定文件地址字段名
        private string _fieldSize = "Float_ASize"; //绑定文件大小字段名
        private string _fileType = "Nvar_AType";//绑定文件类型字段名
        ///// <summary>
        ///// 创建一个空的DataTable
        ///// </summary>
        ///// <returns></returns>
        //public DataTable CreateFileTable()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add(new DataColumn(""));
        //    return dt;
        //}
        /// <summary>
        /// 绑定文件ID字段名,默认值ID
        /// </summary>
        public string FieldID
        {
            get
            {
                return _fieldID;
            }
            set
            {
                _fieldID = value;
            }
        }

        /// <summary>
        /// 绑定文件类型字段名,默认值Nvar_AType
        /// </summary>
        public string FileType
        {
            get { return _fileType; }
            set { _fileType = value; }
        }
        /// <summary>
        /// 绑定文件名称字段名,默认值Nvar_AName
        /// </summary>
        public string FieldName
        {
            get
            {
                return _fieldName;
            }
            set
            {
                _fieldName = value;
            }
        }
        /// <summary>
        /// 绑定文件地址字段名,默认值Var_AAddr
        /// </summary>
        public string FieldAddress
        {
            get
            {
                return _fieldAddress;
            }
            set
            {
                _fieldAddress = value;
            }
        }
        /// <summary>
        /// 绑定文件大小字段名,默认值Float_ASize
        /// </summary>
        public string FieldSize
        {
            get
            {
                return _fieldSize;
            }
            set
            {
                _fieldSize = value;
            }
        }

        #endregion

        #region 全局变量

        private bool _uploadFinish = false;//是否上传完成,如果为False则说明上传出错了!
        /// <summary>
        /// 是否上传完成,如果为False则说明上传出错了!
        /// </summary>
        public bool UploadFinish
        {
            get
            {
                return _uploadFinish;
            }
            set
            {
                _uploadFinish = value;
            }
        }

        public int mflFileCount = 0;//反显记录数目

        #endregion

        #region 反显列表

        /// <summary>
        /// 初始化文件列表
        /// </summary>
        public void BindList(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                List<PFileInfo> list = new List<PFileInfo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //生成反显文件列表
                    OldFileList.InnerHtml = OldFileList.InnerHtml + "<li><span><a href='" + ConfigurationManager.AppSettings["ServerPath"].ToString() + "/" + ConfigurationManager.AppSettings["VirtualName"].ToString() + "/" + _virtualPath + dt.Rows[i][_fieldAddress].ToString() + "' target='_blank'>" + dt.Rows[i][_fieldName].ToString() + "</a></span>&nbsp;<img src='/images/del.jpg' onclick='" + this.ID + "_mflRemoveOldFile(this,\"" + dt.Rows[i][_fieldName].ToString() + "\")' /></li>";
                    //list.Add(new PFileInfo(dt.Rows[i][_fieldName].ToString(), float.Parse(dt.Rows[i][_fieldSize].ToString()), dt.Rows[i][_fieldAddress].ToString())); 没有附件大小 齐鹏飞 2011-04-15
                    list.Add(new PFileInfo(dt.Rows[i][_fieldName].ToString(), "0", dt.Rows[i][_fieldAddress].ToString(), dt.Rows[i][_fileType].ToString(),string.Empty));
                }

                hdOldFileList.Value = JavaScriptConvert.SerializeObject(list);
                mflFileCount = dt.Rows.Count;
            }
        }

        /// <summary>
        /// 初始化文件列表
        /// </summary>
        public void BindList(string FileName, string FileSize,string FileType, string FileAddress)
        {

            List<PFileInfo> list = new List<PFileInfo>();

            //生成反显文件列表
            OldFileList.InnerHtml = OldFileList.InnerHtml + "<li><span><a href='" + ConfigurationManager.AppSettings["ServerPath"].ToString() + "/" + ConfigurationManager.AppSettings["VirtualName"].ToString() + "/" + _virtualPath + FileAddress.ToString() + "' target='_blank'>" + FileName.ToString() + "</a></span>&nbsp;<img src='/images/del.jpg' onclick='" + this.ID + "_mflRemoveOldFile(this,\"" + FileName.ToString() + "\")' /></li>";
            list.Add(new PFileInfo(FileName.ToString(), FileSize, FileAddress.ToString(), FileType,string.Empty));

            hdOldFileList.Value = JavaScriptConvert.SerializeObject(list);
            mflFileCount = 1;

        }

        #endregion

        #region 上传文件        
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="filename">默认为空</param>
        /// <returns>当返回值为空，表示上传错误</returns>
        public List<PFileInfo> Upload(string filename=null)
        {

            List<PFileInfo> list = new List<PFileInfo>();

            #region 新增上传文件保存
            if (Request.Files.Count > 1)
            {
                StringBuilder sbFileName = new StringBuilder();
                try
                {
                    for (int i = 0; i < Request.Files.Count - 1; i++)
                    {
                        //if (Request.Files[i].ContentLength > 0)
                        //{

                        //文件类型
                        string fileType = Request.Files[i].FileName.Substring(Request.Files[i].FileName.LastIndexOf('.'));
                        #region 判断文件类型是否可上传
                        if (_fileExt.IndexOf("|" + fileType.ToLower() + "") == -1)
                        {
                            //TipContent.InnerText = "上传文件类型错误!";
                            //不是指定文件类型则跳过
                            _uploadFinish = false;
                            Jscript.ShowMsg("信息提示:上传文件类型错误", this);
                            return null;
                        }
                        #endregion

                        #region 判断文件大小是否超过
                        string MoveExt = "|.wav|.wma|.mp2|.mp3|.asf|.rm|.rmvb|.mpg|.3gp|.mp4|.flv|.wmv|";
                        if (MoveExt.IndexOf("|" + fileType.ToLower() + "") == -1)
                        {
                            if (Request.Files[i].ContentLength > _sizeLimit)
                            {
                                //TipContent.InnerText = "上传文件太大!";
                                //跳出循环
                                _uploadFinish = false;
                                Jscript.ShowMsg("信息提示:上传文件过大", this);
                                return null;
                            }
                        }

                        #endregion

                        //文件显示名称
                        string newFileTitle = Request.Files[i].FileName.Substring(Request.Files[i].FileName.LastIndexOf('\\') + 1);
                        //文件名 
                        string newFileName = filename + Request.Files[i].FileName.Substring(Request.Files[i].FileName.LastIndexOf('.'));
                        if (string.IsNullOrEmpty(filename))//判断是否指定文件名
                        {
                            newFileName = DateTime.Now.Ticks.ToString() + Request.Files[i].FileName.Substring(Request.Files[i].FileName.LastIndexOf('.'));
                        }
                        // DateTime.Now.ToString("HHmmssms" + i) + "_" + Request.Files[i].FileName.Substring(Request.Files[i].FileName.LastIndexOf('\\') + 1);
                        //文件保存物理路径
                        //修改_virtualPath2路径 如果存在 "YWBL/"不追加时间:lzz
                        string newFilePath = "";
                        //齐鹏飞 注释2011-04-18
                        //if (_virtualPath2.Substring(0, _virtualPath2.IndexOf('/') + 1).Contains("YWBL/"))
                        //{
                        //    newFilePath = _folder + _virtualPath.Replace("/", "\\") + "\\" + _virtualPath2.Replace("/", "\\");
                        //}
                        //else
                        //{
                        //    newFilePath = _folder + _virtualPath.Replace("/", "\\") + "\\" + _virtualPath2.Replace("/", "\\") + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\";
                        //}
                        //newFilePath = _folder + _virtualPath.Replace("/", "\\") + "\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\";
                        newFilePath = _folder + _virtualPath.Replace("/", "\\");
                        System.IO.Directory.CreateDirectory(newFilePath);
                        //文件大小,单位字节

                        string fileSize = Request.Files[i].ContentLength.ToString();

                        Request.Files[i].SaveAs(newFilePath  + newFileName);
                        #region 将上传成功的文件信息保存至list中
                        //修改_virtualPath2路径 如果存在 "YWBL/"不追加时间:lzz   齐鹏飞 注释 2011-04-18
                        //if (_virtualPath2.Substring(0, _virtualPath2.IndexOf('/') + 1).Contains("YWBL/"))
                        //{

                        //    list.Add(new PFileInfo(newFileName, fileSize, "/" + _virtualPath2 + newFileName));
                        //}
                        //else
                        //{
                        //    list.Add(new PFileInfo(newFileName, fileSize, "/" + _virtualPath2 + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/" + newFileName));
                        //}
                        //list.Add(new PFileInfo(newFileTitle, fileSize, "/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/" + newFileName, fileType));
                        list.Add(new PFileInfo(newFileTitle, fileSize, newFileName, fileType,newFilePath));
                        #endregion
                        if (Request.Files.Count - 1 == list.Count)
                        {
                            _uploadFinish = true;
                        }
                        //}
                    }
                }
                catch (Exception ex)
                {
                    TipContent.InnerText = "上传文件出错!<br>" + ex.ToString();
                    _uploadFinish = false;
                }
            }
            else
            {
                _uploadFinish = true;
            }
            #endregion

            #region 判断是否继续,false删除已上传附件

            if (!_uploadFinish)
            {
                //上传出现错误,则删除list中已上传附件
                for (int i = 0; i < list.Count; i++)
                {
                    //删除文件
                    DeleteFile(_folder.Substring(0, _folder.Length - 1) + "\\" + _virtualPath.Replace("/", "\\") + list[i].FileAddress.Replace("/", "\\"));
                }
            }
            else
            {
                #region 删除反显文件

                if (hdDelFileList.Value != "" && hdDelFileList.Value != "[]")
                {
                    List<PFileInfo> listDel = (List<PFileInfo>)JavaScriptConvert.DeserializeObject(hdDelFileList.Value.ToString(), typeof(List<PFileInfo>));
                    for (int i = 0; i < listDel.Count; i++)
                    {
                        //删除文件
                        DeleteFile(_folder.Substring(0, _folder.Length - 1) + "\\" + _virtualPath.Replace("/", "\\") + listDel[i].FileAddress.Replace("/", "\\"));
                    }
                }

                #endregion

                #region 将新增文件与未删除的反显文件组合

                if (hdOldFileList.Value != "" && hdOldFileList.Value != "[]")
                {
                    List<PFileInfo> listOld = (List<PFileInfo>)JavaScriptConvert.DeserializeObject(hdOldFileList.Value.ToString(), typeof(List<PFileInfo>));
                    listOld.AddRange(list);
                    list = listOld;
                }

                #endregion
            }
            #endregion

            ////没有选择上传文件
            //if (_uploadFinish && _IsHave)
            //{
            //    if (list == null)
            //    {
            //        TipContent.InnerText = "请上传文件!";
            //        _uploadFinish = false;
            //    }
            //    else if (list.Count == 0)
            //    {
            //        TipContent.InnerText = "请上传文件!";
            //        _uploadFinish = false;
            //    }
            //}

            return list;
        }

        #endregion

        #region 同一页面多控件上传文件

        /// <summary>
        /// 同一页面多控件上传文件
        /// 注意参数中的数组数一般有一个为页面中显示的当前控件,是不需要上传的.
        /// 所以一般参数中的数组个数应为新上传文件个数+1
        /// </summary>
        /// <param name="oHttpFileCollection"></param>
        /// <returns></returns>
        public List<PFileInfo> Upload(List<HttpPostedFile> oHttpFileCollection)
        {

            List<PFileInfo> list = new List<PFileInfo>();

            #region 新增上传文件保存
            if (oHttpFileCollection.Count > 1)
            {
                StringBuilder sbFileName = new StringBuilder();
                try
                {
                    for (int i = 0; i < oHttpFileCollection.Count - 1; i++)
                    {
                        //if (oHttpFileCollection[i].ContentLength > 0)
                        //{
                        #region 判断文件大小是否超过

                        if (oHttpFileCollection[i].ContentLength > _sizeLimit)
                        {
                            //TipContent.InnerText = "上传文件太大!";
                            //跳出循环
                            break;
                        }

                        #endregion
                        //文件类型
                        string fileType = oHttpFileCollection[i].FileName.Substring(oHttpFileCollection[i].FileName.LastIndexOf('.'));
                        #region 判断文件类型是否可上传
                        if (_fileExt.IndexOf("|" + fileType.ToLower() + "") == -1)
                        {
                            TipContent.InnerText = "上传文件类型错误!";
                            //不是指定文件类型则跳过
                            continue;
                        }
                        #endregion
                        //文件名
                        string newFileName = DateTime.Now.ToString("HHmmssms" + i) + "_" + oHttpFileCollection[i].FileName.Substring(oHttpFileCollection[i].FileName.LastIndexOf('\\') + 1);
                        //文件保存物理路径
                        //修改_virtualPath2路径 如果存在 "YWBL/"不追加时间:lzz
                        string newFilePath = "";
                        if (_virtualPath2.Substring(0, _virtualPath2.IndexOf('/') + 1).Contains("YWBL/"))
                        {
                            newFilePath = _folder + _virtualPath.Replace("/", "\\") + "\\" + _virtualPath2.Replace("/", "\\");
                        }
                        else
                        {
                            newFilePath = _folder + _virtualPath.Replace("/", "\\") + "\\" + _virtualPath2.Replace("/", "\\") + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\";
                        }
                        System.IO.Directory.CreateDirectory(newFilePath);
                        //文件大小,单位字节
                        string fileSize = oHttpFileCollection[i].ContentLength.ToString();
                        oHttpFileCollection[i].SaveAs(newFilePath + newFileName);
                        #region 将上传成功的文件信息保存至list中
                        //修改_virtualPath2路径 如果存在 "YWBL/"不追加时间:lzz
                        if (_virtualPath2.Substring(0, _virtualPath2.IndexOf('/') + 1).Contains("YWBL/"))
                        {

                            list.Add(new PFileInfo(newFileName, fileSize, "/" + _virtualPath2 + newFileName, fileType,string.Empty));
                        }
                        else
                        {
                            list.Add(new PFileInfo(newFileName, fileSize, "/" + _virtualPath2 + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/" + newFileName, fileType,string.Empty));
                        }
                        #endregion
                        if (oHttpFileCollection.Count - 1 == list.Count)
                        {
                            _uploadFinish = true;
                        }
                        //}
                    }
                }
                catch (Exception ex)
                {
                    TipContent.InnerText = "上传文件出错!<br>" + ex.ToString();
                    _uploadFinish = false;
                }
            }
            else
            {
                _uploadFinish = true;
            }
            #endregion

            #region 判断是否继续,false删除已上传附件

            if (!_uploadFinish)
            {
                //上传出现错误,则删除list中已上传附件
                for (int i = 0; i < list.Count; i++)
                {
                    //删除文件
                    DeleteFile(_folder.Substring(0, _folder.Length - 1) + "\\" + _virtualPath.Replace("/", "\\") + list[i].FileAddress.Replace("/", "\\"));
                }
            }
            else
            {
                #region 删除反显文件

                if (hdDelFileList.Value != "" && hdDelFileList.Value != "[]")
                {
                    List<PFileInfo> listDel = (List<PFileInfo>)JavaScriptConvert.DeserializeObject(hdDelFileList.Value.ToString(), typeof(List<PFileInfo>));
                    for (int i = 0; i < listDel.Count; i++)
                    {
                        //删除文件
                        DeleteFile(_folder.Substring(0, _folder.Length - 1) + "\\" + _virtualPath.Replace("/", "\\") + listDel[i].FileAddress.Replace("/", "\\"));
                    }
                }

                #endregion

                #region 将新增文件与未删除的反显文件组合

                if (hdOldFileList.Value != "" && hdOldFileList.Value != "[]")
                {
                    List<PFileInfo> listOld = (List<PFileInfo>)JavaScriptConvert.DeserializeObject(hdOldFileList.Value.ToString(), typeof(List<PFileInfo>));
                    listOld.AddRange(list);
                    list = listOld;
                }

                #endregion
            }
            #endregion

            if (_uploadFinish && _IsHave)
            {
                if (list == null)
                {
                    TipContent.InnerText = "请上传文件!";
                    _uploadFinish = false;
                }
                else if (list.Count == 0)
                {
                    TipContent.InnerText = "请上传文件!";
                    _uploadFinish = false;
                }
            }

            return list;
        }

        #endregion

        #region 删除指定文件

        /// <summary>
        /// 删除指定路径下的单个文件
        /// </summary>
        /// <param name="FileFolder">文件路径</param>
        void DeleteFile(string FileFolder)
        {
            try
            {
                System.IO.File.Delete(FileFolder);
            }
            catch
            { }

        }

        #endregion

        #region 上传按钮

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 获取新上传文件数量

        /// <summary>
        /// 获取新上传文件数量
        /// </summary>
        /// <returns></returns>
        public int GetNewFileCount()
        {
            if (hdNewFileCount.Value.ToString() == "")
            {
                return 1;
            }
            return int.Parse(hdNewFileCount.Value.ToString()) + 1;
        }

        #endregion

        #region 根据控件索引及文件数量返回上传文件对象

        /// <summary>
        /// 根据控件索引及文件数量返回上传文件对象
        /// </summary>
        /// <param name="iIndex">控件在页面中所有上传控件的索引序号</param>
        /// <param name="iFileCount">控件中上传文件的数量</param>
        /// <returns></returns>
        public List<HttpPostedFile> ReturnHttpFileCollection(int iIndex, int iFileCount)
        {
            List<HttpPostedFile> oHttpPostedFiles = new List<HttpPostedFile>();
            for (int i = iIndex; i < iIndex + iFileCount; i++)
            {
                oHttpPostedFiles.Add(Request.Files[i]);
            }
            return oHttpPostedFiles;
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            //添加浏览按钮选择事件
            mflFileUpload.Attributes.Add("onchange", this.ID + "_AddFile(this)");
        }

        #endregion
    }
}