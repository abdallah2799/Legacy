using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Core.Models;
using Common.Enums;
using UI.FormsLayer.Shared;

namespace UI.FormsLayer.Student
{
    public partial class MyExamsForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly LocalizationManager localizationManager;
        private readonly ThemeManager themeManager;
        private readonly SessionManager sessionManager;
        private readonly IStudentExamService _studentExamService;
        private readonly IExamService _examService;

        // Controls
        private MaterialLabel lblTitle;
        private MaterialLabel lblSubtitle;
        private MaterialComboBox cmbLanguage;
        private MaterialButton btnTheme;
        private MaterialButton btnBackToDashboard;
        private MaterialButton btnRefresh;
        private MaterialButton btnStartExam;
        private MaterialButton btnViewResults;
        private MaterialTabControl tabExams;
        private TabPage tabUpcoming;
        private TabPage tabInProgress;
        private TabPage tabCompleted;
        private DataGridView dgvUpcoming;
        private DataGridView dgvInProgress;
        private DataGridView dgvCompleted;
        private Panel panelMain;
        private Panel panelTop;
        private Panel panelContent;
        private MaterialLabel lblNoUpcoming;
        private MaterialLabel lblNoInProgress;
        private MaterialLabel lblNoCompleted;

        public MyExamsForm(IStudentExamService studentExamService, IExamService examService)
        {
            _studentExamService = studentExamService;
            _examService = examService;

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
            btnRefresh = new MaterialButton();
            btnStartExam = new MaterialButton();
            btnViewResults = new MaterialButton();
            tabExams = new MaterialTabControl();
            tabUpcoming = new TabPage();
            tabInProgress = new TabPage();
            tabCompleted = new TabPage();
            dgvUpcoming = new DataGridView();
            dgvInProgress = new DataGridView();
            dgvCompleted = new DataGridView();
            panelMain = new Panel();
            panelTop = new Panel();
            panelContent = new Panel();
            lblNoUpcoming = new MaterialLabel();
            lblNoInProgress = new MaterialLabel();
            lblNoCompleted = new MaterialLabel();

            // Configure form
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "My Exams";
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
            lblTitle.Text = "My Exams";

            // Subtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.Depth = 0;
            lblSubtitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSubtitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblSubtitle.Location = new Point(20, 70);
            lblSubtitle.Text = "View and manage your exams";

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

            // Refresh button
            btnRefresh.AutoSize = false;
            btnRefresh.Size = new Size(100, 50);
            btnRefresh.Location = new Point(420, 20);
            btnRefresh.Text = "Refresh";
            btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRefresh.Click += btnRefresh_Click;

            // Start Exam button
            btnStartExam.AutoSize = false;
            btnStartExam.Size = new Size(120, 40);
            btnStartExam.Text = "Start Exam";
            btnStartExam.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnStartExam.Click += btnStartExam_Click;

            // View Results button
            btnViewResults.AutoSize = false;
            btnViewResults.Size = new Size(120, 40);
            btnViewResults.Text = "View Results";
            btnViewResults.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnViewResults.Click += btnViewResults_Click;

            // Tab Control
            tabExams.Dock = DockStyle.Fill;
            tabExams.Location = new Point(20, 120);
            tabExams.Size = new Size(1160, 560);
            tabExams.Controls.Add(tabUpcoming);
            tabExams.Controls.Add(tabInProgress);
            tabExams.Controls.Add(tabCompleted);

            // Upcoming tab
            tabUpcoming.Text = "Upcoming";
            tabUpcoming.Controls.Add(dgvUpcoming);
            tabUpcoming.Controls.Add(lblNoUpcoming);

            // In Progress tab
            tabInProgress.Text = "In Progress";
            tabInProgress.Controls.Add(dgvInProgress);
            tabInProgress.Controls.Add(lblNoInProgress);

            // Completed tab
            tabCompleted.Text = "Completed";
            tabCompleted.Controls.Add(dgvCompleted);
            tabCompleted.Controls.Add(lblNoCompleted);

            // Configure DataGridViews
            ConfigureDataGridView(dgvUpcoming);
            ConfigureDataGridView(dgvInProgress);
            ConfigureDataGridView(dgvCompleted);

            // No data labels
            ConfigureNoDataLabel(lblNoUpcoming, "No upcoming exams");
            ConfigureNoDataLabel(lblNoInProgress, "No exams in progress");
            ConfigureNoDataLabel(lblNoCompleted, "No completed exams");
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 56;
            dgv.Dock = DockStyle.Fill;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(255, 255, 255);
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 51;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ConfigureNoDataLabel(MaterialLabel lbl, string text)
        {
            lbl.AutoSize = true;
            lbl.Depth = 0;
            lbl.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lbl.Location = new Point(50, 200);
            lbl.Text = text;
            lbl.Visible = false;
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
                cmbLanguage, btnTheme, btnBackToDashboard, btnRefresh
            });

            panelContent.Dock = DockStyle.Fill;
            panelContent.Controls.Add(tabExams);
            panelContent.Controls.Add(lblTitle);
            panelContent.Controls.Add(lblSubtitle);

            // Add action buttons to each tab
            var upcomingPanel = new Panel();
            upcomingPanel.Dock = DockStyle.Top;
            upcomingPanel.Height = 60;
            upcomingPanel.Controls.Add(btnStartExam);
            btnStartExam.Location = new Point(20, 10);
            tabUpcoming.Controls.Add(upcomingPanel);

