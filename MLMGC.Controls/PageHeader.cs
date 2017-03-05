using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.Controls
{
    public class PageHeader
    {
        public static void AddJS(System.Web.UI.Page page,string url)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl script = new System.Web.UI.HtmlControls.HtmlGenericControl("script");
            script.Attributes.Add("type", "text/javascript");
            script.Attributes.Add("src", url);
            page.Header.Controls.Add(script);
        }

        public static void AddCSS(System.Web.UI.Page page, string url)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl css = new System.Web.UI.HtmlControls.HtmlGenericControl("link");
            css.Attributes.Add("type", "text/css");
            css.Attributes.Add("rel", "stylesheet");
            css.Attributes.Add("href", url);
            page.Header.Controls.Add(css);
        }
    }
}
