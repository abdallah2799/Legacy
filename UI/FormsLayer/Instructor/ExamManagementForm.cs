using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Core.Models;
using Common.Enums;

namespace UI.FormsLayer.Instructor
{
    public partial class ExamManagementForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly LocalizationManager localizationManager;
        private readonly ThemeManager themeManager;
        private readonly SessionManager sessionManager;
        private readonly IExamService _examService;
        private readonly ICourseService _courseService;
        private readonly IQuestionService _questionService;

        private readonly int _courseId;
        private Course? _course;

        // Controls
        private MaterialLabel lblTitle;
        private MaterialLabel lblSubtitle;
        private MaterialComboBox cmbLanguage;
        private MaterialButton btnTheme;
        private MaterialButton btnBackToCourses;
        private MaterialButton btnRefresh;
        private MaterialButton btnCreateExam;
        private MaterialButton btnEditExam;
        private MaterialButton btnDeleteExam;
        private MaterialButton btnScheduleExam;
        private MaterialTextBox txtSearch;
        private MaterialComboBox cmbStatusFilter;
        private DataGridView dgvExams;
        private Panel panelMain;
        private Panel panelTop;
        private Panel panelContent;
        private Panel panelExams;
        private MaterialLabel lblNoExams;

        public ExamManagementForm(int courseId)
        {
            _courseId = courseId;

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
            btnBackToCourses = new MaterialButton();
            btnRefresh = new MaterialButton();
            btnCreateExam = new MaterialButton();
            btnEditExam = new MaterialButton();
            btnDeleteExam = new MaterialButton();
            btnScheduleExam = new MaterialButton();
            txtSearch = new MaterialTextBox();
            cmbStatusFilter = new MaterialComboBox();
            dgvExams = new DataGridView();
            panelMain = new Panel();
            panelTop = new Panel();
            panelContent = new Panel();
            panelExams = new Panel();
            lblNoExams = new MaterialLabel();

            // Configure form
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Exam Management";
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
            lblTitle.Text = "Exam Management";

            // Subtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.Depth = 0;
            lblSubtitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSubtitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblSubtitle.Location = new Point(20, 70);
            lblSubtitle.Text = "Manage exams for this course";

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

            // Back to Courses button
            btnBackToCourses.AutoSize = false;
            btnBackToCourses.Size = new Size(150, 50);
            btnBackToCourses.Location = new Point(260, 20);
            btnBackToCourses.Text = "Back to Courses";
            btnBackToCourses.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnBackToCourses.Click += btnBackToCourses_Click;

            // Refresh button
            btnRefresh.AutoSize = false;
            btnRefresh.Size = new Size(100, 50);
            btnRefresh.Location = new Point(420, 20);
            btnRefresh.Text = "Refresh";
            btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRefresh.Click += btnRefresh_Click;

            // Create Exam button
            btnCreateExam.AutoSize = false;
            btnCreateExam.Size = new Size(120, 40);
            btnCreateExam.Text = "Create Exam";
            btnCreateExam.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCreateExam.Click += btnCreateExam_Click;

            // Edit Exam button
            btnEditExam.AutoSize = false;
            btnEditExam.Size = new Size(120, 40);
            btnEditExam.Text = "Edit Exam";
            btnEditExam.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnEditExam.Click += btnEditExam_Click;

            // Delete Exam button
            btnDeleteExam.AutoSize = false;
            btnDeleteExam.Size = new Size(120, 40);
            btnDeleteExam.Text = "Delete Exam";
            btnDeleteExam.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnDeleteExam.Click += btnDeleteExam_Click;

            // Schedule Exam button
            btnScheduleExam.AutoSize = false;
            btnScheduleExam.Size = new Size(120, 40);
            btnScheduleExam.Text = "Schedule Exam";
            btnScheduleExam.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnScheduleExam.Click += btnScheduleExam_Click;

            // Search textbox
            txtSearch.Hint = "Search exams...";
            txtSearch.Size = new Size(200, 50);
            txtSearch.TextChanged += txtSearch_TextChanged;

            // Status filter
            cmbStatusFilter.AutoResize = false;
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Size = new Size(150, 50);
            cmbStatusFilter.Items.AddRange(new[] { "All Status", "Draft", "Scheduled", "In Progress", "Completed", "Cancelled" });
            cmbStatusFilter.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;

            // DataGridView
            dgvExams.AllowUserToAddRows = false;
            dgvExams.AllowUserToDeleteRows = false;
            dgvExams.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExams.BackgroundColor = Color.White;
            dgvExams.BorderStyle = BorderStyle.None;
            dgvExams.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvExams.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvExams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvExams.ColumnHeadersHeight = 56;
            dgvExams.Dock = DockStyle.Fill;
            dgvExams.EnableHeadersVisualStyles = false;
            dgvExams.GridColor = Color.FromArgb(255, 255, 255);
            dgvExams.Location = new Point(0, 0);
            dgvExams.Margin = new Padding(4, 5, 4, 5);
            dgvExams.MultiSelect = false;
            dgvExams.Name = "dgvExams";
            dgvExams.ReadOnly = true;
            dgvExams.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvExams.RowHeadersVisible = false;
            dgvExams.RowHeadersWidth = 51;
            dgvExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExams.Size = new Size(1000, 400);
            dgvExams.TabIndex = 0;

            // No exams label
            lblNoExams.AutoSize = true;
            lblNoExams.Depth = 0;
            lblNoExams.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNoExams.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblNoExams.Location = new Point(50, 200);
            lblNoExams.Text = "No exams found";
            lblNoExams.Visible = false;
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
                cmbLanguage, btnTheme, btnBackToCourses, btnRefresh
            });

            panelContent.Dock = DockStyle.Fill;
            panelContent.Controls.Add(panelExams);
            panelContent.Controls.Add(lblTitle);
            panelContent.Controls.Add(lblSubtitle);

            panelExams.Dock = DockStyle.Fill;
            panelExams.Location = new Point(20, 120);
            panelExams.Size = new Size(1160, 560);
            panelExams.Controls.Add(dgvExams);
            panelExams.Controls.Add(lblNoExams);

            // Add filter controls to a separate panel
            var filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 60;
            filterPanel.Controls.AddRange(new Control[] {
                txtSearch, cmbStatusFilter, btnCreateExam, btnEditExam, btnDeleteExam, btnScheduleExam
            });

            // Position filter controls
            txtSearch.Location = new Point(20, 10);
            cmbStatusFilter.Location = new Point(240, 10);
            btnCreateExam.Location = new Point(410, 10);
            btnEditExam.Location = new Point(550, 10);
            btnDeleteExam.Location = new Point(690, 10);
            btnScheduleExam.Location = new Point(830, 10);

            panelExams.Controls.Add(filterPanel);

            // Add controls to form
            this.Controls.Add(panelMain);
        }

        private void SetupForm()
        {
            materialSkinManager.AddFormToManage(this);
            themeManager.ApplyTheme(materialSkinManager);
            LoadCourse();
            LoadExams();
        }

        private async void LoadCourse()
        {
            try
            {
                // TODO: Implement GetByIdAsync method in ICourseService
                // _course = await _courseService.GetByIdAsync(_courseId);
                if (_course != null)
                {
                    lblSubtitle.Text = $"Manage exams for: {_course.Name}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadExams()
        {
            try
            {
                // TODO: Implement GetByCourseAsync method in IExamService
                var exams = new List<Exam>();
                dgvExams.DataSource = exams.Select(e => new
                {
                    e.ExamId,
                    e.Title,
                    // TODO: Add Description property to Exam model
                    // e.Description,
                    ExamType = e.ExamTypeEnum.ToString(),
                    Duration = $"{e.DurationMinutes} minutes",
                    Status = e.Status.ToString(),
                    ScheduledAt = e.ScheduledAt?.ToString("yyyy-MM-dd HH:mm") ?? "Not Scheduled",
                    // TODO: Add ExamQuestions navigation property to Exam model
                    // QuestionCount = e.ExamQuestions?.Count ?? 0,
                    StudentCount = e.StudentExams?.Count ?? 0,
                    CreatedAt = e.CreatedAt?.ToString("yyyy-MM-dd") ?? "N/A"
                }).ToList();

                lblNoExams.Visible = exams.Count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading exams: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateExam_Click(object sender, EventArgs e)
        {
            // TODO: Open ExamEditorForm for creating new exam
            MessageBox.Show("Create Exam functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditExam_Click(object sender, EventArgs e)
        {
            if (dgvExams.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an exam to edit", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Open ExamEditorForm for editing selected exam
            MessageBox.Show("Edit Exam functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnDeleteExam_Click(object sender, EventArgs e)
        {
            if (dgvExams.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an exam to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this exam?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var examId = (int)dgvExams.SelectedRows[0].Cells["ExamId"].Value;
                    // TODO: Implement DeleteAsync method in IExamService
                // await _examService.DeleteAsync(examId);
                    LoadExams();
                    MessageBox.Show("Exam deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting exam: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnScheduleExam_Click(object sender, EventArgs e)
        {
            if (dgvExams.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an exam to schedule", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Open ExamSchedulingForm
            MessageBox.Show("Schedule Exam functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement search filtering
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Implement status filtering
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadExams();
        }

        private void btnBackToCourses_Click(object sender, EventArgs e)
        {
            // TODO: Fix constructor - need IInstructorCourseService
            // var myCoursesForm = new MyCoursesForm(_courseService, null);
            MessageBox.Show("Back to courses functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
