using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Data;
using MLMGC.BLL.Personal;
using MLMGC.DataEntity.Personal;
using NPOI.HSSF.UserModel;
using StarTech.NPOI;

namespace Web.Personal.Data
{
    /// <summary>
    /// 新数据导入
    /// </summary>
    public class ImportingData
    {
        private int _personalid, _epuserid;
        private string _filename;
        private string _path;

        public ImportingData(int PersonalID)
        {
            _personalid = PersonalID;
            //_epuserid = EPUserTMRID;
            //创建并复制模板文件
            _path = HttpContext.Current.Server.MapPath(".") + @"\DataFile\";
            _filename = _path + string.Format("data_{0}.xml", _personalid);
        }
        /// <summary>
        /// 创建xml文件
        /// </summary>
        /// <param name="_url">excel 文件路径</param>
        /// <returns></returns>
        public bool CreateXML(string _url)
        {
            try
            {
                //创建并复制模板文件
                if (System.IO.File.Exists(_filename))
                {
                    System.IO.File.Delete(_filename);
                }
                System.IO.File.Copy(_path + "data_template.xml", _filename);
                //读取excel表格内容
                HSSFWorkbook workbook = HSSFTestData.OpenSampleWorkbook(_url);
                HSSFSheet shtClient = workbook.GetSheetAt(0);//名录表

                int count = shtClient.LastRowNum;
                if (count == 0)
                {
                    return false;
                }
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.Load(_filename);
                //生成文件标题
                int cellnum = shtClient.GetRow(0).LastCellNum;
                XmlNode xnodeFileField = xmldoc.SelectSingleNode(@"root/FileField");
                for (int i = 0; i < cellnum; i++)
                {
                    XmlElement el = xmldoc.CreateElement("Field");
                    el.SetAttribute("name", "Field" + i);
                    el.SetAttribute("value", GetCellValue(shtClient.GetRow(0).GetCell(i)));
                    xnodeFileField.AppendChild(el);
                }
                //读取内容
                count = count > 1000 ? 1000 : count;
                XmlNode xnodeList = xmldoc.SelectSingleNode(@"root/List");
                for (int i = 1; i <= count; ++i)//从第2行开始
                {
                    if (ISCheckRowStrNullOrEmpty(i, shtClient)) { continue; }
                    XmlElement xlItem = xmldoc.CreateElement("Item");
                    xlItem.SetAttribute("id", i.ToString());
                    xnodeList.AppendChild(xlItem);
                    for (int j = 0; j < cellnum; ++j)//读取每格数据
                    {
                        XmlElement xlData = xmldoc.CreateElement("Data");
                        xlData.SetAttribute("name", "Field" + j.ToString());
                        xlData.InnerText = GetCellValue(shtClient.GetRow(i).GetCell(j));
                        xlItem.AppendChild(xlData);
                    }
                }
                xmldoc.Save(_filename);
                return true;
            }
            catch (Exception mye)
            {
                string str = mye.Message;
            }
            return false;
        }
        /// <summary>
        /// 获取标题数据源
        /// </summary>
        /// <returns></returns>
        public DataTable TitleSource()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Text");

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(_filename);
                XmlNodeList xnl = xmldoc.SelectSingleNode(@"root/FileField").ChildNodes;
                DataRow dr = dt.NewRow();
                dr[0] = "";
                dr[1] = "请选择对应列名";
                dt.Rows.Add(dr);
                foreach (XmlNode item in xnl)
                {
                    dr = dt.NewRow();
                    dr[0] = item.Attributes["name"].Value;
                    dr[1] = item.Attributes["value"].Value;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch { }
            return null;
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable DataList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("编号");
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(_filename);
                List<string> aryTitle = new List<string>();
                //获取标题
                XmlNodeList xnl = xmldoc.SelectNodes("root/CorreField/Field");
                for (int i = 0; i < xnl.Count; i++)
                {
                    XmlElement xe = (XmlElement)xnl[i];
                    if (!string.IsNullOrEmpty(xe.GetAttribute("Source")))
                    {
                        aryTitle.Add(xe.GetAttribute("Source"));
                        dt.Columns.Add(xe.GetAttribute("title"));
                    }
                }
                //获取数据列表
                XmlNodeList xnlList = xmldoc.SelectNodes("root/List/Item");
                int len = xnlList.Count;
                DataRow dr;
                for (int i = 0; i < len; i++)
                {
                    dr = dt.NewRow();
                    dr[0] = i + 1;
                    for (int j = 0; j < aryTitle.Count; j++)
                    {
                        dr[j + 1] = xnlList[i].SelectSingleNode("Data[@name='" + aryTitle[j] + "']").InnerText;

                    }
                    dt.Rows.Add(dr);
                }
            }
            catch
            {
                dt = new DataTable();
            }
            return dt;
        }
        /// <summary>
        /// 保存映射配置
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SaveConfiguration(List<E_CorreField> list)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(_filename);
                foreach (E_CorreField data in list)
                {
                    XmlElement xe = (XmlElement)xmldoc.SelectSingleNode("root/CorreField/Field[@Name='" + data.Name + "']");
                    if (xe == null)
                    {
                        return false;
                    }
                    xe.SetAttribute("Source", data.Source);
                }
                xmldoc.Save(_filename);
                return true;
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        /// 导入数据库
        /// </summary>
        /// <returns></returns>
        public E_ImportingResult ImportingDB()
        {
            E_ImportingResult result = new E_ImportingResult();

            XmlDocument xmldoc = new XmlDocument();
            //加载文件
            try
            {
                xmldoc.Load(_filename);
            }
            catch
            {
                //加载文件失败
                result.ErrorNumber = 1;
                return result;
            }
            //读取配置
            E_ImportingClientInfo data = new E_ImportingClientInfo();
            data.PersonalID = _personalid;
            //data.EPUserTMRID = _epuserid;
            XmlNodeList xnlConfig = xmldoc.SelectNodes("root/CorreField/Field");
            for (int i = 0; i < xnlConfig.Count; i++)
            {
                XmlElement xe = (XmlElement)xnlConfig[i];
                if (string.IsNullOrEmpty(xe.GetAttribute("Source")))
                {
                    continue;
                }
                switch (xe.GetAttribute("Name").ToLower())
                {
                    case "clientname":
                        data.ClientNameFiled = xe.GetAttribute("Source");
                        break;
                    case "address":
                        data.AddressFiled = xe.GetAttribute("Source");
                        break;
                    case "zipcode":
                        data.ZipCodeFiled = xe.GetAttribute("Source");
                        break;
                    case "linkman":
                        data.LinkmanFiled = xe.GetAttribute("Source");
                        break;
                    case "position":
                        data.PositionFiled = xe.GetAttribute("Source");
                        break;
                    case "tel":
                        data.TelFiled = xe.GetAttribute("Source");
                        break;
                    case "mobile":
                        data.MobileFiled = xe.GetAttribute("Source");
                        break;
                    case "fax":
                        data.FaxFiled = xe.GetAttribute("Source");
                        break;
                    case "website":
                        data.WebsiteFiled = xe.GetAttribute("Source");
                        break;
                    case "email":
                        data.EmailFiled = xe.GetAttribute("Source");
                        break;
                    case "qq":
                        data.QQFiled = xe.GetAttribute("Source");
                        break;
                    case "msn":
                        data.MSNFiled = xe.GetAttribute("Source");
                        break;
                    case "remark":
                        data.RemarkFiled = xe.GetAttribute("Source");
                        break;
                    case "sourcecode":
                        data.SourceCodeFiled = xe.GetAttribute("Source");
                        break;
                    case "tradecode":
                        data.TradeCodeFiled = xe.GetAttribute("Source");
                        break;
                    case "areacode":
                        data.AreaCodeFiled = xe.GetAttribute("Source");
                        break;
                    default:
                        break;
                }
            }
            //读取数据
            XmlNodeList xnlList = xmldoc.SelectNodes("root/List/Item");
            int len = xnlList.Count;
            T_ClientInfo bll = new T_ClientInfo();
            DataTable dt;
            for (int i = 0; i < len; i++)
            {
                data.ClientName = GetData(xnlList[i], data.ClientNameFiled);
                data.AddressFiled = GetData(xnlList[i], data.AddressFiled);
                data.ZipCode = GetData(xnlList[i], data.ZipCodeFiled);
                data.Linkman = GetData(xnlList[i], data.LinkmanFiled);
                data.Position = GetData(xnlList[i], data.PositionFiled);
                data.Tel = GetData(xnlList[i], data.TelFiled);
                data.Mobile = GetData(xnlList[i], data.MobileFiled);
                data.Fax = GetData(xnlList[i], data.FaxFiled);
                data.Website = GetData(xnlList[i], data.WebsiteFiled);
                data.Email = GetData(xnlList[i], data.EmailFiled);
                data.QQ = GetData(xnlList[i], data.QQFiled);
                data.MSN = GetData(xnlList[i], data.MSNFiled);
                data.Remark = GetData(xnlList[i], data.RemarkFiled);
                data.SourceName = GetData(xnlList[i], data.SourceCodeFiled);
                data.TradeName = GetData(xnlList[i], data.TradeCodeFiled);
                data.AreaName = GetData(xnlList[i], data.AreaCodeFiled);
                //判断名录名是否存在
                bool bb = bll.Exists(new E_ClientInfo() { PersonalID=_personalid, ClientName = data.ClientName, ClientInfoID=0 });
                
                if (bb)
                {
                    result.FailList.Add(string.Format("[{0}]已经导入数据库！ 第{1}行", data.ClientName, i));
                    ++result.FailNum;
                    continue;
                }

                //判断手机是否存在
                if (!string.IsNullOrEmpty(data.Mobile))
                {
                    dt = new T_ClientInfo().ExistsContact(new E_ClientInfo{ PersonalID = _personalid, ClientInfoID = 0, Type = 1, Value = data.Mobile });
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        result.FailList.Add("出错了！");
                        ++result.FailNum;
                        continue;
                    }
                    if (dt.Rows[0]["Flag"].ToString() != "-1")
                    {
                        result.FailList.Add(string.Format("手机号码[{0}]已经存在于数据库！ 第{1}行", data.Mobile, i));
                        ++result.FailNum;
                        continue;
                    }
                }

                //判断电话是否存在
                if (!string.IsNullOrEmpty(data.Tel))
                {
                    dt = new T_ClientInfo().ExistsContact(new E_ClientInfo { PersonalID = _personalid, ClientInfoID = 0, Type = 2, Value = data.Tel });
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        result.FailList.Add("出错了！");
                        ++result.FailNum;
                        continue;
                    }
                    if (dt.Rows[0]["Flag"].ToString() != "-1")
                    {
                        result.FailList.Add(string.Format("电话号码[{0}]已经存在于数据库！ 第{1}行", data.Tel, i));
                        ++result.FailNum;
                        continue;
                    }
                }

