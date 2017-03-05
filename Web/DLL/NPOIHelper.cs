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
    /// Excel���ɲ�����
    /// </summary>
    public class NPOIHelper
    {
        /// <summary>
        /// ��������
        /// </summary>
        public static System.Collections.SortedList ListColumnsName;
        /// <summary>
        /// ����Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, string filePath)
        {
            if (ListColumnsName == null || ListColumnsName.Count == 0)
                throw (new Exception("���ListColumnsName����Ҫ������������"));

            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, filePath);
        }
        /// <summary>
        /// ����Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, Stream excelStream)
        {
            if (ListColumnsName == null || ListColumnsName.Count == 0)
                throw (new Exception("���ListColumnsName����Ҫ������������"));

            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, excelStream);
        }

        /// <summary>
        /// ����Excel
        /// </summary>
        /// <param name="dsSource"></param>
        /// <param name="excelStream"></param>
        /// <param name="SheetName"></param>
        /// <remarks>������ 2011.05.24</remarks>
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
                //ѭ������Դ�������ݼ�
                newsheet = excelWorkbook.CreateSheet(SheetName[i]);
                //��������
                cellIndex = 0;
                StarTech.NPOI.NPOIHelper.ListColumnsName = new SortedList(new StarTech.NPOI.NoSort());
                //���ñ�����ʽ
                HSSFCellStyle cellStyle = excelWorkbook.CreateCellStyle();
                cellStyle.Alignment = HSSFCellStyle.ALIGN_CENTER;
                HSSFFont mHSSFFont = excelWorkbook.CreateFont();
                mHSSFFont.FontHeightInPoints = 12;//�ֺ�
                mHSSFFont.Boldweight = HSSFFont.BOLDWEIGHT_BOLD;
                cellStyle.SetFont(mHSSFFont);
                //ѭ��������
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
        /// ����Excel��ÿ6�������
        /// </summary>
        /// <param name="dsSource"></param>
        /// <param name="excelStream"></param>
        /// <param name="SheetName"></param>
        public static void ExportExcelZip(DataTable dt, string SheetName, string tmpPath)
        {
            //ÿ���ļ�����
            int num = 60000;
            if (dt == null || SheetName == null) { return; }
            int count = (int)Math.Ceiling(dt.Rows.Count * 1.0 / num);
            for (int i = 0; i < count; i++)
            {
                int rowCount = 0;
                int cellIndex = 0;
                HSSFWorkbook excelWorkbook = CreateExcelFile();
                HSSFSheet newsheet = null;
                //ѭ������Դ�������ݼ�
                newsheet = excelWorkbook.CreateSheet(SheetName);
                //��������
                cellIndex = 0;
                StarTech.NPOI.NPOIHelper.ListColumnsName = new SortedList(new StarTech.NPOI.NoSort());
                //ѭ��������
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
            //ѹ���ļ���
            Compress.ZipCompress(tmpPath, tmpPath + ".zip");
        }

        /// <summary>
        /// ����Excel�ļ�
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
        /// ����Excel�ļ�
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
        /// ����Excel�ļ�
        /// </summary>
        /// <param name="filePath"></param>
        protected static HSSFWorkbook CreateExcelFile()
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            return hssfworkbook;
        }
        /// <summary>
        /// ����excel��ͷ
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="excelSheet"></param>
        protected static void CreateHeader(HSSFSheet excelSheet)
        {
            int cellIndex = 0;
            //ѭ��������
            foreach (System.Collections.DictionaryEntry de in ListColumnsName)
            {
                HSSFRow newRow = excelSheet.CreateRow(0);
                HSSFCell newCell = newRow.CreateCell(cellIndex);
                newCell.SetCellValue(de.Value.ToString());
                cellIndex++;
            }
        }
        /// <summary>
        /// ����������
        /// </summary>
        protected static void InsertRow(DataTable dtSource, HSSFWorkbook excelWorkbook)
        {
            int rowCount = 0;
            int sheetCount = 1;
            HSSFSheet newsheet = null;

            //ѭ������Դ�������ݼ�
            newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
            CreateHeader(newsheet);
            foreach (DataRow dr in dtSource.Rows)
            {
                rowCount++;
                //����10000������ �����µĹ�����
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
        /// ����������
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
                //������
                string columnsName = ListColumnsName.GetKey(cellIndex).ToString();
                HSSFCell newCell = null;
                System.Type rowType = drSource[columnsName].GetType();
                string drValue = drSource[columnsName].ToString().Trim();
                switch (rowType.ToString())
                {
                    case "System.String"://�ַ�������
                        drValue = drValue.Replace("&", "&");
                        drValue = drValue.Replace(">", ">");
                        drValue = drValue.Replace("<", "<");
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(drValue);
                        break;
                    case "System.DateTime"://��������
                        DateTime dateV;
                        DateTime.TryParse(drValue, out dateV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(dateV.ToString("yyyy-MM-dd HH:mm:ss"));

                        ////��ʽ����ʾ
                        //HSSFCellStyle cellStyle = excelWorkBook.CreateCellStyle();
                        //HSSFDataFormat format = excelWorkBook.CreateDataFormat();
                        //cellStyle.DataFormat = format.GetFormat("yyyy-mm-dd hh:mm:ss");
                        //newCell.CellStyle = cellStyle;

                        break;
                    case "System.Boolean"://������
                        bool boolV = false;
                        bool.TryParse(drValue, out boolV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(boolV);
                        break;
                    case "System.Int16"://����
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Byte":
                        int intV = 0;
                        int.TryParse(drValue, out intV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(intV.ToString());
                        break;
                    case "System.Decimal"://������
                    case "System.Double":
                        double doubV = 0;
                        double.TryParse(drValue, out doubV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(doubV);
                        break;
                    case "System.DBNull"://��ֵ����
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue("");
                        break;
                    default:
                        throw (new Exception(rowType.ToString() + "�����������޷�����!"));
                }
            }
        }
    }
    //����ʵ�ֽӿ� ���������� �������˳�򵼳�
    public class NoSort : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return -1;
        }
    }
}
