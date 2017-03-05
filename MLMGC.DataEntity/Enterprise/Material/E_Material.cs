using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise.Material
{
    /// <summary>
    /// 项目资料
    /// </summary>
    [Serializable]
    public class E_Material
    {
        private long _materialid;
        private int _enterpriseid;
        private string _materialname;
        private string _classname;
        private DateTime _updatedate;

        private string _filename;
        private string _url;
        private string _filetype;
        private int _filesize;
        /// <summary>
        /// 项目资料编号
        /// </summary>
        public long MaterialID
        {
            get { return _materialid; }
            set { _materialid = value; }
        }
        /// <summary>
        /// Enterprise.EnterpriseID
        /// </summary>
        public int EnterpriseID
        {
            get { return _enterpriseid; }
            set { _enterpriseid = value; }
        }
        /// <summary>
        /// 项目资料标题
        /// </summary>
        public string MaterialName
        {
            get { return _materialname; }
            set { _materialname = value; }
        }
        /// <summary>
        /// 项目资料分类
        /// </summary>
        public string ClassName
        {
            get { return _classname; }
            set { _classname = value; }
        }

        /// <summary>
        /// 项目资料更新时间
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _updatedate; }
            set { _updatedate = value; }
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

        /// <summary>
        /// 分页参数
        /// </summary>
        public E_Page Page { get; set; }


        private EnumWenKuFlag _wenkuflag;
        /// <summary>
        /// 文库标识(0=未共享，1=提交共享，2=共享成功，3=审核未通过)
        /// </summary>
        public EnumWenKuFlag WenKuFlag { get { return _wenkuflag; } set { _wenkuflag = value; } }
        /// <summary>
        /// 文库标识(0=未共享，1=提交共享，2=共享成功，3=审核未通过)
        /// </summary>
        public int SetWenKuFlag
        {
            set
            {
                switch (value)
                { 
                    case 0:
                        _wenkuflag = EnumWenKuFlag.未共享;
                        break;
                    case 1:
                        _wenkuflag = EnumWenKuFlag.待审核;
                        break;
                    case 2:
                        _wenkuflag = EnumWenKuFlag.审核通过;
                        break;
                    case 3:
                        _wenkuflag = EnumWenKuFlag.审核未通过;
                        break;
                }
            }
        }

        /// <summary>
        /// 文库编号
        /// </summary>
        public long WenKuID { get; set; }

        private EnumMaterialType _materialtype;
        /// <summary>
        /// 资料分类 1=项目资料,2=学习资料
        /// </summary>
        public EnumMaterialType MaterialType { get { return _materialtype; } set { _materialtype = value; } }
        /// <summary>
        /// 资料分类 1=项目资料,2=学习资料
        /// </summary>
        public int SetMaterialType
        {
            set
            {
                if (value == 1)
                    _materialtype = EnumMaterialType.项目资料;
                else
                    _materialtype = EnumMaterialType.学习资料;
            }
        }

    }

    /// <summary>
    /// 文库标识(0=未共享，1=提交共享，2=共享成功，3=审核未通过)
    /// </summary>
    public enum EnumWenKuFlag
    { 
        未共享=0,
        待审核=1,
        审核通过=2,
        审核未通过=3
    }

    /// <summary>
    /// 资料分类 1=项目资料,2=学习资料
    /// </summary>
    public enum EnumMaterialType
    {
        项目资料=1,
        学习资料=2
    }
}
