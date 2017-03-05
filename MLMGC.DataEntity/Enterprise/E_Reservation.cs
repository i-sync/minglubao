using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.DataEntity.Enterprise
{
    public class E_Reservation
    {
        /// <summary>
        /// 企业编号
        /// </summary>
        public int EnterpriseID { get; set; }
        /// <summary>
        /// 名录ID
        /// </summary>
        public int ClientInfoID { get; set; }
        public string ClientInfoIDs { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int EPUserTMRID { get; set; }
        #region 预约
        /// <summary>
        /// 预约编号
        /// </summary>
        public int ReservationID { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? ReservationDate { get; set; }
        /// <summary>
        /// 提前时间
        /// </summary>
        public ushort? AdvanceMinute { get; set; }
        #endregion
        private EnumReservationType _reservationtype;
        /// <summary>
        /// 预约类型
        /// </summary>
        public EnumReservationType ReservationType 
        {
            get
            { 
                return _reservationtype; 
            }
            set
            {
                _reservationtype = value;
            }
        }
        /// <summary>
        /// 设置预约类型
        /// </summary>
        public int SetType
        {
            set 
            {
                switch (value)
                { 
                    case 1:
                        _reservationtype = EnumReservationType.电话预约;
                        break;
                    case 2:
                        _reservationtype = EnumReservationType.上门拜访;
                        break;
                }
            }
        }
    }
    public enum EnumReservationType
    { 
        电话预约=1,
        上门拜访=2
    }
}
