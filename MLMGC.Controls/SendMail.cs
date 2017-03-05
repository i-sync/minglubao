using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text;
using System.Collections.Generic;

namespace MLMGC.Controls
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public class SendMail
    {
        private string _mailform;//发送方邮箱地址
        private string _displayname;//别名
        bool IsWriteLog = false;
        List<string> _listAddition;
        /// <summary>
        /// 发送方邮箱地址
        /// </summary>
        public string MailForm { get { return _mailform; } set { _mailform = value; } }
        /// <summary>
        /// 发送方邮箱别名
        /// </summary>
        private string DisplayName { get { return _displayname; } set { _displayname = value; } }
        private string _host;
        private int _port=25;
        /// <summary>
        /// 发送方地址
        /// </summary>
        private string Host
        {
            set { _host = value; }
            get { return _host; }
        }
        /// <summary>
        /// 端口号
        /// </summary>
        private int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        private string _smtpUserName;
        /// <summary>
        /// 发送方用户名
        /// </summary>
        private string SmtpUserName
        {
            set { _smtpUserName = value; }
            get { return _smtpUserName; }
        }
        private string _smtpPassword;
        /// <summary>
        /// 发送方密码
        /// </summary>
        private string SmtpPassword
        {
            set { _smtpPassword = value; }
            get { return _smtpPassword; }
        }
        public SendMail()
        {
            _mailform = ConfigurationManager.AppSettings["mailFrom"];
            _host = ConfigurationManager.AppSettings["host"];
            _smtpUserName = ConfigurationManager.AppSettings["mailUserName"];
            _smtpPassword = ConfigurationManager.AppSettings["mailPwd"];
            _displayname = ConfigurationManager.AppSettings["DisplayName"];
            IsWriteLog = true;
        }
        public SendMail(string mailfrom, string smtp,int port, string username, string password, string displayname=null,List<string> listAddition=null)
        {
            _mailform = mailfrom;
            _host = smtp;
            _port = port;
            _smtpUserName = username;
            _smtpPassword = password;
            _displayname = displayname??mailfrom;
            _listAddition = listAddition;
            IsWriteLog = false;
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="MailTo"></param>
        /// <param name="Subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public bool Send(string MailTo, string Subject, string body,out string message)
        {
            message = "";
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_mailform);
            if (mail == null) { return false; }
            mail.To.Add(new MailAddress(MailTo));
            mail.Subject = Subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(MailForm, DisplayName);
            mail.BodyEncoding = Encoding.GetEncoding("GB2312");
            if (_listAddition != null)
            {
                foreach (string str in _listAddition)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        Attachment attachment = new Attachment(str);
                        attachment.TransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                        mail.Attachments.Add(attachment);
                    }
                }
            }
            

            bool b = Send(mail,out message);
            if (IsWriteLog) { new LogSet().WriteLog("[" + MailTo + "] 发送" + (b ? "成功" : "失败")); }
            return b;
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        private bool Send(MailMessage mail,out string message)
        {
            message = "";
            SmtpClient sc = new SmtpClient();
            sc.EnableSsl = false;
            sc.Host = _host;
            sc.Credentials = new System.Net.NetworkCredential(_smtpUserName, _smtpPassword);
            try
            {
                sc.Send(mail);
                return true;
            }
            catch (Exception mye) 
            {
                message = mye.Message;
                if (IsWriteLog) { new LogSet().WriteLog("发送邮件错误：" + mye.StackTrace.ToString()); } 
            }
            return false;
        }
    }
}
