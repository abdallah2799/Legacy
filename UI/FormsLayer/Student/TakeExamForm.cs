using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Core.Models;
using Common.Enums;

namespace UI.FormsLayer.Student
{
    public partial class TakeExamForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly LocalizationManager localizationManager;
        private readonly ThemeManager themeManager;
        private readonly SessionManager sessionManager;
        private readonly IStudentExamService _studentExamService;
        private readonly IStudentAnswerService _studentAnswerService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        private readonly int _studentExamId;
        private StudentExam? _studentExam;
        private List<Question> _questions = new();
        private List<StudentAnswer> _studentAnswers = new();
        private int _currentQuestionIndex = 0;
        private System.Windows.Forms.Timer _timer;
        private DateTime _examStartTime;
        private TimeSpan _timeRemaining;

        // Controls
        private MaterialLabel lblTitle;
        private MaterialLabel lblQuestionCounter;
        private MaterialLabel lblTimeRemaining;
        private MaterialLabel lblQuestionText;
        private MaterialButton btnPrevious;
        private MaterialButton btnNext;
        private MaterialButton btnSubmit;
        private MaterialButton btnMarkForReview;
        private Panel panelMain;
        private Panel panelTop;
        private Panel panelContent;
        private Panel panelQuestion;
        private Panel panelAnswers;
        private Panel panelNavigation;
        private Panel panelTimer;
        private MaterialLabel lblNoQuestions;

        public TakeExamForm(int studentExamId)
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
            lblQuestionCounter = new MaterialLabel();
            lblTimeRemaining = new MaterialLabel();
            lblQuestionText = new MaterialLabel();
            btnPrevious = new MaterialButton();
            btnNext = new MaterialButton();
            btnSubmit = new MaterialButton();
            btnMarkForReview = new MaterialButton();
            panelMain = new Panel();
            panelTop = new Panel();
            panelContent = new Panel();
            panelQuestion = new Panel();
            panelAnswers = new Panel();
            panelNavigation = new Panel();
            panelTimer = new Panel();
            lblNoQuestions = new MaterialLabel();

            // Configure form
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Take Exam";
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

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
            lblTitle.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Text = "Exam in Progress";

            // Question Counter
            lblQuestionCounter.AutoSize = true;
            lblQuestionCounter.Depth = 0;
            lblQuestionCounter.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblQuestionCounter.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblQuestionCounter.Location = new Point(20, 60);
            lblQuestionCounter.Text = "Question 1 of 10";

            // Time Remaining
            lblTimeRemaining.AutoSize = true;
            lblTimeRemaining.Depth = 0;
            lblTimeRemaining.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTimeRemaining.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblTimeRemaining.Location = new Point(800, 20);
            lblTimeRemaining.Text = "Time Remaining: 60:00";
            lblTimeRemaining.ForeColor = Color.Red;

            // Question Text
            lblQuestionText.AutoSize = true;
            lblQuestionText.Depth = 0;
            lblQuestionText.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblQuestionText.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            lblQuestionText.Location = new Point(20, 20);
            lblQuestionText.Size = new Size(800, 100);
            lblQuestionText.Text = "Question text will appear here...";

            // Previous button
            btnPrevious.AutoSize = false;
            btnPrevious.Size = new Size(120, 40);
            btnPrevious.Text = "Previous";
            btnPrevious.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnPrevious.Click += btnPrevious_Click;

            // Next button
            btnNext.AutoSize = false;
            btnNext.Size = new Size(120, 40);
            btnNext.Text = "Next";
            btnNext.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNext.Click += btnNext_Click;

            // Submit button
            btnSubmit.AutoSize = false;
            btnSubmit.Size = new Size(120, 40);
            btnSubmit.Text = "Submit Exam";
            btnSubmit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSubmit.Click += btnSubmit_Click;

            // Mark for Review button
            btnMarkForReview.AutoSize = false;
            btnMarkForReview.Size = new Size(120, 40);
            btnMarkForReview.Text = "Mark for Review";
            btnMarkForReview.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnMarkForReview.Click += btnMarkForReview_Click;

