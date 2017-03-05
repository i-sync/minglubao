using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI.HSSF.UserModel;
using StarTech.NPOI;
using MLMGC.BLL.Enterprise;
using MLMGC.DataEntity.Enterprise;
using System.Data;

namespace Web.Enterprise.Data
{
    /// <summary>
    /// 企业导入名录
    /// </summary>
    public class ImportData
    {
        private string strClientName = "名录信息";
        private string strSourceName = "来源信息";
        private string strTradeName = "行业信息";
        private string strAreaName = "地区信息";

        private List<string> _result = new List<string>();
        private string _url = "";
        private int _enterpriseid = 0;
        private int _userid = 0;
        private int _epusertmrid = 0;

        /// <summary>
        /// 获取结果
        /// </summary>
        public List<string> Result { get { return _result; } }

        public ImportData()
        {
            _result.Clear();
        }
        public ImportData(int EnterpriseID, int EPUserTMRID, string url)
        {
            _result.Clear();
            _enterpriseid = EnterpriseID;
            _epusertmrid = EPUserTMRID;
            _url = url;
        }

        /// <summary>
        /// 名录数据导入
        /// </summary>
        /// <returns></returns>
        public bool Import()
        {
            if (string.IsNullOrEmpty(_url))
            {
                _result.Add("请选择文件");
                return false;
            }
            HSSFWorkbook workbook = HSSFTestData.OpenSampleWorkbook(_url);
            if (workbook == null)
            {
                _result.Add("无法读取zip文件,请用户由指定模板进行导入");
                return false;
            }
            if (workbook.NumberOfSheets < 1)
            {
                _result.Add("无法读取Excel文件，请用户由指定模板进行导入！");
                return false;
            }
            HSSFSheet shtClient = workbook.GetSheetAt(0);//名录表
            //HSSFSheet shtSource = workbook.GetSheetAt(1);//来源表
            //HSSFSheet shtTrade = workbook.GetSheetAt(2);//行业表
            //HSSFSheet shtArea = workbook.GetSheetAt(3); //地区表

            if (Check(shtClient))
            {
                //---------导入名录信息---------
                return ImportClient(shtClient);
            }
            return false;
        }

        /// <summary>
        /// 导入名录信息
        /// </summary>
        /// <param name="shtClient"></param>
        /// <returns></returns>
        private bool ImportClient(HSSFSheet shtClient)
        {
            int count = shtClient.LastRowNum;
            int succNum = 0, errorNum = 0;
            HSSFRow row;
            T_ClientInfo bll = new T_ClientInfo();
            E_ClientInfo data;
            DataTable dt;
            for (int i = 1; i <= count; ++i)
            {
                if (ISCheckRowStrNullOrEmpty(i, shtClient)) { continue; }
                row = shtClient.GetRow(i);
                data = new E_ClientInfo();
                data.EnterpriseID = _enterpriseid;
                data.EPUserTMRID = _epusertmrid;
                data.UserID = _userid;
                data.ClientName = GetCellValue(row.GetCell(0));//名称
                data.Address = GetCellValue(row.GetCell(1));//地址
                data.ZipCode = GetCellValue(row.GetCell(2));//邮编
                data.Linkman = GetCellValue(row.GetCell(3));//联系人
                data.Position = GetCellValue(row.GetCell(4));//职务
                data.Tel = GetCellValue(row.GetCell(5));//电话
                data.Mobile = GetCellValue(row.GetCell(6));//手机
                data.Fax = GetCellValue(row.GetCell(7));//传真
                data.Website = GetCellValue(row.GetCell(8));//网址
                data.Email = GetCellValue(row.GetCell(9));//邮箱
                data.QQ = GetCellValue(row.GetCell(10));//QQ
                data.MSN = GetCellValue(row.GetCell(11));//MSN
                data.SourceCode = GetCellValue(row.GetCell(12));//来源编码
                data.TradeCode = GetCellValue(row.GetCell(13));//行业编码
                data.AreaCode = GetCellValue(row.GetCell(14));//地区编码
                data.Remark = GetCellValue(row.GetCell(15));//备注
                //判断名录名是否存在
                dt = bll.Exists(new E_ClientInfo() { EnterpriseID = _enterpriseid, ClientName = data.ClientName, ClientInfoID = 0 });
                if (dt == null || dt.Rows.Count == 0)
                {
                    _result.Add("出错了！");
                    ++errorNum;
                    continue;
                }
                if (dt.Rows[0]["Flag"].ToString() != "-1")
                {
                    _result.Add(string.Format("[{0}]已经导入数据库！ 位置[{1}]中，第{2}行", data.ClientName, strClientName, i));
                    ++errorNum;
                    continue;
                }

                //判断手机是否存在
                if (!string.IsNullOrEmpty(data.Mobile))
                {
                    dt = new T_ClientInfoHelper().ExistsContact(new E_ClientInfoHelper { EnterpriseID = _enterpriseid, ClientInfoID = 0, Type = 1, Value = data.Mobile });
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        _result.Add("出错了！");
                        ++errorNum;
                        continue;
                    }
                    if (dt.Rows[0]["Flag"].ToString() != "-1")
                    {
                        _result.Add(string.Format("手机号码[{0}]已经存在于数据库！ 位置[{1}]中，第{2}行", data.Mobile, strClientName, i));
                        ++errorNum;
                        continue;
                    }
                }

                //判断电话是否存在
                if (!string.IsNullOrEmpty(data.Tel))
                {
                    dt = new T_ClientInfoHelper().ExistsContact(new E_ClientInfoHelper { EnterpriseID = _enterpriseid, ClientInfoID = 0, Type = 2, Value = data.Tel });
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        _result.Add("出错了！");
                        ++errorNum;
                        continue;
                    }
                    if (dt.Rows[0]["Flag"].ToString() != "-1")
                    {
                        _result.Add(string.Format("电话号码[{0}]已经存在于数据库！ 位置[{1}]中，第{2}行", data.Tel, strClientName, i));
                        ++errorNum;
                        continue;
                    }
                }
                
