using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Personal
{
    public class E_JobExperience
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long JobExperienceID { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 个人编号
        /// </summary>
        public int PersonalID { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        
        private EnumScale _scale;
        /// <summary>
        /// 公司规模
        /// </summary>
        public EnumScale Scale{ get{return _scale;}}
        public int SetScale
        {
            set 
            {
                switch (value)
                { 
                    case 0:
                        _scale = EnumScale.未知;
                        break;
                    case 1:
                        _scale = EnumScale.少于50人;
                        break;
                    case 2:
                        _scale = EnumScale.大于50小于150人;
                        break;
                    case 3:
                        _scale = EnumScale.大于150小于500人;
                        break;
                    case 4:
                        _scale = EnumScale.大于500人;
                        break;
                }
            }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string Departments { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 工作描述
        /// </summary>
        public string JobDescription { get; set; }
    }

    /// <summary>
    /// 公司规模
    /// </summary>
    public enum EnumScale
    { 
        未知=0,
        少于50人=1,
        大于50小于150人=2,
        大于150小于500人=3,
        大于500人=4
    }
}
