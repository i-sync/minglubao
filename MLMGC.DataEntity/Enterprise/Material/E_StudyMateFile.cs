using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise.Material
{
    /// <summary>
    /// 学习资料附件
    /// </summary>
    [Serializable]
    public class E_StudyMateFile
    {
        private long _studymaterialid;
        private string _filename;
        private string _url;
        private string _filetype;
        private int _filesize;
                
        /// <summary>
        /// 学习资料编号
        /// </summary>
        public long StudyMaterialID
        {
            get { return _studymaterialid; }
            set { _studymaterialid = value; }
        }
        /// <summary>
        /// 附件名称
        /// </summary>
        public string FileName
        {
            get { return _filename; }
            set { _filename = value; }
        }
        /// <summary>
        /// 附件上传的地址
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        /// <summary>
        /// 附件类型
        /// </summary>
        public string FileType
        {
            get { return _filetype; }
            set { _filetype = value; }
        }
        /// <summary>
        /// 文件大小
        /// </summary>
        public int FileSize
        {
            get { return _filesize; }
            set { _filesize = value; }
        }
    }
}
