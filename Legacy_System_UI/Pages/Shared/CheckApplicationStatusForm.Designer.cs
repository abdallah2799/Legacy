using ClosedXML.Excel;
using Org.BouncyCastle.Asn1.Cmp;

namespace Legacy_System_UI.Pages.Shared
{
    partial class CheckApplicationStatusForm
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
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            ThemeSwitchBtn = new MaterialSkin.Controls.MaterialSwitch();
            cmbLanguage = new MaterialSkin.Controls.MaterialComboBox();
            GoBackHomeBtn = new MaterialSkin.Controls.MaterialButton();
            Tb_ApplicationCode = new MaterialSkin.Controls.MaterialTextBox();
            Btn_Submit = new MaterialSkin.Controls.MaterialButton();
            panelApplicationData = new Panel();
            lblFullName = new MaterialSkin.Controls.MaterialLabel();
            lblEmail = new MaterialSkin.Controls.MaterialLabel();
            lblGender = new MaterialSkin.Controls.MaterialLabel();
            lblAge = new MaterialSkin.Controls.MaterialLabel();
            lblPhone = new MaterialSkin.Controls.MaterialLabel();
            lblAddress = new MaterialSkin.Controls.MaterialLabel();
            lblStatus = new MaterialSkin.Controls.MaterialLabel();
            lblCreatedAt = new MaterialSkin.Controls.MaterialLabel();
            lblNoDataMessage = new MaterialSkin.Controls.MaterialLabel();
            panelApplicationData.SuspendLayout();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            materialLabel1.Location = new Point(158, 125);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(457, 41);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Check Your Application Status";
            // 
            // ThemeSwitchBtn
            // 
            ThemeSwitchBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ThemeSwitchBtn.AutoSize = true;
            ThemeSwitchBtn.Depth = 0;
            ThemeSwitchBtn.Location = new Point(659, 671);
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
            cmbLanguage.Location = new Point(6, 656);
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
            GoBackHomeBtn.Location = new Point(6, 70);
            GoBackHomeBtn.Margin = new Padding(4, 6, 4, 6);
            GoBackHomeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            GoBackHomeBtn.Name = "GoBackHomeBtn";
            GoBackHomeBtn.NoAccentTextColor = Color.Empty;
            GoBackHomeBtn.Size = new Size(148, 36);
            GoBackHomeBtn.TabIndex = 6;
            GoBackHomeBtn.Text = "<-  Go back home";
            GoBackHomeBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            GoBackHomeBtn.UseAccentColor = false;
            GoBackHomeBtn.UseVisualStyleBackColor = true;
            GoBackHomeBtn.Click += GoBackHomeBtn_Click;
            // 
            // Tb_ApplicationCode
            // 
            Tb_ApplicationCode.AnimateReadOnly = false;
            Tb_ApplicationCode.BorderStyle = BorderStyle.None;
            Tb_ApplicationCode.Depth = 0;
            Tb_ApplicationCode.Font = new Font("Microsoft Sans Serif", 9.6F);
            Tb_ApplicationCode.LeadingIcon = null;
            Tb_ApplicationCode.Location = new Point(202, 191);
            Tb_ApplicationCode.MaxLength = 50;
            Tb_ApplicationCode.MouseState = MaterialSkin.MouseState.OUT;
            Tb_ApplicationCode.Multiline = false;
            Tb_ApplicationCode.Name = "Tb_ApplicationCode";
            Tb_ApplicationCode.Size = new Size(289, 50);
            Tb_ApplicationCode.TabIndex = 7;
            Tb_ApplicationCode.Text = "Replace With Your Application Code";
            Tb_ApplicationCode.TrailingIcon = null;
            Tb_ApplicationCode.Enter += SelectAllText;
            Tb_ApplicationCode.Leave += RetriveIFNoCodeEntered;
            // 
            // Btn_Submit
            // 
            Btn_Submit.AutoSize = false;
            Btn_Submit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_Submit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_Submit.Depth = 0;
            Btn_Submit.HighEmphasis = true;
            Btn_Submit.Icon = null;
            Btn_Submit.Location = new Point(489, 191);
            Btn_Submit.Margin = new Padding(4, 6, 4, 6);
            Btn_Submit.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_Submit.Name = "Btn_Submit";
            Btn_Submit.NoAccentTextColor = Color.Empty;
            Btn_Submit.Size = new Size(71, 50);
            Btn_Submit.TabIndex = 9;
            Btn_Submit.Text = "Submit";
            Btn_Submit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_Submit.UseAccentColor = false;
            Btn_Submit.UseVisualStyleBackColor = true;
            Btn_Submit.Click += Btn_Submit_Click;
            // 
            // panelApplicationData
            // 
            panelApplicationData.BorderStyle = BorderStyle.FixedSingle;
            panelApplicationData.Controls.Add(lblFullName);
            panelApplicationData.Controls.Add(lblEmail);
            panelApplicationData.Controls.Add(lblGender);
            panelApplicationData.Controls.Add(lblAge);
            panelApplicationData.Controls.Add(lblPhone);
            panelApplicationData.Controls.Add(lblAddress);
            panelApplicationData.Controls.Add(lblStatus);
            panelApplicationData.Controls.Add(lblCreatedAt);
            panelApplicationData.Location = new Point(79, 270);
            panelApplicationData.Name = "panelApplicationData";
            panelApplicationData.Size = new Size(626, 289);
            panelApplicationData.TabIndex = 10;
            panelApplicationData.Visible = false;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Depth = 0;
            lblFullName.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFullName.Location = new Point(15, 68);
            lblFullName.MouseState = MaterialSkin.MouseState.HOVER;
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(85, 19);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full Name: -";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Depth = 0;
            lblEmail.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEmail.Location = new Point(15, 102);
            lblEmail.MouseState = MaterialSkin.MouseState.HOVER;
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(53, 19);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email: -";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Depth = 0;
            lblGender.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblGender.Location = new Point(15, 136);
            lblGender.MouseState = MaterialSkin.MouseState.HOVER;
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(63, 19);
            lblGender.TabIndex = 2;
            lblGender.Text = "Gender: -";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Depth = 0;
            lblAge.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAge.Location = new Point(15, 170);
            lblAge.MouseState = MaterialSkin.MouseState.HOVER;
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(40, 19);
            lblAge.TabIndex = 3;
            lblAge.Text = "Age: -";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Depth = 0;
            lblPhone.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPhone.Location = new Point(15, 204);
            lblPhone.MouseState = MaterialSkin.MouseState.HOVER;
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(58, 19);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone: -";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Depth = 0;
            lblAddress.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAddress.Location = new Point(15, 238);
            lblAddress.MouseState = MaterialSkin.MouseState.HOVER;
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(70, 19);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Address: -";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Depth = 0;
            lblStatus.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblStatus.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblStatus.Location = new Point(24, 20);
            lblStatus.MouseState = MaterialSkin.MouseState.HOVER;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(76, 24);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status: -";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.AutoSize = true;
            lblCreatedAt.Depth = 0;
            lblCreatedAt.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblCreatedAt.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblCreatedAt.Location = new Point(236, 20);
            lblCreatedAt.MouseState = MaterialSkin.MouseState.HOVER;
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new Size(114, 24);
            lblCreatedAt.TabIndex = 7;
            lblCreatedAt.Text = "Created At: -";
            // 
            // lblNoDataMessage
            // 
            lblNoDataMessage.AutoSize = true;
            lblNoDataMessage.Depth = 0;
            lblNoDataMessage.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNoDataMessage.ForeColor = Color.Gray;
            lblNoDataMessage.Location = new Point(160, 320);
            lblNoDataMessage.MouseState = MaterialSkin.MouseState.HOVER;
            lblNoDataMessage.Name = "lblNoDataMessage";
            lblNoDataMessage.Size = new Size(252, 19);
            lblNoDataMessage.TabIndex = 11;
            lblNoDataMessage.Text = "No Active Application Were Found...";
            lblNoDataMessage.Visible = false;
            // 
            // CheckApplicationStatusForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 711);
            Controls.Add(panelApplicationData);
            Controls.Add(lblNoDataMessage);
            Controls.Add(Btn_Submit);
            Controls.Add(Tb_ApplicationCode);
            Controls.Add(GoBackHomeBtn);
            Controls.Add(ThemeSwitchBtn);
            Controls.Add(cmbLanguage);
            Controls.Add(materialLabel1);
            MaximizeBox = false;
            MaximumSize = new Size(800, 711);
            MinimumSize = new Size(800, 711);
            Name = "CheckApplicationStatusForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Check Application Status";
            panelApplicationData.ResumeLayout(false);
            panelApplicationData.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSwitch ThemeSwitchBtn;
        private MaterialSkin.Controls.MaterialComboBox cmbLanguage;
        private MaterialSkin.Controls.MaterialButton GoBackHomeBtn;
        private MaterialSkin.Controls.MaterialTextBox Tb_ApplicationCode;
        private MaterialSkin.Controls.MaterialButton Btn_Submit;
        private System.Windows.Forms.Panel panelApplicationData;
        private MaterialSkin.Controls.MaterialLabel lblFullName;
        private MaterialSkin.Controls.MaterialLabel lblEmail;
        private MaterialSkin.Controls.MaterialLabel lblGender;
        private MaterialSkin.Controls.MaterialLabel lblAge;
        private MaterialSkin.Controls.MaterialLabel lblPhone;
        private MaterialSkin.Controls.MaterialLabel lblAddress;
        private MaterialSkin.Controls.MaterialLabel lblStatus;
        private MaterialSkin.Controls.MaterialLabel lblCreatedAt;
        private MaterialSkin.Controls.MaterialLabel lblNoDataMessage;

    }
}