                //名录写入数据库
                if (bll.Add(data))//判断名录写入成功与失败
                {
                    ++succNum;
                }
                else
                {
                    ++errorNum;
                }
            }
            _result.Add(string.Format("成功导入{0}条，失败{1}条。", succNum, errorNum));
            return errorNum == 0;
        }

        #region 方法
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
                    }
                }
            }
            return isStrNull;
        }

        /// <summary>
        /// 检查数据是否合法
        /// </summary>
        /// <param name="shtClient">名录信息</param>
        /// <param name="shtSource">来源信息</param>
        /// <param name="shtTrade">行业信息</param>
        /// <param name="shtArea">地区信息</param>
        /// <returns></returns>
        protected bool Check(HSSFSheet shtClient)
        {
            string name, sourcecode, tradecode, areacode;
            T_Area bllArea = new T_Area();
            T_Source bllSource = new T_Source();
            T_Trade bllTrade = new T_Trade();
            T_ClientInfo bll = new T_ClientInfo();
            bool b = true;
            int count = 0;
            DataTable dt = null;

            //------检查名录信息是否合法
            if (b && CheckSheet(shtClient, strClientName, 16))//判断名录信息表是否合法
            {
                //-----检查名称是否已经存在
                count = shtClient.LastRowNum;
                for (int i = 1; i <= count; ++i)//从第2行开始
                {
                    if (ISCheckRowStrNullOrEmpty(i, shtClient))
                    {
                        continue;
                    }
                    name = GetCellValue(shtClient.GetRow(i).GetCell(0));//名称
                    sourcecode = GetCellValue(shtClient.GetRow(i).GetCell(12));//来源
                    tradecode = GetCellValue(shtClient.GetRow(i).GetCell(13));//行业
                    areacode = GetCellValue(shtClient.GetRow(i).GetCell(14));//地区
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        _result.Add(string.Format("名录名录为空！ 位置[{0}]中，第{1}行", strClientName, i));
                        b = false;
                        continue;
                    }
                    dt = bll.Exists(new E_ClientInfo() { EnterpriseID = _enterpriseid, ClientName = name, ClientInfoID = 0 });
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        _result.Add("出错了！");
                        b = false;
                        continue;
                    }
                    if (dt.Rows[0]["Flag"].ToString() != "-1")
                    {
                        _result.Add(string.Format("[{0}]已经在数据库中存在！ 位置[{1}]中，第{2}行", name, strClientName, i));
                        b = false;
                    }
                    //--------判断属性是否完成--------
                    //判断来源
                    if (!string.IsNullOrEmpty(sourcecode) && !bllSource.Exists(new E_Source() { EnterpriseID = _enterpriseid, SourceCode = sourcecode, SourceID = 0 }))
                    {
                        _result.Add("无来源编码:" + sourcecode);
                        b = false;
                    }
                    //判断行业
                    if (!string.IsNullOrEmpty(tradecode) && !bllTrade.Exists(new E_Trade() { EnterpriseID = _enterpriseid, TradeCode = tradecode, TradeID = 0 }))
                    {
                        _result.Add("无行业编码:" + tradecode);
                        b = false;
                    }
                    //判断地区
                    if (!string.IsNullOrEmpty(areacode) && !bllArea.Exists(new E_Area() { EnterpriseID = _enterpriseid, AreaCode = areacode, AreaID = 0 }))
                    {
                        _result.Add("无地区编码:" + areacode);
                        b = false;
                    }
                }

            }
            else
            {
                return false;
            }
            return b;
        }

        /// <summary>
        /// 检验工作表是否合法
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        protected bool CheckSheet(HSSFSheet sheet, string sheetName, int CellNum = 1)
        {
            //判断是否有记录
            if (sheet.LastRowNum < 1)
            {
                _result.Add("[" + sheetName + "]中无记录。");
                return false;
            }
            if (sheet.GetRow(0).LastCellNum < CellNum)
            {
                _result.Add("[" + sheetName + "]中单元格列数量不合法！至少" + CellNum + "列，现在有" + sheet.GetRow(0).LastCellNum + "列。");
                return false;
            }
            return true;
        }
        #endregion
    }
}