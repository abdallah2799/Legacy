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
using UI.FormsLayer.Shared;

namespace UI.FormsLayer.Admin
{
    public partial class AdminApplicantFinalizationForm : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;
        private SessionManager sessionManager;
        
        // Services
        private readonly IApplicantService _applicantService;
        private readonly IUserService _userService;
        private readonly IBranchService _branchService;
        private readonly ITrackService _trackService;
        private readonly IEmailService _emailService;
        
        // Form state
        private List<Applicant> _approvedApplicants = new List<Applicant>();
        private List<Branch> _branches = new List<Branch>();
        private List<Track> _tracks = new List<Track>();
        
        // Controls (declared here for access across methods)
        private MaterialLabel lblTitle;
        private MaterialLabel lblSubtitle;
        private MaterialComboBox cmbLanguage;
        private MaterialButton btnTheme;
        private MaterialButton btnBackToDashboard;
        private MaterialButton btnRefresh;
        private Panel panelMain;
        private Panel panelTop;
        private Panel panelContent;
        private FlowLayoutPanel panelApplicants;
        private MaterialLabel lblNoApplicants;

        public AdminApplicantFinalizationForm()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            SetupEventHandlers();
            
            // Get services from DI
            var serviceProvider = Program.ServiceProvider;
            _applicantService = serviceProvider.GetRequiredService<IApplicantService>();
            _userService = serviceProvider.GetRequiredService<IUserService>();
            _branchService = serviceProvider.GetRequiredService<IBranchService>();
            _trackService = serviceProvider.GetRequiredService<ITrackService>();
            _emailService = serviceProvider.GetRequiredService<IEmailService>();
            
