using Core.Interfaces.Services;
using Core.Models;
using Legacy_System_UI.Infrastructure;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Common.Enums;

namespace Legacy_System_UI.Pages.Student
{
    public partial class ExamForm : MaterialForm
    {
        private readonly MaterialForm _parentForm;
        private readonly IExamService _examService;

        private readonly int _examId;
        private readonly int _studentId;
        private List<Question> _questions = new List<Question>();
        private int _currentIndex = 0;
        private Dictionary<int, List<int>> _userAnswers = new Dictionary<int, List<int>>();

        public ExamForm(MaterialForm parent, int examId, int studentId)
        {
            InitializeComponent();
            _parentForm = parent;
            _examId = examId;
            _studentId = studentId;

            var serviceProvider = Program.ServiceProvider;
            _examService = serviceProvider.GetRequiredService<IExamService>();
        }

        private async void ExamForm_Load(object sender, EventArgs e)
        {
            try
            {
                var exam = await _examService.GetExamWithQuestionsAsync(_examId);

                if (exam == null || !exam.Questions.Any())
                {
                    MessageBox.Show("Exam not available or has no questions.", "Error");
                    this.Close();
                    return;
                }

                this.Text = exam.Title;
                _questions = exam.Questions
                                 .Select(eq => eq.Question)
                                 .OrderBy(q => q.QuestionId)
                                 .ToList();

                DisplayQuestion(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading exam: {ex.Message}", "Load Error");
            }
        }

        private void DisplayQuestion(int index)
        {
            if (index < 0 || index >= _questions.Count) return;

            _currentIndex = index;
            var question = _questions[index];
            Lbl_Question.Text = $"Question {index + 1}/{_questions.Count}: {question.Body}";

            FlowPanel_Options.Controls.Clear();
            CreateAnswerControls(question);

            UpdateNavigationButtons();
        }

        private void CreateAnswerControls(Question question)
        {
            // --- THIS IS THE FIX ---
            // Use the correct property name 'QuestionTypeEnum' from your model
            bool isSingleChoice = question.QuestionTypeEnum == QuestionTypeEnum.TrueFalse || question.QuestionTypeEnum == QuestionTypeEnum.ChooseOne;

            foreach (var answer in question.Answers)
            {
                Control answerControl;
                if (isSingleChoice)
                {
                    answerControl = new MaterialRadioButton { Text = answer.Body, Tag = answer.AnswerId, AutoSize = true, Width = FlowPanel_Options.Width - 30 };
                    answerControl.Click += AnswerControl_CheckedChanged;
                }
                else // ChooseAll
                {
                    answerControl = new MaterialCheckbox { Text = answer.Body, Tag = answer.AnswerId, AutoSize = true, Width = FlowPanel_Options.Width - 30 };
                    ((MaterialCheckbox)answerControl).CheckedChanged += AnswerControl_CheckedChanged;
                }
                FlowPanel_Options.Controls.Add(answerControl);
            }
            RestoreSelectedAnswers(question.QuestionId);
        }

        private void RestoreSelectedAnswers(int questionId)
        {
            if (!_userAnswers.TryGetValue(questionId, out var selectedIds)) return;

            foreach (Control control in FlowPanel_Options.Controls)
            {
                if (control is MaterialRadioButton rb) rb.Checked = selectedIds.Contains((int)rb.Tag);
                else if (control is MaterialCheckbox cb) cb.Checked = selectedIds.Contains((int)cb.Tag);
            }
        }

        private void AnswerControl_CheckedChanged(object sender, EventArgs e)
        {
            int questionId = _questions[_currentIndex].QuestionId;

            if (sender is MaterialRadioButton rb && rb.Checked)
            {
                _userAnswers[questionId] = new List<int> { (int)rb.Tag };
            }
            else if (sender is MaterialCheckbox cb)
            {
                if (!_userAnswers.ContainsKey(questionId)) _userAnswers[questionId] = new List<int>();
                int answerId = (int)cb.Tag;
                if (cb.Checked)
                {
                    if (!_userAnswers[questionId].Contains(answerId)) _userAnswers[questionId].Add(answerId);
                }
                else
                {
                    _userAnswers[questionId].Remove(answerId);
                }
            }
        }

        private void Btn_Next_Click(object sender, EventArgs e)
        {
            if (_currentIndex < _questions.Count - 1) DisplayQuestion(_currentIndex + 1);
        }

        private void Btn_Previous_Click(object sender, EventArgs e)
        {
            if (_currentIndex > 0) DisplayQuestion(_currentIndex - 1);
        }

        private async void Btn_Submit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to submit your final answers?", "Submit Exam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            try
            {
                // 1. Update UI to show it's working and prevent other actions
                Btn_Submit.Enabled = false;
                Btn_Previous.Enabled = false;
                Btn_Next.Enabled = false;
                FlowPanel_Options.Enabled = false;
                Btn_Submit.Text = "Submitting...";

                // 2. Call the service to submit the exam
                int finalScore = await _examService.SubmitExamAsync(_studentId, _examId, _userAnswers);

                // 3. Show the final score to the user in a message box.
                //    This pauses the code until the user clicks "OK".
                MessageBox.Show($"Submission Complete! Your Final Score is: {finalScore}", "Exam Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- THIS IS THE FIX ---
                // 4. After the user clicks "OK", navigate back to the parent form.
                _parentForm?.Show();
                this.Close();
                // -----------------------
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Submission failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Re-enable controls if submission fails so the user can try again
                Btn_Submit.Enabled = true;
                Btn_Submit.Text = "Submit";
                UpdateNavigationButtons(); // Re-enables Previous/Next if appropriate
                FlowPanel_Options.Enabled = true;
            }
        }

        private void UpdateNavigationButtons()
        {
            Btn_Previous.Enabled = (_currentIndex > 0);
            Btn_Next.Enabled = (_currentIndex < _questions.Count - 1);
            Btn_Submit.Visible = (_currentIndex == _questions.Count - 1);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _parentForm?.Show();
            base.OnFormClosing(e);
        }
        private void GoBackHomeBtn_Click(object sender, EventArgs e)
        {
            // Ask the user for confirmation before abandoning the exam
            var result = MessageBox.Show(
                "Are you sure you want to go back? All your progress in this exam will be lost.",
                "Confirm Abandon Exam",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // Only proceed if the user confirms
            if (result == DialogResult.Yes)
            {
                // Show the parent form (the Student Dashboard)
                _parentForm?.Show();

                // Close the current exam form
                this.Close();
            }
        }
    }
}