using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace MLMGC.DALFactory
{
    public sealed class DataAccess
    {
        public static readonly string AssemblyPath = ConfigurationManager.AppSettings["dal"];
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    DataCache.SetCache(ClassNamespace, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }
    }
}
