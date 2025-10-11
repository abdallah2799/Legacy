using Core.Interfaces.Services;
using Legacy_System_UI.Infrastructure;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legacy_System_UI.Pages.Shared
{

    public partial class CheckApplicationStatusForm : MaterialForm
    {
        private readonly MaterialForm parentForm;
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;
        private readonly IApplicantService _applicantService;
        public CheckApplicationStatusForm()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            SetupEventHandlers();

            _applicantService = Program.ServiceProvider.GetRequiredService<IApplicantService>();
        }

        public CheckApplicationStatusForm(MaterialForm _parentform) : this()
        {
            parentForm = _parentform;
        }



        private void SetupEventHandlers()
        {
            // Language change event
            localizationManager.LanguageChanged += (sender, e) => UpdateUIText();

            // Theme change event
            themeManager.ThemeChanged += (sender, e) =>
            {
                themeManager.ApplyTheme(materialSkinManager);
                Refresh();
            };
        }
        private void InitializeMaterialSkin()
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue700,
                Primary.Blue800,
                Primary.Blue500,
                Accent.Blue400,
                TextShade.WHITE
            );

            // Initialize managers
            localizationManager = LocalizationManager.Instance;
            themeManager = ThemeManager.Instance;


            // Apply current theme
            themeManager.ApplyTheme(materialSkinManager);

            // Update UI text
            UpdateUIText();
        }
        private void UpdateUIText()
        {
            // Update form Labels


            // Update Buttons
            GoBackHomeBtn.Text = localizationManager.GetString("GoBack");


            // Update language combo
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_English")} (EN)");
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_Arabic")} (AR)");
            cmbLanguage.SelectedIndex = localizationManager.GetCurrentLanguage() == "ar" ? 1 : 0;

            // Update theme button
            ThemeSwitchBtn.Text = themeManager.GetCurrentTheme() == ThemeMode.Light
                ? localizationManager.GetString("Theme_Light")
                : localizationManager.GetString("Theme_Dark");
        }

        private void ToggleTheme(object sender, EventArgs e)
        {
            themeManager.ToggleTheme();
            if (localizationManager.GetCurrentLanguage() == "ar")
            {
                ThemeSwitchBtn.Text = themeManager.IsDarkMode
                    ? localizationManager.GetString("Theme_Dark")
                    : localizationManager.GetString("Theme_Light");
            }
            else
            {
                ThemeSwitchBtn.Text = themeManager.IsDarkMode ? "Dark Mode" : "Light Mode";
            }

        }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedIndex == 0)
            {
                localizationManager.SetLanguage("en");
            }
            else
            {
                localizationManager.SetLanguage("ar");
            }
        }


        private async void GoBackHomeBtn_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            parentForm.Close();
            e.Cancel = true;
        }

        private void SelectAllText(object sender, EventArgs e)
        {
            if (Tb_ApplicationCode.Text == "Replace With Your Application Code")
                Tb_ApplicationCode.Text = "";
        }

        private void RetriveIFNoCodeEntered(object sender, EventArgs e)
        {
            if (Tb_ApplicationCode.Text == "") Tb_ApplicationCode.Text = "Replace With Your Application Code";
        }

        private async void Btn_Submit_Click(object sender, EventArgs e)
        {
            if(Tb_ApplicationCode.Text =="" || Tb_ApplicationCode.Text == "Replace With Your Application Code") 
            {
                MessageBox.Show("Please Enter Your Application Code", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if(Tb_ApplicationCode.Text.Length>8 || Tb_ApplicationCode.Text.Length < 8) 
            {
                MessageBox.Show("Please Enter A Valid Application Code", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else 
            {
                try
                {
                    var applicant = await _applicantService.GetApplicationByCodeAsync(Tb_ApplicationCode.Text);
                    if (applicant != null)
                    {
                        // Show The application data
                        panelApplicationData.Visible = true;
                        lblNoDataMessage.Visible = false;

                        lblFullName.Text = $"Full Name: {applicant.FullName}";
                        lblEmail.Text = $"Email: {applicant.Email}";
                        lblGender.Text = $"Gender: {applicant.Gender}";
                        lblAge.Text = $"Age: {applicant.Age}";
                        lblPhone.Text = $"Phone: {applicant.Phone}";
                        lblAddress.Text = $"Address: {applicant.Address}";
                        lblStatus.Text = $"Status: {applicant.Status}";
                        lblCreatedAt.Text = $"Created At: {applicant.CreatedAt:g}";
                    }
                    else
                    {
                        //Show the message 
                        panelApplicationData.Visible = false;
                        lblNoDataMessage.Visible = true;
                        lblNoDataMessage.Text = "No Active Application Were Found. Recheck Your Email or Your Code.";
                    }
                }
                catch(Exception ex)  
                { 
                    MessageBox.Show($"An Exception Was Thrown :\n{ex.Message}","Error",MessageBoxButtons.OK, MessageBoxIcon.Hand);
                } 
            }
                
        }
    }
}
