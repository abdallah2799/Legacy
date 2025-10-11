using Core.Interfaces.Services;
using Legacy_System_UI.Infrastructure;
using Legacy_System_UI.Pages.Admin;
using Legacy_System_UI.Pages.Instructor;
using Legacy_System_UI.Pages.Student;
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
    public partial class LoginForm : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;
        private MaterialForm parentForm;
        private SessionManager sessionManager;
        private readonly IAuthService _authService;
        public LoginForm()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            SetupEventHandlers();
            // Get auth service from DI
            var serviceProvider = Program.ServiceProvider;
            _authService = serviceProvider.GetRequiredService<IAuthService>();
        }

        public LoginForm(MaterialForm sender) : this()
        {
            parentForm = sender;
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
            sessionManager = SessionManager.Instance;

            // Apply current theme
            themeManager.ApplyTheme(materialSkinManager);

            // Update UI text
            UpdateUIText();
        }
        private void UpdateUIText()
        {
            // Update form Labels
            this.Text = localizationManager.GetString("Login_Title");
            Lb_WelcomBack.Text = localizationManager.GetString("WelcomeBack");
            Lb_WelcomBack.Location = new Point((Panel_Login.Width - Lb_WelcomBack.Width) / 2, Lb_WelcomBack.Location.Y);
            Lb_LoginOption.Text = localizationManager.GetString("Login_Option");
            if (localizationManager.GetCurrentLanguage() == "ar")
            {
                Lb_LoginOption.Location = new Point(Tb_LoginOption.Location.X + (Tb_LoginOption.Width - Lb_LoginOption.Width), Lb_LoginOption.Location.Y);
            }
            else
            {
                Lb_LoginOption.Location = new Point(Tb_LoginOption.Location.X, Lb_LoginOption.Location.Y);
            }

            Lb_Password.Text = localizationManager.GetString("Login_Password");
            if (localizationManager.GetCurrentLanguage() == "ar")
            {
                Lb_Password.Location = new Point(Tb_Password.Location.X + (Tb_Password.Width - Lb_Password.Width), Lb_Password.Location.Y);
            }
            else
            {
                Lb_Password.Location = new Point(Tb_Password.Location.X, Lb_Password.Location.Y);
            }


            // Update buttons
            GoBackHomeBtn.Text = localizationManager.GetString("GoBack");
            Btn_Login.Text = localizationManager.GetString("Login_Title");

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

        private async void Btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(Tb_LoginOption.Text))
                {
                    MessageBox.Show("Please enter your email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Tb_Password.Text))
                {
                    MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Show loading
                Btn_Login.Enabled = false;
                Btn_Login.Text = "Logging in...";

                // Attempt login
                var user = await _authService.AuthenticateAsync(Tb_LoginOption.Text.Trim(), Tb_Password.Text);

                if (user != null)
                {
                    // Set session
                    sessionManager.Login(user);

                    // Show success message
                    MessageBox.Show($"Welcome back, {user.Username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if(user.Role == "Admin")
                    {
                        // Navigate to admin dashboard
                        var adminDashboard = new AdminMainForm();
                        adminDashboard.Show();
                        this.Hide();
                        return;
                    }
                    else if(user.Role == "Instructor")
                    {
                        // Navigate to instructor dashboard
                        var instructorDashboard = new InstructorMainForm();
                        instructorDashboard.Show();
                        this.Hide();
                        return;
                    } else if(user.Role == "Student")
                    {
                        // Navigate to student dashboard
                        var studentDashboard = new StudentMainForm(user);
                        studentDashboard.Show();
                        this.Hide();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reset button
                Btn_Login.Enabled = true;
                Btn_Login.Text = localizationManager.GetString("Login_Button");
            }
        }
    }
}
