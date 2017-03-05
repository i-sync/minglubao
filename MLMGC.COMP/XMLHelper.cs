using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MLMGC.COMP
{
    public class XMLHelper
    {
        /// <summary>
        /// 获取Flash XML对象
        /// </summary>
        public static configuration GetFlashXML()
        {
            string path = HttpContext.Current.Server.MapPath("~/Flash/app.xml");

            return SerializationHelper.Load<configuration>(path);
        }
    }

    /// <summary>
    /// XML配置对象（ ViewWeb.Flash.app.xml ）
    /// </summary>
    public class configuration
    {
        public string urlHttp { get; set; }
        public string urlRtmp { get; set; }
        public string urlRtmpFailed { get; set; }
        public string delayRtmpFailed { get; set; }
        public string urlFMS { get; set; }
        public string urlUploadRequest { get; set; }
        public string urlFileBaseRep { get; set; }
        public string urlFileBase { get; set; }
        public string  UrlHandle { get; set; }
        public string  TalkPlayUrlFMS { get; set; }

    }
}
