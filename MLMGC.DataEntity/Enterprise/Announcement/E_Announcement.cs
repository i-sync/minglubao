using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise.Announcement
{
    /// <summary>
    /// 企业公告
    /// </summary>
    [Serializable]
    public class E_Announcement
    {
        private int _enterpriseid;
        private long _announcementid;
        private int _teamid;
        private int _epusertmrid;
        private string _anntitle;
        private string _anncontent;
        private DateTime _adddate;
        /// <summary>
        /// Enterprise.EnterpriseID
        /// </summary>
        public int EnterpriseID
        {
            get { return _enterpriseid; }
            set { _enterpriseid = value; }
        }
        /// <summary>
        /// 公告编号
        /// </summary>
        public long AnnouncementID
        {
            get { return _announcementid; }
            set { _announcementid = value; }
        }
        /// <summary>
        /// 团队编号
        /// </summary>
        public int TeamID
        {
            get { return _teamid; }
            set { _teamid = value; }
        }
        /// <summary>
        /// 用户角色编号
        /// </summary>
        public int EPUserTMRID
        {
            get { return _epusertmrid; }
            set { _epusertmrid = value; }
        }
        /// <summary>
        /// 公告简介
        /// </summary>
        public string AnnTitle
        {
            get { return _anntitle; }
            set { _anntitle = value; }
        }
        /// <summary>
        /// 公告内容
        /// </summary>
        public string AnnContent
        {
            get { return _anncontent; }
            set { _anncontent = value; }
        }
        /// <summary>
        /// 公告发布时间
        /// </summary>
        public DateTime AddDate
        {
            get { return _adddate; }
            set { _adddate = value; }
        }
        /// <summary>
        /// 分页
        /// </summary>
        public E_Page Page
        {
            get;
            set;
        }
    }
}
