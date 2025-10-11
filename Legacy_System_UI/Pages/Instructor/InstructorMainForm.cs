using Legacy_System_UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legacy_System_UI.Pages.Instructor
{
    public partial class InstructorMainForm : Form
    {
        private readonly SessionManager sessionManager;
        public InstructorMainForm()
        {
            InitializeComponent();
            sessionManager = SessionManager.Instance;
            materialLabel1.Text = sessionManager.UserName;
        }

        
    }
}