            // No questions label
            lblNoQuestions.AutoSize = true;
            lblNoQuestions.Depth = 0;
            lblNoQuestions.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNoQuestions.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblNoQuestions.Location = new Point(50, 200);
            lblNoQuestions.Text = "No questions found";
            lblNoQuestions.Visible = false;

            // Initialize timer
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000; // 1 second
            _timer.Tick += Timer_Tick;
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
                lblTitle, lblQuestionCounter, lblTimeRemaining
            });

            panelContent.Dock = DockStyle.Fill;
            panelContent.Controls.Add(panelNavigation);
            panelContent.Controls.Add(panelQuestion);
            panelContent.Controls.Add(lblNoQuestions);

            panelQuestion.Dock = DockStyle.Fill;
            panelQuestion.Location = new Point(20, 120);
            panelQuestion.Size = new Size(1160, 500);
            panelQuestion.Controls.Add(panelAnswers);
            panelQuestion.Controls.Add(lblQuestionText);

            panelAnswers.Dock = DockStyle.Fill;
            panelAnswers.Location = new Point(20, 150);
            panelAnswers.Size = new Size(800, 300);

            panelNavigation.Dock = DockStyle.Bottom;
            panelNavigation.Height = 80;
            panelNavigation.Controls.AddRange(new Control[] {
                btnPrevious, btnNext, btnSubmit, btnMarkForReview
            });

            // Position navigation buttons
            btnPrevious.Location = new Point(20, 20);
            btnNext.Location = new Point(160, 20);
            btnMarkForReview.Location = new Point(300, 20);
            btnSubmit.Location = new Point(440, 20);

            // Add controls to form
            this.Controls.Add(panelMain);
        }

        private void SetupForm()
        {
            materialSkinManager.AddFormToManage(this);
            themeManager.ApplyTheme(materialSkinManager);
            LoadExam();
        }

        private async void LoadExam()
        {
            try
            {
                // TODO: Implement GetByIdAsync method in IStudentExamService
                // For now, using a placeholder - this should be replaced with actual service call
                _studentExam = new StudentExam { StudentExamId = _studentExamId };
                if (_studentExam == null)
                {
                    MessageBox.Show("Exam not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                if (_studentExam.Exam == null)
                {
                    MessageBox.Show("Exam details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblTitle.Text = _studentExam.Exam.Title;
                // TODO: Implement GetByExamAsync method in IQuestionService
                // For now, using a placeholder
                _questions = new List<Question>();
                
                if (_questions.Count == 0)
                {
                    lblNoQuestions.Visible = true;
                    return;
                }

                // Start the exam
                await StartExam();
                LoadQuestion(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading exam: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async Task StartExam()
        {
            if (_studentExam == null) return;

            // TODO: Fix Status property - StudentExam doesn't have Status property
            // _studentExam.Status = ExamStatusEnum.InProgress;
            _studentExam.StartedAt = DateTime.Now;
            // TODO: Implement UpdateAsync method in IStudentExamService
            // await _studentExamService.UpdateAsync(_studentExam);

            _examStartTime = DateTime.Now;
            _timeRemaining = TimeSpan.FromMinutes(_studentExam.Exam?.DurationMinutes ?? 60);
            _timer.Start();
        }

        private void LoadQuestion(int questionIndex)
        {
            if (questionIndex < 0 || questionIndex >= _questions.Count)
                return;

            _currentQuestionIndex = questionIndex;
            var question = _questions[questionIndex];

            lblQuestionCounter.Text = $"Question {questionIndex + 1} of {_questions.Count}";
            lblQuestionText.Text = question.Body;

            // Clear previous answers
            panelAnswers.Controls.Clear();

            // Load answers based on question type
            LoadAnswersForQuestion(question);

            // Update navigation buttons
            btnPrevious.Enabled = questionIndex > 0;
            btnNext.Enabled = questionIndex < _questions.Count - 1;
        }

        private async void LoadAnswersForQuestion(Question question)
        {
            try
            {
                var answers = await _answerService.GetByQuestionAsync(question.QuestionId);
                
                switch (question.QuestionTypeEnum)
                {
                    case QuestionTypeEnum.TrueFalse:
                        LoadTrueFalseAnswers(answers.ToList());
                        break;
                    case QuestionTypeEnum.ChooseOne:
                        LoadChooseOneAnswers(answers.ToList());
                        break;
                    case QuestionTypeEnum.ChooseAll:
                        LoadChooseAllAnswers(answers.ToList());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading answers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrueFalseAnswers(List<Answer> answers)
        {
            var trueRadio = new MaterialRadioButton();
            trueRadio.Text = "True";
            trueRadio.Location = new Point(20, 20);
            trueRadio.Name = "trueRadio";

            var falseRadio = new MaterialRadioButton();
            falseRadio.Text = "False";
            falseRadio.Location = new Point(20, 60);
            falseRadio.Name = "falseRadio";

            panelAnswers.Controls.Add(trueRadio);
            panelAnswers.Controls.Add(falseRadio);
        }

        private void LoadChooseOneAnswers(List<Answer> answers)
        {
            int y = 20;
            foreach (var answer in answers)
            {
                var radio = new MaterialRadioButton();
                radio.Text = answer.Body;
                radio.Location = new Point(20, y);
                radio.Name = $"answer_{answer.AnswerId}";
                panelAnswers.Controls.Add(radio);
                y += 40;
            }
        }

        private void LoadChooseAllAnswers(List<Answer> answers)
        {
            int y = 20;
            foreach (var answer in answers)
            {
                var checkbox = new MaterialCheckbox();
                checkbox.Text = answer.Body;
                checkbox.Location = new Point(20, y);
                checkbox.Name = $"answer_{answer.AnswerId}";
                panelAnswers.Controls.Add(checkbox);
                y += 40;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentQuestionIndex > 0)
            {
                SaveCurrentAnswer();
                LoadQuestion(_currentQuestionIndex - 1);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentQuestionIndex < _questions.Count - 1)
            {
                SaveCurrentAnswer();
                LoadQuestion(_currentQuestionIndex + 1);
            }
        }

        private void btnMarkForReview_Click(object sender, EventArgs e)
        {
            // TODO: Implement mark for review functionality
            MessageBox.Show("Mark for review functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to submit the exam?", "Confirm Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SaveCurrentAnswer();
                await SubmitExam();
            }
        }

        private void SaveCurrentAnswer()
        {
            // TODO: Implement saving current answer
            // This would save the student's answer for the current question
        }

        private async Task SubmitExam()
        {
            try
            {
                if (_studentExam == null) return;

                // TODO: Fix Status property - StudentExam doesn't have Status property
                // _studentExam.Status = ExamStatusEnum.Completed;
                _studentExam.SubmittedAt = DateTime.Now;
                // TODO: Implement UpdateAsync method in IStudentExamService
                // await _studentExamService.UpdateAsync(_studentExam);

                _timer.Stop();
                MessageBox.Show("Exam submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                var myExamsForm = new MyExamsForm(_studentExamService, null);
                myExamsForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting exam: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timeRemaining = _timeRemaining.Subtract(TimeSpan.FromSeconds(1));
            
            if (_timeRemaining.TotalSeconds <= 0)
            {
                _timer.Stop();
                MessageBox.Show("Time's up! The exam will be submitted automatically.", "Time Up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SubmitExam();
                return;
            }

            lblTimeRemaining.Text = $"Time Remaining: {_timeRemaining.ToString(@"mm\:ss")}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    "Are you sure you want to exit the exam? Your progress will be saved.",
                    "Exit Exam",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    SaveCurrentAnswer();
                    _timer?.Stop();
                }
            }
            base.OnFormClosing(e);
        }
    }
}
