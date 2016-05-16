using DDI.Common;
using DDIV.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDIWebApp.DDI
{
    public partial class FileDownloadEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    ConfigId.Value = Request.Params["id"];
                }
            }
        }



        protected void btnFileDownload_Click(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00");
            if (this.txtsupcode.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "供应商编码不能为空");
                return;
            }
            if (this.txtBeginDate.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "开始时间不能为空");
                return;
            }
            else
            {
                if (Convert.ToDateTime(txtBeginDate.Text.Trim()) >= dt)
                {
                    MessageBox.Show(this, "开始时间不能大于等于今天");
                    return;
                }
            }

            if (this.txtEndDate.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "截止时间不能为空");
                return;
            }
            else
            {
                if (Convert.ToDateTime(txtEndDate.Text.Trim()) >= dt)
                {
                    MessageBox.Show(this, "截止时间不能大于等于今天");
                    return;
                }
            }


            DAL_Execute dal = new DAL_Execute();
            string pathname = "";
            string begindate = txtBeginDate.Text.Trim() + " 00:00:00";
            DateTime dtadd = Convert.ToDateTime(txtEndDate.Text.Trim()).AddDays(1);
            string enddate = txtEndDate.Text.Trim() + " 23:59:59";



            DataSet ds = dal.FileDownloadList(Convert.ToInt32(ConfigId.Value), txtsupcode.Text.Trim(), begindate, enddate, out pathname);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        StreamExport(ds.Tables[0], null, pathname, this);
                    }
                    else
                    {
                        MessageBox.Show(this, "不存在条件内的数据！");
                    }
                }
                else
                {
                    MessageBox.Show(this, "查询语句错误请确认后再次操作！");
                }


            }


        }

        public static void ExportToSpreadsheet(DataTable table, string name)
        {
            Random r = new Random();
            string rf = "";
            for (int j = 0; j < 10; j++)
            {
                rf = r.Next(int.MaxValue).ToString();
            }

            HttpContext context = HttpContext.Current;
            context.Response.Clear();

            context.Response.ContentType = "application/ms-excel";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + ".xls");
            context.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

            foreach (DataColumn column in table.Columns)
            {
                context.Response.Write(column.ColumnName + ",");
                //context.Response.Write(column.ColumnName + "(" + column.DataType + "),");  
            }

            context.Response.Write(Environment.NewLine);
            double test;

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    switch (table.Columns[i].DataType.ToString())
                    {
                        case "System.String":
                            if (double.TryParse(row[i].ToString(), out test)) context.Response.Write("=");
                            context.Response.Write("\"" + row[i].ToString().Replace("\"", "\"\"") + "\",");
                            break;
                        case "System.DateTime":
                            if (row[i].ToString() != "")
                                context.Response.Write("\"" + ((DateTime)row[i]).ToString("yyyy-MM-dd hh:mm:ss") + "\",");
                            else
                                context.Response.Write("\"" + row[i].ToString().Replace("\"", "\"\"") + "\",");
                            break;
                        default:
                            context.Response.Write("\"" + row[i].ToString().Replace("\"", "\"\"") + "\",");
                            break;
                    }
                }
                context.Response.Write(Environment.NewLine);
            }

            context.Response.End();

        }

        public bool StreamExport(DataTable dt, string[] columns, string fileName, System.Web.UI.Page pages)
        {
            if (dt.Rows.Count > 65535) //总行数大于Excel的行数 
            {
                throw new Exception("预导出的数据总行数大于excel的行数");
            }
            if (string.IsNullOrEmpty(fileName)) return false;

            StringBuilder content = new StringBuilder();
            StringBuilder strtitle = new StringBuilder();
            content.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'>");
            content.Append("<head><title></title><meta http-equiv='Content-Type' content=\"text/html; charset=utf-8\">");
            //注意：[if gte mso 9]到[endif]之间的代码，用于显示Excel的网格线，若不想显示Excel的网格线，可以去掉此代码
            //content.Append("<!--[if gte mso 9]>");
            //content.Append("<xml>");
            //content.Append(" <x:ExcelWorkbook>");
            //content.Append("  <x:ExcelWorksheets>");
            //content.Append("   <x:ExcelWorksheet>");
            //content.Append("    <x:Name>Sheet1</x:Name>");
            //content.Append("    <x:WorksheetOptions>");
            //content.Append("      <x:Print>");
            //content.Append("       <x:ValidPrinterInfo />");
            //content.Append("      </x:Print>");
            //content.Append("    </x:WorksheetOptions>");
            //content.Append("   </x:ExcelWorksheet>");
            //content.Append("  </x:ExcelWorksheets>");
            //content.Append("</x:ExcelWorkbook>");
            //content.Append("</xml>");
            //content.Append("<![endif]-->");
            content.Append("</head><body><table style='border-collapse:collapse;table-layout:fixed;'><tr>");

            if (columns != null)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    if (columns[i] != null && columns[i] != "")
                    {
                        content.Append("<td><b>" + columns[i] + "</b></td>");
                    }
                    else
                    {
                        content.Append("<td><b>" + dt.Columns[i].ColumnName + "</b></td>");
                    }
                }
            }
            else
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    content.Append("<td><b>" + dt.Columns[j].ColumnName + "</b></td>");
                }
            }
            content.Append("</tr>\n");

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                content.Append("<tr>");
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    object obj = dt.Rows[j][k];
                    Type type = obj.GetType();
                    if (type.Name == "Int32" || type.Name == "Single" || type.Name == "Double" || type.Name == "Decimal")
                    {
                        double d = obj == DBNull.Value ? 0.0d : Convert.ToDouble(obj);
                        if (type.Name == "Int32" || (d - Math.Truncate(d) == 0))
                            content.AppendFormat("<td style='vnd.ms-excel.numberformat:#,##0'>{0}</td>", obj);
                        else
                            content.AppendFormat("<td style='vnd.ms-excel.numberformat:#,##0.00'>{0}</td>", obj);
                    }
                    else
                        content.AppendFormat("<td style='vnd.ms-excel.numberformat:@'>{0}</td>", obj);
                }
                content.Append("</tr>\n");
            }
            content.Append("</table></body></html>");
            content.Replace("&nbsp;", "");

            pages.Response.Clear();
            pages.Response.Buffer = false;
            pages.Response.ContentType = "application/ms-excel";  //"application/ms-excel";
            fileName = System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);
            pages.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + ".xls");
            pages.Response.Write(content.ToString());
            pages.Response.End();  //注意，若使用此代码结束响应可能会出现“由于代码已经过优化或者本机框架位于调用堆栈之上,无法计算表达式的值。”的异常。
            //HttpContext.Current.ApplicationInstance.CompleteRequest(); //用此行代码代替上一行代码，则不会出现上面所说的异常。
            return true;
        }



    }
}