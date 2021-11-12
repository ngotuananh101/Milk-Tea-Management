using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilkTeaManagement.Business;

namespace MilkTeaManagement
{
    public partial class AdminMainMenu : Form
    {
        public AdminMainMenu()
        {
            InitializeComponent();
        }

        public AdminMainMenu(Account account)
        {
            InitializeComponent();
            txtWellcome.Text = "Wellcome " + account.userName + " !";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AdminMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
