using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MLMGC.COMP
{
    /// <summary>
    /// 获取邮件内容
    /// </summary>
    public class MailBodyConfig
    {
        private string _title;
        private string _body;
        private bool _isread = false;
        public string Title { get { return _title; } }
        public string Body { get { return _body; } }
        public bool IsRead { get { return _isread; } }
        public MailBodyConfig(string ID = null)
        {
            if (ID != null)
            {
                Load(ID);
            }
        }

        private void Load(string ID)
        {
            try
            {
                string url = System.Web.HttpContext.Current.Server.MapPath("~") + "Config/MailBody.config";
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(url);
                XmlNodeList nodes = xmldoc.DocumentElement.SelectNodes("//item[@id='"+ID+"']");
                if (nodes.Count == 1)
                {
                    _title=nodes[0].SelectSingleNode("title").InnerText;
                    _body = nodes[0].SelectSingleNode("body").InnerText;
                    _isread = true;
                }
            }
            catch { }
        }
    }
}
