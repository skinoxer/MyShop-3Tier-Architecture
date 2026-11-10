using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Entities
{
    public class Order:BaseEntity
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalPrice { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
