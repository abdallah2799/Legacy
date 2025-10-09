using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using UI.Infrastructure;
using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace UI.FormsLayer.Shared
{
    public partial class LoginForm : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;
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
            this.Text = localizationManager.GetString("Login_Title");
            lblTitle.Text = localizationManager.GetString("Login_Title");
            txtEmail.Hint = localizationManager.GetString("Login_Email");
            txtPassword.Hint = localizationManager.GetString("Login_Password");
            btnLogin.Text = localizationManager.GetString("Login_Button");
            chkRememberMe.Text = localizationManager.GetString("Login_RememberMe");
            lnkForgotPassword.Text = localizationManager.GetString("Login_ForgotPassword");
            btnBackToHome.Text = localizationManager.GetString("Login_BackToHome");
            
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Please enter your email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Show loading
                btnLogin.Enabled = false;
                btnLogin.Text = "Logging in...";

                // Attempt login
                var user = await _authService.AuthenticateAsync(txtEmail.Text.Trim(), txtPassword.Text);
                
                if (user != null)
                {
                    // Set session
                    sessionManager.Login(user);
                    
                    // Show success message
                    MessageBox.Show($"Welcome back, {user.Username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Navigate to main dashboard
                    var dashboard = new MainDashboard();
                    dashboard.Show();
                    this.Hide();
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
                btnLogin.Enabled = true;
                btnLogin.Text = localizationManager.GetString("Login_Button");
            }
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            var splashPage = new SplashPage();
            splashPage.Show();
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

        private void lnkForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Forgot password functionality will be implemented in a future update.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
