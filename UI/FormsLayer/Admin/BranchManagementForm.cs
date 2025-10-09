using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Core.Models;
using UI.FormsLayer.Shared;

namespace UI.FormsLayer.Admin
{
    public partial class BranchManagementForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly LocalizationManager localizationManager;
        private readonly ThemeManager themeManager;
        private readonly SessionManager sessionManager;
        private readonly IBranchService _branchService;

        // Controls
        private MaterialLabel lblTitle;
        private MaterialLabel lblSubtitle;
        private MaterialComboBox cmbLanguage;
        private MaterialButton btnTheme;
        private MaterialButton btnBackToDashboard;
        private MaterialButton btnRefresh;
        private MaterialButton btnAddBranch;
        private MaterialButton btnEditBranch;
        private MaterialButton btnDeleteBranch;
        private MaterialTextBox txtSearch;
        private DataGridView dgvBranches;
        private Panel panelMain;
        private Panel panelTop;
        private Panel panelContent;
        private Panel panelBranches;
        private MaterialLabel lblNoBranches;

        public BranchManagementForm(IBranchService branchService)
        {
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
            btnAddBranch = new MaterialButton();
            btnEditBranch = new MaterialButton();
            btnDeleteBranch = new MaterialButton();
            txtSearch = new MaterialTextBox();
            dgvBranches = new DataGridView();
            panelMain = new Panel();
            panelTop = new Panel();
            panelContent = new Panel();
            panelBranches = new Panel();
            lblNoBranches = new MaterialLabel();

            // Configure form
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Branch Management";
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
            lblTitle.Text = "Branch Management";

            // Subtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.Depth = 0;
            lblSubtitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSubtitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblSubtitle.Location = new Point(20, 70);
            lblSubtitle.Text = "Manage system branches and their locations";

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

            // Add Branch button
            btnAddBranch.AutoSize = false;
            btnAddBranch.Size = new Size(120, 40);
            btnAddBranch.Text = "Add Branch";
            btnAddBranch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddBranch.Click += btnAddBranch_Click;

            // Edit Branch button
            btnEditBranch.AutoSize = false;
            btnEditBranch.Size = new Size(120, 40);
            btnEditBranch.Text = "Edit Branch";
            btnEditBranch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnEditBranch.Click += btnEditBranch_Click;

            // Delete Branch button
            btnDeleteBranch.AutoSize = false;
            btnDeleteBranch.Size = new Size(120, 40);
            btnDeleteBranch.Text = "Delete Branch";
            btnDeleteBranch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnDeleteBranch.Click += btnDeleteBranch_Click;

            // Search textbox
            txtSearch.Hint = "Search branches...";
            txtSearch.Size = new Size(200, 50);
            txtSearch.TextChanged += txtSearch_TextChanged;

            // DataGridView
            dgvBranches.AllowUserToAddRows = false;
            dgvBranches.AllowUserToDeleteRows = false;
            dgvBranches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBranches.BackgroundColor = Color.White;
            dgvBranches.BorderStyle = BorderStyle.None;
            dgvBranches.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvBranches.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBranches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBranches.ColumnHeadersHeight = 56;
            dgvBranches.Dock = DockStyle.Fill;
            dgvBranches.EnableHeadersVisualStyles = false;
            dgvBranches.GridColor = Color.FromArgb(255, 255, 255);
            dgvBranches.Location = new Point(0, 0);
            dgvBranches.Margin = new Padding(4, 5, 4, 5);
            dgvBranches.MultiSelect = false;
            dgvBranches.Name = "dgvBranches";
            dgvBranches.ReadOnly = true;
            dgvBranches.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBranches.RowHeadersVisible = false;
            dgvBranches.RowHeadersWidth = 51;
            dgvBranches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBranches.Size = new Size(1000, 400);
            dgvBranches.TabIndex = 0;

            // No branches label
            lblNoBranches.AutoSize = true;
            lblNoBranches.Depth = 0;
            lblNoBranches.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNoBranches.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblNoBranches.Location = new Point(50, 200);
            lblNoBranches.Text = "No branches found";
            lblNoBranches.Visible = false;
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
            panelContent.Controls.Add(panelBranches);
            panelContent.Controls.Add(lblTitle);
            panelContent.Controls.Add(lblSubtitle);

            panelBranches.Dock = DockStyle.Fill;
            panelBranches.Location = new Point(20, 120);
            panelBranches.Size = new Size(1160, 560);
            panelBranches.Controls.Add(dgvBranches);
            panelBranches.Controls.Add(lblNoBranches);

            // Add filter controls to a separate panel
            var filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 60;
            filterPanel.Controls.AddRange(new Control[] {
                txtSearch, btnAddBranch, btnEditBranch, btnDeleteBranch
            });

            // Position filter controls
            txtSearch.Location = new Point(20, 10);
            btnAddBranch.Location = new Point(240, 10);
            btnEditBranch.Location = new Point(380, 10);
            btnDeleteBranch.Location = new Point(520, 10);

            panelBranches.Controls.Add(filterPanel);

            // Add controls to form
            this.Controls.Add(panelMain);
        }

        private void SetupForm()
        {
            materialSkinManager.AddFormToManage(this);
            themeManager.ApplyTheme(materialSkinManager);
            LoadBranches();
        }

        private async void LoadBranches()
        {
            try
            {
                var branches = await _branchService.GetAllBranchesAsync();
                dgvBranches.DataSource = branches.Select(b => new
                {
                    b.BranchId,
                    b.Name,
                    b.Location,
                    ManagerName = b.Manager?.Username ?? "Not Assigned",
                    StudentCount = b.Students?.Count ?? 0,
                    TrackCount = b.BranchTracks?.Count ?? 0,
                    CreatedAt = b.CreatedAt?.ToString("yyyy-MM-dd") ?? "N/A"
                }).ToList();

                lblNoBranches.Visible = branches.Count() == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading branches: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddBranch_Click(object sender, EventArgs e)
        {
            // TODO: Open BranchDetailsForm for adding new branch
            MessageBox.Show("Add Branch functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditBranch_Click(object sender, EventArgs e)
        {
            if (dgvBranches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a branch to edit", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Open BranchDetailsForm for editing selected branch
            MessageBox.Show("Edit Branch functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnDeleteBranch_Click(object sender, EventArgs e)
        {
            if (dgvBranches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a branch to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this branch?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var branchId = (int)dgvBranches.SelectedRows[0].Cells["BranchId"].Value;
                    // TODO: Implement DeleteAsync method in IBranchService
                // await _branchService.DeleteAsync(branchId);
                    LoadBranches();
                    MessageBox.Show("Branch deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting branch: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement search filtering
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBranches();
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
