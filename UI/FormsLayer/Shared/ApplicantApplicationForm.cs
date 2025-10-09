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
    public partial class ApplicantApplicationForm : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;

        // Services
        private readonly IApplicantService _applicantService;
        private readonly IBranchService _branchService;
        private readonly ITrackService _trackService;
        private readonly IEmailService _emailService;

        // Form state
        private int _currentStep = 1;
        private List<Branch> _branches = new List<Branch>();
        private List<Track> _tracks = new List<Track>();
        private Applicant _applicant = new Applicant();

        // Step 1 - Personal Information
        private MaterialTextBox txtFullName;
        private MaterialTextBox txtEmail;
        private MaterialTextBox txtPhone;
        private MaterialTextBox txtAge;
        private MaterialComboBox cmbGender;
        private MaterialTextBox txtAddress;

        // Step 2 - Branch Selection
        private MaterialComboBox cmbBranch;
        private MaterialLabel lblBranchDescription;

        // Step 3 - Track Selection
        private MaterialComboBox cmbFirstTrack;
        private MaterialComboBox cmbSecondTrack;
        private MaterialLabel lblFirstTrackDescription;
        private MaterialLabel lblSecondTrackDescription;

        // Step 4 - Review
        private MaterialLabel lblReviewSummary;

        // Navigation
        private MaterialButton btnPrevious;
        private MaterialButton btnNext;
        private MaterialButton btnSubmit;
        private MaterialCheckbox chkTermsAndConditions;

        public ApplicantApplicationForm()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            SetupEventHandlers();

            // Get services from DI
            var serviceProvider = Program.ServiceProvider;
            _applicantService = serviceProvider.GetRequiredService<IApplicantService>();
            _branchService = serviceProvider.GetRequiredService<IBranchService>();
            _trackService = serviceProvider.GetRequiredService<ITrackService>();
            _emailService = serviceProvider.GetRequiredService<IEmailService>();

            LoadDataAsync();
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

        private async Task LoadDataAsync()
        {
            try
            {
                // Load branches
                _branches = (await _branchService.GetAllBranchesAsync()).ToList();
                cmbBranch.Items.Clear();
                foreach (var branch in _branches)
                {
                    cmbBranch.Items.Add(branch.Name);
                }

                // Load tracks
                _tracks = (await _trackService.GetAllTracksAsync()).ToList();

                // Setup gender combo
                cmbGender.Items.Clear();
                cmbGender.Items.Add("Male");
                cmbGender.Items.Add("Female");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUIText()
        {
            this.Text = "Apply for Legacy";
            lblTitle.Text = "Application Form";
            lblSubtitle.Text = "Please fill in your information to apply for Legacy";

            // Update language combo
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_English")} (EN)");
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_Arabic")} (AR)");
            cmbLanguage.SelectedIndex = localizationManager.GetCurrentLanguage() == "ar" ? 1 : 0;

            // Update theme button
            btnTheme.Text = themeManager.GetCurrentTheme() == ThemeMode.Light
                ? localizationManager.GetString("Theme_Dark")
                : localizationManager.GetString("Theme_Light");

            UpdateStepDisplay();
        }

        private void UpdateStepDisplay()
        {
            lblStepTitle.Text = $"Step {_currentStep} of 4";

            switch (_currentStep)
            {
                case 1:
                    lblStepDescription.Text = "Personal Information";
                    ShowStep1();
                    break;
                case 2:
                    lblStepDescription.Text = "Select Branch";
                    ShowStep2();
                    break;
                case 3:
                    lblStepDescription.Text = "Select Preferred Tracks";
                    ShowStep3();
                    break;
                case 4:
                    lblStepDescription.Text = "Review and Submit";
                    ShowStep4();
                    break;
            }

            UpdateNavigationButtons();
        }

        private void ShowStep1()
        {
            // Show personal information controls
            txtFullName.Visible = true;
            txtEmail.Visible = true;
            txtPhone.Visible = true;
            txtAge.Visible = true;
            cmbGender.Visible = true;
            txtAddress.Visible = true;

            // Hide other steps
            cmbBranch.Visible = false;
            lblBranchDescription.Visible = false;
            cmbFirstTrack.Visible = false;
            cmbSecondTrack.Visible = false;
            lblFirstTrackDescription.Visible = false;
            lblSecondTrackDescription.Visible = false;
            lblReviewSummary.Visible = false;
            chkTermsAndConditions.Visible = false;
        }

        private void ShowStep2()
        {
            // Show branch selection controls
            cmbBranch.Visible = true;
            lblBranchDescription.Visible = true;

            // Hide other steps
            txtFullName.Visible = false;
            txtEmail.Visible = false;
            txtPhone.Visible = false;
            txtAge.Visible = false;
            cmbGender.Visible = false;
            txtAddress.Visible = false;
            cmbFirstTrack.Visible = false;
            cmbSecondTrack.Visible = false;
            lblFirstTrackDescription.Visible = false;
            lblSecondTrackDescription.Visible = false;
            lblReviewSummary.Visible = false;
            chkTermsAndConditions.Visible = false;
        }

        private void ShowStep3()
        {
            // Show track selection controls
            cmbFirstTrack.Visible = true;
            cmbSecondTrack.Visible = true;
            lblFirstTrackDescription.Visible = true;
            lblSecondTrackDescription.Visible = true;

            // Hide other steps
            txtFullName.Visible = false;
            txtEmail.Visible = false;
            txtPhone.Visible = false;
            txtAge.Visible = false;
            cmbGender.Visible = false;
            txtAddress.Visible = false;
            cmbBranch.Visible = false;
            lblBranchDescription.Visible = false;
            lblReviewSummary.Visible = false;
            chkTermsAndConditions.Visible = false;

            LoadTracksForBranch();
        }

        private void ShowStep4()
        {
            // Show review controls
            lblReviewSummary.Visible = true;
            chkTermsAndConditions.Visible = true;

            // Hide other steps
            txtFullName.Visible = false;
            txtEmail.Visible = false;
            txtPhone.Visible = false;
            txtAge.Visible = false;
            cmbGender.Visible = false;
            txtAddress.Visible = false;
            cmbBranch.Visible = false;
            lblBranchDescription.Visible = false;
            cmbFirstTrack.Visible = false;
            cmbSecondTrack.Visible = false;
            lblFirstTrackDescription.Visible = false;
            lblSecondTrackDescription.Visible = false;

            UpdateReviewSummary();
        }

        private void LoadTracksForBranch()
        {
            if (cmbBranch.SelectedIndex >= 0)
            {
                var selectedBranch = _branches[cmbBranch.SelectedIndex];
                var branchTracks = _tracks.Where(t =>
                    t.BranchTracks.Any(bt => bt.BranchID == selectedBranch.BranchId)).ToList();

                cmbFirstTrack.Items.Clear();
                cmbSecondTrack.Items.Clear();

                foreach (var track in branchTracks)
                {
                    cmbFirstTrack.Items.Add(track.Name);
                    cmbSecondTrack.Items.Add(track.Name);
                }
            }
        }

        private void UpdateReviewSummary()
        {
            var summary = $"Personal Information:\n" +
                         $"Name: {txtFullName.Text}\n" +
                         $"Email: {txtEmail.Text}\n" +
                         $"Phone: {txtPhone.Text}\n" +
                         $"Age: {txtAge.Text}\n" +
                         $"Gender: {cmbGender.Text}\n" +
                         $"Address: {txtAddress.Text}\n\n" +
                         $"Branch: {cmbBranch.Text}\n" +
                         $"First Preferred Track: {cmbFirstTrack.Text}\n" +
                         $"Second Preferred Track: {cmbSecondTrack.Text}";

            lblReviewSummary.Text = summary;
        }

        private void UpdateNavigationButtons()
        {
            btnPrevious.Visible = _currentStep > 1;
            btnNext.Visible = _currentStep < 4;
            btnSubmit.Visible = _currentStep == 4;

            if (_currentStep == 4)
            {
                btnSubmit.Enabled = chkTermsAndConditions.Checked;
            }
        }

        private bool ValidateCurrentStep()
        {
            switch (_currentStep)
            {
                case 1:
                    return !string.IsNullOrWhiteSpace(txtFullName.Text) &&
                           !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                           !string.IsNullOrWhiteSpace(txtPhone.Text) &&
                           !string.IsNullOrWhiteSpace(txtAge.Text) &&
                           cmbGender.SelectedIndex >= 0 &&
                           !string.IsNullOrWhiteSpace(txtAddress.Text);

                case 2:
                    return cmbBranch.SelectedIndex >= 0;

                case 3:
                    return cmbFirstTrack.SelectedIndex >= 0 &&
                           cmbSecondTrack.SelectedIndex >= 0 &&
                           cmbFirstTrack.SelectedIndex != cmbSecondTrack.SelectedIndex;

                case 4:
                    return chkTermsAndConditions.Checked;

                default:
                    return false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ValidateCurrentStep())
            {
                _currentStep++;
                UpdateStepDisplay();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentStep > 1)
            {
                _currentStep--;
                UpdateStepDisplay();
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Create applicant object
                var applicant = new Applicant
                {
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Age = int.Parse(txtAge.Text),
                    Gender = cmbGender.Text == "Male" ? GenderEnum.Male : GenderEnum.Female,
                    Address = txtAddress.Text.Trim(),
                    SelectedBranches = new List<int> { _branches[cmbBranch.SelectedIndex].BranchId },
                    SelectedTracks = new List<int> {
                        GetTrackIdByName(cmbFirstTrack.Text),
                        GetTrackIdByName(cmbSecondTrack.Text)
                    },
                    ApplicationCode = Guid.NewGuid().ToString("N")[..8].ToUpper(),
                    Status = ApplicationStatus.Pending
                };

                // Submit application
                await _applicantService.SubmitApplicationAsync(applicant);

                // Send confirmation email
                await _emailService.SendEmailAsync(
                    applicant.Email,
                    "Application Received - Legacy Examination System",
                    $"Dear {applicant.FullName},\n\n" +
                    $"Thank you for applying to Legacy Examination System.\n\n" +
                    $"Your application details:\n" +
                    $"Branch: {cmbBranch.Text}\n" +
                    $"Preferred Tracks: {cmbFirstTrack.Text}, {cmbSecondTrack.Text}\n\n" +
                    $"Your application is now under review. You will be notified of the decision via email.\n\n" +
                    $"Best regards,\nLegacy Team"
                );

                MessageBox.Show("Application submitted successfully! Check your email for confirmation.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Return to splash page
                var splashPage = new SplashPage();
                splashPage.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetTrackIdByName(string trackName)
        {
            return _tracks.FirstOrDefault(t => t.Name == trackName)?.TrackId ?? 0;
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBranch.SelectedIndex >= 0)
            {
                var selectedBranch = _branches[cmbBranch.SelectedIndex];
                lblBranchDescription.Text = $"Location: {selectedBranch.Location ?? "No location available"}";
            }
        }

        private void cmbFirstTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFirstTrack.SelectedIndex >= 0)
            {
                var trackName = cmbFirstTrack.Text;
                var track = _tracks.FirstOrDefault(t => t.Name == trackName);
                lblFirstTrackDescription.Text = $"Description: {track?.Description ?? "No description available"}";
            }
        }

        private void cmbSecondTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecondTrack.SelectedIndex >= 0)
            {
                var trackName = cmbSecondTrack.Text;
                var track = _tracks.FirstOrDefault(t => t.Name == trackName);
                lblSecondTrackDescription.Text = $"Description: {track?.Description ?? "No description available"}";
            }
        }

        private void chkTermsAndConditions_CheckedChanged(object sender, EventArgs e)
        {
            UpdateNavigationButtons();
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

        private void ApplicantApplicationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
