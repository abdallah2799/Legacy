using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Core.Models;

namespace UI.FormsLayer.Student
{
    public partial class ExamResultsForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly LocalizationManager localizationManager;
        private readonly ThemeManager themeManager;
        private readonly SessionManager sessionManager;
        private readonly IStudentExamService _studentExamService;
        private readonly IStudentAnswerService _studentAnswerService;

        private readonly int _studentExamId;
        private StudentExam? _studentExam;

        // Controls
        private MaterialLabel lblTitle;
        private MaterialLabel lblExamTitle;
        private MaterialLabel lblScore;
        private MaterialLabel lblPercentage;
        private MaterialLabel lblPassed;
        private MaterialLabel lblTimeTaken;
        private MaterialComboBox cmbLanguage;
        private MaterialButton btnTheme;
        private MaterialButton btnBackToExams;
        private MaterialButton btnViewDetails;
        private DataGridView dgvQuestionResults;
        private Panel panelMain;
        private Panel panelTop;
        private Panel panelContent;
        private Panel panelResults;
        private Panel panelSummary;
        private MaterialLabel lblNoResults;

        public ExamResultsForm(int studentExamId)
        {
            _studentExamId = studentExamId;

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
            lblExamTitle = new MaterialLabel();
            lblScore = new MaterialLabel();
            lblPercentage = new MaterialLabel();
            lblPassed = new MaterialLabel();
            lblTimeTaken = new MaterialLabel();
            cmbLanguage = new MaterialComboBox();
            btnTheme = new MaterialButton();
            btnBackToExams = new MaterialButton();
            btnViewDetails = new MaterialButton();
            dgvQuestionResults = new DataGridView();
            panelMain = new Panel();
            panelTop = new Panel();
            panelContent = new Panel();
            panelResults = new Panel();
            panelSummary = new Panel();
            lblNoResults = new MaterialLabel();

            // Configure form
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Exam Results";
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
            lblTitle.Text = "Exam Results";

            // Exam Title
            lblExamTitle.AutoSize = true;
            lblExamTitle.Depth = 0;
            lblExamTitle.Font = new Font("Roboto", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblExamTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblExamTitle.Location = new Point(20, 70);
            lblExamTitle.Text = "Exam Title";

            // Score
            lblScore.AutoSize = true;
            lblScore.Depth = 0;
            lblScore.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblScore.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblScore.Location = new Point(20, 110);
            lblScore.Text = "Score: 0/100";

            // Percentage
            lblPercentage.AutoSize = true;
            lblPercentage.Depth = 0;
            lblPercentage.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblPercentage.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblPercentage.Location = new Point(200, 110);
            lblPercentage.Text = "Percentage: 0%";

            // Passed
            lblPassed.AutoSize = true;
            lblPassed.Depth = 0;
            lblPassed.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblPassed.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblPassed.Location = new Point(400, 110);
            lblPassed.Text = "Status: Passed";
            lblPassed.ForeColor = Color.Green;

            // Time Taken
            lblTimeTaken.AutoSize = true;
            lblTimeTaken.Depth = 0;
            lblTimeTaken.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTimeTaken.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblTimeTaken.Location = new Point(20, 150);
            lblTimeTaken.Text = "Time Taken: 45 minutes";

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

            // Back to Exams button
            btnBackToExams.AutoSize = false;
            btnBackToExams.Size = new Size(150, 50);
            btnBackToExams.Location = new Point(260, 20);
            btnBackToExams.Text = "Back to Exams";
            btnBackToExams.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnBackToExams.Click += btnBackToExams_Click;

            // View Details button
            btnViewDetails.AutoSize = false;
            btnViewDetails.Size = new Size(120, 40);
            btnViewDetails.Text = "View Details";
            btnViewDetails.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnViewDetails.Click += btnViewDetails_Click;

            // DataGridView
            dgvQuestionResults.AllowUserToAddRows = false;
            dgvQuestionResults.AllowUserToDeleteRows = false;
            dgvQuestionResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuestionResults.BackgroundColor = Color.White;
            dgvQuestionResults.BorderStyle = BorderStyle.None;
            dgvQuestionResults.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvQuestionResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvQuestionResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvQuestionResults.ColumnHeadersHeight = 56;
            dgvQuestionResults.Dock = DockStyle.Fill;
            dgvQuestionResults.EnableHeadersVisualStyles = false;
            dgvQuestionResults.GridColor = Color.FromArgb(255, 255, 255);
            dgvQuestionResults.Location = new Point(0, 0);
            dgvQuestionResults.Margin = new Padding(4, 5, 4, 5);
            dgvQuestionResults.MultiSelect = false;
            dgvQuestionResults.Name = "dgvQuestionResults";
            dgvQuestionResults.ReadOnly = true;
            dgvQuestionResults.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvQuestionResults.RowHeadersVisible = false;
            dgvQuestionResults.RowHeadersWidth = 51;
            dgvQuestionResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuestionResults.Size = new Size(1000, 300);
            dgvQuestionResults.TabIndex = 0;

            // No results label
            lblNoResults.AutoSize = true;
            lblNoResults.Depth = 0;
            lblNoResults.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNoResults.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblNoResults.Location = new Point(50, 200);
            lblNoResults.Text = "No results found";
            lblNoResults.Visible = false;
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
                cmbLanguage, btnTheme, btnBackToExams
            });

