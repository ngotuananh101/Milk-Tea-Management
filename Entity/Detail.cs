using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaManagement.Entity
{
    class Detail
    {
        private int orderId;
        private int productId;
        private double price;
        private int quantity;
        private DateTime date;

        public Detail()
        {
        }

        public Detail(int orderId, int productId, double price, int quantity, DateTime date)
        {
            this.orderId = orderId;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
            this.date = date;
        }

        public int OrderId { get => orderId; set => orderId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
