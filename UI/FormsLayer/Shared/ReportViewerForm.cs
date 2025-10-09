using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Core.Models;
using Common.Enums;

namespace UI.FormsLayer.Shared
{
    public partial class ReportViewerForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly LocalizationManager localizationManager;
        private readonly ThemeManager themeManager;
        private readonly SessionManager sessionManager;
        private readonly IReportService _reportService;

        // Controls
        private MaterialLabel lblTitle;
        private MaterialLabel lblSubtitle;
        private MaterialComboBox cmbLanguage;
        private MaterialButton btnTheme;
        private MaterialButton btnBackToDashboard;
        private MaterialButton btnGenerate;
        private MaterialButton btnExportPDF;
        private MaterialButton btnExportExcel;
        private MaterialComboBox cmbReportType;
        private MaterialComboBox cmbBranch;
        private MaterialComboBox cmbTrack;
        private MaterialComboBox cmbCourse;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private DataGridView dgvReport;
        private Panel panelMain;
        private Panel panelTop;
        private Panel panelContent;
        private Panel panelFilters;
        private Panel panelReport;
        private MaterialLabel lblNoData;

        public ReportViewerForm(IReportService reportService)
        {
            _reportService = reportService;

            materialSkinManager = MaterialSkinManager.Instance;
            localizationManager = LocalizationManager.Instance;
            themeManager = ThemeManager.Instance;
            sessionManager = SessionManager.Instance;

            InitializeComponent();
            SetupForm();
        }

        private void InitializeComponent()
        {
            // Initialize all controls
            lblTitle = new MaterialLabel();
            lblSubtitle = new MaterialLabel();
            cmbLanguage = new MaterialComboBox();
            btnTheme = new MaterialButton();
            btnBackToDashboard = new MaterialButton();
            btnGenerate = new MaterialButton();
            btnExportPDF = new MaterialButton();
            btnExportExcel = new MaterialButton();
            cmbReportType = new MaterialComboBox();
            cmbBranch = new MaterialComboBox();
            cmbTrack = new MaterialComboBox();
            cmbCourse = new MaterialComboBox();
            dtpFromDate = new DateTimePicker();
            dtpToDate = new DateTimePicker();
            dgvReport = new DataGridView();
            panelMain = new Panel();
            panelTop = new Panel();
            panelContent = new Panel();
            panelFilters = new Panel();
            panelReport = new Panel();
            lblNoData = new MaterialLabel();

            // Configure form
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Report Viewer";
            this.Padding = new Padding(4, 98, 4, 5);

            // Configure controls
            ConfigureControls();
            SetupLayout();

            this.ResumeLayout(false);
        }

        private void ConfigureControls()
        {
            // Title
            lblTitle.AutoSize = true;
            lblTitle.Depth = 0;
            lblTitle.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Text = "Report Viewer";

            // Subtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.Depth = 0;
            lblSubtitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSubtitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblSubtitle.Location = new Point(20, 70);
            lblSubtitle.Text = "Generate and view system reports";

            // Language selector
            cmbLanguage.AutoResize = false;
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.Location = new Point(20, 20);
            cmbLanguage.Size = new Size(120, 50);
            cmbLanguage.Items.AddRange(new[] { "English", "العربية" });
            cmbLanguage.SelectedIndex = 0;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;

            // Theme button
            btnTheme.AutoSize = false;
            btnTheme.Size = new Size(100, 50);
            btnTheme.Location = new Point(150, 20);
            btnTheme.Text = "Dark";
            btnTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTheme.Click += btnTheme_Click;

            // Back to Dashboard button
            btnBackToDashboard.AutoSize = false;
            btnBackToDashboard.Size = new Size(150, 50);
            btnBackToDashboard.Location = new Point(260, 20);
            btnBackToDashboard.Text = "Back to Dashboard";
            btnBackToDashboard.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnBackToDashboard.Click += btnBackToDashboard_Click;

            // Generate button
            btnGenerate.AutoSize = false;
            btnGenerate.Size = new Size(120, 40);
            btnGenerate.Text = "Generate Report";
            btnGenerate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGenerate.Click += btnGenerate_Click;

            // Export PDF button
            btnExportPDF.AutoSize = false;
            btnExportPDF.Size = new Size(120, 40);
            btnExportPDF.Text = "Export PDF";
            btnExportPDF.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnExportPDF.Click += btnExportPDF_Click;

            // Export Excel button
            btnExportExcel.AutoSize = false;
            btnExportExcel.Size = new Size(120, 40);
            btnExportExcel.Text = "Export Excel";
            btnExportExcel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnExportExcel.Click += btnExportExcel_Click;

            // Report Type
            cmbReportType.AutoResize = false;
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.Size = new Size(200, 50);
            cmbReportType.Items.AddRange(new[] {
                "Student Exam Report",
                "Student All Exams Report",
                "Student Exam Summary",
                "Instructor Exam Report",
                "Course Performance Report",
                "Branch Performance Report",
                "Track Performance Report",
                "System Statistics Report"
            });
            cmbReportType.SelectedIndex = 0;
            cmbReportType.SelectedIndexChanged += cmbReportType_SelectedIndexChanged;

            // Branch
            cmbBranch.AutoResize = false;
            cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.Size = new Size(150, 50);
            cmbBranch.Items.Add("All Branches");

            // Track
            cmbTrack.AutoResize = false;
            cmbTrack.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrack.Size = new Size(150, 50);
            cmbTrack.Items.Add("All Tracks");

            // Course
            cmbCourse.AutoResize = false;
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.Size = new Size(150, 50);
            cmbCourse.Items.Add("All Courses");

            // Date pickers
            dtpFromDate.Size = new Size(150, 50);
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);

