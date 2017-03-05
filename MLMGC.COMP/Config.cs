using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MLMGC.COMP
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 分割符（用于数据库StrSplit函数）
        /// </summary>
        public static string Separation
        {
            get { return "々"; }
        }
        /// <summary>
        /// 根目录 http://www.minglubao.com
        /// </summary>
        public static string RootURL
        {
            get { return GetAppSettings("ServerPath"); }
        }
        /// <summary>
        /// 无数据时显示
        /// </summary>
        public static string NoDataTips { get { return "对不起，暂无数据！"; } }
        /// <summary>
        /// 无数据时显示 Tr
        /// </summary>
        /// <param name="rowNum">需要合并的单元格数量</param>
        public static string NoDataTr(int rowNum) { return string.Format("<tr><td colspan='{0}'>{1}</td></tr>", rowNum, NoDataTips); }
        /// <summary>
        /// 当itemCount等于0时，显示 Tr
        /// </summary>
        /// <param name="itemCount"></param>
        /// <param name="rowNum"></param>
        /// <returns></returns>
        public static string NoDataTr(int itemCount, int rowNum) { return itemCount > 0 ? "" : string.Format("<tr><td colspan='{0}'>{1}</td></tr>", rowNum, NoDataTips); }

        #region 网站路径 例如：http://www.minglubao.com/resource/
        /// <summary>
        /// 资源根目录
        /// </summary>
        public static string ResourceUrl
        {
            get { return ConfigurationManager.AppSettings["ServerPath"].ToString() + "/" + ConfigurationManager.AppSettings["VirtualName"].ToString() + "/"; }
        }

        /// <summary>
        /// 企业项目资料上传文件URL(http://www.minglubao.com/Resource/EnterpriseMaterial/)
        /// </summary>
        public static string EnterpriseMaterialUrl
        {
            get { return ResourceUrl + GetAppSettings("EnterpriseMaterial"); }
        }
        /// <summary>
        /// 企业学习资料上传文件URL(http://www.minglubao.com/Resource/EnterpriseStudy/)
        /// </summary>
        public static string EnterpriseStudyUrl
        {
            get { return ResourceUrl + GetAppSettings("EnterpriseStudy"); }
        }

        /// <summary>
        /// 文库上传文件URL(http://www.minglubao.com/Resource/WenKu/)
        /// </summary>
        public static string WenKuUrl
        {
            get { return ResourceUrl + GetAppSettings("WenKu"); }
        }
        #endregion

        #region 服务器物理路径 例如：E:\minglubao\Resource\
        
        /// <summary>
        /// 获取FlashPrinter路径（D:\Backup\我的文档\下载\FlashPaper2.2\FlashPrinter.exe）
        /// </summary>
        public static string FlashPrinterPath
        {
            get { return GetAppSettings("Printer"); }
        }

        /// <summary>
        /// 获取监控文件路径（E:\名录宝\MLMGC\Monitor\Temp\）
        /// </summary>
        public static string MonitorFilePath
        {
            get { return GetAppSettings("MonitorPath"); }
        }

        /// <summary>
        /// 获取WenKu路径
        /// </summary>
        public static string WenKuFolder
        {
            get { return GetAppSettings("WenKu"); }
        }
        /// <summary>
        /// 企业项目资料上传路径(material)
        /// </summary>
        public static string EnterpriseMaterialFolder
        {
            get { return GetAppSettings("EnterpriseMaterial"); }
        }
        /// <summary>
        /// 企业学习资料上传路径(study)
        /// </summary>
        public static string EnterpriseStudyFolder
        {
            get { return GetAppSettings("EnterpriseStudy"); }
        }

        /// <summary>
        /// 企业用户上传头像路径
        /// </summary>
        public static string EnterpriseAvatarFolder
        {
            get { return GetAppSettings("EnterpriseAvatar"); }
        }

        /// <summary>
        /// 企业项目照片路径
        /// </summary>
        public static string EnterpriseItemPhotoFolder
        {
            get { return GetAppSettings("EnterpriseItemPhoto"); }
        }

        /// <summary>
        ///个人用户上传头像路径
        /// </summary>
        public static string PersonalAvatarFolder
        {
            get { return GetAppSettings("PersonalAvatar"); }
        }
        /// <summary>
        /// 个人数据接口文件夹
        /// </summary>
        public static string PersonalDataFoler
        {
            get { return GetAppSettings("PersonalData"); }
        }

        /// <summary>
        /// 企业数据接口文件夹
        /// </summary>
        public static string EnterpriseDataFoler
        {
            get { return GetAppSettings("EnterpriseData"); }
        }

        /// <summary>
        /// 问题反馈附件路径
        /// </summary>
        public static string FeedbackFolder
        {
            get { return GetAppSettings("Feedback"); }
        }

        /// <summary>
        /// 网站通用上传文件路径
        /// </summary>
        public static string UploadFileFolder
        {
            get { return GetAppSettings("Web"); }
        }

        /// <summary>
        /// 获取企业项目资料物理路径 例如：E:\minglubao\Resource\EnterpriseMaterial\xxxxxx.doc
        /// </summary>
        /// <param name="EnterpriseID"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetEnterpriseM(int EnterpriseID, string FileName)
        {
            if (string.IsNullOrEmpty(FileName)) { return string.Empty; }
            return GetAppSettings("Folder") + EnterpriseMaterialFolder + "\\" + EnterpriseID.ToString() + "\\" + FileName;
        }

        /// <summary>
        /// 获取企业学习资料物理路径 例如：E:\minglubao\Resource\EnterpriseStudy\xxxxxx.doc
        /// </summary>
        /// <param name="EnterpriseID"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetEnterpriseS(int EnterpriseID, string FileName)
        {
            if (string.IsNullOrEmpty(FileName)) { return string.Empty; }
            return GetAppSettings("Folder") + EnterpriseStudyFolder + "\\" + EnterpriseID.ToString() + "\\" + FileName;
        }

        /// <summary>
        /// 获取文库资料物理路径 例如：E:\minglubao\Resource\WenKu\xxxxxx.doc
        /// </summary>
        /// <param name="EnterpriseID"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string GetWenKu(string FileName)
        {
            if (string.IsNullOrEmpty(FileName)) { return string.Empty; }
            return GetAppSettings("Folder") + WenKuFolder + "\\" + FileName;
        }

        #endregion

        #region  获取url地址显示
        /// <summary>
        /// 获取企业项目资料，显示路径
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetEnterpriseMaterialUrl(int EnterpriseID,string url)
        {
            return EnterpriseMaterialUrl + "/" + EnterpriseID.ToString() + "/" + url;
        }
        /// <summary>
        /// 获取企业学习资料，显示路径
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetEnterpriseStudyUrl(int EnterpriseID, string url)
        {
            return EnterpriseStudyUrl + "/" + EnterpriseID.ToString() + "/" + url;
        }

        /// <summary>
        /// 获取企业用户头像Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetEnterpriseAvatarUrl(string url)
        {
            return string.IsNullOrEmpty(url) ? "/images/guanliyuan.jpg" : "/" + GetAppSettings("VirtualName") + "/" + EnterpriseAvatarFolder + "/" + url;
        }

        /// <summary>
        /// 获取个人用户头像Url 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetPersonalAvatarUrl(string url)
        { 
            return string.IsNullOrEmpty(url)?"/images/guanliyuan.jpg" : "/" + GetAppSettings("VirtualName") + "/" + PersonalAvatarFolder + "/" + url;
        }

        /// <summary>
        /// 获取文库文档Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <remarks>tianzhenyun 2012-03-15</remarks>
        public static string GetWenKuUrl(string url)
        {
            return WenKuUrl + "/" + url;
        }

        /// <summary>
        /// 获取企业项目照片URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetEnterpriseItemPhotoUrl(string url)
        {
            return string.IsNullOrEmpty(url) ? "" : "/" + GetAppSettings("VirtualName") + "/" + EnterpriseItemPhotoFolder + "/" + url;
        }
        #endregion
        /// <summary>
        /// 导入文件类型
        /// </summary>
        public static string ImportingExt
        {
            get
            {
                return GetAppSettings("ImportingExt");
            }
        }
        /// <summary>
        /// 读取自定义的资源显示信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetUrl(string key)
        {
            return ResourceUrl + GetAppSettings(key);
        }
        /// <summary>
        /// 获取默认警告的天数
        /// </summary>
        public static int WarningDay
        {
            get
            {
                return Convert.ToInt32(GetAppSettings("WarningDay"));
            }
        }

        /// <summary>
        /// 获取web.config AppSettings值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
