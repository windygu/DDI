using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.IO;
using System.Linq;
using System;
namespace DDIV2.DAL
{
    public abstract class NPOIExtExcelHelper
    {
        /// <summary>
        /// 导出txt
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="spitChar"></param>
        /// <returns></returns>
        public static Stream ExportToTxt(DataSet sourceDs, string spitChar)
        {

            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            try
            {
                foreach (DataRow dgvrow in sourceDs.Tables[0].Rows)
                {
                    string rowtxt = string.Empty;
                    foreach (DataColumn col in sourceDs.Tables[0].Columns)
                    {
                        rowtxt += dgvrow[col].ToString().Trim() + spitChar;
                    }
                    sw.WriteLine(rowtxt.TrimEnd(','));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ms.Flush();
                sw.Close();
            }
            return ms;
        }
        /// <summary>
        /// 保存DataSet导出到Excel
        /// </summary>
        /// <param name="sourceDs"></param>
        /// <param name="sheetName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool SaveExportData(DataSet sourceDs, string sheetName, string filename, int filetype, string pathname, bool isHed)
        {
            bool result = false;
            try
            {


                MemoryStream stream = null;
                string hz = "";
                switch (filetype)
                {
                    case 1:
                        stream = NPOIExtExcelHelper.ExportDataSetToExcel(sourceDs, sheetName, ExcelVersion.Version97_2003,isHed) as MemoryStream;
                        hz = ".xls";
                        break;
                    case 2:
                        stream = NPOIExtExcelHelper.ExportDataSetToExcel(sourceDs, sheetName, ExcelVersion.Version2007,isHed) as MemoryStream;
                        hz = ".xlsx";
                        break;
                    case 3:
                        stream = NPOIExtExcelHelper.ExportToTxt(sourceDs, ",") as MemoryStream;
                        hz = ".txt";
                        break;
                    case 4:
                        stream = NPOIExtExcelHelper.ExportDataSetToCSV(sourceDs,isHed) as MemoryStream;
                        hz = ".csv";
                        break;
                }
                string path = pathname + filename + hz;
                if (!Directory.Exists(pathname))
                {
                    Directory.CreateDirectory(pathname, null);
                }

                FileStream fs = new FileStream(path, FileMode.Create);
                fs.Write(stream.ToArray(), 0, stream.ToArray().Length);
                fs.Dispose();

                result = true;
            }
            catch (Exception ep)
            {

                throw ep;
            }

            return result;

        }
        /// <summary>
        /// 由DataSet导出Excel
        /// </summary>
        /// <param name="sourceTable">要导出数据的DataSet</param>
        /// <param name="sheetName">工作表名</param>
        /// <param name="version">excel版本</param>
        /// <returns>Excel工作表</returns>
        public static Stream ExportDataSetToExcel(DataSet sourceDs, string sheetName, ExcelVersion version, bool isHead)
        {
            IWorkbook workbook = GetPerperWorkbook(version);
            string[] sheetNames = sheetName.Split('^');
            for (int i = 0; i < sheetNames.Length; i++)
            {
                ISheet sheet = workbook.CreateSheet(sheetNames[i]);

                IRow headerRow = sheet.CreateRow(0);
                // handling header.
                if (isHead)
                {
                    foreach (DataColumn column in sourceDs.Tables[i].Columns)
                    {
                        ICell icell = headerRow.CreateCell(column.Ordinal);
                        icell.SetCellValue(column.ColumnName.Trim());
                    }
                }
                // handling value.
                int rowIndex = 1;

                foreach (DataRow row in sourceDs.Tables[i].Rows)
                {
                    IRow dataRow = sheet.CreateRow(rowIndex);

                    foreach (DataColumn column in sourceDs.Tables[i].Columns)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString().Trim());
                    }
                    rowIndex++;
                }
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();

            if (version == ExcelVersion.Version97_2003)
            {
                ms.Position = 0;
            }

            workbook = null;
            return ms;
        }
        /// <summary>
        /// 由DataSet导出CSV
        /// </summary>
        /// <param name="sourceTable">要导出数据的DataSet</param>
        /// <param name="sheetName">工作表名</param>
        public static Stream ExportDataSetToCSV(DataSet sourceDs,bool isHed)
        {
            string rowtitle = "";
            string rowtxt = "";
            DataTable dt = sourceDs.Tables[0];
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms, System.Text.Encoding.GetEncoding("GB2312"));
            try
            {
                if (isHed)
                {
                    //写出列名称
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        rowtitle += dt.Columns[i].ColumnName.ToString() + ",";

                    }
                    sw.WriteLine(rowtitle.TrimEnd(','));
                }
                foreach (DataRow dgvrow in sourceDs.Tables[0].Rows)
                {
                    rowtxt = "";
                    foreach (DataColumn col in sourceDs.Tables[0].Columns)
                    {
                        rowtxt += dgvrow[col].ToString().Trim() + ",";
                    }
                    sw.WriteLine(rowtxt.TrimEnd(','));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ms.Flush();
                sw.Close();
            }
            return ms;
        }


        /// <summary>
        /// 获得自适应版本
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        private static IWorkbook GetPerperWorkbook(ExcelVersion version)
        {
            IWorkbook result = null;
            switch (version)
            {
                case ExcelVersion.Version97_2003:
                    result = new HSSFWorkbook();
                    break;
                case ExcelVersion.Version2007:
                    result = new XSSFWorkbook();
                    break;
            }
            return result;
        }

    }
    /// <summary>
    /// excel版本支持
    /// </summary>
    public enum ExcelVersion
    {
        /// <summary>
        /// 早期版本(97-2003)
        /// </summary>
        Version97_2003 = 0,
        /// <summary>
        /// 最新版本(2007及最新）
        /// </summary>
        Version2007 = 1,
    }
}
