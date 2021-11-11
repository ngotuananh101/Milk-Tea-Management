using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaManagement.Entity
{
    class Product
    {
        private int productId;
        private string productName;
        private int quantity;
        private double price;
        private string origin;
        private int categoryId;
        private byte image;

        public Product()
        {
        }

        public Product(int productId, string productName, int quantity, double price, string origin, int categoryId, byte image)
        {
            this.productId = productId;
            this.productName = productName;
            this.quantity = quantity;
            this.price = price;
            this.origin = origin;
            this.categoryId = categoryId;
            this.image = image;
        }

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public string Origin { get => origin; set => origin = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public byte Image { get => image; set => image = value; }
    }
}
