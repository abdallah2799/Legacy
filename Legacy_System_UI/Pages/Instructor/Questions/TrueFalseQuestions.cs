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

namespace Legacy_System_UI.Pages.Instructor.Questions
{
    public partial class TrueFalseQuestions : MaterialForm
    {
        private readonly SessionManager sessionManager;

        private MaterialSkinManager materialSkinManager;
        private ThemeManager themeManager;
        private LocalizationManager localizationManager;
        public TrueFalseQuestions()
        {
            InitializeComponent();
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

            themeManager = ThemeManager.Instance;
            themeManager.ApplyTheme(materialSkinManager);

            sessionManager = SessionManager.Instance;
        }
    }
}
