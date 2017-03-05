using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MLMGC.Security
{
    /// <summary>
    /// 单个在线用户数据，无法继承此类。
    /// </summary>	
    public sealed class ActiveUser
    {
        private static DataTable _activeusers = null;
        private static object padlock = new object();
        private static ActiveUser ac = null;

        public static ActiveUser Instance
        {
            get
            {
                if (ac == null)
                {
                    lock (padlock)
                    {
                        if (ac == null)
                        {
                            ac = new ActiveUser();
                            _activeusers = new DataTable("ActiveUser");
                            _activeusers.Columns.Add(new DataColumn("userid", System.Type.GetType("System.String")));//用户id
                            _activeusers.Columns.Add(new DataColumn("refreshtime", System.Type.GetType("System.DateTime")));//最后刷新时间
                            _activeusers.Columns.Add(new DataColumn("clientip", System.Type.GetType("System.String")));//登录ip
                        }
                    }
                }
                return ac;
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="ip"></param>
        public void Login(string userid, string ip = "")
        {
            if (_activeusers != null)
            {
                DataRow myRow;
                //检查现有表中是否存在用户
                if (_activeusers.Select("userid='" + userid + "'").Count() > 0)
                {
                    _activeusers.Select("userid='" + userid + "'")[0].Delete();
                }
                //登录
                myRow = _activeusers.NewRow();
                myRow[0] = userid;
                myRow[1] = DateTime.Now;
                myRow[2] = ip;
                _activeusers.Rows.Add(myRow);
                _activeusers.AcceptChanges();
            }
        }
        /// <summary>
        /// 刷新在线状态
        /// </summary>
        /// <param name="userid"></param>
        public void Refresh(string userid)
        {
            if (_activeusers != null)
            {
                DataRow[] dr = _activeusers.Select(string.Format("userid='{0}'", userid));
                if (dr.Length == 1)
                {
                    dr[0]["refreshtime"] = DateTime.Now;
                    _activeusers.AcceptChanges();
                }
                else//重新登录
                {
                    Login(userid);
                }
            }
        }

        /// <summary>
        /// 用户退出
        /// </summary>
        /// <param name="userid"></param>
        public void Logout(string userid)
        {
            if (_activeusers != null)
            {
                DataRow[] dr = _activeusers.Select(string.Format("userid='{0}'", userid));
                if (dr.Length == 1)
                {
                    dr[0].Delete();
                }
                _activeusers.AcceptChanges();
            }
        }
        /// <summary>
        /// 判断用户(单)是否在线
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool IsActiveUser(string userid)
        {
            bool _isactive = false;
            if (_activeusers != null)
            {
                _isactive = _activeusers.Select(string.Format("userid='{0}'", userid)).Length == 1;
            }
            return _isactive;
        }

        public string IsActiveClass(string userid)
        {
            return IsActiveUser(userid) ? "online" : "Leave";
        }
    }
}
