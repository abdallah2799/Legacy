using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Core.Models;
using Common.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace UI.FormsLayer.Shared
{
    public partial class GuestPracticeForm : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;
        
        // Services
        private readonly ICourseService _courseService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        
        // Form state
        private bool _isPracticeMode = false;
        private List<Course> _courses = new List<Course>();
        private List<Question> _questions = new List<Question>();
        private List<Answer> _answers = new List<Answer>();
        private int _currentQuestionIndex = 0;
        private Dictionary<int, List<int>> _selectedAnswers = new Dictionary<int, List<int>>();
        
        // Course selection controls
        private MaterialComboBox cmbCourse;
        private MaterialLabel lblCourseDescription;
        private MaterialButton btnStartPractice;
        
        // Practice mode controls
        private MaterialLabel lblQuestionTitle;
        private MaterialLabel lblQuestionText;
        private MaterialLabel lblQuestionCounter;
        private MaterialButton btnPreviousQuestion;
        private MaterialButton btnNextQuestion;
        private MaterialButton btnCheckAnswer;
        private MaterialButton btnExitPractice;
        private Panel panelAnswers;
        private List<MaterialCheckbox> answerCheckboxes = new List<MaterialCheckbox>();
        private MaterialLabel lblAnswerFeedback;

        public GuestPracticeForm()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            SetupEventHandlers();
            
            // Get services from DI
            var serviceProvider = Program.ServiceProvider;
            _courseService = serviceProvider.GetRequiredService<ICourseService>();
            _questionService = serviceProvider.GetRequiredService<IQuestionService>();
            _answerService = serviceProvider.GetRequiredService<IAnswerService>();
            
            LoadCoursesAsync();
        }

        private void InitializeMaterialSkin()
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue700,
                Primary.Blue800,
                Primary.Blue500,
                Accent.Blue400,
                TextShade.WHITE
            );

            // Initialize managers
            localizationManager = LocalizationManager.Instance;
            themeManager = ThemeManager.Instance;
            
            // Apply current theme
            themeManager.ApplyTheme(materialSkinManager);
            
            // Update UI text
            UpdateUIText();
        }

        private void SetupEventHandlers()
        {
            // Language change event
            localizationManager.LanguageChanged += (sender, e) => UpdateUIText();
            
            // Theme change event
            themeManager.ThemeChanged += (sender, e) => 
            {
                themeManager.ApplyTheme(materialSkinManager);
                Refresh();
            };
        }

        private async Task LoadCoursesAsync()
        {
            try
            {
                _courses = (await _courseService.GetAllCoursesAsync()).ToList();
                cmbCourse.Items.Clear();
                foreach (var course in _courses)
                {
                    cmbCourse.Items.Add(course.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUIText()
        {
            this.Text = "Practice Mode";
            lblTitle.Text = "Practice Mode";
            lblSubtitle.Text = "Select a course to practice questions";
            
            // Update language combo
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_English")} (EN)");
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_Arabic")} (AR)");
            cmbLanguage.SelectedIndex = localizationManager.GetCurrentLanguage() == "ar" ? 1 : 0;
            
            // Update theme button
            btnTheme.Text = themeManager.GetCurrentTheme() == ThemeMode.Light 
                ? localizationManager.GetString("Theme_Dark") 
                : localizationManager.GetString("Theme_Light");
                
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (_isPracticeMode)
            {
                ShowPracticeMode();
            }
            else
            {
                ShowCourseSelection();
            }
        }

        private void ShowCourseSelection()
        {
            // Show course selection controls
            cmbCourse.Visible = true;
            lblCourseDescription.Visible = true;
            btnStartPractice.Visible = true;
            
            // Hide practice mode controls
            lblQuestionTitle.Visible = false;
            lblQuestionText.Visible = false;
            lblQuestionCounter.Visible = false;
            btnPreviousQuestion.Visible = false;
            btnNextQuestion.Visible = false;
            btnCheckAnswer.Visible = false;
            btnExitPractice.Visible = false;
            panelAnswers.Visible = false;
            lblAnswerFeedback.Visible = false;
        }

        private void ShowPracticeMode()
        {
            // Hide course selection controls
            cmbCourse.Visible = false;
            lblCourseDescription.Visible = false;
            btnStartPractice.Visible = false;
            
            // Show practice mode controls
            lblQuestionTitle.Visible = true;
            lblQuestionText.Visible = true;
            lblQuestionCounter.Visible = true;
            btnPreviousQuestion.Visible = true;
            btnNextQuestion.Visible = true;
            btnCheckAnswer.Visible = true;
            btnExitPractice.Visible = true;
            panelAnswers.Visible = true;
            lblAnswerFeedback.Visible = false;
        }

        private async void btnStartPractice_Click(object sender, EventArgs e)
        {
            if (cmbCourse.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a course first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedCourse = _courses[cmbCourse.SelectedIndex];
                
                // Load questions for the selected course
                    _questions = (await _questionService.GetByCourseAsync(selectedCourse.CourseId)).ToList();
                
                if (_questions.Count == 0)
                {
                    MessageBox.Show("No questions available for this course.", "No Questions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Load answers for all questions
                _answers = new List<Answer>();
                foreach (var question in _questions)
                {
                        var questionAnswers = await _answerService.GetByQuestionAsync(question.QuestionId);
                    _answers.AddRange(questionAnswers);
                }

                // Initialize practice mode
                _isPracticeMode = true;
                _currentQuestionIndex = 0;
                _selectedAnswers.Clear();
                
                UpdateDisplay();
                DisplayCurrentQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting practice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCurrentQuestion()
        {
            if (_currentQuestionIndex >= _questions.Count)
                return;

            var question = _questions[_currentQuestionIndex];
            
            lblQuestionTitle.Text = $"Question {_currentQuestionIndex + 1}";
            lblQuestionText.Text = question.Body;
            lblQuestionCounter.Text = $"Question {_currentQuestionIndex + 1} of {_questions.Count}";
            
            // Clear previous answers
            panelAnswers.Controls.Clear();
            answerCheckboxes.Clear();
            
            // Get answers for this question
            var questionAnswers = _answers.Where(a => a.QuestionId == question.QuestionId).ToList();
            
            int yPosition = 10;
            foreach (var answer in questionAnswers)
            {
                var checkbox = new MaterialCheckbox
                {
                    Text = answer.Body,
                    Location = new System.Drawing.Point(10, yPosition),
                    Size = new System.Drawing.Size(400, 30),
                    AutoSize = true
                };
                
                // Check if this answer was previously selected
                if (_selectedAnswers.ContainsKey(question.QuestionId) && 
                    _selectedAnswers[question.QuestionId].Contains(answer.AnswerId))
                {
                    checkbox.Checked = true;
                }
                
                panelAnswers.Controls.Add(checkbox);
                answerCheckboxes.Add(checkbox);
                yPosition += 40;
            }
            
            // Update navigation buttons
            btnPreviousQuestion.Enabled = _currentQuestionIndex > 0;
            btnNextQuestion.Enabled = _currentQuestionIndex < _questions.Count - 1;
            
            // Hide answer feedback
            lblAnswerFeedback.Visible = false;
        }

        private void SaveCurrentAnswers()
        {
            if (_currentQuestionIndex >= _questions.Count)
                return;

            var question = _questions[_currentQuestionIndex];
            var selectedAnswerIds = new List<int>();
            
            for (int i = 0; i < answerCheckboxes.Count; i++)
            {
                if (answerCheckboxes[i].Checked)
                {
                    var questionAnswers = _answers.Where(a => a.QuestionId == question.QuestionId).ToList();
                    if (i < questionAnswers.Count)
                    {
                        selectedAnswerIds.Add(questionAnswers[i].AnswerId);
                    }
                }
            }
            
            _selectedAnswers[question.QuestionId] = selectedAnswerIds;
        }

        private void btnPreviousQuestion_Click(object sender, EventArgs e)
        {
            if (_currentQuestionIndex > 0)
            {
                SaveCurrentAnswers();
                _currentQuestionIndex--;
                DisplayCurrentQuestion();
            }
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            if (_currentQuestionIndex < _questions.Count - 1)
            {
                SaveCurrentAnswers();
                _currentQuestionIndex++;
                DisplayCurrentQuestion();
            }
        }

        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswers();
            
            var question = _questions[_currentQuestionIndex];
            var questionAnswers = _answers.Where(a => a.QuestionId == question.QuestionId).ToList();
            var selectedAnswerIds = _selectedAnswers.ContainsKey(question.QuestionId) 
                ? _selectedAnswers[question.QuestionId] 
                : new List<int>();
            
            // Check if answer is correct
            bool isCorrect = true;
            var correctAnswers = questionAnswers.Where(a => a.IsCorrect).ToList();
            var selectedAnswers = questionAnswers.Where(a => selectedAnswerIds.Contains(a.AnswerId)).ToList();
            
            // For TrueFalse and ChooseOne questions
            if (question.QuestionTypeEnum == QuestionTypeEnum.TrueFalse || question.QuestionTypeEnum == QuestionTypeEnum.ChooseOne)
            {
                isCorrect = selectedAnswers.Count == 1 && selectedAnswers[0].IsCorrect;
            }
            // For ChooseAll questions
            else if (question.QuestionTypeEnum == QuestionTypeEnum.ChooseAll)
            {
                isCorrect = correctAnswers.Count == selectedAnswers.Count && 
                           selectedAnswers.All(sa => sa.IsCorrect);
            }
            
            // Show feedback
            lblAnswerFeedback.Visible = true;
            if (isCorrect)
            {
                lblAnswerFeedback.Text = "✓ Correct! Well done.";
                lblAnswerFeedback.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblAnswerFeedback.Text = "✗ Incorrect. The correct answer(s) are highlighted below.";
                lblAnswerFeedback.ForeColor = System.Drawing.Color.Red;
                
                // Highlight correct answers
                for (int i = 0; i < answerCheckboxes.Count; i++)
                {
                    if (i < questionAnswers.Count && questionAnswers[i].IsCorrect)
                    {
                        answerCheckboxes[i].BackColor = System.Drawing.Color.LightGreen;
                    }
                }
            }
        }

        private void btnExitPractice_Click(object sender, EventArgs e)
        {
            _isPracticeMode = false;
            _currentQuestionIndex = 0;
            _selectedAnswers.Clear();
            UpdateDisplay();
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourse.SelectedIndex >= 0)
            {
                var selectedCourse = _courses[cmbCourse.SelectedIndex];
                lblCourseDescription.Text = $"Description: {selectedCourse.Description ?? "No description available"}";
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedIndex == 0)
            {
                localizationManager.SetLanguage("en");
            }
            else
            {
                localizationManager.SetLanguage("ar");
            }
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            themeManager.ToggleTheme();
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            var splashPage = new SplashPage();
            splashPage.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnFormClosing(e);
        }

        // Removed Application.Exit() here to avoid re-entrancy/hangs; rely on OnFormClosing confirmation
    }
}
