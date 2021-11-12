using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MenuCRUD;
using Microsoft.Data.SqlClient;

namespace MilkTeaManagement
{
    public partial class AdminProduct : Form
    {
        SqlConnection con = new SqlConnection("Data Source=HAKU;Initial Catalog = MilkTea; User ID = haku; Password=321");
        public AdminProduct()
        {
            InitializeComponent();
        }

        ProductBusiness catList = new ProductBusiness();

        void LoadProduct()
        {
            var products = catList.GetProducts();
            txtProductId.DataBindings.Clear();
            txtProductName.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtOrigin.DataBindings.Clear();
            comboBox1.DataBindings.Clear();
            //txtPicture.DataBindings.Clear();

            txtProductId.DataBindings.Add("Text", products, "ProductId");
            txtProductName.DataBindings.Add("Text", products, "ProductName");
            txtQuantity.DataBindings.Add("Text", products, "Quantity");
            txtPrice.DataBindings.Add("Text", products, "Price");
            txtOrigin.DataBindings.Add("Text", products, "Origin");
            comboBox1.DataBindings.Add("Text", products, "CategoryId");
            //txtPicture.DataBindings.Add("Text", products, "Picture");







            dataGridView1.DataSource = products;

        }

        bool ValidForm()
        {
            bool flag = true;

            string strError = "";

            Regex regProductId = new Regex(@"^[0-9\s]+$");
            if (!regProductId.IsMatch(txtProductId.Text.Trim()))
            {
                flag = false;
                strError += "ProductId can't be empty & only contain number!\n";
                txtProductId.Focus();
            }

            Regex regProductName = new Regex(@"^[0-9a-zA-Z\s]+$");
            if (!regProductName.IsMatch(txtProductName.Text.Trim()))
            {
                flag = false;
                strError += "ProductName can't be empty or contain special character!\n";
                txtProductName.Focus();

            }

            Regex regQuantity = new Regex(@"^[0-9\s]+$");
            if (!regQuantity.IsMatch(txtQuantity.Text.Trim()))
            {
                flag = false;
                strError += "Invalid Quantity!\n";
                txtQuantity.Focus();

            }

            Regex regPrice = new Regex(@"^[0-9\s]+$");
            if (!regPrice.IsMatch(txtPrice.Text.Trim()))
            {
                flag = false;
                strError += "Invalid Price\n";
                txtPrice.Focus();

            }

            Regex regOrigin = new Regex(@"^[0-9a-zA-Z\s]+$");
            if (!regOrigin.IsMatch(txtOrigin.Text.Trim()))
            {
                flag = false;
                strError += "Invalid Origin\n";
                txtPrice.Focus();

            }



            if (flag == false)
            {
                MessageBox.Show(strError);
            }
            return flag;
        }
        private void Modify_Enter(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg;*.png)|*.jpg|*.jpeg|*.png", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    txtPicture.Text = ofd.FileName;
                    //Insert(ConvertImageToBytes(pictureBox1.Image));
                }
            }
        }

        private void AdminProduct_Load(object sender, EventArgs e)
        {
            LoadProduct();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select CategoryId from Category", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();

            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "CategoryId";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            txtOrigin.Text = "";
            comboBox1.Text = "";
            txtPicture.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidForm())
            {
                //hien thi du lieu tren form len 1 messagebox
                String strResult = "";
                strResult += "ProductId: " + txtProductId.Text.Trim() + "\n";
                strResult += "ProductName: " + txtProductName.Text.Trim() + "\n";
                strResult += "Quantity: " + txtQuantity.Text.Trim() + "\n";
                strResult += "Price: " + txtPrice.Text.Trim() + "\n";
                strResult += "Origin: " + txtOrigin.Text.Trim() + "\n";
                strResult += "CategoryId: " + comboBox1.Text.Trim();

                MessageBox.Show(strResult);
            }
            try
            {
                Insert(Convert.ToInt32(txtProductId.Text), txtProductName.Text, Convert.ToInt32(txtQuantity.Text)
                    , Convert.ToInt32(txtPrice.Text), txtOrigin.Text, Convert.ToInt32(comboBox1.Text), ConvertImageToBytes(pictureBox1.Image));

                LoadProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public void Insert(int ProductId, string ProductName, int Quantity, int Price, String Origin, int CategoryId, byte[] image)
        {
            con.Open();
            using (SqlCommand command = new SqlCommand("Insert into Product(ProductId, ProductName, Quantity, Price, Origin, CategoryId, Picture) values(@ProductId, @ProductName, @Quantity, @Price, @Origin, @CategoryId, @image)", con))
            {
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@ProductId", ProductId);
                command.Parameters.AddWithValue("@ProductName", ProductName);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                command.Parameters.AddWithValue("@Price", Price);
                command.Parameters.AddWithValue("@Origin", Origin);
                command.Parameters.AddWithValue("@CategoryId", CategoryId);
                command.Parameters.AddWithValue("@image", image);
                command.ExecuteNonQuery();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                ProductName = txtProductName.Text,
                Quantity = Convert.ToInt32(txtQuantity.Text),
                Price = Convert.ToInt32(txtPrice.Text),
                Origin = txtOrigin.Text,
                CategoryId = Convert.ToInt32(comboBox1.Text)
            };
            catList.UpdateProduct(product);
            LoadProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                ProductName = txtProductName.Text,
                Quantity = Convert.ToInt32(txtQuantity.Text),
                Price = Convert.ToInt32(txtPrice.Text),
                Origin = txtOrigin.Text,
                CategoryId = Convert.ToInt32(comboBox1.Text)

            };
            catList.DeleteProduct(product);
            LoadProduct();
        }
    }
}
