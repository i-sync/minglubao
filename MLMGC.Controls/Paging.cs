using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Text;

namespace MLMGC.Controls
{
    [DefaultProperty("Text"), ToolboxData("<{0}:Paging runat='server'></{0}:Paging>")]
    public class Paging : System.Web.UI.WebControls.Literal
    {
        public Paging()
        {
        }

        public override void DataBind()
        {
            if (_pagesize > 0)
            {
                switch (_style)
                {
                    case PagingStyle.weibo://微博样式
                        weiboStyle();
                        break;
                    default:
                        styleDefault();
                        break;
                }
            }
            else
            {
                this.Text = "无法绑定数据";
            }
            base.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            DataBind();
            base.OnPreRender(e);
        }
        /// <summary>
        /// 默认样式
        /// </summary>
        protected void styleDefault()
        {
            int pagecount = _count / _pagesize;
            if (pagecount * _pagesize < _count) { pagecount++; }
            StringBuilder sb = new StringBuilder();
            Uri uri = new Uri(Page.Request.Url.ToString());
            sb.Append(string.Format("共 {0} 条记录&nbsp;", _count));
            for (int i = 1; i <= pagecount; i++)
            {
                sb.Append("&nbsp;<a href='" + setpagenum(uri, i.ToString()) + "'>" + i.ToString() + "</a>&nbsp;");
            }
            this.Text = sb.ToString();
        }

        /// <summary>
        /// 微博样式
        /// </summary>
        protected void weiboStyle()
        {
            int pagecount = _count / _pagesize;
            if (pagecount * _pagesize < _count) { pagecount++; }
            int startNum = 1;
            int endNum = pagecount;

            startNum = _currentpage - 2 > 1 ? _currentpage - 2 : 1;
            endNum = startNum + 9 > pagecount ? pagecount : startNum + 9;
            startNum = endNum < 10 ? 1 : startNum;

            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"pager-wrap\"><ul class=\"pages clearfix\">");
            for (int i = startNum; i <= endNum; ++i)
            {
                sb.Append(string.Format("<li class=\"page-number {1}\"><a class=\"js-link\">{0}</a></li>", i, i == _currentpage ? "pgCurrent" : ""));
            }
            sb.Append("</ul></div>");
            this.Text = sb.ToString();
        }


        private string setpagenum(Uri uri, string number)
        {
            if (string.IsNullOrEmpty(uri.Query))
            {
                return String.Concat(uri.ToString(), "?page=" + number);
            }
            else
            {
                if (uri.Query.ToString().IndexOf("page=") == -1)
                {
                    return String.Concat(uri.ToString(), "&page=" + number);
                }
                else
                {
                    string keyWord = "page=";
                    string url = uri.ToString();
                    int index = url.IndexOf(keyWord) + keyWord.Length;
                    int index1 = url.IndexOf("&", index);
                    if (index1 == -1)
                    {
                        url = url.Remove(index, url.Length - index);
                        url = string.Concat(url, number);
                        return url;
                    }
                    url = url.Remove(index, index1 - index);
                    url = url.Insert(index, number);
                    return url;
                }
            }
        }

        private int _pagesize = 0, _currentpage = 0, _count = 0;

        private PagingStyle _style;
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize
        {
            set { _pagesize = value; }
        }
        /// <summary>
        /// 当前页(从1开始)
        /// </summary>
        public int CurrentPage
        {
            set { _currentpage = value; }
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount
        {
            set { _count = value; }
        }
        /// <summary>
        /// 显示样式
        /// </summary>
        public PagingStyle StyleType
        {
            set { _style = value; }
        }
    }
    /// <summary>
    /// 分页样式
    /// </summary>
    public enum PagingStyle
    {
        weibo = 1
    }
}
