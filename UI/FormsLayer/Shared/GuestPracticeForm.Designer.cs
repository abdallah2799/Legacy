namespace UI.FormsLayer.Shared
{
    partial class GuestPracticeForm
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
            this.btnBackToHome = new MaterialSkin.Controls.MaterialButton();
            
            // Course selection controls
            this.cmbCourse = new MaterialSkin.Controls.MaterialComboBox();
            this.lblCourseDescription = new MaterialSkin.Controls.MaterialLabel();
            this.btnStartPractice = new MaterialSkin.Controls.MaterialButton();
            
            // Practice mode controls
            this.lblQuestionTitle = new MaterialSkin.Controls.MaterialLabel();
            this.lblQuestionText = new MaterialSkin.Controls.MaterialLabel();
            this.lblQuestionCounter = new MaterialSkin.Controls.MaterialLabel();
            this.btnPreviousQuestion = new MaterialSkin.Controls.MaterialButton();
            this.btnNextQuestion = new MaterialSkin.Controls.MaterialButton();
            this.btnCheckAnswer = new MaterialSkin.Controls.MaterialButton();
            this.btnExitPractice = new MaterialSkin.Controls.MaterialButton();
            this.panelAnswers = new System.Windows.Forms.Panel();
            this.lblAnswerFeedback = new MaterialSkin.Controls.MaterialLabel();
            
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
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
            this.lblTitle.Text = "Practice Mode";
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
            this.lblSubtitle.Size = new System.Drawing.Size(300, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Select a course to practice questions";
            // 
            // cmbCourse
            // 
            this.cmbCourse.AutoResize = false;
            this.cmbCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbCourse.Depth = 0;
            this.cmbCourse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbCourse.DropDownHeight = 174;
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.DropDownWidth = 121;
            this.cmbCourse.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.IntegralHeight = false;
            this.cmbCourse.ItemHeight = 43;
            this.cmbCourse.Location = new System.Drawing.Point(50, 150);
            this.cmbCourse.MaxDropDownItems = 4;
            this.cmbCourse.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(300, 49);
            this.cmbCourse.TabIndex = 2;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
            // 
            // lblCourseDescription
            // 
            this.lblCourseDescription.AutoSize = true;
            this.lblCourseDescription.Depth = 0;
            this.lblCourseDescription.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCourseDescription.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            this.lblCourseDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCourseDescription.Location = new System.Drawing.Point(50, 220);
            this.lblCourseDescription.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCourseDescription.Name = "lblCourseDescription";
            this.lblCourseDescription.Size = new System.Drawing.Size(200, 19);
            this.lblCourseDescription.TabIndex = 3;
            this.lblCourseDescription.Text = "Description: No description available";
            // 
            // btnStartPractice
            // 
            this.btnStartPractice.AutoSize = false;
            this.btnStartPractice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartPractice.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStartPractice.Depth = 0;
            this.btnStartPractice.HighEmphasis = true;
            this.btnStartPractice.Icon = null;
            this.btnStartPractice.Location = new System.Drawing.Point(50, 280);
            this.btnStartPractice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStartPractice.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStartPractice.Name = "btnStartPractice";
            this.btnStartPractice.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStartPractice.Size = new System.Drawing.Size(200, 50);
            this.btnStartPractice.TabIndex = 4;
            this.btnStartPractice.Text = "Start Practice";
            this.btnStartPractice.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStartPractice.UseAccentColor = false;
            this.btnStartPractice.UseVisualStyleBackColor = true;
            this.btnStartPractice.Click += new System.EventHandler(this.btnStartPractice_Click);
            // 
            // lblQuestionTitle
            // 
            this.lblQuestionTitle.AutoSize = true;
            this.lblQuestionTitle.Depth = 0;
            this.lblQuestionTitle.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblQuestionTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblQuestionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblQuestionTitle.Location = new System.Drawing.Point(50, 150);
            this.lblQuestionTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblQuestionTitle.Name = "lblQuestionTitle";
            this.lblQuestionTitle.Size = new System.Drawing.Size(150, 29);
            this.lblQuestionTitle.TabIndex = 5;
            this.lblQuestionTitle.Text = "Question 1";
            // 
            // lblQuestionText
            // 
            this.lblQuestionText.AutoSize = true;
            this.lblQuestionText.Depth = 0;
            this.lblQuestionText.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblQuestionText.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblQuestionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblQuestionText.Location = new System.Drawing.Point(50, 200);
            this.lblQuestionText.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblQuestionText.Name = "lblQuestionText";
            this.lblQuestionText.Size = new System.Drawing.Size(400, 19);
            this.lblQuestionText.TabIndex = 6;
            this.lblQuestionText.Text = "Question text will appear here";
            // 
            // lblQuestionCounter
            // 
            this.lblQuestionCounter.AutoSize = true;
            this.lblQuestionCounter.Depth = 0;
            this.lblQuestionCounter.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblQuestionCounter.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            this.lblQuestionCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblQuestionCounter.Location = new System.Drawing.Point(50, 240);
            this.lblQuestionCounter.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblQuestionCounter.Name = "lblQuestionCounter";
            this.lblQuestionCounter.Size = new System.Drawing.Size(150, 19);
            this.lblQuestionCounter.TabIndex = 7;
            this.lblQuestionCounter.Text = "Question 1 of 10";
            // 
            // panelAnswers
            // 
            this.panelAnswers.Location = new System.Drawing.Point(50, 280);
            this.panelAnswers.Name = "panelAnswers";
            this.panelAnswers.Size = new System.Drawing.Size(500, 200);
            this.panelAnswers.TabIndex = 8;
            // 
            // btnCheckAnswer
            // 
            this.btnCheckAnswer.AutoSize = false;
            this.btnCheckAnswer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCheckAnswer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCheckAnswer.Depth = 0;
            this.btnCheckAnswer.HighEmphasis = true;
            this.btnCheckAnswer.Icon = null;
            this.btnCheckAnswer.Location = new System.Drawing.Point(50, 500);
            this.btnCheckAnswer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCheckAnswer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCheckAnswer.Name = "btnCheckAnswer";
            this.btnCheckAnswer.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCheckAnswer.Size = new System.Drawing.Size(150, 40);
            this.btnCheckAnswer.TabIndex = 9;
            this.btnCheckAnswer.Text = "Check Answer";
            this.btnCheckAnswer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCheckAnswer.UseAccentColor = false;
            this.btnCheckAnswer.UseVisualStyleBackColor = true;
            this.btnCheckAnswer.Click += new System.EventHandler(this.btnCheckAnswer_Click);
            // 
            // btnPreviousQuestion
            // 
            this.btnPreviousQuestion.AutoSize = false;
            this.btnPreviousQuestion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPreviousQuestion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPreviousQuestion.Depth = 0;
            this.btnPreviousQuestion.HighEmphasis = true;
            this.btnPreviousQuestion.Icon = null;
            this.btnPreviousQuestion.Location = new System.Drawing.Point(250, 500);
            this.btnPreviousQuestion.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPreviousQuestion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreviousQuestion.Name = "btnPreviousQuestion";
            this.btnPreviousQuestion.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPreviousQuestion.Size = new System.Drawing.Size(100, 40);
            this.btnPreviousQuestion.TabIndex = 10;
            this.btnPreviousQuestion.Text = "Previous";
            this.btnPreviousQuestion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnPreviousQuestion.UseAccentColor = false;
            this.btnPreviousQuestion.UseVisualStyleBackColor = true;
            this.btnPreviousQuestion.Click += new System.EventHandler(this.btnPreviousQuestion_Click);
            // 
            // btnNextQuestion
            // 
            this.btnNextQuestion.AutoSize = false;
            this.btnNextQuestion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNextQuestion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNextQuestion.Depth = 0;
            this.btnNextQuestion.HighEmphasis = true;
            this.btnNextQuestion.Icon = null;
            this.btnNextQuestion.Location = new System.Drawing.Point(370, 500);
            this.btnNextQuestion.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNextQuestion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNextQuestion.Name = "btnNextQuestion";
            this.btnNextQuestion.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNextQuestion.Size = new System.Drawing.Size(100, 40);
            this.btnNextQuestion.TabIndex = 11;
            this.btnNextQuestion.Text = "Next";
            this.btnNextQuestion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnNextQuestion.UseVisualStyleBackColor = true;
            this.btnNextQuestion.Click += new System.EventHandler(this.btnNextQuestion_Click);
            // 
            // btnExitPractice
            // 
            this.btnExitPractice.AutoSize = false;
            this.btnExitPractice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExitPractice.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExitPractice.Depth = 0;
            this.btnExitPractice.HighEmphasis = true;
            this.btnExitPractice.Icon = null;
            this.btnExitPractice.Location = new System.Drawing.Point(500, 500);
            this.btnExitPractice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExitPractice.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExitPractice.Name = "btnExitPractice";
            this.btnExitPractice.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnExitPractice.Size = new System.Drawing.Size(100, 40);
            this.btnExitPractice.TabIndex = 12;
            this.btnExitPractice.Text = "Exit Practice";
            this.btnExitPractice.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnExitPractice.UseAccentColor = false;
            this.btnExitPractice.UseVisualStyleBackColor = true;
            this.btnExitPractice.Click += new System.EventHandler(this.btnExitPractice_Click);
            // 
            // lblAnswerFeedback
            // 
            this.lblAnswerFeedback.AutoSize = true;
            this.lblAnswerFeedback.Depth = 0;
            this.lblAnswerFeedback.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnswerFeedback.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            this.lblAnswerFeedback.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAnswerFeedback.Location = new System.Drawing.Point(50, 560);
            this.lblAnswerFeedback.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAnswerFeedback.Name = "lblAnswerFeedback";
            this.lblAnswerFeedback.Size = new System.Drawing.Size(200, 19);
            this.lblAnswerFeedback.TabIndex = 13;
            this.lblAnswerFeedback.Text = "Answer feedback will appear here";
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
            // btnBackToHome
            // 
            this.btnBackToHome.AutoSize = false;
            this.btnBackToHome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBackToHome.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBackToHome.Depth = 0;
            this.btnBackToHome.HighEmphasis = true;
            this.btnBackToHome.Icon = null;
            this.btnBackToHome.Location = new System.Drawing.Point(350, 20);
            this.btnBackToHome.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBackToHome.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBackToHome.Name = "btnBackToHome";
            this.btnBackToHome.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBackToHome.Size = new System.Drawing.Size(100, 40);
            this.btnBackToHome.TabIndex = 2;
            this.btnBackToHome.Text = "Back to Home";
            this.btnBackToHome.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnBackToHome.UseAccentColor = false;
            this.btnBackToHome.UseVisualStyleBackColor = true;
            this.btnBackToHome.Click += new System.EventHandler(this.btnBackToHome_Click);
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
            this.panelTop.Controls.Add(this.btnBackToHome);
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
            this.panelContent.Controls.Add(this.lblAnswerFeedback);
            this.panelContent.Controls.Add(this.btnExitPractice);
            this.panelContent.Controls.Add(this.btnNextQuestion);
            this.panelContent.Controls.Add(this.btnPreviousQuestion);
            this.panelContent.Controls.Add(this.btnCheckAnswer);
            this.panelContent.Controls.Add(this.panelAnswers);
            this.panelContent.Controls.Add(this.lblQuestionCounter);
            this.panelContent.Controls.Add(this.lblQuestionText);
            this.panelContent.Controls.Add(this.lblQuestionTitle);
            this.panelContent.Controls.Add(this.btnStartPractice);
            this.panelContent.Controls.Add(this.lblCourseDescription);
            this.panelContent.Controls.Add(this.cmbCourse);
            this.panelContent.Controls.Add(this.lblSubtitle);
            this.panelContent.Controls.Add(this.lblTitle);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 520);
            this.panelContent.TabIndex = 1;
            // 
            // GuestPracticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelMain);
            this.Name = "GuestPracticeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Practice Mode";
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }

        private MaterialSkin.Controls.MaterialLabel lblTitle;
        private MaterialSkin.Controls.MaterialLabel lblSubtitle;
        private MaterialSkin.Controls.MaterialComboBox cmbLanguage;
        private MaterialSkin.Controls.MaterialButton btnTheme;
        private MaterialSkin.Controls.MaterialButton btnBackToHome;
        
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelContent;
    }
}
