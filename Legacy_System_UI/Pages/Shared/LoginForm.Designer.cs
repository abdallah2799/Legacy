namespace Legacy_System_UI.Pages.Shared
{
    partial class LoginForm 
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
            ThemeSwitchBtn = new MaterialSkin.Controls.MaterialSwitch();
            cmbLanguage = new MaterialSkin.Controls.MaterialComboBox();
            Panel_Login = new Panel();
            Lb_Password = new MaterialSkin.Controls.MaterialLabel();
            Lb_LoginOption = new MaterialSkin.Controls.MaterialLabel();
            Lb_WelcomBack = new MaterialSkin.Controls.MaterialLabel();
            Btn_Login = new MaterialSkin.Controls.MaterialButton();
            Tb_Password = new MaterialSkin.Controls.MaterialTextBox();
            Tb_LoginOption = new MaterialSkin.Controls.MaterialTextBox();
            Panel_Login.SuspendLayout();
            SuspendLayout();
            // 
            // GoBackHomeBtn
            // 
            GoBackHomeBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GoBackHomeBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            GoBackHomeBtn.Depth = 0;
            GoBackHomeBtn.HighEmphasis = true;
            GoBackHomeBtn.Icon = null;
            GoBackHomeBtn.Location = new Point(7, 72);
            GoBackHomeBtn.Margin = new Padding(4, 4, 4, 4);
            GoBackHomeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            GoBackHomeBtn.Name = "GoBackHomeBtn";
            GoBackHomeBtn.NoAccentTextColor = Color.Empty;
            GoBackHomeBtn.Size = new Size(148, 36);
            GoBackHomeBtn.TabIndex = 2;
            GoBackHomeBtn.Text = "<-  Go back home";
            GoBackHomeBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            GoBackHomeBtn.UseAccentColor = false;
            GoBackHomeBtn.UseVisualStyleBackColor = true;
            GoBackHomeBtn.Click += GoBackHomeBtn_Click;
            // 
            // ThemeSwitchBtn
            // 
            ThemeSwitchBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ThemeSwitchBtn.AutoSize = true;
            ThemeSwitchBtn.Depth = 0;
            ThemeSwitchBtn.Location = new Point(281, 457);
            ThemeSwitchBtn.Margin = new Padding(0);
            ThemeSwitchBtn.MouseLocation = new Point(-1, -1);
            ThemeSwitchBtn.MouseState = MaterialSkin.MouseState.HOVER;
            ThemeSwitchBtn.Name = "ThemeSwitchBtn";
            ThemeSwitchBtn.Ripple = true;
            ThemeSwitchBtn.Size = new Size(138, 37);
            ThemeSwitchBtn.TabIndex = 4;
            ThemeSwitchBtn.Text = "Light Mode";
            ThemeSwitchBtn.UseVisualStyleBackColor = true;
            ThemeSwitchBtn.CheckedChanged += ToggleTheme;
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
            cmbLanguage.Location = new Point(5, 457);
            cmbLanguage.Margin = new Padding(3, 2, 3, 2);
            cmbLanguage.MaxDropDownItems = 4;
            cmbLanguage.MouseState = MaterialSkin.MouseState.OUT;
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(133, 49);
            cmbLanguage.StartIndex = 0;
            cmbLanguage.TabIndex = 3;
            cmbLanguage.SelectedIndexChanged += ChangeLanguage;
            // 
            // Panel_Login
            // 
            Panel_Login.Controls.Add(Lb_Password);
            Panel_Login.Controls.Add(Lb_LoginOption);
            Panel_Login.Controls.Add(Lb_WelcomBack);
            Panel_Login.Controls.Add(Btn_Login);
            Panel_Login.Controls.Add(Tb_Password);
            Panel_Login.Controls.Add(Tb_LoginOption);
            Panel_Login.Location = new Point(33, 124);
            Panel_Login.Margin = new Padding(3, 2, 3, 2);
            Panel_Login.Name = "Panel_Login";
            Panel_Login.Size = new Size(358, 299);
            Panel_Login.TabIndex = 5;
            // 
            // Lb_Password
            // 
            Lb_Password.AutoSize = true;
            Lb_Password.Depth = 0;
            Lb_Password.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb_Password.Location = new Point(25, 142);
            Lb_Password.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_Password.Name = "Lb_Password";
            Lb_Password.Size = new Size(71, 19);
            Lb_Password.TabIndex = 2;
            Lb_Password.Text = "Password";
            // 
            // Lb_LoginOption
            // 
            Lb_LoginOption.AutoSize = true;
            Lb_LoginOption.Depth = 0;
            Lb_LoginOption.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb_LoginOption.Location = new Point(25, 60);
            Lb_LoginOption.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_LoginOption.Name = "Lb_LoginOption";
            Lb_LoginOption.Size = new Size(131, 19);
            Lb_LoginOption.TabIndex = 2;
            Lb_LoginOption.Text = "Username / Email ";
            // 
            // Lb_WelcomBack
            // 
            Lb_WelcomBack.AutoSize = true;
            Lb_WelcomBack.Depth = 0;
            Lb_WelcomBack.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            Lb_WelcomBack.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            Lb_WelcomBack.Location = new Point(63, 9);
            Lb_WelcomBack.MouseState = MaterialSkin.MouseState.HOVER;
            Lb_WelcomBack.Name = "Lb_WelcomBack";
            Lb_WelcomBack.Size = new Size(233, 41);
            Lb_WelcomBack.TabIndex = 2;
            Lb_WelcomBack.Text = "Welcome Back ";
            // 
            // Btn_Login
            // 
            Btn_Login.AutoSize = false;
            Btn_Login.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_Login.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_Login.Depth = 0;
            Btn_Login.HighEmphasis = true;
            Btn_Login.Icon = null;
            Btn_Login.Location = new Point(109, 225);
            Btn_Login.Margin = new Padding(4, 4, 4, 4);
            Btn_Login.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_Login.Name = "Btn_Login";
            Btn_Login.NoAccentTextColor = Color.Empty;
            Btn_Login.Size = new Size(138, 27);
            Btn_Login.TabIndex = 1;
            Btn_Login.Text = "Login";
            Btn_Login.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_Login.UseAccentColor = false;
            Btn_Login.UseVisualStyleBackColor = true;
            Btn_Login.Click += Btn_Login_Click;
            // 
            // Tb_Password
            // 
            Tb_Password.AnimateReadOnly = false;
            Tb_Password.BorderStyle = BorderStyle.None;
            Tb_Password.Depth = 0;
            Tb_Password.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Tb_Password.LeadingIcon = null;
            Tb_Password.Location = new Point(25, 164);
            Tb_Password.Margin = new Padding(3, 2, 3, 2);
            Tb_Password.MaxLength = 50;
            Tb_Password.MouseState = MaterialSkin.MouseState.OUT;
            Tb_Password.Multiline = false;
            Tb_Password.Name = "Tb_Password";
            Tb_Password.Password = true;
            Tb_Password.Size = new Size(312, 50);
            Tb_Password.TabIndex = 0;
            Tb_Password.Text = "";
            Tb_Password.TrailingIcon = null;
            // 
            // Tb_LoginOption
            // 
            Tb_LoginOption.AnimateReadOnly = false;
            Tb_LoginOption.BorderStyle = BorderStyle.None;
            Tb_LoginOption.Depth = 0;
            Tb_LoginOption.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Tb_LoginOption.LeadingIcon = null;
            Tb_LoginOption.Location = new Point(25, 82);
            Tb_LoginOption.Margin = new Padding(3, 2, 3, 2);
            Tb_LoginOption.MaxLength = 50;
            Tb_LoginOption.MouseState = MaterialSkin.MouseState.OUT;
            Tb_LoginOption.Multiline = false;
            Tb_LoginOption.Name = "Tb_LoginOption";
            Tb_LoginOption.Size = new Size(312, 50);
            Tb_LoginOption.TabIndex = 0;
            Tb_LoginOption.Text = "";
            Tb_LoginOption.TrailingIcon = null;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 498);
            Controls.Add(Panel_Login);
            Controls.Add(ThemeSwitchBtn);
            Controls.Add(cmbLanguage);
            Controls.Add(GoBackHomeBtn);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MaximumSize = new Size(430, 498);
            MinimumSize = new Size(430, 498);
            Name = "LoginForm";
            Padding = new Padding(3, 48, 3, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Panel_Login.ResumeLayout(false);
            Panel_Login.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private MaterialSkin.Controls.MaterialButton GoBackHomeBtn;
        private MaterialSkin.Controls.MaterialSwitch ThemeSwitchBtn;
        private MaterialSkin.Controls.MaterialComboBox cmbLanguage;
        private Panel Panel_Login;
        private MaterialSkin.Controls.MaterialLabel Lb_Password;
        private MaterialSkin.Controls.MaterialLabel Lb_LoginOption;
        private MaterialSkin.Controls.MaterialLabel Lb_WelcomBack;
        private MaterialSkin.Controls.MaterialButton Btn_Login;
        private MaterialSkin.Controls.MaterialTextBox Tb_Password;
        private MaterialSkin.Controls.MaterialTextBox Tb_LoginOption;
    }
}