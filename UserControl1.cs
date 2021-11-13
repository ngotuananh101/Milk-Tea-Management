using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoDataAccess
{


    public partial class UserControl1 : UserControl
    {
        public event EventHandler PropertyChange;
        public string ProductID { get; set; }
        public string ProductName
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public decimal ProductPrice
        {
            get
            {
                try
                {
                    decimal price = Convert.ToDecimal(textBox1.Text);
                    return price;
                }
                catch
                {
                    return 0;
                }

            }
            set { textBox1.Text = value.ToString(); }
        }
        public int Quantity
        {
            get { return Convert.ToInt32(numericUpDown1.Value); }
            set { numericUpDown1.Value = value; }
        }
        public UserControl1()
        {
            InitializeComponent();
        }

        public UserControl1(string ProductID, string ProductName, decimal Price, int Quantity)
        {
            InitializeComponent();
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.ProductPrice = Price;
            this.Quantity = Quantity;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (PropertyChange != null) PropertyChange(this, null);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (PropertyChange != null) PropertyChange(this, null);
        }

        public override bool Equals(object obj)
        {
            UserControl1 p = (UserControl1)obj;
            return this.ProductID.Equals(p.ProductID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Quantity had to be 0 
            this.ProductID = "";
            this.ProductName = null;
            this.Quantity = 0;
            this.Parent.Controls.Remove(this);



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
