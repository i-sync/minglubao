using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI.HSSF.UserModel;
using StarTech.NPOI;
using MLMGC.BLL.Personal;
using MLMGC.BLL.Personal.Config;
using MLMGC.DataEntity.Personal;
using MLMGC.DataEntity.Personal.Config;
using System.Data;


namespace Web.Personal.Data
{
    /// <summary>
    /// 个人数据导入功能
    /// </summary>
    public class ImportData
    {
        private string strClientName = "名录信息";
        private string strSourceName = "来源信息";
        private string strTradeName = "行业信息";
        private string strAreaName = "地区信息";

        private List<string> _result = new List<string>();
        private string _url = "";
        private int _personalid = 0;
        /// <summary>
        /// 获取结果
        /// </summary>
        public List<string> Result { get { return _result; } }

        public ImportData()
        {
            _result.Clear();
        }
        public ImportData(int PersonalID, string url)
        {
            _result.Clear();
            _personalid = PersonalID;
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
            if (workbook.NumberOfSheets < 4)
            {
                _result.Add("无法读取Excel文件，请用户由指定模板进行导入！");
                return false;
            }
            HSSFSheet shtClient = workbook.GetSheetAt(0);//名录表
            HSSFSheet shtSource = workbook.GetSheetAt(1);//来源表
            HSSFSheet shtTrade = workbook.GetSheetAt(2);//行业表
            HSSFSheet shtArea = workbook.GetSheetAt(3); //地区表

            if (Check(shtClient, shtSource, shtTrade, shtArea))
            {
                //---------导入属性---------
                if (!ImportProperty(shtSource, shtTrade, shtArea))
                {
                    return false;
                }
                //---------导入名录信息---------
                return ImportClient(shtClient);
            }
            return false;
        }
        #region  数据导入
        /// <summary>
        /// 导入属性
        /// </summary>
        /// <returns></returns>
        private bool ImportProperty(HSSFSheet shtSource, HSSFSheet shtTrade, HSSFSheet shtArea)
        {
            int count = 0;
            List<string> aryCode = new List<string>();
            List<string> aryName = new List<string>();
            //--来源
            count = shtSource.LastRowNum;
            for (int i = 1; i <= count; ++i)
            {
                aryCode.Add(GetCellValue(shtSource.GetRow(i).GetCell(0)));//来源名称
                aryName.Add(GetCellValue(shtSource.GetRow(i).GetCell(1)));//来源名称
            }
            if (aryCode.Count > 0 && !new T_Source().BatchAdd(new E_Source()
            {
                PersonalID = _personalid,
                SourceCodeS = string.Join(MLMGC.COMP.Config.Separation, aryCode.ToArray()),
                SourceNameS = string.Join(MLMGC.COMP.Config.Separation, aryName.ToArray())
            }))
            {
                _result.Add(strSourceName + " 导入失败");
                return false;
            }
            aryCode.Clear();
            aryName.Clear();
            //--行业
            count = shtTrade.LastRowNum;
            for (int i = 1; i <= count; ++i)
            {
                aryCode.Add(GetCellValue(shtTrade.GetRow(i).GetCell(0)));//行业名称
                aryName.Add(GetCellValue(shtTrade.GetRow(i).GetCell(1)));//行业名称
            }
            if (aryCode.Count > 0 && !new T_Trade().BatchAdd(new E_Trade()
            {
                PersonalID = _personalid,
                TradeCodeS = string.Join(MLMGC.COMP.Config.Separation, aryCode.ToArray()),
                TradeNameS = string.Join(MLMGC.COMP.Config.Separation, aryName.ToArray())
            }))
            {
                _result.Add(strTradeName + " 导入失败");
                return false;
            }
            aryCode.Clear();
            aryName.Clear();
            //--地区
            count = shtArea.LastRowNum;
            for (int i = 1; i <= count; ++i)
            {
                aryCode.Add(GetCellValue(shtArea.GetRow(i).GetCell(0)));//行业名称
                aryName.Add(GetCellValue(shtArea.GetRow(i).GetCell(1)));//行业名称
            }
            if (aryCode.Count > 0 && !new T_Area().BatchAdd(new E_Area()
            {
                PersonalID = _personalid,
                AreaCodeS = string.Join(MLMGC.COMP.Config.Separation, aryCode.ToArray()),
                AreaNameS = string.Join(MLMGC.COMP.Config.Separation, aryName.ToArray())
            }))
            {
                _result.Add(strAreaName + " 导入失败");
                return false;
            }
            return true;
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
            for (int i = 1; i <= count; ++i)
            {
                if (ISCheckRowStrNullOrEmpty(i, shtClient)) { continue; }
                row = shtClient.GetRow(i);
                data = new E_ClientInfo();
                data.PersonalID = _personalid;
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
                data.SourceName = GetCellValue(row.GetCell(12));//来源编码
                data.TradeName = GetCellValue(row.GetCell(13));//行业编码
                data.AreaName = GetCellValue(row.GetCell(14));//地区编码
                data.Remark = GetCellValue(row.GetCell(15));//备注

                //判断名录名是否存在
                bool flag = bll.Exists(new E_ClientInfo() { PersonalID=_personalid, ClientName = data.ClientName, ClientInfoID = 0 });                
                if (flag)
                {
                    _result.Add(string.Format("[{0}]已经导入数据库！ 位置[{1}]中，第{2}行", data.ClientName, strClientName, i));
                    ++errorNum;
                    continue;
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
        #endregion

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
        protected bool Check(HSSFSheet shtClient, HSSFSheet shtSource, HSSFSheet shtTrade, HSSFSheet shtArea)
        {
            string name, sourcecode, tradecode, areacode;
            MLMGC.BLL.Personal.Config.T_Area bllArea = new MLMGC.BLL.Personal.Config.T_Area();
            MLMGC.BLL.Personal.Config.T_Source bllSource = new MLMGC.BLL.Personal.Config.T_Source();
            MLMGC.BLL.Personal.Config.T_Trade bllTrade = new MLMGC.BLL.Personal.Config.T_Trade();
            MLMGC.BLL.Personal.T_ClientInfo bll = new T_ClientInfo();
            bool b = true;
            int count = 0;
            //------检查名录属性是否合法
            List<string> arySource = new List<string>(), aryTrade = new List<string>(), aryArea = new List<string>();
            //--来源
            count = shtSource.LastRowNum;
            for (int i = 1; i <= count; ++i)
            {
                if (ISCheckRowStrNullOrEmpty(i, shtSource))
                {
                    continue;
                }
                sourcecode = GetCellValue(shtSource.GetRow(i).GetCell(0));//来源编码
                if (arySource.Contains(sourcecode))
                {
                    _result.Add("[" + strSourceName + "]中编码[" + sourcecode + "]有重复！第" + i.ToString() + "行");
                    b = false;
                }
                else if (bllSource.Exists(new E_Source() { PersonalID = _personalid, SourceCode = sourcecode }))
                {
                    _result.Add(string.Format("来源编码[{0}]已经存在 [1]中第{2}行", sourcecode,strAreaName,i));
                    b = false;
                }
                else
                {
                    arySource.Add(sourcecode);
                }
            }
            //--行业
            count = shtTrade.LastRowNum;
            for (int i = 1; i <= count; ++i)
            {
                if (ISCheckRowStrNullOrEmpty(i, shtTrade))
                {
                    continue;
                }
                tradecode = GetCellValue(shtTrade.GetRow(i).GetCell(0));//来源编码
                if (aryTrade.Contains(tradecode))
                {
                    _result.Add("[" + strTradeName + "]中编码[" + tradecode + "]有重复！第" + i.ToString() + "行");
                }
                else if (bllTrade.Exists(new E_Trade() { PersonalID = _personalid, TradeCode = tradecode }))
                {
                    _result.Add(string.Format("行业编码[{0}]数据库中已经存在 [{1}]中第{2}行", tradecode, strTradeName, i));
                    b = false;
                }
                else
                {
                    aryTrade.Add(tradecode);
                }
            }
            //--地区
            count = shtArea.LastRowNum;
            for (int i = 1; i <= count; ++i)
            {
                if (ISCheckRowStrNullOrEmpty(i, shtArea))
                {
                    continue;
                }
                areacode = GetCellValue(shtArea.GetRow(i).GetCell(0));//来源编码
                if (aryArea.Contains(areacode))
                {
                    _result.Add("[" + strAreaName + "]中编码[" + areacode + "]有重复！第" + i.ToString() + "行");
                }
                else if (bllArea.Exists(new E_Area() { PersonalID = _personalid, AreaCode = areacode }))
                {
                    _result.Add(string.Format("地区编码[{0}]已经存在 [{1}]中,第{2}行", areacode, strAreaName, i));
                    b = false;
                }
                else
                {
                    aryArea.Add(areacode);
                }
            }
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
                    if (bll.Exists(new E_ClientInfo() { PersonalID = _personalid, ClientName = name, ClientInfoID = 0 }))
                    {
                        _result.Add(string.Format("[{0}]已经在数据库中存在！ 位置[{1}]中，第{2}行", name, strClientName, i));
                        b = false;
                    }
                    //--------判断属性是否完成--------
                    //判断来源
                    if (!string.IsNullOrEmpty(sourcecode) && !arySource.Contains(sourcecode) &&
                        !bllSource.Exists(new E_Source() { PersonalID = _personalid, SourceCode = sourcecode }))
                    {
                        _result.Add("无来源编码:" + sourcecode);
                        b = false;
                    }
                    //判断行业
                    if (!string.IsNullOrEmpty(tradecode) && !aryTrade.Contains(tradecode) &&
                        !bllTrade.Exists(new E_Trade() { PersonalID = _personalid, TradeCode = tradecode }))
                    {
                        _result.Add("无行业编码:" + tradecode);
                        b = false;
                    }
                    //判断地区
                    if (!string.IsNullOrEmpty(areacode) && !aryArea.Contains(areacode) &&
                        !bllArea.Exists(new E_Area() { PersonalID = _personalid, AreaCode = areacode }))
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