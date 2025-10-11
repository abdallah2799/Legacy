using Core.Models;
using Core.Models;
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

namespace Legacy_System_UI.Pages.Admin
{
    public partial class AdminMainForm : Form
    {
        private readonly SessionManager sessionManager;
        public AdminMainForm()
        {
            InitializeComponent();
            sessionManager = SessionManager.Instance;
            materialLabel1.Text = sessionManager.UserName;
        }
        
    }
}
