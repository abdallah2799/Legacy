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
            // StartupForm
            // 
            ClientSize = new Size(573, 752);
            Controls.Add(ThemeSwitchBtn);
            Controls.Add(cmbLanguage);
            FormStyle = FormStyles.ActionBar_None;
            Name = "StartupForm";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private MaterialSwitch ThemeSwitchBtn;
        private MaterialComboBox cmbLanguage;
    }
}