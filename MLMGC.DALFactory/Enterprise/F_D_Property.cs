﻿using System;
using System.Collections.Generic;
using MLMGC.IDAL.Enterprise;

namespace MLMGC.DALFactory.Enterprise
{
    /// <summary>
    /// 名录属性配置
    /// </summary>
    public abstract class F_D_Property
    {
        public static I_D_Property Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".Enterprise.D_Property";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_Property)objType;
        }
    }
}
