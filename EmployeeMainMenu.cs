using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoDataAccess;
using MenuCRUD;
using Microsoft.Data.SqlClient;
using MilkTeaManagement.Business;
using ShoppingCartNew.Business;

namespace MilkTeaManagement
{
    public partial class EmployeeMainMenu : Form
    {
        public EmployeeMainMenu()
        {
            InitializeComponent();
        }

        public EmployeeMainMenu(Account account)
        {
            InitializeComponent();
            txtUsername.Text = "Wellcome " + account.userName + " !";
            timer1.Start();
        }

        List<UserControl1> ProductControls = new List<UserControl1>();
        CategoryBusiness catList = new CategoryBusiness();
        ProductBusiness proList = new ProductBusiness();
        private decimal CalculateFreight()
        {
            decimal sum = 0;
            foreach (UserControl1 uc in ProductControls)
                sum += uc.ProductPrice * uc.Quantity;
            return sum;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            txtTime.Text = dt.ToString("HH:MM:ss dd-MM-yyyy");
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCategory.SelectedItem == null)
            {

            }
            else
            {
                var product = new Product()
                {
                    CategoryId = Convert.ToInt32(comboCategory.SelectedValue.GetHashCode())
                };
                List<Product> productscat = proList.GetProductsWithCatID(product);
                dataGridView1.DataSource = productscat;
                this.dataGridView1.Columns["ProductID"].Visible = false;
                this.dataGridView1.Columns["CategoryID"].Visible = false;
            }
        }
        private void Product_DataChange(object sender, EventArgs e)
        {
            label2.Text = CalculateFreight().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //lay tu datagridview
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {

                    for (int i = 0; i <= dataGridView1.Rows.Count; i++)
                    {
                        //Product p; UserControl1 MyControl = new UserControl1(p.ProductID, p.ProductName, p.Price, 1);
                        UserControl1 MyControl = new UserControl1(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), Convert.ToDecimal(row.Cells[3].Value), 1);
                        MyControl.PropertyChange += Product_DataChange;
                        if (!ProductControls.Contains(MyControl))
                        {
                            ProductControls.Add(MyControl);
                            flowLayoutPanel1.Controls.Add(MyControl);
                            //break de khong vuong vao vonng loop cua 3 san pham
                            break;

                        }
                        else
                        {
                            ProductControls[ProductControls.IndexOf(MyControl)].Quantity += 1;
                            //tuong tu
                            break;
                        }
                    }
                }


            }
            Product_DataChange(null, null);
        }

        private void NormalImage(object sender, EventArgs e)
        {

            foreach (DataGridViewImageColumn column in
                dataGridView1.Columns)
            {
                column.ImageLayout = DataGridViewImageCellLayout.Normal;
                column.Description = "Normal";
            }
        }

        SqlConnection con = new SqlConnection(new AccountBusiness().GetConnectionString());
        private void EmployeeMainMenu_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn cbColumn = new DataGridViewCheckBoxColumn();
            cbColumn.HeaderText = "Check";
            cbColumn.Name = "cbColumn";
            dataGridView1.Columns.Add(cbColumn);
            DataGridViewImageColumn dgvi = new DataGridViewImageColumn();

            comboCategory.DataSource = new CategoryBusiness().GetCategories();

            comboCategory.SelectedItem = null;
            comboCategory.SelectedText = "--select--";
            con.Open();
            SqlCommand cmd = new SqlCommand("Select CategoryId from Category", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();

            comboCategory.DataSource = ds.Tables[0];
            comboCategory.ValueMember = "CategoryId";

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "Image2";
            img.Name = "img";

            img.ImageLayout = DataGridViewImageCellLayout.Normal;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string zz = dataGridView1.Rows[i].Cells[5].Value.ToString();
                Image image2 = Image.FromFile(@zz);
                img.Image = image2;
            }
            dataGridView1.Columns.Add(img);

            this.dataGridView1.Columns["productid"].Visible = false;
            this.dataGridView1.Columns["categoryid"].Visible = false;

            flowLayoutPanel1.AutoScroll = true;
        }
    }
}
