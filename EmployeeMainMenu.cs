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

        private Account accountt = new Account();
        public EmployeeMainMenu(Account account)
        {
            InitializeComponent();
            accountt = account;
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
                
                Category category = (Category)comboCategory.SelectedItem;
                var product = new Product()
                {
                    // CategoryId = Convert.ToInt32(comboCategory.SelectedValue.ToString())
                    CategoryId = category.CategoryID
                };
                List<Product> productscat = proList.GetProductsWithCatID(product);
                dataGridView1.DataSource = productscat;
                this.dataGridView1.Columns["ProductID"].Visible = false;
                this.dataGridView1.Columns["CategoryID"].Visible = false;
                this.dataGridView1.Columns["Image"].Visible = false;
            }
        }
        private void Product_DataChange(object sender, EventArgs e)
        {
            // label2.Text = CalculateFreight().ToString();
            richTextBox1.Text = "";
            // richTextBox1.AppendText("MILK TEA STORE");
            // richTextBox1.AppendText("\nAddress: Thach Hoa - Thach That - Ha Noi");
            // richTextBox1.AppendText("\nPhone: 0123456789");
            // richTextBox1.AppendText("\nTime: "+txtTime.Text);
            // richTextBox1.AppendText("\nCashier: " + accountt.userName);
            richTextBox1.AppendText("\n------------------------------------------------------------------------------------\n");
            richTextBox1.AppendText("\n" + string.Format("{0,-30}{1,-30}{2,-20}{3,-30}", "Product", "Quantity", "Price","Sum"));
            foreach (UserControl1 uc in ProductControls)
            {
                richTextBox1.AppendText("\n" + string.Format("{0,-40}{1,-30}{2,-16}{3,-30}", uc.ProductName, uc.Quantity, uc.ProductPrice + "đ", (uc.ProductPrice*uc.Quantity) + "đ"));
            }
            richTextBox1.AppendText("\n------------------------------------------------------------------------------------");
            richTextBox1.AppendText("\n"+string.Format("{0,-95}{1,-10}","Total: ", CalculateFreight().ToString()+"đ"));

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

        SqlConnection con = new SqlConnection(new AccountBusiness().GetConnectionString());
        private void EmployeeMainMenu_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn cbColumn = new DataGridViewCheckBoxColumn();
            cbColumn.HeaderText = "Check";
            cbColumn.Name = "cbColumn";
            dataGridView1.Columns.Add(cbColumn);
            DataGridViewImageColumn dgvi = new DataGridViewImageColumn();
            comboCategory.DataSource = new CategoryBusiness().GetCategories();
            comboCategory.ValueMember = "CategoryName";
            comboCategory.SelectedItem = null;
            comboCategory.SelectedText = "--select--";
            List<Product> products = proList.GetProducts();
            dataGridView1.DataSource = products;
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "Preview";
            img.Name = "img";
            img.ImageLayout = DataGridViewImageCellLayout.Normal;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string zz = dataGridView1.Rows[i].Cells[6].Value.ToString();
                Image image2 = resizeImage(Image.FromFile(zz),new Size(100,100));
                img.Image = image2;
            }
            dataGridView1.Columns.Add(img);
            this.dataGridView1.Columns["productid"].Visible = false;
            this.dataGridView1.Columns["categoryid"].Visible = false;
            this.dataGridView1.Columns["image"].Visible = false;
            foreach (DataGridViewRow x in dataGridView1.Rows)
            {
                x.MinimumHeight = 100;
            }
            flowLayoutPanel1.AutoScroll = true;
        }
        public Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;

            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprmm", 230, 600);

            printPreviewDialog1.ShowDialog();
            OrdersBusiness orders = new OrdersBusiness();
            orders.InsertOrder(new Order
            {
                employeeId = accountt.userId,
                total = CalculateFreight(),
                date = DateTime.Now
            });
            Order order = orders.Get1Orders();
            OrdersDetailBusiness ordersDetailBusiness = new OrdersDetailBusiness();
            foreach (UserControl1 uc in ProductControls)
            {
                ordersDetailBusiness.InsertOrderDetail(new OrdersDetail
                {
                    orderId = order.orderId,
                    price = uc.ProductPrice,
                    quantity = uc.Quantity,
                    productName = uc.ProductID
                });
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("MILK TEA STORE", new Font("Arial",10,FontStyle.Bold),Brushes.Black,10,20);
            e.Graphics.DrawString("Address: Thach Hoa - Thach That - Ha Noi", new Font("Arial", 5, FontStyle.Regular), Brushes.Black, 10, 40);
            e.Graphics.DrawString("Phone: 0123456789", new Font("Arial", 5, FontStyle.Regular), Brushes.Black, 10, 50);
            e.Graphics.DrawString("Time: "+txtTime.Text, new Font("Arial", 5, FontStyle.Regular), Brushes.Black, 10, 60);
            e.Graphics.DrawString("Cashier: " + accountt.userName, new Font("Arial", 5, FontStyle.Regular), Brushes.Black, 10, 70);
            // e.Graphics.DrawString("------------------------------------------------------------------------------------", new Font("Arial", 5, FontStyle.Regular), Brushes.Black, 10, 80);
            e.Graphics.DrawString(richTextBox1.Text, new Font("Arial", 5, FontStyle.Regular), Brushes.Black, 10, 90);
            // e.Graphics.DrawString("------------------------------------------------------------------------------------", new Font("Arial", 5, FontStyle.Regular), Brushes.Black, 10, 100);
            // e.Graphics.DrawString(string.Format("{0,-75}{1,-10}", "Total: ", CalculateFreight().ToString()), new Font("Arial", 5, FontStyle.Bold), Brushes.Black, 10, 540);
            // e.Graphics.DrawString("Thank you ! See you later !!", new Font("Arial", 5, FontStyle.Bold), Brushes.Black, 10, 90);
        }
    }
}