            dtpToDate.Size = new Size(150, 50);
            dtpToDate.Value = DateTime.Now;

            // DataGridView
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReport.ColumnHeadersHeight = 56;
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.EnableHeadersVisualStyles = false;
            dgvReport.GridColor = Color.FromArgb(255, 255, 255);
            dgvReport.Location = new Point(0, 0);
            dgvReport.Margin = new Padding(4, 5, 4, 5);
            dgvReport.MultiSelect = false;
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(1200, 400);
            dgvReport.TabIndex = 0;

            // No data label
            lblNoData.AutoSize = true;
            lblNoData.Depth = 0;
            lblNoData.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNoData.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblNoData.Location = new Point(50, 200);
            lblNoData.Text = "No data found";
            lblNoData.Visible = false;
        }

        private void SetupLayout()
        {
            // Panel structure
            panelMain.Dock = DockStyle.Fill;
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelTop);

            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 100;
            panelTop.Controls.AddRange(new Control[] {
                cmbLanguage, btnTheme, btnBackToDashboard
            });

            panelContent.Dock = DockStyle.Fill;
            panelContent.Controls.Add(panelReport);
            panelContent.Controls.Add(panelFilters);
            panelContent.Controls.Add(lblTitle);
            panelContent.Controls.Add(lblSubtitle);

            panelFilters.Dock = DockStyle.Top;
            panelFilters.Height = 120;
            panelFilters.Controls.AddRange(new Control[] {
                cmbReportType, cmbBranch, cmbTrack, cmbCourse, dtpFromDate, dtpToDate,
                btnGenerate, btnExportPDF, btnExportExcel
            });

            // Position filter controls
            cmbReportType.Location = new Point(20, 20);
            cmbBranch.Location = new Point(240, 20);
            cmbTrack.Location = new Point(410, 20);
            cmbCourse.Location = new Point(580, 20);
            dtpFromDate.Location = new Point(750, 20);
            dtpToDate.Location = new Point(920, 20);

            btnGenerate.Location = new Point(20, 70);
            btnExportPDF.Location = new Point(160, 70);
            btnExportExcel.Location = new Point(300, 70);

            panelReport.Dock = DockStyle.Fill;
            panelReport.Location = new Point(20, 220);
            panelReport.Size = new Size(1360, 500);
            panelReport.Controls.Add(dgvReport);
            panelReport.Controls.Add(lblNoData);

            // Add controls to form
            this.Controls.Add(panelMain);
        }

        private void SetupForm()
        {
            materialSkinManager.AddFormToManage(this);
            themeManager.ApplyTheme(materialSkinManager);
            LoadFilterData();
        }

        private async void LoadFilterData()
        {
            try
            {
                // TODO: Load branches, tracks, and courses for filters
                // This would populate the combo boxes with available options
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading filter data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var reportType = (ReportTypeEnum)cmbReportType.SelectedIndex;
                var branchId = cmbBranch.SelectedIndex > 0 ? (int?)cmbBranch.SelectedIndex : null;
                var trackId = cmbTrack.SelectedIndex > 0 ? (int?)cmbTrack.SelectedIndex : null;
                var courseId = cmbCourse.SelectedIndex > 0 ? (int?)cmbCourse.SelectedIndex : null;
                var fromDate = dtpFromDate.Value;
                var toDate = dtpToDate.Value;

                object reportData = reportType switch
                {
                    ReportTypeEnum.StudentExamReport => await _reportService.GetStudentExamReportAsync(0), // TODO: Implement proper filtering
                    ReportTypeEnum.StudentAllExamsReport => await _reportService.GetStudentAllExamsReportAsync(0), // TODO: Implement proper filtering
                    ReportTypeEnum.StudentExamSummary => new { Message = "TODO: Implement GetStudentExamSummaryAsync" }, // TODO: Implement this method
                    ReportTypeEnum.InstructorExamReport => new { Message = "TODO: Implement GetInstructorExamReportAsync" }, // TODO: Implement this method
                    ReportTypeEnum.CoursePerformanceReport => new { Message = "TODO: Implement GetCoursePerformanceReportAsync" }, // TODO: Implement this method
                    ReportTypeEnum.BranchPerformanceReport => new { Message = "TODO: Implement GetBranchPerformanceReportAsync" }, // TODO: Implement this method
                    ReportTypeEnum.TrackPerformanceReport => new { Message = "TODO: Implement GetTrackPerformanceReportAsync" }, // TODO: Implement this method
                    ReportTypeEnum.SystemStatisticsReport => new { Message = "TODO: Implement GetSystemStatisticsReportAsync" }, // TODO: Implement this method
                    _ => throw new ArgumentException("Invalid report type")
                };

                dgvReport.DataSource = reportData;
                lblNoData.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            // TODO: Implement PDF export
            MessageBox.Show("PDF export functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // TODO: Implement Excel export
            MessageBox.Show("Excel export functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Update filter controls based on report type
            // Some reports may not need all filters
        }

        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            var dashboard = new MainDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            themeManager.ToggleTheme();
            themeManager.ApplyTheme(materialSkinManager);
            btnTheme.Text = themeManager.IsDarkMode ? "Light" : "Dark";
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var language = cmbLanguage.SelectedIndex == 0 ? "en" : "ar";
            localizationManager.SetLanguage(language);
            // TODO: Update all form text with localized strings
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    localizationManager.GetString("ExitConfirmation_Message"),
                    localizationManager.GetString("ExitConfirmation_Title"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            base.OnFormClosing(e);
        }
    }
}