            panelContent.Dock = DockStyle.Fill;
            panelContent.Controls.Add(panelResults);
            panelContent.Controls.Add(panelSummary);
            panelContent.Controls.Add(lblTitle);

            panelSummary.Dock = DockStyle.Top;
            panelSummary.Height = 200;
            panelSummary.Controls.AddRange(new Control[] {
                lblExamTitle, lblScore, lblPercentage, lblPassed, lblTimeTaken, btnViewDetails
            });

            panelResults.Dock = DockStyle.Fill;
            panelResults.Location = new Point(20, 220);
            panelResults.Size = new Size(1160, 400);
            panelResults.Controls.Add(dgvQuestionResults);
            panelResults.Controls.Add(lblNoResults);

            // Position summary controls
            btnViewDetails.Location = new Point(600, 110);

            // Add controls to form
            this.Controls.Add(panelMain);
        }

        private void SetupForm()
        {
            materialSkinManager.AddFormToManage(this);
            themeManager.ApplyTheme(materialSkinManager);
            LoadResults();
        }

        private async void LoadResults()
        {
            try
            {
                // TODO: Implement GetByIdAsync method in IStudentExamService
                _studentExam = new StudentExam { StudentExamId = _studentExamId };
                if (_studentExam == null)
                {
                    MessageBox.Show("Exam results not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                if (_studentExam.Exam == null)
                {
                    MessageBox.Show("Exam details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Update summary labels
                lblExamTitle.Text = _studentExam.Exam.Title;
                lblScore.Text = $"Score: {_studentExam.Score ?? 0}/{_studentExam.Exam.FullMark ?? 100}";
                // TODO: Fix Percentage and IsPassed properties - StudentExam doesn't have these properties
                lblPercentage.Text = $"Percentage: N/A%";
                lblPassed.Text = $"Status: N/A";
                lblPassed.ForeColor = Color.Gray;

                if (_studentExam.StartedAt.HasValue && _studentExam.SubmittedAt.HasValue)
                {
                    var timeTaken = _studentExam.SubmittedAt.Value - _studentExam.StartedAt.Value;
                    lblTimeTaken.Text = $"Time Taken: {timeTaken.ToString(@"hh\:mm\:ss")}";
                }

                // Load question results
                await LoadQuestionResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading results: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadQuestionResults()
        {
            try
            {
                // TODO: Implement GetByStudentExamAsync method in IStudentAnswerService
                var studentAnswers = new List<StudentAnswer>();
                
                dgvQuestionResults.DataSource = studentAnswers.Select(sa => new
                {
                    QuestionNumber = sa.Question?.QuestionId ?? 0,
                    QuestionText = sa.Question?.Body ?? "N/A",
                    StudentAnswer = sa.Answer?.Body ?? "No answer",
                    CorrectAnswer = GetCorrectAnswer(sa.Question),
                    IsCorrect = sa.IsCorrect ? "Yes" : "No",
                    // TODO: Add Points and TimeSpent properties to StudentAnswer model
                    Points = 0,
                    TimeSpent = "N/A"
                }).ToList();

                lblNoResults.Visible = studentAnswers.Count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading question results: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCorrectAnswer(Question? question)
        {
            if (question == null) return "N/A";
            
            // TODO: Implement getting correct answer based on question type
            return "Correct answer will be shown here";
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvQuestionResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a question to view details", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Open QuestionDetailsForm
            MessageBox.Show("View Question Details functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBackToExams_Click(object sender, EventArgs e)
        {
            // TODO: Fix constructor - need IExamService
            // var myExamsForm = new MyExamsForm(_studentExamService, null);
            MessageBox.Show("Back to exams functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
