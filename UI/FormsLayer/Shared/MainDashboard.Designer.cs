namespace UI.FormsLayer.Shared
{
    partial class MainDashboard
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
            this.lblWelcome = new MaterialSkin.Controls.MaterialLabel();
            this.lblRole = new MaterialSkin.Controls.MaterialLabel();
            this.cmbLanguage = new MaterialSkin.Controls.MaterialComboBox();
            this.btnTheme = new MaterialSkin.Controls.MaterialButton();
            this.btnLogout = new MaterialSkin.Controls.MaterialButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Depth = 0;
            this.lblWelcome.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblWelcome.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWelcome.Location = new System.Drawing.Point(50, 50);
            this.lblWelcome.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(200, 41);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, User!";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Depth = 0;
            this.lblRole.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRole.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRole.Location = new System.Drawing.Point(50, 100);
            this.lblRole.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(100, 19);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Role: Student";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.AutoResize = false;
            this.cmbLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbLanguage.Depth = 0;
            this.cmbLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbLanguage.DropDownHeight = 174;
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.DropDownWidth = 121;
            this.cmbLanguage.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.IntegralHeight = false;
            this.cmbLanguage.ItemHeight = 43;
            this.cmbLanguage.Location = new System.Drawing.Point(20, 20);
            this.cmbLanguage.MaxDropDownItems = 4;
            this.cmbLanguage.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(150, 49);
            this.cmbLanguage.StartIndex = 0;
            this.cmbLanguage.TabIndex = 0;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // btnTheme
            // 
            this.btnTheme.AutoSize = false;
            this.btnTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTheme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTheme.Depth = 0;
            this.btnTheme.HighEmphasis = true;
            this.btnTheme.Icon = null;
            this.btnTheme.Location = new System.Drawing.Point(200, 20);
            this.btnTheme.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTheme.Size = new System.Drawing.Size(100, 40);
            this.btnTheme.TabIndex = 1;
            this.btnTheme.Text = "Dark";
            this.btnTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnTheme.UseAccentColor = false;
            this.btnTheme.UseVisualStyleBackColor = true;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSize = false;
            this.btnLogout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogout.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogout.Depth = 0;
            this.btnLogout.HighEmphasis = true;
            this.btnLogout.Icon = null;
            this.btnLogout.Location = new System.Drawing.Point(350, 20);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogout.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogout.Size = new System.Drawing.Size(100, 40);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnLogout.UseAccentColor = false;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1000, 700);
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Controls.Add(this.btnTheme);
            this.panelTop.Controls.Add(this.cmbLanguage);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 80);
            this.panelTop.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.lblRole);
            this.panelContent.Controls.Add(this.lblWelcome);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1000, 620);
            this.panelContent.TabIndex = 1;
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelMain);
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Legacy Examination System";
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }

        private MaterialSkin.Controls.MaterialLabel lblWelcome;
        private MaterialSkin.Controls.MaterialLabel lblRole;
        private MaterialSkin.Controls.MaterialComboBox cmbLanguage;
        private MaterialSkin.Controls.MaterialButton btnTheme;
        private MaterialSkin.Controls.MaterialButton btnLogout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelContent;
    }
}
