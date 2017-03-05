using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MLMGC.COMP
{
    public class DataDictionaries
    {


        public static void BindListControls(System.Web.UI.WebControls.ListControl control, System.Data.DataTable dataSource)
        {
            control.DataSource = dataSource;
            control.DataTextField = "Text";
            control.DataValueField = "Value";
            control.DataBind();
        }

        public static void BindProperty(System.Web.UI.WebControls.DropDownList ddl, DataTable dt)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = "Text";
            ddl.DataValueField = "Value";
            ddl.DataBind();
        }


        //public static void BindListControls(System.Web.UI.WebControls.ListControl control, FY.COMP.DictionaryTypes dictionaryTypeEnum)
        //{
        //    control.DataSource = dataSource;
        //    control.DataTextField = "Text";
        //    control.DataValueField = "Value";
        //    control.DataBind();
        //}
    }
}
