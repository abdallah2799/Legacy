using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class ReportExporter
    {
        public static string GetReportFileName(string reportType, string identifier, string format)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return $"{reportType}_{identifier}_{timestamp}.{format}";
        }

        public static string GetMimeType(string format)
        {
            return format.ToLower() switch
            {
                "pdf" => "application/pdf",
                "xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "xls" => "application/vnd.ms-excel",
                _ => "application/octet-stream"
            };
        }
    }
}
