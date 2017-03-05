using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;

namespace MLMGC.COMP
{
    public class EnumUtil
    {
        public static void BindList<T>(DropDownList ddl)
        {
            List<ListItem> li = ToListItem<T>();
            ddl.DataSource = li;
            ddl.DataTextField = "text";
            ddl.DataValueField = "value";
            ddl.DataBind();
        }
        public static void BindList<T>(RadioButtonList rbl)
        {
            List<ListItem> li = ToListItem<T>();
            rbl.DataSource = li;
            rbl.DataTextField = "text";
            rbl.DataValueField = "value";
            rbl.DataBind();
        }
        /// <summary>
        /// 获取enum列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<ListItem> ToListItem<T>()
        {
            List<ListItem> li = new List<ListItem>();
            foreach (int s in Enum.GetValues(typeof(T)))
            {
                li.Add(new ListItem { 
                 Value=s.ToString(),
                 Text=Enum.GetName(typeof(T),s)
                });
            }
            return li;
        }
        /// <summary>
        /// 获取enum列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="IsDefault">是否需要默认值</param>
        /// <returns></returns>
        public static List<ListItem> ToListItem<T>(bool IsDefault)
        {
            List<ListItem> li = new List<ListItem>();
            if (IsDefault)
            {
                ListItem liDefault = new ListItem();
                liDefault.Text = "——请选择——";
                liDefault.Value = "-1";
                li.Add(liDefault);
            }
            foreach (int s in Enum.GetValues(typeof(T)))
            {
                li.Add(new ListItem
                {
                    Value = s.ToString(),
                    Text = Enum.GetName(typeof(T), s)
                });
            }
            return li;
        }
        /// <summary>
        /// 获取enum列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static DataTable ToTable<T>()
        {
            DataTable tab = new DataTable();
            tab.Columns.Add("ID", typeof(int));
            tab.Columns.Add("Name", typeof(string));
            foreach (int s in Enum.GetValues(typeof(T)))
            {
                tab.Rows.Add(s.ToString(), Enum.GetName(typeof(T), s));
            }
            return tab;
        }
        /// <summary>
        /// 获取指定enum的名称 找不到则返回null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetName<T>(int value)
        {
            if (!Enum.IsDefined(typeof(T), value))
            {
                return null;
            }
            return Enum.GetName(typeof(T), value);
        }
        /// <summary>
        /// 获取指定enum的名称 找不到则返回null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetName<T>(string value)
        {
            int v;
            int.TryParse(value, out v);
            return GetName<T>(v);
        }
        /// <summary>
        /// 获取指定enum的名称 找不到则返回null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetName<T>(object obj)
        {
            return GetName<T>(obj.ToString());
        }

    }
}