                bool b = bll.Add(data);
                if (b)
                {
                    ++result.SuccNum;
                }
                else
                {
                    ++result.FailNum;
                    result.FailList.Add(data.ClientName);
                }
            }
            //删除文件
            try
            {
                System.IO.File.Delete(_filename);
            }
            catch { }
            return result;
        }
        /// <summary>
        /// 获取单一数据项
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetData(XmlNode node, string name)
        {
            if (string.IsNullOrEmpty(name)) { return string.Empty; }
            return node.SelectSingleNode("Data[@name='" + name + "']").InnerText;
        }

        #region 辅助方法
        /// <summary>
        /// 获取单元格内容
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private string GetCellValue(HSSFCell cell)
        {
            if (cell == null)
            {
                return "";
            }
            return cell.ToString().Trim();//修改于11-07-07 添加了Trim()
        }
        /// <summary>
        /// 检验Excel表中全空行，并对其进行删除
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool ISCheckRowStrNullOrEmpty(int i, HSSFSheet sheet)
        {
            HSSFRow row = sheet.GetRow(i);
            bool isStrNull = true;
            if (row != null)
            {
                foreach (HSSFCell item in row)
                {
                    if (!string.IsNullOrEmpty(item.ToString()))
                    {
                        isStrNull = false;
                        break;
                    }
                }
            }
            return isStrNull;
        }
        #endregion
    }

    /// <summary>
    /// 数据导入对应字段
    /// </summary>
    public class E_CorreField
    {
        /// <summary>
        /// 数据库字段
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 对应字段
        /// </summary>
        public string Source { get; set; }
    }
    /// <summary>
    /// 名录导入结果
    /// </summary>
    public class E_ImportingResult
    {
        int _succ = 0, _fail = 0, _error = 0;
        List<string> _list = new List<string>();
        /// <summary>
        /// 成功数量
        /// </summary>
        public int SuccNum { get { return _succ; } set { _succ = value; } }
        /// <summary>
        /// 失败数量
        /// </summary>
        public int FailNum { get { return _fail; } set { _fail = value; } }

        /// <summary>
        /// 错误编号
        /// </summary>
        public int ErrorNumber { get { return _error; } set { _error = value; } }
        /// <summary>
        /// 失败名录名称
        /// </summary>
        public List<string> FailList
        {
            get { return _list; }
            set { _list = value; }
        }
    }

    public class E_ImportingClientInfo : MLMGC.DataEntity.Personal.E_ClientInfo
    {
        public string ClientNameFiled { get; set; }
        public string AddressFiled { get; set; }
        public string ZipCodeFiled { get; set; }
        public string LinkmanFiled { get; set; }
        public string PositionFiled { get; set; }
        public string TelFiled { get; set; }
        public string MobileFiled { get; set; }
        public string FaxFiled { get; set; }
        public string WebsiteFiled { get; set; }
        public string EmailFiled { get; set; }
        public string QQFiled { get; set; }
        public string MSNFiled { get; set; }
        public string RemarkFiled { get; set; }
        public string SourceCodeFiled { get; set; }
        public string TradeCodeFiled { get; set; }
        public string AreaCodeFiled { get; set; }
    }
}