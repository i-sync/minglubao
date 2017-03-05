using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMGC.COMP
{
    public enum DictionaryTypes
    {
        /// <summary>
        /// 不取任何字典项
        /// </summary>
        None=0,
        /// <summary>
        /// 办公用品一级类别
        /// </summary>
        OfficeGoodsFirstCategory,

        /// <summary>
        /// 办公用品一级类别
        /// </summary>
        OfficeGoodsSecondCategory,
        /// <summary>
        /// 会议类型字典项
        /// </summary>
        MeetTypes,
        /// <summary>
        /// 会议级别字典项
        /// </summary>
        MeetLevels,

        /// <summary>
        /// 会议变动类型字典项
        /// </summary>
        MeetChangeTypes,

        /// <summary>
        /// 部门字典项
        /// </summary>
        Dept,

        /// <summary>
        /// 业务模块操作字典项
        /// </summary>
        OperateRights,
        /// <summary>
        /// 业务模块操作字典项_业务文件
        /// </summary>
        OperateRightsFile,
        /// <summary>
        /// 业务模块操作字典项_业务日志
        /// </summary>
        OperateRightsLog,
        /// <summary>
        /// 业务模块操作字典项_业务合同
        /// </summary>
        OperateRightsContract,

        /// <summary>
        /// 业务模块字典项
        /// </summary>
        FileScope,

        /// <summary>
        /// 案源类型
        /// </summary>
        CaseTypes,
        
        /// <summary>
        /// 客户类型
        /// </summary>
        CustomerTypes,

        /// <summary>
        /// 客户级别
        /// </summary>
        CustomerLevles,

        /// <summary>
        /// 客户来源
        /// </summary>
        CustomerSouces,

        /// <summary>
        /// 分类编号-流水号
        /// </summary>
        ClassifyCode_SequeueNos,

        /// <summary>
        /// 分类编号-业务类型
        /// </summary>
        ClassifyCode_CaseTypes,

        /// <summary>
        /// 分类编号-客户名称分类描述
        /// </summary>
        ClassifyCode_CustomerNameTypes,

        /// <summary>
        /// 分类编号-收案时间名称类型
        /// </summary>
        ClassifyCode_ReceiveCaseTimeNameTypes,

        /// <summary>
        /// 分类编号-发布时间名称类型
        /// </summary>
        ClassifyCode_PublishTimeNameTypes,

        /// <summary>
        /// 分类编号-颁布布时间字典表
        /// </summary>
        ClassifyCode_DecreeTimes,

        /// <summary>
        /// 时间点
        /// </summary>
        TimePoint,

        /// <summary>
        /// 学历
        /// </summary>
        Degrees,
        /// <summary>
        /// 一级岗位级别
        /// </summary>
        FirstPosLevels,

        /// <summary>
        /// 二级岗位级别
        /// </summary>
        SecondPosLevels

    }
}
