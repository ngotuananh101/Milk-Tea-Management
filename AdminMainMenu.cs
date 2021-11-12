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
            timer1.Start();
        }

        public AdminMainMenu(Account account)
        {
            InitializeComponent();
            txtWellcome.Text = "Wellcome " + account.userName + " !";
            timer1.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AdminMainMenu_Load(object sender, EventArgs e)
        {
            getHome();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label1.Text = dt.ToString("HH:MM:ss");
        }

        private void getHome()
        {
            AdminHome home = new AdminHome();
            home.TopLevel = false;
            panelDetail.Controls.Add(home);
            home.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            panelDetail.Controls.Clear();
            AdminEmployee employee = new AdminEmployee();
            employee.TopLevel = false;
            panelDetail.Controls.Add(employee);
            employee.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelDetail.Controls.Clear();
            getHome();
        }

        private void btnStatic_Click(object sender, EventArgs e)
        {
            panelDetail.Controls.Clear();
            AdminStatic statics = new AdminStatic();
            statics.TopLevel = false;
            panelDetail.Controls.Add(statics);
            statics.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            panelDetail.Controls.Clear();
            AdminProduct product = new AdminProduct();
            product.TopLevel = false;
            panelDetail.Controls.Add(product);
            product.Show();
        }
    }
}
