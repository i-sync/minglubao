using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.Enterprise.Plan;

namespace MLMGC.DALFactory.Enterprise.Plan
{
    /// <summary>
    /// 团队计划
    /// </summary>
    public class F_D_TeamPlan
    {
        public static I_D_TeamPlan Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.Plan.D_TeamPlan";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_TeamPlan)objType;
        }
    }
}
