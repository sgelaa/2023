using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookNation.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }
        public int AppUserId { get; set; }
    }
}