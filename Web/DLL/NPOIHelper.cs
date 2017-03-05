using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using System.Data;
using System.Collections;
using MLMGC.COMP;

namespace StarTech.NPOI
{
    /// <summary>
    /// Excel生成操作类
    /// </summary>
    public class NPOIHelper
    {
        /// <summary>
        /// 导出列名
        /// </summary>
        public static System.Collections.SortedList ListColumnsName;
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, string filePath)
        {
            if (ListColumnsName == null || ListColumnsName.Count == 0)
                throw (new Exception("请对ListColumnsName设置要导出的列明！"));

            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, filePath);
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, Stream excelStream)
        {
            if (ListColumnsName == null || ListColumnsName.Count == 0)
                throw (new Exception("请对ListColumnsName设置要导出的列明！"));

            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, excelStream);
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dsSource"></param>
        /// <param name="excelStream"></param>
        /// <param name="SheetName"></param>
        /// <remarks>齐鹏飞 2011.05.24</remarks>
        public static void ExportExcel(DataSet ds, Stream excelStream, List<string> SheetName)
        {
            if (ds == null || SheetName==null) { return; }
            if (ds.Tables.Count != SheetName.Count) { return; }
            int rowCount = 0;
            int cellIndex = 0;
            HSSFWorkbook excelWorkbook = CreateExcelFile();
            HSSFSheet newsheet = null;
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                //循环数据源导出数据集
                newsheet = excelWorkbook.CreateSheet(SheetName[i]);
                //创建标题
                cellIndex = 0;
                StarTech.NPOI.NPOIHelper.ListColumnsName = new SortedList(new StarTech.NPOI.NoSort());
                //设置标题样式
                HSSFCellStyle cellStyle = excelWorkbook.CreateCellStyle();
                cellStyle.Alignment = HSSFCellStyle.ALIGN_CENTER;
                HSSFFont mHSSFFont = excelWorkbook.CreateFont();
                mHSSFFont.FontHeightInPoints = 12;//字号
                mHSSFFont.Boldweight = HSSFFont.BOLDWEIGHT_BOLD;
                cellStyle.SetFont(mHSSFFont);
                //循环导出列
                foreach (DataColumn dc in ds.Tables[i].Columns)
                {
                    HSSFRow newRow = newsheet.CreateRow(0);
                    HSSFCell newCell = newRow.CreateCell(cellIndex);
                    newCell.SetCellValue(dc.ColumnName);
                    newCell.CellStyle = cellStyle;

                    StarTech.NPOI.NPOIHelper.ListColumnsName.Add(dc.ColumnName, dc.ColumnName);
                    cellIndex++;
                    
                }
                rowCount = 0;
                foreach (DataRow dr in ds.Tables[i].Rows)
                {
                    ++rowCount;
                    HSSFRow newRow = newsheet.CreateRow(rowCount);
                    InsertCell(ds.Tables[i], dr, newRow, newsheet, excelWorkbook);
                }
            }
            SaveExcelFile(excelWorkbook, excelStream);
        }

        /// <summary>
        /// 导出Excel并每6万条打包
        /// </summary>
        /// <param name="dsSource"></param>
        /// <param name="excelStream"></param>
        /// <param name="SheetName"></param>
        public static void ExportExcelZip(DataTable dt, string SheetName, string tmpPath)
        {
            //每个文件条数
            int num = 60000;
            if (dt == null || SheetName == null) { return; }
            int count = (int)Math.Ceiling(dt.Rows.Count * 1.0 / num);
            for (int i = 0; i < count; i++)
            {
                int rowCount = 0;
                int cellIndex = 0;
                HSSFWorkbook excelWorkbook = CreateExcelFile();
                HSSFSheet newsheet = null;
                //循环数据源导出数据集
                newsheet = excelWorkbook.CreateSheet(SheetName);
                //创建标题
                cellIndex = 0;
                StarTech.NPOI.NPOIHelper.ListColumnsName = new SortedList(new StarTech.NPOI.NoSort());
                //循环导出列
                foreach (DataColumn dc in dt.Columns)
                {
                    HSSFRow newRow = newsheet.CreateRow(0);
                    HSSFCell newCell = newRow.CreateCell(cellIndex);
                    newCell.SetCellValue(dc.ColumnName);
                    StarTech.NPOI.NPOIHelper.ListColumnsName.Add(dc.ColumnName, dc.ColumnName);
                    cellIndex++;

                }
                rowCount = 0;
                for (int j = i * num; (j < (i + 1) * num) && (j < dt.Rows.Count); j++)
                {
                    DataRow dr = dt.Rows[j];
                    ++rowCount;
                    HSSFRow newRow = newsheet.CreateRow(rowCount);
                    InsertCell(dt, dr, newRow, newsheet, excelWorkbook);
                }
                SaveExcelFile(excelWorkbook, tmpPath + "/" + (i + 1).ToString() + ".xls");
            }
            //压缩文件夹
            Compress.ZipCompress(tmpPath, tmpPath + ".zip");
        }

        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <param name="excelWorkBook"></param>
        /// <param name="filePath"></param>
        protected static void SaveExcelFile(HSSFWorkbook excelWorkBook, string filePath)
        {
            FileStream file = null;
            try
            {
                file = new FileStream(filePath, FileMode.Create);
                excelWorkBook.Write(file);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <param name="excelWorkBook"></param>
        /// <param name="filePath"></param>
        protected static void SaveExcelFile(HSSFWorkbook excelWorkBook, Stream excelStream)
        {
            try
            {
                excelWorkBook.Write(excelStream);
            }
            finally
            {

            }
        }
        /// <summary>
        /// 创建Excel文件
        /// </summary>
        /// <param name="filePath"></param>
        protected static HSSFWorkbook CreateExcelFile()
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            return hssfworkbook;
        }
        /// <summary>
        /// 创建excel表头
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="excelSheet"></param>
        protected static void CreateHeader(HSSFSheet excelSheet)
        {
            int cellIndex = 0;
            //循环导出列
            foreach (System.Collections.DictionaryEntry de in ListColumnsName)
            {
                HSSFRow newRow = excelSheet.CreateRow(0);
                HSSFCell newCell = newRow.CreateCell(cellIndex);
                newCell.SetCellValue(de.Value.ToString());
                cellIndex++;
            }
        }
        /// <summary>
        /// 插入数据行
        /// </summary>
        protected static void InsertRow(DataTable dtSource, HSSFWorkbook excelWorkbook)
        {
            int rowCount = 0;
            int sheetCount = 1;
            HSSFSheet newsheet = null;

            //循环数据源导出数据集
            newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
            CreateHeader(newsheet);
            foreach (DataRow dr in dtSource.Rows)
            {
                rowCount++;
                //超出10000条数据 创建新的工作簿
                if (rowCount ==2)
                {
                    rowCount = 1;
                    sheetCount++;
                    newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
                    CreateHeader(newsheet);
                }

                HSSFRow newRow = newsheet.CreateRow(rowCount);
                InsertCell(dtSource, dr, newRow, newsheet, excelWorkbook);
            }
        }
        /// <summary>
        /// 导出数据行
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="drSource"></param>
        /// <param name="currentExcelRow"></param>
        /// <param name="excelSheet"></param>
        /// <param name="excelWorkBook"></param>
        protected static void InsertCell(DataTable dtSource, DataRow drSource, HSSFRow currentExcelRow, HSSFSheet excelSheet, HSSFWorkbook excelWorkBook)
        {
            for (int cellIndex = 0; cellIndex < ListColumnsName.Count; cellIndex++)
            {
                //列名称
                string columnsName = ListColumnsName.GetKey(cellIndex).ToString();
                HSSFCell newCell = null;
                System.Type rowType = drSource[columnsName].GetType();
                string drValue = drSource[columnsName].ToString().Trim();
                switch (rowType.ToString())
                {
                    case "System.String"://字符串类型
                        drValue = drValue.Replace("&", "&");
                        drValue = drValue.Replace(">", ">");
                        drValue = drValue.Replace("<", "<");
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(drValue);
                        break;
                    case "System.DateTime"://日期类型
                        DateTime dateV;
                        DateTime.TryParse(drValue, out dateV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(dateV.ToString("yyyy-MM-dd HH:mm:ss"));

                        ////格式化显示
                        //HSSFCellStyle cellStyle = excelWorkBook.CreateCellStyle();
                        //HSSFDataFormat format = excelWorkBook.CreateDataFormat();
                        //cellStyle.DataFormat = format.GetFormat("yyyy-mm-dd hh:mm:ss");
                        //newCell.CellStyle = cellStyle;

                        break;
                    case "System.Boolean"://布尔型
                        bool boolV = false;
                        bool.TryParse(drValue, out boolV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(boolV);
                        break;
                    case "System.Int16"://整型
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Byte":
                        int intV = 0;
                        int.TryParse(drValue, out intV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(intV.ToString());
                        break;
                    case "System.Decimal"://浮点型
                    case "System.Double":
                        double doubV = 0;
                        double.TryParse(drValue, out doubV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(doubV);
                        break;
                    case "System.DBNull"://空值处理
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue("");
                        break;
                    default:
                        throw (new Exception(rowType.ToString() + "：类型数据无法处理!"));
                }
            }
        }
    }
    //排序实现接口 不进行排序 根据添加顺序导出
    public class NoSort : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return -1;
        }
    }
}
