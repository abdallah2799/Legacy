namespace UI.FormsLayer.Shared
{
    partial class SplashPage
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
            this.lblSubtitle = new MaterialSkin.Controls.MaterialLabel();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.btnApply = new MaterialSkin.Controls.MaterialButton();
            this.btnPractice = new MaterialSkin.Controls.MaterialButton();
            this.cmbLanguage = new MaterialSkin.Controls.MaterialComboBox();
            this.btnTheme = new MaterialSkin.Controls.MaterialButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelActions = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelActions.SuspendLayout();
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
            this.lblWelcome.Size = new System.Drawing.Size(300, 41);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to Legacy";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Depth = 0;
            this.lblSubtitle.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSubtitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSubtitle.Location = new System.Drawing.Point(50, 100);
            this.lblSubtitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(400, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Your Gateway to Academic Excellence";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = false;
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(50, 20);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogin.Size = new System.Drawing.Size(200, 60);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = false;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnApply
            // 
            this.btnApply.AutoSize = false;
            this.btnApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApply.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnApply.Depth = 0;
            this.btnApply.HighEmphasis = true;
            this.btnApply.Icon = null;
            this.btnApply.Location = new System.Drawing.Point(50, 100);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnApply.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnApply.Name = "btnApply";
            this.btnApply.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnApply.Size = new System.Drawing.Size(200, 60);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply for Legacy";
            this.btnApply.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnApply.UseAccentColor = false;
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnPractice
            // 
            this.btnPractice.AutoSize = false;
            this.btnPractice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPractice.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPractice.Depth = 0;
            this.btnPractice.HighEmphasis = true;
            this.btnPractice.Icon = null;
            this.btnPractice.Location = new System.Drawing.Point(50, 180);
            this.btnPractice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPractice.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPractice.Name = "btnPractice";
            this.btnPractice.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPractice.Size = new System.Drawing.Size(200, 60);
            this.btnPractice.TabIndex = 2;
            this.btnPractice.Text = "Practice Mode";
            this.btnPractice.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPractice.UseAccentColor = false;
            this.btnPractice.UseVisualStyleBackColor = true;
            this.btnPractice.Click += new System.EventHandler(this.btnPractice_Click);
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
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 600);
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnTheme);
            this.panelTop.Controls.Add(this.cmbLanguage);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 80);
            this.panelTop.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelActions);
            this.panelContent.Controls.Add(this.lblSubtitle);
            this.panelContent.Controls.Add(this.lblWelcome);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 520);
            this.panelContent.TabIndex = 1;
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnPractice);
            this.panelActions.Controls.Add(this.btnApply);
            this.panelActions.Controls.Add(this.btnLogin);
            this.panelActions.Location = new System.Drawing.Point(200, 200);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(300, 260);
            this.panelActions.TabIndex = 2;
            // 
            // SplashPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelMain);
            this.Name = "SplashPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Legacy Examination System";
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private MaterialSkin.Controls.MaterialLabel lblWelcome;
        private MaterialSkin.Controls.MaterialLabel lblSubtitle;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private MaterialSkin.Controls.MaterialButton btnApply;
        private MaterialSkin.Controls.MaterialButton btnPractice;
        private MaterialSkin.Controls.MaterialComboBox cmbLanguage;
        private MaterialSkin.Controls.MaterialButton btnTheme;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelActions;
    }
}
