using Microsoft.Data.SqlClient;
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
using MenuCRUD;
using MilkTeaManagement.Business;

namespace MilkTeaDemo
{
    public partial class EmployeeDetail : Form
    {
        public EmployeeDetail()
        {
            InitializeComponent();
        }

        private Account account;
        private int addOrEdit = 1;
        public EmployeeDetail(Account accountt)
        {
            InitializeComponent();
            account = accountt;
        }

        EmployeeBusiness catList = new EmployeeBusiness();
        SqlConnection con = new SqlConnection(new AccountBusiness().GetConnectionString()
        
        
        );

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidForm())
            {
                //hien thi du lieu tren form len 1 messagebox
                String strResult = "";
                strResult += "Id: " + txtID.Text.Trim() + "\n";
                strResult += "Employee Name: " + txtName.Text.Trim() + "\n";
                strResult += "Date of Birth: " + txtDob.Text.Trim() + "\n";
                strResult += "Email: " + txtEmail.Text.Trim() + "\n";
                strResult += "Phone: " + txtPhone.Text.Trim() + "\n";
                strResult += "Address: " + txtAddress.Text.Trim() + "\n";
                strResult += "Gender: " + rbFemale.Checked +"\n";
                strResult += "ManagerId: " + cboManId.Text.Trim();
                MessageBox.Show(strResult);

                if (account.roleId == 1)
                {
                    ManagerBusiness mb = new ManagerBusiness();
                    Manager manager = new Manager
                    {
                        managerId = txtID.Text,
                        managerName = txtName.Text,
                        managerDob = txtDob.Text,
                        managerEmail = txtEmail.Text,
                        phone = txtPhone.Text,
                        address = txtAddress.Text,
                        gender = rbMale.Checked,
                        userId = account.userId
                    };
                    if (addOrEdit == 1)
                    {
                        // add new manager info
                        mb.InsertManager(manager);

                    }else if (addOrEdit == 2)
                    {
                        // edit manager info
                        mb.UpdateManager(manager);
                    }
                }
                else if(account.roleId == 2)
                {
                    EmployeeBusiness eb = new EmployeeBusiness();
                    Employee employee = new Employee
                    {
                        employeeId = txtID.Text,
                        employeeName = txtName.Text,
                        employeeDob = txtDob.Text,
                        employeeEmail = txtEmail.Text,
                        phone = txtPhone.Text,
                        address = txtAddress.Text,
                        gender = rbMale.Checked,
                        managerId = cboManId.SelectedValue.ToString(),
                        userId = account.userId
                    };
                    if (addOrEdit == 1)
                    {
                        // add new employee info
                        
                        eb.InsertEmployee(employee); 

                    }
                    else if (addOrEdit == 2)
                    {
                        // edit employee info
                        eb.UpdateEmployee(employee);
                    }
                }
            }

        }

        private void Employee_Detail_Load(object sender, EventArgs e)
        {
            if (account.roleId == 1)
            {
                loadManager();
                cboManId.Visible = false;
                lblManager.Visible = false;

            }else if (account.roleId == 2)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select ManagerId from Manager", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.ExecuteNonQuery();
                con.Close();
                cboManId.DataSource = ds.Tables[0];
                cboManId.ValueMember = "ManagerId";
                loadEmplooyee();
            }

        }

        void loadEmplooyee()
        {
            EmployeeBusiness eb = new EmployeeBusiness();
            int userId = Int32.Parse(account.userId);
            Employee employee = eb.GetEmployeeByUserID(userId);
            if (employee != null)
            {
                addOrEdit = 2;
                txtID.Text = employee.employeeId;
                txtName.Text = employee.employeeName;
                txtDob.Text = employee.employeeDob;
                txtEmail.Text = employee.employeeEmail;
                txtPhone.Text = employee.phone;
                txtAddress.Text = employee.address;
                if (employee.gender)
                {
                    rbMale.Checked = true;
                    rbFemale.Checked = false;
                }
                else
                {
                    rbMale.Checked = false;
                    rbFemale.Checked = true;
                }
            }
            else
            {
                addOrEdit = 1;
            }
        }
        void loadManager()
        {
            ManagerBusiness mb = new ManagerBusiness();
            int userId = Int32.Parse(account.userId);
            Manager manager = mb.GetManagerByUserID(userId);
            if (manager != null)
            {
                addOrEdit = 2;
                txtID.Text = manager.managerId;
                txtName.Text = manager.managerName;
                txtDob.Text = manager.managerDob;
                txtEmail.Text = manager.managerEmail;
                txtPhone.Text = manager.phone;
                txtAddress.Text = manager.address;
                if (manager.gender)
                {
                    rbMale.Checked = true;
                    rbFemale.Checked = false;
                }
                else
                {
                    rbMale.Checked = false;
                    rbFemale.Checked = true;
                }
            }
            else
            {
                addOrEdit = 1;
            }
        }

        bool ValidForm()
        {
            bool flag = true;

            string strError = "";
            //
            // Regex regEmpDob = new Regex(@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$");
            // if (!regEmpDob.IsMatch(txtDob.Text.Trim()))
            // {
            //     flag = false;
            //     strError += "Invalid Date of birth!\n";
            //     txtDob.Focus();
            // }

            Regex regEmpEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regEmpEmail.IsMatch(txtEmail.Text.Trim()))
            {
                flag = false;
                strError += "Invalid Email!\n";
                txtEmail.Focus();
            }

           
            //
            // Regex regAddress = new Regex(@"^[0-9a-zA-Z\s]+$");
            // if (!regAddress.IsMatch(txtAddress.Text.Trim()))
            // {
            //     flag = false;
            //     strError += "Invalid Address!\n";
            //     txtAddress.Focus();
            //
            // }

           

            if (flag == false)
            {
                MessageBox.Show(strError);
            }
            return flag;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDob.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            rbFemale.Checked = false;
            rbMale.Checked = false;
            cboManId.Text = "";
        }

        private void cboManId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
