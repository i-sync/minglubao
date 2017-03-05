using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise.Plan;

namespace MLMGC.DALFactory.Enterprise.Plan
{
    /// <summary>
    /// 个人计划
    /// </summary>
    public class F_D_UserPlan
    {
        public static I_D_UserPlan Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.Plan.D_UserPlan";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_UserPlan)objType;
        }
    }
}
