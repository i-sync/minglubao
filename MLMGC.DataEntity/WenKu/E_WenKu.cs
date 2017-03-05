using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.DataEntity.User;

namespace MLMGC.DataEntity.WenKu
{
    /// <summary>
    /// 文库
    /// </summary>
    public class E_WenKu
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long WenKuID { get; set; }
        /// <summary>
        /// 编号集合
        /// </summary>
        public string WenKuIDs { get; set; }
        /// <summary>
        /// 文库分类编号
        /// </summary>
        public int WenKuClassID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Intro { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keywords { get; set; }
        
        /// <summary>
        /// 文件类型(0=全部,1=doc,2=pdf,3=ppt,4=xls,5=txt)
        /// </summary>
        private EnumFileType _filetype;
        /// <summary>
        /// 文件类型(0=全部,1=doc,2=pdf,3=ppt,4=xls,5=txt)
        /// </summary>
        public EnumFileType FileType { get { return _filetype; } }
        /// <summary>
        /// 文件类型(0=全部,1=doc,2=pdf,3=ppt,4=xls,5=txt)
        /// </summary>
        public int SetFileType
        {
            set {
                switch (value)
                { 
                    case 0:
                        _filetype = EnumFileType.全部;
                        break;
                    case 1:
                        _filetype = EnumFileType.DOC;
                        break;
                    case 2:
                        _filetype = EnumFileType.PDF;
                        break;
                    case 3:
                        _filetype = EnumFileType.PPT;
                        break;
                    case 4:
                        _filetype = EnumFileType.XLS;
                        break;
                    case 5:
                        _filetype = EnumFileType.TXT;
                        break;
                    case 6:
                        _filetype = EnumFileType.其它;
                        break;
                }
            }
        }
        /// <summary>
        /// 配置字符串
        /// </summary>
        public string SetFileType2
        {
            set {
                switch (value.ToUpper())
                { 
                    case ".DOC":
                        _filetype = EnumFileType.DOC;
                        break;
                    case ".PDF":
                        _filetype = EnumFileType.PDF;
                        break;
                    case ".PPT":
                        _filetype = EnumFileType.PPT;
                        break;
                    case ".XLS":
                        _filetype = EnumFileType.XLS;
                        break;
                    case ".TXT":
                        _filetype = EnumFileType.TXT;
                        break;
                    default :
                        _filetype = EnumFileType.其它;
                        break;
                }
            }
        }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public int FileSize { get; set; }
        /// <summary>
        /// 文档路径
        /// </summary>
        public string FileUrl { get; set; }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int ReadNum { get; set; }
        /// <summary>
        /// 下载次数
        /// </summary>
        public int DownNum { get; set; }
        /// <summary>
        /// 上传日期
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime CheckDate { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 企业编号 
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 用户类型：1=企业用户，2=个人用户
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// 状态(0=待审核，1=审核通过，并上线，2=审核未通过，3=下线)
        /// </summary>
        private EnumStatusFlag _statusflag;
        /// <summary>
        /// 状态(0=待审核，1=审核通过，并上线，2=审核未通过，3=下线)
        /// </summary>
        public EnumStatusFlag StatusFlag { get { return _statusflag; } set { _statusflag = value; } }
        /// <summary>
        /// 状态(0=待审核，1=审核通过，并上线，2=审核未通过，3=下线)
        /// </summary>
        public int SetStatusFlag
        {
            set {
                switch (value)
                { 
                    case 0:
                        _statusflag = EnumStatusFlag.待审核;
                        break;
                    case 1:
                        _statusflag = EnumStatusFlag.审核通过且上线;
                        break;
                    case 2:
                        _statusflag = EnumStatusFlag.审核未通过;
                        break;
                    case 3:
                        _statusflag = EnumStatusFlag.下线;
                        break;
                }
            }
        }

        /// <summary>
        ///  文库swf转换状态（0=未转换，1=转换成功，2=转换失败）
        /// </summary>
        private EnumSwfFlag _swfflag;
        /// <summary>
        ///  文库swf转换状态（0=未转换，1=转换成功，2=转换失败）
        /// </summary>
        public EnumSwfFlag SwfFlag { get { return _swfflag; } set { _swfflag = value; } }
        /// <summary>
        ///  文库swf转换状态（0=未转换，1=转换成功，2=转换失败）
        /// </summary>
        public int SetSwfFlag {
            set {
                switch (value)
                { 
                    case 0:
                        _swfflag = EnumSwfFlag.待转换;
                        break;
                    case 1:
                        _swfflag = EnumSwfFlag.转换成功;
                        break;
                    case 2:
                        _swfflag = EnumSwfFlag.转换失败;
                        break;
                }
            }
        }
        /// <summary>
        /// 删除标识(0=删除，1=未删除)
        /// </summary>
        public int DelFlag { get; set; }
        /// <summary>
        /// 自定义分类名称
        /// </summary>
        public string CustomClassName { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public E_Page Page { get; set; }

    }

    /// <summary>
    /// 文件类型(0=全部,1=doc,2=pdf,3=ppt,4=xls,5=txt)
    /// </summary>
    public enum EnumFileType
    { 
        全部=0,
        DOC=1,
        PDF=2,
        PPT=3,
        XLS=4,
        TXT=5,
        其它=6
    }

    /// <summary>
    /// 状态(0=待审核，1=审核通过，并上线，2=审核未通过，3=下线)
    /// </summary>
    public enum EnumStatusFlag
    { 
        待审核=0,
        审核通过且上线=1,
        审核未通过=2,
        下线=3
    }

    /// <summary>
    /// 文库swf转换状态（0=未转换，1=转换成功，2=转换失败）
    /// </summary>
    public enum EnumSwfFlag
    { 
        待转换=0,
        转换成功=1,
        转换失败=2
    }
}
