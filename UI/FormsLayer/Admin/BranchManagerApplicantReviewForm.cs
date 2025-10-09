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
    public partial class BranchManagerApplicantReviewForm : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;
        private SessionManager sessionManager;
        
        // Services
        private readonly IApplicantService _applicantService;
        private readonly IBranchService _branchService;
        private readonly ITrackService _trackService;
        private readonly IEmailService _emailService;
        
        // Form state
        private List<Applicant> _pendingApplicants = new List<Applicant>();
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

        public BranchManagerApplicantReviewForm()
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
                // Load pending applicants for this branch manager's branch
                var allApplicants = await _applicantService.GetPendingApplicationsAsync();
                _pendingApplicants = allApplicants.Where(a => 
                    a.SelectedBranches.Contains(sessionManager.BranchId ?? 0)).ToList();
                
                // Load tracks for track selection
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
            
            if (_pendingApplicants.Count == 0)
            {
                lblNoApplicants.Visible = true;
                return;
            }
            
            lblNoApplicants.Visible = false;
            
            foreach (var applicant in _pendingApplicants)
            {
                var applicantCard = CreateApplicantCard(applicant);
                panelApplicants.Controls.Add(applicantCard);
            }
        }

        private MaterialCard CreateApplicantCard(Applicant applicant)
        {
            var card = new MaterialCard
            {
                Size = new System.Drawing.Size(400, 300),
                Margin = new Padding(10),
                Padding = new Padding(15)
            };
            
            // Applicant info panel
            var infoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 200
            };
            
            var lblName = new MaterialLabel
            {
                Text = $"Name: {applicant.FullName}",
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(350, 20),
                FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1
            };
            
            var lblEmail = new MaterialLabel
            {
                Text = $"Email: {applicant.Email}",
                Location = new System.Drawing.Point(10, 40),
                Size = new System.Drawing.Size(350, 20)
            };
            
            var lblPhone = new MaterialLabel
            {
                Text = $"Phone: {applicant.Phone}",
                Location = new System.Drawing.Point(10, 70),
                Size = new System.Drawing.Size(350, 20)
            };
            
            var lblAge = new MaterialLabel
            {
                Text = $"Age: {applicant.Age}",
                Location = new System.Drawing.Point(10, 100),
                Size = new System.Drawing.Size(350, 20)
            };
            
            var lblGender = new MaterialLabel
            {
                Text = $"Gender: {applicant.GenderDisplay}",
                Location = new System.Drawing.Point(10, 130),
                Size = new System.Drawing.Size(350, 20)
            };
            
            var lblApplicationDate = new MaterialLabel
            {
                Text = $"Applied: {applicant.CreatedAt?.ToString("MMM dd, yyyy") ?? "N/A"}",
                Location = new System.Drawing.Point(10, 160),
                Size = new System.Drawing.Size(350, 20)
            };
            
            infoPanel.Controls.AddRange(new Control[] { lblName, lblEmail, lblPhone, lblAge, lblGender, lblApplicationDate });
            
            // Preferred tracks info
            var tracksInfo = GetPreferredTracksInfo(applicant);
            var lblTracks = new MaterialLabel
            {
                Text = $"Preferred Tracks: {tracksInfo}",
                Location = new System.Drawing.Point(10, 190),
                Size = new System.Drawing.Size(350, 20),
                FontType = MaterialSkin.MaterialSkinManager.fontType.Body2
            };
            infoPanel.Controls.Add(lblTracks);
            
            // Action buttons panel
            var buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50
            };
            
            var btnAccept = new MaterialButton
            {
                Text = "Accept",
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(100, 30),
                Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained,
                UseAccentColor = true
            };
            btnAccept.Click += (s, e) => AcceptApplicant(applicant);
            
            var btnReject = new MaterialButton
            {
                Text = "Reject",
                Location = new System.Drawing.Point(120, 10),
                Size = new System.Drawing.Size(100, 30),
                Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined
            };
            btnReject.Click += (s, e) => RejectApplicant(applicant);
            
            buttonPanel.Controls.AddRange(new Control[] { btnAccept, btnReject });
            
            card.Controls.Add(infoPanel);
            card.Controls.Add(buttonPanel);
            
            return card;
        }

        private string GetPreferredTracksInfo(Applicant applicant)
        {
            if (applicant.SelectedTracks == null || applicant.SelectedTracks.Count < 2)
                return "No tracks selected";
            
            var track1 = _tracks.FirstOrDefault(t => t.TrackId == applicant.SelectedTracks[0]);
            var track2 = _tracks.FirstOrDefault(t => t.TrackId == applicant.SelectedTracks[1]);
            
            var track1Name = track1?.Name ?? "Unknown";
            var track2Name = track2?.Name ?? "Unknown";
            
            return $"{track1Name}, {track2Name}";
        }

        private async void AcceptApplicant(Applicant applicant)
        {
            try
            {
                // Show track selection dialog
                var selectedTrack = ShowTrackSelectionDialog(applicant);
                if (selectedTrack == null)
                    return;
                
                // Confirm acceptance
                var result = MessageBox.Show(
                    $"Are you sure you want to accept {applicant.FullName} for the {selectedTrack.Name} track?",
                    "Confirm Acceptance",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    // Update applicant status
                    applicant.Status = ApplicationStatus.UnderReview;
                    applicant.AcceptedTrackId = selectedTrack.TrackId;
                    applicant.AcceptedBranchId = sessionManager.BranchId;
                    
                    await _applicantService.ApproveApplicantAsync(applicant.Id);
                    
                    // Send acceptance email
                    await _emailService.SendEmailAsync(
                        applicant.Email,
                        "Application Approved - Pending Admin Setup",
                        $"Dear {applicant.FullName},\n\n" +
                        $"Congratulations! Your application has been approved by the branch manager.\n" +
                        $"You have been accepted for the {selectedTrack.Name} track.\n\n" +
                        $"The admin will now set up your account and send you login credentials.\n\n" +
                        $"Thank you for your interest in the Legacy Examination System.\n\n" +
                        $"Best regards,\nBranch Management Team");
                    
                    MessageBox.Show($"Applicant {applicant.FullName} has been accepted for {selectedTrack.Name} track.", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Refresh the list
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error accepting applicant: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void RejectApplicant(Applicant applicant)
        {
            try
            {
                // Show rejection reason dialog
                var reason = ShowRejectionReasonDialog();
                if (string.IsNullOrWhiteSpace(reason))
                    return;
                
                // Confirm rejection
                var result = MessageBox.Show(
                    $"Are you sure you want to reject {applicant.FullName}?",
                    "Confirm Rejection",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    // Update applicant status
                    applicant.Status = ApplicationStatus.Rejected;
                    
                    await _applicantService.RejectApplicantAsync(applicant.Id);
                    
                    // Send rejection email
                    await _emailService.SendEmailAsync(
                        applicant.Email,
                        "Application Status Update",
                        $"Dear {applicant.FullName},\n\n" +
                        $"Thank you for your interest in the Legacy Examination System.\n\n" +
                        $"After careful consideration, we regret to inform you that your application has not been approved at this time.\n\n" +
                        $"Reason: {reason}\n\n" +
                        $"We encourage you to reapply in the future when you meet the requirements.\n\n" +
                        $"Best regards,\nBranch Management Team");
                    
                    MessageBox.Show($"Applicant {applicant.FullName} has been rejected.", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Refresh the list
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error rejecting applicant: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Track ShowTrackSelectionDialog(Applicant applicant)
        {
            var dialog = new Form
            {
                Text = "Select Track for Applicant",
                Size = new System.Drawing.Size(400, 200),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            
            var lblTitle = new Label
            {
                Text = $"Select a track for {applicant.FullName}:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(350, 20)
            };
            
            var cmbTracks = new ComboBox
            {
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(300, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            
            // Add only the two preferred tracks
            if (applicant.SelectedTracks != null && applicant.SelectedTracks.Count >= 2)
            {
                var track1 = _tracks.FirstOrDefault(t => t.TrackId == applicant.SelectedTracks[0]);
                var track2 = _tracks.FirstOrDefault(t => t.TrackId == applicant.SelectedTracks[1]);
                
                if (track1 != null) cmbTracks.Items.Add(track1);
                if (track2 != null) cmbTracks.Items.Add(track2);
            }
            
            var btnOK = new Button
            {
                Text = "OK",
                Location = new System.Drawing.Point(200, 100),
                Size = new System.Drawing.Size(75, 30),
                DialogResult = DialogResult.OK
            };
            
            var btnCancel = new Button
            {
                Text = "Cancel",
                Location = new System.Drawing.Point(285, 100),
                Size = new System.Drawing.Size(75, 30),
                DialogResult = DialogResult.Cancel
            };
            
            dialog.Controls.AddRange(new Control[] { lblTitle, cmbTracks, btnOK, btnCancel });
            
            if (dialog.ShowDialog() == DialogResult.OK && cmbTracks.SelectedItem is Track selectedTrack)
            {
                return selectedTrack;
            }
            
            return null;
        }

        private string ShowRejectionReasonDialog()
        {
            var dialog = new Form
            {
                Text = "Rejection Reason",
                Size = new System.Drawing.Size(400, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            
            var lblTitle = new Label
            {
                Text = "Please provide a reason for rejection:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(350, 20)
            };
            
            var txtReason = new TextBox
            {
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(340, 100),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            
            var btnOK = new Button
            {
                Text = "OK",
                Location = new System.Drawing.Point(200, 170),
                Size = new System.Drawing.Size(75, 30),
                DialogResult = DialogResult.OK
            };
            
            var btnCancel = new Button
            {
                Text = "Cancel",
                Location = new System.Drawing.Point(285, 170),
                Size = new System.Drawing.Size(75, 30),
                DialogResult = DialogResult.Cancel
            };
            
            dialog.Controls.AddRange(new Control[] { lblTitle, txtReason, btnOK, btnCancel });
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return txtReason.Text.Trim();
            }
            
            return null;
        }

        private void UpdateUIText()
        {
            this.Text = "Branch Manager - Applicant Review";
            lblTitle.Text = "Applicant Review";
            lblSubtitle.Text = "Review and approve/reject pending applications for your branch";
            btnRefresh.Text = "Refresh";
            btnBackToDashboard.Text = "Back to Dashboard";
            lblNoApplicants.Text = "No pending applicants found for your branch.";

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
    }
}
