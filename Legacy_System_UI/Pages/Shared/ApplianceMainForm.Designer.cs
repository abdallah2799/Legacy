namespace Legacy_System_UI.Pages.Shared
{
    partial class ApplianceMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GoBackHomeBtn = new MaterialSkin.Controls.MaterialButton();
            cmbLanguage = new MaterialSkin.Controls.MaterialComboBox();
            ThemeSwitchBtn = new MaterialSkin.Controls.MaterialSwitch();
            Panel_Application = new Panel();
            Btn_Apply = new MaterialSkin.Controls.MaterialButton();
            Cmb_Gender = new MaterialSkin.Controls.MaterialComboBox();
            Cmb_Branch = new MaterialSkin.Controls.MaterialComboBox();
            Cmb_PrimaryTrack = new MaterialSkin.Controls.MaterialComboBox();
            Cmb_SecondaryTrack = new MaterialSkin.Controls.MaterialComboBox();
            Lb_Gender = new MaterialSkin.Controls.MaterialLabel();
            Lb_Address = new MaterialSkin.Controls.MaterialLabel();
            Lb_Age = new MaterialSkin.Controls.MaterialLabel();
            Lb_Email = new MaterialSkin.Controls.MaterialLabel();
            Lb_SecondaryTrack = new MaterialSkin.Controls.MaterialLabel();
            Lb_PrimaryTrack = new MaterialSkin.Controls.MaterialLabel();
            Lb_Branch = new MaterialSkin.Controls.MaterialLabel();
            Lb_Phone = new MaterialSkin.Controls.MaterialLabel();
            Lb_JoinUs = new MaterialSkin.Controls.MaterialLabel();
            Lb_FullName = new MaterialSkin.Controls.MaterialLabel();
            Tb_Address = new MaterialSkin.Controls.MaterialTextBox();
            Tb_Age = new MaterialSkin.Controls.MaterialTextBox();
            Tb_Email = new MaterialSkin.Controls.MaterialTextBox();
            Tb_Phone = new MaterialSkin.Controls.MaterialTextBox();
            Tb_Name = new MaterialSkin.Controls.MaterialTextBox();
            Panel_Application.SuspendLayout();
            SuspendLayout();
            // 
            // GoBackHomeBtn
            // 
            GoBackHomeBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GoBackHomeBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            GoBackHomeBtn.Depth = 0;
            GoBackHomeBtn.HighEmphasis = true;
            GoBackHomeBtn.Icon = null;
            GoBackHomeBtn.Location = new Point(9, 70);
            GoBackHomeBtn.Margin = new Padding(4, 6, 4, 6);
            GoBackHomeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            GoBackHomeBtn.Name = "GoBackHomeBtn";
            GoBackHomeBtn.NoAccentTextColor = Color.Empty;
            GoBackHomeBtn.Size = new Size(148, 36);
            GoBackHomeBtn.TabIndex = 3;
            GoBackHomeBtn.Text = "<-  Go back home";
            GoBackHomeBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            GoBackHomeBtn.UseAccentColor = false;
            GoBackHomeBtn.UseVisualStyleBackColor = true;
            GoBackHomeBtn.Click += GoBackHomeBtn_Click;
            // 
            // cmbLanguage
            // 
            cmbLanguage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            cmbLanguage.Items.AddRange(new object[] { "English", "العربية" });
            cmbLanguage.Location = new Point(9, 747);
            cmbLanguage.MaxDropDownItems = 4;
            cmbLanguage.MouseState = MaterialSkin.MouseState.OUT;
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(151, 49);
            cmbLanguage.StartIndex = 0;
            cmbLanguage.TabIndex = 4;
            cmbLanguage.SelectedIndexChanged += ChangeLanguage;
            // 
            // ThemeSwitchBtn
            // 
            ThemeSwitchBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ThemeSwitchBtn.AutoSize = true;
            ThemeSwitchBtn.Depth = 0;
            ThemeSwitchBtn.Location = new Point(650, 759);
            ThemeSwitchBtn.Margin = new Padding(0);
            ThemeSwitchBtn.MouseLocation = new Point(-1, -1);
            ThemeSwitchBtn.MouseState = MaterialSkin.MouseState.HOVER;
            ThemeSwitchBtn.Name = "ThemeSwitchBtn";
            ThemeSwitchBtn.Ripple = true;
            ThemeSwitchBtn.Size = new Size(138, 37);
            ThemeSwitchBtn.TabIndex = 5;
            ThemeSwitchBtn.Text = "Light Mode";
            ThemeSwitchBtn.UseVisualStyleBackColor = true;
            ThemeSwitchBtn.CheckedChanged += ToggleTheme;
            // 
            // Panel_Application
            // 
            Panel_Application.Controls.Add(Btn_Apply);
            Panel_Application.Controls.Add(Cmb_Gender);
            Panel_Application.Controls.Add(Cmb_Branch);
            Panel_Application.Controls.Add(Cmb_PrimaryTrack);
            Panel_Application.Controls.Add(Cmb_SecondaryTrack);
            Panel_Application.Controls.Add(Lb_Gender);
            Panel_Application.Controls.Add(Lb_Address);
            Panel_Application.Controls.Add(Lb_Age);
            Panel_Application.Controls.Add(Lb_Email);
            Panel_Application.Controls.Add(Lb_SecondaryTrack);
            Panel_Application.Controls.Add(Lb_PrimaryTrack);
            Panel_Application.Controls.Add(Lb_Branch);
            Panel_Application.Controls.Add(Lb_Phone);
            Panel_Application.Controls.Add(Lb_JoinUs);
            Panel_Application.Controls.Add(Lb_FullName);
            Panel_Application.Controls.Add(Tb_Address);
            Panel_Application.Controls.Add(Tb_Age);
            Panel_Application.Controls.Add(Tb_Email);
            Panel_Application.Controls.Add(Tb_Phone);
            Panel_Application.Controls.Add(Tb_Name);
            Panel_Application.Location = new Point(18, 104);
            Panel_Application.Name = "Panel_Application";
            Panel_Application.Size = new Size(737, 616);
            Panel_Application.TabIndex = 6;
            // 
            // Btn_Apply
            // 
            Btn_Apply.AutoSize = false;
            Btn_Apply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_Apply.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_Apply.Depth = 0;
            Btn_Apply.HighEmphasis = true;
            Btn_Apply.Icon = null;
            Btn_Apply.Location = new Point(423, 535);
            Btn_Apply.Margin = new Padding(4, 6, 4, 6);
            Btn_Apply.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_Apply.Name = "Btn_Apply";
            Btn_Apply.NoAccentTextColor = Color.Empty;
            Btn_Apply.Size = new Size(283, 45);
            Btn_Apply.TabIndex = 9;
            Btn_Apply.Text = "Confirm Application";
            Btn_Apply.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_Apply.UseAccentColor = false;
            Btn_Apply.UseVisualStyleBackColor = true;
            Btn_Apply.Click += Btn_Apply_Click;
            // 
            // Cmb_Gender
            // 
            Cmb_Gender.AutoResize = false;
            Cmb_Gender.BackColor = Color.FromArgb(255, 255, 255);
            Cmb_Gender.Depth = 0;
            Cmb_Gender.DrawMode = DrawMode.OwnerDrawVariable;
            Cmb_Gender.DropDownHeight = 174;
            Cmb_Gender.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_Gender.DropDownWidth = 121;
            Cmb_Gender.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            Cmb_Gender.ForeColor = Color.FromArgb(222, 0, 0, 0);
            Cmb_Gender.FormattingEnabled = true;
            Cmb_Gender.IntegralHeight = false;
            Cmb_Gender.ItemHeight = 43;
            Cmb_Gender.Location = new Point(54, 535);
            Cmb_Gender.MaxDropDownItems = 4;
            Cmb_Gender.MouseState = MaterialSkin.MouseState.OUT;
            Cmb_Gender.Name = "Cmb_Gender";
            Cmb_Gender.Size = new Size(283, 49);
            Cmb_Gender.StartIndex = 0;
            Cmb_Gender.TabIndex = 4;
            
            // 
            // Cmb_Branch
            // 
            Cmb_Branch.AutoResize = false;
            Cmb_Branch.BackColor = Color.FromArgb(255, 255, 255);
            Cmb_Branch.Depth = 0;
            Cmb_Branch.DrawMode = DrawMode.OwnerDrawVariable;
            Cmb_Branch.DropDownHeight = 174;
            Cmb_Branch.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_Branch.DropDownWidth = 121;
            Cmb_Branch.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            Cmb_Branch.ForeColor = Color.FromArgb(222, 0, 0, 0);
            Cmb_Branch.FormattingEnabled = true;
            Cmb_Branch.IntegralHeight = false;
            Cmb_Branch.ItemHeight = 43;
            Cmb_Branch.Location = new Point(423, 228);
            Cmb_Branch.MaxDropDownItems = 4;
            Cmb_Branch.MouseState = MaterialSkin.MouseState.OUT;
            Cmb_Branch.Name = "Cmb_Branch";
            Cmb_Branch.Size = new Size(283, 49);
            Cmb_Branch.StartIndex = 0;
            Cmb_Branch.TabIndex = 6;
            Cmb_Branch.SelectedIndexChanged += UpdateBranchTrack;
            
            // 
            // Cmb_PrimaryTrack
            // 
            Cmb_PrimaryTrack.AutoResize = false;
            Cmb_PrimaryTrack.BackColor = Color.FromArgb(255, 255, 255);
            Cmb_PrimaryTrack.Depth = 0;
            Cmb_PrimaryTrack.DrawMode = DrawMode.OwnerDrawVariable;
            Cmb_PrimaryTrack.DropDownHeight = 174;
            Cmb_PrimaryTrack.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_PrimaryTrack.DropDownWidth = 121;
            Cmb_PrimaryTrack.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            Cmb_PrimaryTrack.ForeColor = Color.FromArgb(222, 0, 0, 0);
            Cmb_PrimaryTrack.FormattingEnabled = true;
            Cmb_PrimaryTrack.IntegralHeight = false;
            Cmb_PrimaryTrack.ItemHeight = 43;
            Cmb_PrimaryTrack.Location = new Point(423, 337);
            Cmb_PrimaryTrack.MaxDropDownItems = 4;
            Cmb_PrimaryTrack.MouseState = MaterialSkin.MouseState.OUT;
            Cmb_PrimaryTrack.Name = "Cmb_PrimaryTrack";
            Cmb_PrimaryTrack.Size = new Size(283, 49);
            Cmb_PrimaryTrack.StartIndex = 0;
            Cmb_PrimaryTrack.TabIndex = 7;
            Cmb_PrimaryTrack.Leave += EnsureUniqe;
            // 
            // Cmb_SecondaryTrack
            // 
            Cmb_SecondaryTrack.AutoResize = false;
            Cmb_SecondaryTrack.BackColor = Color.FromArgb(255, 255, 255);
            Cmb_SecondaryTrack.Depth = 0;
            Cmb_SecondaryTrack.DrawMode = DrawMode.OwnerDrawVariable;
            Cmb_SecondaryTrack.DropDownHeight = 174;
            Cmb_SecondaryTrack.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_SecondaryTrack.DropDownWidth = 121;
            Cmb_SecondaryTrack.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            Cmb_SecondaryTrack.ForeColor = Color.FromArgb(222, 0, 0, 0);
            Cmb_SecondaryTrack.FormattingEnabled = true;
            Cmb_SecondaryTrack.IntegralHeight = false;
            Cmb_SecondaryTrack.ItemHeight = 43;
            Cmb_SecondaryTrack.Location = new Point(423, 438);
            Cmb_SecondaryTrack.MaxDropDownItems = 4;
            Cmb_SecondaryTrack.MouseState = MaterialSkin.MouseState.OUT;
            Cmb_SecondaryTrack.Name = "Cmb_SecondaryTrack";
            Cmb_SecondaryTrack.Size = new Size(283, 49);
            Cmb_SecondaryTrack.StartIndex = 0;
            Cmb_SecondaryTrack.TabIndex = 8;
            Cmb_SecondaryTrack.Leave += EnsureUniqe;
            // 
            // Lb_Gender
            // 
            Lb_Gender.AutoSize = true;
            Lb_Gender.Depth = 0;
            Lb_Gender.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb_Gender.Location = new Point(54, 513);
            Lb_Gender.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_Gender.Name = "Lb_Gender";
            Lb_Gender.Size = new Size(51, 19);
            Lb_Gender.TabIndex = 1;
            Lb_Gender.Text = "Gender";
            // 
            // Lb_Address
            // 
            Lb_Address.AutoSize = true;
            Lb_Address.Depth = 0;
            Lb_Address.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb_Address.Location = new Point(54, 417);
            Lb_Address.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_Address.Name = "Lb_Address";
            Lb_Address.Size = new Size(58, 19);
            Lb_Address.TabIndex = 1;
            Lb_Address.Text = "Address";
            // 
            // Lb_Age
            // 
            Lb_Age.AutoSize = true;
            Lb_Age.Depth = 0;
            Lb_Age.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb_Age.Location = new Point(54, 314);
            Lb_Age.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_Age.Name = "Lb_Age";
            Lb_Age.Size = new Size(28, 19);
            Lb_Age.TabIndex = 1;
            Lb_Age.Text = "Age";
            // 
            // Lb_Email
            // 
            Lb_Email.AutoSize = true;
            Lb_Email.Depth = 0;
            Lb_Email.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb_Email.Location = new Point(54, 205);
            Lb_Email.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_Email.Name = "Lb_Email";
            Lb_Email.Size = new Size(41, 19);
            Lb_Email.TabIndex = 1;
            Lb_Email.Text = "Email";
            // 
            // Lb_SecondaryTrack
            // 
            Lb_SecondaryTrack.AutoSize = true;
            Lb_SecondaryTrack.Depth = 0;
            Lb_SecondaryTrack.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb_SecondaryTrack.Location = new Point(423, 418);
            Lb_SecondaryTrack.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_SecondaryTrack.Name = "Lb_SecondaryTrack";
            Lb_SecondaryTrack.Size = new Size(120, 19);
            Lb_SecondaryTrack.TabIndex = 1;
            Lb_SecondaryTrack.Text = "Secondary Track";
            // 
            // Lb_PrimaryTrack
            // 
            Lb_PrimaryTrack.AutoSize = true;
            Lb_PrimaryTrack.Depth = 0;
            Lb_PrimaryTrack.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb_PrimaryTrack.Location = new Point(423, 314);
            Lb_PrimaryTrack.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_PrimaryTrack.Name = "Lb_PrimaryTrack";
            Lb_PrimaryTrack.Size = new Size(100, 19);
            Lb_PrimaryTrack.TabIndex = 1;
            Lb_PrimaryTrack.Text = "Primary Track";
            // 
            // Lb_Branch
            // 
            Lb_Branch.AutoSize = true;
            Lb_Branch.Depth = 0;
            Lb_Branch.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb_Branch.Location = new Point(423, 205);
            Lb_Branch.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_Branch.Name = "Lb_Branch";
            Lb_Branch.Size = new Size(51, 19);
            Lb_Branch.TabIndex = 1;
            Lb_Branch.Text = "Branch";
            // 
            // Lb_Phone
            // 
            Lb_Phone.AutoSize = true;
            Lb_Phone.Depth = 0;
            Lb_Phone.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb_Phone.Location = new Point(423, 98);
            Lb_Phone.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_Phone.Name = "Lb_Phone";
            Lb_Phone.Size = new Size(46, 19);
            Lb_Phone.TabIndex = 1;
            Lb_Phone.Text = "Phone";
            // 
            // Lb_JoinUs
            // 
            Lb_JoinUs.AutoSize = true;
            Lb_JoinUs.Depth = 0;
            Lb_JoinUs.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            Lb_JoinUs.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            Lb_JoinUs.HighEmphasis = true;
            Lb_JoinUs.Location = new Point(54, 18);
            Lb_JoinUs.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_JoinUs.Name = "Lb_JoinUs";
            Lb_JoinUs.Size = new Size(155, 58);
            Lb_JoinUs.TabIndex = 1;
            Lb_JoinUs.Text = "Join us";
            // 
            // Lb_FullName
            // 
            Lb_FullName.AutoSize = true;
            Lb_FullName.Depth = 0;
            Lb_FullName.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb_FullName.Location = new Point(54, 98);
            Lb_FullName.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_FullName.Name = "Lb_FullName";
            Lb_FullName.Size = new Size(73, 19);
            Lb_FullName.TabIndex = 1;
            Lb_FullName.Text = "Full Name";
            // 
            // Tb_Address
            // 
            Tb_Address.AnimateReadOnly = false;
            Tb_Address.BorderStyle = BorderStyle.None;
            Tb_Address.Depth = 0;
            Tb_Address.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Tb_Address.LeadingIcon = null;
            Tb_Address.Location = new Point(54, 439);
            Tb_Address.MaxLength = 50;
            Tb_Address.MouseState = MaterialSkin.MouseState.OUT;
            Tb_Address.Multiline = false;
            Tb_Address.Name = "Tb_Address";
            Tb_Address.Size = new Size(283, 50);
            Tb_Address.TabIndex = 3;
            Tb_Address.Text = "";
            Tb_Address.TrailingIcon = null;
            // 
            // Tb_Age
            // 
            Tb_Age.AnimateReadOnly = false;
            Tb_Age.BorderStyle = BorderStyle.None;
            Tb_Age.Depth = 0;
            Tb_Age.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Tb_Age.LeadingIcon = null;
            Tb_Age.Location = new Point(54, 336);
            Tb_Age.MaxLength = 50;
            Tb_Age.MouseState = MaterialSkin.MouseState.OUT;
            Tb_Age.Multiline = false;
            Tb_Age.Name = "Tb_Age";
            Tb_Age.Size = new Size(283, 50);
            Tb_Age.TabIndex = 2;
            Tb_Age.Text = "";
            Tb_Age.TrailingIcon = null;
            Tb_Age.KeyDown += AllowNumbersOnly;
            Tb_Age.Leave += SetRange;
            // 
            // Tb_Email
            // 
            Tb_Email.AnimateReadOnly = false;
            Tb_Email.BorderStyle = BorderStyle.None;
            Tb_Email.Depth = 0;
            Tb_Email.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Tb_Email.LeadingIcon = null;
            Tb_Email.Location = new Point(54, 227);
            Tb_Email.MaxLength = 50;
            Tb_Email.MouseState = MaterialSkin.MouseState.OUT;
            Tb_Email.Multiline = false;
            Tb_Email.Name = "Tb_Email";
            Tb_Email.Size = new Size(283, 50);
            Tb_Email.TabIndex = 1;
            Tb_Email.Text = "";
            Tb_Email.TrailingIcon = null;
            // 
            // Tb_Phone
            // 
            Tb_Phone.AnimateReadOnly = false;
            Tb_Phone.BorderStyle = BorderStyle.None;
            Tb_Phone.Depth = 0;
            Tb_Phone.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Tb_Phone.LeadingIcon = null;
            Tb_Phone.Location = new Point(423, 120);
            Tb_Phone.MaxLength = 50;
            Tb_Phone.MouseState = MaterialSkin.MouseState.OUT;
            Tb_Phone.Multiline = false;
            Tb_Phone.Name = "Tb_Phone";
            Tb_Phone.Size = new Size(283, 50);
            Tb_Phone.TabIndex = 5;
            Tb_Phone.Text = "";
            Tb_Phone.TrailingIcon = null;
            Tb_Phone.KeyDown += AllowNumbersOnly;
            // 
            // Tb_Name
            // 
            Tb_Name.AnimateReadOnly = false;
            Tb_Name.BorderStyle = BorderStyle.None;
            Tb_Name.Depth = 0;
            Tb_Name.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Tb_Name.LeadingIcon = null;
            Tb_Name.Location = new Point(54, 120);
            Tb_Name.MaxLength = 50;
            Tb_Name.MouseState = MaterialSkin.MouseState.OUT;
            Tb_Name.Multiline = false;
            Tb_Name.Name = "Tb_Name";
            Tb_Name.Size = new Size(283, 50);
            Tb_Name.TabIndex = 0;
            Tb_Name.Text = "";
            Tb_Name.TrailingIcon = null;
            // 
            // ApplianceMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 811);
            Controls.Add(Panel_Application);
            Controls.Add(ThemeSwitchBtn);
            Controls.Add(cmbLanguage);
            Controls.Add(GoBackHomeBtn);
            MaximizeBox = false;
            Name = "ApplianceMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Application Form";
            Load += ApplianceMainForm_Load;
            Panel_Application.ResumeLayout(false);
            Panel_Application.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton GoBackHomeBtn;
        private MaterialSkin.Controls.MaterialComboBox cmbLanguage;
        private MaterialSkin.Controls.MaterialSwitch ThemeSwitchBtn;
        private Panel Panel_Application;
        private MaterialSkin.Controls.MaterialTextBox Tb_Name;
        private MaterialSkin.Controls.MaterialLabel Lb_Address;
        private MaterialSkin.Controls.MaterialLabel Lb_Age;
        private MaterialSkin.Controls.MaterialLabel Lb_Email;
        private MaterialSkin.Controls.MaterialLabel Lb_SecondaryTrack;
        private MaterialSkin.Controls.MaterialLabel Lb_PrimaryTrack;
        private MaterialSkin.Controls.MaterialLabel Lb_Branch;
        private MaterialSkin.Controls.MaterialLabel Lb_Phone;
        private MaterialSkin.Controls.MaterialLabel Lb_FullName;
        private MaterialSkin.Controls.MaterialButton Btn_Apply;
        private MaterialSkin.Controls.MaterialComboBox Cmb_SecondaryTrack;
        private MaterialSkin.Controls.MaterialLabel Lb_Gender;
        private MaterialSkin.Controls.MaterialLabel Lb_JoinUs;
        private MaterialSkin.Controls.MaterialComboBox Cmb_Gender;
        private MaterialSkin.Controls.MaterialTextBox Tb_Address;
        private MaterialSkin.Controls.MaterialTextBox Tb_Age;
        private MaterialSkin.Controls.MaterialTextBox Tb_Email;
        private MaterialSkin.Controls.MaterialTextBox Tb_Phone;
        private MaterialSkin.Controls.MaterialComboBox Cmb_Branch;
        private MaterialSkin.Controls.MaterialComboBox Cmb_PrimaryTrack;
    }
}