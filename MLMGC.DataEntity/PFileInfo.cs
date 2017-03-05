using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity
{
    /// <summary>
    /// 文件上传实体类
    /// </summary>
    public class PFileInfo
    {

        public PFileInfo()
        { }

        public PFileInfo(string fileName, string fileSize, string fileAddress, string fileType, string filePath)
        {
            this._fileName = fileName;
            this._fileSize = fileSize;
            this._fileAddress = fileAddress;
            this.FileType = fileType;
            this.FilePath = filePath;
        }
        public PFileInfo(string fileName, string filePath)
        {
            this._fileName = fileName;
            this._filePath = filePath;
        }

        private string _fileID;
        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID
        {
            get { return _fileID; }
            set { _fileID = value; }
        }

        private string _fileName;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private string _fileSize;
        /// <summary>
        /// 文件大小
        /// </summary>
        public string FileSize
        {
            get { return _fileSize; }
            set { _fileSize = value; }
        }

        /// <summary>
        /// 文件类型（如：.doc）
        /// </summary>
        public string FileType { get; set; }

        private string _filePath;
        /// <summary>
        /// 文件物理路径
        /// </summary>
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        private string _fileAddress;
        /// <summary>
        /// 文件虚拟路径
        /// </summary>
        public string FileAddress
        {
            get { return _fileAddress; }
            set { _fileAddress = value; }
        }

        private bool _isNew;
        /// <summary>
        /// 是否新增
        /// </summary>
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        #region 批量上传扩展参数

        private int _int_FCDID; //父文件夹ID；
        /// <summary>
        /// 父文件夹ID
        /// </summary>
        public int Int_FCDID
        {
            get { return _int_FCDID; }
            set { _int_FCDID = value; }
        }

        private string _folderName; //文件夹名称
        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string FolderName
        {
            get { return _folderName; }
            set { _folderName = value; }
        }

        private string _var_StaffID; //当前操作人
        /// <summary>
        /// 当前操作人
        /// </summary>
        public string Var_StaffID
        {
            get { return _var_StaffID; }
            set { _var_StaffID = value; }
        }

        private string _var_CTranID; //项目业务ID

        /// <summary>
        /// 项目业务ID
        /// </summary>
        public string Var_CTranID
        {
            get { return _var_CTranID; }
            set { _var_CTranID = value; }
        }

        /// <summary>
        /// 文件大小字符串
        /// </summary>
        public string FileSizeStr
        {
            get;
            set;
        }

        /// <summary>
        /// 判断是否是上传根目录文件
        /// </summary>
        public int Int_IsFirst
        {
            get;
            set;
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public string Nvar_StaffName
        {
            get;
            set;
        }

        #endregion
    }
}
