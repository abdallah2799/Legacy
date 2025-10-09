using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Core.Models;
using UI.FormsLayer.Shared;

namespace UI.FormsLayer.Instructor
{
    public partial class MyCoursesForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly LocalizationManager localizationManager;
        private readonly ThemeManager themeManager;
        private readonly SessionManager sessionManager;
        private readonly ICourseService _courseService;
        private readonly IInstructorCourseService _instructorCourseService;

        // Controls
        private MaterialLabel lblTitle;
        private MaterialLabel lblSubtitle;
        private MaterialComboBox cmbLanguage;
        private MaterialButton btnTheme;
        private MaterialButton btnBackToDashboard;
        private MaterialButton btnRefresh;
        private MaterialButton btnViewCourse;
        private MaterialButton btnManageExams;
        private MaterialTextBox txtSearch;
        private DataGridView dgvCourses;
        private Panel panelMain;
        private Panel panelTop;
        private Panel panelContent;
        private Panel panelCourses;
        private MaterialLabel lblNoCourses;

        public MyCoursesForm(ICourseService courseService, IInstructorCourseService instructorCourseService)
        {
            _courseService = courseService;
            _instructorCourseService = instructorCourseService;

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
            btnViewCourse = new MaterialButton();
            btnManageExams = new MaterialButton();
            txtSearch = new MaterialTextBox();
            dgvCourses = new DataGridView();
            panelMain = new Panel();
            panelTop = new Panel();
            panelContent = new Panel();
            panelCourses = new Panel();
            lblNoCourses = new MaterialLabel();

            // Configure form
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "My Courses";
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
            lblTitle.Text = "My Courses";

            // Subtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.Depth = 0;
            lblSubtitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSubtitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblSubtitle.Location = new Point(20, 70);
            lblSubtitle.Text = "Manage your assigned courses and exams";

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

            // View Course button
            btnViewCourse.AutoSize = false;
            btnViewCourse.Size = new Size(120, 40);
            btnViewCourse.Text = "View Course";
            btnViewCourse.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnViewCourse.Click += btnViewCourse_Click;

            // Manage Exams button
            btnManageExams.AutoSize = false;
            btnManageExams.Size = new Size(120, 40);
            btnManageExams.Text = "Manage Exams";
            btnManageExams.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnManageExams.Click += btnManageExams_Click;

            // Search textbox
            txtSearch.Hint = "Search courses...";
            txtSearch.Size = new Size(200, 50);
            txtSearch.TextChanged += txtSearch_TextChanged;

            // DataGridView
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCourses.BackgroundColor = Color.White;
            dgvCourses.BorderStyle = BorderStyle.None;
            dgvCourses.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvCourses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCourses.ColumnHeadersHeight = 56;
            dgvCourses.Dock = DockStyle.Fill;
            dgvCourses.EnableHeadersVisualStyles = false;
            dgvCourses.GridColor = Color.FromArgb(255, 255, 255);
            dgvCourses.Location = new Point(0, 0);
            dgvCourses.Margin = new Padding(4, 5, 4, 5);
            dgvCourses.MultiSelect = false;
            dgvCourses.Name = "dgvCourses";
            dgvCourses.ReadOnly = true;
            dgvCourses.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.Size = new Size(1000, 400);
            dgvCourses.TabIndex = 0;

            // No courses label
            lblNoCourses.AutoSize = true;
            lblNoCourses.Depth = 0;
            lblNoCourses.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNoCourses.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblNoCourses.Location = new Point(50, 200);
            lblNoCourses.Text = "No courses assigned";
            lblNoCourses.Visible = false;
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
            panelContent.Controls.Add(panelCourses);
            panelContent.Controls.Add(lblTitle);
            panelContent.Controls.Add(lblSubtitle);

            panelCourses.Dock = DockStyle.Fill;
            panelCourses.Location = new Point(20, 120);
            panelCourses.Size = new Size(1160, 560);
            panelCourses.Controls.Add(dgvCourses);
            panelCourses.Controls.Add(lblNoCourses);

            // Add filter controls to a separate panel
            var filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 60;
            filterPanel.Controls.AddRange(new Control[] {
                txtSearch, btnViewCourse, btnManageExams
            });

            // Position filter controls
            txtSearch.Location = new Point(20, 10);
            btnViewCourse.Location = new Point(240, 10);
            btnManageExams.Location = new Point(380, 10);

            panelCourses.Controls.Add(filterPanel);

            // Add controls to form
            this.Controls.Add(panelMain);
        }

        private void SetupForm()
        {
            materialSkinManager.AddFormToManage(this);
            themeManager.ApplyTheme(materialSkinManager);
            LoadCourses();
        }

        private async void LoadCourses()
        {
            try
            {
                var instructorId = sessionManager.InstructorId;
                if (instructorId == 0)
                {
                    MessageBox.Show("Instructor ID not found in session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var courses = await _instructorCourseService.GetCoursesByInstructorAsync(instructorId ?? 0);
                dgvCourses.DataSource = courses.Select(c => new
                {
                    c.CourseId,
                    c.Name,
                    c.Description,
                    TrackName = "N/A", // TODO: Add Track navigation property to Course model
                    ExamCount = 0, // TODO: Add Exams navigation property to Course model
                    StudentCount = 0, // TODO: Add Students navigation property to Course model
                    CreatedAt = "N/A" // TODO: Add CreatedAt property to Course model
                }).ToList();

                lblNoCourses.Visible = courses.Count() == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewCourse_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a course to view", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Open CourseDetailsForm
            MessageBox.Show("View Course functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnManageExams_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a course to manage exams", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var courseId = (int)dgvCourses.SelectedRows[0].Cells["Id"].Value;
            var examManagementForm = new ExamManagementForm(courseId);
            examManagementForm.Show();
            this.Hide();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement search filtering
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCourses();
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
