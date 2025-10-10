using Application.Services;
using Common.Enums;
using Common.Helpers;
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
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legacy_System_UI.Pages.Shared
{
    public partial class ApplianceMainForm : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;
        private MaterialForm parentForm;

        // Services 
        private readonly IBranchService _branchService;
        private readonly ITrackService _trackService;
        private readonly IEmailService _emailService;
        private readonly IApplicantService _applicantService;

        private IEnumerable<Branch> allBranches = new List<Branch>();

        public ApplianceMainForm()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            SetupEventHandlers();

            // Get services from DI
            var serviceProvider = Program.ServiceProvider;
            _branchService = serviceProvider.GetRequiredService<IBranchService>();
            _trackService = serviceProvider.GetRequiredService<ITrackService>();
            _emailService = serviceProvider.GetRequiredService<IEmailService>();
            _applicantService = serviceProvider.GetRequiredService<IApplicantService>();
        }

        public ApplianceMainForm(MaterialForm sender) : this()
        {
            parentForm = sender;
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
            this.Text = localizationManager.GetString("Application_Form");

            Lb_JoinUs.Text = localizationManager.GetString("Join_Us");

            if (localizationManager.GetCurrentLanguage() == "ar")
                Lb_JoinUs.Location = new Point(Tb_Phone.Location.X + (Tb_Phone.Width - Lb_JoinUs.Width), Lb_JoinUs.Location.Y);
            else
                Lb_JoinUs.Location = new Point(Tb_Name.Location.X, Lb_JoinUs.Location.Y);

            Lb_FullName.Text = localizationManager.GetString("Full_Name");
            if (localizationManager.GetCurrentLanguage() == "ar")
                Lb_FullName.Location = new Point(Tb_Name.Location.X + (Tb_Name.Width - Lb_FullName.Width), Lb_FullName.Location.Y);
            else
                Lb_FullName.Location = new Point(Tb_Name.Location.X, Lb_FullName.Location.Y);

            Lb_Email.Text = localizationManager.GetString("Email");
            if (localizationManager.GetCurrentLanguage() == "ar")
                Lb_Email.Location = new Point(Tb_Email.Location.X + (Tb_Email.Width - Lb_Email.Width), Lb_Email.Location.Y);
            else
                Lb_Email.Location = new Point(Tb_Email.Location.X, Lb_Email.Location.Y);

            Lb_Age.Text = localizationManager.GetString("Age");
            if (localizationManager.GetCurrentLanguage() == "ar")
                Lb_Age.Location = new Point(Tb_Age.Location.X + (Tb_Age.Width - Lb_Age.Width), Lb_Age.Location.Y);
            else
                Lb_Age.Location = new Point(Tb_Age.Location.X, Lb_Age.Location.Y);

            Lb_Address.Text = localizationManager.GetString("Address");
            if (localizationManager.GetCurrentLanguage() == "ar")
                Lb_Address.Location = new Point(Tb_Address.Location.X + (Tb_Address.Width - Lb_Address.Width), Lb_Address.Location.Y);
            else
                Lb_Address.Location = new Point(Tb_Address.Location.X, Lb_Address.Location.Y);

            Lb_Gender.Text = localizationManager.GetString("Gender");
            if (localizationManager.GetCurrentLanguage() == "ar")
                Lb_Gender.Location = new Point(Cmb_Gender.Location.X + (Cmb_Gender.Width - Lb_Gender.Width), Lb_Gender.Location.Y);
            else
                Lb_Gender.Location = new Point(Cmb_Gender.Location.X, Lb_Gender.Location.Y);

            Lb_Phone.Text = localizationManager.GetString("Phone");
            if (localizationManager.GetCurrentLanguage() == "ar")
                Lb_Phone.Location = new Point(Tb_Phone.Location.X + (Tb_Phone.Width - Lb_Phone.Width), Lb_Phone.Location.Y);
            else
                Lb_Phone.Location = new Point(Tb_Phone.Location.X, Lb_Phone.Location.Y);

            Lb_Branch.Text = localizationManager.GetString("Branch");
            if (localizationManager.GetCurrentLanguage() == "ar")
                Lb_Branch.Location = new Point(Cmb_Branch.Location.X + (Cmb_Branch.Width - Lb_Branch.Width), Lb_Branch.Location.Y);
            else
                Lb_Branch.Location = new Point(Cmb_Branch.Location.X, Lb_Branch.Location.Y);

            Lb_PrimaryTrack.Text = localizationManager.GetString("Primary_Track");
            if (localizationManager.GetCurrentLanguage() == "ar")
                Lb_PrimaryTrack.Location = new Point(Cmb_PrimaryTrack.Location.X + (Cmb_PrimaryTrack.Width - Lb_PrimaryTrack.Width), Lb_PrimaryTrack.Location.Y);
            else
                Lb_PrimaryTrack.Location = new Point(Cmb_PrimaryTrack.Location.X, Lb_PrimaryTrack.Location.Y);

            Lb_SecondaryTrack.Text = localizationManager.GetString("Secondary_Track");
            if (localizationManager.GetCurrentLanguage() == "ar")
                Lb_SecondaryTrack.Location = new Point(Cmb_SecondaryTrack.Location.X + (Cmb_SecondaryTrack.Width - Lb_SecondaryTrack.Width), Lb_SecondaryTrack.Location.Y);
            else
                Lb_SecondaryTrack.Location = new Point(Cmb_SecondaryTrack.Location.X, Lb_SecondaryTrack.Location.Y);








            // Update buttons
            GoBackHomeBtn.Text = localizationManager.GetString("GoBack");
            Btn_Apply.Text = localizationManager.GetString("Confirm_Application");


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

        private async void Btn_Apply_Click(object sender, EventArgs e)
        {
            // Validate all fields are filled
            string validationErrors = ValidateInputs();
            if (!string.IsNullOrEmpty(validationErrors))
            {
                MessageBox.Show(validationErrors, "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // All validations passed, proceed with application submission
                
                var applicant = new Applicant
                {
                    FullName = Tb_Name.Text,
                    Email = Tb_Email.Text,
                    Age = int.Parse(Tb_Age.Text),
                    Address = Tb_Address.Text,
                    Phone = Tb_Phone.Text,
                    Gender = Cmb_Gender.Text == "Male" ? GenderEnum.Male : GenderEnum.Female,
                    SelectedBranches = new List<int> { (Cmb_Branch.SelectedItem as Branch).BranchId },
                    SelectedTracks = Cmb_SecondaryTrack.SelectedIndex != -1 ? new List<int> { (Cmb_PrimaryTrack.SelectedItem as Track).TrackId, (Cmb_SecondaryTrack.SelectedItem as Track).TrackId } : new List<int> { (Cmb_PrimaryTrack.SelectedItem as Track).TrackId },
                    ApplicationCode = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                    ApplicationPasswordHash = PasswordHelper.HashPassword("Default@123"), // In real app, generate or get from user
                    CreatedAt = DateTime.Now,
                    Status = ApplicationStatus.Pending,
                    UpdatedAt = DateTime.Now
                };

                try
                {
                    // Simulate saving to database
                    // In real app, call a service to save the applicant
                    // e.g., await _applicantService.AddApplicantAsync(applicant);
                    // For demo, just show the application code

                    await _emailService.SendEmailAsync(
                            applicant.Email,
                                    "Application Received - Legacy Examination System",
                                    $"Dear {applicant.FullName},\n\n" +
                                    $"Thank you for applying to Legacy Examination System.\n\n" +
                                    $"Your application details:\n" +
                                    $"Branch: {Cmb_Branch.Text}\n" +
                                    $"Preferred Tracks: {Cmb_PrimaryTrack.Text}, {Cmb_SecondaryTrack.Text}\n\n" +
                                    $"Your Application Code: {applicant.ApplicationCode}\n" +
                                    $"Your application is now under review. You will be notified of the decision via email.\n\n" +
                                    $"Best regards,\nLegacy Team"
                                    );
                    await _applicantService.SubmitApplicationAsync(applicant);
                    MessageBox.Show($"Application submitted successfully!\nYour application code is: {applicant.ApplicationCode}", "Application Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Clear form for next application
                    resetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error submitting application: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Enabled = true;
                    // Hide loading indicator if any
                }
            }
        }

        private void AllowNumbersOnly(object sender, KeyEventArgs e)
        {
            // Allow control keys (Backspace, Delete, etc.)
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Shift)
            {
                // Allow top-row number keys (without Shift, to avoid symbols)
                return;
            }

            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                // Allow numpad number keys
                return;
            }

            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Tab)
            {
                // Allow useful control keys
                return;
            }

            // Block everything else
            e.SuppressKeyPress = true;
        }

        private void SetRange(object sender, EventArgs e)
        {
            // Ensure age is within 18-60
            if (int.TryParse(Tb_Age.Text, out int age))
            {
                if (age < 18)
                {
                    var result = MessageBox.Show("Age must be between 18 and 31 !", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Tb_Age.Text = "";
                    Tb_Age.Focus();
                }
                else if (age > 31)
                {
                    var result = MessageBox.Show("Age must be between 18 and 31 !", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Tb_Age.Text = "";
                    Tb_Age.Focus();
                }
            }
            else
            {
                Tb_Age.Text = ""; // Default to minimum if parsing fails
            }
        }

        private async void ApplianceMainForm_Load(object sender, EventArgs e)
        {

            try
            {
                allBranches = await _branchService.GetBranchesWithTracksAsync();
                Cmb_Branch.DataSource = allBranches.ToList();
                Cmb_Branch.DisplayMember = "Name";
                Cmb_Branch.ValueMember = "BranchId";

                var tracks = await _trackService.GetAllTracksAsync();

                Cmb_PrimaryTrack.DataSource = tracks.ToList();
                Cmb_PrimaryTrack.DisplayMember = "Name";
                Cmb_PrimaryTrack.ValueMember = "TrackId";
                Cmb_SecondaryTrack.DataSource = tracks.ToList();
                Cmb_SecondaryTrack.DisplayMember = "Name";
                Cmb_SecondaryTrack.ValueMember = "TrackId";

                Cmb_Branch.SelectedIndex =
                Cmb_PrimaryTrack.SelectedIndex =
                Cmb_SecondaryTrack.SelectedIndex =
                Cmb_Gender.SelectedIndex = -1;


                Cmb_Gender.Items.Clear();
                Cmb_Gender.Items.Add(GenderEnum.Male.ToString());
                Cmb_Gender.Items.Add(GenderEnum.Female.ToString());


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Enabled = true;
                // Hide loading indicator if any
            }
        }

        private void EnsureUniqe(object sender, EventArgs e)
        {
            // Make sure Cmb_PrimaryTrack Not The Same As Cmb_SecondaryTrack
            if (Cmb_PrimaryTrack.SelectedIndex == -1 && Cmb_SecondaryTrack.SelectedIndex == -1)
                return;
            if (Cmb_PrimaryTrack.Text == Cmb_SecondaryTrack.Text)
            {

                var result = MessageBox.Show("Primary Track and Secondary Track cannot be the same!", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cmb_SecondaryTrack.SelectedIndex = -1;
                Cmb_SecondaryTrack.Focus();
            }
            if (Cmb_PrimaryTrack.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your Primary Track", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cmb_PrimaryTrack.Focus();
                return;
            }
        }

        private static bool IsValid(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }

        private string ValidateInputs()
        {
            string errorMessage = "";

            // Define regex patterns
            string namePattern = @"^[A-Za-z]{2,}(?:\s[A-Za-z]{2,}){2}$";
            string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            string agePattern = @"^(?:1[01][0-9]|31|[1-9][0-9]?)$";
            string addressPattern = @"^[A-Za-z0-9\s,.\-]{5,100}$";
            string phonePattern = @"^01[0-2,5]{1}[0-9]{8}$"; // Egyptian format

            // Local validator
            bool IsValid(string input, string pattern) => Regex.IsMatch(input, pattern);

            // Required field validation
            if (string.IsNullOrWhiteSpace(Tb_Name.Text))
                errorMessage += "- Full Name is required.\n";
            if (string.IsNullOrWhiteSpace(Tb_Email.Text))
                errorMessage += "- Email is required.\n";
            if (string.IsNullOrWhiteSpace(Tb_Age.Text))
                errorMessage += "- Age is required.\n";
            if (string.IsNullOrWhiteSpace(Tb_Address.Text))
                errorMessage += "- Address is required.\n";
            if (string.IsNullOrWhiteSpace(Tb_Phone.Text))
                errorMessage += "- Phone is required.\n";
            if (Cmb_Gender.SelectedIndex == -1)
                errorMessage += "- Please select your Gender.\n";
            if (Cmb_Branch.SelectedIndex == -1)
                errorMessage += "- Please select a Branch.\n";
            if (Cmb_PrimaryTrack.SelectedIndex == -1)
                errorMessage += "- Please select a Primary Track.\n";

            // Length checks
            if (Tb_Name.Text.Length > Common.Constants.Validation.MAX_FULLNAME_LENGTH)
                errorMessage += $"- Full Name cannot exceed {Common.Constants.Validation.MAX_FULLNAME_LENGTH} characters.\n";
            if (Tb_Email.Text.Length > Common.Constants.Validation.MAX_EMAIL_LENGTH)
                errorMessage += $"- Email cannot exceed {Common.Constants.Validation.MAX_EMAIL_LENGTH} characters.\n";
            if (Tb_Phone.Text.Length > Common.Constants.Validation.MAX_PHONE_LENGTH)
                errorMessage += $"- Phone cannot exceed {Common.Constants.Validation.MAX_PHONE_LENGTH} characters.\n";
            if (Tb_Address.Text.Length > Common.Constants.Validation.MAX_ADDRESS_LENGTH)
                errorMessage += $"- Address cannot exceed {Common.Constants.Validation.MAX_ADDRESS_LENGTH} characters.\n";

            // Pattern-based validation
            if (!string.IsNullOrWhiteSpace(Tb_Name.Text) && !IsValid(Tb_Name.Text, namePattern))
                errorMessage += "- Full Name must be at least first, middle, last naem and doesn't contain invalid characters.\n";
            if (!string.IsNullOrWhiteSpace(Tb_Email.Text) && !IsValid(Tb_Email.Text, emailPattern))
                errorMessage += "- Invalid Email format.\n";
            if (!string.IsNullOrWhiteSpace(Tb_Age.Text) && !IsValid(Tb_Age.Text, agePattern))
                errorMessage += "- Age must be a number between 1 and 31.\n";
            if (!string.IsNullOrWhiteSpace(Tb_Address.Text) && !IsValid(Tb_Address.Text, addressPattern))
                errorMessage += "- Address contains invalid characters.\n";
            if (!string.IsNullOrWhiteSpace(Tb_Phone.Text) && !IsValid(Tb_Phone.Text, phonePattern))
                errorMessage += "- Invalid Egyptian phone number format.\n";

            // Logical checks
            if (int.TryParse(Tb_Age.Text, out int age))
            {
                if (age < Common.Constants.Validation.MIN_AGE || age > Common.Constants.Validation.MAX_AGE)
                    errorMessage += $"- Age must be between {Common.Constants.Validation.MIN_AGE} and {Common.Constants.Validation.MAX_AGE}.\n";
            }
            else if (!string.IsNullOrWhiteSpace(Tb_Age.Text))
            {
                errorMessage += "- Age must be a valid number.\n";
            }

            if (Cmb_PrimaryTrack.SelectedIndex != -1 && Cmb_SecondaryTrack.SelectedIndex != -1)
            {
                if (Cmb_PrimaryTrack.Text == Cmb_SecondaryTrack.Text)
                    errorMessage += "- Primary Track and Secondary Track cannot be the same.\n";
            }

            if (!string.IsNullOrEmpty(errorMessage))
                errorMessage = "Please fix the following errors:\n" + errorMessage;

            return errorMessage;
        }

        private void UpdateBranchTrack(object sender, EventArgs e)
        {
            var selectedBranch = Cmb_Branch.SelectedItem as Branch;
            if (selectedBranch == null)
                return;

            try
            {
                //var allBranches = await _branchService.GetBranchesWithTracksAsync();

                var branchTracks = allBranches.FirstOrDefault(b => b.BranchId == selectedBranch.BranchId)?.BranchTracks.ToList();

                if (branchTracks == null || branchTracks.Count == 0)
                    return;

                var tracks = new List<Track>();

                foreach (var bt in branchTracks)
                {
                    tracks.Add(bt.Track);
                }

                Cmb_PrimaryTrack.DataSource = tracks.ToList();
                Cmb_SecondaryTrack.DataSource = tracks.ToList();

                Cmb_PrimaryTrack.DisplayMember = "Name";
                Cmb_PrimaryTrack.ValueMember = "TrackId";

                Cmb_SecondaryTrack.DisplayMember = "Name";
                Cmb_SecondaryTrack.ValueMember = "TrackId";

                Cmb_PrimaryTrack.SelectedIndex = -1;
                Cmb_SecondaryTrack.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tracks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                this.Enabled = true;
                // Hide loading indicator if any
            }
        }

        private void resetForm()
        {
            Tb_Name.Text = "";
            Tb_Email.Text = "";
            Tb_Age.Text = "";
            Tb_Address.Text = "";
            Tb_Phone.Text = "";
            Cmb_Gender.SelectedIndex = -1;
            Cmb_Branch.SelectedIndex = -1;
            Cmb_PrimaryTrack.SelectedIndex = -1;
            Cmb_SecondaryTrack.SelectedIndex = -1;
        }
    }
}
