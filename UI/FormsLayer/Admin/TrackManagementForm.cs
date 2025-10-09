using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Core.Models;
using UI.FormsLayer.Shared;

namespace UI.FormsLayer.Admin
{
    public partial class TrackManagementForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly LocalizationManager localizationManager;
        private readonly ThemeManager themeManager;
        private readonly SessionManager sessionManager;
        private readonly ITrackService _trackService;
        private readonly IBranchService _branchService;

        // Controls
        private MaterialLabel lblTitle;
        private MaterialLabel lblSubtitle;
        private MaterialComboBox cmbLanguage;
        private MaterialButton btnTheme;
        private MaterialButton btnBackToDashboard;
        private MaterialButton btnRefresh;
        private MaterialButton btnAddTrack;
        private MaterialButton btnEditTrack;
        private MaterialButton btnDeleteTrack;
        private MaterialButton btnAssignToBranch;
        private MaterialTextBox txtSearch;
        private MaterialComboBox cmbBranchFilter;
        private DataGridView dgvTracks;
        private Panel panelMain;
        private Panel panelTop;
        private Panel panelContent;
        private Panel panelTracks;
        private MaterialLabel lblNoTracks;

        public TrackManagementForm(ITrackService trackService, IBranchService branchService)
        {
            _trackService = trackService;
            _branchService = branchService;

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
            lblSubtitle = new MaterialLabel();
            cmbLanguage = new MaterialComboBox();
            btnTheme = new MaterialButton();
            btnBackToDashboard = new MaterialButton();
            btnRefresh = new MaterialButton();
            btnAddTrack = new MaterialButton();
            btnEditTrack = new MaterialButton();
            btnDeleteTrack = new MaterialButton();
            btnAssignToBranch = new MaterialButton();
            txtSearch = new MaterialTextBox();
            cmbBranchFilter = new MaterialComboBox();
            dgvTracks = new DataGridView();
            panelMain = new Panel();
            panelTop = new Panel();
            panelContent = new Panel();
            panelTracks = new Panel();
            lblNoTracks = new MaterialLabel();

            // Configure form
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Track Management";
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
            lblTitle.Text = "Track Management";

            // Subtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.Depth = 0;
            lblSubtitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSubtitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblSubtitle.Location = new Point(20, 70);
            lblSubtitle.Text = "Manage tracks and their assignments to branches";

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

            // Back to Dashboard button
            btnBackToDashboard.AutoSize = false;
            btnBackToDashboard.Size = new Size(150, 50);
            btnBackToDashboard.Location = new Point(260, 20);
            btnBackToDashboard.Text = "Back to Dashboard";
            btnBackToDashboard.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnBackToDashboard.Click += btnBackToDashboard_Click;

            // Refresh button
            btnRefresh.AutoSize = false;
            btnRefresh.Size = new Size(100, 50);
            btnRefresh.Location = new Point(420, 20);
            btnRefresh.Text = "Refresh";
            btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRefresh.Click += btnRefresh_Click;

            // Add Track button
            btnAddTrack.AutoSize = false;
            btnAddTrack.Size = new Size(120, 40);
            btnAddTrack.Text = "Add Track";
            btnAddTrack.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddTrack.Click += btnAddTrack_Click;

            // Edit Track button
            btnEditTrack.AutoSize = false;
            btnEditTrack.Size = new Size(120, 40);
            btnEditTrack.Text = "Edit Track";
            btnEditTrack.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnEditTrack.Click += btnEditTrack_Click;

            // Delete Track button
            btnDeleteTrack.AutoSize = false;
            btnDeleteTrack.Size = new Size(120, 40);
            btnDeleteTrack.Text = "Delete Track";
            btnDeleteTrack.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnDeleteTrack.Click += btnDeleteTrack_Click;

            // Assign to Branch button
            btnAssignToBranch.AutoSize = false;
            btnAssignToBranch.Size = new Size(140, 40);
            btnAssignToBranch.Text = "Assign to Branch";
            btnAssignToBranch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnAssignToBranch.Click += btnAssignToBranch_Click;

            // Search textbox
            txtSearch.Hint = "Search tracks...";
            txtSearch.Size = new Size(200, 50);
            txtSearch.TextChanged += txtSearch_TextChanged;

            // Branch filter
            cmbBranchFilter.AutoResize = false;
            cmbBranchFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranchFilter.Size = new Size(150, 50);
            cmbBranchFilter.SelectedIndexChanged += cmbBranchFilter_SelectedIndexChanged;

            // DataGridView
            dgvTracks.AllowUserToAddRows = false;
            dgvTracks.AllowUserToDeleteRows = false;
            dgvTracks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTracks.BackgroundColor = Color.White;
            dgvTracks.BorderStyle = BorderStyle.None;
            dgvTracks.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvTracks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTracks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTracks.ColumnHeadersHeight = 56;
            dgvTracks.Dock = DockStyle.Fill;
            dgvTracks.EnableHeadersVisualStyles = false;
            dgvTracks.GridColor = Color.FromArgb(255, 255, 255);
            dgvTracks.Location = new Point(0, 0);
            dgvTracks.Margin = new Padding(4, 5, 4, 5);
            dgvTracks.MultiSelect = false;
            dgvTracks.Name = "dgvTracks";
            dgvTracks.ReadOnly = true;
            dgvTracks.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTracks.RowHeadersVisible = false;
            dgvTracks.RowHeadersWidth = 51;
            dgvTracks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTracks.Size = new Size(1000, 400);
            dgvTracks.TabIndex = 0;

            // No tracks label
            lblNoTracks.AutoSize = true;
            lblNoTracks.Depth = 0;
            lblNoTracks.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNoTracks.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblNoTracks.Location = new Point(50, 200);
            lblNoTracks.Text = "No tracks found";
            lblNoTracks.Visible = false;
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
                cmbLanguage, btnTheme, btnBackToDashboard, btnRefresh
            });

            panelContent.Dock = DockStyle.Fill;
            panelContent.Controls.Add(panelTracks);
            panelContent.Controls.Add(lblTitle);
            panelContent.Controls.Add(lblSubtitle);

            panelTracks.Dock = DockStyle.Fill;
            panelTracks.Location = new Point(20, 120);
            panelTracks.Size = new Size(1160, 560);
            panelTracks.Controls.Add(dgvTracks);
            panelTracks.Controls.Add(lblNoTracks);

            // Add filter controls to a separate panel
            var filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 60;
            filterPanel.Controls.AddRange(new Control[] {
                txtSearch, cmbBranchFilter, btnAddTrack, btnEditTrack, btnDeleteTrack, btnAssignToBranch
            });

            // Position filter controls
            txtSearch.Location = new Point(20, 10);
            cmbBranchFilter.Location = new Point(240, 10);
            btnAddTrack.Location = new Point(410, 10);
            btnEditTrack.Location = new Point(550, 10);
            btnDeleteTrack.Location = new Point(690, 10);
            btnAssignToBranch.Location = new Point(850, 10);

            panelTracks.Controls.Add(filterPanel);

            // Add controls to form
            this.Controls.Add(panelMain);
        }

        private void SetupForm()
        {
            materialSkinManager.AddFormToManage(this);
            themeManager.ApplyTheme(materialSkinManager);
            LoadTracks();
            LoadBranches();
        }

        private async void LoadTracks()
        {
            try
            {
                var tracks = await _trackService.GetAllTracksAsync();
                dgvTracks.DataSource = tracks.Select(t => new
                {
                    t.TrackId,
                    t.Name,
                    t.Description,
                    AssignedBranches = t.BranchTracks?.Count ?? 0,
                    CourseCount = t.TrackCourses?.Count ?? 0,
                    // TODO: Add Students navigation property to Track model
                    // StudentCount = t.Students?.Count ?? 0,
                    CreatedAt = t.CreatedAt?.ToString("yyyy-MM-dd") ?? "N/A"
                }).ToList();

                lblNoTracks.Visible = tracks.Count() == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tracks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadBranches()
        {
            try
            {
                var branches = await _branchService.GetAllBranchesAsync();
                cmbBranchFilter.Items.Clear();
                cmbBranchFilter.Items.Add("All Branches");
                foreach (var branch in branches)
                {
                    cmbBranchFilter.Items.Add(branch.Name);
                }
                cmbBranchFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading branches: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            // TODO: Open TrackDetailsForm for adding new track
            MessageBox.Show("Add Track functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditTrack_Click(object sender, EventArgs e)
        {
            if (dgvTracks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a track to edit", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Open TrackDetailsForm for editing selected track
            MessageBox.Show("Edit Track functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnDeleteTrack_Click(object sender, EventArgs e)
        {
            if (dgvTracks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a track to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this track?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var trackId = (int)dgvTracks.SelectedRows[0].Cells["TrackId"].Value;
                    // TODO: Implement DeleteAsync method in ITrackService
                // await _trackService.DeleteAsync(trackId);
                    LoadTracks();
                    MessageBox.Show("Track deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting track: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAssignToBranch_Click(object sender, EventArgs e)
        {
            if (dgvTracks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a track to assign to branch", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Open TrackBranchAssignmentForm
            MessageBox.Show("Assign Track to Branch functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement search filtering
        }

        private void cmbBranchFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Implement branch filtering
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTracks();
        }

        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            var dashboard = new MainDashboard();
            dashboard.Show();
            this.Hide();
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
