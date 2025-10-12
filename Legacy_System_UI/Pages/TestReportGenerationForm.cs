using Core.Interfaces.Services;
using Legacy_System_UI.Infrastructure;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legacy_System_UI.Pages
{
    public partial class TestReportGenerationForm : MaterialForm
    {
        private readonly IReportService _reportService;
        public TestReportGenerationForm()
        {
            InitializeComponent();
            _reportService = Program.ServiceProvider.GetRequiredService<IReportService>();
        }

        private void TestReportGenerationForm_Load(object sender, EventArgs e)
        {

        }

        private async void Btn_GenerateReprt_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Tb_Id.Text, out int studentExamId))
            {
                MaterialMessageBox.Show("Please enter a valid Student Exam ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Generate the PDF report
                var pdfBytes = await _reportService.GenerateStudentExamReportPDFAsync(studentExamId);

                // Generate the Excel report

                //var excelBytes =await _reportService.GenerateStudentExamReportExcelAsync(studentExamId);

                // Use SaveFileDialog to let the user choose where to save the file
                ReportExporterHandler.UseSaveDialog(pdfBytes, "StudentExamReport", studentExamId.ToString(), "pdf");

                // if excel
                //ReportExporterHandler.UseSaveDialog(excelBytes, "StudentExamReport", studentExamId.ToString(), "xls"); //or xlsx

            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
