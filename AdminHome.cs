using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using MilkTeaManagement.Business;

namespace MilkTeaManagement
{
    public partial class AdminHome : Form
    {
        SqlConnection con = new SqlConnection(new AccountBusiness().GetConnectionString());
        public AdminHome()
        {
            InitializeComponent();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd =
                new SqlCommand(
                    "SELECT COUNT(Orders.OrderId) As TotalOrder, COUNT(Product.ProductId) As TotalProduct, COUNT(Employee.EmployeeId) As TotalEmployee FROM Orders, Product, Employee",
                    con);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows == true)
            {
                while (reader.Read())
                {
                    label4.Text = reader.GetInt32("TotalOrder").ToString();
                    label5.Text = reader.GetInt32("TotalProduct").ToString();
                    label6.Text = reader.GetInt32("TotalEmployee").ToString();
                }

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
