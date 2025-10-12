namespace Legacy_System_UI.Pages.Admin
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            materialTabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            materialTabControl = new MaterialSkin.Controls.MaterialTabControl();
            tabManageAdmins = new TabPage();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabShowAdmins = new TabPage();
            gridAdminsData = new DataGridView();
            btnShowAllAdmins = new MaterialSkin.Controls.MaterialButton();
            btnSearchAdmin = new MaterialSkin.Controls.MaterialButton();
            txtSearchAdmin = new MaterialSkin.Controls.MaterialTextBox();
            radioSearchByEmail = new MaterialSkin.Controls.MaterialRadioButton();
            radioSearchByUsername = new MaterialSkin.Controls.MaterialRadioButton();
            radioSearchById = new MaterialSkin.Controls.MaterialRadioButton();
            tabUpdateAdmin = new TabPage();
            lblFullname = new MaterialSkin.Controls.MaterialLabel();
            txtFullname = new MaterialSkin.Controls.MaterialTextBox();
            lblUsername = new MaterialSkin.Controls.MaterialLabel();
            txtUsername = new MaterialSkin.Controls.MaterialTextBox();
            lblEmail = new MaterialSkin.Controls.MaterialLabel();
            txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            lblPassword = new MaterialSkin.Controls.MaterialLabel();
            txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            btnSubmitUpdate = new MaterialSkin.Controls.MaterialButton();
            gridAdminsForUpdate = new DataGridView();
            tabCreateAdmin = new TabPage();
            lblCreateFullname = new MaterialSkin.Controls.MaterialLabel();
            txtCreateFullname = new MaterialSkin.Controls.MaterialTextBox();
            lblCreateUsername = new MaterialSkin.Controls.MaterialLabel();
            txtCreateUsername = new MaterialSkin.Controls.MaterialTextBox();
            lblCreateEmail = new MaterialSkin.Controls.MaterialLabel();
            txtCreateEmail = new MaterialSkin.Controls.MaterialTextBox();
            lblCreatePassword = new MaterialSkin.Controls.MaterialLabel();
            txtCreatePassword = new MaterialSkin.Controls.MaterialTextBox();
            lblCreateAddress = new MaterialSkin.Controls.MaterialLabel();
            txtCreateAddress = new MaterialSkin.Controls.MaterialTextBox();
            lblCreatePhone = new MaterialSkin.Controls.MaterialLabel();
            txtCreatePhone = new MaterialSkin.Controls.MaterialTextBox();
            lblCreateAge = new MaterialSkin.Controls.MaterialLabel();
            txtCreateAge = new MaterialSkin.Controls.MaterialTextBox();
            lblCreateGender = new MaterialSkin.Controls.MaterialLabel();
            cmbCreateGender = new MaterialSkin.Controls.MaterialComboBox();
            btnCreateAdmin = new MaterialSkin.Controls.MaterialButton();
            tabDeleteAdmin = new TabPage();
            lblSearchDelete = new MaterialSkin.Controls.MaterialLabel();
            txtSearchDelete = new MaterialSkin.Controls.MaterialTextBox();
            btnGetAdminDelete = new MaterialSkin.Controls.MaterialButton();
            radioSearchByID_Delete = new MaterialSkin.Controls.MaterialRadioButton();
            radioSearchByUsername_Delete = new MaterialSkin.Controls.MaterialRadioButton();
            radioSearchByEmail_Delete = new MaterialSkin.Controls.MaterialRadioButton();
            gridAdminsForDelete = new DataGridView();
            lblDelFullname = new MaterialSkin.Controls.MaterialLabel();
            lblDelFullnameValue = new MaterialSkin.Controls.MaterialLabel();
            lblDelUsername = new MaterialSkin.Controls.MaterialLabel();
            lblDelUsernameValue = new MaterialSkin.Controls.MaterialLabel();
            lblDelEmail = new MaterialSkin.Controls.MaterialLabel();
            lblDelEmailValue = new MaterialSkin.Controls.MaterialLabel();
            btnDeleteAdmin = new MaterialSkin.Controls.MaterialButton();
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            tabManageStudents = new TabPage();
            lblStudentsComingSoon = new MaterialSkin.Controls.MaterialLabel();
            tabManageInstructors = new TabPage();
            lblInstructorsComingSoon = new MaterialSkin.Controls.MaterialLabel();
            tabManageBranches = new TabPage();
            lblBranchesComingSoon = new MaterialSkin.Controls.MaterialLabel();
            tabManageTracks = new TabPage();
            lblTracksComingSoon = new MaterialSkin.Controls.MaterialLabel();
            tabManageCourses = new TabPage();
            lblCoursesComingSoon = new MaterialSkin.Controls.MaterialLabel();
            tabExportReports = new TabPage();
            lblReportsComingSoon = new MaterialSkin.Controls.MaterialLabel();
            tabProfile = new TabPage();
            btnLogout = new MaterialSkin.Controls.MaterialButton();
            lblProfileFullname = new MaterialSkin.Controls.MaterialLabel();
            lblProfileUsername = new MaterialSkin.Controls.MaterialLabel();
            lblProfileEmail = new MaterialSkin.Controls.MaterialLabel();
            lblProfileAddress = new MaterialSkin.Controls.MaterialLabel();
            lblProfilePhone = new MaterialSkin.Controls.MaterialLabel();
            lblProfileAge = new MaterialSkin.Controls.MaterialLabel();
            lblProfilePassword = new MaterialSkin.Controls.MaterialLabel();
            lblProfileGender = new MaterialSkin.Controls.MaterialLabel();
            txtProfileFullname = new MaterialSkin.Controls.MaterialTextBox2();
            txtProfileUsername = new MaterialSkin.Controls.MaterialTextBox2();
            txtProfileEmail = new MaterialSkin.Controls.MaterialTextBox2();
            txtProfileAddress = new MaterialSkin.Controls.MaterialTextBox2();
            txtProfilePhone = new MaterialSkin.Controls.MaterialTextBox2();
            txtProfileAge = new MaterialSkin.Controls.MaterialTextBox2();
            txtProfilePassword = new MaterialSkin.Controls.MaterialTextBox2();
            cmbProfileGender = new MaterialSkin.Controls.MaterialComboBox();
            btnUpdateProfile = new MaterialSkin.Controls.MaterialButton();
            ThemeSwitchBtn = new MaterialSkin.Controls.MaterialSwitch();
            cmbLanguage = new MaterialSkin.Controls.MaterialComboBox();
            materialTabControl.SuspendLayout();
            tabManageAdmins.SuspendLayout();
            materialTabControl1.SuspendLayout();
            tabShowAdmins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAdminsData).BeginInit();
            tabUpdateAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAdminsForUpdate).BeginInit();
            tabCreateAdmin.SuspendLayout();
            tabDeleteAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAdminsForDelete).BeginInit();
            tabManageStudents.SuspendLayout();
            tabManageInstructors.SuspendLayout();
            tabManageBranches.SuspendLayout();
            tabManageTracks.SuspendLayout();
            tabManageCourses.SuspendLayout();
            tabExportReports.SuspendLayout();
            tabProfile.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabSelector
            // 
            materialTabSelector.BaseTabControl = materialTabControl;
            materialTabSelector.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            materialTabSelector.Depth = 0;
            materialTabSelector.Dock = DockStyle.Top;
            materialTabSelector.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector.Location = new Point(3, 64);
            materialTabSelector.Margin = new Padding(0);
            materialTabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabSelector.Name = "materialTabSelector";
            materialTabSelector.Size = new Size(1496, 30);
            materialTabSelector.TabIndex = 0;
            // 
            // materialTabControl
            // 
            materialTabControl.Controls.Add(tabManageAdmins);
            materialTabControl.Controls.Add(tabManageStudents);
            materialTabControl.Controls.Add(tabManageInstructors);
            materialTabControl.Controls.Add(tabManageBranches);
            materialTabControl.Controls.Add(tabManageTracks);
            materialTabControl.Controls.Add(tabManageCourses);
            materialTabControl.Controls.Add(tabExportReports);
            materialTabControl.Controls.Add(tabProfile);
            materialTabControl.Depth = 0;
            materialTabControl.ItemSize = new Size(60, 25);
            materialTabControl.Location = new Point(3, 96);
            materialTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl.Multiline = true;
            materialTabControl.Name = "materialTabControl";
            materialTabControl.SelectedIndex = 0;
            materialTabControl.Size = new Size(1480, 603);
            materialTabControl.TabIndex = 1;
            // 
            // tabManageAdmins
            // 
            tabManageAdmins.BackColor = Color.White;
            tabManageAdmins.Controls.Add(materialTabControl1);
            tabManageAdmins.Controls.Add(materialTabSelector1);
            tabManageAdmins.Location = new Point(4, 29);
            tabManageAdmins.Name = "tabManageAdmins";
            tabManageAdmins.Padding = new Padding(3);
            tabManageAdmins.Size = new Size(1472, 570);
            tabManageAdmins.TabIndex = 0;
            tabManageAdmins.Text = "Manage Admins";
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabShowAdmins);
            materialTabControl1.Controls.Add(tabUpdateAdmin);
            materialTabControl1.Controls.Add(tabCreateAdmin);
            materialTabControl1.Controls.Add(tabDeleteAdmin);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(3, 39);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1466, 528);
            materialTabControl1.TabIndex = 0;
            // 
            // tabShowAdmins
            // 
            tabShowAdmins.BackColor = Color.White;
            tabShowAdmins.Controls.Add(gridAdminsData);
            tabShowAdmins.Controls.Add(btnShowAllAdmins);
            tabShowAdmins.Controls.Add(btnSearchAdmin);
            tabShowAdmins.Controls.Add(txtSearchAdmin);
            tabShowAdmins.Controls.Add(radioSearchByEmail);
            tabShowAdmins.Controls.Add(radioSearchByUsername);
            tabShowAdmins.Controls.Add(radioSearchById);
            tabShowAdmins.Location = new Point(4, 29);
            tabShowAdmins.Name = "tabShowAdmins";
            tabShowAdmins.Padding = new Padding(3);
            tabShowAdmins.Size = new Size(1458, 495);
            tabShowAdmins.TabIndex = 0;
            tabShowAdmins.Text = "Show Admins Data";
            // 
            // gridAdminsData
            // 
            gridAdminsData.AllowUserToAddRows = false;
            gridAdminsData.AllowUserToDeleteRows = false;
            gridAdminsData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridAdminsData.BackgroundColor = Color.WhiteSmoke;
            gridAdminsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAdminsData.Location = new Point(40, 150);
            gridAdminsData.Name = "gridAdminsData";
            gridAdminsData.ReadOnly = true;
            gridAdminsData.RowHeadersVisible = false;
            gridAdminsData.RowHeadersWidth = 51;
            gridAdminsData.Size = new Size(1300, 320);
            gridAdminsData.TabIndex = 6;
            // 
            // btnShowAllAdmins
            // 
            btnShowAllAdmins.AutoSize = false;
            btnShowAllAdmins.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnShowAllAdmins.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnShowAllAdmins.Depth = 0;
            btnShowAllAdmins.HighEmphasis = true;
            btnShowAllAdmins.Icon = null;
            btnShowAllAdmins.Location = new Point(600, 35);
            btnShowAllAdmins.Margin = new Padding(4, 6, 4, 6);
            btnShowAllAdmins.MouseState = MaterialSkin.MouseState.HOVER;
            btnShowAllAdmins.Name = "btnShowAllAdmins";
            btnShowAllAdmins.NoAccentTextColor = Color.Empty;
            btnShowAllAdmins.Size = new Size(150, 40);
            btnShowAllAdmins.TabIndex = 2;
            btnShowAllAdmins.Text = "Show All";
            btnShowAllAdmins.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnShowAllAdmins.UseAccentColor = false;
            btnShowAllAdmins.UseVisualStyleBackColor = true;
            btnShowAllAdmins.Click += btnShowAllAdmins_Click;
            // 
            // btnSearchAdmin
            // 
            btnSearchAdmin.AutoSize = false;
            btnSearchAdmin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSearchAdmin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSearchAdmin.Depth = 0;
            btnSearchAdmin.HighEmphasis = true;
            btnSearchAdmin.Icon = null;
            btnSearchAdmin.Location = new Point(460, 35);
            btnSearchAdmin.Margin = new Padding(4, 6, 4, 6);
            btnSearchAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            btnSearchAdmin.Name = "btnSearchAdmin";
            btnSearchAdmin.NoAccentTextColor = Color.Empty;
            btnSearchAdmin.Size = new Size(120, 40);
            btnSearchAdmin.TabIndex = 1;
            btnSearchAdmin.Text = "Search";
            btnSearchAdmin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSearchAdmin.UseAccentColor = false;
            btnSearchAdmin.UseVisualStyleBackColor = true;
            btnSearchAdmin.Click += btnSearchAdmin_Click;
            // 
            // txtSearchAdmin
            // 
            txtSearchAdmin.AnimateReadOnly = false;
            txtSearchAdmin.BorderStyle = BorderStyle.None;
            txtSearchAdmin.Depth = 0;
            txtSearchAdmin.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSearchAdmin.Hint = "Search Admin...";
            txtSearchAdmin.LeadingIcon = null;
            txtSearchAdmin.Location = new Point(40, 30);
            txtSearchAdmin.MaxLength = 50;
            txtSearchAdmin.MouseState = MaterialSkin.MouseState.OUT;
            txtSearchAdmin.Multiline = false;
            txtSearchAdmin.Name = "txtSearchAdmin";
            txtSearchAdmin.Size = new Size(400, 50);
            txtSearchAdmin.TabIndex = 0;
            txtSearchAdmin.Text = "";
            txtSearchAdmin.TrailingIcon = null;
            // 
            // radioSearchByEmail
            // 
            radioSearchByEmail.AutoSize = true;
            radioSearchByEmail.Depth = 0;
            radioSearchByEmail.Location = new Point(250, 95);
            radioSearchByEmail.Margin = new Padding(0);
            radioSearchByEmail.MouseLocation = new Point(-1, -1);
            radioSearchByEmail.MouseState = MaterialSkin.MouseState.HOVER;
            radioSearchByEmail.Name = "radioSearchByEmail";
            radioSearchByEmail.Ripple = true;
            radioSearchByEmail.Size = new Size(75, 37);
            radioSearchByEmail.TabIndex = 5;
            radioSearchByEmail.TabStop = true;
            radioSearchByEmail.Text = "Email";
            radioSearchByEmail.UseVisualStyleBackColor = true;
            // 
            // radioSearchByUsername
            // 
            radioSearchByUsername.AutoSize = true;
            radioSearchByUsername.Depth = 0;
            radioSearchByUsername.Location = new Point(110, 95);
            radioSearchByUsername.Margin = new Padding(0);
            radioSearchByUsername.MouseLocation = new Point(-1, -1);
            radioSearchByUsername.MouseState = MaterialSkin.MouseState.HOVER;
            radioSearchByUsername.Name = "radioSearchByUsername";
            radioSearchByUsername.Ripple = true;
            radioSearchByUsername.Size = new Size(106, 37);
            radioSearchByUsername.TabIndex = 4;
            radioSearchByUsername.TabStop = true;
            radioSearchByUsername.Text = "Username";
            radioSearchByUsername.UseVisualStyleBackColor = true;
            // 
            // radioSearchById
            // 
            radioSearchById.AutoSize = true;
            radioSearchById.Depth = 0;
            radioSearchById.Location = new Point(40, 95);
            radioSearchById.Margin = new Padding(0);
            radioSearchById.MouseLocation = new Point(-1, -1);
            radioSearchById.MouseState = MaterialSkin.MouseState.HOVER;
            radioSearchById.Name = "radioSearchById";
            radioSearchById.Ripple = true;
            radioSearchById.Size = new Size(50, 37);
            radioSearchById.TabIndex = 3;
            radioSearchById.TabStop = true;
            radioSearchById.Text = "ID";
            radioSearchById.UseVisualStyleBackColor = true;
            // 
            // tabUpdateAdmin
            // 
            tabUpdateAdmin.BackColor = Color.White;
            tabUpdateAdmin.Controls.Add(lblFullname);
            tabUpdateAdmin.Controls.Add(txtFullname);
            tabUpdateAdmin.Controls.Add(lblUsername);
            tabUpdateAdmin.Controls.Add(txtUsername);
            tabUpdateAdmin.Controls.Add(lblEmail);
            tabUpdateAdmin.Controls.Add(txtEmail);
            tabUpdateAdmin.Controls.Add(lblPassword);
            tabUpdateAdmin.Controls.Add(txtPassword);
            tabUpdateAdmin.Controls.Add(btnSubmitUpdate);
            tabUpdateAdmin.Controls.Add(gridAdminsForUpdate);
            tabUpdateAdmin.Location = new Point(4, 29);
            tabUpdateAdmin.Name = "tabUpdateAdmin";
            tabUpdateAdmin.Padding = new Padding(3);
            tabUpdateAdmin.Size = new Size(1380, 495);
            tabUpdateAdmin.TabIndex = 1;
            tabUpdateAdmin.Text = "Update Admin Data";
            tabUpdateAdmin.UseVisualStyleBackColor = true;
            // 
            // lblFullname
            // 
            lblFullname.AutoSize = true;
            lblFullname.Depth = 0;
            lblFullname.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFullname.Location = new Point(60, 50);
            lblFullname.MouseState = MaterialSkin.MouseState.HOVER;
            lblFullname.Name = "lblFullname";
            lblFullname.Size = new Size(77, 19);
            lblFullname.TabIndex = 0;
            lblFullname.Text = "Full Name:";
            // 
            // txtFullname
            // 
            txtFullname.AnimateReadOnly = false;
            txtFullname.BorderStyle = BorderStyle.None;
            txtFullname.Depth = 0;
            txtFullname.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFullname.Hint = "Full name";
            txtFullname.LeadingIcon = null;
            txtFullname.Location = new Point(180, 40);
            txtFullname.MaxLength = 50;
            txtFullname.MouseState = MaterialSkin.MouseState.OUT;
            txtFullname.Multiline = false;
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(500, 50);
            txtFullname.TabIndex = 1;
            txtFullname.Text = "";
            txtFullname.TrailingIcon = null;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Depth = 0;
            lblUsername.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUsername.Location = new Point(60, 120);
            lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(76, 19);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.AnimateReadOnly = false;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Depth = 0;
            txtUsername.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUsername.Hint = "Username";
            txtUsername.LeadingIcon = null;
            txtUsername.Location = new Point(180, 110);
            txtUsername.MaxLength = 50;
            txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            txtUsername.Multiline = false;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(500, 50);
            txtUsername.TabIndex = 3;
            txtUsername.Text = "";
            txtUsername.TrailingIcon = null;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Depth = 0;
            lblEmail.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEmail.Location = new Point(60, 190);
            lblEmail.MouseState = MaterialSkin.MouseState.HOVER;
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(45, 19);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.Hint = "Email address";
            txtEmail.LeadingIcon = null;
            txtEmail.Location = new Point(180, 180);
            txtEmail.MaxLength = 50;
            txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(500, 50);
            txtEmail.TabIndex = 5;
            txtEmail.Text = "";
            txtEmail.TrailingIcon = null;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Depth = 0;
            lblPassword.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPassword.Location = new Point(60, 260);
            lblPassword.MouseState = MaterialSkin.MouseState.HOVER;
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(75, 19);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.AnimateReadOnly = false;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Depth = 0;
            txtPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPassword.Hint = "New password (optional)";
            txtPassword.LeadingIcon = null;
            txtPassword.Location = new Point(180, 250);
            txtPassword.MaxLength = 50;
            txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Password = true;
            txtPassword.Size = new Size(500, 50);
            txtPassword.TabIndex = 7;
            txtPassword.Text = "";
            txtPassword.TrailingIcon = null;
            // 
            // btnSubmitUpdate
            // 
            btnSubmitUpdate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSubmitUpdate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSubmitUpdate.Depth = 0;
            btnSubmitUpdate.HighEmphasis = true;
            btnSubmitUpdate.Icon = null;
            btnSubmitUpdate.Location = new Point(180, 330);
            btnSubmitUpdate.Margin = new Padding(4, 6, 4, 6);
            btnSubmitUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            btnSubmitUpdate.Name = "btnSubmitUpdate";
            btnSubmitUpdate.NoAccentTextColor = Color.Empty;
            btnSubmitUpdate.Size = new Size(128, 36);
            btnSubmitUpdate.TabIndex = 8;
            btnSubmitUpdate.Text = "Update Admin";
            btnSubmitUpdate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSubmitUpdate.UseAccentColor = true;
            // 
            // gridAdminsForUpdate
            // 
            gridAdminsForUpdate.AllowUserToAddRows = false;
            gridAdminsForUpdate.AllowUserToDeleteRows = false;
            gridAdminsForUpdate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridAdminsForUpdate.BackgroundColor = Color.WhiteSmoke;
            gridAdminsForUpdate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAdminsForUpdate.Location = new Point(850, 30);
            gridAdminsForUpdate.Name = "gridAdminsForUpdate";
            gridAdminsForUpdate.ReadOnly = true;
            gridAdminsForUpdate.RowHeadersVisible = false;
            gridAdminsForUpdate.RowHeadersWidth = 51;
            gridAdminsForUpdate.Size = new Size(500, 430);
            gridAdminsForUpdate.TabIndex = 0;
            // 
            // tabCreateAdmin
            // 
            tabCreateAdmin.BackColor = Color.White;
            tabCreateAdmin.Controls.Add(lblCreateFullname);
            tabCreateAdmin.Controls.Add(txtCreateFullname);
            tabCreateAdmin.Controls.Add(lblCreateUsername);
            tabCreateAdmin.Controls.Add(txtCreateUsername);
            tabCreateAdmin.Controls.Add(lblCreateEmail);
            tabCreateAdmin.Controls.Add(txtCreateEmail);
            tabCreateAdmin.Controls.Add(lblCreatePassword);
            tabCreateAdmin.Controls.Add(txtCreatePassword);
            tabCreateAdmin.Controls.Add(lblCreateAddress);
            tabCreateAdmin.Controls.Add(txtCreateAddress);
            tabCreateAdmin.Controls.Add(lblCreatePhone);
            tabCreateAdmin.Controls.Add(txtCreatePhone);
            tabCreateAdmin.Controls.Add(lblCreateAge);
            tabCreateAdmin.Controls.Add(txtCreateAge);
            tabCreateAdmin.Controls.Add(lblCreateGender);
            tabCreateAdmin.Controls.Add(cmbCreateGender);
            tabCreateAdmin.Controls.Add(btnCreateAdmin);
            tabCreateAdmin.Location = new Point(4, 29);
            tabCreateAdmin.Name = "tabCreateAdmin";
            tabCreateAdmin.Padding = new Padding(3);
            tabCreateAdmin.Size = new Size(1380, 495);
            tabCreateAdmin.TabIndex = 2;
            tabCreateAdmin.Text = "Create New Admin";
            tabCreateAdmin.UseVisualStyleBackColor = true;
            // 
            // lblCreateFullname
            // 
            lblCreateFullname.AutoSize = true;
            lblCreateFullname.Depth = 0;
            lblCreateFullname.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCreateFullname.Location = new Point(100, 50);
            lblCreateFullname.MouseState = MaterialSkin.MouseState.HOVER;
            lblCreateFullname.Name = "lblCreateFullname";
            lblCreateFullname.Size = new Size(77, 19);
            lblCreateFullname.TabIndex = 0;
            lblCreateFullname.Text = "Full Name:";
            // 
            // txtCreateFullname
            // 
            txtCreateFullname.AnimateReadOnly = false;
            txtCreateFullname.BorderStyle = BorderStyle.None;
            txtCreateFullname.Depth = 0;
            txtCreateFullname.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCreateFullname.Hint = "Enter full name";
            txtCreateFullname.LeadingIcon = null;
            txtCreateFullname.Location = new Point(250, 40);
            txtCreateFullname.MaxLength = 50;
            txtCreateFullname.MouseState = MaterialSkin.MouseState.OUT;
            txtCreateFullname.Multiline = false;
            txtCreateFullname.Name = "txtCreateFullname";
            txtCreateFullname.Size = new Size(450, 50);
            txtCreateFullname.TabIndex = 1;
            txtCreateFullname.Text = "";
            txtCreateFullname.TrailingIcon = null;
            // 
            // lblCreateUsername
            // 
            lblCreateUsername.AutoSize = true;
            lblCreateUsername.Depth = 0;
            lblCreateUsername.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCreateUsername.Location = new Point(100, 110);
            lblCreateUsername.MouseState = MaterialSkin.MouseState.HOVER;
            lblCreateUsername.Name = "lblCreateUsername";
            lblCreateUsername.Size = new Size(76, 19);
            lblCreateUsername.TabIndex = 2;
            lblCreateUsername.Text = "Username:";
            // 
            // txtCreateUsername
            // 
            txtCreateUsername.AnimateReadOnly = false;
            txtCreateUsername.BorderStyle = BorderStyle.None;
            txtCreateUsername.Depth = 0;
            txtCreateUsername.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCreateUsername.Hint = "Enter username";
            txtCreateUsername.LeadingIcon = null;
            txtCreateUsername.Location = new Point(250, 100);
            txtCreateUsername.MaxLength = 50;
            txtCreateUsername.MouseState = MaterialSkin.MouseState.OUT;
            txtCreateUsername.Multiline = false;
            txtCreateUsername.Name = "txtCreateUsername";
            txtCreateUsername.Size = new Size(450, 50);
            txtCreateUsername.TabIndex = 3;
            txtCreateUsername.Text = "";
            txtCreateUsername.TrailingIcon = null;
            // 
            // lblCreateEmail
            // 
            lblCreateEmail.AutoSize = true;
            lblCreateEmail.Depth = 0;
            lblCreateEmail.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCreateEmail.Location = new Point(100, 170);
            lblCreateEmail.MouseState = MaterialSkin.MouseState.HOVER;
            lblCreateEmail.Name = "lblCreateEmail";
            lblCreateEmail.Size = new Size(45, 19);
            lblCreateEmail.TabIndex = 4;
            lblCreateEmail.Text = "Email:";
            // 
            // txtCreateEmail
            // 
            txtCreateEmail.AnimateReadOnly = false;
            txtCreateEmail.BorderStyle = BorderStyle.None;
            txtCreateEmail.Depth = 0;
            txtCreateEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCreateEmail.Hint = "Enter email address";
            txtCreateEmail.LeadingIcon = null;
            txtCreateEmail.Location = new Point(250, 160);
            txtCreateEmail.MaxLength = 50;
            txtCreateEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtCreateEmail.Multiline = false;
            txtCreateEmail.Name = "txtCreateEmail";
            txtCreateEmail.Size = new Size(450, 50);
            txtCreateEmail.TabIndex = 5;
            txtCreateEmail.Text = "";
            txtCreateEmail.TrailingIcon = null;
            // 
            // lblCreatePassword
            // 
            lblCreatePassword.AutoSize = true;
            lblCreatePassword.Depth = 0;
            lblCreatePassword.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCreatePassword.Location = new Point(100, 230);
            lblCreatePassword.MouseState = MaterialSkin.MouseState.HOVER;
            lblCreatePassword.Name = "lblCreatePassword";
            lblCreatePassword.Size = new Size(75, 19);
            lblCreatePassword.TabIndex = 6;
            lblCreatePassword.Text = "Password:";
            // 
            // txtCreatePassword
            // 
            txtCreatePassword.AnimateReadOnly = false;
            txtCreatePassword.BorderStyle = BorderStyle.None;
            txtCreatePassword.Depth = 0;
            txtCreatePassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCreatePassword.Hint = "Enter password";
            txtCreatePassword.LeadingIcon = null;
            txtCreatePassword.Location = new Point(250, 220);
            txtCreatePassword.MaxLength = 50;
            txtCreatePassword.MouseState = MaterialSkin.MouseState.OUT;
            txtCreatePassword.Multiline = false;
            txtCreatePassword.Name = "txtCreatePassword";
            txtCreatePassword.Password = true;
            txtCreatePassword.Size = new Size(450, 50);
            txtCreatePassword.TabIndex = 7;
            txtCreatePassword.Text = "";
            txtCreatePassword.TrailingIcon = null;
            // 
            // lblCreateAddress
            // 
            lblCreateAddress.AutoSize = true;
            lblCreateAddress.Depth = 0;
            lblCreateAddress.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCreateAddress.Location = new Point(100, 290);
            lblCreateAddress.MouseState = MaterialSkin.MouseState.HOVER;
            lblCreateAddress.Name = "lblCreateAddress";
            lblCreateAddress.Size = new Size(62, 19);
            lblCreateAddress.TabIndex = 8;
            lblCreateAddress.Text = "Address:";
            // 
            // txtCreateAddress
            // 
            txtCreateAddress.AnimateReadOnly = false;
            txtCreateAddress.BorderStyle = BorderStyle.None;
            txtCreateAddress.Depth = 0;
            txtCreateAddress.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCreateAddress.Hint = "Enter address";
            txtCreateAddress.LeadingIcon = null;
            txtCreateAddress.Location = new Point(250, 280);
            txtCreateAddress.MaxLength = 50;
            txtCreateAddress.MouseState = MaterialSkin.MouseState.OUT;
            txtCreateAddress.Multiline = false;
            txtCreateAddress.Name = "txtCreateAddress";
            txtCreateAddress.Size = new Size(450, 50);
            txtCreateAddress.TabIndex = 9;
            txtCreateAddress.Text = "";
            txtCreateAddress.TrailingIcon = null;
            // 
            // lblCreatePhone
            // 
            lblCreatePhone.AutoSize = true;
            lblCreatePhone.Depth = 0;
            lblCreatePhone.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCreatePhone.Location = new Point(100, 350);
            lblCreatePhone.MouseState = MaterialSkin.MouseState.HOVER;
            lblCreatePhone.Name = "lblCreatePhone";
            lblCreatePhone.Size = new Size(50, 19);
            lblCreatePhone.TabIndex = 10;
            lblCreatePhone.Text = "Phone:";
            // 
            // txtCreatePhone
            // 
            txtCreatePhone.AnimateReadOnly = false;
            txtCreatePhone.BorderStyle = BorderStyle.None;
            txtCreatePhone.Depth = 0;
            txtCreatePhone.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCreatePhone.Hint = "Enter phone number";
            txtCreatePhone.LeadingIcon = null;
            txtCreatePhone.Location = new Point(250, 340);
            txtCreatePhone.MaxLength = 50;
            txtCreatePhone.MouseState = MaterialSkin.MouseState.OUT;
            txtCreatePhone.Multiline = false;
            txtCreatePhone.Name = "txtCreatePhone";
            txtCreatePhone.Size = new Size(450, 50);
            txtCreatePhone.TabIndex = 11;
            txtCreatePhone.Text = "";
            txtCreatePhone.TrailingIcon = null;
            // 
            // lblCreateAge
            // 
            lblCreateAge.AutoSize = true;
            lblCreateAge.Depth = 0;
            lblCreateAge.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCreateAge.Location = new Point(100, 410);
            lblCreateAge.MouseState = MaterialSkin.MouseState.HOVER;
            lblCreateAge.Name = "lblCreateAge";
            lblCreateAge.Size = new Size(32, 19);
            lblCreateAge.TabIndex = 12;
            lblCreateAge.Text = "Age:";
            // 
            // txtCreateAge
            // 
            txtCreateAge.AnimateReadOnly = false;
            txtCreateAge.BorderStyle = BorderStyle.None;
            txtCreateAge.Depth = 0;
            txtCreateAge.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCreateAge.Hint = "Enter age";
            txtCreateAge.LeadingIcon = null;
            txtCreateAge.Location = new Point(250, 400);
            txtCreateAge.MaxLength = 50;
            txtCreateAge.MouseState = MaterialSkin.MouseState.OUT;
            txtCreateAge.Multiline = false;
            txtCreateAge.Name = "txtCreateAge";
            txtCreateAge.Size = new Size(200, 50);
            txtCreateAge.TabIndex = 13;
            txtCreateAge.Text = "";
            txtCreateAge.TrailingIcon = null;
            // 
            // lblCreateGender
            // 
            lblCreateGender.AutoSize = true;
            lblCreateGender.Depth = 0;
            lblCreateGender.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCreateGender.Location = new Point(500, 410);
            lblCreateGender.MouseState = MaterialSkin.MouseState.HOVER;
            lblCreateGender.Name = "lblCreateGender";
            lblCreateGender.Size = new Size(55, 19);
            lblCreateGender.TabIndex = 14;
            lblCreateGender.Text = "Gender:";
            // 
            // cmbCreateGender
            // 
            cmbCreateGender.AutoResize = false;
            cmbCreateGender.BackColor = Color.FromArgb(255, 255, 255);
            cmbCreateGender.Depth = 0;
            cmbCreateGender.DrawMode = DrawMode.OwnerDrawVariable;
            cmbCreateGender.DropDownHeight = 174;
            cmbCreateGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCreateGender.DropDownWidth = 121;
            cmbCreateGender.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbCreateGender.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbCreateGender.FormattingEnabled = true;
            cmbCreateGender.IntegralHeight = false;
            cmbCreateGender.ItemHeight = 43;
            cmbCreateGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbCreateGender.Location = new Point(580, 400);
            cmbCreateGender.MaxDropDownItems = 4;
            cmbCreateGender.MouseState = MaterialSkin.MouseState.OUT;
            cmbCreateGender.Name = "cmbCreateGender";
            cmbCreateGender.Size = new Size(120, 49);
            cmbCreateGender.StartIndex = 0;
            cmbCreateGender.TabIndex = 15;
            // 
            // btnCreateAdmin
            // 
            btnCreateAdmin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCreateAdmin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCreateAdmin.Depth = 0;
            btnCreateAdmin.HighEmphasis = true;
            btnCreateAdmin.Icon = null;
            btnCreateAdmin.Location = new Point(250, 460);
            btnCreateAdmin.Margin = new Padding(4, 6, 4, 6);
            btnCreateAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            btnCreateAdmin.Name = "btnCreateAdmin";
            btnCreateAdmin.NoAccentTextColor = Color.Empty;
            btnCreateAdmin.Size = new Size(126, 36);
            btnCreateAdmin.TabIndex = 16;
            btnCreateAdmin.Text = "Create Admin";
            btnCreateAdmin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCreateAdmin.UseAccentColor = true;
            // 
            // tabDeleteAdmin
            // 
            tabDeleteAdmin.BackColor = Color.White;
            tabDeleteAdmin.Controls.Add(lblSearchDelete);
            tabDeleteAdmin.Controls.Add(txtSearchDelete);
            tabDeleteAdmin.Controls.Add(btnGetAdminDelete);
            tabDeleteAdmin.Controls.Add(radioSearchByID_Delete);
            tabDeleteAdmin.Controls.Add(radioSearchByUsername_Delete);
            tabDeleteAdmin.Controls.Add(radioSearchByEmail_Delete);
            tabDeleteAdmin.Controls.Add(gridAdminsForDelete);
            tabDeleteAdmin.Controls.Add(lblDelFullname);
            tabDeleteAdmin.Controls.Add(lblDelFullnameValue);
            tabDeleteAdmin.Controls.Add(lblDelUsername);
            tabDeleteAdmin.Controls.Add(lblDelUsernameValue);
            tabDeleteAdmin.Controls.Add(lblDelEmail);
            tabDeleteAdmin.Controls.Add(lblDelEmailValue);
            tabDeleteAdmin.Controls.Add(btnDeleteAdmin);
            tabDeleteAdmin.Location = new Point(4, 29);
            tabDeleteAdmin.Name = "tabDeleteAdmin";
            tabDeleteAdmin.Padding = new Padding(3);
            tabDeleteAdmin.Size = new Size(1380, 495);
            tabDeleteAdmin.TabIndex = 3;
            tabDeleteAdmin.Text = "Delete Admin";
            tabDeleteAdmin.UseVisualStyleBackColor = true;
            // 
            // lblSearchDelete
            // 
            lblSearchDelete.AutoSize = true;
            lblSearchDelete.Depth = 0;
            lblSearchDelete.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSearchDelete.Location = new Point(40, 30);
            lblSearchDelete.MouseState = MaterialSkin.MouseState.HOVER;
            lblSearchDelete.Name = "lblSearchDelete";
            lblSearchDelete.Size = new Size(104, 19);
            lblSearchDelete.TabIndex = 0;
            lblSearchDelete.Text = "Search Admin:";
            // 
            // txtSearchDelete
            // 
            txtSearchDelete.AnimateReadOnly = false;
            txtSearchDelete.BorderStyle = BorderStyle.None;
            txtSearchDelete.Depth = 0;
            txtSearchDelete.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSearchDelete.Hint = "Enter ID, Username, or Email";
            txtSearchDelete.LeadingIcon = null;
            txtSearchDelete.Location = new Point(170, 20);
            txtSearchDelete.MaxLength = 50;
            txtSearchDelete.MouseState = MaterialSkin.MouseState.OUT;
            txtSearchDelete.Multiline = false;
            txtSearchDelete.Name = "txtSearchDelete";
            txtSearchDelete.Size = new Size(400, 50);
            txtSearchDelete.TabIndex = 1;
            txtSearchDelete.Text = "";
            txtSearchDelete.TrailingIcon = null;
            // 
            // btnGetAdminDelete
            // 
            btnGetAdminDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGetAdminDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGetAdminDelete.Depth = 0;
            btnGetAdminDelete.HighEmphasis = true;
            btnGetAdminDelete.Icon = null;
            btnGetAdminDelete.Location = new Point(590, 30);
            btnGetAdminDelete.Margin = new Padding(4, 6, 4, 6);
            btnGetAdminDelete.MouseState = MaterialSkin.MouseState.HOVER;
            btnGetAdminDelete.Name = "btnGetAdminDelete";
            btnGetAdminDelete.NoAccentTextColor = Color.Empty;
            btnGetAdminDelete.Size = new Size(64, 36);
            btnGetAdminDelete.TabIndex = 2;
            btnGetAdminDelete.Text = "Get";
            btnGetAdminDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGetAdminDelete.UseAccentColor = true;
            // 
            // radioSearchByID_Delete
            // 
            radioSearchByID_Delete.AutoSize = true;
            radioSearchByID_Delete.Depth = 0;
            radioSearchByID_Delete.Location = new Point(720, 30);
            radioSearchByID_Delete.Margin = new Padding(0);
            radioSearchByID_Delete.MouseLocation = new Point(-1, -1);
            radioSearchByID_Delete.MouseState = MaterialSkin.MouseState.HOVER;
            radioSearchByID_Delete.Name = "radioSearchByID_Delete";
            radioSearchByID_Delete.Ripple = true;
            radioSearchByID_Delete.Size = new Size(72, 37);
            radioSearchByID_Delete.TabIndex = 3;
            radioSearchByID_Delete.Text = "By ID";
            // 
            // radioSearchByUsername_Delete
            // 
            radioSearchByUsername_Delete.AutoSize = true;
            radioSearchByUsername_Delete.Depth = 0;
            radioSearchByUsername_Delete.Location = new Point(800, 30);
            radioSearchByUsername_Delete.Margin = new Padding(0);
            radioSearchByUsername_Delete.MouseLocation = new Point(-1, -1);
            radioSearchByUsername_Delete.MouseState = MaterialSkin.MouseState.HOVER;
            radioSearchByUsername_Delete.Name = "radioSearchByUsername_Delete";
            radioSearchByUsername_Delete.Ripple = true;
            radioSearchByUsername_Delete.Size = new Size(128, 37);
            radioSearchByUsername_Delete.TabIndex = 4;
            radioSearchByUsername_Delete.Text = "By Username";
            // 
            // radioSearchByEmail_Delete
            // 
            radioSearchByEmail_Delete.AutoSize = true;
            radioSearchByEmail_Delete.Depth = 0;
            radioSearchByEmail_Delete.Location = new Point(950, 30);
            radioSearchByEmail_Delete.Margin = new Padding(0);
            radioSearchByEmail_Delete.MouseLocation = new Point(-1, -1);
            radioSearchByEmail_Delete.MouseState = MaterialSkin.MouseState.HOVER;
            radioSearchByEmail_Delete.Name = "radioSearchByEmail_Delete";
            radioSearchByEmail_Delete.Ripple = true;
            radioSearchByEmail_Delete.Size = new Size(97, 37);
            radioSearchByEmail_Delete.TabIndex = 5;
            radioSearchByEmail_Delete.Text = "By Email";
            // 
            // gridAdminsForDelete
            // 
            gridAdminsForDelete.AllowUserToAddRows = false;
            gridAdminsForDelete.AllowUserToDeleteRows = false;
            gridAdminsForDelete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridAdminsForDelete.BackgroundColor = Color.WhiteSmoke;
            gridAdminsForDelete.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAdminsForDelete.Location = new Point(850, 100);
            gridAdminsForDelete.Name = "gridAdminsForDelete";
            gridAdminsForDelete.ReadOnly = true;
            gridAdminsForDelete.RowHeadersVisible = false;
            gridAdminsForDelete.RowHeadersWidth = 51;
            gridAdminsForDelete.Size = new Size(500, 360);
            gridAdminsForDelete.TabIndex = 0;
            // 
            // lblDelFullname
            // 
            lblDelFullname.AutoSize = true;
            lblDelFullname.Depth = 0;
            lblDelFullname.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDelFullname.Location = new Point(60, 140);
            lblDelFullname.MouseState = MaterialSkin.MouseState.HOVER;
            lblDelFullname.Name = "lblDelFullname";
            lblDelFullname.Size = new Size(77, 19);
            lblDelFullname.TabIndex = 6;
            lblDelFullname.Text = "Full Name:";
            // 
            // lblDelFullnameValue
            // 
            lblDelFullnameValue.AutoSize = true;
            lblDelFullnameValue.Depth = 0;
            lblDelFullnameValue.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDelFullnameValue.Location = new Point(180, 140);
            lblDelFullnameValue.MouseState = MaterialSkin.MouseState.HOVER;
            lblDelFullnameValue.Name = "lblDelFullnameValue";
            lblDelFullnameValue.Size = new Size(5, 19);
            lblDelFullnameValue.TabIndex = 7;
            lblDelFullnameValue.Text = "-";
            // 
            // lblDelUsername
            // 
            lblDelUsername.AutoSize = true;
            lblDelUsername.Depth = 0;
            lblDelUsername.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDelUsername.Location = new Point(60, 200);
            lblDelUsername.MouseState = MaterialSkin.MouseState.HOVER;
            lblDelUsername.Name = "lblDelUsername";
            lblDelUsername.Size = new Size(76, 19);
            lblDelUsername.TabIndex = 8;
            lblDelUsername.Text = "Username:";
            // 
            // lblDelUsernameValue
            // 
            lblDelUsernameValue.AutoSize = true;
            lblDelUsernameValue.Depth = 0;
            lblDelUsernameValue.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDelUsernameValue.Location = new Point(180, 200);
            lblDelUsernameValue.MouseState = MaterialSkin.MouseState.HOVER;
            lblDelUsernameValue.Name = "lblDelUsernameValue";
            lblDelUsernameValue.Size = new Size(5, 19);
            lblDelUsernameValue.TabIndex = 9;
            lblDelUsernameValue.Text = "-";
            // 
            // lblDelEmail
            // 
            lblDelEmail.AutoSize = true;
            lblDelEmail.Depth = 0;
            lblDelEmail.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDelEmail.Location = new Point(60, 260);
            lblDelEmail.MouseState = MaterialSkin.MouseState.HOVER;
            lblDelEmail.Name = "lblDelEmail";
            lblDelEmail.Size = new Size(45, 19);
            lblDelEmail.TabIndex = 10;
            lblDelEmail.Text = "Email:";
            // 
            // lblDelEmailValue
            // 
            lblDelEmailValue.AutoSize = true;
            lblDelEmailValue.Depth = 0;
            lblDelEmailValue.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDelEmailValue.Location = new Point(180, 260);
            lblDelEmailValue.MouseState = MaterialSkin.MouseState.HOVER;
            lblDelEmailValue.Name = "lblDelEmailValue";
            lblDelEmailValue.Size = new Size(5, 19);
            lblDelEmailValue.TabIndex = 11;
            lblDelEmailValue.Text = "-";
            // 
            // btnDeleteAdmin
            // 
            btnDeleteAdmin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteAdmin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDeleteAdmin.Depth = 0;
            btnDeleteAdmin.HighEmphasis = true;
            btnDeleteAdmin.Icon = null;
            btnDeleteAdmin.Location = new Point(180, 330);
            btnDeleteAdmin.Margin = new Padding(4, 6, 4, 6);
            btnDeleteAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteAdmin.Name = "btnDeleteAdmin";
            btnDeleteAdmin.NoAccentTextColor = Color.Empty;
            btnDeleteAdmin.Size = new Size(124, 36);
            btnDeleteAdmin.TabIndex = 12;
            btnDeleteAdmin.Text = "Delete Admin";
            btnDeleteAdmin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDeleteAdmin.UseAccentColor = true;
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.BaseTabControl = materialTabControl1;
            materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Dock = DockStyle.Top;
            materialTabSelector1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector1.Location = new Point(3, 3);
            materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(1466, 36);
            materialTabSelector1.TabIndex = 1;
            // 
            // tabManageStudents
            // 
            tabManageStudents.BackColor = Color.White;
            tabManageStudents.Controls.Add(lblStudentsComingSoon);
            tabManageStudents.Location = new Point(4, 29);
            tabManageStudents.Name = "tabManageStudents";
            tabManageStudents.Padding = new Padding(3);
            tabManageStudents.Size = new Size(1481, 570);
            tabManageStudents.TabIndex = 1;
            tabManageStudents.Text = "Manage Students";
            // 
            // lblStudentsComingSoon
            // 
            lblStudentsComingSoon.AutoSize = true;
            lblStudentsComingSoon.Depth = 0;
            lblStudentsComingSoon.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblStudentsComingSoon.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblStudentsComingSoon.Location = new Point(550, 250);
            lblStudentsComingSoon.MouseState = MaterialSkin.MouseState.HOVER;
            lblStudentsComingSoon.Name = "lblStudentsComingSoon";
            lblStudentsComingSoon.Size = new Size(363, 29);
            lblStudentsComingSoon.TabIndex = 0;
            lblStudentsComingSoon.Text = "Manage Students — Coming Soon";
            // 
            // tabManageInstructors
            // 
            tabManageInstructors.BackColor = Color.White;
            tabManageInstructors.Controls.Add(lblInstructorsComingSoon);
            tabManageInstructors.Location = new Point(4, 29);
            tabManageInstructors.Name = "tabManageInstructors";
            tabManageInstructors.Size = new Size(1481, 570);
            tabManageInstructors.TabIndex = 2;
            tabManageInstructors.Text = "Manage Instructors";
            // 
            // lblInstructorsComingSoon
            // 
            lblInstructorsComingSoon.AutoSize = true;
            lblInstructorsComingSoon.Depth = 0;
            lblInstructorsComingSoon.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblInstructorsComingSoon.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblInstructorsComingSoon.Location = new Point(530, 250);
            lblInstructorsComingSoon.MouseState = MaterialSkin.MouseState.HOVER;
            lblInstructorsComingSoon.Name = "lblInstructorsComingSoon";
            lblInstructorsComingSoon.Size = new Size(384, 29);
            lblInstructorsComingSoon.TabIndex = 0;
            lblInstructorsComingSoon.Text = "Manage Instructors — Coming Soon";
            // 
            // tabManageBranches
            // 
            tabManageBranches.BackColor = Color.White;
            tabManageBranches.Controls.Add(lblBranchesComingSoon);
            tabManageBranches.Location = new Point(4, 29);
            tabManageBranches.Name = "tabManageBranches";
            tabManageBranches.Size = new Size(1481, 570);
            tabManageBranches.TabIndex = 3;
            tabManageBranches.Text = "Manage Branches";
            // 
            // lblBranchesComingSoon
            // 
            lblBranchesComingSoon.AutoSize = true;
            lblBranchesComingSoon.Depth = 0;
            lblBranchesComingSoon.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblBranchesComingSoon.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblBranchesComingSoon.Location = new Point(540, 250);
            lblBranchesComingSoon.MouseState = MaterialSkin.MouseState.HOVER;
            lblBranchesComingSoon.Name = "lblBranchesComingSoon";
            lblBranchesComingSoon.Size = new Size(368, 29);
            lblBranchesComingSoon.TabIndex = 0;
            lblBranchesComingSoon.Text = "Manage Branches — Coming Soon";
            // 
            // tabManageTracks
            // 
            tabManageTracks.BackColor = Color.White;
            tabManageTracks.Controls.Add(lblTracksComingSoon);
            tabManageTracks.Location = new Point(4, 29);
            tabManageTracks.Name = "tabManageTracks";
            tabManageTracks.Size = new Size(1481, 570);
            tabManageTracks.TabIndex = 4;
            tabManageTracks.Text = "Manage Tracks";
            // 
            // lblTracksComingSoon
            // 
            lblTracksComingSoon.AutoSize = true;
            lblTracksComingSoon.Depth = 0;
            lblTracksComingSoon.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTracksComingSoon.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblTracksComingSoon.Location = new Point(560, 250);
            lblTracksComingSoon.MouseState = MaterialSkin.MouseState.HOVER;
            lblTracksComingSoon.Name = "lblTracksComingSoon";
            lblTracksComingSoon.Size = new Size(340, 29);
            lblTracksComingSoon.TabIndex = 0;
            lblTracksComingSoon.Text = "Manage Tracks — Coming Soon";
            // 
            // tabManageCourses
            // 
            tabManageCourses.BackColor = Color.White;
            tabManageCourses.Controls.Add(lblCoursesComingSoon);
            tabManageCourses.Location = new Point(4, 29);
            tabManageCourses.Name = "tabManageCourses";
            tabManageCourses.Size = new Size(1481, 570);
            tabManageCourses.TabIndex = 5;
            tabManageCourses.Text = "Manage Courses";
            // 
            // lblCoursesComingSoon
            // 
            lblCoursesComingSoon.AutoSize = true;
            lblCoursesComingSoon.Depth = 0;
            lblCoursesComingSoon.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblCoursesComingSoon.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblCoursesComingSoon.Location = new Point(550, 250);
            lblCoursesComingSoon.MouseState = MaterialSkin.MouseState.HOVER;
            lblCoursesComingSoon.Name = "lblCoursesComingSoon";
            lblCoursesComingSoon.Size = new Size(356, 29);
            lblCoursesComingSoon.TabIndex = 0;
            lblCoursesComingSoon.Text = "Manage Courses — Coming Soon";
            // 
            // tabExportReports
            // 
            tabExportReports.BackColor = Color.White;
            tabExportReports.Controls.Add(lblReportsComingSoon);
            tabExportReports.Location = new Point(4, 29);
            tabExportReports.Name = "tabExportReports";
            tabExportReports.Size = new Size(1481, 570);
            tabExportReports.TabIndex = 6;
            tabExportReports.Text = "Export Reports";
            // 
            // lblReportsComingSoon
            // 
            lblReportsComingSoon.AutoSize = true;
            lblReportsComingSoon.Depth = 0;
            lblReportsComingSoon.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblReportsComingSoon.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblReportsComingSoon.Location = new Point(550, 250);
            lblReportsComingSoon.MouseState = MaterialSkin.MouseState.HOVER;
            lblReportsComingSoon.Name = "lblReportsComingSoon";
            lblReportsComingSoon.Size = new Size(334, 29);
            lblReportsComingSoon.TabIndex = 0;
            lblReportsComingSoon.Text = "Export Reports — Coming Soon";
            // 
            // tabProfile
            // 
            tabProfile.BackColor = Color.White;
            tabProfile.Controls.Add(btnLogout);
            tabProfile.Controls.Add(lblProfileFullname);
            tabProfile.Controls.Add(lblProfileUsername);
            tabProfile.Controls.Add(lblProfileEmail);
            tabProfile.Controls.Add(lblProfileAddress);
            tabProfile.Controls.Add(lblProfilePhone);
            tabProfile.Controls.Add(lblProfileAge);
            tabProfile.Controls.Add(lblProfilePassword);
            tabProfile.Controls.Add(lblProfileGender);
            tabProfile.Controls.Add(txtProfileFullname);
            tabProfile.Controls.Add(txtProfileUsername);
            tabProfile.Controls.Add(txtProfileEmail);
            tabProfile.Controls.Add(txtProfileAddress);
            tabProfile.Controls.Add(txtProfilePhone);
            tabProfile.Controls.Add(txtProfileAge);
            tabProfile.Controls.Add(txtProfilePassword);
            tabProfile.Controls.Add(cmbProfileGender);
            tabProfile.Controls.Add(btnUpdateProfile);
            tabProfile.Location = new Point(4, 29);
            tabProfile.Name = "tabProfile";
            tabProfile.Size = new Size(1481, 570);
            tabProfile.TabIndex = 7;
            tabProfile.Text = "Profile & Logout";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogout.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLogout.Depth = 0;
            btnLogout.HighEmphasis = true;
            btnLogout.Icon = null;
            btnLogout.Location = new Point(1272, 20);
            btnLogout.Margin = new Padding(4, 6, 4, 6);
            btnLogout.MouseState = MaterialSkin.MouseState.HOVER;
            btnLogout.Name = "btnLogout";
            btnLogout.NoAccentTextColor = Color.Empty;
            btnLogout.Size = new Size(78, 36);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLogout.UseAccentColor = true;
            btnLogout.Click += BtnLogout_Click;
            // 
            // lblProfileFullname
            // 
            lblProfileFullname.Anchor = AnchorStyles.None;
            lblProfileFullname.AutoSize = true;
            lblProfileFullname.Depth = 0;
            lblProfileFullname.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblProfileFullname.Location = new Point(450, 80);
            lblProfileFullname.MouseState = MaterialSkin.MouseState.HOVER;
            lblProfileFullname.Name = "lblProfileFullname";
            lblProfileFullname.Size = new Size(77, 19);
            lblProfileFullname.TabIndex = 1;
            lblProfileFullname.Text = "Full Name:";
            // 
            // lblProfileUsername
            // 
            lblProfileUsername.Anchor = AnchorStyles.None;
            lblProfileUsername.AutoSize = true;
            lblProfileUsername.Depth = 0;
            lblProfileUsername.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblProfileUsername.Location = new Point(450, 140);
            lblProfileUsername.MouseState = MaterialSkin.MouseState.HOVER;
            lblProfileUsername.Name = "lblProfileUsername";
            lblProfileUsername.Size = new Size(76, 19);
            lblProfileUsername.TabIndex = 2;
            lblProfileUsername.Text = "Username:";
            // 
            // lblProfileEmail
            // 
            lblProfileEmail.Anchor = AnchorStyles.None;
            lblProfileEmail.AutoSize = true;
            lblProfileEmail.Depth = 0;
            lblProfileEmail.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblProfileEmail.Location = new Point(450, 200);
            lblProfileEmail.MouseState = MaterialSkin.MouseState.HOVER;
            lblProfileEmail.Name = "lblProfileEmail";
            lblProfileEmail.Size = new Size(45, 19);
            lblProfileEmail.TabIndex = 3;
            lblProfileEmail.Text = "Email:";
            // 
            // lblProfileAddress
            // 
            lblProfileAddress.Anchor = AnchorStyles.None;
            lblProfileAddress.AutoSize = true;
            lblProfileAddress.Depth = 0;
            lblProfileAddress.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblProfileAddress.Location = new Point(450, 260);
            lblProfileAddress.MouseState = MaterialSkin.MouseState.HOVER;
            lblProfileAddress.Name = "lblProfileAddress";
            lblProfileAddress.Size = new Size(62, 19);
            lblProfileAddress.TabIndex = 4;
            lblProfileAddress.Text = "Address:";
            // 
            // lblProfilePhone
            // 
            lblProfilePhone.Anchor = AnchorStyles.None;
            lblProfilePhone.AutoSize = true;
            lblProfilePhone.Depth = 0;
            lblProfilePhone.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblProfilePhone.Location = new Point(450, 320);
            lblProfilePhone.MouseState = MaterialSkin.MouseState.HOVER;
            lblProfilePhone.Name = "lblProfilePhone";
            lblProfilePhone.Size = new Size(50, 19);
            lblProfilePhone.TabIndex = 5;
            lblProfilePhone.Text = "Phone:";
            // 
            // lblProfileAge
            // 
            lblProfileAge.Anchor = AnchorStyles.None;
            lblProfileAge.AutoSize = true;
            lblProfileAge.Depth = 0;
            lblProfileAge.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblProfileAge.Location = new Point(450, 380);
            lblProfileAge.MouseState = MaterialSkin.MouseState.HOVER;
            lblProfileAge.Name = "lblProfileAge";
            lblProfileAge.Size = new Size(32, 19);
            lblProfileAge.TabIndex = 6;
            lblProfileAge.Text = "Age:";
            // 
            // lblProfilePassword
            // 
            lblProfilePassword.Anchor = AnchorStyles.None;
            lblProfilePassword.AutoSize = true;
            lblProfilePassword.Depth = 0;
            lblProfilePassword.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblProfilePassword.Location = new Point(450, 440);
            lblProfilePassword.MouseState = MaterialSkin.MouseState.HOVER;
            lblProfilePassword.Name = "lblProfilePassword";
            lblProfilePassword.Size = new Size(75, 19);
            lblProfilePassword.TabIndex = 7;
            lblProfilePassword.Text = "Password:";
            // 
            // lblProfileGender
            // 
            lblProfileGender.Anchor = AnchorStyles.None;
            lblProfileGender.AutoSize = true;
            lblProfileGender.Depth = 0;
            lblProfileGender.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblProfileGender.Location = new Point(750, 380);
            lblProfileGender.MouseState = MaterialSkin.MouseState.HOVER;
            lblProfileGender.Name = "lblProfileGender";
            lblProfileGender.Size = new Size(55, 19);
            lblProfileGender.TabIndex = 8;
            lblProfileGender.Text = "Gender:";
            // 
            // txtProfileFullname
            // 
            txtProfileFullname.Anchor = AnchorStyles.None;
            txtProfileFullname.AnimateReadOnly = false;
            txtProfileFullname.BackgroundImageLayout = ImageLayout.None;
            txtProfileFullname.CharacterCasing = CharacterCasing.Normal;
            txtProfileFullname.Depth = 0;
            txtProfileFullname.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtProfileFullname.HideSelection = true;
            txtProfileFullname.Hint = "Full name";
            txtProfileFullname.LeadingIcon = null;
            txtProfileFullname.Location = new Point(600, 70);
            txtProfileFullname.MaxLength = 50;
            txtProfileFullname.MouseState = MaterialSkin.MouseState.OUT;
            txtProfileFullname.Name = "txtProfileFullname";
            txtProfileFullname.PasswordChar = '\0';
            txtProfileFullname.PrefixSuffixText = null;
            txtProfileFullname.ReadOnly = false;
            txtProfileFullname.RightToLeft = RightToLeft.No;
            txtProfileFullname.SelectedText = "";
            txtProfileFullname.SelectionLength = 0;
            txtProfileFullname.SelectionStart = 0;
            txtProfileFullname.ShortcutsEnabled = true;
            txtProfileFullname.Size = new Size(300, 48);
            txtProfileFullname.TabIndex = 9;
            txtProfileFullname.TabStop = false;
            txtProfileFullname.TextAlign = HorizontalAlignment.Left;
            txtProfileFullname.TrailingIcon = null;
            txtProfileFullname.UseSystemPasswordChar = false;
            // 
            // txtProfileUsername
            // 
            txtProfileUsername.Anchor = AnchorStyles.None;
            txtProfileUsername.AnimateReadOnly = false;
            txtProfileUsername.BackgroundImageLayout = ImageLayout.None;
            txtProfileUsername.CharacterCasing = CharacterCasing.Normal;
            txtProfileUsername.Depth = 0;
            txtProfileUsername.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtProfileUsername.HideSelection = true;
            txtProfileUsername.Hint = "Username";
            txtProfileUsername.LeadingIcon = null;
            txtProfileUsername.Location = new Point(600, 130);
            txtProfileUsername.MaxLength = 50;
            txtProfileUsername.MouseState = MaterialSkin.MouseState.OUT;
            txtProfileUsername.Name = "txtProfileUsername";
            txtProfileUsername.PasswordChar = '\0';
            txtProfileUsername.PrefixSuffixText = null;
            txtProfileUsername.ReadOnly = false;
            txtProfileUsername.RightToLeft = RightToLeft.No;
            txtProfileUsername.SelectedText = "";
            txtProfileUsername.SelectionLength = 0;
            txtProfileUsername.SelectionStart = 0;
            txtProfileUsername.ShortcutsEnabled = true;
            txtProfileUsername.Size = new Size(300, 48);
            txtProfileUsername.TabIndex = 10;
            txtProfileUsername.TabStop = false;
            txtProfileUsername.TextAlign = HorizontalAlignment.Left;
            txtProfileUsername.TrailingIcon = null;
            txtProfileUsername.UseSystemPasswordChar = false;
            // 
            // txtProfileEmail
            // 
            txtProfileEmail.Anchor = AnchorStyles.None;
            txtProfileEmail.AnimateReadOnly = false;
            txtProfileEmail.BackgroundImageLayout = ImageLayout.None;
            txtProfileEmail.CharacterCasing = CharacterCasing.Normal;
            txtProfileEmail.Depth = 0;
            txtProfileEmail.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtProfileEmail.HideSelection = true;
            txtProfileEmail.Hint = "Email address";
            txtProfileEmail.LeadingIcon = null;
            txtProfileEmail.Location = new Point(600, 190);
            txtProfileEmail.MaxLength = 50;
            txtProfileEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtProfileEmail.Name = "txtProfileEmail";
            txtProfileEmail.PasswordChar = '\0';
            txtProfileEmail.PrefixSuffixText = null;
            txtProfileEmail.ReadOnly = false;
            txtProfileEmail.RightToLeft = RightToLeft.No;
            txtProfileEmail.SelectedText = "";
            txtProfileEmail.SelectionLength = 0;
            txtProfileEmail.SelectionStart = 0;
            txtProfileEmail.ShortcutsEnabled = true;
            txtProfileEmail.Size = new Size(300, 48);
            txtProfileEmail.TabIndex = 11;
            txtProfileEmail.TabStop = false;
            txtProfileEmail.TextAlign = HorizontalAlignment.Left;
            txtProfileEmail.TrailingIcon = null;
            txtProfileEmail.UseSystemPasswordChar = false;
            // 
            // txtProfileAddress
            // 
            txtProfileAddress.Anchor = AnchorStyles.None;
            txtProfileAddress.AnimateReadOnly = false;
            txtProfileAddress.BackgroundImageLayout = ImageLayout.None;
            txtProfileAddress.CharacterCasing = CharacterCasing.Normal;
            txtProfileAddress.Depth = 0;
            txtProfileAddress.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtProfileAddress.HideSelection = true;
            txtProfileAddress.Hint = "Address";
            txtProfileAddress.LeadingIcon = null;
            txtProfileAddress.Location = new Point(600, 250);
            txtProfileAddress.MaxLength = 50;
            txtProfileAddress.MouseState = MaterialSkin.MouseState.OUT;
            txtProfileAddress.Name = "txtProfileAddress";
            txtProfileAddress.PasswordChar = '\0';
            txtProfileAddress.PrefixSuffixText = null;
            txtProfileAddress.ReadOnly = false;
            txtProfileAddress.RightToLeft = RightToLeft.No;
            txtProfileAddress.SelectedText = "";
            txtProfileAddress.SelectionLength = 0;
            txtProfileAddress.SelectionStart = 0;
            txtProfileAddress.ShortcutsEnabled = true;
            txtProfileAddress.Size = new Size(300, 48);
            txtProfileAddress.TabIndex = 12;
            txtProfileAddress.TabStop = false;
            txtProfileAddress.TextAlign = HorizontalAlignment.Left;
            txtProfileAddress.TrailingIcon = null;
            txtProfileAddress.UseSystemPasswordChar = false;
            // 
            // txtProfilePhone
            // 
            txtProfilePhone.Anchor = AnchorStyles.None;
            txtProfilePhone.AnimateReadOnly = false;
            txtProfilePhone.BackgroundImageLayout = ImageLayout.None;
            txtProfilePhone.CharacterCasing = CharacterCasing.Normal;
            txtProfilePhone.Depth = 0;
            txtProfilePhone.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtProfilePhone.HideSelection = true;
            txtProfilePhone.Hint = "Phone number";
            txtProfilePhone.LeadingIcon = null;
            txtProfilePhone.Location = new Point(600, 310);
            txtProfilePhone.MaxLength = 50;
            txtProfilePhone.MouseState = MaterialSkin.MouseState.OUT;
            txtProfilePhone.Name = "txtProfilePhone";
            txtProfilePhone.PasswordChar = '\0';
            txtProfilePhone.PrefixSuffixText = null;
            txtProfilePhone.ReadOnly = false;
            txtProfilePhone.RightToLeft = RightToLeft.No;
            txtProfilePhone.SelectedText = "";
            txtProfilePhone.SelectionLength = 0;
            txtProfilePhone.SelectionStart = 0;
            txtProfilePhone.ShortcutsEnabled = true;
            txtProfilePhone.Size = new Size(300, 48);
            txtProfilePhone.TabIndex = 13;
            txtProfilePhone.TabStop = false;
            txtProfilePhone.TextAlign = HorizontalAlignment.Left;
            txtProfilePhone.TrailingIcon = null;
            txtProfilePhone.UseSystemPasswordChar = false;
            // 
            // txtProfileAge
            // 
            txtProfileAge.Anchor = AnchorStyles.None;
            txtProfileAge.AnimateReadOnly = false;
            txtProfileAge.BackgroundImageLayout = ImageLayout.None;
            txtProfileAge.CharacterCasing = CharacterCasing.Normal;
            txtProfileAge.Depth = 0;
            txtProfileAge.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtProfileAge.HideSelection = true;
            txtProfileAge.Hint = "Age";
            txtProfileAge.LeadingIcon = null;
            txtProfileAge.Location = new Point(600, 370);
            txtProfileAge.MaxLength = 50;
            txtProfileAge.MouseState = MaterialSkin.MouseState.OUT;
            txtProfileAge.Name = "txtProfileAge";
            txtProfileAge.PasswordChar = '\0';
            txtProfileAge.PrefixSuffixText = null;
            txtProfileAge.ReadOnly = false;
            txtProfileAge.RightToLeft = RightToLeft.No;
            txtProfileAge.SelectedText = "";
            txtProfileAge.SelectionLength = 0;
            txtProfileAge.SelectionStart = 0;
            txtProfileAge.ShortcutsEnabled = true;
            txtProfileAge.Size = new Size(120, 48);
            txtProfileAge.TabIndex = 14;
            txtProfileAge.TabStop = false;
            txtProfileAge.TextAlign = HorizontalAlignment.Left;
            txtProfileAge.TrailingIcon = null;
            txtProfileAge.UseSystemPasswordChar = false;
            // 
            // txtProfilePassword
            // 
            txtProfilePassword.Anchor = AnchorStyles.None;
            txtProfilePassword.AnimateReadOnly = false;
            txtProfilePassword.BackgroundImageLayout = ImageLayout.None;
            txtProfilePassword.CharacterCasing = CharacterCasing.Normal;
            txtProfilePassword.Depth = 0;
            txtProfilePassword.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtProfilePassword.HideSelection = true;
            txtProfilePassword.Hint = "Enter new password (optional)";
            txtProfilePassword.LeadingIcon = null;
            txtProfilePassword.Location = new Point(600, 430);
            txtProfilePassword.MaxLength = 50;
            txtProfilePassword.MouseState = MaterialSkin.MouseState.OUT;
            txtProfilePassword.Name = "txtProfilePassword";
            txtProfilePassword.PasswordChar = '*';
            txtProfilePassword.PrefixSuffixText = null;
            txtProfilePassword.ReadOnly = false;
            txtProfilePassword.RightToLeft = RightToLeft.No;
            txtProfilePassword.SelectedText = "";
            txtProfilePassword.SelectionLength = 0;
            txtProfilePassword.SelectionStart = 0;
            txtProfilePassword.ShortcutsEnabled = true;
            txtProfilePassword.Size = new Size(300, 48);
            txtProfilePassword.TabIndex = 15;
            txtProfilePassword.TabStop = false;
            txtProfilePassword.TextAlign = HorizontalAlignment.Left;
            txtProfilePassword.TrailingIcon = null;
            txtProfilePassword.UseSystemPasswordChar = false;
            // 
            // cmbProfileGender
            // 
            cmbProfileGender.Anchor = AnchorStyles.None;
            cmbProfileGender.AutoResize = false;
            cmbProfileGender.BackColor = Color.FromArgb(255, 255, 255);
            cmbProfileGender.Depth = 0;
            cmbProfileGender.DrawMode = DrawMode.OwnerDrawVariable;
            cmbProfileGender.DropDownHeight = 174;
            cmbProfileGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProfileGender.DropDownWidth = 121;
            cmbProfileGender.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbProfileGender.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbProfileGender.FormattingEnabled = true;
            cmbProfileGender.IntegralHeight = false;
            cmbProfileGender.ItemHeight = 43;
            cmbProfileGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbProfileGender.Location = new Point(830, 370);
            cmbProfileGender.MaxDropDownItems = 4;
            cmbProfileGender.MouseState = MaterialSkin.MouseState.OUT;
            cmbProfileGender.Name = "cmbProfileGender";
            cmbProfileGender.Size = new Size(120, 49);
            cmbProfileGender.StartIndex = 0;
            cmbProfileGender.TabIndex = 16;
            // 
            // btnUpdateProfile
            // 
            btnUpdateProfile.Anchor = AnchorStyles.None;
            btnUpdateProfile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUpdateProfile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUpdateProfile.Depth = 0;
            btnUpdateProfile.HighEmphasis = true;
            btnUpdateProfile.Icon = null;
            btnUpdateProfile.Location = new Point(600, 500);
            btnUpdateProfile.Margin = new Padding(4, 6, 4, 6);
            btnUpdateProfile.MouseState = MaterialSkin.MouseState.HOVER;
            btnUpdateProfile.Name = "btnUpdateProfile";
            btnUpdateProfile.NoAccentTextColor = Color.Empty;
            btnUpdateProfile.Size = new Size(138, 36);
            btnUpdateProfile.TabIndex = 17;
            btnUpdateProfile.Text = "Update Profile";
            btnUpdateProfile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUpdateProfile.UseAccentColor = true;
            btnUpdateProfile.Click += btnUpdateProfile_Click;
            // 
            // ThemeSwitchBtn
            // 
            ThemeSwitchBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ThemeSwitchBtn.AutoSize = true;
            ThemeSwitchBtn.Depth = 0;
            ThemeSwitchBtn.Location = new Point(1357, 717);
            ThemeSwitchBtn.Margin = new Padding(0);
            ThemeSwitchBtn.MouseLocation = new Point(-1, -1);
            ThemeSwitchBtn.MouseState = MaterialSkin.MouseState.HOVER;
            ThemeSwitchBtn.Name = "ThemeSwitchBtn";
            ThemeSwitchBtn.Ripple = true;
            ThemeSwitchBtn.Size = new Size(138, 37);
            ThemeSwitchBtn.TabIndex = 5;
            ThemeSwitchBtn.Text = "Light Mode";
            ThemeSwitchBtn.UseVisualStyleBackColor = true;
            ThemeSwitchBtn.Click += ToggleTheme;
            // 
            // cmbLanguage
            // 
            cmbLanguage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cmbLanguage.AutoResize = false;
            cmbLanguage.BackColor = Color.White;
            cmbLanguage.Depth = 0;
            cmbLanguage.DrawMode = DrawMode.OwnerDrawVariable;
            cmbLanguage.DropDownHeight = 174;
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.DropDownWidth = 121;
            cmbLanguage.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbLanguage.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.IntegralHeight = false;
            cmbLanguage.ItemHeight = 43;
            cmbLanguage.Items.AddRange(new object[] { "English", "العربية" });
            cmbLanguage.Location = new Point(7, 705);
            cmbLanguage.MaxDropDownItems = 4;
            cmbLanguage.MouseState = MaterialSkin.MouseState.OUT;
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(151, 49);
            cmbLanguage.StartIndex = 0;
            cmbLanguage.TabIndex = 6;
            cmbLanguage.SelectedIndexChanged += ChangeLanguage;
            // 
            // AdminMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1502, 759);
            Controls.Add(cmbLanguage);
            Controls.Add(ThemeSwitchBtn);
            Controls.Add(materialTabControl);
            Controls.Add(materialTabSelector);
            MaximumSize = new Size(1502, 759);
            MinimumSize = new Size(1502, 759);
            Name = "AdminMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Main Panel";
            materialTabControl.ResumeLayout(false);
            tabManageAdmins.ResumeLayout(false);
            materialTabControl1.ResumeLayout(false);
            tabShowAdmins.ResumeLayout(false);
            tabShowAdmins.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridAdminsData).EndInit();
            tabUpdateAdmin.ResumeLayout(false);
            tabUpdateAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridAdminsForUpdate).EndInit();
            tabCreateAdmin.ResumeLayout(false);
            tabCreateAdmin.PerformLayout();
            tabDeleteAdmin.ResumeLayout(false);
            tabDeleteAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridAdminsForDelete).EndInit();
            tabManageStudents.ResumeLayout(false);
            tabManageStudents.PerformLayout();
            tabManageInstructors.ResumeLayout(false);
            tabManageInstructors.PerformLayout();
            tabManageBranches.ResumeLayout(false);
            tabManageBranches.PerformLayout();
            tabManageTracks.ResumeLayout(false);
            tabManageTracks.PerformLayout();
            tabManageCourses.ResumeLayout(false);
            tabManageCourses.PerformLayout();
            tabExportReports.ResumeLayout(false);
            tabExportReports.PerformLayout();
            tabProfile.ResumeLayout(false);
            tabProfile.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl;
        private TabPage tabManageAdmins;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabShowAdmins;
        private TabPage tabUpdateAdmin;
        private TabPage tabCreateAdmin;
        private TabPage tabDeleteAdmin;
        private DataGridView gridAdminsData;
        private MaterialSkin.Controls.MaterialTextBox txtSearchAdmin;
        private MaterialSkin.Controls.MaterialButton btnSearchAdmin;
        private MaterialSkin.Controls.MaterialButton btnShowAllAdmins;
        private MaterialSkin.Controls.MaterialRadioButton radioSearchById;
        private MaterialSkin.Controls.MaterialRadioButton radioSearchByUsername;
        private MaterialSkin.Controls.MaterialRadioButton radioSearchByEmail;
        private MaterialSkin.Controls.MaterialSwitch ThemeSwitchBtn;
        private MaterialSkin.Controls.MaterialComboBox cmbLanguage;

        // Other management tabs
        private TabPage tabManageStudents;
        private TabPage tabManageInstructors;
        private TabPage tabManageBranches;
        private TabPage tabManageTracks;
        private TabPage tabManageCourses;
        private TabPage tabExportReports;
        private TabPage tabProfile;

        private DataGridView gridAdminsForUpdate;
        private MaterialSkin.Controls.MaterialLabel lblFullname;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private MaterialSkin.Controls.MaterialLabel lblEmail;
        private MaterialSkin.Controls.MaterialLabel lblPassword;
        private MaterialSkin.Controls.MaterialTextBox txtFullname;
        private MaterialSkin.Controls.MaterialTextBox txtUsername;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialButton btnSubmitUpdate;

        private MaterialSkin.Controls.MaterialLabel lblSearchDelete;
        private MaterialSkin.Controls.MaterialTextBox txtSearchDelete;
        private MaterialSkin.Controls.MaterialButton btnGetAdminDelete;
        private MaterialSkin.Controls.MaterialRadioButton radioSearchByID_Delete;
        private MaterialSkin.Controls.MaterialRadioButton radioSearchByUsername_Delete;
        private MaterialSkin.Controls.MaterialRadioButton radioSearchByEmail_Delete;
        private DataGridView gridAdminsForDelete;
        private MaterialSkin.Controls.MaterialLabel lblDelFullname;
        private MaterialSkin.Controls.MaterialLabel lblDelFullnameValue;
        private MaterialSkin.Controls.MaterialLabel lblDelUsername;
        private MaterialSkin.Controls.MaterialLabel lblDelUsernameValue;
        private MaterialSkin.Controls.MaterialLabel lblDelEmail;
        private MaterialSkin.Controls.MaterialLabel lblDelEmailValue;
        private MaterialSkin.Controls.MaterialButton btnDeleteAdmin;

        private MaterialSkin.Controls.MaterialLabel lblCreateFullname;
        private MaterialSkin.Controls.MaterialLabel lblCreateUsername;
        private MaterialSkin.Controls.MaterialLabel lblCreateEmail;
        private MaterialSkin.Controls.MaterialLabel lblCreatePassword;
        private MaterialSkin.Controls.MaterialLabel lblCreateAddress;
        private MaterialSkin.Controls.MaterialLabel lblCreatePhone;
        private MaterialSkin.Controls.MaterialLabel lblCreateAge;
        private MaterialSkin.Controls.MaterialLabel lblCreateGender;

        private MaterialSkin.Controls.MaterialTextBox txtCreateFullname;
        private MaterialSkin.Controls.MaterialTextBox txtCreateUsername;
        private MaterialSkin.Controls.MaterialTextBox txtCreateEmail;
        private MaterialSkin.Controls.MaterialTextBox txtCreatePassword;
        private MaterialSkin.Controls.MaterialTextBox txtCreateAddress;
        private MaterialSkin.Controls.MaterialTextBox txtCreatePhone;
        private MaterialSkin.Controls.MaterialTextBox txtCreateAge;

        private MaterialSkin.Controls.MaterialComboBox cmbCreateGender;
        private MaterialSkin.Controls.MaterialButton btnCreateAdmin;


        private MaterialSkin.Controls.MaterialLabel lblStudentsComingSoon;
        private MaterialSkin.Controls.MaterialLabel lblInstructorsComingSoon;
        private MaterialSkin.Controls.MaterialLabel lblBranchesComingSoon;
        private MaterialSkin.Controls.MaterialLabel lblTracksComingSoon;
        private MaterialSkin.Controls.MaterialLabel lblCoursesComingSoon;
        private MaterialSkin.Controls.MaterialLabel lblReportsComingSoon;

        // Profile tab controls
        private MaterialSkin.Controls.MaterialButton btnLogout;
        private MaterialSkin.Controls.MaterialLabel lblProfileFullname;
        private MaterialSkin.Controls.MaterialLabel lblProfileUsername;
        private MaterialSkin.Controls.MaterialLabel lblProfileEmail;
        private MaterialSkin.Controls.MaterialLabel lblProfileAddress;
        private MaterialSkin.Controls.MaterialLabel lblProfilePhone;
        private MaterialSkin.Controls.MaterialLabel lblProfileAge;
        private MaterialSkin.Controls.MaterialLabel lblProfilePassword;
        private MaterialSkin.Controls.MaterialLabel lblProfileGender;
        private MaterialSkin.Controls.MaterialTextBox2 txtProfileFullname;
        private MaterialSkin.Controls.MaterialTextBox2 txtProfileUsername;
        private MaterialSkin.Controls.MaterialTextBox2 txtProfileEmail;
        private MaterialSkin.Controls.MaterialTextBox2 txtProfileAddress;
        private MaterialSkin.Controls.MaterialTextBox2 txtProfilePhone;
        private MaterialSkin.Controls.MaterialTextBox2 txtProfileAge;
        private MaterialSkin.Controls.MaterialTextBox2 txtProfilePassword;
        private MaterialSkin.Controls.MaterialComboBox cmbProfileGender;
        private MaterialSkin.Controls.MaterialButton btnUpdateProfile;
    }
}
