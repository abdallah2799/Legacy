using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Core.Models;
using Common.Enums;
using StudentModel = Core.Models.Student;
using InstructorModel = Core.Models.Instructor;
using AdminModel = Core.Models.Admin;

namespace UI.FormsLayer.Admin
{
    public partial class UserDetailsForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly LocalizationManager localizationManager;
        private readonly ThemeManager themeManager;
        private readonly IUserService _userService;
        private readonly IBranchService _branchService;
        private readonly ITrackService _trackService;

        private User? _editingUser;
        private bool _isEditMode;

        // Controls
        private MaterialLabel lblTitle;
        private MaterialComboBox cmbLanguage;
        private MaterialButton btnTheme;
        private MaterialButton btnSave;
        private MaterialButton btnCancel;
        private MaterialTextBox txtUsername;
        private MaterialTextBox txtEmail;
        private MaterialTextBox txtPassword;
        private MaterialTextBox txtConfirmPassword;
        private MaterialComboBox cmbRole;
        private MaterialComboBox cmbBranch;
        private MaterialComboBox cmbTrack;
        private MaterialCheckbox chkIsActive;
        private Panel panelMain;
        private Panel panelTop;
        private Panel panelContent;
        private Panel panelForm;

        public UserDetailsForm(
            IUserService userService,
            IBranchService branchService,
            ITrackService trackService,
            User? userToEdit = null)
        {
            _userService = userService;
            _branchService = branchService;
            _trackService = trackService;
            _editingUser = userToEdit;
            _isEditMode = userToEdit != null;

            materialSkinManager = MaterialSkinManager.Instance;
            localizationManager = LocalizationManager.Instance;
            themeManager = ThemeManager.Instance;

            InitializeComponent();
            SetupForm();
        }

