using MilkTeaManagement.Business;
using MilkTeaManagement.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft;

namespace MilkTeaManagement
{
    public partial class AdminStatic : Form
    {
        public AdminStatic()
        {
            InitializeComponent();
        }

        OrdersBusiness orderList = new OrdersBusiness();
        OrdersDetailBusiness ordersDetailList = new OrdersDetailBusiness();
        EmployeeBusiness employeeList = new EmployeeBusiness();
        ManagerBusiness managerList = new ManagerBusiness();

        internal void refreshDgvOrders()
        {
            List<Order> orders = orderList.GetOrders();
            dgvOrder.Columns.Clear();
            dgvOrder.DataSource = null;
            dgvOrder.DataSource = orders;
            dgvOrder.Columns["OrderId"].ReadOnly = true;
            dgvOrder.Columns["EmployeeId"].ReadOnly = true;
            dgvOrder.Columns["Total"].ReadOnly = true;
            dgvOrder.Columns["Date"].ReadOnly = true;
        }

        internal void refreshDgvOrders(string search)
        {

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dgvOrder.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dgvOrder.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvOrder.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvOrder.Columns.Count; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dgvOrder.Rows[i].Cells[j].Value.ToString();
                    }
                }
                ExcelApp.Columns.AutoFit();
                ExcelApp.ActiveWorkbook.SaveCopyAs(sfd.FileName + ".xls");
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
                MessageBox.Show("Records Successfully Exported");
            }
            else if (dr != DialogResult.OK)
            {
                MessageBox.Show("Not Exported");
            }
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            refreshDgvOrders();

        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderId = Convert.ToInt32(dgvOrder.CurrentRow.Cells["OrderId"].Value);
            string employeeId = dgvOrder.CurrentRow.Cells["EmployeeId"].Value.ToString();
            string managerId = employeeList.GetManagerId(employeeId);
            List<Employee> employee = employeeList.GetEmployeeById(employeeId);
            

            List<OrdersDetail> ordersDetails = ordersDetailList.GetOrdersDetailsById(orderId);
            List<Manager> manager = managerList.GetManagerById(managerId.ToString());
            dgvOrderDetails.DataSource = null;
            dgvOrderDetails.DataSource = ordersDetails;
            dgvOrderDetails.Columns["OrderId"].Visible = false;

            txtEId.DataBindings.Clear();
            txtEName.DataBindings.Clear();
            txtEDob.DataBindings.Clear();
            txtEEmail.DataBindings.Clear();
            txtEPhone.DataBindings.Clear();
            txtEAddress.DataBindings.Clear();
            txtEUserId.DataBindings.Clear();
            txtMId.DataBindings.Clear();
            txtMName.DataBindings.Clear();
            txtMDob.DataBindings.Clear();
            txtMEmail.DataBindings.Clear();
            txtMPhone.DataBindings.Clear();
            txtMAddress.DataBindings.Clear();
            txtMUserId.DataBindings.Clear();

            txtEId.DataBindings.Add("Text", employee, "EmployeeId");
            txtEName.DataBindings.Add("Text", employee, "EmployeeName");
            txtEDob.DataBindings.Add("Text", employee, "EmployeeDob");
            txtEEmail.DataBindings.Add("Text", employee, "EmployeeEmail");
            txtEPhone.DataBindings.Add("Text", employee, "Phone");
            txtEAddress.DataBindings.Add("Text", employee, "Address");
            txtEUserId.DataBindings.Add("Text", employee, "UserId");
            

            txtMId.DataBindings.Add("Text", manager, "ManagerId");
            txtMName.DataBindings.Add("Text", manager, "ManagerName");
            txtMDob.DataBindings.Add("Text", manager, "ManagerDob");
            txtMEmail.DataBindings.Add("Text", manager, "ManagerEmail");
            txtMPhone.DataBindings.Add("Text", manager, "Phone");
            txtMAddress.DataBindings.Add("Text", manager, "Address");
            txtMUserId.DataBindings.Add("Text", manager, "UserId");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtMAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
