using Legacy_System_UI.Infrastructure;
using MaterialSkin;
using MaterialSkin.Controls;
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
        public StartupForm()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            SetupEventHandlers();
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
                ThemeSwitchBtn.Text = themeManager.IsDarkMode? "Dark Mode" : "Light Mode";
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
    }
}
