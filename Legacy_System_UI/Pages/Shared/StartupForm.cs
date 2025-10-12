using Legacy_System_UI.Infrastructure;
using MaterialSkin;
using MaterialSkin.Controls;
using Legacy_System_UI.Pages.Guest;
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
    public partial class StartupForm : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;


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
            // Update labels
            this.Text = localizationManager.GetString("Startup_Title");
            Lb_Welcome.Text = localizationManager.GetString("Welcome");
            Lb_Welcome.Location = new Point((Width - Lb_Welcome.Width) / 2, Lb_Welcome.Location.Y);

            Lb_Slogan.Text = localizationManager.GetString("Slogan");
            Lb_Slogan.Location = new Point((Width - Lb_Slogan.Width) / 2, Lb_Slogan.Location.Y);

            // Update buttons
            Login_Btn.Text = localizationManager.GetString("Login_Title");
            Apply_Btn.Text = localizationManager.GetString("Apply");
            QB_Btn.Text = localizationManager.GetString("Menu_QuestionBank");
            CheckStatus_Btn.Text = localizationManager.GetString("check_status");

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

        public StartupForm()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            SetupEventHandlers();
        }

        private void Login_Btn_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(this);
            this.Hide();
            loginForm.Show();   
        }

        private void Apply_Btn_Click(object sender, EventArgs e)
        {
            var applianceForm = new ApplianceMainForm(this);
            this.Hide();
            applianceForm.Show();
        }

        private void QB_Btn_Click(object sender, EventArgs e)
        {
            var questionBankForm = new QuestionBankForm(this);
            this.Hide();
            questionBankForm.Show();
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
                else
                {
                    base.OnFormClosing(e);
                }
            }

        }

        private void CheckStatus_Btn_Click(object sender, EventArgs e)
        {
            var checkApplicationStatusForm = new CheckApplicationStatusForm(this);
            this.Hide();
            checkApplicationStatusForm.Show();
        }
    }
}
