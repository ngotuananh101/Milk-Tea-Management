using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilkTeaManagement.Business;

namespace MilkTeaManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        AccountBusiness accountList = new AccountBusiness();
        RoleBusiness roleList = new RoleBusiness();
        public bool validAccount()
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (user == "" || pass == "")
            {
                return false;
            }
            Regex regex = new Regex(@"^([a-zA-Z0-9_\.]+)$");
            if (!regex.IsMatch(user) || !regex.IsMatch(pass))
            {
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text.Trim();
            string Password = txtPassword.Text.Trim();

            if (validAccount())
            {
                //string sql = "select * from Account where Username = '" + Username + "' and Password = '" + Password + "' and RoleId = " + cbbRole.SelectedValue;
                //if (Database.GetDataBySql(sql).Rows.Count > 0)
                List<Account> accounts = accountList.GetAccount(Username, Password);
                if (accounts.Count > 0)
                {
                    if (accounts[0].roleId == 2)
                    {
                        //Employee form
                        
                    }
                    if (accounts[0].roleId == 1)
                    {

                        this.Hide();
                        AdminMainMenu adminMain = new AdminMainMenu(accounts[0]);
                        adminMain.ShowDialog();
                        // Statistic form = new Statistic();
                        //form.lblManagerId.Text = Database.GetUserId(Username, Password, Convert.ToInt32(cbbRole.SelectedValue));
                        // form.ShowDialog();
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("This account not exist or no permission!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid Account or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
