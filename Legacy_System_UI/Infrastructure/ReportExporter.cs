using Common.Helpers;
using Core.Models;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy_System_UI.Infrastructure
{
    public class ReportExporterHandler: ReportExporter
    {
        public static async void UseSaveDialog(byte[] OutputBytes , string ReportType , string Identifier , string Extention)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = GetFilterType(Extention);
                saveFileDialog.FileName = GetReportFileName(ReportType, Identifier, Extention);
                saveFileDialog.Title = $"Save {ReportType} Report {Extention.ToUpper()}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    await File.WriteAllBytesAsync(saveFileDialog.FileName, OutputBytes);
                    MaterialMessageBox.Show($"Report saved successfully to: {saveFileDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MaterialMessageBox.Show("Report generation cancelled by user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
