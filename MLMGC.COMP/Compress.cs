using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace MLMGC.COMP
{
    /// <summary>
    /// 压缩
    /// </summary>
    public class Compress
    {
        /// <summary>
        /// zip压缩
        /// </summary>
        /// <param name="path">源文件夹路径</param>
        /// <param name="topath">目标文件路径</param>
        /// <param name="FileName">从源文件夹中指定某文件</param>
        /// <returns>-1=文件不存在,0=未知错误,1=成功</returns>
        public static int ZipCompress(string path, string topath,string FileName="")
        {
            //文件夹不存在
            if (!Directory.Exists(path))
            {
                return -1;
            }

            try
            {
                string[] filenames = Directory.GetFiles(path);
                if (!string.IsNullOrEmpty(FileName) && filenames.Length > 0)
                {
                    if (File.Exists(path + FileName))
                    {
                        List<string> list = new List<string>();
                        list.Add(path + FileName);
                        filenames = list.ToArray();

                    }
                    else
                    {
                        return -2;
                    }
                }
                using (ZipOutputStream s = new ZipOutputStream(File.Create(topath)))
                {
                    s.SetLevel(9); // 0 - store only to 9 - means best compression
                    byte[] buffer = new byte[4096];
                    foreach (string file in filenames)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 解压缩
        /// 王洪岐
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="topath"></param>
        /// <returns></returns>
        public static int ZipUnCompress(string filePath,string topath)
        {
            //文件不存在
            if (!File.Exists(filePath))
            {
                return -1;
            }
            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(filePath)))
                {

                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(theEntry.Name);
                        string fileName = Path.GetFileName(theEntry.Name);

                        // create directory
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(topath + directoryName);
                        }
                        else if (!Directory.Exists(topath))
                        {
                            Directory.CreateDirectory(topath);
                        }
                        if (fileName != String.Empty)
                        {
                            using (FileStream streamWriter = File.Create(topath + theEntry.Name))
                            {

                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
