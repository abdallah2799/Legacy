using Common.Enums;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Legacy_System_UI.Infrastructure;
using Legacy_System_UI.Pages.Shared;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legacy_System_UI.Pages.Admin
{
    public partial class AdminMainForm : MaterialForm
    {
        private SessionManager sessionManager;
        private readonly MaterialForm parentForm;
        private MaterialSkinManager materialSkinManager;
        private LocalizationManager localizationManager;
        private ThemeManager themeManager;
        private IUserService userService;
        private IBranchService branchService;
        private ITrackService trackService;
        private ICourseService courseService;
        private IReportService reportService;

        public AdminMainForm()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            SetupEventHandlers();

            // Inject all required services
            userService = Program.ServiceProvider.GetRequiredService<IUserService>();
            branchService = Program.ServiceProvider.GetRequiredService<IBranchService>();
            trackService = Program.ServiceProvider.GetRequiredService<ITrackService>();
            courseService = Program.ServiceProvider.GetRequiredService<ICourseService>();
            reportService = Program.ServiceProvider.GetRequiredService<IReportService>();

            this.Load += (s, e) =>
            {
                // اربط الـselector بالـtab control الداخلي
                materialTabSelector1.BaseTabControl = materialTabControl1;

                // خليه ياخد المساحة الصح داخل التاب
                materialTabSelector1.Dock = DockStyle.Top;
                materialTabControl1.Dock = DockStyle.Fill;

                // إظهار الـMain tab control (كان Hidden)
                materialTabControl.Visible = true;

                // Load profile data when form loads
                LoadProfileData();


            };
        }
        public AdminMainForm(MaterialForm _parentForm) : this()
        {
            parentForm = _parentForm;
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



            // Update buttons


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
            //gridAdminsData.GridColor;
            if (themeManager.IsDarkMode)
                gridAdminsData.ForeColor = gridAdminsForDelete.ForeColor = gridAdminsForUpdate.ForeColor = Color.Black;

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



        private void BtnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                // Show confirmation dialog
                var result = MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Logout from session
                    SessionManager.Instance.Logout();

                    // Close current form
                    this.Hide();

                    //// Show login form
                    parentForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadProfileData()
        {
            try
            {
                var currentUser = SessionManager.Instance.GetCurrentUser();
                if (currentUser != null)
                {
                    // Fill profile form with current user data
                    txtProfileFullname.Text = currentUser.FullName ?? "";
                    txtProfileUsername.Text = currentUser.Username ?? "";
                    txtProfileEmail.Text = currentUser.Email ?? "";
                    txtProfileAddress.Text = currentUser.Address ?? "";
                    txtProfilePhone.Text = currentUser.Phone ?? "";
                    txtProfileAge.Text = currentUser.Age.ToString() ?? "";
                    txtProfilePassword.Text = ""; // Leave password empty

                    // Set gender if available
                    if (!string.IsNullOrEmpty(currentUser.GenderDisplay))
                    {
                        cmbProfileGender.SelectedItem = currentUser.Gender;
                    }
                    else
                    {
                        cmbProfileGender.SelectedIndex = 0; // Default to first item
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            try
            {
                // For now, just show a success message
                MessageBox.Show(
                    "Profile updated successfully (simulation).",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // TODO: Add actual update logic here later
                // This will involve:
                // 1. Validating all fields
                // 2. Calling userService.UpdateUserAsync() or similar method
                // 3. Updating SessionManager if successful
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.Close();
                e.Cancel = true;
            }
            else System.Windows.Forms.Application.Exit();
        }

        private async void btnShowAllAdmins_Click(object sender, EventArgs e)
        {
            var data = await userService.GetUsersByRoleAsync("Admin");
            var admins = data.Select(a => new { AdminID = a.UserId, a.FullName, a.Username, a.Email, a.Age, a.Phone, a.Address }).ToList();
            gridAdminsData.DataSource = admins;

        }

        private async void btnSearchAdmin_Click(object sender, EventArgs e)
        {
            if (txtSearchAdmin.Text == null || txtSearchAdmin.Text.Length == 0)
            {
                MessageBox.Show("Please provide a criteria and input to search for", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var allAdmins = await userService.GetUsersByRoleAsync("Admin");
            List<User> user = new();
            //IEnumerable<User> admins;
            //if (gridAdminsData.DataSource == null)
            //{
            //    admins =await userService.GetProfileAsync
            //}
            var selected = tabShowAdmins.Controls.OfType<MaterialSkin.Controls.MaterialRadioButton>().FirstOrDefault(r => r.Checked);

            if (selected != null)
            {
                string selectedText = selected.Text.Trim();

                switch (selectedText)
                {
                    case "Username":
                        // 🧠 Add logic to search by Username
                        var admin = allAdmins.FirstOrDefault(a => a.Username == txtSearchAdmin.Text);
                        if (admin != null)
                            user.Add(admin);
                        else
                            MessageBox.Show("No user Found", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        gridAdminsData.DataSource = user.Select(a => new { AdminID = a.UserId, a.FullName, a.Username, a.Email, a.Age, a.Phone, a.Address }).ToList();
                        break;

                    case "ID":
                        // 🧠 Add logic to search by ID

                        bool result = int.TryParse(txtSearchAdmin.Text, out var id);
                        if (result)
                        {
                            admin = allAdmins.FirstOrDefault(a => a.UserId == id);
                            if (admin != null)
                                user.Add(admin);
                            else
                                MessageBox.Show("No user Found", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            gridAdminsData.DataSource = user.Select(a => new { AdminID = a.UserId, a.FullName, a.Username, a.Email, a.Age, a.Phone, a.Address }).ToList();
                        }
                        else
                        {
                            MessageBox.Show("Please provide a valid ID", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case "Email":
                        // 🧠 Add logic to search by Email
                        admin = allAdmins.FirstOrDefault(a => a.Email == txtSearchAdmin.Text);
                        if (admin != null)
                            user.Add(admin);
                        else
                            MessageBox.Show("No user Found", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        gridAdminsData.DataSource = user.Select(a => new { AdminID = a.UserId, a.FullName, a.Username, a.Email, a.Age, a.Phone, a.Address }).ToList();
                        break;

                    default:
                        MessageBox.Show("Unexpected option selected.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select a search criteria.",
                    "Careful", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }


    }
}
