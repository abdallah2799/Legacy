using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;

namespace UI.FormsLayer.Shared
{
    public partial class SplashPage : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;

        public SplashPage()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            SetupEventHandlers();
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

        private void UpdateUIText()
        {
            this.Text = localizationManager.GetString("Splash_Title");
            lblWelcome.Text = localizationManager.GetString("Splash_Welcome");
            lblSubtitle.Text = localizationManager.GetString("Splash_Subtitle");
            btnLogin.Text = localizationManager.GetString("Splash_Login");
            btnApply.Text = localizationManager.GetString("Splash_Apply");
            btnPractice.Text = localizationManager.GetString("Splash_Practice");
            
            // Update language combo
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_English")} (EN)");
            cmbLanguage.Items.Add($"{localizationManager.GetString("Language_Arabic")} (AR)");
            cmbLanguage.SelectedIndex = localizationManager.GetCurrentLanguage() == "ar" ? 1 : 0;
            
            // Update theme button
            btnTheme.Text = themeManager.GetCurrentTheme() == ThemeMode.Light 
                ? localizationManager.GetString("Theme_Dark") 
                : localizationManager.GetString("Theme_Light");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var applicationForm = new ApplicantApplicationForm();
            applicationForm.Show();
            this.Hide();
        }

        private void btnPractice_Click(object sender, EventArgs e)
        {
            var practiceForm = new GuestPracticeForm();
            practiceForm.Show();
            this.Hide();
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnTheme_Click(object sender, EventArgs e)
        {
            themeManager.ToggleTheme();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnFormClosing(e);
        }

        // Removed Application.Exit() here to avoid re-entrancy/hangs; rely on OnFormClosing confirmation
    }
}
