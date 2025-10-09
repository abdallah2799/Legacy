namespace UI.FormsLayer.Shared
{
    partial class ApplicantApplicationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new MaterialSkin.Controls.MaterialLabel();
            lblSubtitle = new MaterialSkin.Controls.MaterialLabel();
            lblStepTitle = new MaterialSkin.Controls.MaterialLabel();
            lblStepDescription = new MaterialSkin.Controls.MaterialLabel();
            cmbLanguage = new MaterialSkin.Controls.MaterialComboBox();
            btnTheme = new MaterialSkin.Controls.MaterialButton();
            btnBackToHome = new MaterialSkin.Controls.MaterialButton();
            txtFullName = new MaterialSkin.Controls.MaterialTextBox();
            txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            txtPhone = new MaterialSkin.Controls.MaterialTextBox();
            txtAge = new MaterialSkin.Controls.MaterialTextBox();
            cmbGender = new MaterialSkin.Controls.MaterialComboBox();
            txtAddress = new MaterialSkin.Controls.MaterialTextBox();
            cmbBranch = new MaterialSkin.Controls.MaterialComboBox();
            lblBranchDescription = new MaterialSkin.Controls.MaterialLabel();
            cmbFirstTrack = new MaterialSkin.Controls.MaterialComboBox();
            cmbSecondTrack = new MaterialSkin.Controls.MaterialComboBox();
            lblFirstTrackDescription = new MaterialSkin.Controls.MaterialLabel();
            lblSecondTrackDescription = new MaterialSkin.Controls.MaterialLabel();
            lblReviewSummary = new MaterialSkin.Controls.MaterialLabel();
            chkTermsAndConditions = new MaterialSkin.Controls.MaterialCheckbox();
            btnPrevious = new MaterialSkin.Controls.MaterialButton();
            btnNext = new MaterialSkin.Controls.MaterialButton();
            btnSubmit = new MaterialSkin.Controls.MaterialButton();
            panelMain = new Panel();
            panelContent = new Panel();
            panelNavigation = new Panel();
            panelSteps = new Panel();
            panelTop = new Panel();
            panelMain.SuspendLayout();
            panelContent.SuspendLayout();
            panelNavigation.SuspendLayout();
            panelSteps.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Depth = 0;
            lblTitle.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            lblTitle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTitle.Location = new Point(67, 31);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(259, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Application Form";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Depth = 0;
            lblSubtitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSubtitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblSubtitle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSubtitle.Location = new Point(64, 89);
            lblSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblSubtitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(349, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Please fill in your information to apply for Legacy";
            // 
            // lblStepTitle
            // 
            lblStepTitle.AutoSize = true;
            lblStepTitle.Depth = 0;
            lblStepTitle.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblStepTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblStepTitle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblStepTitle.Location = new Point(64, 126);
            lblStepTitle.Margin = new Padding(4, 0, 4, 0);
            lblStepTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblStepTitle.Name = "lblStepTitle";
            lblStepTitle.Size = new Size(115, 29);
            lblStepTitle.TabIndex = 2;
            lblStepTitle.Text = "Step 1 of 4";
            // 
            // lblStepDescription
            // 
            lblStepDescription.AutoSize = true;
            lblStepDescription.Depth = 0;
            lblStepDescription.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblStepDescription.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblStepDescription.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblStepDescription.Location = new Point(64, 165);
            lblStepDescription.Margin = new Padding(4, 0, 4, 0);
            lblStepDescription.MouseState = MaterialSkin.MouseState.HOVER;
            lblStepDescription.Name = "lblStepDescription";
            lblStepDescription.Size = new Size(150, 19);
            lblStepDescription.TabIndex = 3;
            lblStepDescription.Text = "Personal Information";
            // 
            // cmbLanguage
            // 
            cmbLanguage.AutoResize = false;
            cmbLanguage.BackColor = Color.FromArgb(255, 255, 255);
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
            cmbLanguage.Location = new Point(18, 11);
            cmbLanguage.Margin = new Padding(4, 5, 4, 5);
            cmbLanguage.MaxDropDownItems = 4;
            cmbLanguage.MouseState = MaterialSkin.MouseState.OUT;
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(199, 49);
            cmbLanguage.StartIndex = 0;
            cmbLanguage.TabIndex = 0;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // btnTheme
            // 
            btnTheme.AutoSize = false;
            btnTheme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTheme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTheme.Depth = 0;
            btnTheme.HighEmphasis = true;
            btnTheme.Icon = null;
            btnTheme.Location = new Point(237, 11);
            btnTheme.Margin = new Padding(5, 9, 5, 9);
            btnTheme.MouseState = MaterialSkin.MouseState.HOVER;
            btnTheme.Name = "btnTheme";
            btnTheme.NoAccentTextColor = Color.Empty;
            btnTheme.Size = new Size(66, 45);
            btnTheme.TabIndex = 1;
            btnTheme.Text = "Dark";
            btnTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTheme.UseAccentColor = false;
            btnTheme.UseVisualStyleBackColor = true;
            btnTheme.Click += btnTheme_Click;
            // 
            // btnBackToHome
            // 
            btnBackToHome.AutoSize = false;
            btnBackToHome.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackToHome.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBackToHome.Depth = 0;
            btnBackToHome.HighEmphasis = true;
            btnBackToHome.Icon = null;
            btnBackToHome.Location = new Point(1189, 17);
            btnBackToHome.Margin = new Padding(5, 9, 5, 9);
            btnBackToHome.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackToHome.Name = "btnBackToHome";
            btnBackToHome.NoAccentTextColor = Color.Empty;
            btnBackToHome.Size = new Size(118, 39);
            btnBackToHome.TabIndex = 2;
            btnBackToHome.Text = "Back to Home";
            btnBackToHome.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnBackToHome.UseAccentColor = false;
            btnBackToHome.UseVisualStyleBackColor = true;
            btnBackToHome.Click += btnBackToHome_Click;
            // 
            // txtFullName
            // 
            txtFullName.AnimateReadOnly = false;
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Depth = 0;
            txtFullName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFullName.Hint = "Full Name";
            txtFullName.LeadingIcon = null;
            txtFullName.Location = new Point(27, 224);
            txtFullName.Margin = new Padding(4, 5, 4, 5);
            txtFullName.MaxLength = 50;
            txtFullName.MouseState = MaterialSkin.MouseState.OUT;
            txtFullName.Multiline = false;
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(400, 50);
            txtFullName.TabIndex = 4;
            txtFullName.Text = "";
            txtFullName.TrailingIcon = null;
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.Hint = "Email";
            txtEmail.LeadingIcon = null;
            txtEmail.Location = new Point(500, 63);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.MaxLength = 50;
            txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 50);
            txtEmail.TabIndex = 5;
            txtEmail.Text = "";
            txtEmail.TrailingIcon = null;
            // 
            // txtPhone
            // 
            txtPhone.AnimateReadOnly = false;
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Depth = 0;
            txtPhone.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPhone.Hint = "Phone";
            txtPhone.LeadingIcon = null;
            txtPhone.Location = new Point(474, 249);
            txtPhone.Margin = new Padding(4, 5, 4, 5);
            txtPhone.MaxLength = 50;
            txtPhone.MouseState = MaterialSkin.MouseState.OUT;
            txtPhone.Multiline = false;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(400, 50);
            txtPhone.TabIndex = 6;
            txtPhone.Text = "";
            txtPhone.TrailingIcon = null;
            // 
            // txtAge
            // 
            txtAge.AnimateReadOnly = false;
            txtAge.BorderStyle = BorderStyle.None;
            txtAge.Depth = 0;
            txtAge.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAge.Hint = "Age";
            txtAge.LeadingIcon = null;
            txtAge.Location = new Point(67, 631);
            txtAge.Margin = new Padding(4, 5, 4, 5);
            txtAge.MaxLength = 3;
            txtAge.MouseState = MaterialSkin.MouseState.OUT;
            txtAge.Multiline = false;
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(133, 50);
            txtAge.TabIndex = 7;
            txtAge.Text = "";
            txtAge.TrailingIcon = null;
            // 
            // cmbGender
            // 
            cmbGender.AutoResize = false;
            cmbGender.BackColor = Color.FromArgb(255, 255, 255);
            cmbGender.Depth = 0;
            cmbGender.DrawMode = DrawMode.OwnerDrawVariable;
            cmbGender.DropDownHeight = 174;
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.DropDownWidth = 121;
            cmbGender.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbGender.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbGender.FormattingEnabled = true;
            cmbGender.IntegralHeight = false;
            cmbGender.ItemHeight = 43;
            cmbGender.Location = new Point(67, 330);
            cmbGender.Margin = new Padding(4, 5, 4, 5);
            cmbGender.MaxDropDownItems = 4;
            cmbGender.MouseState = MaterialSkin.MouseState.OUT;
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(199, 49);
            cmbGender.StartIndex = 0;
            cmbGender.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.AnimateReadOnly = false;
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Depth = 0;
            txtAddress.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAddress.Hint = "Address";
            txtAddress.LeadingIcon = null;
            txtAddress.Location = new Point(394, 342);
            txtAddress.Margin = new Padding(4, 5, 4, 5);
            txtAddress.MaxLength = 200;
            txtAddress.MouseState = MaterialSkin.MouseState.OUT;
            txtAddress.Multiline = false;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(400, 50);
            txtAddress.TabIndex = 9;
            txtAddress.Text = "";
            txtAddress.TrailingIcon = null;
            // 
            // cmbBranch
            // 
            cmbBranch.AutoResize = false;
            cmbBranch.BackColor = Color.FromArgb(255, 255, 255);
            cmbBranch.Depth = 0;
            cmbBranch.DrawMode = DrawMode.OwnerDrawVariable;
            cmbBranch.DropDownHeight = 174;
            cmbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBranch.DropDownWidth = 121;
            cmbBranch.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbBranch.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbBranch.FormattingEnabled = true;
            cmbBranch.IntegralHeight = false;
            cmbBranch.ItemHeight = 43;
            cmbBranch.Location = new Point(27, 61);
            cmbBranch.Margin = new Padding(4, 5, 4, 5);
            cmbBranch.MaxDropDownItems = 4;
            cmbBranch.MouseState = MaterialSkin.MouseState.OUT;
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(399, 49);
            cmbBranch.StartIndex = 0;
            cmbBranch.TabIndex = 10;
            cmbBranch.SelectedIndexChanged += cmbBranch_SelectedIndexChanged;
            // 
            // lblBranchDescription
            // 
            lblBranchDescription.AutoSize = true;
            lblBranchDescription.Depth = 0;
            lblBranchDescription.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBranchDescription.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBranchDescription.Location = new Point(55, 375);
            lblBranchDescription.Margin = new Padding(4, 0, 4, 0);
            lblBranchDescription.MouseState = MaterialSkin.MouseState.HOVER;
            lblBranchDescription.Name = "lblBranchDescription";
            lblBranchDescription.Size = new Size(259, 19);
            lblBranchDescription.TabIndex = 11;
            lblBranchDescription.Text = "Description: No description available";
            // 
            // cmbFirstTrack
            // 
            cmbFirstTrack.AutoResize = false;
            cmbFirstTrack.BackColor = Color.FromArgb(255, 255, 255);
            cmbFirstTrack.Depth = 0;
            cmbFirstTrack.DrawMode = DrawMode.OwnerDrawVariable;
            cmbFirstTrack.DropDownHeight = 174;
            cmbFirstTrack.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFirstTrack.DropDownWidth = 121;
            cmbFirstTrack.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbFirstTrack.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbFirstTrack.FormattingEnabled = true;
            cmbFirstTrack.IntegralHeight = false;
            cmbFirstTrack.ItemHeight = 43;
            cmbFirstTrack.Location = new Point(27, 148);
            cmbFirstTrack.Margin = new Padding(4, 5, 4, 5);
            cmbFirstTrack.MaxDropDownItems = 4;
            cmbFirstTrack.MouseState = MaterialSkin.MouseState.OUT;
            cmbFirstTrack.Name = "cmbFirstTrack";
            cmbFirstTrack.Size = new Size(399, 49);
            cmbFirstTrack.StartIndex = 0;
            cmbFirstTrack.TabIndex = 12;
            cmbFirstTrack.SelectedIndexChanged += cmbFirstTrack_SelectedIndexChanged;
            // 
            // cmbSecondTrack
            // 
            cmbSecondTrack.AutoResize = false;
            cmbSecondTrack.BackColor = Color.FromArgb(255, 255, 255);
            cmbSecondTrack.Depth = 0;
            cmbSecondTrack.DrawMode = DrawMode.OwnerDrawVariable;
            cmbSecondTrack.DropDownHeight = 174;
            cmbSecondTrack.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSecondTrack.DropDownWidth = 121;
            cmbSecondTrack.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbSecondTrack.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbSecondTrack.FormattingEnabled = true;
            cmbSecondTrack.IntegralHeight = false;
            cmbSecondTrack.ItemHeight = 43;
            cmbSecondTrack.Location = new Point(460, 165);
            cmbSecondTrack.Margin = new Padding(4, 5, 4, 5);
            cmbSecondTrack.MaxDropDownItems = 4;
            cmbSecondTrack.MouseState = MaterialSkin.MouseState.OUT;
            cmbSecondTrack.Name = "cmbSecondTrack";
            cmbSecondTrack.Size = new Size(399, 49);
            cmbSecondTrack.StartIndex = 0;
            cmbSecondTrack.TabIndex = 13;
            cmbSecondTrack.SelectedIndexChanged += cmbSecondTrack_SelectedIndexChanged;
            // 
            // lblFirstTrackDescription
            // 
            lblFirstTrackDescription.AutoSize = true;
            lblFirstTrackDescription.Depth = 0;
            lblFirstTrackDescription.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFirstTrackDescription.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblFirstTrackDescription.Location = new Point(27, 124);
            lblFirstTrackDescription.Margin = new Padding(4, 0, 4, 0);
            lblFirstTrackDescription.MouseState = MaterialSkin.MouseState.HOVER;
            lblFirstTrackDescription.Name = "lblFirstTrackDescription";
            lblFirstTrackDescription.Size = new Size(259, 19);
            lblFirstTrackDescription.TabIndex = 14;
            lblFirstTrackDescription.Text = "Description: No description available";
            // 
            // lblSecondTrackDescription
            // 
            lblSecondTrackDescription.AutoSize = true;
            lblSecondTrackDescription.Depth = 0;
            lblSecondTrackDescription.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSecondTrackDescription.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSecondTrackDescription.Location = new Point(64, 418);
            lblSecondTrackDescription.Margin = new Padding(4, 0, 4, 0);
            lblSecondTrackDescription.MouseState = MaterialSkin.MouseState.HOVER;
            lblSecondTrackDescription.Name = "lblSecondTrackDescription";
            lblSecondTrackDescription.Size = new Size(259, 19);
            lblSecondTrackDescription.TabIndex = 15;
            lblSecondTrackDescription.Text = "Description: No description available";
            // 
            // lblReviewSummary
            // 
            lblReviewSummary.AutoSize = true;
            lblReviewSummary.Depth = 0;
            lblReviewSummary.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblReviewSummary.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblReviewSummary.Location = new Point(64, 325);
            lblReviewSummary.Margin = new Padding(4, 0, 4, 0);
            lblReviewSummary.MouseState = MaterialSkin.MouseState.HOVER;
            lblReviewSummary.Name = "lblReviewSummary";
            lblReviewSummary.Size = new Size(124, 19);
            lblReviewSummary.TabIndex = 16;
            lblReviewSummary.Text = "Review Summary";
            // 
            // chkTermsAndConditions
            // 
            chkTermsAndConditions.AutoSize = true;
            chkTermsAndConditions.Depth = 0;
            chkTermsAndConditions.Location = new Point(54, 522);
            chkTermsAndConditions.Margin = new Padding(0);
            chkTermsAndConditions.MouseLocation = new Point(-1, -1);
            chkTermsAndConditions.MouseState = MaterialSkin.MouseState.HOVER;
            chkTermsAndConditions.Name = "chkTermsAndConditions";
            chkTermsAndConditions.ReadOnly = false;
            chkTermsAndConditions.Ripple = true;
            chkTermsAndConditions.Size = new Size(279, 37);
            chkTermsAndConditions.TabIndex = 17;
            chkTermsAndConditions.Text = "I agree to the terms and conditions";
            chkTermsAndConditions.UseVisualStyleBackColor = true;
            chkTermsAndConditions.CheckedChanged += chkTermsAndConditions_CheckedChanged;
            // 
            // btnPrevious
            // 
            btnPrevious.AutoSize = false;
            btnPrevious.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnPrevious.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnPrevious.Depth = 0;
            btnPrevious.HighEmphasis = true;
            btnPrevious.Icon = null;
            btnPrevious.Location = new Point(19, 26);
            btnPrevious.Margin = new Padding(5, 9, 5, 9);
            btnPrevious.MouseState = MaterialSkin.MouseState.HOVER;
            btnPrevious.Name = "btnPrevious";
            btnPrevious.NoAccentTextColor = Color.Empty;
            btnPrevious.Size = new Size(133, 62);
            btnPrevious.TabIndex = 18;
            btnPrevious.Text = "Previous";
            btnPrevious.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnPrevious.UseAccentColor = false;
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.AutoSize = false;
            btnNext.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNext.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNext.Depth = 0;
            btnNext.HighEmphasis = true;
            btnNext.Icon = null;
            btnNext.Location = new Point(184, 28);
            btnNext.Margin = new Padding(5, 9, 5, 9);
            btnNext.MouseState = MaterialSkin.MouseState.HOVER;
            btnNext.Name = "btnNext";
            btnNext.NoAccentTextColor = Color.Empty;
            btnNext.Size = new Size(133, 62);
            btnNext.TabIndex = 19;
            btnNext.Text = "Next";
            btnNext.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNext.UseAccentColor = false;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.AutoSize = false;
            btnSubmit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSubmit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSubmit.Depth = 0;
            btnSubmit.HighEmphasis = true;
            btnSubmit.Icon = null;
            btnSubmit.Location = new Point(339, 28);
            btnSubmit.Margin = new Padding(5, 9, 5, 9);
            btnSubmit.MouseState = MaterialSkin.MouseState.HOVER;
            btnSubmit.Name = "btnSubmit";
            btnSubmit.NoAccentTextColor = Color.Empty;
            btnSubmit.Size = new Size(200, 62);
            btnSubmit.TabIndex = 20;
            btnSubmit.Text = "Submit Application";
            btnSubmit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSubmit.UseAccentColor = false;
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelTop);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(4, 98);
            panelMain.Margin = new Padding(4, 5, 4, 5);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1325, 974);
            panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(panelNavigation);
            panelContent.Controls.Add(lblSecondTrackDescription);
            panelContent.Controls.Add(lblReviewSummary);
            panelContent.Controls.Add(panelSteps);
            panelContent.Controls.Add(lblBranchDescription);
            panelContent.Controls.Add(lblStepDescription);
            panelContent.Controls.Add(lblStepTitle);
            panelContent.Controls.Add(lblSubtitle);
            panelContent.Controls.Add(lblTitle);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 70);
            panelContent.Margin = new Padding(4, 5, 4, 5);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1325, 904);
            panelContent.TabIndex = 1;
            // 
            // panelNavigation
            // 
            panelNavigation.Controls.Add(btnSubmit);
            panelNavigation.Controls.Add(btnNext);
            panelNavigation.Controls.Add(btnPrevious);
            panelNavigation.Location = new Point(109, 628);
            panelNavigation.Margin = new Padding(4, 5, 4, 5);
            panelNavigation.Name = "panelNavigation";
            panelNavigation.Size = new Size(571, 110);
            panelNavigation.TabIndex = 5;
            // 
            // panelSteps
            // 
            panelSteps.AutoScroll = true;
            panelSteps.Controls.Add(chkTermsAndConditions);
            panelSteps.Controls.Add(cmbSecondTrack);
            panelSteps.Controls.Add(cmbFirstTrack);
            panelSteps.Controls.Add(cmbBranch);
            panelSteps.Controls.Add(lblFirstTrackDescription);
            panelSteps.Controls.Add(txtAddress);
            panelSteps.Controls.Add(cmbGender);
            panelSteps.Controls.Add(txtAge);
            panelSteps.Controls.Add(txtPhone);
            panelSteps.Controls.Add(txtEmail);
            panelSteps.Controls.Add(txtFullName);
            panelSteps.Location = new Point(448, 31);
            panelSteps.Margin = new Padding(4, 5, 4, 5);
            panelSteps.Name = "panelSteps";
            panelSteps.Size = new Size(850, 858);
            panelSteps.TabIndex = 4;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnBackToHome);
            panelTop.Controls.Add(btnTheme);
            panelTop.Controls.Add(cmbLanguage);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1325, 70);
            panelTop.TabIndex = 0;
            // 
            // ApplicantApplicationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1333, 1077);
            Controls.Add(panelMain);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ApplicantApplicationForm";
            Padding = new Padding(4, 98, 4, 5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Apply for Legacy";
            Load += ApplicantApplicationForm_Load;
            panelMain.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            panelNavigation.ResumeLayout(false);
            panelSteps.ResumeLayout(false);
            panelSteps.PerformLayout();
            panelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        private MaterialSkin.Controls.MaterialLabel lblTitle;
        private MaterialSkin.Controls.MaterialLabel lblSubtitle;
        private MaterialSkin.Controls.MaterialLabel lblStepTitle;
        private MaterialSkin.Controls.MaterialLabel lblStepDescription;
        private MaterialSkin.Controls.MaterialComboBox cmbLanguage;
        private MaterialSkin.Controls.MaterialButton btnTheme;
        private MaterialSkin.Controls.MaterialButton btnBackToHome;
        
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelSteps;
        private System.Windows.Forms.Panel panelNavigation;
    }
}
