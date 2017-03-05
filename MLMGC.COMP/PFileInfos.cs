using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Json;

namespace MLMGC.COMP
{
    public class PFileInfos
    {

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private string _fileSize;
        public string FileSize
        {
            get { return _fileSize; }
            set { _fileSize = value; }
        }

        private string _fileAddress;
        public string FileAddress
        {
            get { return _fileAddress; }
            set { _fileAddress = value; }
        }

        /// <summary>
        /// 旧JSON转string
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static List<PFileInfos> ParseJsonString(string jsonString)//
        {
            List<PFileInfos> filelist = new List<PFileInfos>();

            //jsonString = jsonString.Substring(1, jsonString.Length - 2);

            List<string> listString = new List<string>();
            JsonTextParser parser = new JsonTextParser();
            while (jsonString.Length != 0)
            {
                int index = jsonString.IndexOf("},{");
                string itemString = null;
                if (index == -1)
                {
                    itemString = jsonString;
                }
                else
                {
                    itemString = jsonString.Substring(0, index + 1);
                }
                listString.Add(itemString);
                JsonObject  jsonObj=parser.Parse(itemString);
                PFileInfos file = new PFileInfos();
                foreach (JsonObject field in jsonObj as JsonObjectCollection)
                {
                    string fieldName = field.Name;
                    string fieldValue = field.GetValue().ToString().Replace(",", "");
                    switch (fieldName)
                    {
                        case "fileName":
                            file.FileName = fieldValue;
                            break;
                        case "filePath":
                            file.FileAddress = fieldValue;
                            break;
                        case "fileSize":
                            file.FileSize = fieldValue;
                            break;
                    }
                }
                filelist.Add(file);
                if (index == -1)
                {
                    jsonString = "";
                }
                else
                {
                    jsonString = jsonString.Substring(index + 2);
                }
            }

            return filelist;
        }

    }
}
