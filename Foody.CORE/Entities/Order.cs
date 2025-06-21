using Foody.CORE.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.CORE.Entities
{
    public enum OrderState
    {
        Pending = 1,
        Approved = 2,
        Preparing = 3,
        Completed = 4,
        Rejected = 5
    }

    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public OrderState OrderState { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal TotalPrice => OrderItems.Sum(i => i.Quantity * i.ListPrice);
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }        
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