            var inProgressPanel = new Panel();
            inProgressPanel.Dock = DockStyle.Top;
            inProgressPanel.Height = 60;
            inProgressPanel.Controls.Add(btnStartExam);
            btnStartExam.Location = new Point(20, 10);
            tabInProgress.Controls.Add(inProgressPanel);

            var completedPanel = new Panel();
            completedPanel.Dock = DockStyle.Top;
            completedPanel.Height = 60;
            completedPanel.Controls.Add(btnViewResults);
            btnViewResults.Location = new Point(20, 10);
            tabCompleted.Controls.Add(completedPanel);

            // Add controls to form
            this.Controls.Add(panelMain);
        }

        private void SetupForm()
        {
            materialSkinManager.AddFormToManage(this);
            themeManager.ApplyTheme(materialSkinManager);
            LoadExams();
        }

        private async void LoadExams()
        {
            try
            {
                var studentId = sessionManager.StudentId;
                if (studentId == 0)
                {
                    MessageBox.Show("Student ID not found in session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var studentExams = await _studentExamService.GetByStudentAsync(studentId ?? 0);
                
                // Separate exams by status
                // TODO: Fix Status property - StudentExam doesn't have Status property
                var upcoming = studentExams.Where(se => se.Exam?.Status == ExamStatusEnum.Queued).ToList();
                // TODO: Fix Status property - StudentExam doesn't have Status property
                var inProgress = new List<StudentExam>(); // studentExams.Where(se => se.Status == ExamStatusEnum.InProgress).ToList();
                var completed = new List<StudentExam>(); // studentExams.Where(se => se.Status == ExamStatusEnum.Completed).ToList();

                // Load upcoming exams
                dgvUpcoming.DataSource = upcoming.Select(se => new
                {
                    se.StudentExamId,
                    ExamTitle = se.Exam?.Title ?? "N/A",
                    CourseName = se.Exam?.TrackCourse?.Course?.Name ?? "N/A",
                    ScheduledAt = se.Exam?.ScheduledAt?.ToString("yyyy-MM-dd HH:mm") ?? "N/A",
                    Duration = $"{se.Exam?.DurationMinutes ?? 0} minutes",
                    ExamType = se.Exam?.ExamTypeEnum.ToString() ?? "N/A"
                }).ToList();
                lblNoUpcoming.Visible = upcoming.Count == 0;

                // Load in progress exams
                dgvInProgress.DataSource = inProgress.Select(se => new
                {
                    se.StudentExamId,
                    ExamTitle = se.Exam?.Title ?? "N/A",
                    CourseName = se.Exam?.TrackCourse?.Course?.Name ?? "N/A",
                    StartedAt = se.StartedAt?.ToString("yyyy-MM-dd HH:mm") ?? "N/A",
                    TimeRemaining = CalculateTimeRemaining(se),
                    ExamType = se.Exam?.ExamTypeEnum.ToString() ?? "N/A"
                }).ToList();
                lblNoInProgress.Visible = inProgress.Count == 0;

                // Load completed exams
                dgvCompleted.DataSource = completed.Select(se => new
                {
                    se.StudentExamId,
                    ExamTitle = se.Exam?.Title ?? "N/A",
                    CourseName = se.Exam?.TrackCourse?.Course?.Name ?? "N/A",
                    Score = se.Score?.ToString() ?? "N/A",
                    // TODO: Add Percentage and IsPassed properties to StudentExam model
                    Percentage = "N/A",
                    IsPassed = "N/A",
                    SubmittedAt = se.SubmittedAt?.ToString("yyyy-MM-dd HH:mm") ?? "N/A"
                }).ToList();
                lblNoCompleted.Visible = completed.Count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading exams: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CalculateTimeRemaining(StudentExam studentExam)
        {
            if (studentExam.Exam?.DurationMinutes == null || studentExam.StartedAt == null)
                return "N/A";

            var totalMinutes = studentExam.Exam.DurationMinutes;
            var elapsed = DateTime.Now - studentExam.StartedAt.Value;
            var remaining = totalMinutes - (int)elapsed.TotalMinutes;

            if (remaining <= 0)
                return "Time Up";
            
            return $"{remaining} minutes";
        }

        private void btnStartExam_Click(object sender, EventArgs e)
        {
            DataGridView currentDgv = GetCurrentDataGridView();
            if (currentDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an exam to start", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var studentExamId = (int)currentDgv.SelectedRows[0].Cells["Id"].Value;
            var takeExamForm = new TakeExamForm(studentExamId);
            takeExamForm.Show();
            this.Hide();
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            if (dgvCompleted.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an exam to view results", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var studentExamId = (int)dgvCompleted.SelectedRows[0].Cells["Id"].Value;
            var resultsForm = new ExamResultsForm(studentExamId);
            resultsForm.Show();
            this.Hide();
        }

        private DataGridView GetCurrentDataGridView()
        {
            return tabExams.SelectedTab switch
            {
                var tab when tab == tabUpcoming => dgvUpcoming,
                var tab when tab == tabInProgress => dgvInProgress,
                var tab when tab == tabCompleted => dgvCompleted,
                _ => dgvUpcoming
            };
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadExams();
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
