using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public abstract class ReportExporter
    {
        public static string GetReportFileName(string reportType, string identifier, string format)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return $"{reportType}_{identifier}_{timestamp}.{format}";
        }

        public static string GetFilterType(string format)
        {
            return format.ToLower() switch
            {
                "pdf" => "PDF files (*.pdf)|*.pdf",
                "xlsx" => "Excel Workbook (*.xlsx)|*.xlsx",
                "xls" => "Excel 97-2003 Workbook (*.xls)|*.xls",
                _ => "All files (*.*)|*.*" // Default to all files if format is unknown
            };
        }
    }
}
