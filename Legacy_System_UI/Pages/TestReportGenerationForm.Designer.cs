namespace Legacy_System_UI.Pages
{
    partial class TestReportGenerationForm
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
            Btn_GenerateReprt = new MaterialSkin.Controls.MaterialButton();
            Tb_Id = new MaterialSkin.Controls.MaterialTextBox();
            SuspendLayout();
            // 
            // Btn_GenerateReprt
            // 
            Btn_GenerateReprt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_GenerateReprt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_GenerateReprt.Depth = 0;
            Btn_GenerateReprt.HighEmphasis = true;
            Btn_GenerateReprt.Icon = null;
            Btn_GenerateReprt.Location = new Point(306, 233);
            Btn_GenerateReprt.Margin = new Padding(4, 6, 4, 6);
            Btn_GenerateReprt.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_GenerateReprt.Name = "Btn_GenerateReprt";
            Btn_GenerateReprt.NoAccentTextColor = Color.Empty;
            Btn_GenerateReprt.Size = new Size(154, 36);
            Btn_GenerateReprt.TabIndex = 0;
            Btn_GenerateReprt.Text = "Generate Report";
            Btn_GenerateReprt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_GenerateReprt.UseAccentColor = false;
            Btn_GenerateReprt.UseVisualStyleBackColor = true;
            Btn_GenerateReprt.Click += Btn_GenerateReprt_Click;
            // 
            // Tb_Id
            // 
            Tb_Id.AnimateReadOnly = false;
            Tb_Id.BorderStyle = BorderStyle.None;
            Tb_Id.Depth = 0;
            Tb_Id.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Tb_Id.LeadingIcon = null;
            Tb_Id.Location = new Point(306, 183);
            Tb_Id.MaxLength = 50;
            Tb_Id.MouseState = MaterialSkin.MouseState.OUT;
            Tb_Id.Multiline = false;
            Tb_Id.Name = "Tb_Id";
            Tb_Id.Size = new Size(154, 50);
            Tb_Id.TabIndex = 1;
            Tb_Id.Text = "";
            Tb_Id.TrailingIcon = null;
            // 
            // TestReportGenerationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Tb_Id);
            Controls.Add(Btn_GenerateReprt);
            Name = "TestReportGenerationForm";
            Text = "Test Report Generation Form";
            Load += TestReportGenerationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton Btn_GenerateReprt;
        private MaterialSkin.Controls.MaterialTextBox Tb_Id;
    }
}