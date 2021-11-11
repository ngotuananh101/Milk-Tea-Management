using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaManagement.Entity
{
    class Discount
    {
        private string discountId;
        private int productId;
        private DateTime startDate;
        private DateTime endDate;
        private int value;

        public Discount()
        {
        }

        public Discount(string discountId, int productId, DateTime startDate, DateTime endDate, int value)
        {
            this.discountId = discountId;
            this.productId = productId;
            this.startDate = startDate;
            this.endDate = endDate;
            this.value = value;
        }

        public string DiscountId { get => discountId; set => discountId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public int Value { get => value; set => this.value = value; }
    }
}
