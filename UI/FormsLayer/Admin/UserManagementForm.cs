using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Core.Models;
using Common.Enums;
using UI.FormsLayer.Shared;
using StudentModel = Core.Models.Student;
using InstructorModel = Core.Models.Instructor;
using AdminModel = Core.Models.Admin;

namespace UI.FormsLayer.Admin
{
    public partial class UserManagementForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly LocalizationManager localizationManager;
        private readonly ThemeManager themeManager;
        private readonly SessionManager sessionManager;
        private readonly IUserService _userService;
        private readonly IBranchService _branchService;
        private readonly ITrackService _trackService;

        // Controls
        private MaterialLabel lblTitle;
        private MaterialLabel lblSubtitle;
        private MaterialComboBox cmbLanguage;
        private MaterialButton btnTheme;
        private MaterialButton btnBackToDashboard;
        private MaterialButton btnRefresh;
        private MaterialButton btnAddUser;
        private MaterialButton btnEditUser;
        private MaterialButton btnDeleteUser;
        private MaterialTextBox txtSearch;
        private MaterialComboBox cmbRoleFilter;
        private MaterialComboBox cmbBranchFilter;
        private DataGridView dgvUsers;
        private Panel panelMain;
        private Panel panelTop;
        private Panel panelContent;
        private Panel panelUsers;
        private MaterialLabel lblNoUsers;

        public UserManagementForm(
            IUserService userService,
            IBranchService branchService,
            ITrackService trackService)
        {
            _userService = userService;
            _branchService = branchService;
            _trackService = trackService;

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
            btnAddUser = new MaterialButton();
            btnEditUser = new MaterialButton();
            btnDeleteUser = new MaterialButton();
            txtSearch = new MaterialTextBox();
            cmbRoleFilter = new MaterialComboBox();
            cmbBranchFilter = new MaterialComboBox();
            dgvUsers = new DataGridView();
            panelMain = new Panel();
            panelTop = new Panel();
            panelContent = new Panel();
            panelUsers = new Panel();
            lblNoUsers = new MaterialLabel();

            // Configure form
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "User Management";
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
            lblTitle.Text = "User Management";

            // Subtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.Depth = 0;
            lblSubtitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSubtitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblSubtitle.Location = new Point(20, 70);
            lblSubtitle.Text = "Manage system users and their roles";

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

            // Add User button
            btnAddUser.AutoSize = false;
            btnAddUser.Size = new Size(120, 40);
            btnAddUser.Text = "Add User";
            btnAddUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddUser.Click += btnAddUser_Click;

            // Edit User button
            btnEditUser.AutoSize = false;
            btnEditUser.Size = new Size(120, 40);
            btnEditUser.Text = "Edit User";
            btnEditUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnEditUser.Click += btnEditUser_Click;

            // Delete User button
            btnDeleteUser.AutoSize = false;
            btnDeleteUser.Size = new Size(120, 40);
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnDeleteUser.Click += btnDeleteUser_Click;

            // Search textbox
            txtSearch.Hint = "Search users...";
            txtSearch.Size = new Size(200, 50);
            txtSearch.TextChanged += txtSearch_TextChanged;

            // Role filter
            cmbRoleFilter.AutoResize = false;
            cmbRoleFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoleFilter.Size = new Size(150, 50);
            cmbRoleFilter.Items.AddRange(new[] { "All Roles", "Student", "Instructor", "Admin" });
            cmbRoleFilter.SelectedIndex = 0;
            cmbRoleFilter.SelectedIndexChanged += cmbRoleFilter_SelectedIndexChanged;

            // Branch filter
            cmbBranchFilter.AutoResize = false;
            cmbBranchFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranchFilter.Size = new Size(150, 50);
            cmbBranchFilter.SelectedIndexChanged += cmbBranchFilter_SelectedIndexChanged;

            // DataGridView
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsers.ColumnHeadersHeight = 56;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.FromArgb(255, 255, 255);
            dgvUsers.Location = new Point(0, 0);
            dgvUsers.Margin = new Padding(4, 5, 4, 5);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1200, 400);
            dgvUsers.TabIndex = 0;

            // No users label
            lblNoUsers.AutoSize = true;
            lblNoUsers.Depth = 0;
            lblNoUsers.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNoUsers.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblNoUsers.Location = new Point(50, 200);
            lblNoUsers.Text = "No users found";
            lblNoUsers.Visible = false;
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
            panelContent.Controls.Add(panelUsers);
            panelContent.Controls.Add(lblTitle);
            panelContent.Controls.Add(lblSubtitle);

            panelUsers.Dock = DockStyle.Fill;
            panelUsers.Location = new Point(20, 120);
            panelUsers.Size = new Size(1360, 600);
            panelUsers.Controls.Add(dgvUsers);
            panelUsers.Controls.Add(lblNoUsers);

            // Add controls to form
            this.Controls.Add(panelMain);

            // Add filter controls to a separate panel
            var filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 60;
            filterPanel.Controls.AddRange(new Control[] {
                txtSearch, cmbRoleFilter, cmbBranchFilter, btnAddUser, btnEditUser, btnDeleteUser
            });

            // Position filter controls
            txtSearch.Location = new Point(20, 10);
            cmbRoleFilter.Location = new Point(240, 10);
            cmbBranchFilter.Location = new Point(410, 10);
            btnAddUser.Location = new Point(580, 10);
            btnEditUser.Location = new Point(720, 10);
            btnDeleteUser.Location = new Point(860, 10);

            panelUsers.Controls.Add(filterPanel);
        }

        private void SetupForm()
        {
            materialSkinManager.AddFormToManage(this);
            themeManager.ApplyTheme(materialSkinManager);
            LoadUsers();
            LoadBranches();
        }

        private async void LoadUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                dgvUsers.DataSource = users.Select(u => new
                {
                    u.UserId,
                    u.Username,
                    u.Email,
                    Role = GetUserRole(u),
                    Branch = GetUserBranch(u),
                    Track = GetUserTrack(u),
                    // TODO: Add IsActive property to User model
                    // IsActive = u.IsActive ? "Yes" : "No",
                    CreatedAt = u.CreatedAt?.ToString("yyyy-MM-dd") ?? "N/A"
                }).ToList();

                lblNoUsers.Visible = users.Count() == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private string GetUserRole(User user)
        {
            if (user is StudentModel) return "Student";
            if (user is InstructorModel) return "Instructor";
            if (user is AdminModel) return "Admin";
            return "Unknown";
        }

        private string GetUserBranch(User user)
        {
            if (user is StudentModel student)
                return student.Branch?.Name ?? "N/A";
            if (user is InstructorModel instructor)
                return instructor.Branch?.Name ?? "N/A";
            return "N/A";
        }

        private string GetUserTrack(User user)
        {
            if (user is StudentModel student)
                return student.Track?.Name ?? "N/A";
            return "N/A";
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // TODO: Open UserDetailsForm for adding new user
            MessageBox.Show("Add User functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Open UserDetailsForm for editing selected user
            MessageBox.Show("Edit User functionality will be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var userId = (int)dgvUsers.SelectedRows[0].Cells["UserId"].Value;
                    // TODO: Implement DeleteAsync method in IUserService
                // await _userService.DeleteAsync(userId);
                    LoadUsers();
                    MessageBox.Show("User deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement search filtering
        }

        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Implement role filtering
        }

        private void cmbBranchFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Implement branch filtering
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
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
