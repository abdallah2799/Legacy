namespace Legacy_System_UI.Pages.Student
{
    partial class StudentMainForm
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
            lblWelcome = new MaterialSkin.Controls.MaterialLabel();
            listViewExams = new MaterialSkin.Controls.MaterialListView();
            btnStartExam = new MaterialSkin.Controls.MaterialButton();
            btnLogout = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Depth = 0;
            lblWelcome.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblWelcome.Location = new Point(50, 97);
            lblWelcome.MouseState = MaterialSkin.MouseState.HOVER;
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(107, 19);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "materialLabel1";
            // 
            // listViewExams
            // 
            listViewExams.AutoSizeTable = false;
            listViewExams.BackColor = Color.FromArgb(255, 255, 255);
            listViewExams.BorderStyle = BorderStyle.None;
            listViewExams.Depth = 0;
            listViewExams.FullRowSelect = true;
            listViewExams.Location = new Point(46, 156);
            listViewExams.MinimumSize = new Size(200, 100);
            listViewExams.MouseLocation = new Point(-1, -1);
            listViewExams.MouseState = MaterialSkin.MouseState.OUT;
            listViewExams.Name = "listViewExams";
            listViewExams.OwnerDraw = true;
            listViewExams.Size = new Size(713, 211);
            listViewExams.TabIndex = 1;
            listViewExams.UseCompatibleStateImageBehavior = false;
            listViewExams.View = View.Details;
            // 
            // btnStartExam
            // 
            btnStartExam.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnStartExam.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnStartExam.Depth = 0;
            btnStartExam.HighEmphasis = true;
            btnStartExam.Icon = null;
            btnStartExam.Location = new Point(46, 385);
            btnStartExam.Margin = new Padding(4, 6, 4, 6);
            btnStartExam.MouseState = MaterialSkin.MouseState.HOVER;
            btnStartExam.Name = "btnStartExam";
            btnStartExam.NoAccentTextColor = Color.Empty;
            btnStartExam.Size = new Size(111, 36);
            btnStartExam.TabIndex = 2;
            btnStartExam.Text = "Start Exam";
            btnStartExam.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnStartExam.UseAccentColor = false;
            btnStartExam.UseVisualStyleBackColor = true;
            btnStartExam.Click += btnStartExam_Click;
            // 
            // btnLogout
            // 
            btnLogout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogout.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLogout.Depth = 0;
            btnLogout.HighEmphasis = true;
            btnLogout.Icon = null;
            btnLogout.Location = new Point(681, 385);
            btnLogout.Margin = new Padding(4, 6, 4, 6);
            btnLogout.MouseState = MaterialSkin.MouseState.HOVER;
            btnLogout.Name = "btnLogout";
            btnLogout.NoAccentTextColor = Color.Empty;
            btnLogout.Size = new Size(78, 36);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLogout.UseAccentColor = false;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // StudentMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogout);
            Controls.Add(btnStartExam);
            Controls.Add(listViewExams);
            Controls.Add(lblWelcome);
            Name = "StudentMainForm";
            Text = "StudentMainForm";
            Load += StudentMainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblWelcome;
        private MaterialSkin.Controls.MaterialListView listViewExams;
        private MaterialSkin.Controls.MaterialButton btnStartExam;
        private MaterialSkin.Controls.MaterialButton btnLogout;
    }
}