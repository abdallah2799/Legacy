namespace Legacy_System_UI.Pages.Student
{
    partial class ExamForm
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
            Lbl_Result = new MaterialSkin.Controls.MaterialLabel();
            Btn_Previous = new MaterialSkin.Controls.MaterialButton();
            Btn_Next = new MaterialSkin.Controls.MaterialButton();
            Btn_Submit = new MaterialSkin.Controls.MaterialButton();
            FlowPanel_Options = new FlowLayoutPanel();
            GoBackHomeBtn = new MaterialSkin.Controls.MaterialButton();
            ThemeSwitchBtn = new MaterialSkin.Controls.MaterialSwitch();
            cmbLanguage = new MaterialSkin.Controls.MaterialComboBox();
            Lbl_Question = new MaterialSkin.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // Lbl_Result
            // 
            Lbl_Result.AutoSize = true;
            Lbl_Result.Depth = 0;
            Lbl_Result.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lbl_Result.ForeColor = Color.Gray;
            Lbl_Result.Location = new Point(106, 437);
            Lbl_Result.MouseState = MaterialSkin.MouseState.HOVER;
            Lbl_Result.Name = "Lbl_Result";
            Lbl_Result.Size = new Size(1, 0);
            Lbl_Result.TabIndex = 23;
            // 
            // Btn_Previous
            // 
            Btn_Previous.AutoSize = false;
            Btn_Previous.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_Previous.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_Previous.Depth = 0;
            Btn_Previous.HighEmphasis = true;
            Btn_Previous.Icon = null;
            Btn_Previous.Location = new Point(106, 392);
            Btn_Previous.Margin = new Padding(4);
            Btn_Previous.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_Previous.Name = "Btn_Previous";
            Btn_Previous.NoAccentTextColor = Color.Empty;
            Btn_Previous.Size = new Size(100, 27);
            Btn_Previous.TabIndex = 21;
            Btn_Previous.Text = "← Previous";
            Btn_Previous.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_Previous.UseAccentColor = false;
            Btn_Previous.UseVisualStyleBackColor = true;
            Btn_Previous.Click += Btn_Previous_Click;
            // 
            // Btn_Next
            // 
            Btn_Next.AutoSize = false;
            Btn_Next.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_Next.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_Next.Depth = 0;
            Btn_Next.HighEmphasis = true;
            Btn_Next.Icon = null;
            Btn_Next.Location = new Point(647, 392);
            Btn_Next.Margin = new Padding(4);
            Btn_Next.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_Next.Name = "Btn_Next";
            Btn_Next.NoAccentTextColor = Color.Empty;
            Btn_Next.Size = new Size(97, 27);
            Btn_Next.TabIndex = 22;
            Btn_Next.Text = "Next ➜";
            Btn_Next.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_Next.UseAccentColor = false;
            Btn_Next.UseVisualStyleBackColor = true;
            Btn_Next.Click += Btn_Next_Click;
            // 
            // Btn_Submit
            // 
            Btn_Submit.AutoSize = false;
            Btn_Submit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_Submit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_Submit.Depth = 0;
            Btn_Submit.HighEmphasis = true;
            Btn_Submit.Icon = null;
            Btn_Submit.Location = new Point(378, 392);
            Btn_Submit.Margin = new Padding(4);
            Btn_Submit.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_Submit.Name = "Btn_Submit";
            Btn_Submit.NoAccentTextColor = Color.Empty;
            Btn_Submit.Size = new Size(96, 27);
            Btn_Submit.TabIndex = 20;
            Btn_Submit.Text = "Submit";
            Btn_Submit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_Submit.UseAccentColor = false;
            Btn_Submit.UseVisualStyleBackColor = true;
            Btn_Submit.Click += Btn_Submit_Click;
            // 
            // FlowPanel_Options
            // 
            FlowPanel_Options.AutoScroll = true;
            FlowPanel_Options.Location = new Point(106, 227);
            FlowPanel_Options.Margin = new Padding(3, 2, 3, 2);
            FlowPanel_Options.Name = "FlowPanel_Options";
            FlowPanel_Options.Size = new Size(648, 150);
            FlowPanel_Options.TabIndex = 19;
            // 
            // GoBackHomeBtn
            // 
            GoBackHomeBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GoBackHomeBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            GoBackHomeBtn.Depth = 0;
            GoBackHomeBtn.HighEmphasis = true;
            GoBackHomeBtn.Icon = null;
            GoBackHomeBtn.Location = new Point(93, 110);
            GoBackHomeBtn.Margin = new Padding(4);
            GoBackHomeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            GoBackHomeBtn.Name = "GoBackHomeBtn";
            GoBackHomeBtn.NoAccentTextColor = Color.Empty;
            GoBackHomeBtn.Size = new Size(148, 36);
            GoBackHomeBtn.TabIndex = 15;
            GoBackHomeBtn.Text = "<-  Go back home";
            GoBackHomeBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            GoBackHomeBtn.UseAccentColor = false;
            GoBackHomeBtn.UseVisualStyleBackColor = true;
            GoBackHomeBtn.Click += this.GoBackHomeBtn_Click;
            // 
            // ThemeSwitchBtn
            // 
            ThemeSwitchBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ThemeSwitchBtn.AutoSize = true;
            ThemeSwitchBtn.Depth = 0;
            ThemeSwitchBtn.Location = new Point(620, 517);
            ThemeSwitchBtn.Margin = new Padding(0);
            ThemeSwitchBtn.MouseLocation = new Point(-1, -1);
            ThemeSwitchBtn.MouseState = MaterialSkin.MouseState.HOVER;
            ThemeSwitchBtn.Name = "ThemeSwitchBtn";
            ThemeSwitchBtn.Ripple = true;
            ThemeSwitchBtn.Size = new Size(138, 37);
            ThemeSwitchBtn.TabIndex = 14;
            ThemeSwitchBtn.Text = "Light Mode";
            ThemeSwitchBtn.UseVisualStyleBackColor = true;
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
            cmbLanguage.Location = new Point(93, 512);
            cmbLanguage.Margin = new Padding(3, 2, 3, 2);
            cmbLanguage.MaxDropDownItems = 4;
            cmbLanguage.MouseState = MaterialSkin.MouseState.OUT;
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(133, 49);
            cmbLanguage.StartIndex = 0;
            cmbLanguage.TabIndex = 13;
            // 
            // Lbl_Question
            // 
            Lbl_Question.Depth = 0;
            Lbl_Question.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lbl_Question.Location = new Point(106, 168);
            Lbl_Question.MouseState = MaterialSkin.MouseState.HOVER;
            Lbl_Question.Name = "Lbl_Question";
            Lbl_Question.Size = new Size(648, 45);
            Lbl_Question.TabIndex = 24;
            Lbl_Question.Text = "Question";
            // 
            // ExamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 619);
            Controls.Add(Lbl_Question);
            Controls.Add(Lbl_Result);
            Controls.Add(Btn_Previous);
            Controls.Add(Btn_Next);
            Controls.Add(Btn_Submit);
            Controls.Add(FlowPanel_Options);
            Controls.Add(GoBackHomeBtn);
            Controls.Add(ThemeSwitchBtn);
            Controls.Add(cmbLanguage);
            Name = "ExamForm";
            Text = "Exam";
            Load += ExamForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel Lbl_Result;
        private MaterialSkin.Controls.MaterialButton Btn_Previous;
        private MaterialSkin.Controls.MaterialButton Btn_Next;
        private MaterialSkin.Controls.MaterialButton Btn_Submit;
        private FlowLayoutPanel FlowPanel_Options;
        private MaterialSkin.Controls.MaterialButton GoBackHomeBtn;
        private MaterialSkin.Controls.MaterialSwitch ThemeSwitchBtn;
        private MaterialSkin.Controls.MaterialComboBox cmbLanguage;
        private MaterialSkin.Controls.MaterialLabel Lbl_Question;
    }
}