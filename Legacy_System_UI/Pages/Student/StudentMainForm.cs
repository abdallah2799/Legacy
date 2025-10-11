using Common.Enums;
using Core.Interfaces.Services;
using Core.Models;
using Legacy_System_UI.Infrastructure;
using Legacy_System_UI.Pages.Shared;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentModel = Core.Models.Student;

namespace Legacy_System_UI.Pages.Student
{
    public partial class StudentMainForm : MaterialForm
    {
        private readonly User _loggedInStudent;
        private readonly SessionManager _sessionManager;

        // We no longer need to store the IExamService as a field.

        public StudentMainForm(User student)
        {
            InitializeComponent();
            this.Load += StudentMainForm_Load;

            _loggedInStudent = student;
            _sessionManager = SessionManager.Instance;
        }

        private async void StudentMainForm_Load(object sender, EventArgs e)
        {
            if (_loggedInStudent == null)
            {
                MessageBox.Show("Could not identify the logged in student. Logging out.", "Authentication Error");
                Logout();
                return;
            }

            lblWelcome.Text = $"Welcome, {_loggedInStudent.FullName}!";

            // Setup ListView
            listViewExams.View = View.Details;
            listViewExams.FullRowSelect = true;
            listViewExams.Columns.Clear();
            listViewExams.Columns.Add("Exam Title", 350);
            listViewExams.Columns.Add("Course", 200);
            listViewExams.Columns.Add("Status", 100);
            listViewExams.Columns.Add("Scheduled Date", 150);

            // Disable buttons until loading is complete to prevent race conditions
            btnStartExam.Enabled = false;

            await LoadAvailableExams();

            // Re-enable the button after loading is done
            btnStartExam.Enabled = true;
        }

        private async Task LoadAvailableExams()
        {
            try
            {
                // --- THIS IS THE ROBUST FIX ---
                // Create a temporary, isolated scope for this database operation.
                using (var scope = Program.ServiceProvider.CreateScope())
                {
                    // Get a fresh set of services from this temporary scope.
                    var scopedExamService = scope.ServiceProvider.GetRequiredService<IExamService>();

                    var allExams = await scopedExamService.GetAllExamsAsync();
                    var studentTrackId = ((StudentModel)_loggedInStudent).TrackId;

                    var availableExams = allExams
                        .Where(e => e.TrackCourse?.TrackId == studentTrackId && e.Status == ExamStatusEnum.Queued)
                        .OrderBy(e => e.ScheduledAt)
                        .ToList();

                    listViewExams.Items.Clear();
                    foreach (var exam in availableExams)
                    {
                        var item = new ListViewItem(exam.Title);
                        item.SubItems.Add(exam.TrackCourse?.Course?.Name ?? "N/A");
                        item.SubItems.Add(exam.Status.ToString());
                        item.SubItems.Add(exam.ScheduledAt?.ToString("yyyy-MM-dd") ?? "N/A");
                        item.Tag = exam.ExamId;
                        listViewExams.Items.Add(item);
                    }
                } // The scope and all its services (including the DbContext) are automatically disposed here.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load exams: {ex.Message}", "Service Error");
            }
        }

        private void btnStartExam_Click(object sender, EventArgs e)
        {
            if (listViewExams.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an exam from the list to start.", "No Selection");
                return;
            }
            var selectedExamId = (int)listViewExams.SelectedItems[0].Tag;
            var examForm = new ExamForm(this, selectedExamId, _loggedInStudent.UserId);
            examForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the click event for the logout button.
        /// </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        /// <summary>
        /// Performs the logout operation.
        /// </summary>
        private void Logout()
        {
            _sessionManager.Logout();

            // Find the main startup form to show it again
            var startupForm = System.Windows.Forms.Application.OpenForms.OfType<StartupForm>().FirstOrDefault();
            if (startupForm != null)
            {
                startupForm.Show();
            }
            else
            {
                // As a fallback, create a new one
                new StartupForm().Show();
            }
            this.Close();
        }

        // ------------------------------------

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.Visible == false && e.CloseReason == CloseReason.UserClosing)
            {
                // This form is hidden (e.g., exam is open), so don't exit the app
            }
            else if (System.Windows.Forms.Application.OpenForms.OfType<StartupForm>().Any(f => f.Visible))
            {
                // The startup form is visible, so don't exit the app
            }
            else
            {
                // This is the main form being closed, so exit the entire application.
                System.Windows.Forms.Application.Exit();
            }
            base.OnFormClosing(e);
        }


    }
}