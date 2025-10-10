using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
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

namespace Legacy_System_UI.Pages.Guest
{
    public partial class QuestionBankForm : MaterialForm
    {
        private readonly MaterialForm parentForm;
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;
        private IEnumerable<Question> _questions;
        private IEnumerable<Course> _allCourses;
        private int _currentQuestionIndex = 0;
        private readonly ICourseService _courseService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        public QuestionBankForm()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            SetupEventHandlers();

            _courseService = Program.ServiceProvider.GetRequiredService<ICourseService>();
            _questionService = Program.ServiceProvider.GetRequiredService<IQuestionService>();
            _answerService = Program.ServiceProvider.GetRequiredService<IAnswerService>();
        }

        public QuestionBankForm(MaterialForm _parentForm) : this()
        {
            parentForm = _parentForm;
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
        private void UpdateUIText()
        {
            // Update form Labels


            // Update Buttons
            GoBackHomeBtn.Text = localizationManager.GetString("GoBack");


            // Update language combo
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_English")} (EN)");
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_Arabic")} (AR)");
            cmbLanguage.SelectedIndex = localizationManager.GetCurrentLanguage() == "ar" ? 1 : 0;

            // Update theme button
            ThemeSwitchBtn.Text = themeManager.GetCurrentTheme() == ThemeMode.Light
                ? localizationManager.GetString("Theme_Light")
                : localizationManager.GetString("Theme_Dark");
        }

        private void ToggleTheme(object sender, EventArgs e)
        {
            themeManager.ToggleTheme();
            if (localizationManager.GetCurrentLanguage() == "ar")
            {
                ThemeSwitchBtn.Text = themeManager.IsDarkMode
                    ? localizationManager.GetString("Theme_Dark")
                    : localizationManager.GetString("Theme_Light");
            }
            else
            {
                ThemeSwitchBtn.Text = themeManager.IsDarkMode ? "Dark Mode" : "Light Mode";
            }

        }

        private void ChangeLanguage(object sender, EventArgs e)
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


        private async void GoBackHomeBtn_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            parentForm.Close();
            e.Cancel = true;
        }

        private async void QuestionBankForm_Load(object sender, EventArgs e)
        {
            _allCourses = await _courseService.GetAllCoursesAsync();

            Cmb_Course.DataSource = _allCourses.ToList();
            Cmb_Course.DisplayMember = "Name";
            Cmb_Course.ValueMember = "CourseId";
            Cmb_Course.SelectedIndex = -1;
        }



        private async void Cmb_Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Course.SelectedItem is Course selectedCourse)
            {
                await LoadQuestionsForCourse(selectedCourse.CourseId);
                _currentQuestionIndex = 0;
                ShowQuestion(_currentQuestionIndex);
            }
        }

        private async Task LoadQuestionsForCourse(int courseId)
        {
            _questions = await _questionService.GetByCourseAsync(courseId);
        }

        private void ShowQuestion(int index)
        {
            if (_questions == null || !_questions.Any()) return;
            var questions = _questions.ToList();
            var question = questions[index];
            Lbl_Question.Text = $"{index + 1}. {question.Body}";
            FlowPanel_Options.Controls.Clear();

            foreach (var option in question.Answers)
            {
                var radio = new RadioButton
                {
                    Text = option.Body,
                    Tag = option.IsCorrect,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10)
                };
                FlowPanel_Options.Controls.Add(radio);
            }
            Lbl_Result.Text = "";
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            var selectedOption = FlowPanel_Options.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedOption == null)
            {
                MessageBox.Show("Please select an answer first!");
                return;
            }

            bool isCorrect = (bool)selectedOption.Tag;
            if (isCorrect)
            {
                Lbl_Result.ForeColor = Color.Green;
                Lbl_Result.Text = "✅ Correct!";
            }
            else
            {
                Lbl_Result.ForeColor = Color.Red;
                var correct = FlowPanel_Options.Controls.OfType<RadioButton>().FirstOrDefault(r => (bool)r.Tag);
                Lbl_Result.Text = $"❌ Wrong. Correct answer: {correct?.Text}";
            }
        }

        private void Btn_Next_Click(object sender, EventArgs e)
        {
            if (_questions == null || !_questions.Any()) return;
            var questions = _questions.ToList();
            if (_currentQuestionIndex < questions.Count - 1)
            {
                _currentQuestionIndex++;
                ShowQuestion(_currentQuestionIndex);
            }
            else
            {
                MessageBox.Show("🎉 No more questions in this course!");
            }
        }

        private void Btn_Previous_Click(object sender, EventArgs e)
        {
            if (_questions == null || !_questions.Any()) return;
            var questions = _questions.ToList();
            if (_currentQuestionIndex > 0)
            {
                _currentQuestionIndex--;
                ShowQuestion(_currentQuestionIndex);
            }
            else
            {
                MessageBox.Show("No Previous Questions..!");
            }
        }
    }
}
