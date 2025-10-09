namespace UI.FormsLayer.Admin
{
    partial class BranchManagerApplicantReviewForm
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
            this.lblTitle = new MaterialSkin.Controls.MaterialLabel();
            this.lblSubtitle = new MaterialSkin.Controls.MaterialLabel();
            this.cmbLanguage = new MaterialSkin.Controls.MaterialComboBox();
            this.btnTheme = new MaterialSkin.Controls.MaterialButton();
            this.btnBackToDashboard = new MaterialSkin.Controls.MaterialButton();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelApplicants = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNoApplicants = new MaterialSkin.Controls.MaterialLabel();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Depth = 0;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(50, 50);
            this.lblTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Applicant Review";
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
            this.lblSubtitle.Text = "Review and approve/reject pending applications for your branch";
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
            // btnBackToDashboard
            // 
            this.btnBackToDashboard.AutoSize = false;
            this.btnBackToDashboard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBackToDashboard.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBackToDashboard.Depth = 0;
            this.btnBackToDashboard.HighEmphasis = true;
            this.btnBackToDashboard.Icon = null;
            this.btnBackToDashboard.Location = new System.Drawing.Point(350, 20);
            this.btnBackToDashboard.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBackToDashboard.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBackToDashboard.Name = "btnBackToDashboard";
            this.btnBackToDashboard.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBackToDashboard.Size = new System.Drawing.Size(150, 40);
            this.btnBackToDashboard.TabIndex = 2;
            this.btnBackToDashboard.Text = "Back to Dashboard";
            this.btnBackToDashboard.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnBackToDashboard.UseAccentColor = false;
            this.btnBackToDashboard.UseVisualStyleBackColor = true;
            this.btnBackToDashboard.Click += new System.EventHandler(this.btnBackToDashboard_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = false;
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefresh.Depth = 0;
            this.btnRefresh.HighEmphasis = true;
            this.btnRefresh.Icon = null;
            this.btnRefresh.Location = new System.Drawing.Point(50, 150);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefresh.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRefresh.UseAccentColor = false;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelApplicants
            // 
            this.panelApplicants.AutoScroll = true;
            this.panelApplicants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelApplicants.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelApplicants.Location = new System.Drawing.Point(0, 0);
            this.panelApplicants.Name = "panelApplicants";
            this.panelApplicants.Padding = new System.Windows.Forms.Padding(10);
            this.panelApplicants.Size = new System.Drawing.Size(1000, 400);
            this.panelApplicants.TabIndex = 0;
            this.panelApplicants.WrapContents = false;
            // 
            // lblNoApplicants
            // 
            this.lblNoApplicants.AutoSize = true;
            this.lblNoApplicants.Depth = 0;
            this.lblNoApplicants.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNoApplicants.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblNoApplicants.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNoApplicants.Location = new System.Drawing.Point(50, 200);
            this.lblNoApplicants.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNoApplicants.Name = "lblNoApplicants";
            this.lblNoApplicants.Size = new System.Drawing.Size(300, 19);
            this.lblNoApplicants.TabIndex = 3;
            this.lblNoApplicants.Text = "No pending applicants found for your branch.";
            this.lblNoApplicants.Visible = false;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1200, 700);
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnBackToDashboard);
            this.panelTop.Controls.Add(this.btnTheme);
            this.panelTop.Controls.Add(this.cmbLanguage);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 80);
            this.panelTop.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelApplicants);
            this.panelContent.Controls.Add(this.lblNoApplicants);
            this.panelContent.Controls.Add(this.btnRefresh);
            this.panelContent.Controls.Add(this.lblSubtitle);
            this.panelContent.Controls.Add(this.lblTitle);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1200, 620);
            this.panelContent.TabIndex = 1;
            // 
            // BranchManagerApplicantReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelMain);
            this.Name = "BranchManagerApplicantReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branch Manager - Applicant Review";
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
