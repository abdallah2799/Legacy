using MaterialSkin;
using MaterialSkin.Controls;
using Legacy_System_UI.Infrastructure;

namespace Legacy_System_UI.Pages.Shared
{
    public partial class StartupForm : MaterialForm
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
            cmbLanguage = new MaterialComboBox();
            ThemeSwitchBtn = new MaterialSwitch();
            Lb_Welcome = new MaterialLabel();
            Lb_Slogan = new MaterialLabel();
            Login_Btn = new MaterialButton();
            Apply_Btn = new MaterialButton();
            QB_Btn = new MaterialButton();
            CheckStatus_Btn = new MaterialButton();
            SuspendLayout();
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
            cmbLanguage.Location = new Point(6, 697);
            cmbLanguage.MaxDropDownItems = 4;
            cmbLanguage.MouseState = MouseState.OUT;
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(151, 49);
            cmbLanguage.StartIndex = 0;
            cmbLanguage.TabIndex = 1;
            cmbLanguage.SelectedIndexChanged += ChangeLanguage;
            // 
            // ThemeSwitchBtn
            // 
            ThemeSwitchBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ThemeSwitchBtn.AutoSize = true;
            ThemeSwitchBtn.Depth = 0;
            ThemeSwitchBtn.Location = new Point(422, 709);
            ThemeSwitchBtn.Margin = new Padding(0);
            ThemeSwitchBtn.MouseLocation = new Point(-1, -1);
            ThemeSwitchBtn.MouseState = MouseState.HOVER;
            ThemeSwitchBtn.Name = "ThemeSwitchBtn";
            ThemeSwitchBtn.Ripple = true;
            ThemeSwitchBtn.Size = new Size(138, 37);
            ThemeSwitchBtn.TabIndex = 2;
            ThemeSwitchBtn.Text = "Light Mode";
            ThemeSwitchBtn.UseVisualStyleBackColor = true;
            ThemeSwitchBtn.CheckedChanged += ToggleTheme;
            // 
            // Lb_Welcome
            // 
            Lb_Welcome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Lb_Welcome.AutoSize = true;
            Lb_Welcome.Depth = 0;
            Lb_Welcome.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            Lb_Welcome.FontType = MaterialSkinManager.fontType.H3;
            Lb_Welcome.Location = new Point(78, 109);
            Lb_Welcome.MouseState = MouseState.HOVER;
            Lb_Welcome.Name = "Lb_Welcome";
            Lb_Welcome.Size = new Size(432, 58);
            Lb_Welcome.TabIndex = 3;
            Lb_Welcome.Text = "Welcome To Legacy";
            // 
            // Lb_Slogan
            // 
            Lb_Slogan.AutoSize = true;
            Lb_Slogan.Depth = 0;
            Lb_Slogan.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            Lb_Slogan.FontType = MaterialSkinManager.fontType.H6;
            Lb_Slogan.Location = new Point(117, 177);
            Lb_Slogan.MouseState = MouseState.HOVER;
            Lb_Slogan.Name = "Lb_Slogan";
            Lb_Slogan.Size = new Size(342, 24);
            Lb_Slogan.TabIndex = 4;
            Lb_Slogan.Text = "Your Gateway to Academic Excellence";
            // 
            // Login_Btn
            // 
            Login_Btn.AutoSize = false;
            Login_Btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Login_Btn.Density = MaterialButton.MaterialButtonDensity.Default;
            Login_Btn.Depth = 0;
            Login_Btn.HighEmphasis = true;
            Login_Btn.Icon = null;
            Login_Btn.Location = new Point(136, 270);
            Login_Btn.Margin = new Padding(4, 6, 4, 6);
            Login_Btn.MouseState = MouseState.HOVER;
            Login_Btn.Name = "Login_Btn";
            Login_Btn.NoAccentTextColor = Color.Empty;
            Login_Btn.Size = new Size(299, 61);
            Login_Btn.TabIndex = 5;
            Login_Btn.Text = "Login";
            Login_Btn.Type = MaterialButton.MaterialButtonType.Contained;
            Login_Btn.UseAccentColor = false;
            Login_Btn.UseVisualStyleBackColor = true;
            Login_Btn.Click += Login_Btn_Click;
            // 
            // Apply_Btn
            // 
            Apply_Btn.AutoSize = false;
            Apply_Btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Apply_Btn.Density = MaterialButton.MaterialButtonDensity.Default;
            Apply_Btn.Depth = 0;
            Apply_Btn.HighEmphasis = true;
            Apply_Btn.Icon = null;
            Apply_Btn.Location = new Point(136, 377);
            Apply_Btn.Margin = new Padding(4, 6, 4, 6);
            Apply_Btn.MouseState = MouseState.HOVER;
            Apply_Btn.Name = "Apply_Btn";
            Apply_Btn.NoAccentTextColor = Color.Empty;
            Apply_Btn.Size = new Size(299, 61);
            Apply_Btn.TabIndex = 5;
            Apply_Btn.Text = "Apply For Legacy";
            Apply_Btn.Type = MaterialButton.MaterialButtonType.Contained;
            Apply_Btn.UseAccentColor = false;
            Apply_Btn.UseVisualStyleBackColor = true;
            Apply_Btn.Click += Apply_Btn_Click;
            // 
            // QB_Btn
            // 
            QB_Btn.AutoSize = false;
            QB_Btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            QB_Btn.Density = MaterialButton.MaterialButtonDensity.Default;
            QB_Btn.Depth = 0;
            QB_Btn.HighEmphasis = true;
            QB_Btn.Icon = null;
            QB_Btn.Location = new Point(136, 589);
            QB_Btn.Margin = new Padding(4, 6, 4, 6);
            QB_Btn.MouseState = MouseState.HOVER;
            QB_Btn.Name = "QB_Btn";
            QB_Btn.NoAccentTextColor = Color.Empty;
            QB_Btn.Size = new Size(299, 61);
            QB_Btn.TabIndex = 5;
            QB_Btn.Text = "Question Bank";
            QB_Btn.Type = MaterialButton.MaterialButtonType.Contained;
            QB_Btn.UseAccentColor = false;
            QB_Btn.UseVisualStyleBackColor = true;
            QB_Btn.Click += QB_Btn_Click;
            // 
            // CheckStatus_Btn
            // 
            CheckStatus_Btn.AutoSize = false;
            CheckStatus_Btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CheckStatus_Btn.Density = MaterialButton.MaterialButtonDensity.Default;
            CheckStatus_Btn.Depth = 0;
            CheckStatus_Btn.HighEmphasis = true;
            CheckStatus_Btn.Icon = null;
            CheckStatus_Btn.Location = new Point(136, 481);
            CheckStatus_Btn.Margin = new Padding(4, 6, 4, 6);
            CheckStatus_Btn.MouseState = MouseState.HOVER;
            CheckStatus_Btn.Name = "CheckStatus_Btn";
            CheckStatus_Btn.NoAccentTextColor = Color.Empty;
            CheckStatus_Btn.Size = new Size(299, 61);
            CheckStatus_Btn.TabIndex = 5;
            CheckStatus_Btn.Text = "Check Application Status";
            CheckStatus_Btn.Type = MaterialButton.MaterialButtonType.Contained;
            CheckStatus_Btn.UseAccentColor = false;
            CheckStatus_Btn.UseVisualStyleBackColor = true;
            CheckStatus_Btn.Click += CheckStatus_Btn_Click;
            // 
            // StartupForm
            // 
            ClientSize = new Size(573, 752);
            Controls.Add(QB_Btn);
            Controls.Add(CheckStatus_Btn);
            Controls.Add(Apply_Btn);
            Controls.Add(Login_Btn);
            Controls.Add(Lb_Slogan);
            Controls.Add(Lb_Welcome);
            Controls.Add(ThemeSwitchBtn);
            Controls.Add(cmbLanguage);
            MaximizeBox = false;
            MaximumSize = new Size(573, 752);
            MinimumSize = new Size(573, 752);
            Name = "StartupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Legacy Examination Stystem";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private MaterialSwitch ThemeSwitchBtn;
        private MaterialComboBox cmbLanguage;
        private MaterialLabel Lb_Welcome;
        private MaterialLabel Lb_Slogan;
        private MaterialButton Login_Btn;
        private MaterialButton Apply_Btn;
        private MaterialButton QB_Btn;
        private MaterialButton CheckStatus_Btn;
    }
}