        private void InitializeComponent()
        {
            // Initialize all controls
            lblTitle = new MaterialLabel();
            cmbLanguage = new MaterialComboBox();
            btnTheme = new MaterialButton();
            btnSave = new MaterialButton();
            btnCancel = new MaterialButton();
            txtUsername = new MaterialTextBox();
            txtEmail = new MaterialTextBox();
            txtPassword = new MaterialTextBox();
            txtConfirmPassword = new MaterialTextBox();
            cmbRole = new MaterialComboBox();
            cmbBranch = new MaterialComboBox();
            cmbTrack = new MaterialComboBox();
            chkIsActive = new MaterialCheckbox();
            panelMain = new Panel();
            panelTop = new Panel();
            panelContent = new Panel();
            panelForm = new Panel();

            // Configure form
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = _isEditMode ? "Edit User" : "Add User";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

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
            lblTitle.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Text = _isEditMode ? "Edit User" : "Add New User";

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

            // Username
            txtUsername.Hint = "Username";
            txtUsername.Location = new Point(20, 80);
            txtUsername.Size = new Size(250, 50);
            txtUsername.MaxLength = 50;

            // Email
            txtEmail.Hint = "Email";
            txtEmail.Location = new Point(290, 80);
            txtEmail.Size = new Size(250, 50);
            txtEmail.MaxLength = 100;

            // Password
            txtPassword.Hint = "Password";
            txtPassword.Location = new Point(20, 150);
            txtPassword.Size = new Size(250, 50);
            txtPassword.MaxLength = 100;

            // Confirm Password
            txtConfirmPassword.Hint = "Confirm Password";
            txtConfirmPassword.Location = new Point(290, 150);
            txtConfirmPassword.Size = new Size(250, 50);
            txtConfirmPassword.MaxLength = 100;

            // Role
            cmbRole.AutoResize = false;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Location = new Point(20, 220);
            cmbRole.Size = new Size(250, 50);
            cmbRole.Items.AddRange(new[] { "Student", "Instructor", "Admin" });
            cmbRole.SelectedIndex = 0;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;

            // Branch
            cmbBranch.AutoResize = false;
            cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.Location = new Point(290, 220);
            cmbBranch.Size = new Size(250, 50);

            // Track
            cmbTrack.AutoResize = false;
            cmbTrack.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrack.Location = new Point(20, 290);
            cmbTrack.Size = new Size(250, 50);

            // Is Active checkbox
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(20, 360);
            chkIsActive.Text = "Active";
            chkIsActive.Checked = true;

            // Save button
            btnSave.AutoSize = false;
            btnSave.Size = new Size(120, 50);
            btnSave.Location = new Point(300, 600);
            btnSave.Text = "Save";
            btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSave.Click += btnSave_Click;

            // Cancel button
            btnCancel.AutoSize = false;
            btnCancel.Size = new Size(120, 50);
            btnCancel.Location = new Point(440, 600);
            btnCancel.Text = "Cancel";
            btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnCancel.Click += btnCancel_Click;
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
                cmbLanguage, btnTheme
            });

            panelContent.Dock = DockStyle.Fill;
            panelContent.Controls.Add(panelForm);
            panelContent.Controls.Add(lblTitle);

            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(20, 80);
            panelForm.Size = new Size(560, 500);
            panelForm.Controls.AddRange(new Control[] {
                txtUsername, txtEmail, txtPassword, txtConfirmPassword,
                cmbRole, cmbBranch, cmbTrack, chkIsActive,
                btnSave, btnCancel
            });

            // Add controls to form
            this.Controls.Add(panelMain);
        }

        private void SetupForm()
        {
            materialSkinManager.AddFormToManage(this);
            themeManager.ApplyTheme(materialSkinManager);
            LoadBranches();
            LoadTracks();
            LoadUserData();
        }

        private async void LoadBranches()
        {
            try
            {
                var branches = await _branchService.GetAllBranchesAsync();
                cmbBranch.Items.Clear();
                foreach (var branch in branches)
                {
                    cmbBranch.Items.Add(branch.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading branches: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadTracks()
        {
            try
            {
                var tracks = await _trackService.GetAllTracksAsync();
                cmbTrack.Items.Clear();
                foreach (var track in tracks)
                {
                    cmbTrack.Items.Add(track.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tracks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserData()
        {
            if (_isEditMode && _editingUser != null)
            {
                txtUsername.Text = _editingUser.Username;
                txtEmail.Text = _editingUser.Email;
                // TODO: Add IsActive property to User model
                // chkIsActive.Checked = _editingUser.IsActive;

                // Set role
                if (_editingUser is StudentModel)
                    cmbRole.SelectedIndex = 0;
                else if (_editingUser is InstructorModel)
                    cmbRole.SelectedIndex = 1;
                else if (_editingUser is AdminModel)
                    cmbRole.SelectedIndex = 2;

                // Set branch and track for students
                if (_editingUser is StudentModel student)
                {
                    if (student.Branch != null)
                    {
                        var branchIndex = cmbBranch.Items.IndexOf(student.Branch.Name);
                        if (branchIndex >= 0)
                            cmbBranch.SelectedIndex = branchIndex;
                    }

                    if (student.Track != null)
                    {
                        var trackIndex = cmbTrack.Items.IndexOf(student.Track.Name);
                        if (trackIndex >= 0)
                            cmbTrack.SelectedIndex = trackIndex;
                    }
                }
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show/hide branch and track based on role
            bool isStudent = cmbRole.SelectedIndex == 0;
            cmbBranch.Visible = isStudent;
            cmbTrack.Visible = isStudent;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                if (_isEditMode && _editingUser != null)
                {
                    await UpdateUser();
                }
                else
                {
                    await CreateUser();
                }

                MessageBox.Show(_isEditMode ? "User updated successfully" : "User created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_isEditMode && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbRole.SelectedIndex == 0 && (cmbBranch.SelectedIndex < 0 || cmbTrack.SelectedIndex < 0))
            {
                MessageBox.Show("Branch and Track are required for students", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async Task CreateUser()
        {
            var role = (Common.Enums.UserRoleEnum)cmbRole.SelectedIndex;
            var username = txtUsername.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;

            switch (role)
            {
                case Common.Enums.UserRoleEnum.Student:
                    var student = new StudentModel
                    {
                        Username = username,
                        Email = email,
                        // TODO: Add IsActive property to User model
                        // IsActive = chkIsActive.Checked
                    };
                    await _userService.RegisterAsync(student, password);
                    break;

                case Common.Enums.UserRoleEnum.Instructor:
                    var instructor = new InstructorModel
                    {
                        Username = username,
                        Email = email,
                        // TODO: Add IsActive property to User model
                        // IsActive = chkIsActive.Checked
                    };
                    await _userService.RegisterAsync(instructor, password);
                    break;

                case Common.Enums.UserRoleEnum.Admin:
                    var admin = new AdminModel
                    {
                        Username = username,
                        Email = email,
                        // TODO: Add IsActive property to User model
                        // IsActive = chkIsActive.Checked
                    };
                    await _userService.RegisterAsync(admin, password);
                    break;
            }
        }

        private async Task UpdateUser()
        {
            if (_editingUser == null) return;

            _editingUser.Username = txtUsername.Text.Trim();
            _editingUser.Email = txtEmail.Text.Trim();
                // TODO: Add IsActive property to User model
                // _editingUser.IsActive = chkIsActive.Checked;

            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                // TODO: Update password
            }

                // TODO: Implement UpdateAsync method in IUserService
                // await _userService.UpdateAsync(_editingUser);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