            LoadDataAsync();
        }

        private void InitializeMaterialSkin()
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            // Theme and ColorScheme are set in Program.cs globally
            
            localizationManager = LocalizationManager.Instance;
            themeManager = ThemeManager.Instance;
            sessionManager = SessionManager.Instance;
            
            themeManager.ApplyTheme(materialSkinManager);
            UpdateUIText();
        }

        private void SetupEventHandlers()
        {
            localizationManager.LanguageChanged += (sender, e) => UpdateUIText();
            themeManager.ThemeChanged += (sender, e) => 
            {
                themeManager.ApplyTheme(materialSkinManager);
                Refresh();
            };

            btnRefresh.Click += btnRefresh_Click;
            btnBackToDashboard.Click += btnBackToDashboard_Click;
            btnTheme.Click += btnTheme_Click;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
        }

        private async Task LoadDataAsync()
        {
            try
            {
                // Load applicants approved by branch managers
                var allApplicants = await _applicantService.GetPendingApplicationsAsync();
                _approvedApplicants = allApplicants.Where(a => 
                    a.Status == ApplicationStatus.UnderReview && 
                    a.AcceptedTrackId.HasValue && 
                    a.AcceptedBranchId.HasValue).ToList();
                
                // Load branches and tracks for display
                _branches = (await _branchService.GetAllBranchesAsync()).ToList();
                _tracks = (await _trackService.GetAllTracksAsync()).ToList();
                
                DisplayApplicants();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayApplicants()
        {
            panelApplicants.Controls.Clear();
            
            if (_approvedApplicants.Count == 0)
            {
                lblNoApplicants.Visible = true;
                return;
            }
            
            lblNoApplicants.Visible = false;
            
            foreach (var applicant in _approvedApplicants)
            {
                var applicantCard = CreateApplicantCard(applicant);
                panelApplicants.Controls.Add(applicantCard);
            }
        }

        private MaterialCard CreateApplicantCard(Applicant applicant)
        {
            var card = new MaterialCard
            {
                Size = new System.Drawing.Size(450, 350),
                Margin = new Padding(10),
                Padding = new Padding(15)
            };
            
            // Applicant info panel
            var infoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 250
            };
            
            var lblName = new MaterialLabel
            {
                Text = $"Name: {applicant.FullName}",
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(400, 20),
                FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1
            };
            
            var lblEmail = new MaterialLabel
            {
                Text = $"Email: {applicant.Email}",
                Location = new System.Drawing.Point(10, 40),
                Size = new System.Drawing.Size(400, 20)
            };
            
            var lblPhone = new MaterialLabel
            {
                Text = $"Phone: {applicant.Phone}",
                Location = new System.Drawing.Point(10, 70),
                Size = new System.Drawing.Size(400, 20)
            };
            
            var lblAge = new MaterialLabel
            {
                Text = $"Age: {applicant.Age}",
                Location = new System.Drawing.Point(10, 100),
                Size = new System.Drawing.Size(400, 20)
            };
            
            var lblGender = new MaterialLabel
            {
                Text = $"Gender: {applicant.GenderDisplay}",
                Location = new System.Drawing.Point(10, 130),
                Size = new System.Drawing.Size(400, 20)
            };
            
            var lblApplicationDate = new MaterialLabel
            {
                Text = $"Applied: {applicant.CreatedAt?.ToString("MMM dd, yyyy") ?? "N/A"}",
                Location = new System.Drawing.Point(10, 160),
                Size = new System.Drawing.Size(400, 20)
            };
            
            // Branch and Track info
            var branch = _branches.FirstOrDefault(b => b.BranchId == applicant.AcceptedBranchId);
            var track = _tracks.FirstOrDefault(t => t.TrackId == applicant.AcceptedTrackId);
            
            var lblBranch = new MaterialLabel
            {
                Text = $"Branch: {branch?.Name ?? "Unknown"}",
                Location = new System.Drawing.Point(10, 190),
                Size = new System.Drawing.Size(400, 20),
                FontType = MaterialSkin.MaterialSkinManager.fontType.Body2
            };
            
            var lblTrack = new MaterialLabel
            {
                Text = $"Track: {track?.Name ?? "Unknown"}",
                Location = new System.Drawing.Point(10, 220),
                Size = new System.Drawing.Size(400, 20),
                FontType = MaterialSkin.MaterialSkinManager.fontType.Body2
            };
            
            infoPanel.Controls.AddRange(new Control[] { 
                lblName, lblEmail, lblPhone, lblAge, lblGender, 
                lblApplicationDate, lblBranch, lblTrack 
            });
            
            // Action buttons panel
            var buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50
            };
            
            var btnFinalize = new MaterialButton
            {
                Text = "Finalize Applicant",
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(150, 30),
                Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained,
                UseAccentColor = true
            };
            btnFinalize.Click += (s, e) => FinalizeApplicant(applicant);
            
            var btnViewDetails = new MaterialButton
            {
                Text = "View Details",
                Location = new System.Drawing.Point(180, 10),
                Size = new System.Drawing.Size(120, 30),
                Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined
            };
            btnViewDetails.Click += (s, e) => ViewApplicantDetails(applicant);
            
            buttonPanel.Controls.AddRange(new Control[] { btnFinalize, btnViewDetails });
            
            card.Controls.Add(infoPanel);
            card.Controls.Add(buttonPanel);
            
            return card;
        }

        private async void FinalizeApplicant(Applicant applicant)
        {
            try
            {
                // Show finalization dialog
                var result = ShowFinalizationDialog(applicant);
                if (result == null)
                    return;
                
                // Validate username uniqueness (simplified for now - in real app, you'd check against database)
                // For now, we'll assume the generated username is unique
                
                // Confirm finalization
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to finalize {applicant.FullName} as a student?\n\n" +
                    $"Username: {result.Username}\n" +
                    $"Track: {_tracks.FirstOrDefault(t => t.TrackId == applicant.AcceptedTrackId)?.Name}\n" +
                    $"Branch: {_branches.FirstOrDefault(b => b.BranchId == applicant.AcceptedBranchId)?.Name}",
                    "Confirm Finalization",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                
                if (confirmResult == DialogResult.Yes)
                {
                    // Create student user
                    var student = new Core.Models.Student
                    {
                        Username = result.Username,
                        Email = applicant.Email,
                        FullName = applicant.FullName,
                        Phone = applicant.Phone,
                        Age = applicant.Age,
                        Gender = applicant.Gender,
                        Address = applicant.Address,
                        TrackId = applicant.AcceptedTrackId ?? 0,
                        BranchId = applicant.AcceptedBranchId ?? 0,
                        RoleEnum = Common.Enums.UserRoleEnum.Student
                    };
                    
                    // Register student
                    await _userService.RegisterAsync(student, result.Password);
                    
                    // Update applicant status
                    applicant.Status = ApplicationStatus.Approved;
                    applicant.Username = result.Username;
                    applicant.PasswordHash = result.Password; // In real app, this would be hashed
                    
                    // Send welcome email
                    await _emailService.SendEmailAsync(
                        applicant.Email,
                        "Welcome to Legacy Examination System - Account Created",
                        $"Dear {applicant.FullName},\n\n" +
                        $"Congratulations! Your account has been successfully created.\n\n" +
                        $"Your login credentials:\n" +
                        $"Username: {result.Username}\n" +
                        $"Password: {result.Password}\n\n" +
                        $"Please log in to the system and change your password for security.\n\n" +
                        $"You have been enrolled in:\n" +
                        $"Track: {_tracks.FirstOrDefault(t => t.TrackId == applicant.AcceptedTrackId)?.Name}\n" +
                        $"Branch: {_branches.FirstOrDefault(b => b.BranchId == applicant.AcceptedBranchId)?.Name}\n\n" +
                        $"Welcome to the Legacy Examination System!\n\n" +
                        $"Best regards,\nAdministration Team");
                    
                    MessageBox.Show($"Applicant {applicant.FullName} has been successfully finalized as a student.\n\n" +
                                  $"Username: {result.Username}\n" +
                                  $"Welcome email sent to: {applicant.Email}", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Refresh the list
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finalizing applicant: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewApplicantDetails(Applicant applicant)
        {
            var detailsForm = new Form
            {
                Text = $"Applicant Details - {applicant.FullName}",
                Size = new System.Drawing.Size(500, 600),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20)
            };
            
            var yPosition = 20;
            
            // Personal Information
            var lblPersonalTitle = new Label
            {
                Text = "Personal Information",
                Location = new System.Drawing.Point(20, yPosition),
                Size = new System.Drawing.Size(400, 25),
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold)
            };
            yPosition += 35;
            
            var personalInfo = new[]
            {
                $"Full Name: {applicant.FullName}",
                $"Email: {applicant.Email}",
                $"Phone: {applicant.Phone}",
                $"Age: {applicant.Age}",
                $"Gender: {applicant.GenderDisplay}",
                $"Address: {applicant.Address ?? "Not provided"}",
                $"Application Date: {applicant.CreatedAt?.ToString("MMM dd, yyyy HH:mm") ?? "N/A"}"
            };
            
            foreach (var info in personalInfo)
            {
                var lbl = new Label
                {
                    Text = info,
                    Location = new System.Drawing.Point(20, yPosition),
                    Size = new System.Drawing.Size(400, 20)
                };
                panel.Controls.Add(lbl);
                yPosition += 25;
            }
            
            yPosition += 20;
            
            // Application Information
            var lblAppTitle = new Label
            {
                Text = "Application Information",
                Location = new System.Drawing.Point(20, yPosition),
                Size = new System.Drawing.Size(400, 25),
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold)
            };
            yPosition += 35;
            
            var branch = _branches.FirstOrDefault(b => b.BranchId == applicant.AcceptedBranchId);
            var track = _tracks.FirstOrDefault(t => t.TrackId == applicant.AcceptedTrackId);
            
            var appInfo = new[]
            {
                $"Application Code: {applicant.ApplicationCode}",
                $"Status: {applicant.Status}",
                $"Accepted Branch: {branch?.Name ?? "Unknown"} ({branch?.Location ?? "Unknown location"})",
                $"Accepted Track: {track?.Name ?? "Unknown"}",
                $"Track Description: {track?.Description ?? "No description available"}"
            };
            
            foreach (var info in appInfo)
            {
                var lbl = new Label
                {
                    Text = info,
                    Location = new System.Drawing.Point(20, yPosition),
                    Size = new System.Drawing.Size(400, 20)
                };
                panel.Controls.Add(lbl);
                yPosition += 25;
            }
            
            // Preferred Tracks (if available)
            if (applicant.SelectedTracks != null && applicant.SelectedTracks.Count >= 2)
            {
                yPosition += 20;
                var lblPrefTitle = new Label
                {
                    Text = "Original Preferred Tracks",
                    Location = new System.Drawing.Point(20, yPosition),
                    Size = new System.Drawing.Size(400, 25),
                    Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold)
                };
                yPosition += 35;
                
                for (int i = 0; i < Math.Min(applicant.SelectedTracks.Count, 2); i++)
                {
                    var prefTrack = _tracks.FirstOrDefault(t => t.TrackId == applicant.SelectedTracks[i]);
                    var lbl = new Label
                    {
                        Text = $"Preference {i + 1}: {prefTrack?.Name ?? "Unknown"}",
                        Location = new System.Drawing.Point(20, yPosition),
                        Size = new System.Drawing.Size(400, 20)
                    };
                    panel.Controls.Add(lbl);
                    yPosition += 25;
                }
            }
            
            var btnClose = new Button
            {
                Text = "Close",
                Location = new System.Drawing.Point(200, yPosition + 20),
                Size = new System.Drawing.Size(100, 30),
                DialogResult = DialogResult.OK
            };
            panel.Controls.Add(btnClose);
            
            detailsForm.Controls.Add(panel);
            detailsForm.ShowDialog();
        }

        private FinalizationResult ShowFinalizationDialog(Applicant applicant)
        {
            var dialog = new Form
            {
                Text = "Finalize Applicant",
                Size = new System.Drawing.Size(400, 350),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            
            var lblTitle = new Label
            {
                Text = $"Finalize {applicant.FullName}",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(350, 25),
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold)
            };
            
            var lblUsername = new Label
            {
                Text = "Username:",
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(100, 20)
            };
            
            var txtUsername = new TextBox
            {
                Location = new System.Drawing.Point(130, 58),
                Size = new System.Drawing.Size(200, 25),
                Text = GenerateUsername(applicant)
            };
            
            var lblPassword = new Label
            {
                Text = "Password:",
                Location = new System.Drawing.Point(20, 100),
                Size = new System.Drawing.Size(100, 20)
            };
            
            var txtPassword = new TextBox
            {
                Location = new System.Drawing.Point(130, 98),
                Size = new System.Drawing.Size(200, 25),
                UseSystemPasswordChar = true,
                Text = GeneratePassword()
            };
            
            var lblConfirmPassword = new Label
            {
                Text = "Confirm Password:",
                Location = new System.Drawing.Point(20, 140),
                Size = new System.Drawing.Size(100, 20)
            };
            
            var txtConfirmPassword = new TextBox
            {
                Location = new System.Drawing.Point(130, 138),
                Size = new System.Drawing.Size(200, 25),
                UseSystemPasswordChar = true,
                Text = txtPassword.Text
            };
            
            var btnGeneratePassword = new Button
            {
                Text = "Generate New Password",
                Location = new System.Drawing.Point(20, 180),
                Size = new System.Drawing.Size(150, 30)
            };
            btnGeneratePassword.Click += (s, e) => 
            {
                var newPassword = GeneratePassword();
                txtPassword.Text = newPassword;
                txtConfirmPassword.Text = newPassword;
            };
            
            var btnOK = new Button
            {
                Text = "OK",
                Location = new System.Drawing.Point(200, 250),
                Size = new System.Drawing.Size(75, 30),
                DialogResult = DialogResult.OK
            };
            
            var btnCancel = new Button
            {
                Text = "Cancel",
                Location = new System.Drawing.Point(285, 250),
                Size = new System.Drawing.Size(75, 30),
                DialogResult = DialogResult.Cancel
            };
            
            dialog.Controls.AddRange(new Control[] { 
                lblTitle, lblUsername, txtUsername, lblPassword, txtPassword, 
                lblConfirmPassword, txtConfirmPassword, btnGeneratePassword, btnOK, btnCancel 
            });
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                
                if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                
                return new FinalizationResult
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text
                };
            }
            
            return null;
        }

        private string GenerateUsername(Applicant applicant)
        {
            // Generate username from first name + last name + random number
            var nameParts = applicant.FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var firstName = nameParts.Length > 0 ? nameParts[0].ToLower() : "user";
            var lastName = nameParts.Length > 1 ? nameParts[1].ToLower() : "";
            
            var baseUsername = lastName.Length > 0 ? $"{firstName}.{lastName}" : firstName;
            var random = new Random();
            var randomNumber = random.Next(100, 999);
            
            return $"{baseUsername}{randomNumber}";
        }

        private string GeneratePassword()
        {
            // Generate a random password
            var random = new Random();
            var password = "";
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            
            for (int i = 0; i < 8; i++)
            {
                password += chars[random.Next(chars.Length)];
            }
            
            return password;
        }

        private void UpdateUIText()
        {
            this.Text = "Admin - Applicant Finalization";
            lblTitle.Text = "Applicant Finalization";
            lblSubtitle.Text = "Finalize approved applicants by creating their student accounts";
            btnRefresh.Text = "Refresh";
            btnBackToDashboard.Text = "Back to Dashboard";
            lblNoApplicants.Text = "No approved applicants found for finalization.";

            // Update language combo
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_English")} (EN)");
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_Arabic")} (AR)");
            cmbLanguage.SelectedIndex = localizationManager.GetCurrentLanguage() == "ar" ? 1 : 0;
            
            // Update theme button
            btnTheme.Text = themeManager.GetCurrentTheme() == ThemeMode.Light 
                ? localizationManager.GetString("Theme_Dark") 
                : localizationManager.GetString("Theme_Light");
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            var dashboard = Program.ServiceProvider.GetRequiredService<MainDashboard>();
            dashboard.Show();
            this.Hide();
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

        private class FinalizationResult
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
}
