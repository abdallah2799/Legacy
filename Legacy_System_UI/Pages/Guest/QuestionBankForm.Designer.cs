namespace Legacy_System_UI.Pages.Guest
{
    partial class QuestionBankForm
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
            ThemeSwitchBtn = new MaterialSkin.Controls.MaterialSwitch();
            cmbLanguage = new MaterialSkin.Controls.MaterialComboBox();
            GoBackHomeBtn = new MaterialSkin.Controls.MaterialButton();
            Lbl_Title = new MaterialSkin.Controls.MaterialLabel();
            Cmb_Course = new MaterialSkin.Controls.MaterialComboBox();
            Lbl_Question = new MaterialSkin.Controls.MaterialLabel();
            FlowPanel_Options = new FlowLayoutPanel();
            Btn_Submit = new MaterialSkin.Controls.MaterialButton();
            Btn_Next = new MaterialSkin.Controls.MaterialButton();
            Lbl_Result = new MaterialSkin.Controls.MaterialLabel();
            Btn_Previous = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // ThemeSwitchBtn
            // 
            ThemeSwitchBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ThemeSwitchBtn.AutoSize = true;
            ThemeSwitchBtn.Depth = 0;
            ThemeSwitchBtn.Location = new Point(657, 723);
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
            cmbLanguage.Location = new Point(16, 711);
            cmbLanguage.MaxDropDownItems = 4;
            cmbLanguage.MouseState = MaterialSkin.MouseState.OUT;
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(151, 49);
            cmbLanguage.StartIndex = 0;
            cmbLanguage.TabIndex = 3;
            cmbLanguage.SelectedIndexChanged += ChangeLanguage;
            // 
            // GoBackHomeBtn
            // 
            GoBackHomeBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GoBackHomeBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            GoBackHomeBtn.Depth = 0;
            GoBackHomeBtn.HighEmphasis = true;
            GoBackHomeBtn.Icon = null;
            GoBackHomeBtn.Location = new Point(7, 70);
            GoBackHomeBtn.Margin = new Padding(4, 6, 4, 6);
            GoBackHomeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            GoBackHomeBtn.Name = "GoBackHomeBtn";
            GoBackHomeBtn.NoAccentTextColor = Color.Empty;
            GoBackHomeBtn.Size = new Size(148, 36);
            GoBackHomeBtn.TabIndex = 5;
            GoBackHomeBtn.Text = "<-  Go back home";
            GoBackHomeBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            GoBackHomeBtn.UseAccentColor = false;
            GoBackHomeBtn.UseVisualStyleBackColor = true;
            GoBackHomeBtn.Click += GoBackHomeBtn_Click;
            // 
            // Lbl_Title
            // 
            Lbl_Title.AutoSize = true;
            Lbl_Title.Depth = 0;
            Lbl_Title.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lbl_Title.ForeColor = Color.FromArgb(33, 150, 243);
            Lbl_Title.Location = new Point(20, 120);
            Lbl_Title.MouseState = MaterialSkin.MouseState.HOVER;
            Lbl_Title.Name = "Lbl_Title";
            Lbl_Title.Size = new Size(124, 19);
            Lbl_Title.TabIndex = 6;
            Lbl_Title.Text = "📚 Question Bank";
            // 
            // Cmb_Course
            // 
            Cmb_Course.AutoResize = false;
            Cmb_Course.BackColor = Color.FromArgb(255, 255, 255);
            Cmb_Course.Depth = 0;
            Cmb_Course.DrawMode = DrawMode.OwnerDrawVariable;
            Cmb_Course.DropDownHeight = 174;
            Cmb_Course.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_Course.DropDownWidth = 121;
            Cmb_Course.Font = new Font("Segoe UI", 11F);
            Cmb_Course.ForeColor = Color.FromArgb(222, 0, 0, 0);
            Cmb_Course.FormattingEnabled = true;
            Cmb_Course.IntegralHeight = false;
            Cmb_Course.ItemHeight = 43;
            Cmb_Course.Location = new Point(30, 180);
            Cmb_Course.MaxDropDownItems = 4;
            Cmb_Course.MouseState = MaterialSkin.MouseState.OUT;
            Cmb_Course.Name = "Cmb_Course";
            Cmb_Course.Size = new Size(300, 49);
            Cmb_Course.StartIndex = 0;
            Cmb_Course.TabIndex = 7;
            Cmb_Course.SelectionChangeCommitted += Cmb_Course_SelectedIndexChanged;
            // 
            // Lbl_Question
            // 
            Lbl_Question.Depth = 0;
            Lbl_Question.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lbl_Question.Location = new Point(30, 250);
            Lbl_Question.MouseState = MaterialSkin.MouseState.HOVER;
            Lbl_Question.Name = "Lbl_Question";
            Lbl_Question.Size = new Size(740, 60);
            Lbl_Question.TabIndex = 8;
            Lbl_Question.Text = "Select a course to start...";
            // 
            // FlowPanel_Options
            // 
            FlowPanel_Options.AutoScroll = true;
            FlowPanel_Options.Location = new Point(30, 320);
            FlowPanel_Options.Name = "FlowPanel_Options";
            FlowPanel_Options.Size = new Size(740, 200);
            FlowPanel_Options.TabIndex = 9;
            // 
            // Btn_Submit
            // 
            Btn_Submit.AutoSize = false;
            Btn_Submit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_Submit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_Submit.Depth = 0;
            Btn_Submit.HighEmphasis = true;
            Btn_Submit.Icon = null;
            Btn_Submit.Location = new Point(340, 540);
            Btn_Submit.Margin = new Padding(4, 6, 4, 6);
            Btn_Submit.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_Submit.Name = "Btn_Submit";
            Btn_Submit.NoAccentTextColor = Color.Empty;
            Btn_Submit.Size = new Size(110, 36);
            Btn_Submit.TabIndex = 10;
            Btn_Submit.Text = "Submit";
            Btn_Submit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_Submit.UseAccentColor = false;
            Btn_Submit.UseVisualStyleBackColor = true;
            Btn_Submit.Click += Btn_Submit_Click;
            // 
            // Btn_Next
            // 
            Btn_Next.AutoSize = false;
            Btn_Next.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_Next.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_Next.Depth = 0;
            Btn_Next.HighEmphasis = true;
            Btn_Next.Icon = null;
            Btn_Next.Location = new Point(648, 540);
            Btn_Next.Margin = new Padding(4, 6, 4, 6);
            Btn_Next.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_Next.Name = "Btn_Next";
            Btn_Next.NoAccentTextColor = Color.Empty;
            Btn_Next.Size = new Size(111, 36);
            Btn_Next.TabIndex = 11;
            Btn_Next.Text = "Next ➜";
            Btn_Next.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_Next.UseAccentColor = false;
            Btn_Next.UseVisualStyleBackColor = true;
            Btn_Next.Click += Btn_Next_Click;
            // 
            // Lbl_Result
            // 
            Lbl_Result.AutoSize = true;
            Lbl_Result.Depth = 0;
            Lbl_Result.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lbl_Result.ForeColor = Color.Gray;
            Lbl_Result.Location = new Point(30, 600);
            Lbl_Result.MouseState = MaterialSkin.MouseState.HOVER;
            Lbl_Result.Name = "Lbl_Result";
            Lbl_Result.Size = new Size(1, 0);
            Lbl_Result.TabIndex = 12;
            // 
            // Btn_Previous
            // 
            Btn_Previous.AutoSize = false;
            Btn_Previous.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_Previous.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_Previous.Depth = 0;
            Btn_Previous.HighEmphasis = true;
            Btn_Previous.Icon = null;
            Btn_Previous.Location = new Point(30, 540);
            Btn_Previous.Margin = new Padding(4, 6, 4, 6);
            Btn_Previous.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_Previous.Name = "Btn_Previous";
            Btn_Previous.NoAccentTextColor = Color.Empty;
            Btn_Previous.Size = new Size(114, 36);
            Btn_Previous.TabIndex = 11;
            Btn_Previous.Text = "← Previous";
            Btn_Previous.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_Previous.UseAccentColor = false;
            Btn_Previous.UseVisualStyleBackColor = true;
            Btn_Previous.Click += Btn_Previous_Click;
            // 
            // QuestionBankForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 775);
            Controls.Add(Lbl_Result);
            Controls.Add(Btn_Previous);
            Controls.Add(Btn_Next);
            Controls.Add(Btn_Submit);
            Controls.Add(FlowPanel_Options);
            Controls.Add(Lbl_Question);
            Controls.Add(Cmb_Course);
            Controls.Add(Lbl_Title);
            Controls.Add(GoBackHomeBtn);
            Controls.Add(ThemeSwitchBtn);
            Controls.Add(cmbLanguage);
            MaximizeBox = false;
            Name = "QuestionBankForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Question Bank";
            Load += QuestionBankForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSwitch ThemeSwitchBtn;
        private MaterialSkin.Controls.MaterialComboBox cmbLanguage;
        private MaterialSkin.Controls.MaterialButton GoBackHomeBtn;

        private MaterialSkin.Controls.MaterialLabel Lbl_Title;
        private MaterialSkin.Controls.MaterialComboBox Cmb_Course;
        private MaterialSkin.Controls.MaterialLabel Lbl_Question;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel_Options;
        private MaterialSkin.Controls.MaterialButton Btn_Submit;
        private MaterialSkin.Controls.MaterialButton Btn_Next;
        private MaterialSkin.Controls.MaterialLabel Lbl_Result;
        private MaterialSkin.Controls.MaterialButton Btn_Previous;
    }
}
