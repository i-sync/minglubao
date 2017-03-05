using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 名录数据导入导出
    /// </summary>
    public class F_D_ClientInfoData
    {
        public static I_D_ClientInfoData Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_ClientInfoData";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_ClientInfoData)objType;
        }
    }
}
