using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLMGC.IDAL.WenKu;

namespace MLMGC.DALFactory.WenKu
{
    /// <summary>
    /// 文库下载日志
    /// </summary>
    public abstract class F_D_WenKuDownload
    {
        public static I_D_WenKuDownload Create()
        {
            string ClassNamespace = DataAccess.AssemblyPath + ".WenKu.D_WenKuDownload";
            object objType = DataAccess.CreateObject(DataAccess.AssemblyPath, ClassNamespace);
            return (I_D_WenKuDownload)objType;
        }
    }
}
