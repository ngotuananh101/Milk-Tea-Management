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
using Microsoft.Data.SqlClient;
using MilkTeaManagement.Business;

namespace MilkTeaManagement
{
    public partial class AdminEmployee : Form
    {
        SqlConnection con = new SqlConnection(new AccountBusiness().GetConnectionString());
        public AdminEmployee()
        {
            InitializeComponent();
        }

        AccountBusiness catList = new AccountBusiness();
        void LoadAccount()
        {
            var accounts = catList.GetAccounts();
            txtPassword.DataBindings.Clear();
            txtUsername.DataBindings.Clear();
            cboRoleId.DataBindings.Clear();
            txtUserId.DataBindings.Clear();
            txtUsername.DataBindings.Add("Text", accounts, "Username");
            txtPassword.DataBindings.Add("Text", accounts, "Password");
            cboRoleId.DataBindings.Add("Text", accounts, "RoleId");
            txtUserId.DataBindings.Add("Text", accounts, "UserId");

            dataGridView1.DataSource = accounts;

        }

        bool ValidForm()
        {
            bool flag = true;

            string strError = "";

            Regex regUsername = new Regex(@"^[0-9a-zA-Z\s]+$");
            if (!regUsername.IsMatch(txtUsername.Text.Trim()))
            {
                flag = false;
                strError += "Username can't be empty or contain special character!\n";
                txtUsername.Focus();
            }

            Regex regPassword = new Regex(@"^[0-9a-zA-Z\s]+$");
            if (!regPassword.IsMatch(txtPassword.Text.Trim()))
            {
                flag = false;
                strError += "Password can't be empty or contain special character!\n";
                txtPassword.Focus();

            }

            Regex regRoleId = new Regex(@"^[0-9\s]+$");
            if (!regRoleId.IsMatch(cboRoleId.Text.Trim()))
            {
                flag = false;
                strError += "Invalid RoleId!\n";
                cboRoleId.Focus();

            }

            Regex regUserId = new Regex(@"^[0-9\s]+$");
            if (!regUserId.IsMatch(txtUserId.Text.Trim()))
            {
                flag = false;
                strError += "Invalid UserId\n";
                txtUserId.Focus();

            }

            if (flag == false)
            {
                MessageBox.Show(strError);
            }
            return flag;
        }

        private void AdminEmployee_Load(object sender, EventArgs e)
        {
            LoadAccount();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Role", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();

            cboRoleId.DataSource = ds.Tables[0];
            cboRoleId.ValueMember = "RoleId";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidForm())
            {
                //hien thi du lieu tren form len 1 messagebox
                String strResult = "";
                strResult += "Username: " + txtUsername.Text.Trim() + "\n";
                strResult += "Password: " + txtPassword.Text.Trim() + "\n";
                strResult += "RoleId: " + cboRoleId.Text.Trim() + "\n";
                strResult += "UserId: " + txtUserId.Text.Trim();

                MessageBox.Show(strResult);
            }
            try
            {
                var account = new Account { userName = txtUsername.Text, passWord = txtPassword.Text, roleId = Convert.ToInt32(cboRoleId.Text), userId = txtUserId.Text };

                catList.InsertAccount(account);
                LoadAccount();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        void Clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            cboRoleId.Text = "";
            txtUserId.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var account = new Account { userName = txtUsername.Text, passWord = txtPassword.Text, roleId = Convert.ToInt32(cboRoleId.Text), userId = txtUserId.Text };

            catList.DeleteAccount(account);
            LoadAccount();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var account = new Account { userName = txtUsername.Text, passWord = txtPassword.Text, roleId = Convert.ToInt32(cboRoleId.Text), userId = txtUserId.Text };

            catList.UpdateAccount(account);
            LoadAccount();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (cboRoleId.SelectedIndex == 0)
            {
                btnEditManager.Visible = true;
                btnEditInfo.Visible = false;
            }else if (cboRoleId.SelectedIndex == 1)
            {
                btnEditManager.Visible = false;
                btnEditInfo.Visible = true;
            }
            
            // MessageBox.Show(cboRoleId.SelectedIndex.ToString(), cboRoleId.SelectedText);
        }
    }
}
