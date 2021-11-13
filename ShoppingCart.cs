using DemoDataAccess;
using ShoppingCartNew.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingCartNew
{
    public partial class ShoppingCart : Form
    {
        CategoryBusiness catList = new CategoryBusiness();
        ProductBusiness proList = new ProductBusiness();
        public ShoppingCart()
        {
            InitializeComponent();
           
        }

        List<UserControl1> ProductControls = new List<UserControl1>();
        private decimal CalculateFreight()
        {
            decimal sum = 0;
            foreach (UserControl1 uc in ProductControls)
                sum += uc.ProductPrice * uc.Quantity;
            return sum;
        }

        //du lieu thay doi
        private void Product_DataChange(object sender, EventArgs e)
        {
            label2.Text = CalculateFreight().ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //in bill
        }

        //moi lan thay doi thi chon cach load
        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {//comboCategory.SelectedValue
            //int i = Convert.ToInt32(comboCategory.SelectedValue.GetHashCode();
            if (comboCategory.SelectedItem == null) 
            { 
               
            }
            else
            { 
                var product = new Product()
                {
                    CategoryID = Convert.ToInt32(comboCategory.SelectedValue.GetHashCode())
                };
                List<Product> productscat = proList.GetProductsWithCatID(product);
                dataGridView1.DataSource = productscat;
                this.dataGridView1.Columns["ProductID"].Visible = false;
                this.dataGridView1.Columns["CategoryID"].Visible = false;
            }
        }

        //dung de load lai form ma ko can thhay doi index
        private void reloadEmployee()
        {
            // comboCategory.SelectedIndex = 0;
            


        }

       
        private void button2_Click(object sender, EventArgs e)
        {
           
            //lay tu datagridview
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {

                    for (int i = 0; i <= dataGridView1.Rows.Count;i++)
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
        private void ShoppingCart_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn cbColumn = new DataGridViewCheckBoxColumn();
            cbColumn.HeaderText = "Check";
            cbColumn.Name = "cbColumn";
            dataGridView1.Columns.Add(cbColumn);
            DataGridViewImageColumn dgvi = new DataGridViewImageColumn();

            comboCategory.DataSource = new CategoryBusiness().GetCategories();
           
            comboCategory.SelectedItem = null;
            comboCategory.SelectedText = "--select--";



            //this.dataGridView1.Columns["Image"].

            //dataGridView1.AutoGenerateColumns = false;




            List<Product> products = proList.GetProducts();
            dataGridView1.DataSource = products;
            
            

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "Image2";
            img.Name = "img";
            
           
            img.ImageLayout = DataGridViewImageCellLayout.Normal;
            for(int i=0; i < dataGridView1.Rows.Count; i++)
            {
                //string zz = dataGridView1.Rows[i].Cells[5].Value.ToString();
                //Image image = Image.FromFile(zz);
                //img.Image = image;
                //break;
                    
                    string zz = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    Image image2 = Image.FromFile(@zz);
                    img.Image = image2;
                   // dataGridView1.Rows.Add();
                   // dataGridView1["Image",i].Value = image2;
                    //dataGridView1.Rows[i].Cells[6].Value = image2;
                    //dataGridView1.Rows.Add( image2);
                //neu lam else
                //Image image = null;
                //dataGridView1.Rows[i].Cells[6].Value = image;

            }
                dataGridView1.Columns.Add(img);





            //combo box
            //comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboCategory.SelectedIndex = 0;

            this.dataGridView1.Columns["productid"].Visible = false;
            this.dataGridView1.Columns["categoryid"].Visible = false;

            flowLayoutPanel1.AutoScroll = true;
        }
    }
}
